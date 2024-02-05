
import { Component, EventEmitter, Output } from '@angular/core';
import { Account } from 'src/app/models/account';
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
  account!:Account;
  mastery!:Mastery[];
  champMasterys : Mastery[] = []; 
  masterys: Mastery[]=[];
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
    this.GetUser();
  }

  GetUser(){
    if(this.username){

      this.accountService.getIdAccountByNameBr(this.username).subscribe({
        next: (_account:Account) => {
          this.account = _account
          console.log("Sucesso");
          console.log(this.account);
        },
        error: (error:any) => {
          // this.spinner.hide();
          console.log('Erro ao carregar o Usuário','Erro!');
        },
         complete: () => {
          if(this.account!= null){
            this.GetMasterys();
          }
        }
      });
    }
  }

  GetMasterys(){
    if(this.account!= null){
      this.accountService.getMaestriasByPiuuId(this.account.puuid).subscribe({
        next: (_mastery:Mastery[]) => {
          this.mastery = _mastery
          console.log("Sucesso");
          console.log(this.mastery);
        },
        error: (error:any) => {
          // this.spinner.hide();
          console.log('Erro ao carregar as Maestrias','Erro!');
        },
         complete: () => {
          this.populaMasterys()

        }
      });
    }
  }

  populaMasterys(){
    for(let i = 0; i < 3; i++){
      this.masterys.push(this.mastery[i]);
      console.log(this.masterys[i].champName)
      console.log(this.masterys[i].champUrlImg)
    }
    this.perfilVerificado = true;
  }

}
