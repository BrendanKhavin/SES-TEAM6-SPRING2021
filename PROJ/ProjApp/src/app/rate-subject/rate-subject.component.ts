import { Component, Input, OnInit } from '@angular/core';


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

  constructor() {
    this.sCode = "";
    this.sName = "";
  }

  ngOnInit(): void {
  }

  showPopup(): void {
    this.isPopupVisible = true;
  }

  /**
   * TODO: Save user rating to database.
   */
  onPopupOk(): void {
    this.isPopupVisible = false;
  }

  onPopupCancel(): void {
    this.isPopupVisible = false;
  }
}
