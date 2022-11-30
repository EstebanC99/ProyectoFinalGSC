import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Person } from 'src/app/Interfaces/person';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonServiceService {

  private _persons : BehaviorSubject<Person[]> = new BehaviorSubject<Person[]>([]);

  public readonly personsList: Observable<Person[]> = this._persons.asObservable();

  constructor(private http: HttpClient) {
    this.getPersonsList();  
  }

  getPersonsList(): void {
    this.http.get<Person[]>(`${environment.apiUrl}/Person/Persons`).subscribe((data: Person[]) => {
      this._persons.next(data);
    });
  }

  saveNewPerson(person: Person): void {
    this.http.post<Person>(`${environment.apiUrl}/Person/Add`, person).subscribe(() => this.refreshList());
  }

  updatePerson(existingPerson: Person): void {
    this.http.put<Person>(`${environment.apiUrl}/Person/Modify`, existingPerson).subscribe(() => this.refreshList());
  }

  deletePerson(person: Person): void {
    this.http.delete(`${environment.apiUrl}/Person/Delete?ID=${person.id}`).subscribe(() => this.refreshList());
  }

  refreshList(): void {
    this.getPersonsList();
  }
}
