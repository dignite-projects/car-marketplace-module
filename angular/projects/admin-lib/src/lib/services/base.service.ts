import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  constructor() { }

  
  /**获取缓存 */
  getItem(key: string) {
    return JSON.parse(localStorage.getItem(key)) || [] || ''
  }
  /**设置缓存 */
  setItem(key: string, value: any) {
    localStorage.setItem(key, JSON.stringify(value));
  }

  /**@param {深拷贝--方法} dest   */
	deepClone(dest:any) {
		if (typeof dest === 'object') {
			if (!dest) return dest; // null
			var obj = dest.constructor(); // Object/Array
			for (var key in dest) {
				obj[key] = this.deepClone(dest[key])
			}
			return obj;
		} else {
			return dest;
		}
	}
}
