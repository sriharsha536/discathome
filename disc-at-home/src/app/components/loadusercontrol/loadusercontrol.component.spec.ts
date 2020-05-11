import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoadusercontrolComponent } from './loadusercontrol.component';

describe('LoadusercontrolComponent', () => {
  let component: LoadusercontrolComponent;
  let fixture: ComponentFixture<LoadusercontrolComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoadusercontrolComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoadusercontrolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
