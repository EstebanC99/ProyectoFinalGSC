import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Category } from 'src/app/Interfaces/category';
import { CategoryService } from 'src/app/Services/Category/category.service';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {
  dataSource = new MatTableDataSource<Category>([]);
  displayedColumns: string[] = ['id', 'description'];
  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;
  @Output() selectedCategory = new EventEmitter<Category>();
  @Output() displayed: EventEmitter<boolean> = new EventEmitter(true);

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categoryService.categoriesList.subscribe((data: Category[]) => {
      this.dataSource.data = data;
    });
    this.dataSource.paginator = this.paginator;
    this.displayed.emit(true);
  }

  selectCategory(category: Category): void {
    if (category == null) return;

    this.selectedCategory.emit(category);

    this.displayed.emit(false);
  }
}
