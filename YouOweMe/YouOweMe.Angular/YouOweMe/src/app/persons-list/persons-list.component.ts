import { DataSource } from '@angular/cdk/collections';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { Observable } from 'rxjs';
import { Person } from '../Interfaces/person';
import { PersonServiceService } from '../Services/Person/person.service';

@Component({
  selector: 'app-persons-list',
  templateUrl: './persons-list.component.html',
  styleUrls: ['./persons-list.component.css']
})
export class PersonsListComponent implements OnInit, AfterViewInit {
  DataSource = new PersonDataSource(this.personService);
  DisplayedColumns: string[] = ["id", "name", "lastname", "email", "phone"];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  
  constructor(private personService: PersonServiceService) {
   
  }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {

  }

  recargarListado(recargar: boolean): void {
    this.DataSource.connect().subscribe();
  }

}

export class PersonDataSource extends DataSource<Person> {
  constructor(private personService: PersonServiceService){
    super();
  }

  connect(): Observable<Person[]> {
    return this.personService.GetPersonsList();
  }

  disconnect(): void {
    
  }
}
