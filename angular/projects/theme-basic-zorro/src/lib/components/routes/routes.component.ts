/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { ABP, RoutesService, TreeNode } from '@abp/ng.core';
import {
  Component,
  ElementRef,
  Input,
  QueryList,
  Renderer2,
  TrackByFunction,
  ViewChildren,
} from '@angular/core';

@Component({
  selector: 'dig-routes',
  templateUrl: 'routes.component.html',
  styles: [`
      .wrapper {
        width: 100%;
      }

      button {
        margin-bottom: 12px;
      }
      ::ng-deep.ant-menu-title-content,.submenu-title{
        width:100%;
        display: flex;
        align-items: center;
      }
      ::ng-deep .activestyle{
        // background:#f22;
        background-color: #1890ff !important ;
      }
  `]
})
export class RoutesComponent {
  @Input() smallScreen?: boolean;
  @Input() isCollapsed?: boolean;

  @ViewChildren('childrenContainer') childrenContainers!: QueryList<ElementRef<HTMLDivElement>>;

  rootDropdownExpand = {} as { [key: string]: boolean };

  trackByFn: TrackByFunction<TreeNode<ABP.Route>> = (_, item) => item.name;

  constructor(public readonly routesService: RoutesService, protected renderer: Renderer2) {
    // this.routeList=this.setLevels(routesService.visible$ , 0)

    this.routesService.visible$.subscribe(res => {
      this.routeList = this.setLevels(res, 1)
    })
  }

  isDropdown(node: TreeNode<ABP.Route>) {
    return !node?.isLeaf || this.routesService.hasChildren(node.name);
  }

  closeDropdown() {
    this.childrenContainers.forEach(({ nativeElement }) => {
      this.renderer.addClass(nativeElement, 'd-none');
      setTimeout(() => this.renderer.removeClass(nativeElement, 'd-none'), 0);
    });
  }

  isNzIcon = ((val: string = '') => !(val.includes('fat') || val.includes('fa')))

  routeList: any[] = []
  mode = true;
  dark = true;
  const = 1
  /**设置级别 */
  setLevels(arr: any[], level = 0) {
    for (let i = 0; i < arr.length; i++) {
      arr[i].level = level;
      if (Array.isArray(arr[i].children)) {
        arr[i].children = this.setLevels(arr[i].children, level + 1);
      }
    }
    return arr;
  }



}


