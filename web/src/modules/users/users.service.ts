import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from './models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private readonly BASE_URL = `${environment.apiUrl}/users`;

  constructor(
    private readonly httpClient: HttpClient
  ) { }

  getAll(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.BASE_URL);
  }

  deleteById(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.BASE_URL}/${id}`);
  }
}
