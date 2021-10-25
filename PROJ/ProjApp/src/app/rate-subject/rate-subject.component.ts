import { Component, Input, OnInit } from '@angular/core';
import { CompletedSubjectService } from '../../services/completedSubject.service';
import { NzNotificationService } from 'ng-zorro-antd/notification';


@Component({
  selector: 'app-rate-subject',
  templateUrl: './rate-subject.component.html',
  styleUrls: ['./rate-subject.component.less']
})

export class RateSubjectComponent implements OnInit {

  @Input() sCode: string;
  @Input() sName: string;

  isPopupVisible = false;
  userRating = 0;

  constructor(private csService: CompletedSubjectService, private notification: NzNotificationService) {
    this.sCode = "";
    this.sName = "";
  }

  ngOnInit(): void {
  }

  showPopup(): void {
    this.isPopupVisible = true;
  }

  onPopupOk(): void {
    this.csService.addCompletedSubject(this.sCode, this.userRating).subscribe(
      (ret) => {
        this.notification.create(
          'success',
          'Success',
          'User rating has been saved.'
        );

        /**
         * THIS IS A LAZY APPROACH
         * 
        if (ret) {
          this.notification.create(
            'success',
            'Success',
            'User rating has been saved.'
          );
        } else {
          this.notification.create(
            'error',
            'Error',
            'User rating was not saved.'
          );
        }
         */
      },
      (err) => {
        this.notification.create(
          'error',
          'Error',
          'User rating could not be saved. Please contact site administrator.'
        );
      }
    );
    this.isPopupVisible = false;
  }

  onPopupCancel(): void {
    this.isPopupVisible = false;
  }
}
