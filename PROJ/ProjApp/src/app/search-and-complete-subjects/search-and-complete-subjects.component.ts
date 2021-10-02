import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search-and-complete-subjects',
  templateUrl: './search-and-complete-subjects.component.html',
  styleUrls: ['./search-and-complete-subjects.component.less']
})
export class SearchAndCompleteSubjectsComponent implements OnInit {

  searchController = new SearchController();
  searchText = "";

  constructor() { }

  ngOnInit(): void {
  }

  searchSubjects(): void {
    this.searchController.search(this.searchText);
  }
}

class SearchController {
  subjects = new Array();
  results = new Array();

  constructor() {
    this.subjects.push({ code: "41095", name: "Software Engineering Studio 2A" });
    this.subjects.push({ code: "41096", name: "Software Engineering Studio 2B" });
  }

  search(s: string): void {
    this.results = new Array();
    this.subjects.forEach(subject => {
      if (subject.code.includes(s) || subject.name.includes(s)) {
        this.results.push(subject);
      }
    });
  }
}
