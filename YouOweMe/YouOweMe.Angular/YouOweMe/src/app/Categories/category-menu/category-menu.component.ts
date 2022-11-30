import { Component, OnInit, ViewChild } from '@angular/core';
import { Category } from 'src/app/Interfaces/category';
import { CategoriesListComponent } from '../categories-list/categories-list.component';
import { CategoryDetailComponent } from '../category-detail/category-detail.component';

@Component({
  selector: 'app-category-menu',
  templateUrl: './category-menu.component.html',
  styleUrls: ['./category-menu.component.css']
})
export class CategoryMenuComponent implements OnInit {

  displayCategoryList: boolean = true;
  displayCategoryDetail: boolean = false;
  @ViewChild(CategoriesListComponent) categoryList!: CategoriesListComponent;
  @ViewChild(CategoryDetailComponent) categoryDetail! : CategoryDetailComponent;

  constructor() { }

  ngOnInit(): void {
  }

  displayCategory(selectedCategory: Category): void {
    this.categoryDetail.displayCategory(selectedCategory);
  }

}
