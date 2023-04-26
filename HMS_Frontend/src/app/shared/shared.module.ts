import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ErrorModalComponent } from './modals/error-modal/error-modal.component';

@NgModule({
  declarations: [
    ErrorModalComponent
  ],
  imports: [
    CommonModule,
    ModalModule.forRoot()
  ],
  exports: [
    ErrorModalComponent
  ]
})
export class SharedModule { }
