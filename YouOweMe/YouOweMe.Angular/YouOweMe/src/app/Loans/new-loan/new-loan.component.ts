import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';
import { Loan } from 'src/app/Interfaces/loan';
import { Person } from 'src/app/Interfaces/person';
import { Thing } from 'src/app/Interfaces/thing';
import { LoanService } from 'src/app/Services/Loan/loan.service';
import { PersonServiceService } from 'src/app/Services/Person/person.service';
import { ThingService } from 'src/app/Services/Things/thing.service';

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
    quantityBorrowed: ['', [Validators.required, Validators.min(1), Validators.max(100)]]
  });

  persons: Person[] = [];
  things : Thing[] = [];

  filteredPersons: Observable<Person[]> = this.formControl['owner'].valueChanges.pipe(
    startWith(''), 
    map((val: string) => this._filterPerson(val || ''))
  );
  filteredThings: Observable<Thing[]> = this.formControl['thing'].valueChanges.pipe(
    startWith(''),
    map((val: string) => this._filterThing(val || ''))
  );

  selectedPerson?: Person;
  selectedThing?: Thing;

  constructor(
    private formBuilder: FormBuilder,
    private personService: PersonServiceService,
    private thingService: ThingService,
    private loanService: LoanService) {
    
  }

  get formControl() {
    return this.newLoanForm.controls;
  }

  ngOnInit(): void {
    this.personService.personsList.subscribe((data: Person[]) => {
      this.persons = data;
    });

    this.thingService.thingsList.subscribe((data: Thing[]) => {
      this.things = data;
    });

    this.formControl['owner'].valueChanges.subscribe((data: Person) => this._determinePerson(data));

    this.formControl['thing'].valueChanges.subscribe((data: Thing) => this._determineThing(data));
  }

  setStep(step: number): void {
    this.step = step;
  }

  nextStep(): void {
    this.step++;

    if (this.step === 3)
      this.registerLoan();
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

  private registerLoan(): void {
    if (!this.selectedThing || !this.selectedPerson)
      return;

    let loan: Loan = {
      thing: this.selectedThing,
      person: this.selectedPerson,
      borrowedAmount: this.formControl['quantityBorrowed'].value
    };

    console.log(loan);
    this.loanService.saveNewLoan(loan);
  }
}
