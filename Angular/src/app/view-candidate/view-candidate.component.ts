import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpProviderService } from '../service/http-provider.service';
import { WebApiService } from '../service/web-api.service';

@Component({
  selector: 'app-view-candidate',
  templateUrl: './view-candidate.component.html',
  styleUrls: ['./view-candidate.component.scss']
})
export class ViewCandidateComponent implements OnInit {

  candidateId: any;
  candidateDetail : any= [];
   
  constructor(public webApiService: WebApiService, private route: ActivatedRoute, private httpProvider : HttpProviderService) { }
  
  ngOnInit(): void {
    this.candidateId = this.route.snapshot.params['candidateId'];      
    this.getCandidateDetailById();
  }

  getCandidateDetailById() {       
    this.httpProvider.getCandidateDetailById(this.candidateId).subscribe((data : any) => {      
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.candidateDetail = resultData;
        }
      }
    },
    (error :any)=> { }); 
  }

}
