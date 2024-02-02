import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreelaListComponent } from './freela-list.component';

describe('FreelaListComponent', () => {
  let component: FreelaListComponent;
  let fixture: ComponentFixture<FreelaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FreelaListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FreelaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
