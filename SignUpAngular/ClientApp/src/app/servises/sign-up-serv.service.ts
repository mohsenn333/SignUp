import { UserModel } from './../Model/user-model.model';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SignUpServService {

  constructor(private http:HttpClient) { }
  private apiurl = 'https://localhost:44320/api/User/';

  public getUsers() {
    return this.http.get<UserModel[]>(this.apiurl);
  }
  public getUser(id) {
    return this.http.get(this.apiurl + id);
  }

  public deleteUser(user) {
    return this.http.delete(this.apiurl + user.id);
  }

  public createUser(user) {
    return this.http.post<UserModel>(this.apiurl, user);
  }

  public updateUser(user) {
    return this.http.put<UserModel>(this.apiurl, user);
  }
}
