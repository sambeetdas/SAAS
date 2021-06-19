import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Utility } from '../common/utility';

@Component({
  selector: 'app-home',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  public router: Router;
  public http: HttpClient;
  public utility: Utility;
  public subscribe: SubscribedModel

  constructor(http: HttpClient, utility: Utility, router: Router) {
    this.subscribe = new SubscribedModel();
    this.router = router;
    this.http = http;
    this.utility = utility;
  }

  Login() {

    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    };

    this.http.post(this.utility.serverUrl + '/api/Subscription/ValidateSubscription', this.subscribe, httpHeader).subscribe(result => {
      if (result != null) {
        this.router.navigate(['/api']);
      }      
    }, error => {
    });
  }
}

class SubscribedModel {
  subscribedEmail: string;
  subscribedPassword: string;
}
