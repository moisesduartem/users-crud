import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { HttpClientModule } from '@angular/common/http';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { UsersTableComponent } from './components/users-table/users-table.component';
import { UserDeletionDialogComponent } from './components/user-deletion-dialog/user-deletion-dialog.component';

@NgModule({
  declarations: [
    UsersTableComponent,
    UserDeletionDialogComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    MatDialogModule,
    HttpClientModule,
    MatSnackBarModule
  ],
  exports: [
    UsersTableComponent
  ]
})
export class UsersModule { }
