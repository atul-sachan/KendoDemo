import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KendoGridExampleComponent } from './kendo-grid-example.component';

describe('KendoGridExampleComponent', () => {
  let component: KendoGridExampleComponent;
  let fixture: ComponentFixture<KendoGridExampleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KendoGridExampleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KendoGridExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
