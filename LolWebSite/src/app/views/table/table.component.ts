import { Component } from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent {

  rows : number[] = [1,2,3,11,1,1,1,1]
  modalOpen : boolean = false;


  closeModal(modal:boolean){
    this.modalOpen = modal;
  }

  openModal(){
    this.modalOpen = true;
  }
}
