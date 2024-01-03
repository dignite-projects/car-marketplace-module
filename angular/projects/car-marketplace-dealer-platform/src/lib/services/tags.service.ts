import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class TagsService {


  constructor(
    private __BaseService: BaseService
  ) { }
  /**预设标签 */
  TagsList: any[any] = ['准新车', '急售车型', '奥迪认证']
  /**获取标签 */
  getTagList() {
    let storageTags = this.__BaseService.getItem('storageTags') || []
    return [...this.TagsList, ...storageTags]
  }

  /**添加标签到缓存 */
  pushstorageTags(val: any) {
    let storageTagslist = this.__BaseService.getItem('storageTags')
    if (val) {
      storageTagslist.unshift(val)
      this.__BaseService.setItem('storageTags', storageTagslist)
    }
  }
  /**删除缓存标签 */
  deleteTag(val:any) {
    return new Promise((resolve, rejects) => {
      let storageTagslist = this.__BaseService.getItem('storageTags')
      storageTagslist.splice(storageTagslist.indexOf(val), 1)
      this.__BaseService.setItem('storageTags', storageTagslist)
      resolve(true)
    })
  }
}
