import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { IStudent } from 'src/models/student.model';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { TouchSequence } from 'selenium-webdriver';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userSubject: BehaviorSubject<IStudent>;
  public user: Observable<IStudent>;
  public isUserLoggedIn: BehaviorSubject<boolean>  = new BehaviorSubject<boolean>(false);

  constructor(private router: Router, private http: HttpClient) {
    this.userSubject = new BehaviorSubject<IStudent>(JSON.parse(localStorage.getItem('user')!));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): IStudent {
    return this.userSubject.value;
  }

  login(formValues: FormGroup) {
    const body = {
      email: formValues.value.email,
      password: formValues.value.password,
    }
    return this.sendLogin(body);
  }

  private sendLogin(body: any) {
    return this.http.post<IStudent>('/api/account/login', JSON.stringify(body), httpOptions)
      .pipe(map(user => {
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject.next(user);
        this.isUserLoggedIn.next(true);
        return user;
      }))
  }

  isLoggedIn() {
    return !!localStorage.getItem('user');
  }

  getCurrentUser() {
    return this.user;
  }

  logout() {
    localStorage.removeItem('user');
    this.userSubject.next(null!);
  }
}
