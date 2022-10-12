import { Component, OnInit } from '@angular/core';
import { TOAST_TYPE } from './toast.enum';
import { ToastService } from './toast.service';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.scss']
})
export class ToastComponent {
  public __types = TOAST_TYPE;
  constructor(public serviceToast: ToastService) { }


}
