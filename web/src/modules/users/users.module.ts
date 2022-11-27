import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersTableComponent } from './components/users-table/users-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';

@NgModule({
  declarations: [
    UsersTableComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule
  ],
  exports: [
    UsersTableComponent
  ]
})
export class UsersModule { }
