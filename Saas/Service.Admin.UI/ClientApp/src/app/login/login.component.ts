import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Utility } from '../common/utility';
import { LoginModel } from '../model/login.model';
import { SubscribedModel } from '../model/subscribed.model';
import { AuthGuard } from '../common/authguard';

@Component({
  selector: 'app-home',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  public router: Router;
  public http: HttpClient;
  public utility: Utility;
  public login: LoginModel;
  public authGuard: AuthGuard;
 

  constructor(http: HttpClient, utility: Utility, router: Router, authGuard: AuthGuard) {
    this.login = new LoginModel();
    this.router = router;
    this.http = http;
    this.utility = utility;
    this.authGuard = authGuard;
  }

  ngOnInit() {
    this.authGuard.DisposeAuthModel();
  }

  Login() {

    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    };

    this.http.post<SubscribedModel>(this.utility.serverUrl + '/api/Subscription/ValidateSubscription', this.login, httpHeader).subscribe(result => {
      if (result != null) {
        this.authGuard.SetAuthModel(result.subscribedId, result.subscribedEmail, result.subcriptionCode, "Test_Token");
        this.router.navigate(['/api']);
      }      
    }, error => {
    });
  }
}
