import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';

//var apiUrl = "https://localhost:44370/";

var apiUrl = "http://192.168.10.10:105";

var httpLink = {
  getAllCandidate: apiUrl + "/api/candidate/getAllCandidate",
  deleteCandidateById: apiUrl + "/api/candidate/deleteCandidateById",
  getCandidateDetailById: apiUrl + "/api/candidate/getCandidateDetailById",
  saveCandidate: apiUrl + "/api/candidate/saveCandidate"
}

@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {

  constructor(private webApiService: WebApiService) { }

  public getAllCandidate(): Observable<any> {
    return this.webApiService.get(httpLink.getAllCandidate);
  }

  public deleteCandidateById(model: any): Observable<any> {
    return this.webApiService.post(httpLink.deleteCandidateById + '?candidateId=' + model, "");
  }

  public getCandidateDetailById(model: any): Observable<any> {
    return this.webApiService.get(httpLink.getCandidateDetailById + '?candidateId=' + model);
  }

  public saveCandidate(model: any): Observable<any> {
    return this.webApiService.post(httpLink.saveCandidate, model);
  }
  
}
