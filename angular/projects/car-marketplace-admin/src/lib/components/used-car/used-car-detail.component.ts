import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { BrandService, ModelService, TrimService } from '../../../../proxy/src/proxy/public/cars';
import { usedCarStatusOptions } from '../../../../proxy/src/proxy/used-cars/used-car-status.enum';
import { FileDescriptorService } from '../../../../proxy/src/proxy/dignite/file-explorer/files';
import { UsedCarService } from '../../../../proxy/src/proxy/admin/used-cars';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { CarColorOptions } from '@dignite/car-marketplace-dealer-platform';
// import { NzImageService } from 'ng-zorro-antd/image';


@Component({
  selector: 'lib-used-car-detail',
  templateUrl: './used-car-detail.component.html',
  styleUrls: ['./used-car-detail.component.scss']
})
export class UsedCarDetailComponent {
  constructor(
    private _BrandService: BrandService,
    private _ModelService: ModelService,
    private _TrimService: TrimService,
    public _FileDescriptorService: FileDescriptorService,
    private _UsedCarService: UsedCarService,
    public _location: Location,
    private route: ActivatedRoute,
  ) { }


  /**表单数据 */
  // usedCarForm: FormGroup = this.fb.group({ ...new UsedCarConfig() })

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
  UsedCarInfo: any = ''
  /**二手车状态列表 */
  usedCarStatusList: any[any] = usedCarStatusOptions;

  /**颜色列表 */
  CarColorList: any[] = CarColorOptions
  // 

  /**图片容器 */
  fileCells: any[any] = []

  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.

    let usedCarId = this.route.snapshot.params.id
    if (usedCarId) {
      this.usedCarId = usedCarId
      this.UsedCarInfo = await this.getUsedCarDetail()
      this.getImageConfiguration()
    }

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
        // this.usedCarForm.setValue(new UsedCarConfig({ ...res }));
        resolve(res)
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
          name: elg,
          models: arr1.filter(elc => elc[groupname] == elg)
        })
      })
      resolve(list)
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
  /**品牌改变 */
  async brandChange(event) {
    // console.log('品牌改变', this.brandId);
    this.modelList = await this.getModelList(this.brandId)
    // this.usedCarForm.patchValue({ trimId: '' });
    // this.trimList = []
  }

  /**获取车型列表 */
  getModelList(brandId) {
    return new Promise((resolve, rejects) => {
      this._ModelService.getList({
        brandId: brandId
      }).subscribe(async (res) => {
        // console.log(res.items, '获取车型列表');
        resolve(new Array(...res.items))
      })
    })
  }

  /**车型列表选择改变 */
  async modelChange(event) {
    this.trimList = await this.getgropuValue(await this.gettrimList(this.modelId), 'year')
    // this.usedCarForm.patchValue({ trimId: '' });
  }
  /**获取车款列表 */
  gettrimList(ModelId) {
    return new Promise((resolve, rejects) => {
      this._TrimService.getList({
        modelId: ModelId
      }).subscribe(async (res) => {
        // console.log(res.items, '获取车款列表');
        resolve(new Array(...res.items))
      })
    })
  }



  /**获取图片容器 */
  getImageConfiguration() {
    return new Promise<void>((resolve, reject) => {
      this._FileDescriptorService.getFileContainerConfiguration('CarPics').subscribe(async (res) => {
        // let allowedFileTypeNames = []
        // res.allowedFileTypeNames.map(el => {
        //   allowedFileTypeNames.push('image/' + el.slice(1))
        // })
        let imagemess = await this.getImage(this.usedCarId)
        imagemess.map(el => el.src = el.url)
        let fileCellsConfig = {}
        res.fileCells.map(async (el: any) => {
          el.fileList = imagemess.filter(elV => elV.cellName === el.name)
          fileCellsConfig[el.name] = [el.name, Validators.required]
        })
        this.fileCells = res.fileCells
        // let fileCellsgroup = this.fb.group({ ...fileCellsConfig })
        // this.usedCarForm.addControl('fileCellsarr', fileCellsgroup);
        console.log(this.fileCells,'获取图片容器');
        // this.allowedFileTypeNames = allowedFileTypeNames.toString()
        // this.maxBlobSize = res.maxBlobSize
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

}
