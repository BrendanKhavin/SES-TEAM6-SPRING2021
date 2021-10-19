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

  /**
   * TODO: Ret is always false.
   */
  onPopupOk(): void {
    this.csService.addCompletedSubject(this.sCode, this.userRating).subscribe(
      (ret) => {
        if (ret === true) {
          this.notification.create(
            'success',
            'Save Success',
            'Subject added.'
          );
        } else {
          this.notification.create(
            'error',
            'Save Failed',
            'An error occured. Please try again. #02'
          );
        }
      },
      (err) => {
        this.notification.create(
          'error',
          'Save Failed',
          'An error occured. Please try again. #03'
        );
        console.error(err);
      }
    );
    this.isPopupVisible = false;
  }

  onPopupCancel(): void {
    this.isPopupVisible = false;
  }
}
