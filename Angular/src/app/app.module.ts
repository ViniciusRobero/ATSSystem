import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { ViewCandidateComponent } from './components/view-candidate/view-candidate.component';
import { AddCandidateComponent } from './components/candidates/add-candidate/add-candidate.component';
import { EditCandidateComponent } from './components/candidates/edit-candidate/edit-candidate.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ListCandidateComponent } from './components/candidates/list-candidate/list-candidate.component';
import { AddJobComponent } from './components/jobs/add-job/add-job.component';
import { EditJobComponent } from './components/jobs/edit-job/edit-job.component';
import { ListJobComponent } from './components/jobs/list-jobs/list-job.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ViewCandidateComponent,
    AddCandidateComponent,
    EditCandidateComponent,
    ListCandidateComponent,
    AddJobComponent,
    EditJobComponent,
    ListJobComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
