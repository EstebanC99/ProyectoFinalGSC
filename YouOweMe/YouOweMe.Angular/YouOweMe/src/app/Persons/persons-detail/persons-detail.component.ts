import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmCancelNotificationComponent } from '../../confirm-cancel-notification/confirm-cancel-notification.component';
import { Person } from '../../Interfaces/person';
import { PersonServiceService } from '../../Services/Person/person.service';

@Component({
  selector: 'app-persons-detail',
  templateUrl: './persons-detail.component.html',
  styleUrls: ['./persons-detail.component.css']
})
export class PersonsDetailComponent implements OnInit {

  expanded: boolean = false;
  personDetailForm!: FormGroup;
  @ViewChild(FormGroupDirective) formGroupDirective!: FormGroupDirective;
  @Output() displayed: EventEmitter<boolean> = new EventEmitter(false);

  constructor(
    private formBuilder: FormBuilder,
    private personService: PersonServiceService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.personDetailForm = this.formBuilder.group({
      id: [""],
      name: ["", [Validators.required]],
      lastname: ["", [Validators.required]],
      email: ["", [Validators.email]],
      phone: ["", [Validators.pattern("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$")]]
    })
  }

  get formControl() {
    return this.personDetailForm.controls;
  }

  save(): void {
    if (!this.personDetailForm.valid) return;

    let person: Person = this.mapPerson();

    if (!person.id){
      this.personService.saveNewPerson(person);
    } else {
      this.personService.updatePerson(person);
    }

    this.cancel();
  }

  cancel(): void {
    this.formGroupDirective.resetForm();
    this.personDetailForm.reset();
    
    this.displayed.emit(false);
  }

  delete(): void {
    let person: Person = this.mapPerson();

    this.dialog.open(ConfirmCancelNotificationComponent, {
      data: {
        message: `¿Seguro desea eliminar a ${person.name} ${person.lastname}?`,
      }
    }).afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.personService.deletePerson(person);
      } else {
        this.cancel();
      }
    });
  }

  displayPerson(selectedPerson: Person): void {
    this.formControl['id'].setValue(selectedPerson.id);
    this.formControl['name'].setValue(selectedPerson.name);
    this.formControl['lastname'].setValue(selectedPerson.lastname);
    this.formControl['email'].setValue(selectedPerson.email);
    this.formControl['phone'].setValue(selectedPerson.phone);
    this.displayed.emit(true);
  }

  mapPerson(): Person{
    let id: number = this.formControl['id'].value;
    
    let person: Person = {
      id: !id ? 0 : id,
      name: this.formControl['name'].value,
      lastname: this.formControl['lastname'].value,
      email: this.formControl['email'].value,
      phone: this.formControl['phone'].value
    };

    return person;
  }
}
