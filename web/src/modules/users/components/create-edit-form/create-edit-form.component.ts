import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SCHOLARITY_NAMES } from '../../enums/scholarity.enum';
import { User } from '../../models/user.model';
import { UsersService } from '../../users.service';

@Component({
  selector: 'app-create-edit-form',
  templateUrl: './create-edit-form.component.html',
  styleUrls: ['./create-edit-form.component.scss']
})
export class CreateEditFormComponent implements OnInit {
  formGroup: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: { user: User | null },
    private readonly usersService: UsersService,
    private readonly snackBar: MatSnackBar,
  ) {
    this.formGroup = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      birthDate: new FormControl('', [Validators.required]),
      scholarity: new FormControl('', [Validators.required]),
    });

    if (this.formType === 'EDIT') {
      const user = this.data.user as User;

      this.formGroup.setValue({
        firstName: user.firstName,
        lastName: user.lastName,
        email: user.email,
        birthDate: user.birthDate,
        scholarity: SCHOLARITY_NAMES[user.scholarity]
      });
    }
  }

  ngOnInit(): void {
  }

  get formType(): 'CREATE' | 'EDIT' {
    const userIsEmpty = this.data.user === null;
    return userIsEmpty ? 'CREATE' : 'EDIT';
  }

  get scholarities(): string[] {
    return Object.values(SCHOLARITY_NAMES);
  }

  get shouldDisableSubmitButton(): boolean {
    return this.formGroup.status !== 'VALID';
  }

  submit(): void {
    
    const rawFormData = this.formGroup.getRawValue();
    
    const scholarityNumber = this.scholarities.findIndex(x => x === rawFormData.scholarity);

    const data = { ...rawFormData, scholarity: scholarityNumber };

    if (this.formType === 'CREATE') {
      this.usersService.create(data).subscribe({
        error: (e) => this.snackBar.open('Erro ao tentar criar usuário', 'Fechar'),
        complete: () => {
          this.snackBar.open('Usuário criado com sucesso', 'Fechar');
        }
      });
      return;
    }

    this.usersService.update(this.data?.user?.id as number, data).subscribe({
      error: (e) => this.snackBar.open('Erro ao tentar atualizar usuário', 'Fechar'),
      complete: () => {
        this.snackBar.open('Usuário atualizado com sucesso', 'Fechar');
      }
    });
  }
}
