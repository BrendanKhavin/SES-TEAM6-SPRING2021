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
    var content = {
      Id: '0000',
      UserId: '1234',
      SubjectId: subject,
      Score: score
    };
    return this.doPOST(content);
  }

  doPOST(cs: ICompletedSubjects) {
    console.log(cs);
    return this.http.post<ICompletedSubjects>('api/subject/addcompletedsubject', JSON.stringify(cs), httpOptions);
  }

}
