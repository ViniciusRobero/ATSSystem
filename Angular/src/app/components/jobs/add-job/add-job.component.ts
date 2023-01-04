import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../../../service/http-provider.service';

@Component({
  selector: 'app-add-job',
  templateUrl: './add-job.component.html',
  styleUrls: ['./add-job.component.scss']
})
export class AddJobComponent implements OnInit {
  addJobForm: jobForm = new jobForm();

  @ViewChild("jobForm")
  jobForm!: NgForm;

  isSubmitted: boolean = false;

  constructor(private router: Router, private httpProvider: HttpProviderService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  AddJob(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      console.log(this.addJobForm);
      this.httpProvider.saveJob(this.addJobForm).subscribe(async data => {
        if (data != null && data.body != null) {
          if (data != null && data.body != null) {
            var resultData = data.body;
            if (resultData != null && resultData.succeeded) {
              this.toastr.success("Vaga cadastrada com sucesso.");
              setTimeout(() => {
                this.router.navigate(['/ListJobs']);
              }, 500);
            }
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

export class jobForm {
  JobTitle: string = "";
  JobDiscription: string = "";
  Seniority:string = "";
  Salary: string ="";
}
