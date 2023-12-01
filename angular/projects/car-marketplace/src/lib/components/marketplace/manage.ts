export class ManageConfig {
    name:string
    contactPerson:string
    contactNumber:string
    address:string
    latitude:any
    longitude:any

    constructor(data?: ManageConfig) {
        
        if (data) {
            for (const key in data) {
                if (data.hasOwnProperty(key)) {
                    this[key] = data[key];
                }
            }
        }
    }

}