import { HttpClient } from '@angular/common/http';
import {Component, OnInit} from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Scholarity, SCHOLARITY_NAMES } from '../../enums/scholarity.enum';
import { User } from '../../models/user.model';
import { UsersService } from '../../users.service';

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
    private readonly usersService: UsersService
  ) { }

  ngOnInit(): void {
    this.users$ = this.usersService.getAll();
  }

  getScholarityName(scholarity: Scholarity) {
    return SCHOLARITY_NAMES[scholarity];
  }
}