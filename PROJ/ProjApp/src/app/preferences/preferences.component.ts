import { Component, OnInit } from '@angular/core';

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
  radioValue = "A";
  experienceLevel = null;
  listOfOption: Array<{ label: string; value: string }> = [];
  listOfTagOptions = [];

  constructor() { }

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
  }

}

