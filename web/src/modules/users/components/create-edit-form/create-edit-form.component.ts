import { Component, OnInit } from '@angular/core';
import { SCHOLARITY_NAMES } from '../../enums/scholarity.enum';

@Component({
  selector: 'app-create-edit-form',
  templateUrl: './create-edit-form.component.html',
  styleUrls: ['./create-edit-form.component.scss']
})
export class CreateEditFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  get scholarities(): string[] {
    return Object.values(SCHOLARITY_NAMES);
  }
}
