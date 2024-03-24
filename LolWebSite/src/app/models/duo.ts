import { AccountInformations } from "./account copy";

export interface Duo {
    id : number ;
    puuid : string ;
    gameName : string ;
    tagLine : string ; 
    lane : string ;
    laneDuo : string ;
    elo : string ;
    modoDeJogo : string ;
    isVoiceUser : boolean ;
    note : string ;
    idIcone: number;
    accountInformations : AccountInformations;
}

