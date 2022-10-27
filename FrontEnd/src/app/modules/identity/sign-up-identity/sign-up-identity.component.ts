import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../service/identity.service';

@Component({
  selector: 'app-sign-up-identity',
  templateUrl: './sign-up-identity.component.html',
  styleUrls: ['./sign-up-identity.component.scss']
})
export class SignUpIdentityComponent implements OnInit {
  constructor(public service: IdentityService) { }

  ngOnInit() {
    debugger;
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          console.log('New user created!', 'Registration successful.');
        } else {
          res.errors.forEach((element: { code: any; description: any; }) => {
            switch (element.code) {
              case 'DuplicateUserName':
                console.log('Username is already taken','Registration failed.');
                break;

              default:
                console.log(element.description,'Registration failed.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }

}