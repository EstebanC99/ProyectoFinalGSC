import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';
import { Person } from 'src/app/Interfaces/person';
import { Thing } from 'src/app/Interfaces/thing';

@Component({
  selector: 'app-new-loan',
  templateUrl: './new-loan.component.html',
  styleUrls: ['./new-loan.component.css']
})
export class NewLoanComponent implements OnInit {

  step: number = 0;

  newLoanForm: FormGroup = this.formBuilder.group({
    owner: ['', [Validators.required]],
    thing: ['', [Validators.required]],
    quantityBorrowed: ['', [Validators.required, Validators.min(0), Validators.max(100)]]
  });

  filteredPersons: Observable<Person[]> = this.formControl['owner'].valueChanges.pipe(
    startWith(''), 
    map((val: string) => this._filterPerson(val || ''))
  );
  persons: Person[] = [
    { id: 1, name: 'Esteban', lastname: 'Carignani', email: 'esteban@mail.com', phone: '1238613' },
    { id: 2, name: 'Esteban', lastname: 'Carignani', email: 'esteban@mail.com', phone: '1238613' },
    { id: 3, name: 'Esteban', lastname: 'Carignani', email: 'esteban@mail.com', phone: '1238613' },
    { id: 4, name: 'Esteban', lastname: 'Carignani', email: 'esteban@mail.com', phone: '1238613' },
    { id: 5, name: 'Esteban', lastname: 'Carignani', email: 'esteban@mail.com', phone: '1238613' },
    { id: 6, name: 'Esteban', lastname: 'Carignani', email: 'esteban@mail.com', phone: '1238613' }
  ];
  things : Thing[] = [
    { id: 1, name: 'Cosa x', description: 'Mi descripcion', color: 'rojo', quantity: 1, category: { id: 1, description: 'Categoria'}},
    { id: 2, name: 'Cosa x', description: 'Mi descripcion', color: 'rojo', quantity: 1, category: { id: 1, description: 'Categoria'}},
    { id: 3, name: 'Cosa x', description: 'Mi descripcion', color: 'rojo', quantity: 1, category: { id: 1, description: 'Categoria'}},
    { id: 4, name: 'Cosa x', description: 'Mi descripcion', color: 'rojo', quantity: 1, category: { id: 1, description: 'Categoria'}},
  ];
  filteredThings: Observable<Thing[]> = this.formControl['thing'].valueChanges.pipe(
    startWith(''),
    map((val: string) => this._filterThing(val || ''))
  );
  selectedPerson?: Person;
  selectedThing?: Thing;

  constructor(private formBuilder: FormBuilder) {
    
  }

  get formControl() {
    return this.newLoanForm.controls;
  }

  ngOnInit(): void {
    this.formControl['owner'].valueChanges.subscribe((data: Person) => this._determinePerson(data));

    this.formControl['thing'].valueChanges.subscribe((data: Thing) => this._determineThing(data));


  }

  setStep(step: number): void {
    this.step = step;
  }

  nextStep(): void {
    if (!this.newLoanForm.valid) return;

    this.step++;
  }

  prevStep(): void {
    this.step--;
  }

  displayPerson(person: Person): string {
    if (!person) return '';
    return person && person.name ? `${person.lastname}, ${person.name}` : '';
  }

  displayThing(thing: Thing): string {
    if (!thing) return '';

    return thing && thing.name ? thing.name : '';
  }

  private _filterPerson(value: string): Person[] {
    let filterValue = '';

    if (typeof(value) == 'string'){
      filterValue = value.toLowerCase();
    } 

    return this.persons.filter(p => p.lastname.toLowerCase().includes(filterValue) || p.name.toLowerCase().includes(filterValue));
  }

  private _filterThing(value: string): Thing[] {
    let filterValue = '';

    if (typeof(value) == 'string'){
      filterValue = value.toLowerCase();
    } 

    return this.things.filter(t => t.name.toLowerCase().includes(filterValue));
  }

  private _determinePerson(data: Person) {
    if (typeof(data) === 'string'){
      this.selectedPerson = { name: '', email: '', lastname: '', phone: '' };
      return;
    }

    this.selectedPerson = data;
  }

  private _determineThing(data: Thing) {
    if (typeof(data) === 'string') {
      this.selectedThing = { name: '', description: '', color: '', quantity: 0, category: { description: ''}};
      return;
    }

    this.selectedThing = data;
  }
}
