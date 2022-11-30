import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Person } from '../../Interfaces/person';
import { PersonServiceService } from '../../Services/Person/person.service';

@Component({
  selector: 'app-persons-list',
  templateUrl: './persons-list.component.html',
  styleUrls: ['./persons-list.component.css']
})
export class PersonsListComponent implements OnInit {

  dataSource = new MatTableDataSource<Person>([]);
  displayedColumns: string[] = ["id", "name", "lastname", "email", "phone"];
  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;
  @Output() selectedPerson = new EventEmitter<Person>();
  @Output() displayed = new EventEmitter<boolean>();
  
  constructor(
    private personService: PersonServiceService) {
   
  }

  ngOnInit(): void {
    this.personService.personsList.subscribe((data: Person[]) => {
      this.dataSource.data = data;
    });
    this.dataSource.paginator = this.paginator;
    this.displayed.emit(true);
  }

  selectPerson(selectedPerson: Person): void{
    if(selectedPerson == null) return;
    this.displayed.emit(false);
    
    this.selectedPerson.emit(selectedPerson);
  }
}
