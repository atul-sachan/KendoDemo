import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { toODataString } from '@progress/kendo-data-query';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators/map';

export abstract class DataService {
  private BASE_URL = 'http://localhost:5000/odata/';

  constructor(
    private http: HttpClient,
    protected tableName: string
  ) {
  }

  public fetch(state: any): Observable<GridDataResult> {
    const queryStr = `${toODataString(state)}&$count=true`;

    return this.http
      // tslint:disable-next-line:max-line-length
      .get(`${this.BASE_URL}${this.tableName}?${queryStr}`, { 'headers': new HttpHeaders({ 'id': localStorage.getItem('id') }), observe: 'response' })
      .pipe(
        map(response => {
          const gridData = response.body['value'];
          // gridData.map((val, index) => val.RowId = index);
          localStorage.setItem('index', response.headers.get('X-Total-Count'));
          return (<GridDataResult>{
            data: gridData,
            total: parseInt(response.body['@odata.count'], 10)
          });
        })
      );
  }
}



@Injectable({
  providedIn: 'root'
})
export class KendoGridServiceService extends DataService {

  constructor(http: HttpClient) { super(http, 'Kendo'); }
}
