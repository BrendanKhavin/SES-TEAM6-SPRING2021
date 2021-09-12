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

  constructor() { }

  ngOnInit(): void {
  }

}

