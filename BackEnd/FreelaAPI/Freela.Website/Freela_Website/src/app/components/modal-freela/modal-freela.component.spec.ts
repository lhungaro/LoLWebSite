import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalFreelaComponent } from './modal-freela.component';

describe('ModalFreelaComponent', () => {
  let component: ModalFreelaComponent;
  let fixture: ComponentFixture<ModalFreelaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalFreelaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalFreelaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
