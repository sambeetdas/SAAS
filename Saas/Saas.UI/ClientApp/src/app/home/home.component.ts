import { Component, Inject, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Utility } from '../common/utility';
import { SharedService } from '../common/shared.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public http: HttpClient;
  public utility: Utility;
  public router: Router;
  public subscriptions: Subscriptions[];
  public sharedService: SharedService;

  constructor(http: HttpClient, utility: Utility, router: Router, sharedService: SharedService) {
    this.http = http;
    this.utility = utility;
    this.router = router;
    this.sharedService = sharedService;
  }

  ngOnInit() {
    this.GetSubscriptions();
  }

  GetSubscriptions() {

    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    };

    this.http.get<Subscriptions[]>(this.utility.serverUrl + '/api/Subscription/GetAllSubscription', httpHeader).subscribe(result => {
      this.subscriptions = result;
    }, error => console.error(error));
  }

  Subscribe(subscriptionId: string, subcriptionCode: string) {
    this.sharedService.SetData(subcriptionCode, subscriptionId);
    this.router.navigate(['/subscribe']);
  }
}

interface Subscriptions {
  subscriptionId: string;
  subcriptionCode: number;
  title: number;
  description: string;
  type: string;
  amount: number;
  currency: number;
  frequency: string;
  services: string;
  status: number;
  createDate: Date;
  updateDate: Date;
  createUser: number;
  updateUser: string;
}
