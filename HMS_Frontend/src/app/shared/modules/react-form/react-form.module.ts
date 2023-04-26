import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ReactFormRoutingModule } from './react-form-routing.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ReactFormRoutingModule
  ],
  exports: [ReactiveFormsModule]
})
export class ReactFormModule { }
