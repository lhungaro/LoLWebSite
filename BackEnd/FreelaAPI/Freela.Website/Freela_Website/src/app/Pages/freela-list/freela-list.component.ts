import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Freela } from 'src/app/models/freela';
import { FreelaService } from 'src/app/services/freela.service';

@Component({
  selector: 'app-freela-list',
  templateUrl: './freela-list.component.html',
  styleUrls: ['./freela-list.component.css']
})
export class FreelaListComponent implements OnInit {

  freelas : Freela[] = [];

  constructor( private freelaService : FreelaService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    ) { }

  ngOnInit(): void {
    this.getFreela();
  }

  public getFreela() : void{
    this.freelaService.getFreela().subscribe(
      response =>{
        this.freelas = response;
      },error => {
        console.log(error)
        this.spinner.hide();
        this.toastr.error('Erro ao salvar','Erro!')
      });
      setTimeout(() => {
        this.spinner.hide();
      }, 2000);
  }
}
