import { HttpClient } from '@angular/common/http';
import {Component, OnInit} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Scholarity, SCHOLARITY_NAMES } from '../../enums/scholarity.enum';
import { User } from '../../models/user.model';
import { TableService } from '../../table.service';
import { UsersService } from '../../users.service';
import { UserDeletionDialogComponent } from '../user-deletion-dialog/user-deletion-dialog.component';

const ELEMENT_DATA: User[] = [
  { 
    id: 1, 
    firstName: "Paul", 
    lastName: "McCartney", 
    email: "paul@gmail.com", 
    birthDate: "1942-06-18", 
    scholarity: Scholarity.Elementary 
  }
];

@Component({
  selector: 'app-users-table',
  styleUrls: ['users-table.component.scss'],
  templateUrl: 'users-table.component.html',
})
export class UsersTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'fullName', 'email', 'birthDate', 'scholarity', 'actions'];
  dataSource = ELEMENT_DATA;
  users$: Observable<User[]> = new Observable<User[]>;

  constructor(
    public dialog: MatDialog,
    private readonly usersService: UsersService,
    private readonly tableService: TableService
  ) { }

  ngOnInit(): void {
    this.users$ = this.usersService.getAll();

    this.tableService.shouldReload$.subscribe({
      next: (value) => {
        if (value) {
          this.users$ = this.usersService.getAll();
          this.tableService.updateValue(false);
        }
      }
    });
  }

  getScholarityName(scholarity: Scholarity) {
    return SCHOLARITY_NAMES[scholarity];
  }

  openDeletionDialog(user: User): void {
    this.dialog.open(UserDeletionDialogComponent, {
      width: '350px',
      data: {
        user
      }
    });
  }
}