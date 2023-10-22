import { Component, EventEmitter, Output } from '@angular/core';
import { Mastery } from 'src/app/models/mastery';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {

  @Output() closeModalTable = new EventEmitter<boolean>();


  borderUrl = "https://toppng.com/free-image/level-425-summoner-icon-border-league-of-legends-level-425-PNG-free-PNG-Images_176028";
  eloUrl! : string;
  username  = "Username";
  verified : boolean = true;
  totalGames : number = 332;
  PDL : number = 92;
  elo : string = "Esmeralda II";

  champMastery1 : Mastery = {
    champ: "Aatrox",
    masteryPoints: "256.351",
    masteryLevel: "7",
    champIconUrl:"http://ddragon.leagueoflegends.com/cdn/13.20.1/img/champion/Aatrox.png"
  }

  champMastery2 : Mastery = {
    champ: "Ahri",
    masteryPoints: "256.351",
    masteryLevel: "7",
    champIconUrl:"http://ddragon.leagueoflegends.com/cdn/13.20.1/img/champion/Ahri.png"

  }
  champMastery3 : Mastery = {
    champ: "Sejuani",
    masteryPoints: "256.351",
    masteryLevel: "7",
    champIconUrl:"http://ddragon.leagueoflegends.com/cdn/13.20.1/img/champion/Sejuani.png"
  }
  
  closeModal(){
    this.closeModalTable.emit(false);
  }
}
