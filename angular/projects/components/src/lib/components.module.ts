import {  ModuleWithProviders, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule, NgTemplateOutlet } from '@angular/common';
import { ModalComponent,PreviewComponent,PageHeaderComponent,ToastsComponent, TableComponent, PageComponent, TabsComponent } from './components';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { DDatePipe } from './pipes';
import styles from './constants/styles';



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
  ],
  providers:[]
}) 

export class ComponentsModule { 
  
  static forRoot(): ModuleWithProviders<ComponentsModule> {
    const stylesElement = document.createElement('style');
    var oText=document.createTextNode(styles);
    stylesElement.appendChild(oText)
    document.body.appendChild(stylesElement);
    return {
      ngModule: ComponentsModule,
      providers: [],
    };
  }
}
