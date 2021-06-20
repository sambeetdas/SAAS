import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Utility } from '../common/utility';
import { SharedService } from '../common/shared.service';

@Component({
  selector: 'app-home',
  templateUrl: './subscription.component.html',
})

export class SubscriptionComponent {
  public router: Router;
  public http: HttpClient;
  public utility: Utility;
  public subscribe: SubscribedModel;
  public sharedService: SharedService;
  public selectedSubcriptionCode: string;
  public selectedSubcriptionId: string;

  constructor(http: HttpClient, utility: Utility, router: Router, sharedService: SharedService) {
    this.router = router;
    this.http = http;
    this.utility = utility;
    this.subscribe = new SubscribedModel();
    this.sharedService = sharedService;
  }

  ngOnInit() {
    this.selectedSubcriptionCode = this.sharedService.GetData().subscriptionCode;
    this.selectedSubcriptionId = this.sharedService.GetData().subscriptionId;
    console.log(this.selectedSubcriptionCode);
  }

  SubscribeUser() {
    if (this.subscribe.subscribedPassword == this.subscribe.subscribedConfirmPassword) {
      const httpHeader = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'Access-Control-Allow-Origin': '*'
        })
      };
      this.subscribe.subcriptionCode = this.selectedSubcriptionCode;
      this.subscribe.subscriptionId = this.selectedSubcriptionId;
      this.http.post(this.utility.serverUrl + '/api/Subscription/AddSubscription', this.subscribe, httpHeader).subscribe(result => {
        if (result != null) {
          this.router.navigate(['/api']);
        }
      }, error => {
      });
    }
  }
}

class SubscribedModel {
  subscriptionId: string;
  subcriptionCode: string;
  subscribedEmail: string;
  subscribedPhone: string;
  subscribedPassword: string;
  subscribedConfirmPassword: string;
  firstName: string;
  lastName: string;
  status: string = 'A';
}
