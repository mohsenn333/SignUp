import { UserModel } from './../Model/user-model.model';
import { Component, OnInit } from '@angular/core';
import { SignUpServService } from '../servises/sign-up-serv.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent  {
user:UserModel=new UserModel();
  constructor(private router: Router,private signserv:SignUpServService) { }

  createUser(): void {
    this.signserv.createUser(this.user)
        .subscribe( data => {
          alert("Employee created successfully.");
          this.router.navigate(['/User-List']);
        });

  };

}
