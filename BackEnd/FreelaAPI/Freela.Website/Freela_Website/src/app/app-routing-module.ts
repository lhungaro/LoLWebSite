import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FreelaListComponent } from './pages/freela-list/freela-list.component';
import { ProjectListComponent } from './Pages/project-list/project-list.component';
import { LandingComponent } from './pages/landing/landing.component';
import { ProjectFormComponent } from './Pages/project-form/project-form.component';
import { FreelaFormComponent } from './Pages/freela-form/freela-form.component';
import { RegisterComponent } from './Pages/register/register.component';
import { LoginComponent } from './pages/login/login.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';

const routes: Routes = [
    { path: 'encontre-um-freela', component: FreelaListComponent },
    { path: 'encontre-um-job', component: ProjectListComponent },
    { path: 'publique-um-job', component: ProjectFormComponent },
    { path: 'cadastro-freela', component: FreelaFormComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'home', component: LandingComponent },
    { path: '**', component: PageNotFoundComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
