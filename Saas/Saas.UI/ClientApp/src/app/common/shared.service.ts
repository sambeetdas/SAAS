import { Injectable } from '@angular/core';


@Injectable({
  providedIn:'root'
})

export class SharedService {
  subscription: Subscription;
  constructor() {
    this.subscription = new Subscription();
  }

  SetData(subscriptionCode, subscriptionId) {
    this.subscription.subscriptionCode = subscriptionCode;
    this.subscription.subscriptionId = subscriptionId;
  }

  GetData() {
    return this.subscription;
  }
 
}

class Subscription {
  subscriptionCode: string;
  subscriptionId: string;
}
