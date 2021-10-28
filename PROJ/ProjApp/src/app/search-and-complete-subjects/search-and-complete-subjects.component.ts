import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../../services/subject.service';
import { CompletedSubjectService } from '../../services/completedSubject.service';

@Component({
  selector: 'app-search-and-complete-subjects',
  templateUrl: './search-and-complete-subjects.component.html',
  styleUrls: ['./search-and-complete-subjects.component.less']
})
export class SearchAndCompleteSubjectsComponent implements OnInit {

  searchController = new SearchController(this.subjectService, this.csService);
  searchText = "";

  constructor(private subjectService: SubjectService, private csService: CompletedSubjectService) { }

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

  constructor(private subjectService: SubjectService, private csService: CompletedSubjectService) {
    var completedSubjects = new Set();

    this.csService.getCompletedSubjectsByUserID().subscribe(subjects => {
      subjects.map((subject, index) => {
        completedSubjects.add(subject.subjectCode);
      });

      // GET subjects in database and remove ones the user has
      // completed before.
      this.subjectService.getAllSubjects().subscribe(subjects => {
        subjects.map(s => {
          if (!completedSubjects.has(s.subjectCode)) {
            this.subjects.push({
              code: s.subjectCode,
              name: s.subjectName
            });
          }
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
