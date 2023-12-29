import { Pipe, PipeTransform } from '@angular/core';
import { AuthenticationStatusToName } from '../enums';
import { authenticationStatusOptions } from '../../../proxy/src/proxy/dealers/authentication-status.enum';

/**获取当前车商状态 */
@Pipe({
  name: 'getDealerStatusToName'
})
export class GetDealerStatusToNamePipe implements PipeTransform {

  transform(Status: unknown, ...args: unknown[]): unknown {
    let StatusOptions = JSON.parse(JSON.stringify(authenticationStatusOptions))
    let findObj=StatusOptions.find(el=>el.value===Status)
    return findObj?AuthenticationStatusToName[findObj.key]:'--'
  }

}
