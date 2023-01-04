import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCandidateComponent } from './components/candidates/add-candidate/add-candidate.component';
import { EditCandidateComponent } from './components/candidates/edit-candidate/edit-candidate.component';
import { ListCandidateComponent } from './components/candidates/list-candidate/list-candidate.component';
import { HomeComponent } from './components/home/home.component';
import { AddJobComponent } from './components/jobs/add-job/add-job.component';
import { EditJobComponent } from './components/jobs/edit-job/edit-job.component';
import { ListJobComponent } from './components/jobs/list-jobs/list-job.component';
import { ViewCandidateComponent } from './components/view-candidate/view-candidate.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent },
  { path: 'ViewCandidate/:candidateId', component: ViewCandidateComponent },
  { path: 'AddCandidate', component: AddCandidateComponent },
  { path: 'EditCandidate/:candidateId', component: EditCandidateComponent },
  { path: 'ListCandidates', component: ListCandidateComponent }, 
  { path: 'AddJobs', component: AddJobComponent },
  { path: 'EditJobs/:jobId', component: EditJobComponent },
  { path: 'ListJobs', component: ListJobComponent },
];
  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }