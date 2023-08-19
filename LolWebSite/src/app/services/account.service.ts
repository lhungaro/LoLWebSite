import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
@Injectable()

export class AccountService{

  constructor(private http: HttpClient) {}

  private apiKey = 'RGAPI-51f07945-5c12-4dae-b801-71f16b80a080'
  private baseUrl = 'https://br1.api.riotgames.com'
  private headers = new HttpHeaders({
    'Authorization': `Bearer ${this.apiKey}`
  })
  
  // options = {
  //   headers : this.headers,
  // };
  

  public getIdAccountByNameBr(name: string){
    var url = this.baseUrl + `/lol/summoner/v4/summoners/by-name/${name}?api_key=${this.apiKey}`;
    
    return this.http.get<any>(url);
  }

  //type : normal, ranked, tourney, tutorial
  public getMatchsByPuuid(puuid: string, type:string){
    
    var url = `https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/${puuid}/ids?type=${type}&start=0&count=100&api_key=${this.apiKey}`;
    
    return this.http.get<any>(url);
  }

  public getMatchDataByMatchId(matchId :string){
    //colocar url certa
    var url = `https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/${matchId}/ids?type=${matchId}&start=0&count=100&api_key=${this.apiKey}`;
    
    return this.http.get<any>(url);
  }

}


