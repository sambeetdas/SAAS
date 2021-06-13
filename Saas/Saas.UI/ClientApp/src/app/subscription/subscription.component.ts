import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Utility } from '../common/utility';

@Component({
  selector: 'app-home',
  templateUrl: './subscription.component.html',
})

export class SubscriptionComponent {
  public router: Router;
  public http: HttpClient;
  public utility: Utility;

  constructor(http: HttpClient, utility: Utility, router: Router) {
    this.router = router;
    this.http = http;
    this.utility = utility;
  }

  SubscribeUser() {
    this.router.navigate(['/api']);
  }
}
