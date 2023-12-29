import { Component, EventEmitter, Input, Output } from '@angular/core';
import { EnvironmentService } from '@abp/ng.core';
import { HttpClient, HttpEvent, HttpEventType, HttpRequest, HttpResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsedCarConfig } from '../used-car-config';
import { BrandService, ModelService, TrimService } from '../../../../../proxy/src/proxy/public/cars';
import { usedCarStatusOptions } from '../../../../../proxy/src/proxy/used-cars/used-car-status.enum';
import { TagsService } from '../../../services';
import { CarColorOptions } from '../../../enums';
import { FileDescriptorService } from '../../../../../proxy/src/proxy/dignite/file-explorer/files';
import { DomSanitizer } from '@angular/platform-browser';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { UsedCarService } from '../../../../../proxy/src/proxy/dealer-platform/used-cars';
import { filter } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd/message';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'lib-used-car-create-edit-extract',
  templateUrl: './used-car-create-edit-extract.component.html',
  styleUrls: ['./used-car-create-edit-extract.component.scss']
})
export class UsedCarCreateEditExtractComponent {
  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private environment: EnvironmentService,
    private _BrandService: BrandService,
    private _ModelService: ModelService,
    private _TrimService: TrimService,
    private _tagsService: TagsService,
    public _FileDescriptorService: FileDescriptorService,
    private sanitizer: DomSanitizer,
    private _confirmationService: ConfirmationService,
    private _UsedCarService: UsedCarService,
    private FileDescriptorService: FileDescriptorService,
    private message: NzMessageService,
    public _location: Location,
    private router: Router,
    private route: ActivatedRoute,
  ) { }

  /**表单数据 */
  usedCarForm: FormGroup = this.fb.group({ ...new UsedCarConfig() })

  /**品牌列表 */
  brandList: any[any] = []

  /**品牌ID */
  brandId: string = ''

  /**车型列表 */
  modelList: any[any] = []

  /**车型ID */
  modelId: string = ''

  /**车款列表 */
  trimList: any[any] = []

  /**车款id */
  trimId: string = ''

  /**二手车id */
  usedCarId: any = ''

  /**二手车详情 */
  UsedCarDetail: any = ''

  /**二手车状态列表 */
  usedCarStatusList: any[any] = usedCarStatusOptions;

  /**颜色列表 */
  CarColorList: any[] = CarColorOptions

  /**图片容器 */
  fileCells: any[any] = []

  /**预设标签列表 */
  TagsList: any[any] = this._tagsService.getTagList()

  /**是否显示标签编辑 */
  taInputVisible: boolean = false

  /**标签编辑内容 */
  tagInputValue: string = ''

  /**是否是标签删除 */
  isTagDelete: boolean = false

  /**图片容器中需要删除的图片 */
  deleteimg: any[] = []

  /**上传图片的类型 */
  allowedFileTypeNames: any = ''

  /**最大图片大小 */
  maxBlobSize: any = 0

  /**需要预览的图片 */
  previewImage: string | undefined = '';

  /**是否打开图片预览模块 */
  previewVisible = false;

  /**上传失败需要将表单容器的值删除的字段名称 */
  fileCellsErrname: string

  /**页面标题 */
  @Input() title: string

  /**是否开启返回按钮 */
  @Input() isback: string
 
  /**上传失败需要将表单容器的值删除的字段名称 */
  @Input()
  public set fileCellsDeleteNmae(errname: string) {
    if (errname) {
      this.fileCellsErrname = errname
      this.fileCells.map(el => {
        if (el.name === errname) {
          el.fileList = []
        }
      })
      let fileCellsarr = this.usedCarForm.value.fileCellsarr
      fileCellsarr[errname] = ''
      this.usedCarForm.patchValue({ fileCellsarr: fileCellsarr });
    }

  }


  /**提交回调 */
  @Output() submint = new EventEmitter<any>();


  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.brandList = await this.getgropuValue(await this.getBrandList(), 'firstLetter')

    let usedCarId = this.route.snapshot.params.id
    if (usedCarId) {
      this.usedCarId = usedCarId
      this.UsedCarDetail = await this.getUsedCarDetail()
    }
    this.getImageConfiguration()
  }

  /**提交 */
  onsubmitCreateEdit() {
    this.submint.emit({
      formGroupValue: this.usedCarForm.value,
      fileCells: this.fileCells,
      deleteimg: this.deleteimg,
      usedCarId: this.usedCarId
    })
  }

  /**删除图片*/
  deleteImage(item) {
    this.fileCells.map(async (el) => {
      if (el.name === item.name) {
        this.deleteimg.push(...el.fileList.filter(item => item.id))
        el.fileList = []
      }
    })
    let fileCellsarr = this.usedCarForm.value.fileCellsarr
    fileCellsarr[item.name] = ''
    this.usedCarForm.patchValue({ fileCellsarr: fileCellsarr });
  }



  /**获取二手车详情 */
  getUsedCarDetail() {
    return new Promise((resolve, rejects) => {
      this._UsedCarService.get(this.usedCarId).subscribe(async (res: any) => {
        this.brandList = await this.getgropuValue(await this.getBrandList(), 'firstLetter')
        this.brandId = res.brandId
        this.modelList = await this.getModelList(res.brandId)
        this.modelId = res.modelId
        this.trimList = await this.getgropuValue(await this.gettrimList(this.modelId), 'year')
        this.trimId = res.trimId
        res.registrationDate = new Date(res.registrationDate)
        res.commercialInsuranceExpirationDate = new Date(res.commercialInsuranceExpirationDate)
        res.compulsoryInsuranceExpirationDate = new Date(res.compulsoryInsuranceExpirationDate)
        let getTagList = this._tagsService.getTagList()
        this.TagsList = getTagList.filter(item => res.tags.indexOf(item) === -1)
        this.usedCarForm.setValue(new UsedCarConfig({ ...res }));
        resolve(res)
      })
    })
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
        let fileCellsConfig = {}
        res.fileCells.map(async (el: any) => {
          el.fileList = imagemess.filter(elV => elV.cellName === el.name)
          fileCellsConfig[el.name] = [el.fileList.length > 0 ? el.name : '', Validators.required]
        })
        this.fileCells = res.fileCells
        let fileCellsgroup = this.fb.group({ ...fileCellsConfig })
        this.usedCarForm.addControl('fileCellsarr', fileCellsgroup);
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

  /**获取品牌列表 */
  getBrandList() {
    return new Promise((resolve, rejects) => {
      this._BrandService.getList().subscribe(res => {
        resolve(new Array(...res.items))
      })
    })
  }
  /**品牌改变 */
  async brandChange(event) {
    this.modelList = await this.getModelList(this.brandId)
    this.usedCarForm.patchValue({ trimId: '' });
    this.trimList = []
  }

  /**获取车型列表 */
  getModelList(brandId) {
    return new Promise((resolve, rejects) => {
      this._ModelService.getList({
        brandId: brandId
      }).subscribe(async (res) => {
        resolve(new Array(...res.items))
      })
    })
  }

  /**车型列表选择改变 */
  async modelChange(event) {
    this.trimList = await this.getgropuValue(await this.gettrimList(this.modelId), 'year')
    this.usedCarForm.patchValue({ trimId: '' });
  }
  /**获取车款列表 */
  gettrimList(ModelId) {
    return new Promise((resolve, rejects) => {
      this._TrimService.getList({
        modelId: ModelId
      }).subscribe(async (res) => {
        resolve(new Array(...res.items))
      })
    })
  }
  // /**车款列表选择 */
  trimChange(event) {
    let findbrand = this.brandList.find(item =>
      item.models.find(model => model.id === this.brandId)
    )?.models?.find(model => model.id === this.brandId);
    let trimid = event.target.value
    let findtrim = this.trimList.find(item =>
      item.models.find(model => model.id === trimid)
    )?.models?.find(model => model.id === trimid);
    let getname = `${findbrand.name} ${findtrim.year}${findtrim.name}`
    this.usedCarForm.patchValue({ name: getname });
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
          name: elg,
          models: arr1.filter(elc => elc[groupname] == elg)
        })
      })
      resolve(list)
    })
  }

  /** 标签选择*/
  tabCheckChange(key: string): void {
    let tagsArray = this.usedCarForm.value.tags
    if (this.isTagDelete) return
    if (tagsArray.indexOf(key) === -1) {
      tagsArray.push(key)
      this.usedCarForm.patchValue({ tags: tagsArray });
      this.TagsList.splice(this.TagsList.indexOf(key), 1)
    }
  }
  /**标签删除 */
  checkClose(key: string): void {
    let tagsArray = this.usedCarForm.value.tags
    tagsArray.splice(tagsArray.indexOf(key), 1)
    let getTagList = this._tagsService.getTagList()
    if (getTagList.indexOf(key) == -1) {
      this._tagsService.pushstorageTags(key)
    }
    this.TagsList = this._tagsService.getTagList().filter(item => tagsArray.indexOf(item) === -1)
    this.usedCarForm.patchValue({ tags: tagsArray });
  }
  /**删除缓存的tag */
  storageClose(item) {
    this.isTagDelete = true
    this._tagsService.deleteTag(item).then(() => {
      this.isTagDelete = false
      this.TagsList = this._tagsService.getTagList()
    })
  }

  /**标签编辑取消焦点回车确定 */
  handleInputConfirm(): void {
    let tagsArray = this.usedCarForm.value.tags
    if (this.tagInputValue && this.TagsList.indexOf(this.tagInputValue) === -1) {
      tagsArray.push(this.tagInputValue)
      this.usedCarForm.patchValue({ tags: tagsArray });
      this._tagsService.pushstorageTags(this.tagInputValue)
    }
    this.tagInputValue = '';
    this.taInputVisible = false;
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

  /* 读取文件信息 */
  readFile(files: any) {
    let _that = this
    let filesArray = []
    Array.from(files).forEach((item: any, index: any) => {
      // item.src = window.URL.createObjectURL(item);
      item.src = this.sanitizer.bypassSecurityTrustResourceUrl(window.URL.createObjectURL(item));
      filesArray.push(item)
    });
    return filesArray
  }



}
