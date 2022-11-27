import {Component} from '@angular/core';
import { Scholarity, SCHOLARITY_NAMES } from '../../enums/scholarity.enum';
import { User } from '../../models/user.model';

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
export class UsersTableComponent {
  displayedColumns: string[] = ['id', 'fullName', 'email', 'birthDate', 'scholarity', 'actions'];
  dataSource = ELEMENT_DATA;

  getScholarityName(scholarity: Scholarity) {
    return SCHOLARITY_NAMES[scholarity];
  }
}