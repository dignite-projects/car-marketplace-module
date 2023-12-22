/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { ManageConfig } from './manage';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { filter } from 'rxjs';
import { DealerService } from '../../proxy/dealer-platform/dealers';
import { FileDescriptorService } from '../../proxy/dignite/file-explorer/files';
import { EnvironmentService } from '@abp/ng.core';
import { AdministratorService } from '../../services/administrator.service';

@Component({
  selector: 'lib-car-marketplace',
  templateUrl: './car-marketplace.component.html',
  styleUrls: ['./car-marketplace.component.scss', '../../style/index.scss']
})
export class CarMarketplaceComponent {
  constructor(
    private DealerServiceplatform: DealerService,
    private _AdministratorService: AdministratorService,
    private modal: NzModalService,
    private message: NzMessageService,
    private sanitizer: DomSanitizer,
    private http: HttpClient,
    public _FileDescriptorService: FileDescriptorService,
    private environment: EnvironmentService,
  ) { }

  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.authenticationStatusList = await this._AdministratorService.getauthenticationStatusOptions()
    this.getCarMarketplace()
  }
  /**车商状态-name */
  authenticationStatusList: any[any] = []
  /**车商信息 */
  carMarketplace: any = ''
  /** 编辑弹窗是否打开 */
  isNewGroup = false;
  /**编辑弹窗标题 */
  modalTitle: string = ''

  /**是否正在编辑某个字段集合*/
  isEdit: boolean = false;
  manageConfig: ManageConfig = new ManageConfig()

  /**获取车商信息 */
  getCarMarketplace() {

    this.DealerServiceplatform.findByCurrentUser().subscribe(async (res) => {
      // console.log('获取车商信息', res, this.fileListView)
      this.carMarketplace = res
      this.fileListView_show = []
      /**问题 */
      setTimeout(async () => {
        this.fileListView_show = await this.getImage(res?.id)
      }, 200)
    })
  }

  /**开启-新建字段集合模态框 */
  showModal(title?: string): void {
    this.isNewGroup = true;
    this.modalTitle = title
    this.fileListView = this.fileListView_show
    this.manageConfig = new ManageConfig({
      ...this.carMarketplace
    })
  }
  /**上传图片方法 */
  uploadfun() {
    return new Promise((resolve, rejects) => {
      this.fileList.map(async (file) => {
        let formData = new FormData();
        formData.append('file', file, file.name);
        await this.requestImage(
          {
            containerName: 'DealerCover',
            entityId: this.carMarketplace.id,
          }, formData
        )
        resolve(true)
      })
    })
  }
  /**点击确定回调-新建站点 */
  handleOk(): void {
    // console.log('Button ok clicked!', this.manageConfig, this.fileList);

    let data = this.manageConfig
    this.modal.confirm({
      nzTitle: '确定要更新这个车商信息吗',
      nzContent: `<b style="color: red;">${data.name}</b>`,
      nzOkText: '确认',
      nzOkType: 'primary',
      nzOnOk: () => {
        const messageid = this.message.loading('提交中', { nzDuration: 0 }).messageId;

        this.DealerServiceplatform.update(this.carMarketplace.id, {
          name: data.name,
          address: data.address,
          contactPerson: data.contactPerson,
          contactNumber: data.contactNumber,
          shortName: data.shortName
        }).subscribe(async (res) => {
          await this.uploadfun()
          if (this.deleteimg.length > 0) {
            await this.requestDeleteimg()
          }

          setTimeout(() => {
            this.closeModal();
            this.getCarMarketplace()
            this.message.remove(messageid);
            this.message.info('已完成');
          }, 1200)
        })

      },
      nzCancelText: '取消',
      nzOnCancel: () => {
        this.closeModal()
      }
    });
  }
  /**点击遮罩层或右上角叉或取消按钮的回调-新建字段集合模态框 */
  handleCancel(): void {
    // console.log('Button cancel clicked!');
    this.closeModal();
  }
  /**关闭模态框 */
  closeModal() {
    this.isNewGroup = false;
    this.isEdit = false;
    this.manageConfig = new ManageConfig()
    this.fileListView = []
  }



  /**上传图片的容器 */
  fileList: any[] = []
  /**展示的图片 */
  fileListView: any[] = []
  /** */
  fileListView_show: any[] = []
  /**上传图片的类型 */
  allowedFileTypeNames: any = ''
  /**最大图片大小 */
  // maxBlobSize: any = 0
  /**需要删除的图片 */
  deleteimg: any[] = []
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

  /**提交图片到服务器 */
  requestImage(input, formData) {
    return new Promise((resolve, reject) => {
      const req = new HttpRequest('POST', `${this.environment.getEnvironment().apis.FileExplorer.url}/api/file-explorer/files?containerName=${input.containerName}&entityId=${input.entityId}`, formData, {
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
  UploadFlieChange(files) {
    let filesdispose = this.readFile(files.target.files)
    this.fileList = filesdispose
    // console.log('上传图片改变', files, filesdispose);
  }
  previewImage: string | undefined = '';
  previewVisible = false;
  handlePreview(elf) {
    this.previewImage = elf.src || elf.url
    this.previewVisible = true
  }

  /**删除图片*/
  deleteImage(item, finame) {
    if (this.fileList.length > 0) {
      this.fileList = []
    }
    if (this.fileListView.length > 0) {
      this.fileListView = []
      this.deleteimg.push(item)
    }
    // console.log(item, finame, '删除图片', this.deleteimg);

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
