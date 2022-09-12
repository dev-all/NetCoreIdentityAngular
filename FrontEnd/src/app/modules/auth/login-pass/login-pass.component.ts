import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@data/services/api/security/auth.service';
import { faGooglePlusG } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-login-pass',
  templateUrl: './login-pass.component.html',
  styleUrls: ['./login-pass.component.scss']
})
export class LoginPassComponent implements OnInit {

  returnUrl: any;
  faGoogle = faGooglePlusG ;

  public loginForm: FormGroup;

  isFormSubmitted = false;


  emailLogin : string = '';


  //----------------------

  constructor(private formBuilder : FormBuilder , private router: Router, private route: ActivatedRoute, private serviceAuth: AuthService) {
    if (this.GetEmailLogin() =='') {
      this.router.navigate([`${this.returnUrl}${'auth/login'}`]);
    }

  this.loginForm = this.formBuilder.group({
    email : [ this.GetEmailLogin() ,[Validators.required,
                Validators.email,
                Validators.pattern(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
    password: ['',[Validators.required,Validators.minLength(4)]],
    });

  }

  ngOnInit(): void {
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';



  }

  GetEmailLogin() {
   return this.serviceAuth.emaillogin;
  }



  get fm(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }

  onLoggedin() {

    debugger;
    if(this.loginForm.valid){
    localStorage.setItem('isLoggedin', 'true');
    if (localStorage.getItem('isLoggedin')) {
      this.router.navigate([this.returnUrl]);
    }
    }


  }

  Authenticate() {

    this.isFormSubmitted =true;
    if(!this.loginForm.valid ){
      return;
    }

    debugger;
    localStorage.setItem('isLoggedin', 'true');
    this.serviceAuth.login(this.loginForm.value).subscribe( r =>
        {
          console.log(r);
        });

    if (localStorage.getItem('isLoggedin')) {

      this.router.navigate([this.returnUrl]);

    }


  }




  //   onLoggedin(e: Event) {
  //     e.preventDefault();
  //     debugger;
  //     localStorage.setItem('isLoggedin', 'true');

  //     if(!this.loginForm.valid){
  //       return;
  //     }


  //     if (localStorage.getItem('isLoggedin')) {

  //       this.router.navigate([this.returnUrl]);

  //     }

  // }

}
