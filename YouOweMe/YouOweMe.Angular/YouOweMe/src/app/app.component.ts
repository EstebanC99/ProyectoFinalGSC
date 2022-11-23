import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';
import { User } from './user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  currentUser!: User;
  title = 'YouOweMe';

  constructor(
    private router: Router,
    private authService: AuthService){
      this.authService.currentUser.subscribe(x => this.currentUser = x);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
