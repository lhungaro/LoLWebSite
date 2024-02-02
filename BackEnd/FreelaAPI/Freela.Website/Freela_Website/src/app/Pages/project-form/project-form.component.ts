import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/models/company';
import { Project } from 'src/app/models/project';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-project-form',
  templateUrl: './project-form.component.html',
  styleUrls: ['./project-form.component.css']
})
export class ProjectFormComponent implements OnInit {

  constructor(
    private projectService : ProjectService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router : Router
  ) { }

  project = {} as Project;
  form! : FormGroup;
  company = {} as Company;

  ngOnInit(): void {
    this.validation();

  }

  public validation(){
    this.form = new FormGroup({
      title : new FormControl(),
      name : new FormControl(),
      cnpj : new FormControl(),
      description : new FormControl(),
      area : new FormControl(),
      valuetopay : new FormControl(),
      categories : new FormControl(),
      contact : new FormControl(),
    })
  }

  public salvar():void{
    this.spinner.show();
    console.log(this.form.value.title);
    this.project.title = this.form.value.title;
    this.project.description = this.form.value.description;
    this.project.area = this.form.value.area;
    this.project.valuetopay = this.form.value.valuetopay;
    this.project.categories = this.form.value.categories;
    this.project.contaxt = this.form.value.contact;
    this.project.proposes = 0;
    this.project.status = 1;
    this.project.ranking = 1;
    this.project.createdate = new Date();

    this.company.name = this.form.value.name;
    this.company.cpnj = this.form.value.cnpj;
    this.company.companyRanking = 1;
    this.company.companyStatus = 1;

    this.project.company = this.company;


    this.projectService.post(this.project).subscribe(
      () =>
      {
        this.toastr.success('Salvo com sucesso!', 'Sucesso!')
        console.log("Salvo com sucesso");
        setTimeout(() => {
          this.router.navigate(['/encontre-um-freela']);
        }, 2000);

    },
      (error:any) => {
        console.log(error);
        this.spinner.hide();
        this.toastr.error('Erro ao salvar','Erro!')
      },
      () => {
        setTimeout(() => {
          this.spinner.hide();
        }, 2000);
      }

    );
  }

}
