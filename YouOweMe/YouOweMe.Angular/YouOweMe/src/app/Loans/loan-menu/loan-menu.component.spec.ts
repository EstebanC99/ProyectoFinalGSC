import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanMenuComponent } from './loan-menu.component';

describe('LoanMenuComponent', () => {
  let component: LoanMenuComponent;
  let fixture: ComponentFixture<LoanMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoanMenuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoanMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
