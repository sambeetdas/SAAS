import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Utility } from '../common/utility';
import { Script } from '../model/script.model';



@Component({
  selector: 'app-home',
  templateUrl: './script.component.html',
})

export class ScriptComponent {


  public http: HttpClient;
  public utility: Utility;
  public router: Router;
  public activatedRoute: ActivatedRoute;
  public scripts: Script[];
  public serviceReferenceId: string;

  constructor(http: HttpClient, utility: Utility, router: Router, activatedRoute: ActivatedRoute) {
    this.http = http;
    this.utility = utility;
    this.router = router;
    this.activatedRoute = activatedRoute;
  }

  ngOnInit() {
    this.serviceReferenceId = this.activatedRoute.snapshot.params['serviceReferenceId'];
    this.GetScripts();
  }

  GetScripts() {

    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    };

    this.http.get<Script[]>(this.utility.serverUrl + '/api/Service/GetServiceScript/' + this.serviceReferenceId, httpHeader).subscribe(result => {
      console.log(result);
      this.scripts = result;
    }, error => console.error(error));
  }

  Validate(script: Script) {
    const httpHeader = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    };

    this.http.post(this.utility.serverUrl + '/api/Service/ValidateScript', script, httpHeader).subscribe(result => {
      if (result != null) {
        console.log(result);
      }
    }, error => {
    });

  }

  ProcessScript(script: Script) {
    console.log(script);

  }
}
