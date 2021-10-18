import { FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  registered = false;
  firstName: string | undefined;
  lastName: string | undefined;
  studentId: string | undefined;
  email: string | undefined;
  password: string | undefined;
  loginSuccessful = false;

  constructor(private http: HttpClient) { }

  // POST register(formBody)
  register(formValues: FormGroup): Observable<Object> {
    const body = {
      firstName: formValues.value.firstName,
      lastName: formValues.value.lastName,
      studentId: formValues.value.studentId,
      email: formValues.value.email,
      password: formValues.value.password,
    }
    this.registered = true
    return this.sendRegistration(body);
  }

  private sendRegistration(body: any) {
    return this.http.post('/api/user/create', JSON.stringify(body), httpOptions);
  }

}
