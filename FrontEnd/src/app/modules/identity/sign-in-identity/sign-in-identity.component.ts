import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '@data/services/api/user.service';
import { IdentityService } from '../service/identity.service';

@Component({
  selector: 'app-sign-in-identity',
  templateUrl: './sign-in-identity.component.html',
  styleUrls: ['./sign-in-identity.component.scss']
})
export class SignInIdentityComponent implements OnInit {

  formModel = {
    UserName: '',
    Password: ''
  }
  constructor(private service: IdentityService, private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/home');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
      },
      err => {
        if (err.status == 400)
        console.log('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
  }
}