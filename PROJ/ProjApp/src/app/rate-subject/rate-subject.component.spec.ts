import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RateSubjectComponent } from './rate-subject.component';

describe('RateSubjectComponent', () => {
  let component: RateSubjectComponent;
  let fixture: ComponentFixture<RateSubjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RateSubjectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RateSubjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
