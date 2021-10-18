import { Component, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { ISubject } from '../../models/subject.model';
import { SubjectService } from '../../services/subject.service';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.less']
})

export class RecommendationComponent implements OnInit {
  faculties = ['Engineering', 'Law', 'Medicine', 'Science', 'Architecture', 'Design'];
  selectedFaculties = [];
  creditPoints = [3, 6, 9, 12, 18, 24];
  selectedCreditPoints = [];
  loading = true;
  searchValue = '';
  cards: ISubject[] = [];

  constructor(private subjectService: SubjectService) {
  }

  showModal(card: { isVisible: boolean; }): void {
    card.isVisible = true;
  }

  handleOk(card: { isVisible: boolean; }): void {
    card.isVisible = false;
  }

  handleCancel(card: { isVisible: boolean; }): void {
    card.isVisible = false;
  }

  handleRate(card: { id: any; }): void {
    //will have it redirect to the ratings page
  }

  ngOnInit(): void {
    this.subjectService.getAllSubjects().subscribe(arr => {
      this.cards = arr;
    });
  }
}

