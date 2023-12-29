import { Pipe, PipeTransform } from '@angular/core';
import { authenticationStatusOptions } from '../../../proxy/src/proxy/dealers';
import { AuthenticationStatusName } from '../enums';


@Pipe({
  name: 'getDealerStatusName'
})
export class GetDealerStatusNamePipe implements PipeTransform {

  transform(Status: unknown, ...args: unknown[]): unknown {
    let StatusOptions = JSON.parse(JSON.stringify(authenticationStatusOptions))
    let findObj=StatusOptions.find(el=>el.value===Status)
    return findObj?AuthenticationStatusName[findObj.key]:'--'
  }

}
