import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCandidateComponent } from './add-candidate/add-candidate.component';
import { EditCandidateComponent } from './edit-candidate/edit-candidate.component';
import { HomeComponent } from './home/home.component';
import { ViewCandidateComponent } from './view-candidate/view-candidate.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent },
  { path: 'ViewCandidate/:candidateId', component: ViewCandidateComponent },
  { path: 'AddCandidate', component: AddCandidateComponent },
  { path: 'EditCandidate/:candidateId', component: EditCandidateComponent } 
];
  

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }