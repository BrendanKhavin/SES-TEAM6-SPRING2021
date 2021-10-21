import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InterestService {

  constructor(private http: HttpClient) {}

  getAllInterests(): Observable<string[]> {
    return this.http.get<string[]>('/api/interests');
  }
}
