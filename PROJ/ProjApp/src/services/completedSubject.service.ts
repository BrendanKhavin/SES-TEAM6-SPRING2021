import { FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICompletedSubjects } from '../models/completedSubject.model';

const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
@Injectable({
  providedIn: 'root'
})
export class CompletedSubjectService {

  constructor(private http: HttpClient) { }

  addCompletedSubject(subject: string, score: number): Observable<Object> {
    var params = new HttpParams()
      .set("SubjectId", subject)
      .set("UserId", "1000")
      .set("Score", score.toString())

    var content = {
      SubjectId: subject,
      UserId: '1234',
      Score: score
    };
    return this.doPOST(content, params);
  }

  doPOST(cs: ICompletedSubjects, params: HttpParams) {
    console.log(cs);
    // return this.http.post<ICompletedSubjects>('api/subject/addcompletedsubject', JSON.stringify(cs), httpOptions);
    return this.http.post('api/completedsubjects/addUserSubject', JSON.stringify(cs), {
      'headers': new HttpHeaders({ 'Content-Type': 'application/json' }),
      'params': params
    });
  }

}
