import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';

//var apiUrl = "https://localhost:44370/";

var apiUrl = "https://localhost:44308";

var httpLink = {
  candidates: apiUrl + "/api/Candidates"
}

@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {

  constructor(private webApiService: WebApiService) { }

  public getAllCandidate(): Observable<any> {
    return this.webApiService.get(httpLink.candidates);
  }

  public deleteCandidateById(id: any): Observable<any> {
    return this.webApiService.delete(httpLink.candidates + '/' + id);
  }

  public getCandidateDetailById(id: any): Observable<any> {
    return this.webApiService.get(httpLink.candidates + '/' + id);
  }

  public saveCandidate(model: any): Observable<any> {
    return this.webApiService.post(httpLink.candidates, model);
  }
  
}
