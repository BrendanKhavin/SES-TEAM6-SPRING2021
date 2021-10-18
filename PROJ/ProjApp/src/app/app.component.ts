import { IStudent } from 'src/models/student.model';
import { AuthService } from 'src/services/auth.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  isCollapsed = false;
  currentUser!: IStudent;
  isLoggedIn = false;

  constructor(private auth: AuthService) {
    this.getCurrentUser();
    this.isLoggedIn = this.auth.isLoggedIn();
  }
  
  getCurrentUser() {
    this.auth.getCurrentUser().subscribe(
      (ret) => {
        this.currentUser = ret;
      }
    );
  }
}
