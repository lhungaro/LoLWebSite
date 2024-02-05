import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
@Injectable()

export class AccountService{

  constructor(private http: HttpClient) {}

  private baseUrl = 'https://localhost:7213/'

  public getIdAccountByNameBr(name: string){
    let parts = name.split('#');
    let tag = parts[1];
    let username = parts[0];
    var url = this.baseUrl + `GetAccount/${username}/${tag}`;
    
    return this.http.get<any>(url);
  }

  public getMaestriasByPiuuId(piuuid: string){
    var url = this.baseUrl + `GetMastery/${piuuid}`;
    
    return this.http.get<any>(url);
  }

}

