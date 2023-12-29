


import { Component } from '@angular/core';
import { ToastService } from '../../services';

@Component({
  selector: 'dignite-toasts',
  // standalone: true,
  // templateUrl:'./toasts.component.html',
  template:`
 <ng-container *ngFor="let toast of _toastService.toasts">
  <ngb-toast
      [class]="toast.classname"
      [autohide]="true"
      [delay]="toast.delay || 5000"
      (hidden)="_toastService.remove(toast)"
    >
      <ng-template [ngTemplateOutlet]="toast.template"></ng-template>
    </ngb-toast>
</ng-container>
  `,
  host: { class: 'toast-container position-fixed top-0 start-50 p-3 translate-middle-x', style: 'z-index: 1200' },
})
export class ToastsComponent {
  constructor(public _toastService: ToastService) { 
  }
}
