import { Component, OnInit, ViewChild } from '@angular/core';
import { Person } from '../../Interfaces/person';
import { PersonsDetailComponent } from '../persons-detail/persons-detail.component';
import { PersonsListComponent } from '../persons-list/persons-list.component';

@Component({
  selector: 'app-person-menu',
  templateUrl: './person-menu.component.html',
  styleUrls: ['./person-menu.component.css']
})
export class PersonMenuComponent implements OnInit {

  displayPersonList: boolean = true;
  displayPersonDetail: boolean = false;
  @ViewChild(PersonsListComponent) personsList!: PersonsListComponent;
  @ViewChild(PersonsDetailComponent) personDetail!: PersonsDetailComponent;

  constructor() { 

  }

  ngOnInit(): void {
  }

  displayPerson(selectedPerson: Person): void {
    this.personDetail.displayPerson(selectedPerson);
  }

}
