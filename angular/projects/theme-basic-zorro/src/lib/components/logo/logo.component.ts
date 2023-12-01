import { ApplicationInfo, EnvironmentService } from '@abp/ng.core';
import { Component } from '@angular/core';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'dig-logo',
  template: `
    <a class="navbar-brand" routerLink="/">
      <img
        *ngIf="appInfo.logoUrl"
        [src]="appInfo.logoUrl"
        [alt]="appInfo.name"
        width="auto"
        height="32px"
      />
      <div class="spanlog"> {{ appInfo.name }}</div>
    </a>

    <ng-template #appName>
     <div class="spanlog"> {{ appInfo.name }}</div>
    </ng-template>
  `,
  styles: [`
  .navbar-brand{
    color:#fff;
    width:100%;
    display:flex;
    align-items:center;
    img+div{
      margin-left: 10px;
    }
  }
  .spanlog{
      width:100%;
      overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
    }


  `]
})
export class LogoComponent {
  get appInfo(): ApplicationInfo {
    return this.environment.getEnvironment().application;
  }

  constructor(private environment: EnvironmentService) { }
}
