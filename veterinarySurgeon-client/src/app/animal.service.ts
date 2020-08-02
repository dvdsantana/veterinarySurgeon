import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AnimalService {

  private baseUrl = 'https://localhost:44392/animals';

  constructor(private http: HttpClient) { }

  getAnimalsList(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
  }
}