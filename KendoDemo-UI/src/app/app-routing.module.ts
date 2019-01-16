import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { KendoGridExampleComponent } from './kendo-grid-example/kendo-grid-example.component';

const routes: Routes = [
  { path: '', component: KendoGridExampleComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
