import {eLayoutType, SubscriptionService} from '@abp/ng.core';
import { collapseWithMargin, slideFromBottom } from '@abp/ng.theme.shared';
import {AfterViewInit, Component} from '@angular/core';
import { LayoutService } from '../../services/layout.service';


@Component({
  selector: 'dig-layout-application',
  templateUrl: './application-layout.component.html',
  styleUrls:['./application-layout.component.scss'],
  animations: [slideFromBottom, collapseWithMargin],
  providers: [LayoutService, SubscriptionService],
})
export class ApplicationLayoutComponent implements AfterViewInit {
  // required for dynamic component
  static type = eLayoutType.application;

  constructor(public service: LayoutService) {}

  ngAfterViewInit() {
    this.service.subscribeWindowSize();
    console.log(this.service.smallScreen);
    
  }

  isCollapsed = false;
}
