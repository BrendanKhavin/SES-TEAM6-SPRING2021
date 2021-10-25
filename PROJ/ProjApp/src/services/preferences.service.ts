import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStudentPreferences } from 'src/models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentPreferencesService {

  constructor(private http: HttpClient) {}

  getStudentPreferences(studentId: string): Observable<IStudentPreferences> {
    return this.http.get<IStudentPreferences>('/api/UserPreferences/' + studentId);
  }
}
