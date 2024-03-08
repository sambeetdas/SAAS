import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SubscriptionComponent } from './subscription/subscription.component';
import { LoginComponent } from './login/login.component';
import { APIComponent } from './api/api.component';
import { ScriptComponent } from './script/script.component';
import { Utility } from './common/utility';
import { AuthGuard } from './common/authguard';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SubscriptionComponent,
    LoginComponent,
    APIComponent,
    ScriptComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'subscribe/:subscriptionCode', component: SubscriptionComponent },
      { path: 'login', component: LoginComponent },
      { path: 'api', component: APIComponent, canActivate: [AuthGuard] },
      { path: 'script/:serviceReferenceId', component: ScriptComponent, canActivate: [AuthGuard]},
    ])
  ],
  providers: [Utility, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
