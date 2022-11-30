import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject, Observable } from 'rxjs';
import { Category } from 'src/app/Interfaces/category';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private _categories: BehaviorSubject<Category[]> = new BehaviorSubject<Category[]>([]);
  public readonly categoriesList: Observable<Category[]> = this._categories.asObservable();

  constructor(private http: HttpClient, private notification: MatSnackBar) {
    this.getCategories();
  }

  getCategories(): void {
    this.http.get<Category[]>(`${environment.apiUrl}/Category/Categories`).subscribe(
      (data: Category[]) => { this._categories.next(data); }
    );
  }

  saveNewCategory(category: Category): void {
    this.http.post<Category>(`${environment.apiUrl}/Category/Add`, category).subscribe({ 
      complete: () => {
        this.refreshList(); 
        this.notification.open("Categoria agregada con exito!", "Aceptar", {verticalPosition: "bottom"});
      } 
    });
  }

  updateCategory(category: Category): void {
    this.http.put<Category>(`${environment.apiUrl}/Category/Modify`, category).subscribe({
      complete: () => {
        this.refreshList();
        this.notification.open("Categoria modificada con exito!", "Aceptar", {verticalPosition: "bottom"});
      }
    });
  }

  deleteCategory(category: Category): void {
    this.http.delete(`${environment.apiUrl}/Category/Delete?ID=${category.id}`).subscribe({
      complete: () => {
        this.refreshList();
        this.notification.open("Categoria eliminada con exito!", "Aceptar", {verticalPosition: "bottom"});
      }
    });
  }

  refreshList(): void {
    this.getCategories();
  }
}
