import { NavItem, NavItemsService } from '@abp/ng.theme.shared';
import { Component, Input, TrackByFunction } from '@angular/core';

@Component({
  selector: 'dig-nav-items',
  templateUrl: 'nav-items.component.html',
  styles: [`
    .navbar_ul{
      display: flex;
      align-items: center;
      margin:0;
    }
    .navbar_li+.navbar_li{
      margin-left: 16px;
    }
  `]
})
export class NavItemsComponent {
  trackByFn: TrackByFunction<NavItem> = (_, element) => element.id;

  constructor(public readonly navItems: NavItemsService) { }
}
