import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchAndCompleteSubjectsComponent } from './search-and-complete-subjects.component';

describe('SearchAndCompleteSubjectsComponent', () => {
  let component: SearchAndCompleteSubjectsComponent;
  let fixture: ComponentFixture<SearchAndCompleteSubjectsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchAndCompleteSubjectsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchAndCompleteSubjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
