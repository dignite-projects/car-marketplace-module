import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import {
    NgbToastModule,
    NgbDropdownModule,
    NgbDatepickerModule,
    NgbDateAdapter,
    NgbDateNativeUTCAdapter,
    NgbDateNativeAdapter,
    NgbDateParserFormatter,
    NgbInputDatepicker,
    NgbDateStruct
} from '@ng-bootstrap/ng-bootstrap';
/**
 * 车商信息编辑表单
 */
export class UsedCarConfig {
    // name: string | Validators[] = ['', Validators.required];
    /**车款id */
    "trimId": string | Validators[] = ['', Validators.required]

    /**二手车名称 */
    "name": string | Validators[] = ['', Validators.required]

    /**标签 */
    "tags": string[] | Validators[] = [[], Validators.required]

    /**二手车状态  */
    "status": number | Validators[] = [1, Validators.required]

    /**车辆颜色 */
    "color": string | Validators[] = ['', Validators.required]

    /**价格 */
    "price": number | Validators[] = ['', Validators.required]

    /**总里程(公里) */
    "totalMileage": number | Validators[] = ['', Validators.required]

    /**过户次数 */
    "transfersCount": number | Validators[] = [1, Validators.required]

    /**初次上牌日期new Date('2023-12-22T01:24:44.992') */
    "registrationDate": NgbDateStruct | Validators[] = ['', Validators.required]

    /**交强险过期日期 */
    "compulsoryInsuranceExpirationDate": NgbDateStruct | Validators[] = ['']

    /**商业险过期日期 */
    "commercialInsuranceExpirationDate": NgbDateStruct | Validators[] = ['']

    /**车辆描述情况 */
    "description": string | Validators[] = ['']


    constructor(data?: UsedCarConfig) {
        if (data) {
            for (const key in data) {
                if (data.hasOwnProperty(key) && this.hasOwnProperty(key)) {
                    this[key] = data[key];
                }
            }
        }
    }
}