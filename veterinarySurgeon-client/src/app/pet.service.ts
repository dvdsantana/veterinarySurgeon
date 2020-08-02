import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PetService {

  private baseUrl = 'https://localhost:44392/pets';

  constructor(private http: HttpClient) { }

  createPet(pet: Object): Observable<Object> {
    return this.http.post(`${this.baseUrl}`, pet);
  }

  deletePet(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getPetsList(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
  }
}
