export class CarConfig {
    /**车款id */
    "trimId": string
    /**二手车名称 */
    "name": string
    /**车辆描述情况 */
    "description": string
    /**二手车状态  */
    "status": number =1
    /**初次上牌日期 */
    "registrationDate": string
    /**总里程(公里) */
    "totalMileage": number
    /**过户次数 */
    "transfersCount": number=1
    /**交强险过期日期 */
    "compulsoryInsuranceExpirationDate": string 
    /**商业险过期日期 */
    "commercialInsuranceExpirationDate": string
    /**车辆颜色 */
    "color": string
    /**价格 */
    "price": number
    /**标签 */
    "tags":string[]=[]

    constructor(data?: CarConfig) {

        if (data) {
            for (const key in data) {
                if (data.hasOwnProperty(key)) {
                    this[key] = data[key];
                }
            }
        }
    }

}