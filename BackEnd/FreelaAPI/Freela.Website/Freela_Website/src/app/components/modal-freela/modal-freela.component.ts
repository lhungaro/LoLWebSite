import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Freela } from 'src/app/models/freela';

@Component({
  selector: 'app-modal-freela',
  templateUrl: './modal-freela.component.html',
  styleUrls: ['./modal-freela.component.css']
})
export class ModalFreelaComponent implements OnInit {

  @Input() freela?: Freela;
  @Output() closeModal = new EventEmitter<any>();
  constructor() { }

  ngOnInit(): void {
  }

  close() {
    this.closeModal.emit(null);
  }

}
