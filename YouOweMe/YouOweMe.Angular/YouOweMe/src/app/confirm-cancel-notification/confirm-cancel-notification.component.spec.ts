import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmCancelNotificationComponent } from './confirm-cancel-notification.component';

describe('ConfirmCancelNotificationComponent', () => {
  let component: ConfirmCancelNotificationComponent;
  let fixture: ComponentFixture<ConfirmCancelNotificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfirmCancelNotificationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfirmCancelNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
