import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Filme } from './filme';
import { Observable } from 'rxjs';
var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};
@Injectable()
export class FilmesService {

  private url: string = 'https://localhost:44341/CopaFilme/';

  constructor(private http: HttpClient) { }
 
  buscarTodos(): Observable<Filme[]> {  
    return this.http.get<Filme[]>(this.url + "ObterTodos");  
  } 
  fazerCompeticao(filmes: Filme[]): Observable<Filme[]> { 
    return this.http.post<Filme[]>(this.url + "FazerCompeticao", filmes, httpOptions);  
  }   
 
}
