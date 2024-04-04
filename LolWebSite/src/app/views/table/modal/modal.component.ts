import { Component, EventEmitter, Output } from '@angular/core';
import { Mastery } from 'src/app/models/mastery';
import { DuoService } from 'src/app/services/duo.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  constructor(private duoService:DuoService) {}

  @Output() closeModalTable = new EventEmitter<boolean>();


  borderUrl = "https://toppng.com/free-image/level-425-summoner-icon-border-league-of-legends-level-425-PNG-free-PNG-Images_176028";
  eloUrl! : string;
  username  = "Username";
  verified : boolean = true;
  totalGames : number = 332;
  PDL : number = 92;
  elo : string = "Esmeralda II";

  champMastery1 : any = {
    champ: "Aatrox",
    championPoints: "256.351",
    championLevel: "7",
    champIconUrl:"http://ddragon.leagueoflegends.com/cdn/13.20.1/img/champion/Aatrox.png"
  }

  champMastery2 : any = {
    champ: "Ahri",
    championPoints: "256.351",
    championLevel: "7",
    champIconUrl:"http://ddragon.leagueoflegends.com/cdn/13.20.1/img/champion/Ahri.png"

  }
  champMastery3 : any = {
    champ: "Sejuani",
    championPoints: "256.351",
    championLevel: "7",
    champIconUrl:"http://ddragon.leagueoflegends.com/cdn/13.20.1/img/champion/Sejuani.png"
  }
  
  closeModal(){
    this.closeModalTable.emit(false);
  }

  

}
