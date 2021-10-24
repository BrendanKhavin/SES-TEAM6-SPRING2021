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
  faculties = ['Engineering', 'Law', 'Medicine', 'Science', 'Architecture', 'Design'];
  selectedFaculties = [];
  creditPoints = [3, 6, 9, 12, 18, 24];
  selectedCreditPoints = [];
  loading = true;
  searchValue = '';
  cards: ISubject[] = [];
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

  handleRate(card: { id: any; }): void {
      //will have it redirect to the ratings page
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
    console.log(this.currentUser.studentId)
    this.subjectService.getRecommendedSubjects("10000003").subscribe(arr => {
      this.cards = arr;
    });
  }
}

