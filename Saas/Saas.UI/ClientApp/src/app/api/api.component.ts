import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Utility } from '../common/utility';
import { Service } from '../model/service.model';

@Component({
  selector: 'app-home',
  templateUrl: './api.component.html',
})

export class APIComponent {


  public http: HttpClient;
  public utility: Utility;
  public router: Router;
  public services: Service[];

  constructor(http: HttpClient, utility: Utility, router: Router) {
    this.http = http;
    this.utility = utility;
    this.router = router;
  }

  ngOnInit() {
    this.GetServices();
  }

  GetServices() {

    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    };

    this.http.get<Service[]>(this.utility.serverUrl + '/api/Service/GetAllServices', httpHeader).subscribe(result => {
      this.services = result;
    }, error => console.error(error));
  }

  GotoScript(serviceReferenceId: string) {

    this.router.navigate(['/script', serviceReferenceId]);
  }

}
