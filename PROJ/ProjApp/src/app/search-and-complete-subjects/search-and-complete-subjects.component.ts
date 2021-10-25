import { Component, OnInit } from '@angular/core';
import { ISubject } from '../../models/subject.model';
import { SubjectService } from '../../services/subject.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-search-and-complete-subjects',
  templateUrl: './search-and-complete-subjects.component.html',
  styleUrls: ['./search-and-complete-subjects.component.less']
})
export class SearchAndCompleteSubjectsComponent implements OnInit {

  searchController = new SearchController(this.subjectService);
  searchText = "";

  constructor(private subjectService: SubjectService, private authService: AuthService) {
    console.log(authService.userValue.studentId);
  }

  ngOnInit(): void {
  }

  searchSubjects(): void {
    this.searchController.search(this.searchText);
  }
}

class SearchController {
  MAX_RESULTS = 7;

  subjects = new Array();
  results = new Array();

  constructor(private subjectService: SubjectService) {
    // this.subjects.push({ code: "41095", name: "Software Engineering Studio 2A" });
    // this.subjects.push({ code: "41096", name: "Software Engineering Studio 2B" });

    this.subjectService.getAllSubjects().subscribe(subjects => {
      subjects.map(s => {
        this.subjects.push({
          code: s.subjectCode,
          name: s.subjectName
        });
      });
    });
  }

  search(s: string): void {
    this.results = new Array();
    this.subjects.forEach(subject => {
      if (this.results.length < this.MAX_RESULTS && (subject.code.includes(s) || subject.name.includes(s))) {
        this.results.push(subject);
      }
    });
  }
}
