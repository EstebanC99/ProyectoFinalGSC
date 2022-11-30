import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmCancelNotificationComponent } from 'src/app/confirm-cancel-notification/confirm-cancel-notification.component';
import { Category } from 'src/app/Interfaces/category';
import { CategoryService } from 'src/app/Services/Category/category.service';

@Component({
  selector: 'app-category-detail',
  templateUrl: './category-detail.component.html',
  styleUrls: ['./category-detail.component.css']
})
export class CategoryDetailComponent implements OnInit {

  categoryDetailForm!: FormGroup;
  @ViewChild(FormGroupDirective) formGroupDirective!: FormGroupDirective;
  @Output() displayed : EventEmitter<boolean> = new EventEmitter(false);

  constructor(
    private formBuilder: FormBuilder,
    private categoryService: CategoryService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.categoryDetailForm = this.formBuilder.group({
      id: [''],
      description: ['', [Validators.required]]
    });
  }

  get formControl() {
    return this.categoryDetailForm.controls;
  }

  save(): void {
    if (!this.categoryDetailForm.valid) return;

    let category: Category = this.mapCategory();

    if (!category.id){
      this.categoryService.saveNewCategory(category);
    } else {
      this.categoryService.updateCategory(category);
    }

    this.cancel();
  }

  cancel(): void {
    this.formGroupDirective.resetForm();
    this.categoryDetailForm.reset();

    this.displayed.emit(false);
  }

  delete(): void {
    let category: Category = this.mapCategory();

    this.dialog.open(ConfirmCancelNotificationComponent, {
      data: {
        message: `¿Seguro desea eliminar la categoria ${category.description}?`
      }
    }).afterClosed().subscribe((confirmed: boolean) => {
      if (confirmed) {
        this.categoryService.deleteCategory(category);
      } else {
        this.cancel();
      }
    });
  }

  displayCategory(selectedCategory: Category): void {
    this.formControl['id'].setValue(selectedCategory.id);
    this.formControl['description'].setValue(selectedCategory.description);

    this.displayed.emit(true);
  }

  mapCategory(): Category {
    let id: number = this.formControl['id'].value;

    let category: Category = {
      id: !id ? 0 : id,
      description: this.formControl['description'].value
    };

    return category;
  }

}
