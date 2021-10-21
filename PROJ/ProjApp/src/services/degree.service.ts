import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDegree } from './../models/degree.model';

@Injectable({
  providedIn: 'root'
})
export class DegreeService {

  constructor(private http: HttpClient) {}

  getAllDegrees(): Observable<IDegree[]> {
    return this.http.get<IDegree[]>('/api/degrees');
  }
}
