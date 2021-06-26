import { Component, Inject, Output } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Utility } from '../common/utility';
import { Subscriptions } from '../model/subscriptions.model';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public http: HttpClient;
  public utility: Utility;
  public router: Router;
  public subscriptions: Subscriptions[];

  constructor(http: HttpClient, utility: Utility, router: Router) {
    this.http = http;
    this.utility = utility;
    this.router = router;
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

  Subscribe(subcription: Subscriptions) {
    this.router.navigate(['/subscribe', subcription.subcriptionCode.toLowerCase()]);
  }
}
