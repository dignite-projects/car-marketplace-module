import { Pipe, PipeTransform } from '@angular/core';
import { usedCarStatusName } from '../enums';
import { usedCarStatusOptions } from '../proxy/used-cars/used-car-status.enum';

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
