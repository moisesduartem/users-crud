import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SCHOLARITY_NAMES } from '../../enums/scholarity.enum';

@Component({
  selector: 'app-create-edit-form',
  templateUrl: './create-edit-form.component.html',
  styleUrls: ['./create-edit-form.component.scss']
})
export class CreateEditFormComponent implements OnInit {
  formGroup: FormGroup;

  constructor() {
    this.formGroup = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      birthDate: new FormControl('', [Validators.required]),
      scholarity: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit(): void {
  }

  get scholarities(): string[] {
    return Object.values(SCHOLARITY_NAMES);
  }

  get shouldDisableSubmitButton(): boolean {
    return this.formGroup.status !== 'VALID';
  }
}
