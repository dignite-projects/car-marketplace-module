import { Pipe, PipeTransform } from '@angular/core';
import {usedCarStatusOptions} from '../../../proxy/src/proxy/used-cars/used-car-status.enum'
import { usedCarStatusName } from '../enums';

@Pipe({
  name: 'getUsedCarStatusToName'
})
export class GetUsedCarStatusToNamePipe implements PipeTransform {

  transform(Status: unknown, ...args: unknown[]): unknown {
    let StatusOptions = JSON.parse(JSON.stringify(usedCarStatusOptions))
    let findObj=StatusOptions.find(el=>el.value===Status)
    return findObj?usedCarStatusName[findObj.key]:'--'
  }
}
