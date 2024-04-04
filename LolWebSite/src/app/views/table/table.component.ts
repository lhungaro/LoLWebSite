import { Component } from '@angular/core';
import { Duo, DuoDTO } from 'src/app/models/duo';
import { DuoService } from 'src/app/services/duo.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent {

  constructor(private duoService:DuoService) { }

  duos : DuoDTO[] = [];
  modalOpen : boolean = false;

  ngOnInit(){
    this.getAllDuos();
  }

  getAllDuos(){
      this.duoService.getAllDuos().subscribe({
        next: (_duos:DuoDTO[]) => {
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
