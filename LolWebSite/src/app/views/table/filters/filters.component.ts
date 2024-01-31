import { Component } from '@angular/core';

@Component({
  selector: 'app-filters',
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class FiltersComponent {
  selectedOption: any;

  options = [
    { value: 1, label: 'Opção 1', image: '../../../assets/ranked-emblem/emblem-esmerald.png' },
    { value: 2, label: 'Opção 2', image: '../../../assets/ranked-emblem/emblem-esmerald.png' },
    { value: 3, label: 'Opção 3', image: '../../../assets/ranked-emblem/emblem-esmerald.png' },
  ];
  
  modalOpen : boolean = true;

  closeModal(modal:boolean){
    this.modalOpen = modal;
  }

  openModal(){
    this.modalOpen = true;
  }
}
