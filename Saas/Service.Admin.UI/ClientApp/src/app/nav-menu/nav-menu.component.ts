import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthGuard } from '../common/authguard';
import { Authenticated } from '../model/authenticated.model';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public router: Router;
  public authGuard: AuthGuard;
  public authentication: any;

  constructor(router: Router, authGuard: AuthGuard) {
    this.router = router;
    this.authGuard = authGuard;
  }

  ngOnInit() {

    this.authentication = this.authGuard.GetAuthModel();
    this.authGuard.getAuthModel.subscribe(a => this.authentication = a);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  Logout() {
    this.authGuard.DisposeAuthModel();
  }
}
