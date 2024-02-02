import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreelaItemComponent } from './freela-item.component';

describe('FreelaItemComponent', () => {
  let component: FreelaItemComponent;
  let fixture: ComponentFixture<FreelaItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FreelaItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FreelaItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
