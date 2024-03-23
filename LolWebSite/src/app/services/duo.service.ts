import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { Duo } from "../models/duo";
@Injectable()

export class DuoService{

  constructor(private http: HttpClient) {}

  private baseUrl = 'https://localhost:7213/api/Duo'

  public getAllDuos(){
    var url = this.baseUrl;
    return this.http.get<Duo[]>(url);
  }

  public getMaestriasByPiuuId(piuuid: string){
    var url = this.baseUrl + `GetMastery/${piuuid}`;
    
    return this.http.get<any>(url);
  }

}

