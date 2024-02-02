import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Project } from "../models/project";

@Injectable({
  providedIn: 'root',
})

export class ProjectService {

  baseURL = 'https://localhost:7123/api/project';

  constructor( private http: HttpClient) {
  }

  getProject(): Observable<Project[]> {
    return this.http.get<Project[]>(this.baseURL)
  }

  getProjectByArea(area : string): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.baseURL}/${area}/area`)
  }

  getProjectById(id : number): Observable<Project> {
    return this.http.get<Project>(`${this.baseURL}/${id}`);
  }

  public post(Project: Project) : Observable<Project>{
    return this.http.post<Project>(this.baseURL, Project);
  }
}
