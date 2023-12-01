export class CarConfig {
    /**车款id */
    "trimId": string
    /**二手车名称 */
    "name": string
    /**车辆描述情况 */
    "description": string
    /**二手车状态  */
    "status": number 
    /**初次上牌日期 */
    "registrationDate": string
    /**总公里(万) */
    "totalMileage": number
    /**过户次数 */
    "transfersCount": number
    /**交强险过期日期 */
    "compulsoryInsuranceExpirationDate": string 
    /**商业险过期日期 */
    "commercialInsuranceExpirationDate": string
    /**车辆颜色 */
    "color": string
    /**价格 */
    "price": number

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