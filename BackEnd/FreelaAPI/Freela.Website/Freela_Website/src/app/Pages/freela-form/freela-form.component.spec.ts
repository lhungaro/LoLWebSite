import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FreelaFormComponent } from './freela-form.component';

describe('FreelaFormComponent', () => {
  let component: FreelaFormComponent;
  let fixture: ComponentFixture<FreelaFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FreelaFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FreelaFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
