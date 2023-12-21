/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { AdministratorService } from '../../services/administrator.service';
import { DealerService } from '../../proxy/admin/dealers';



@Component({
  selector: 'lib-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.scss', '../../style/index.scss']
})
export class ManageComponent implements OnInit {
  constructor(
    private _AdministratorService: AdministratorService,
    private DealerServiceAdmin: DealerService,
    private router: Router,
    private modal: NzModalService,
    private message: NzMessageService,
  ) { }
  async ngOnInit(): Promise<void> {
    this.authenticationStatusList = await this._AdministratorService.getauthenticationStatusOptions()

    this.getCarMarletplaceList()
  }
  /**车商列表 */
  CarMarketplaceList: any[] = []
  /**车商状态-name */
  authenticationStatusList: any[any] = []
  /**车商列表-分页 */
  SkipCount: number = 0
  /**车商列表-每页最大个数 */
  MaxResultCount: number = 15
  /**车商列表--总数据 */
  pageTotal: number = 0
  /**查询条件 */
  search: any = {
    filter: '',
    authenticationStatus: ''
  }
  /** 编辑弹窗是否打开 */
  isNewGroup = false;
  /**编辑弹窗标题 */
  modalTitle: string = ''

  /**是否正在编辑某个字段集合*/
  isEdit: boolean = false;
  /**导出车商 */
  exportAsExcelFile() {
    this.DealerServiceAdmin.getListAsExcelFile({
      authenticationStatus: this.search.authenticationStatus
    }).subscribe((ExcelFile) => {
      console.log(ExcelFile, '导出车商文件');
      const url = window.URL.createObjectURL(ExcelFile);
      // 以动态创建a标签进行下载
      const a = document.createElement('a');
      const fileName = "经销商列表";
      a.href = url;
      a.download = fileName + '.xlsx';//后缀名根据需要任意选择
      a.click();
      window.URL.revokeObjectURL(url);
    })
  }

  /**获取车商列表 */
  getCarMarletplaceList() {
    this.DealerServiceAdmin.getList({
      ...this.search,
      sorting: '',
      skipCount: this.SkipCount * this.MaxResultCount,
      maxResultCount: this.MaxResultCount
    }).subscribe(res => {
      // console.log('获取车商列表', res);
      this.CarMarketplaceList = res.items
      this.pageTotal = res.totalCount
    })
  }

  /**
   * 筛选方法
   */
  searchSite() {
    this.getCarMarletplaceList()
  }
  /**认证车商 */
  authenticateCarMarketplace(data, type: string) {
    if (type == 'yes') {
      this.modal.confirm({
        nzTitle: '确定要批准这个车商',
        nzContent: `<b style="color: red;">${data.name}</b>`,
        nzOkText: '批准',
        nzOkType: 'primary',
        nzOnOk: () => {
          this.authenticateByIdAndStatusSubmit(data, 1)
        },
        nzCancelText: '取消',
        nzOnCancel: (cal) => {
        }
      });
    } else if (type == 'no') {
      this.modal.confirm({
        nzTitle: '确定要不批准这个车商',
        nzContent: `<b style="color: red;">${data.name}</b>`,
        nzOkText: '不批准',
        nzOkType: 'primary',
        nzOnOk: () => {
          // console.log('认证车商-不批准');
          this.authenticateByIdAndStatusSubmit(data, 2)
        },
        nzCancelText: '取消',
        nzOnCancel: (cal) => {
        }
      });
    }
  }
  /**认证提交 */
  authenticateByIdAndStatusSubmit(data, Status, title = '认证中', seccess = '认证完成') {
    const messageid = this.message.loading(title, { nzDuration: 0 }).messageId;
    this.DealerServiceAdmin.authenticateByIdAndStatus(data.id, Status).subscribe(res => {
      setTimeout(() => {
        this.closeModal();
        this.getCarMarletplaceList()
        this.message.remove(messageid);
        this.message.info(seccess);
      }, 1200)
    })
  }
  /**编辑车商 */
  editStieShowModal(data: any) {
    this.showModal('编辑')

  }
  /**修改的车商状态 */
  StatusValue = null
  /**正在修改的车商 */
  CarMarketplace_Item: any = ''
  /**修改车商状态 */
  changeStatus(data) {
    this.showModal('编辑')
    this.StatusValue = data.authenticationStatus
    this.CarMarketplace_Item = data
  }
  /**删除车商 */
  SiteDelete(data) {
    this.modal.confirm({
      nzTitle: '确定要删除这个车商吗',
      nzContent: `<b style="color: red;">${data.name}</b>`,
      nzOkText: '确认',
      nzOkType: 'primary',
      nzOnOk: () => {
        const messageid = this.message.loading('删除中', { nzDuration: 0 }).messageId;
        this.DealerServiceAdmin.delete(data.id).subscribe(res => {
          setTimeout(() => {
            this.closeModal();
            this.getCarMarletplaceList()
            this.message.remove(messageid);
            this.message.info('已删除');
          }, 1200)
        })
      },
      nzCancelText: '取消',
      nzOnCancel: () => {
        this.closeModal()
      }
    });
  }
  /**翻页 */
  nzPageIndexChange(event) {
    this.SkipCount = event - 1
    this.getCarMarletplaceList()
  }

  /**开启-新建字段集合模态框 */
  showModal(title?: string): void {
    this.isNewGroup = true;
    this.modalTitle = title
  }
  /**点击确定回调-新建站点 */
  handleOk(): void {
    let data = this.CarMarketplace_Item
    this.modal.confirm({
      nzTitle: '确定要修改这个车商的状态吗',
      nzContent: `<b style="color: red;">${data.name}</b>`,
      nzOkText: '确认',
      nzOkType: 'primary',
      nzOnOk: () => {
        // console.log('点击确定回调')
        this.authenticateByIdAndStatusSubmit(data, this.StatusValue, '修改中', '修改完成')
      },
      nzCancelText: '取消',
      nzOnCancel: () => {
        this.closeModal()
      }
    });
  }
  /**点击遮罩层或右上角叉或取消按钮的回调-新建字段集合模态框 */
  handleCancel(): void {
    this.closeModal();
  }
  /**关闭模态框 */
  closeModal() {
    this.isNewGroup = false;
    this.isEdit = false;
    this.CarMarketplace_Item = ''
  }


}
