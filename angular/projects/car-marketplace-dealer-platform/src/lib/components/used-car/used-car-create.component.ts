import { EnvironmentService } from '@abp/ng.core';
import { HttpClient, HttpEvent, HttpEventType, HttpRequest, HttpResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsedCarConfig } from './used-car-config';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { filter } from 'rxjs';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { ToastService } from '@dignite-ng/components';
import { UsedCarService } from '../../proxy/dealer-platform/used-cars';
import { FileDescriptorService } from '../../proxy/dignite/file-explorer/files';



@Component({
  selector: 'lib-used-car-create',
  templateUrl: './used-car-create.component.html',
  styleUrls: ['./used-car-create.component.scss'],

})
export class UsedCarCreateComponent {
  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private environment: EnvironmentService,
    public _FileDescriptorService: FileDescriptorService,
    private _confirmationService: ConfirmationService,
    private _UsedCarService: UsedCarService,
    public _location: Location,
    private router: Router,
    private _toastService: ToastService,
  ) { }

  /**表单数据 */
  // usedCarForm: FormGroup = this.fb.group({ ...new UsedCarConfig() })
  usedCarForm: FormGroup 


  /**二手车id */
  usedCarId: any = ''

  /**二手车详情 */
  UsedCarDetail: any = ''

  /**图片容器 */
  fileCells: any[any] = []


  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.usedCarForm = this.fb.group({ ...new UsedCarConfig() })
  }

  /**提交 */
  async onsubmit(event) {
    let input = event.formGroupValue
    this.fileCells = event.fileCells
    this.usedCarId = event.usedCarId
    this._confirmationService
      .warn(`${input.name}`, '确定要提交这个二手车吗?', {})
      .subscribe(async (status: Confirmation.Status) => {
        if (status == 'confirm') {
          this._UsedCarService.create({
            ...input
          }).subscribe(async (res) => {
            /**二手车id */
            this.usedCarId = res.id
            /**二手车详情 */
            this.UsedCarDetail = res
            await this.reqfengzhaung().catch(errname => {
              this.router.navigate([`/car-marketplace/used-car/${this.usedCarId}/edit`], { skipLocationChange: true })
            })
          })
        }
        if (status == 'reject') return
      });
  }
  /**上传图片方法 */
  /**上传图片的封装方法 */
  reqfengzhaung() {
    return new Promise<void>((resolve, reject) => {
      let req_fileCells = this.fileCells.filter((el) => el.fileList.length > 0)
      let count = 0
      req_fileCells.map(async (cell, index1) => {
        cell.fileList.map(async (file) => {
          let formData = new FormData();
          formData.append('file', file, file.name);
          // const messageid = this.message.loading(`正在提交“${cell.displayName}”图片`, { nzDuration: 0 }).messageId;
          const messageid = this._toastService.show({
            content: `正在提交“${cell.displayName}”图片`,
            type: 'loading',
          });
          this.requestImage(
            {
              containerName: 'CarPics',
              cellName: cell.name,
              entityId: this.usedCarId,
            }, formData
          ).then(() => {
            count++
            // this.message.remove(messageid);
            this._toastService.remove(messageid)
            if (req_fileCells.length === count) {
              // this.message.info('已完成');
              this._toastService.show({
                content: `已完成`,
                type: 'success',
                delay: 2500
              })
              this._location.back();
              resolve()
            }
          }).catch(() => {
            this._toastService.remove(messageid);
            // this.message.info(`“${cell.displayName}”图片上传失败，请重新上传`);
            this._toastService.show({
              content: `“${cell.displayName}”图片上传失败，请重新上传`,
              type: 'danger',
              delay: 2500
            })
            reject(cell.name)
          })
        })
      })
    })
  }
  /**提交图片到服务器 */
  requestImage(input, formData) {
    return new Promise((resolve, rejects) => {
      const req = new HttpRequest('POST', `${this.environment.getEnvironment().apis.FileExplorer.url}/api/file-explorer/files?containerName=${input.containerName}&cellName=${input.cellName}&entityId=${input.entityId}`, formData, {
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









}
