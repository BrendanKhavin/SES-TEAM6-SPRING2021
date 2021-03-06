import { FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICompletedSubjects } from '../models/completedSubject.model';
import { AuthService } from '../services/auth.service';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
@Injectable({
  providedIn: 'root'
})
export class CompletedSubjectService {

  constructor(private http: HttpClient, private authService: AuthService) { }

  addCompletedSubject(subject: string, score: number): Observable<Object> {
    var params = new HttpParams()
      .set("SubjectId", subject)
      .set("UserId", this.authService.userValue.studentId.toString())
      .set("Score", score.toString())

    var content = {
      SubjectId: subject,
      UserId: '1234',
      Score: score
    };
    return this.doPOST(content, params);
  }

  doPOST(cs: ICompletedSubjects, params: HttpParams): Observable<Object> {
    return this.http.post('api/completedsubjects/addUserSubject', JSON.stringify(cs), {
      'headers': new HttpHeaders({ 'Content-Type': 'application/json' }),
      'params': params
    });
  }

}
