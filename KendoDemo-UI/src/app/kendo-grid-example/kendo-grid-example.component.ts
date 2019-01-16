import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { GridComponent, PageChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { KendoGridServiceService } from './kendo-grid-service.service';
import { tap, switchMap } from 'rxjs/operators';
import { SortDescriptor } from '@progress/kendo-data-query';

@Component({
  selector: 'app-kendo-grid-example',
  templateUrl: './kendo-grid-example.component.html',
  styleUrls: ['./kendo-grid-example.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class KendoGridExampleComponent implements OnInit {
  public loading: boolean;
  @ViewChild('grid') private grid: GridComponent;
  public mySelection: number[] = [];

  public state: any = {
    skip: 0,
    take: 100,
    sort: [{
      field: 'Id',
      dir: 'asc'
    }]
  };

  public query: any;
  private stateChange = new BehaviorSubject<any>(this.state);

  constructor(private service: KendoGridServiceService) { }

  ngOnInit() {
    this.query = this.stateChange.pipe(
      tap(state => {
        this.state = state;
        this.loading = true;
      }),
      switchMap(state => this.service.fetch(state)),
      tap(() => {
        // this.rowPersistance();
        this.loading = false;
      })
    );
  }

  public pageChange(state: PageChangeEvent): void {
    this.state.take = state.take;
    this.state.skip = state.skip;
    this.stateChange.next(this.state);
  }

  public sortChange(sort: SortDescriptor[]): void {
    const sorts = sort.filter(e => {
      if (e.dir === undefined) {
        e.dir = 'asc';
      }
      return e;
    });
    this.state.sort = sorts;
    this.stateChange.next(this.state);
  }

  public onSelectedKeysChange(e) { }

  public onSelectedChange(state: SelectionEvent) {
    localStorage.setItem('id', state.selectedRows[0].dataItem.Id);
  }
  public met() {
    this.mySelection = [];
    this.mySelection.push(151);
    setTimeout(() => {
      document.querySelector('.k-state-selected').scrollIntoView();
    }, 3000);

  }

  public manualselect() {
    this.mySelection = [];
    this.mySelection.push(351);
    this.state.skip = 300;
    this.stateChange.next(this.state);
    setTimeout(() => {
      document.querySelector('.k-state-selected').scrollIntoView();
    }, 3000);
  }

  select() {
    this.rowPersistance();
    // 5e02fac8-dbec-4f4a-9a33-ba48f8d2c9f1
  }

  public rowPersistance(): void {
    if (localStorage.getItem('index')) {

      const currentPage = (this.state.skip / 100);
      // tslint:disable-next-line:radix
      const persistancePage = Math.floor(parseInt(localStorage.getItem('index')) / 100);
      setTimeout(() => {
        this.mySelection = [];
        // tslint:disable-next-line:radix
        this.mySelection.push(parseInt(localStorage.getItem('id')));
        if (currentPage === persistancePage) {

          console.log(document.querySelector('.k-state-selected'));
          document.querySelector('.k-state-selected').scrollIntoView();
        } else {
          // tslint:disable-next-line:radix
          this.state.skip = parseInt(localStorage.getItem('index')) - 1;
          this.stateChange.next(this.state);
        }
      }, 4000);
    }
  }

}
