import { Pipe, PipeTransform } from '@angular/core';
import { AuthenticationStatusName } from '../enums';
import { authenticationStatusOptions } from '../proxy/dealers';


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
