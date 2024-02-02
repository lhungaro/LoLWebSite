import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  @Output() toggleTheme: EventEmitter<any> = new EventEmitter();
  
  changeTheme() {
    console.log("mudou");
    
    this.toggleTheme.emit(); // Emitirá um evento para o pai
  }

}
