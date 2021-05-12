import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from '../Model/user-model.model';
import { SignUpServService } from '../servises/sign-up-serv.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css','../css/bootstrap.min.css']
})
export class UserListComponent implements OnInit {

  users:UserModel[];

  constructor(private router: Router,private sing:SignUpServService) { }

  ngOnInit(): void {
    this.sing.getUsers()
      .subscribe( data => {
        this.users = data;
      });
  };

  deleteUser(user: UserModel): void {
    this.sing.deleteUser(user)
      .subscribe( data => {
        this.users = this.users.filter(u => u !== user);
      })
  };

}
