
import { Component, EventEmitter, Output } from '@angular/core';
import { Mastery } from 'src/app/models/mastery';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-filters-modal',
  templateUrl: './filters-modal.component.html',
  styleUrls: ['./filters-modal.component.css']
})
export class FiltersModalComponent {

  constructor(private accountService:AccountService) { }

  @Output() closeModalTable = new EventEmitter<boolean>();
 
  perfilVerificado = false;
  username!:string;

  borderUrl = "https://toppng.com/free-image/level-425-summoner-icon-border-league-of-legends-level-425-PNG-free-PNG-Images_176028";
  eloUrl! : string;
  verified : boolean = true;
  totalGames : number = 332;
  PDL : number = 92;
  elo : string = "Esmeralda II";
  LabelVerificar = "Verificar";
  topLaneIsActive :boolean = false;
  jungleLaneIsActive: boolean = false;
  midLaneIsActive: boolean = false;
  botLaneIsActive: boolean = false;
  suporteLaneIsActive: boolean = false;
  topDuoLaneIsActive :boolean = false;
  jungleDuoLaneIsActive: boolean = false;
  midDuoLaneIsActive: boolean = false;
  botDuoLaneIsActive: boolean = false;
  suporteDuoLaneIsActive: boolean = false;

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

  selecionouTop(){
    this.topLaneIsActive = !this.topLaneIsActive;
  }
  selecionouJungle(){
    this.jungleLaneIsActive = !this.jungleLaneIsActive;
  }
  selecionouMid(){
    this.midLaneIsActive = !this.midLaneIsActive;
  }
  selecionouBot(){
    this.botLaneIsActive = !this.botLaneIsActive;
  }
  selecionouSuporte(){
    this.suporteLaneIsActive = !this.suporteLaneIsActive;
  }

  selecionouDuoTop(){
    this.topDuoLaneIsActive = !this.topDuoLaneIsActive;
  }
  selecionouDuoJungle(){
    this.jungleDuoLaneIsActive = !this.jungleDuoLaneIsActive;
  }
  selecionouDuoMid(){
    this.midDuoLaneIsActive = !this.midDuoLaneIsActive;
  }
  selecionouDuoBot(){
    this.botDuoLaneIsActive = !this.botDuoLaneIsActive;
  }
  selecionouDuoSuporte(){
    this.suporteDuoLaneIsActive = !this.suporteDuoLaneIsActive;
  }

  Verificar(){
    if(this.username)
      this.accountService
  }

}
