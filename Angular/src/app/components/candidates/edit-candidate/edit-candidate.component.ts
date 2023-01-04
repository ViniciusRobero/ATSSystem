import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from 'src/app/service/http-provider.service';


@Component({
  selector: 'app-edit-candidate',
  templateUrl: './edit-candidate.component.html',
  styleUrls: ['./edit-candidate.component.scss']
})
export class EditCandidateComponent implements OnInit {
  editCandidateForm: candidateForm = new candidateForm();

  @ViewChild("candidateForm")
  candidateForm!: NgForm;

  isSubmitted: boolean = false;
  candidateId: any;

  constructor(private toastr: ToastrService, private route: ActivatedRoute, private router: Router,
    private httpProvider: HttpProviderService) { }

  ngOnInit(): void {
    this.candidateId = this.route.snapshot.params['candidateId'];
    this.getCandidateDetailById();
  }

  getCandidateDetailById() {
    this.httpProvider.getCandidateDetailById(this.candidateId).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body.data;
        if (resultData) {
          this.editCandidateForm.Id = resultData.id;
          this.editCandidateForm.FirstName = resultData.firstName;
          this.editCandidateForm.LastName = resultData.lastName;
          this.editCandidateForm.Email = resultData.email;
          this.editCandidateForm.Curriculum = resultData.curriculum;
        }
      }
    },
      (error: any) => { });
  }

  EditCandidate(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.saveCandidate(this.editCandidateForm).subscribe(async data => {
        if (data != null && data.body != null) {
          var resultData = data.body;
            if (resultData != null && resultData.succeeded) {
              this.toastr.success(resultData.message);
              setTimeout(() => {
                this.router.navigate(['/Home']);
              }, 500);
            }
        }
      },
        async error => {
          this.toastr.error(error.message);
          setTimeout(() => {
            this.router.navigate(['/Home']);
          }, 500);
        });
    }
  }
}

export class candidateForm {
  Id: number = 0;
  FirstName: string = "";
  LastName: string = "";
  Email: string = "";
  Curriculum: string = "";
}
