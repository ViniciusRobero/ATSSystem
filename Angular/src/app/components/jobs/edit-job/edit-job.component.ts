import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from 'src/app/service/http-provider.service';


@Component({
  selector: 'app-edit-job',
  templateUrl: './edit-job.component.html',
  styleUrls: ['./edit-job.component.scss']
})
export class EditJobComponent implements OnInit {
  editJobForm: jobForm = new jobForm();

  @ViewChild("jobForm")
  jobForm!: NgForm;

  isSubmitted: boolean = false;
  jobId: any;

  constructor(private toastr: ToastrService, private route: ActivatedRoute, private router: Router,
    private httpProvider: HttpProviderService) { }

  ngOnInit(): void {
    this.jobId = this.route.snapshot.params['jobId'];
    this.getJobDetailById();
  }

  getJobDetailById() {
    this.httpProvider.getJobDetailById(this.jobId).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body.data;
        if (resultData) {
          this.editJobForm.Id = resultData.id;
          this.editJobForm.JobTitle = resultData.jobTitle;
          this.editJobForm.JobDiscription = resultData.jobDiscription;
          this.editJobForm.Seniority = resultData.seniority;
          this.editJobForm.Salary = resultData.salary;
        }
      }
    },
      (error: any) => { });
  }

  EditJob(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.saveJob(this.editJobForm).subscribe(async data => {
        if (data != null && data.body != null) {
          var resultData = data.body;
            if (resultData != null && resultData.succeeded) {
              this.toastr.success("Vaga atualizada com sucesso.");
              setTimeout(() => {
                this.router.navigate(['/ListJobs']);
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

export class jobForm {
  Id: number = 0;
  JobTitle: string = "";
  JobDiscription: string = "";
  Seniority:string = "";
  Salary: string ="";
}
