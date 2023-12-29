import { Component, TemplateRef, ViewChild } from '@angular/core';
import { DealerDto, DealerService } from '../../../../proxy/src/proxy/dealer-platform/dealers';
import { FileDescriptorService } from '../../../../proxy/src/proxy/dignite/file-explorer/files';
import { FormBuilder, FormGroup } from '@angular/forms';
import { DealerEditConfig } from './dealer-edit-config';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { filter } from 'rxjs';
import { EnvironmentService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { ToastService } from '@dignite/components';


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
  ) { }

  @ViewChild('successTpl') successTpl?: TemplateRef<any>;
  @ViewChild('errTpl') errTpl?: TemplateRef<any>;
  /**
   * 车商信息
   */
  dealerInfo: DealerDto | any;
  /**1
   * 封面图片列表
   */
  fileListView_show: any[] = []
  /**
   * 是否打开模态框
   */
  isModalVisible?: boolean
  /**是否正在加载中 */
  isloading: boolean = false

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getCarMarketplace()

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
  /**提示 */
  showSuccess(template: TemplateRef<any>) {
    this._toastService.show({ template, classname: 'bg-success text-light', delay: 5000 });
  }
  showDanger(template: TemplateRef<any>) {
    this._toastService.show({ template, classname: 'bg-danger text-light', delay: 3000 });
  }
  /**模态框确定 */
  ModalConfirm() {
    let input = this.dealerForm.value
    this._confirmationService
      .warn(`${input.name}`, '确定要更新这个车商信息吗?', {})
      .subscribe(async (status: Confirmation.Status) => {
        if (status == 'confirm') {
          this.isloading = true

          await this.uploadfun().catch(err => {
          
            this.fileListView = []
            this.isloading = false
            this.showDanger(this.errTpl)
            return
          })
          this.requestDeleteimg()
          this.DealerServiceplatform.update(this.dealerInfo.id, {
            name: input.name,
            address: input.address,
            contactPerson: input.contactPerson,
            contactNumber: input.contactNumber,
            shortName: input.shortName
          }).subscribe(async (res) => {
            this.ModalClose()
            this.showSuccess(this.successTpl)
            this.getCarMarketplace()
            this.isloading = false
          })

        }
        if (status == 'reject') return
      });
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

  /**表单数据 */
  dealerForm: FormGroup = this.fb.group({ ...new DealerEditConfig() })
  /**
   * 编辑封面图片列表
   */
  fileListView: any[] = []
  /**需要删除的图片 */
  deleteimg: any[] = []
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
