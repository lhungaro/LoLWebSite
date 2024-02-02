import { DATE_PIPE_DEFAULT_TIMEZONE } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Company } from 'src/app/models/company';
import { Freela } from 'src/app/models/freela';
import { FreelaService } from 'src/app/services/freela.service';

@Component({
  selector: 'app-freela-form',
  templateUrl: './freela-form.component.html',
  styleUrls: ['./freela-form.component.css']
})
export class FreelaFormComponent implements OnInit {

  form!: FormGroup;
  freela = {} as Freela;
  company = {} as Company;

  constructor(private freelaService : FreelaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private router : Router) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation(){
    this.form = new FormGroup({
      name : new FormControl(),
      biography : new FormControl(),
      whatsapp : new FormControl(),
      area : new FormControl(),
      price : new FormControl(),
      curriculum : new FormControl(),
      companyName : new FormControl(),
      cnpj : new FormControl(),
    })
  }

  public salvar():void{
    this.spinner.show();

    this.freela.name = this.form.value.name;
    this.freela.biography = this.form.value.biography;
    this.freela.whatsapp = this.form.value.whatsapp;
    this.freela.area = this.form.value.area;
    this.freela.price = this.form.value.price;
    this.freela.photourl = "";
    this.freela.curriculum = this.form.value.curriculum;
    this.company.name = this.form.value.companyName;
    this.company.cpnj = this.form.value.cnpj;
    this.company.companyRanking = 1;
    this.company.companyStatus = 1;
    console.log(this.company);
    this.freela.company = this.company;

    this.freelaService.post(this.freela).subscribe(
      () =>
      {
        this.toastr.success('Salvo com sucesso!', 'Sucesso!')
        setTimeout(() => {
          this.router.navigate(['/encontre-um-job']);
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
