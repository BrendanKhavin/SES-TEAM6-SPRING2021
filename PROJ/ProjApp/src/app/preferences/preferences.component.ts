import { Component, OnInit } from '@angular/core';
import { IDegree } from '../../models/degree.model';
import { DegreeService } from 'src/services/degree.service';
import { SubjectService } from 'src/services/subject.service';

@Component({
  selector: 'app-preferences',
  templateUrl: './preferences.component.html',
  styleUrls: ['./preferences.component.less']
})
export class PreferencesComponent implements OnInit {
  faculties = ['Engineering','Law','Medicine','Science','Architecture','Design'];
  selectedFaculties = [];
  creditPoints = [3,6,9,12,18,24];
  selectedCreditPoints = [];
  completedSubjects = [
  'Software Engineering Studio 1A', 'Software Engineering Studio 1B', 
  'Software Engineering Studio 2A','Applications Programming'];
  selectedCompletedSubjects = [];
  studentType = "domestic";
  groupworkValue = "individual";
  assessmentPreference = [
    { label: 'Exams', value: 'Exams', checked: true },
    { label: 'Assignments', value: 'Assignments', checked: true },
    { label: 'Presentations', value: 'Presentations', checked: true },
    { label: 'Essays', value: 'Essays', checked: true }
  ];
  degrees: IDegree[] = [];
  listOfOption: Array<{ label: string; value: string }> = [];
  listOfTagOptions = [];
  log(value: object[]): void {
    console.log(value);
  }

  constructor(private subjectService: SubjectService, private degreeService: DegreeService) { }

  ngOnInit(): void {
    const children: Array<{ label: string; value: string }> = [
      {label: 'art', value: 'art'},
      {label: 'code', value: 'code'},
      {label: 'design', value: 'design'},
      {label: 'economics', value: 'economics'},
      {label: 'finance', value: 'finance'},
      {label: 'innovation', value: 'innovation'},
      {label: 'python', value: 'python'}
    ];
    this.listOfOption = children;
    this.degreeService.getAllDegrees().subscribe(degrees => this.degrees = degrees);
    }
}

