import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from 'src/app/Interfaces/person';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonServiceService {

  constructor(private http: HttpClient) {
    
  }

  GetPersonsList(): Observable<Person[]> {
    return this.http.get<Person[]>(`${environment.apiUrl}/Person/Persons`);
  }
}
