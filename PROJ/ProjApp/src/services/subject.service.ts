import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ISubject } from '../models/subject.model';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  constructor(private http: HttpClient) {}

  getAllSubjects(): Observable<ISubject[]> {
    return this.http.get<ISubject[]>('/api/subjects');
  }
}
