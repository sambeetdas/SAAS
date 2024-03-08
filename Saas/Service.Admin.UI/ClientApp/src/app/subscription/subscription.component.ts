import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Utility } from '../common/utility';
import { SubscribedModel } from '../model/subscribed.model';

@Component({
  selector: 'app-home',
  templateUrl: './subscription.component.html',
})

export class SubscriptionComponent {
  public router: Router;
  public http: HttpClient;
  public utility: Utility;
  public subscribe: SubscribedModel;
  public activatedRoute: ActivatedRoute;
  public selectedSubcriptionCode: string;

  constructor(http: HttpClient, utility: Utility, router: Router, activatedRoute: ActivatedRoute) {
    this.router = router;
    this.http = http;
    this.utility = utility;
    this.subscribe = new SubscribedModel();
    this.activatedRoute = activatedRoute;
  }

  ngOnInit() {
    this.selectedSubcriptionCode = this.activatedRoute.snapshot.params['subscriptionCode'].toUpperCase();
    console.log(this.activatedRoute.snapshot.data['subcriptiondata']);
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
      this.http.post(this.utility.serverUrl + '/api/Subscription/AddSubscription', this.subscribe, httpHeader).subscribe(result => {
        if (result != null) {
          this.router.navigate(['/login']);
        }
      }, error => {
      });
    }
  }
}

