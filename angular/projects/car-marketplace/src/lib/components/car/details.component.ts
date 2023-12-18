/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { CarConfig } from './car';
// import { BrandService, ModelService, TrimService } from 'projects/car-marketplace/proxy/public/cars';
import { async } from '@angular/core/testing';
import { CarService } from 'projects/car-marketplace/src/services/car.service';
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

@Component({
  selector: 'lib-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss', '../../../style/index.scss']
})
export class DetailsComponent {

  constructor(
    private BrandService: BrandService,
    private ModelService: ModelService,
    private TrimService: TrimService,
    private CarService: CarService,
    private modal: NzModalService,
    private message: NzMessageService,
    private _UsedCarService: UsedCarService,
    public _location: Location,
    public _FileDescriptorService: FileDescriptorService,
    private route: ActivatedRoute,
    private sanitizer: DomSanitizer,
    private http: HttpClient,
    private msg: NzMessageService

  ) {

  }
  /**二手车id */
  usedCarId: any = ''
  /**二手车详情 */
  UsedCarDetail: any = ''

  /**品牌ID */
  brandID: string = ''
  /**品牌列表 */
  brandList: any[any] = []
  /**车型ID */
  modelID: string = ''
  /**车型列表 */
  modelList: any[any] = []
  /**车款列表 */
  trimList: any[any] = []
  /**二手车状态列表 */
  carStatusList: any[any] = []
  /**图片容器 */
  fileCells: any[any] = []
  /**上传图片的类型 */
  allowedFileTypeNames: any = ''
  /**最大图片大小 */
  maxBlobSize: any = 0
  /**需要删除的图片 */
  deleteimg: any[] = []

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.route.queryParams.subscribe(async (params) => {
     // console.log(params, '跳转页面接收数据');
      if (params.usedCarId) {
        this.usedCarId = params.usedCarId
        this.brandList = await this.getBrandList()
        this.carStatusList = await this.CarService.getcarStatusName()
        this.getImageConfiguration()
        if (params.usedCarId) {
          this.usedCarId = params.usedCarId
          this.UsedCarDetail = await this.getUsedCarDetail()
        }
      }
    })
  }

  /**获取二手车详情 */
  getUsedCarDetail() {
    return new Promise((resolve, rejects) => {
      this._UsedCarService.get(this.usedCarId).subscribe((res: any) => {
       // console.log(res, '获取二手车详情', this.fileCells);
        this.brandID = res.brandId
        this.BrandChange(this.brandID)
        this.modelID = res.modelId
        this.ModelChange(this.modelID)
        this.UsedCarDetail = res
        resolve(res)
      })
    })
  }

  /**获取品牌列表 */
  getBrandList() {
    return new Promise((resolve, rejects) => {
      this.BrandService.getList().subscribe(res => {
       // console.log(res.items, '获取品牌列表');
        resolve(new Array(...res.items))
      })
    })
  }
  /**品牌列表改变 */
  async BrandChange(event) {
   // console.log('品牌列表改变', event);
    this.modelList = await this.getModelList(event)
  }
  /**获取车型列表 */
  getModelList(brandId) {
    return new Promise((resolve, rejects) => {
      this.ModelService.getList({
        brandId: brandId
      }).subscribe(res => {
       // console.log(res.items, '获取车型列表');
        resolve(new Array(...res.items))
      })
    })
  }
  /**车型列表选择改变 */
  async ModelChange(event) {
    this.trimList = await this.gettrimList(event)
  }
  /**获取车款列表 */
  gettrimList(ModelId) {
    return new Promise((resolve, rejects) => {
      this.TrimService.getList({
        modelId: ModelId
      }).subscribe(res => {
       // console.log(res.items, '获取车款列表');
        resolve(new Array(...res.items))
      })
    })
  }



  /**获取图片容器 */
  getImageConfiguration() {
    this._FileDescriptorService.getFileContainerConfiguration('CarPics').subscribe(async (res) => {
      let allowedFileTypeNames = []
      res.allowedFileTypeNames.map(el => {
        allowedFileTypeNames.push('image/' + el.slice(1))
      })

      let imagemess = await this.getImage(this.usedCarId)
    

      imagemess.map(el => {
        el.src = el.url
      })
      await res.fileCells.map(async (el: any) => {
        el.fileList = []
        el.fileListView = imagemess.filter(elV => elV.cellName === el.name)
      })
      this.fileCells = res.fileCells
      this.allowedFileTypeNames = allowedFileTypeNames.toString()
      this.maxBlobSize = res.maxBlobSize
     // console.log('获取图片容器', imagemess, this.fileCells );
    })
  }
  previewImage: string | undefined = '';
  previewVisible = false;
  handlePreview(elf) {
    this.previewImage = elf.src
    this.previewVisible = true
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


}
