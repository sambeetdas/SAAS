import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Utility } from '../common/utility';
import { LoginModel } from '../model/login.model';

@Component({
  selector: 'app-home',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  public router: Router;
  public http: HttpClient;
  public utility: Utility;
  public login: LoginModel;
 

  constructor(http: HttpClient, utility: Utility, router: Router) {
    this.login = new LoginModel();
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

    this.http.post(this.utility.serverUrl + '/api/Subscription/ValidateSubscription', this.login, httpHeader).subscribe(result => {
      if (result != null) {
        this.router.navigate(['/api']);
      }      
    }, error => {
    });
  }
}
