import { Component, Input, OnInit } from '@angular/core';
import { Freela } from 'src/app/models/freela';

@Component({
  selector: 'app-freela-item',
  templateUrl: './freela-item.component.html',
  styleUrls: ['./freela-item.component.css']
})
export class FreelaItemComponent implements OnInit {

  @Input() freela?: Freela;
  modalOpen = false;

  constructor() { }

  ngOnInit(): void {
    console.log(this.freela?.company?.companyRanking);

  }

  activeModal() {
    this.modalOpen = true;
  }
  closeModal(a:any) {
    this.modalOpen = false;
  }

}
