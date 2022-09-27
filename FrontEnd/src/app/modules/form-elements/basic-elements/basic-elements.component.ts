import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { CONST_LOGIN_PAGE } from '@data/constants';

@Component({
  selector: 'app-basic-elements',
  templateUrl: './basic-elements.component.html',
  styleUrls: ['./basic-elements.component.scss'],
})
export class BasicElementsComponent implements OnInit {
  model: string = '';
  modelIsValid: boolean = false;
  public data = CONST_LOGIN_PAGE;
  public loginForm;

  control: FormControl;

  public myForm;

  constructor(private formBuilder: FormBuilder) {
    this.myForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: [
        '',
        [
          Validators.required,
          Validators.email,
          Validators.pattern(
            /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
          ),
        ],
      ],
      password: ['', [Validators.required, Validators.minLength(4)]],
      remember: ['', Validators.required],
    });

    this.control = new FormControl('', [
      Validators.required,
      Validators.minLength(4),
    ]);
    this.loginForm = this.data.FORM;
  }

  ngOnInit(): void {
    //console.log(this.control);

    //set del valor
    this.myForm.get('username')?.setValue('leon147');
  }

  get fm() {
    return this.myForm.controls;
  }

  submitForm() {
    console.log('submitForm');
    // todo el valor del form
    console.log(this.myForm.value);
    // get username ingresado
    console.log(this.myForm.get('username')?.value);
  }

  get isValidForm() {
    return this.loginForm.email.isValid() && this.loginForm.password.isValid();
  }

  cambioTexto(valorDelInput: string) {
    // this.model se actualiza despues que el parametro valordelinput
    //console.log(this.model);
    console.log(valorDelInput);

    this.modelIsValid = !!valorDelInput && valorDelInput.length > 4;
  }
}
