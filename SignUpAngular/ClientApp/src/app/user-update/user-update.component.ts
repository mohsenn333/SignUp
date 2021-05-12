import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SignUpServService } from '../servises/sign-up-serv.service';


@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit {

  user:any={};
  constructor( private router:Router,private route:ActivatedRoute,private signser:SignUpServService) { }

  ngOnInit() {
    this.signser.getUser(this.route.snapshot.params['id'])
      .subscribe(data => {
        this.user = data;
      });

  };
  updateUser(): void {
    this.signser.updateUser(this.user)
      .subscribe(data => {
        alert("User updated successfully.");
        this.router.navigate(['/User-List']);
      });

  };

}
