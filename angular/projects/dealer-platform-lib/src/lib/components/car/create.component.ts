/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component, ElementRef, ViewChild } from '@angular/core';
import { CarConfig } from './car';
import { ActivatedRoute, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Location } from '@angular/common';
import { filter } from 'rxjs';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { CarService, TagsService } from '../../services';
import { UsedCarService } from '../../proxy/dealer-platform/cars';
import { FileDescriptorService } from '../../proxy/dignite/file-explorer/files';
import { BrandService, ModelService, TrimService } from '../../proxy/public/cars';
import { CarColorOptions } from '../../enums';
import { EnvironmentService } from '@abp/ng.core';




@Component({
  selector: 'lib-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../style/index.scss']
})
export class CreateComponent {


  /*  */
  constructor(
    private _BrandService: BrandService,
    private _ModelService: ModelService,
    private _TrimService: TrimService,
    private _CarService: CarService,
    private modal: NzModalService,
    private message: NzMessageService,
    private _UsedCarService: UsedCarService,
    public _location: Location,
    public _FileDescriptorService: FileDescriptorService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private http: HttpClient,
    private _TagsService: TagsService,
    private environment: EnvironmentService,
    private router: Router
  ) {

  }


  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    // 
    // this.usedCarId=
    let usedCarId = this.route.snapshot.params.id
    this.TagsList = await this._TagsService.getTagList()
    this.TagsListyushe = await this._TagsService.TagsList
    this.brandList = await this.getBrandList()
    this.carStatusList = await this._CarService.getcarStatusName()
    this.getImageConfiguration()
    if (usedCarId) {
      this.isEdit = true
      this.usedCarId = usedCarId
      this.UsedCarDetail = await this.getUsedCarDetail()
    }


  }
  /**是否是编辑状态 */
  isEdit: boolean = false
  /**二手车状态列表 */
  carStatusList: any[any] = []
  /**品牌ID */
  brandID: string = ''
  /**品牌列表 */
  brandList: any[any] = []
  /**颜色列表 */
  CarColorList: any[] = CarColorOptions
  /** Tags列表 */
  TagsList: any[] = []
  TagsListyushe: any[] = []
  /**车型ID */
  modelID: string = ''
  /**车型列表 */
  modelList: any[any] = []
  _modelList_copy: any[any] = []
  /**车款列表 */
  trimList: any[any] = []
  _trimList_copy: any[any] = []
  /**二手车配置 */
  CarCreateGroup: any = new CarConfig()
  /**二手车id */
  usedCarId: any = ''
  /**二手车详情 */
  UsedCarDetail: any = ''

  /**图片容器 */
  fileCells: any[any] = []
  /**上传图片的类型 */
  allowedFileTypeNames: any = ''
  /**最大图片大小 */
  maxBlobSize: any = 0
  /**需要删除的图片 */
  deleteimg: any[] = []
  /**获取二手车详情 */
  getUsedCarDetail() {
    return new Promise((resolve, rejects) => {
      this._UsedCarService.get(this.usedCarId).subscribe(async (res: any) => {
        // console.log(res, '获取二手车详情', this.fileCells);
        this.brandID = res.brandId
        this.modelList = await this.getModelList(res.brandId)
        this.modelID = res.modelId
        this.trimList = await this.gettrimList(res.modelId)
        let getTagList = this._TagsService.getTagList()
        this.TagsList = getTagList.filter(item => res.tags.indexOf(item) === -1)
        this.CarCreateGroup = new CarConfig({ ...res })
        resolve(res)
      })
    })
  }

  /**获取品牌列表 */
  getBrandList() {
    return new Promise((resolve, rejects) => {
      this._BrandService.getList().subscribe(res => {
        // console.log(res.items, '获取品牌列表');
        resolve(new Array(...res.items))
      })
    })
  }
  /**品牌列表改变 */
  async BrandChange(event) {
    this.modelList = await this.getModelList(event)
    // console.log('品牌列表改变', event, this.modelList);
    this.CarCreateGroup.name = ''
    this.modelID = ''
    this.CarCreateGroup.trimId = ''
  }
  /**获取车型列表 */
  getModelList(brandId) {
    return new Promise((resolve, rejects) => {
      this._ModelService.getList({
        brandId: brandId
      }).subscribe(async (res) => {
        // console.log(res.items,'获取车型列表',);
        this._modelList_copy = res.items
        resolve(new Array(...res.items))
      })
    })
  }
  /**获取设置分组数据 */
  getgropuValue(arr1, groupname) {
    return new Promise((resolve, rejects) => {
      const uniqueGroups = arr1.reduce((accumulator, currentItem) => {
        if (!accumulator.includes(currentItem[groupname])) {
          accumulator.push(currentItem[groupname]);
        }
        return accumulator;
      }, []);
      let list = []
      uniqueGroups.forEach(async (elg) => {
        list.push({
          group: elg,
          children: arr1.filter(elc => elc[groupname] == elg)
        })
      })
      resolve(list)
    })
  }
  /**车型列表选择改变 */
  async ModelChange(event) {
    this.trimList = await this.gettrimList(event)
    // console.log('车型列表选择改变', event, this.trimList);
    this.CarCreateGroup.name = ''
    this.CarCreateGroup.trimId = ''
  }
  /**获取车款列表 */
  gettrimList(ModelId) {
    return new Promise((resolve, rejects) => {
      this._TrimService.getList({
        modelId: ModelId
      }).subscribe(async (res) => {
        this._trimList_copy = res.items
        let list: any = await this.getgropuValue(res.items, 'year')
        resolve(new Array(...list))
      })
    })
  }
  /**车款列表选择 */
  trimChange(event) {
    let findbrand = this.brandList.find((el) => el.id === this.brandID)
    let findtrim = this._trimList_copy.find((el) => el.id === event)
    // console.log('车款列表选择', event, findbrand, findtrim);
    this.CarCreateGroup.name = `${findbrand.name} ${findtrim.year}${findtrim.name}`
  }

  /**获取图片容器 */
  getImageConfiguration() {
    return new Promise<void>((resolve, reject) => {
      this._FileDescriptorService.getFileContainerConfiguration('CarPics').subscribe(async (res) => {
        let allowedFileTypeNames = []
        res.allowedFileTypeNames.map(el => {
          allowedFileTypeNames.push('image/' + el.slice(1))
        })
        let imagemess = await this.getImage(this.usedCarId)
        imagemess.map(el => el.src = el.url)
        await res.fileCells.map(async (el: any) => {
          el.fileList = []
          el.fileListView = imagemess.filter(elV => elV.cellName === el.name)
        })
        this.fileCells = res.fileCells
        this.allowedFileTypeNames = allowedFileTypeNames.toString()
        this.maxBlobSize = res.maxBlobSize
        resolve()
      })
    })

  }
  /**获取图片信息 */
  getImage(usedCarId: any): any {
    return new Promise((resolve, reject) => {
      if (!usedCarId) resolve([])
      this._FileDescriptorService.getList({
        containerName: 'CarPics',
        entityId: `${usedCarId}`,
        skipCount: 0,
        maxResultCount: 100
      }).subscribe(res => {
        resolve(usedCarId ? res.items : [])
      })
    })
  }



  /** 标签选择*/
  checkChange(key: string): void {
    console.log('标签选择', key);
    if (this.isdelete) return
    if (this.CarCreateGroup.tags.indexOf(key) === -1) {
      this.CarCreateGroup.tags.push(key)
      this.TagsList.splice(this.TagsList.indexOf(key), 1)
    }

  }
  /**标签删除 */
  checkClose(key: string): void {
    console.log('标签删除');
    this.CarCreateGroup.tags.splice(this.CarCreateGroup.tags.indexOf(key), 1)
    let getTagList = this._TagsService.getTagList()
    if (getTagList.indexOf(key) == -1) {
      this._TagsService.pushstorageTags(key)
    }
    this.TagsList = this._TagsService.getTagList().filter(item => this.CarCreateGroup.tags.indexOf(item) === -1)
  }
  /**删除缓存的tag */
  storageClose(item) {
    console.log('删除缓存的tag', item);
    this.isdelete = true
    this._TagsService.deleteTag(item).then(() => {
      this.isdelete = false
      this.TagsList = this._TagsService.getTagList()
    })
  }

  // tags = ['Unremovable', 'Tag 2', 'Tag 3'];
  taInputVisible = false;
  tagInputValue = '';
  isdelete: boolean = false
  @ViewChild('inputElement', { static: false }) inputElement?: ElementRef;



  /**显示输入框 */
  showInput(): void {
    this.taInputVisible = true;
    setTimeout(() => {
      this.inputElement?.nativeElement.focus();
    }, 10);
  }

  handleInputConfirm(): void {
    if (this.tagInputValue && this.TagsList.indexOf(this.tagInputValue) === -1) {
      this.CarCreateGroup.tags.push(this.tagInputValue)
      this._TagsService.pushstorageTags(this.tagInputValue)
    }
    this.tagInputValue = '';
    this.taInputVisible = false;
  }

  /**验证图片是否提交 */
  VerifyImageIAO() {
    try {
      this.fileCells.forEach((el => {
        if (el.fileList.length + el.fileListView.length == 0) {
          throw el
        }
      }))
      return
    } catch (error) {
      return error
    }
  }
  VerifyImageIAOboolisnull() {
    try {
      this.fileCells.forEach((el => {
        if (el.fileList.length + el.fileListView.length == 0) {
          throw false
        }
      }))
      return true
    } catch (error) {
      return error
    }
  }

  /**提交 */
  submitCreate() {
    // console.log('提交表单', this.brandID, this.CarCreateGroup, this.fileCells, '需要删除的图片', this.deleteimg);
    let Verifyback = this.VerifyImageIAO()
    if (Verifyback) return this.message.info(`请上传'${Verifyback.displayName}'图片`);

    // return
    if (this.isEdit) {
      this.modal.confirm({
        nzTitle: '确定要更新这个二手车信息吗',
        nzOkText: '确认',
        nzOkType: 'primary',
        nzOnOk: () => {
          const messageid = this.message.loading('正在更新中', { nzDuration: 0 }).messageId;
          this._UsedCarService.update(this.usedCarId, {
            ...this.CarCreateGroup
          }).subscribe(res => {
            setTimeout(async () => {
              await this.requestDeleteimg()
              await this.reqfengzhaung()
              this.message.remove(messageid);
              this.message.info('已完成');
              this._location.back();
            }, 1200)
          })
        },
        nzCancelText: '取消',
        nzOnCancel: () => {
        }
      });

      return
    }
    this.modal.confirm({
      nzTitle: '确定要提交这个二手车吗',
      nzOkText: '确认',
      nzOkType: 'primary',
      nzOnOk: () => {
        const messageid = this.message.loading('正在提交中', { nzDuration: 0 }).messageId;
        this._UsedCarService.create({
          ...this.CarCreateGroup
        }).subscribe(res => {
          /**二手车id */
          this.usedCarId = res.id
          /**二手车详情 */
          this.UsedCarDetail = res
          setTimeout(async () => {
            await this.reqfengzhaung()
            this.message.remove(messageid);
            this.message.info('已完成');
            this._location.back();
          }, 1200)
        })
      },
      nzCancelText: '取消',
      nzOnCancel: () => {
      }
    });

  }

  /**上传图片的封装方法 */
  reqfengzhaung() {
    return new Promise<void>((resolve, reject) => {
      let req_fileCells=this.fileCells.filter((el)=>el.fileList.length>0)
      let count = 0
      req_fileCells.map(async (cell, index1) => {
        cell.fileList.map(async (file) => {
          let formData = new FormData();
          formData.append('file', file, file.name);
          this.requestImage(
            {
              containerName: 'CarPics',
              cellName: cell.name,
              entityId: this.usedCarId,
            }, formData
          ).then(() => {
            count++
            if (req_fileCells.length === count) {
              resolve()
            }
          })
        })
      })
    })
  }
  /***删除指定照片 */
  requestDeleteimg() {
    return new Promise<void>((resolve, reject) => {
      if (this.deleteimg.length === 0) resolve()
      this.deleteimg.map(async (image, index) => {
        await this._FileDescriptorService.delete(image.id).subscribe(res => {
          if (this.deleteimg.length - 1 === index) {
            resolve()
          }
        })
      })

    })
  }

  /**提交图片到服务器 */
  requestImage(input, formData) {
    return new Promise((resolve, reject) => {
      const req = new HttpRequest('POST', `${this.environment.getEnvironment().apis.FileExplorer.url}/api/file-explorer/files?containerName=${input.containerName}&cellName=${input.cellName}&entityId=${input.entityId}`, formData, {
      });
      this.http
        .request(req)
        .pipe(filter(e => e instanceof HttpResponse)).subscribe((back) => {
          // console.log(back, '上传图片返回');
          resolve(back)
        })

    })
  }




  /**上传图片改变 */
  UploadFlieChange(files, item) {
    let filesdispose = this.readFile(files.target.files)
    this.fileCells.map(elc => {
      if (elc.name === item.name) {
        elc.fileList = filesdispose
      }
    })
  }
  previewImage: string | undefined = '';
  previewVisible = false;
  handlePreview(elf) {
    this.previewImage = elf.src
    this.previewVisible = true
  }

  /**删除图片*/
  deleteImage(item, finame) {
    // console.log(item, finame, '删除图片');
    this.fileCells.map(async (el) => {
      if (el.name === item.name) {
        if (finame == 'fileListView') {
          this.deleteimg.push(...el[finame])
        }
        el[finame] = []
      }
    })
  }
  /***/
  /* 读取文件信息 */
  readFile(files: any) {
    let _that = this
    let filesArray = []
    Array.from(files).forEach((item: any, index: any) => {
      item.src = this.sanitizer.bypassSecurityTrustResourceUrl(window.URL.createObjectURL(item));
      filesArray.push(item)
    });
    return filesArray
  }















}
