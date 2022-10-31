import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

export class IdentityService {

  readonly BaseURI = 'https://localhost:7074/api';
  public formModel;

  constructor(private fb: FormBuilder, private http: HttpClient) { 
    debugger;
      this.formModel = this.fb.group({
        UserName: ['', Validators.required],
        Email: ['', Validators.email],
        FullName: [''],
        Passwords: this.fb.group({
          Password: ['', [Validators.required, Validators.minLength(4)]],
          ConfirmPassword: ['', Validators.required]
          }, { validator: this.comparePasswords })

        });
  }
  



  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    confirmPswrdCtrl?.setErrors({ passwordMismatch: true });
    ////passwordMismatch
   // // this.confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl?.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password')?.value != confirmPswrdCtrl?.value)
        confirmPswrdCtrl?.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl?.setErrors(null);
    }
  }

  register() {
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + '/ApplicationUser/Register', body);
  }

  login(formData: any) {
    return this.http.post(this.BaseURI + '/Account/sign-in', formData);    
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/UserProfile');
  }

  roleMatch(allowedRoles: any[]): boolean {

    var isMatch = false;
    var token = localStorage.getItem('token');
    if (token!= null)
    {    
    var payLoad = JSON.parse(window.atob(token.split('.')[1]));
    var userRole = payLoad.role;
    allowedRoles.forEach(element => {
      if (userRole == element) {
        isMatch = true;
        return false;
      }else{
        return isMatch;
      }
    });
    }
    
    return isMatch;
   
  }
}
