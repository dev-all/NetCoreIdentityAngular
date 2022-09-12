import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-one',
  templateUrl: './form-one.component.html',
  styleUrls: ['./form-one.component.scss']
})
export class FormOneComponent implements OnInit {

  model: string  = '';
  modelIsValid: boolean = false;
  sportsList = [
    {
      id:1,
      name:'sport',
      value:'cricket',
      label:'Cricket'
    },{
      id:2,
      name:'sport',
      value:'football',
      label:'Football'
    },{
      id:3,
      name:'sport',
      value:'swimming',
      label:'Swimming'
    },{
      id:4,
      name:'sport',
      value:'hockey',
      label:'Hockey'
    }
  ]
  public myForm;
  isFormSubmitted = false;
  constructor( private formBuilder : FormBuilder) {

    this.myForm = this.formBuilder.group({
      username : ['',Validators.required],
      email : ['',[Validators.required,
                  Validators.email,
                  Validators.pattern(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
      password: ['',[Validators.required,Validators.minLength(4)]],
      sport: ['', Validators.required],
      remember: ['',Validators.required],
      address: this.formBuilder.group({
        street:  ['',Validators.required],
        city: [''],
        state: [''],
        zip: ['']
      }),
      aliases: this.formBuilder.array([
        this.formBuilder.control('')
      ])
      });
  }

  ngOnInit(): void {
    //set del valor
    this.myForm.get('username')?.setValue('leon147');
  }

  get fm(){
    return this.myForm.controls;
  }

  get aliases() {
    return this.myForm.get('aliases') as FormArray;
  }

  addAlias() {
    this.aliases.push(this.formBuilder.control(''));
  }
  updateProfile() {
    this.myForm.patchValue({
      username: 'Nancy',
      address: {
        street: '123 Drew Street'
      }
    });
  }

  submitForm(){
     // Set flag to true
    this.isFormSubmitted = true;

    console.log('submitForm');
    // todo el valor del form
    console.log(this.myForm.value);
    // get username ingresado
    console.log(this.myForm.get('username')?.value);

  }

}
