import { Router, CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Authenticated } from '../model/authenticated.model';


@Injectable()
export class AuthGuard implements CanActivate {

  private auth: Authenticated = new Authenticated();
  public getAuthModel = new Subject();

  constructor(private _router: Router) {

  }

  public SetAuthModel(subscriptionId: string, subscriptionUser: string, subscriptionType: string, token: string) {
    this.auth.isAuthenticated = true;
    this.auth.subscriptionId = subscriptionId;
    this.auth.subscriptionUser = subscriptionUser;
    this.auth.subscriptionType = subscriptionType;
    this.auth.token = token;

    this.SetCookie(this.auth);

    this.RefreshSubject();
  }

  public GetAuthModel(): Authenticated {
    let authJson: string = this.GetCookie();
    let authModel: Authenticated = Object.assign(new Authenticated(), JSON.parse(authJson));
    //this.RefreshSubject();
    return authModel;
  }

  public DisposeAuthModel() {
    this.ClearCookie();
    this.RefreshSubject();
  }

  public canActivate(): boolean {
    if (this.IsLoggedin())
      return true;
    else {
      this._router.navigate(['/login']);
      return false;
    }
  }

  private RefreshSubject() {
    let cookieContent = this.GetAuthModel();
    this.getAuthModel.next(cookieContent);
  }

  private IsLoggedin() {
    let authModel = this.GetAuthModel();
    return authModel.isAuthenticated;
  }

  private SetCookie(auth: Authenticated) {
    localStorage.setItem('cookie_key', JSON.stringify(auth));
  }

  private GetCookie(): string {
    let authJson: string = localStorage.getItem('cookie_key');
    return authJson;
  }

  private ClearCookie() {
    localStorage.removeItem('cookie_key')
  }

}


