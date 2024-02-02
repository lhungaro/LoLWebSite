import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LandingComponent } from './pages/landing/landing.component';
import { FooterComponent } from './components/footer/footer.component';
import { FreelaListComponent } from './pages/freela-list/freela-list.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { FreelaItemComponent } from './components/freela-item/freela-item.component';
import { ProjectListComponent } from './Pages/project-list/project-list.component';
import { ProjectItemComponent } from './components/project-item/project-item.component';
import { FreelaRankingComponent } from './components/freela-ranking/freela-ranking.component';
import { ModalFreelaComponent } from './components/modal-freela/modal-freela.component';
import { AppRoutingModule } from './app-routing-module';
import { FreelaFormComponent } from './Pages/freela-form/freela-form.component';
import { ProjectFormComponent } from './Pages/project-form/project-form.component';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './Pages/register/register.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    FooterComponent,
    FreelaListComponent,
    PageHeaderComponent,
    FreelaItemComponent,
    ProjectItemComponent,
    ProjectListComponent,
    FreelaRankingComponent,
    ModalFreelaComponent,
    FreelaFormComponent,
    ProjectFormComponent,
    LoginComponent,
    RegisterComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    CommonModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
      progressAnimation: 'increasing'
    })

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
