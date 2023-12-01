/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { DealerService } from 'projects/car-marketplace/proxy/dealer-platform/dealers';
import { AdministratorService } from 'projects/car-marketplace/src/services/administrator.service';
import { ManageConfig } from './manage';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';

@Component({
  selector: 'lib-car-marketplace',
  templateUrl: './car-marketplace.component.html',
  styleUrls: ['./car-marketplace.component.scss', '../../../style/index.scss']
})
export class CarMarketplaceComponent {
  constructor(
    private DealerServiceplatform: DealerService,
    private AdministratorService: AdministratorService,
    private router: Router,
    private modal: NzModalService,
    private message: NzMessageService
  ) { }

  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.authenticationStatusList = await this.AdministratorService.getauthenticationStatusOptions()
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
    this.DealerServiceplatform.findByCurrentUser().subscribe(res => {
      console.log('获取车商信息', res)
      this.carMarketplace = res
    })
  }

  /**开启-新建字段集合模态框 */
  showModal(title?: string): void {
    this.isNewGroup = true;
    this.modalTitle = title
    this.manageConfig = new ManageConfig({
      ...this.carMarketplace
    })
  }
  /**点击确定回调-新建站点 */
  handleOk(): void {
    console.log('Button ok clicked!', this.manageConfig);
    let data = this.manageConfig
    this.modal.confirm({
      nzTitle: '确定要更新这个车商信息吗',
      nzContent: `<b style="color: red;">${data.name}</b>`,
      nzOkText: '确认',
      nzOkType: 'primary',
      // nzOkDanger: true,
      nzOnOk: () => {
        const messageid = this.message.loading('提交中', { nzDuration: 0 }).messageId;
          this.DealerServiceplatform.update(this.carMarketplace.id, {
            name: data.name,
            address: data.address,
            contactPerson: data.contactPerson,
            contactNumber: data.contactNumber
          }).subscribe(res=>{
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
    console.log('Button cancel clicked!');
    // this.isNewGroup = false;
    this.closeModal();
  }
  /**关闭模态框 */
  closeModal() {
    this.isNewGroup = false;
    this.isEdit = false;
    this.manageConfig = new ManageConfig()
  }




}
