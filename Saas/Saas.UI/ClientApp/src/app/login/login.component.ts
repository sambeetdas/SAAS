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
  public subscribed: LoginModel

  constructor(http: HttpClient, utility: Utility, router: Router) {
    this.subscribed = new LoginModel();
    this.router = router;
    this.http = http;
    this.utility = utility;
  }

  Login() {
    this.router.navigate(['/api']);
  }
}

class LoginModel {
  Email: string;
  Password: string;
}
