import { Validators } from "@angular/forms";
/**
 * 车商信息编辑表单
 */
export class DealerEditConfig {

    // 名称
    name: string | Validators[] = ['', Validators.required];
    // 简称
    shortName: string | Validators[] = ['', Validators.required];
    // 联系人
    contactPerson: string | Validators[] = ['', Validators.required];
    // 联系方式
    contactNumber: number | Validators[] = ['', Validators.required];
    // 地址
    address: string | Validators[] = ['', Validators.required];
    latitude: number | Validators[] = [''];
    longitude: number | Validators[] = [''];

    constructor(data?: DealerEditConfig) {
        if (data) {
            for (const key in data) {
                if (data.hasOwnProperty(key)&&this.hasOwnProperty(key)) {
                    this[key] = data[key];
                }
            }
        }
    }
}