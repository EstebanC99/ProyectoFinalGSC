import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Thing } from 'src/app/Interfaces/thing';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ThingService {
  private _things: BehaviorSubject<Thing[]> = new BehaviorSubject<Thing[]>([]);
  public thingsList: Observable<Thing[]> = this._things.asObservable();

  constructor(
    private http: HttpClient
  ) { 
    this.getThings();
  }

  getThings(): void {
    this.http.get<Thing[]>(`${environment.apiUrl}/Thing/Things`).subscribe(
      (data: Thing[]) => {
        this._things.next(data);
      }
    );
  }

  refreshList(): void {
    this.getThings();
  }
}
