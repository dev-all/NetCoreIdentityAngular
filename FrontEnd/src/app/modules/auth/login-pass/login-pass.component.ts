import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from '@data/schema';
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
  errorMessage!:string;

  constructor(private formBuilder : FormBuilder 
            , private router: Router
            , private route: ActivatedRoute
            , private serviceAuth: AuthService) {
  

  this.loginForm = this.formBuilder.group({
    email : [ this.GetEmail() ,[Validators.required,
                Validators.email,
                Validators.pattern(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
    password: ['',[Validators.required,Validators.minLength(4)]],
    });

  }

  ngOnInit(): void {      
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  GetEmail() :string{    
    let email = localStorage.getItem('InitLoginEmail');
    if (!email) {
      this.serviceAuth.logout()     
     }
    return  email || "";
  }



  get fm(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }

  onLoggedin() {
    
    if(this.loginForm.valid){
    localStorage.setItem('isLoggedin', 'true');
    if (localStorage.getItem('isLoggedin')) {
      this.router.navigate([this.returnUrl]);
    }
    }
  }

  Authenticate(user : UserModel) {

    this.isFormSubmitted =true;
    if(!this.loginForm.valid ){
      this.errorMessage= "Opss!!! revise los datos ingresados";
      return;
    }      
    this.serviceAuth.signIn(user).subscribe( response =>
      {     
        debugger;   
        console.log(response);
        // if(response.status == "200")
        //     {                  
        //       this.setUserToLocalStorage(response.data);
        //       this.userSubject$.next(response.data);
        //       this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
        //     }            
                      
      });
  }
}
