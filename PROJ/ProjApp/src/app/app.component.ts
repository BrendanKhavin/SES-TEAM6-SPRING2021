import { BehaviorSubject } from 'rxjs';
import { IStudent } from 'src/models/student.model';
import { AuthService } from 'src/services/auth.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  isCollapsed = false;
  currentUser!: IStudent;
  isLoggedIn = false;
  

  constructor(private auth: AuthService, private router: Router) {
    this.getCurrentUser();
    this.auth.isUserLoggedIn.subscribe( 
      value => {
        this.isLoggedIn = value;
      }
    )
  }

  ngOnInit() {
    this.isLoggedIn = this.auth.isLoggedIn();
  }

  getCurrentUser() {
    this.auth.getCurrentUser().subscribe(
      (ret) => {
        this.currentUser = ret;
      }
    );
  }

  logout() {
    this.isLoggedIn = false;
    this.auth.logout();
    this.router.navigate(['homepage']);
  }
}
