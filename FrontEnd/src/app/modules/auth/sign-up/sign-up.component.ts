import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from '@data/schema';
import { AuthService } from '@data/services/api/security/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  errorMEssage!:string;
  public authForm: FormGroup;
  isFormSubmitted = false;
  errorMessage!:string;

  constructor(private router: Router
    ,private formBuilder: FormBuilder    
    , private route: ActivatedRoute
    , private serviceAuth: AuthService) { 
     
    this.authForm = this.formBuilder.group({
      fullname : ['',Validators.required],
      email : ['',[Validators.required,
      Validators.email,
      Validators.pattern(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
      password : ['',Validators.required],
      agreeTerm : false
    });

    }

  ngOnInit(): void {
 
  }
  get fm(){
    return this.authForm.controls;
  }

  submitForm(user:UserModel){
    if (this.authForm.valid){
      if (user.agreeTerm === false)
      {
        this.errorMessage= "You must agree to terms & conditions before singning up!";
        return;
      }
      // deberia obtener el id del back para el rol invitado
      user.roleId='091da15d-3ae4-4f6e-aafb-8160d1c524a5';
      return this.serviceAuth.signUp(user).subscribe( 
        user =>{
            console.log(user);
            localStorage.setItem('isLoggedin', 'true');
            localStorage.setItem('user', JSON.stringify(user));
            this.router.navigate(['/']);
          },
        error => {
            console.log(error);
            if(error.status === 409){
              this.errorMessage = "Error 409";              
            }else{
            this.errorMessage = "Error 409 Please try again!";   
            }
            return;   
          });          
      // this.isFormSubmitted = true;
      // localStorage.setItem('isLoggedin', 'true');
      // if (localStorage.getItem('isLoggedin')) {
      //   this.router.navigate(['/']);
      // }
    }
    return;
   }


  
}
