import { AuthWrapperService } from '@abp/ng.account.core';
import { Component } from '@angular/core';

@Component({
  selector: 'dig-auth-wrapper',
  templateUrl: './auth-wrapper.component.html',
  providers: [AuthWrapperService],
})
export class AuthWrapperComponent {
  constructor(public service: AuthWrapperService) {}
}
