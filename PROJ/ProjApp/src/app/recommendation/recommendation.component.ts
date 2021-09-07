import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.less']
})
export class RecommendationComponent implements OnInit {
  faculties = ['Engineering','Law','Medicine','Science','Architecture','Design'];
  selectedFaculties = [];
  creditPoints = [3,6,9,12,18,24];
  selectedCreditPoints = [];
  loading = true;
  searchValue = '';
  cards = [
    {title: "Test 1", content:"Test Content"},
    {title: "Test 2", content: "Test Content"},
    {title: "Test 3", content: "Test Content"}
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
