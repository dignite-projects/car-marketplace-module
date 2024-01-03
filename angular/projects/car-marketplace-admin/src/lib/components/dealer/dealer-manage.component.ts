import { Component, TemplateRef, ViewChild } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { ToastService } from '@dignite/components';
import { DealerService } from '../../proxy/admin/dealers';
import { authenticationStatusOptions } from '../../proxy/dealers';



// import { DealerService } from '../../proxy/admin/dealers';

@Component({
  selector: 'lib-dealer-manage',
  templateUrl: './dealer-manage.component.html',
  styleUrls: ['./dealer-manage.component.scss']
})
export class DealerManageComponent {
  constructor(
    private DealerServiceAdmin: DealerService,
    private _confirmationService: ConfirmationService,
    private _toastService: ToastService,
  ) { }
  /**查询条件 */
  search: any = {
    filter: '',
    authenticationStatus: ''
  }
  /**车商列表 */
  dealerList: any[] = []

  /**车商状态-name */
  authenticationStatusList: any[any] = authenticationStatusOptions

  @ViewChild('nameCol') nameCol: TemplateRef<any>;
  @ViewChild('statusCol') statusCol: TemplateRef<any>;
  @ViewChild('creationTimeCol') creationTimeCol: TemplateRef<any>;
  @ViewChild('operateCol') operateCol: TemplateRef<any>;
  /**表格数据 */
  rows = [];
  /**表格加载 */
  loadingIndicator = true;
  // sortable: false
  /**列数据 */
  columns = [];
  /**列类型 */
  ColumnMode = ColumnMode;
  /**分页数据 */
  page: any = {
    skipCount: 0,
    maxResultCount: 15,
    total: 0
  }
  /**
 * 是否打开模态框
 */
  isModalVisible?: boolean

  setPage(event) {
    this.page = event
    this.getDealerList();
  }
  /**
 * 筛选方法
 */
  searchSite() {
    this.getDealerList()
  }
  /**获取车商列表 */
  getDealerList() {
    this.DealerServiceAdmin.getList({
      ...this.search,
      sorting: '',
      skipCount: this.page.skipCount * this.page.maxResultCount,
      maxResultCount: this.page.maxResultCount,
    }).subscribe(res => {
      this.dealerList = res.items
      this.loadingIndicator = false;
      this.page.total = res.totalCount;
      this.columns = [
        {
          name: '名称', prop: 'name',
          // cellTemplate: this.nameCol,
          minWidth: 200,
        },
        { name: '联系人', prop: 'contactPerson' },
        { name: '联系方式', prop: 'contactNumber' },
        { name: '地址', prop: 'address' },
        {
          name: '状态', prop: 'authenticationStatus',
          cellTemplate: this.statusCol,
          minWidth: 160,
        },
        {
          name: '创建时间', prop: 'creationTime',
          cellTemplate: this.creationTimeCol,
          minWidth: 160,
        },
        {
          name: '操作', prop: 'operate',
          cellTemplate: this.operateCol,
          minWidth: 160,
        },
      ].map(el => ({
        ...el,
        minWidth: this.getCloumnWidth(el.prop)
      }));
    })
  }

  /**获取列的最小宽度 */
  getCloumnWidth(value) {
    switch (value) {
      case 'name':
        return 240;
        break;
      case 'status':
        return 120;
        break;
      case 'creationTime':
        return 160;
        break;
      case 'operate':
        return 100;
        break;
      default:
        return 60;
        break;
    }
  }


  /**导出车商 */
  exportAsExcelFile() {
    // _toastService
    const id = this._toastService.show({
      content: `资源准备中`,
      type: 'loading',
    });;
    this.DealerServiceAdmin.getListAsExcelFile({
      authenticationStatus: this.search.authenticationStatus
    }).subscribe((ExcelFile) => {
      this._toastService.remove(id);
      this._toastService.show({
        content: `资源已就绪，正在下载中`,
        type: 'success',
        delay: 2500
      })
      const url = window.URL.createObjectURL(ExcelFile);
      // 以动态创建a标签进行下载
      const a = document.createElement('a');
      const fileName = "经销商列表";
      a.href = url;
      a.download = fileName + '.xlsx';//后缀名根据需要任意选择
      a.click();
      // window.URL.revokeObjectURL(url);
    })
  }
  /**认证车商 */
  authenticateCarMarketplace(data, type: string) {
    this._confirmationService
      .warn(`${data.name}`, `确定要${type == 'yes' ? '批准' : '不批准'}这个车商信息吗?`, {})
      .subscribe(async (status: Confirmation.Status) => {
        if (status == 'confirm') {
          this.authenticateByIdAndStatusSubmit(data, type == 'yes' ? 1 : 2)
        }
        if (status == 'reject') return
      });
  }
  /**认证提交 */
  authenticateByIdAndStatusSubmit(data, Status, title = '认证中', seccess = '认证完成') {
    const messageid = this._toastService.show({
      content: title,
      type: 'loading',
    });;
    this.DealerServiceAdmin.authenticateByIdAndStatus(data.id, Status).subscribe(res => {
      this.getDealerList()
      this._toastService.remove(messageid);
      this._toastService.show({
        content: seccess,
        type: 'success',
        delay: 2500
      })
    })
  }

  /**修改的车商状态 */
  StatusValue = ''

  /**正在修改的车商 */
  dealer_Item: any = ''

  /**修改车商状态 */
  changeStatus(data) {
    this.open('编辑')
    this.StatusValue = data.authenticationStatus
    this.dealer_Item = data
  }

  /**删除车商 */
  SiteDelete(data) {
    this._confirmationService
      .warn(`${data.name}`, '确定要删除这个车商吗?', {})
      .subscribe(async (status: Confirmation.Status) => {
        if (status == 'confirm') {
          const messageid = this._toastService.show({
            content: `删除中`,
            type: 'loading',
          });;
          this.DealerServiceAdmin.delete(data.id).subscribe(res => {
            this.ModalClose();
            this.getDealerList()
            this._toastService.remove(messageid);
            this._toastService.show({
              content: `已删除`,
              type: 'success',
              delay: 2500
            })
          })
        }
        if (status == 'reject') return
      });
   
  }

  /**
   * 打开
   * @param title 
   */
  open(title?: string) {
    this.isModalVisible = true
  }

  /**模态框确定 */
  ModalConfirm() {
    let data = this.dealer_Item
    this._confirmationService
      .warn(`${data.name}`, '确定要修改这个车商的状态吗?', {})
      .subscribe(async (status: Confirmation.Status) => {
        if (status == 'confirm') {
          this.authenticateByIdAndStatusSubmit(data, this.StatusValue, '修改中', '修改完成')
          this.ModalClose()
        }
        if (status == 'reject') return
      });


  }
  /**模态框取消 */
  ModalClose() {
    this.isModalVisible = false
  }


}
