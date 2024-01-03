import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule, NgTemplateOutlet } from '@angular/common';
import { ModalComponent,PreviewComponent,PageHeaderComponent,ToastsComponent, TableComponent, PageComponent, TabsComponent } from './components';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { DDatePipe } from './pipes';

@NgModule({
  declarations: [
    PageHeaderComponent,
    ModalComponent,
    PreviewComponent,
    ToastsComponent,
    PageComponent,
    TableComponent,
    TabsComponent,
    DDatePipe,
  ],
  imports: [
    CommonModule,
    FormsModule,
    NgbToastModule, 
    NgTemplateOutlet,
    NgxDatatableModule
  ], 
  exports: [
    PageHeaderComponent,
    ModalComponent,
    PreviewComponent,
    ToastsComponent,
    PageComponent,
    TableComponent,
    TabsComponent,
    // DDatePipe
  ]
})
export class ComponentsModule { }
