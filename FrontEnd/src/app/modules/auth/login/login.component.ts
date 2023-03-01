import { Component,   OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { AuthService } from '@data/services/api/security/auth.service';
import {faGooglePlusG } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  returnUrl: any;
  faGoogle = faGooglePlusG ;
  public loginForm: FormGroup;
  isFormSubmitted = false;


//--------------------------------------
  constructor(private formBuilder : FormBuilder
    , private router: Router
    , private route: ActivatedRoute
    , private serviceAuth: AuthService) {

    localStorage.clear();
    this.loginForm = this.formBuilder.group({
      email : ['',[Validators.required,
                  Validators.email,
                  Validators.pattern(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
      });


  }

  ngOnInit(): void {
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  get fm(){
    return this.loginForm.controls;
  }

  onLoggedin(e: Event) {
    e.preventDefault();
   // console.log(this.loginForm.get('email')?.value);
  }


  submitForm(){
   if (this.loginForm.valid){
   this.isFormSubmitted = true;
  //  localStorage.setItem('isLoggedin', 'true');
  //  if (localStorage.getItem('isLoggedin')) {
  //     }
    //this.serviceAuth.emaillogin = this.loginForm.get('email')?.value;

      localStorage.setItem('InitLoginEmail', this.loginForm.get('email')?.value);
      this.router.navigate([`${this.returnUrl}${INTERNAL_ROUTES.AUTH_LOGIN_PASS}`]);

  }
 }

 signUp(){
  this.router.navigate([`${this.returnUrl}${INTERNAL_ROUTES.AUTH_SIGNUP}`]);
}

}
