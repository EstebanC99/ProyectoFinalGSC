import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Category } from 'src/app/Interfaces/category';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private _categories: BehaviorSubject<Category[]> = new BehaviorSubject<Category[]>([]);
  public readonly categoriesList: Observable<Category[]> = this._categories.asObservable();

  constructor(private http: HttpClient) {
    this.getCategories();
  }

  getCategories(): void {
    this.http.get<Category[]>(`${environment.apiUrl}/Category/Categories`).subscribe((data: Category[]) => {
      this._categories.next(data);
    });
  }

  saveNewCategory(category: Category): void {
    console.log(JSON.stringify(category));
    this.http.post<Category>(`${environment.apiUrl}/Category/Add`, category).subscribe(() => this.refreshList());
  }

  updateCategory(category: Category): void {
    this.http.put<Category>(`${environment.apiUrl}/Category/Modify`, category).subscribe(() => this.refreshList());
  }

  deleteCategory(category: Category): void {
    this.http.delete(`${environment.apiUrl}/Category/Delete?ID=${category.id}`).subscribe(() => this.refreshList());
  }

  refreshList(): void {
    this.getCategories();
  }
}
