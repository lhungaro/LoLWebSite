import { Component, ElementRef, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'LolWebSite';
  isDarkTheme = false;

  constructor(private renderer : Renderer2, private el: ElementRef) {}

  toggleTheme() {
    console.log("Mudou tema");
    this.isDarkTheme = !this.isDarkTheme;
  }
}