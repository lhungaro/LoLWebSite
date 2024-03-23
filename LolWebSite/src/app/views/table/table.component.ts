import { Component } from '@angular/core';
import { Duo } from 'src/app/models/duo';
import { DuoService } from 'src/app/services/duo.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent {

  constructor(private duoService:DuoService) { }

  duos : Duo[] = [];
  modalOpen : boolean = false;

  ngOnInit(){
    this.GetAllDuos();
  }

  GetAllDuos(){
      this.duoService.getAllDuos().subscribe({
        next: (_duos:Duo[]) => {
          this.duos = _duos
          console.log("Sucesso");
          console.log(this.duos);
        },
        error: (error:any) => {
          // this.spinner.hide();
          console.log('Erro ao carregar o Usuário','Erro!');
        },
      });
  }

  closeModal(modal:boolean){
    this.modalOpen = modal;
  }

  openModal(){
    this.modalOpen = true;
  }
}
