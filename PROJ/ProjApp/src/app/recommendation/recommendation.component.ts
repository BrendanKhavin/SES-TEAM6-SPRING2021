import { Component, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { IStudent } from '../../models/student.model';
import { ISubject } from '../../models/subject.model';
import { AuthService } from '../../services/auth.service';
import { SubjectService } from '../../services/subject.service';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.less']
})

export class RecommendationComponent implements OnInit {
  faculties = ['Engineering', 'IT'];
  selectedFaculty = "";
  creditPoints = [2, 3, 6, 9, 12, 18, 24];
  selectedCreditPoint = 0;
  loading = true;
  searchValue = '';
  cards: ISubject[] = [];
  cardsCurrent: ISubject[] = [];
  currentUser!: IStudent;

  constructor(private subjectService: SubjectService, private authService: AuthService) {
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

  updateFilter() {
    if (!this.selectedFaculty && !this.selectedCreditPoint)
    {
      this.cardsCurrent = this.cards;
    }
    else if (!this.selectedFaculty) {
      this.cardsCurrent = this.cards.filter(card => card.creditPoints == this.selectedCreditPoint)
    }
    else if (!this.selectedCreditPoint) {
      this.cardsCurrent = this.cards.filter(card => card.courseArea == this.selectedFaculty)
    }
    else {
      this.cardsCurrent = this.cards.filter(card => card.creditPoints == this.selectedCreditPoint)
      this.cardsCurrent = this.cardsCurrent.filter(card => card.courseArea == this.selectedFaculty)
    }
  }

  getCurrentUser() {
    this.authService.getCurrentUser().subscribe(
      (ret) => {
        this.currentUser = ret;
      }
    );
  }

  ngOnInit(): void {
    this.getCurrentUser();
    this.subjectService.getRecommendedSubjects(this.currentUser.studentId).subscribe(arr => {
      this.cards = arr;
      this.cardsCurrent = arr;
    });
  }
}

