import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  url = 'https://secure.snd.payu.com/api/v2_1/orders'
  constructor(private http: HttpClient) { }

  orderByPayU(){
    let model = {
      "notifyUrl": "https://your.eshop.com/notify",
    "customerIp": "127.0.0.1",
    "merchantPosId": "300746",
    "description": "RTV market",
    "currencyCode": "PLN",
    "totalAmount": "21000",
    "buyer": {
        "email": "john.doe@example.com",
        "phone": "654111654",
        "firstName": "John",
        "lastName": "Doe",
        "language": "pl"
    },
    "settings":{
        "invoiceDisabled":"true"
    },
    "products": [
        {
            "name": "Wireless Mouse for Laptop",
            "unitPrice": "15000",
            "quantity": "1"
        },
        {
            "name": "HDMI cable",
            "unitPrice": "6000",
            "quantity": "1"
        }
    ]
    }
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer d9a4536e-62ba-4f60-8017-6053211d3f47' });
    let options = { headers: headers };

    this.http.post(this.url, model, options)
  }

}
