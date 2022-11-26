import { Output, EventEmitter } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Person } from '../Interfaces/person';
import { PersonServiceService } from '../Services/Person/person.service';

@Component({
  selector: 'app-persons-detail',
  templateUrl: './persons-detail.component.html',
  styleUrls: ['./persons-detail.component.css']
})
export class PersonsDetailComponent implements OnInit {

  personDetailForm!: FormGroup;

  @Output() personaAgregada = new EventEmitter<boolean>();

  constructor(
    private formBuilder: FormBuilder,
    private personService: PersonServiceService) { }

  ngOnInit(): void {
    this.personDetailForm = this.formBuilder.group({
      name: ["", [Validators.required]],
      lastname: ["", [Validators.required]],
      email: ["", [Validators.email]],
      phone: ["", [Validators.pattern("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$")]]
    })
  }

  get formControl() {
    return this.personDetailForm.controls;
  }

  guardar(): void {
    let newPerson: Person = {
      name: this.formControl['name'].value,
      lastname: this.formControl['lastname'].value,
      email: this.formControl['email'].value,
      phone: this.formControl['phone'].value
    };

    this.personService.SaveNewPerson(newPerson);

    this.personaAgregada.emit(true);
  }
}
