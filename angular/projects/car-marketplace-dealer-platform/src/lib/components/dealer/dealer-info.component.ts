import { Component, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DealerEditConfig } from './dealer-edit-config';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { filter, from } from 'rxjs';
import { EnvironmentService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { ToastService } from '@dignite/components';
import { DealerService, DealerDto } from '../../proxy/dealer-platform/dealers';
import { FileDescriptorService } from '../../proxy/dignite/file-explorer/files';


@Component({
  selector: 'lib-dealer-info',
  templateUrl: './dealer-info.component.html',
  styleUrls: ['./dealer-info.component.scss'],
})
export class DealerInfoComponent {
  constructor(
    private DealerServiceplatform: DealerService,
    public _FileDescriptorService: FileDescriptorService,
    private fb: FormBuilder,
    private sanitizer: DomSanitizer,
    private http: HttpClient,
    private environment: EnvironmentService,
    private _confirmationService: ConfirmationService,
    private _toastService: ToastService
  ) { 
   
    
  }

  /**
   * 车商信息
   */
  dealerInfo: DealerDto | any;

  /**
   * 封面图片列表
   */
  fileListView_show: any[] = []

  /**
   * 是否打开模态框
   */
  isModalVisible?: boolean

  /**是否正在加载中 */
  isloading: boolean = false

  
  /**表单数据 */
  dealerForm: FormGroup

  /**
   * 编辑封面图片列表
   */
  fileListView: any[] = []

  /**需要删除的图片 */
  deleteimg: any[] = []
  



  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getCarMarketplace()
    // console.log(this.fb,FormBuilder,'测试');
    this.dealerForm = this.fb.group({ ...new DealerEditConfig() })

  }
  /**获取车商信息 */
  getCarMarketplace() {
    this.DealerServiceplatform.findByCurrentUser().subscribe(async (res: DealerDto) => {
      this.dealerInfo = res
      this.fileListView_show = await this.getImage(res?.id)
    })
  }
  /**获取图片信息 */
  getImage(marketplaceCarId: any): any {
    return new Promise((resolve, reject) => {
      this._FileDescriptorService.getList({
        containerName: 'DealerCover',
        entityId: `${marketplaceCarId}`,
        skipCount: 0,
        maxResultCount: 100
      }).subscribe(res => {
        res.items.map((el: any) => {
          el.src = el.url + `?time=${new Date().getTime()}`
        })
        resolve(res.items.length > 0 ? res.items : [])
      })
    })
  }


  /**
    * 编辑
    * @param title 
    */
  EditOpen(title?: string) {
    this.isModalVisible = true
    this.fileListView = this.fileListView_show
    this.dealerForm.setValue({ ...new DealerEditConfig(this.dealerInfo) })
  }

  /**模态框确定 */
  ModalConfirm() {
    let input = this.dealerForm.value
    this._confirmationService
      .warn(`${input.name}`, '确定要更新这个车商信息吗?', {})
      .subscribe(async (status: Confirmation.Status) => {
        if (status == 'confirm') {
          this.isloading = true
          let ids = this._toastService.show({
            content: '更新中',
            type: 'loading',
          })
          // return
          /**是否图片上传失败 */
          let isImgErr = false
          await this.uploadfun().catch(err => {
            console.log(err, 'uploadfunuploadfun');
            isImgErr = true
            if (isImgErr) {
              this.fileListView = []
              this.isloading = false
              this._toastService.remove(ids)
              this.toastsOpen('封面上传失败，请重新上传','danger')
            }
          })
          if (!isImgErr) this.requestDeleteimg()
          this.DealerServiceplatform.update(this.dealerInfo.id, {
            name: input.name,
            address: input.address,
            contactPerson: input.contactPerson,
            contactNumber: input.contactNumber,
            shortName: input.shortName
          }).subscribe(async (res) => {
            if (!isImgErr) {
              this._toastService.remove(ids)
              this.toastsOpen('车商信息提交成功','success')
              this.ModalClose()
              this.getCarMarketplace()
              this.isloading = false
            }

          })
        }
        if (status == 'reject') return
      });
  }

  toastsOpen(content,type) {
    this._toastService.show({
      content: content,
      type: type,
      delay: 2000
    })
  }
  /**模态框取消 */
  ModalClose() {
    this.isModalVisible = false
    this.closeModalClearData()
  }
  /**关闭模态框需要清除的数据 */
  closeModalClearData() {
    this.fileListView = []
    this.deleteimg = []
  }

  /**上传图片--更改 */
  UploadFlieChange(files) {
    let filesdispose = this.readFile(files.target.files)
    this.fileListView = filesdispose
  }
  /**删除图片*/
  deleteImage(item) {
    if (item.id) {
      this.deleteimg.push(item)
    }
    this.fileListView = []
  }
  /**上传图片方法 */
  uploadfun() {
    return new Promise((resolve, rejects) => {
      this.fileListView.map(async (file) => {
        if (!file.id) {
          let formData = new FormData();
          formData.append('file', file, file.name);
          await this.requestImage(
            {
              containerName: 'DealerCover',
              entityId: this.dealerInfo?.id,
            }, formData
          ).catch((err) => {
            // console.log(err,'失败');
            rejects(false)
          })

        }
        resolve(true)
      })

    })
  }
  /**提交图片到服务器 */
  requestImage(input, formData) {
    return new Promise((resolve, rejects) => {
      const req = new HttpRequest('POST', `${this.environment.getEnvironment().apis.FileExplorer.url}/api/file-explorer/files?containerName=${input.containerName}&entityId=${input.entityId}`, formData, {
      });
      this.http
        .request(req)
        .pipe(filter(e => e instanceof HttpResponse)).subscribe((back) => {
          resolve(back)
        }, (err) => {
          rejects()
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
