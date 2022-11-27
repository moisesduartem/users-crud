import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from '../../models/user.model';
import { TableService } from '../../table.service';
import { UsersService } from '../../users.service';

@Component({
  selector: 'app-user-deletion-dialog',
  templateUrl: './user-deletion-dialog.component.html',
  styleUrls: ['./user-deletion-dialog.component.scss']
})
export class UserDeletionDialogComponent implements OnInit {

  constructor(
    private readonly usersService: UsersService,
    private readonly tableService: TableService,
    private readonly snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) 
    public data: { user: User }
  ) { }

  ngOnInit(): void {
  }

  deleteUser() {
    this.usersService.deleteById(this.data.user.id).subscribe({
      error: (e) => this.snackBar.open('Erro ao tentar excluir usuário', 'Fechar'),
      complete: () => {
        this.tableService.updateValue(true);
        this.snackBar.open('Usuário excluído com sucesso', 'Fechar');
      }
    });
  }
}
