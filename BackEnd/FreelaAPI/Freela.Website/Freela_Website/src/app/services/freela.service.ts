import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Freela } from "../models/freela";

@Injectable({
  providedIn: 'root',
})

export class FreelaService {

  baseURL = 'https://localhost:7123/api/User';

  constructor( private http: HttpClient) {
  }

  getFreela(): Observable<Freela[]> {
    return this.http.get<Freela[]>(this.baseURL)
  }

  getFreelaByArea(area : string): Observable<Freela[]> {
    return this.http.get<Freela[]>(`${this.baseURL}/${area}/area`)
  }

  getFreelaById(id : number): Observable<Freela> {
    return this.http.get<Freela>(`${this.baseURL}/${id}`);
  }

  public post(Freela: Freela) : Observable<Freela>{
    return this.http.post<Freela>(this.baseURL, Freela);
  }
}
