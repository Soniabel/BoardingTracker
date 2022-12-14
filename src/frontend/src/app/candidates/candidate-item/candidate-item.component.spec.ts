import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateItemComponent } from './candidate-item.component';

describe('CandidateItemComponent', () => {
  let component: CandidateItemComponent;
  let fixture: ComponentFixture<CandidateItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CandidateItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CandidateItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
