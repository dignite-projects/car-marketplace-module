/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { CarConfig } from './car';
// import { BrandService, ModelService, TrimService } from 'projects/car-marketplace/proxy/public/cars';
import { async } from '@angular/core/testing';
import { CarService } from 'projects/car-marketplace/src/services/car.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
// import { UsedCarService } from 'projects/car-marketplace/proxy/dealer-platform/cars';
import { Location } from '@angular/common';

import { NzUploadFile } from 'ng-zorro-antd/upload';
import { UsedCarService } from 'projects/car-marketplace/proxy/dealer-platform/cars/used-car.service';
import { BrandService, ModelService, TrimService } from 'projects/car-marketplace/proxy/public/cars';
import { FileDescriptorService } from 'projects/car-marketplace/proxy/dignite/file-explorer/files';
import { Observable, Observer, filter } from 'rxjs';
import { DomSanitizer } from '@angular/platform-browser';
import { environment } from 'projects/dev-app/src/environments/environment';
import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { CarColorService } from 'projects/car-marketplace/src/services/car-color.service';
import { CarColorOptions } from 'projects/car-marketplace/config/src/enums/car-color';
import { TagsOptions } from 'projects/car-marketplace/config/src/enums/tags';




@Component({
  selector: 'lib-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../../../style/index.scss']
})
export class CreateComponent {


  /*  */
  constructor(
    private BrandService: BrandService,
    private ModelService: ModelService,
    private TrimService: TrimService,
    private CarService: CarService,
    private router: Router,
    private modal: NzModalService,
    private message: NzMessageService,
    private _UsedCarService: UsedCarService,
    public _location: Location,
    public _FileDescriptorService: FileDescriptorService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private http: HttpClient,
    private msg: NzMessageService,
    private _CarColorService: CarColorService
  ) {

  }


  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.route.queryParams.subscribe(async (params) => {
      console.log(params, '跳转页面接收数据');

      this.brandList = await this.getBrandList()
      this.carStatusList = await this.CarService.getcarStatusName()
      this.getImageConfiguration()
      if (params.usedCarId) {
        this.isEdit = true
        this.usedCarId = params.usedCarId
        this.UsedCarDetail = await this.getUsedCarDetail()
      }
    })
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
  TagsList: any[] = TagsOptions

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
      this._UsedCarService.get(this.usedCarId).subscribe(async(res: any) => {
        console.log(res, '获取二手车详情', this.fileCells);
        this.brandID = res.brandId
        // this.BrandChange(this.brandID)
        this.modelList = await this.getModelList(res.brandId)
        // this.ModelChange(this.modelID)
        this.modelID = res.modelId
        this.trimList = await this.gettrimList(res.modelId)
        this.CarCreateGroup = new CarConfig({ ...res })
        resolve(res)
      })
    })
  }

  /**获取品牌列表 */
  getBrandList() {
    return new Promise((resolve, rejects) => {
      this.BrandService.getList().subscribe(res => {
        console.log(res.items, '获取品牌列表');
        resolve(new Array(...res.items))
      })
    })
  }
  /**品牌列表改变 */
  async BrandChange(event) {
    this.modelList = await this.getModelList(event)
    console.log('品牌列表改变', event, this.modelList);
    this.CarCreateGroup.name = ''
    this.modelID = ''
    this.CarCreateGroup.trimId = ''
  }
  /**获取车型列表 */
  getModelList(brandId) {
    return new Promise((resolve, rejects) => {
      this.ModelService.getList({
        brandId: brandId
      }).subscribe(async (res) => {
        console.log(res.items,'获取车型列表',);
        this._modelList_copy = res.items
        // let list: any = await this.getgropuValue(res.items, 'group')
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
      // return list
    })
  }
  /**车型列表选择改变 */
  async ModelChange(event) {
    this.trimList = await this.gettrimList(event)
    console.log('车型列表选择改变', event, this.trimList);
    this.CarCreateGroup.name = ''
    this.CarCreateGroup.trimId = ''
  }
  /**获取车款列表 */
  gettrimList(ModelId) {
    return new Promise((resolve, rejects) => {
      this.TrimService.getList({
        modelId: ModelId
      }).subscribe(async (res) => {
        this._trimList_copy = res.items
        let list: any = await this.getgropuValue(res.items, 'year')
        // console.log(res.items, '获取车款列表',trimList);
        resolve(new Array(...list))
      })
    })
  }
  /**车款列表选择 */
  trimChange(event) {
    let findbrand = this.brandList.find((el) => el.id === this.brandID)
    let findtrim = this._trimList_copy.find((el) => el.id === event)
    console.log('车款列表选择', event, findbrand, findtrim);
    // this.setUsedCarName()
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
        console.log('获取图片容器', imagemess, this.usedCarId);

        imagemess.map(el => {
          el.src = el.url
        })
        // console.log('获取图片信息',new Array(...imagemess));
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

  /** 标签*/

  checkChange(e: boolean, key: string): void {
    console.log(e, '标签', key);
    if (e) {
      this.CarCreateGroup.tags.push(key)
    } else {
      this.CarCreateGroup.tags.splice(this.CarCreateGroup.tags.includes(key), 1)
    }
  }


  /**提交 */
  submitCreate() {
    console.log('提交表单', this.brandID, this.CarCreateGroup, this.fileCells, '需要删除的图片', this.deleteimg);
// return
    if (this.isEdit) {
      this.modal.confirm({
        nzTitle: '确定要更新这个二手车信息吗',
        // nzContent: `<b style="color: red;">${data.name}</b>`,
        nzOkText: '确认',
        nzOkType: 'primary',
        // nzOkDanger: true,
        nzOnOk: () => {
          const messageid = this.message.loading('更新中', { nzDuration: 0 }).messageId;
          this._UsedCarService.update(this.usedCarId, {
            ...this.CarCreateGroup
          }).subscribe(res => {
            setTimeout(async () => {
              // await this.requestDeleteimg()
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
      // nzContent: `<b style="color: red;">${data.name}</b>`,
      nzOkText: '确认',
      nzOkType: 'primary',
      // nzOkDanger: true,
      nzOnOk: () => {
        const messageid = this.message.loading('提交中', { nzDuration: 0 }).messageId;
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
      this.fileCells.map(async (cell) => {
        cell.fileList.map(async (file) => {
          let formData = new FormData();
          formData.append('file', file, file.name);
          await this.requestImage(
            {
              containerName: 'CarPics',
              cellName: cell.name,
              entityId: this.usedCarId,
            }, formData
          )
        })
      })
      resolve()
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
      const req = new HttpRequest('POST', `${environment.apis.FileExplorer.url}/api/file-explorer/files?containerName=${input.containerName}&cellName=${input.cellName}&entityId=${input.entityId}`, formData, {
      });
      this.http
        .request(req)
        .pipe(filter(e => e instanceof HttpResponse)).subscribe((back) => {
          console.log(back, '上传图片返回');
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
    // console.log('上传图片改变', files, item, filesdispose, this.fileCells);
  }
  previewImage: string | undefined = '';
  previewVisible = false;
  handlePreview(elf) {
    this.previewImage = elf.src
    this.previewVisible = true
  }

  /**删除图片*/
  deleteImage(item, finame) {
    console.log(item, finame, '删除图片');
    // item=[]
    // let deleteimg = []
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
    // return files
    Array.from(files).forEach((item: any, index: any) => {
      item.src = this.sanitizer.bypassSecurityTrustResourceUrl(window.URL.createObjectURL(item));
      filesArray.push(item)
    });
    return filesArray
  }















}