import { Injectable } from '@angular/core';
import { ERRORS_VALIDATIONS } from '@data/constants';
import { ENUM_VALIDATION_OPTIONS } from '@data/enum';
import { IResponseValidation } from '@data/interfaces';
import { retry } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ValidationsService {
  constructor() {}

  /**
   * se creo el enum, las interfaces, y las const
   *
   * @param value any
   * @param Type ENUM_VALIDATION_OPTIONS
   */
  validateField(value: any, type: ENUM_VALIDATION_OPTIONS) {
    switch (type) {
      case ENUM_VALIDATION_OPTIONS.EMAIL:
        return this.validateEmail(value);

      case ENUM_VALIDATION_OPTIONS.PASSWORD:
        return this.validatePassword(value);
    }
  }

  /**
   * Valid email with pattern
   */
  private validateEmail(value: any): IResponseValidation {
    const r: IResponseValidation = { msg: '', isValid: true };
    // tener en cuenta que no es una str
    const pattern =
      /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    r.isValid = pattern.test(value);
    r.msg =
      value === ''
        ? ERRORS_VALIDATIONS.EMAIL_REQUERED_FIELD
        : ERRORS_VALIDATIONS.EMAIL_INVALID;
    return r;
  }

  private validatePassword(value: any): IResponseValidation {
    const r: IResponseValidation = { msg: '', isValid: true };
    // Match at least one uppercase letter,
    // at least one lowercase letter,
    // at least one digit
    // and includes 12 or more symbols
    //String validPassRegex = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=\\S+$).{12,}$";

    // and special characters:
    // 8 a 20 characters:
    const pattern =
      /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\S+$).{8,20}$/;
    r.isValid = pattern.test(value);
    r.msg =
      value === ''
        ? ERRORS_VALIDATIONS.PASSWORD_REQUIRED_FIELD
        : ERRORS_VALIDATIONS.PASSWORD_REQUIRED_PATTERN;

    return r;
  }
}
