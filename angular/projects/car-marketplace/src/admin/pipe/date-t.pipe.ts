import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateT'
})
export class DateTPipe implements PipeTransform {

 
  transform(date: Date,type:string, ...args: unknown[]): unknown {
    
    if (!date) {
			return ''
		}
		date = new Date(date)
		
		let year = date.getFullYear()
		let month = date.getMonth() + 1
		let day = date.getDate()
		let hour = date.getHours()
		let minute = date.getMinutes()
		let second = date.getSeconds()
		month = this.formatNumber(month)
		day = this.formatNumber(day)
		hour = this.formatNumber(hour)
		minute = this.formatNumber(minute)
		second = this.formatNumber(second)
		if (type == 'yy/mm/dd hh:mm:ss') {
			return `${year}/${month}/${day} ${hour}:${minute}:${second}`
		}
		if (type == 'yy-mm-dd hh:mm:ss') {
			return `${year}-${month}-${day} ${hour}:${minute}:${second}`
		}
		if (type == 'yy-mm-dd hh:mm') {
			return `${year}-${month}-${day} ${hour}:${minute}`
		}
		if (type == 'yy/mm/dd hh:mm') {
			return `${year}/${month}/${day} ${hour}:${minute}`
		}
		if (type == 'yy/mm/dd') {
			return `${year}/${month}/${day}`
		}
		if (type == 'hh:mm') {
			return ` ${hour}:${minute}`
		}

		if (type == 'yy-mm-dd') {
			return `${year}-${month}-${day}`
		}
		if (type == 'yy年mm月dd日') {
			return `${year}年${month}月${day}日`
		}
		if (type == 'dd-mm') {
			return `${year}-${month}`
		}
		if (type == 'dd') {
			return `${year}`
		}
		if (type == 'yy') {
			return `${year}`
		}
		if (type == 'hh') {
			return ` ${hour}`
		}
	
  }
  formatNumber(n) {
		n = n.toString()
		return n[1] ? n : '0' + n
	}

}
