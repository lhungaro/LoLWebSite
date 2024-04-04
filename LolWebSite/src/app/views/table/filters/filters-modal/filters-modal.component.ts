
import { Component, EventEmitter, Output } from '@angular/core';
import { Account } from 'src/app/models/account';
import { Duo } from 'src/app/models/duo';
import { Mastery } from 'src/app/models/mastery';
import { AccountService } from 'src/app/services/account.service';
import { DuoService } from 'src/app/services/duo.service';

@Component({
  selector: 'app-filters-modal',
  templateUrl: './filters-modal.component.html',
  styleUrls: ['./filters-modal.component.css']
})
export class FiltersModalComponent {

  constructor(private accountService:AccountService,
    private duoService:DuoService) { }

  @Output() closeModalTable = new EventEmitter<boolean>();
 
  perfilVerificado = false;
  username!:string;

  borderUrl = "https://toppng.com/free-image/level-425-summoner-icon-border-league-of-legends-level-425-PNG-free-PNG-Images_176028";
  eloUrl! : string;
  verified : boolean = false;
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
  
  eloSelecionado!:any;
  gameMode: any;
  lanes:any[] = [];
  lanesDuo:any[] = [];
  isVoiceUserCheck:any;
  note:any;
  tag:any;

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

  podeVerificar(){
    return this.username.length > 0 && this.tag.length > 0;
  }

  Verificar(){
    debugger
    this.GetUser();
  }

  GetUser(){
    if(this.username && this.tag){

      this.accountService.getIdAccountByNameBr(this.username + this.tag).subscribe({
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
            this.verified = true;
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
    }
    this.perfilVerificado = true;
  }

  onSubmit() {
    this.verificaLanesAtivas();
    let piuuid = "";
    let gameName = this.username;
    let tagLine = this.tag;
    let elo = this.eloSelecionado;

    if(this.verified){
      piuuid = this.account.puuid;
      gameName = this.account.gameName;
      tagLine = this.account.tagLine;
      elo = this.elo;

    }
    debugger
    let duo : Duo = {
      id : 0,
      puuid : piuuid,
      gameName : gameName,
      tagLine : tagLine, 
      lane : this.lanes.toString(),
      laneDuo : this.lanesDuo.toString(),
      elo : elo,
      modoDeJogo : this.gameMode,
      isVoiceUser : this.isVoiceUserCheck,
      note : this.note,
    }

    this.postDuo(duo);

    console.log(duo);
    console.log("Lanes : " +this.lanes);
    console.log("Username : " +this.username);
    console.log("TAG : " +this.tag);
    console.log("LanesDuo : " +this.lanesDuo);
    console.log("ELo : " +this.eloSelecionado);
    console.log("Modo de Jogo : " +this.gameMode);
    console.log("Usa voice : " +this.isVoiceUserCheck);
    console.log("Nota : " +this.note);
  }

  verificaLanesAtivas(){
    
    if(this.topLaneIsActive)
    this.lanes.push('top')
    if(this.jungleLaneIsActive)
    this.lanes.push('jungle')
    if(this.midLaneIsActive)
    this.lanes.push('mid')
    if(this.botLaneIsActive)
    this.lanes.push('bot')
    if(this.suporteLaneIsActive)
    this.lanes.push('suporte')

    if(this.topDuoLaneIsActive)
    this.lanesDuo.push('top')
    if(this.jungleDuoLaneIsActive)
    this.lanesDuo.push('jungle')
    if(this.midDuoLaneIsActive)
    this.lanesDuo.push('mid')
    if(this.botDuoLaneIsActive)
    this.lanesDuo.push('bot')
    if(this.suporteDuoLaneIsActive)
    this.lanesDuo.push('suporte')
  }

  postDuo(duo:Duo) {
    const data = duo; // Dados que você quer enviar
    this.duoService.postDuo(data).subscribe(response => {
      console.log('Response:', response);
      // Faça algo com a resposta, se necessário
    }, error => {
      console.error('Error:', error);
      // Trate o erro, se necessário
    });
  }

}
