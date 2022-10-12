import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { IToast } from './itoast.metadata';
import { TOAST_TYPE } from './toast.enum';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  private initialData: IToast[] = [];
  private toastSubject: BehaviorSubject<IToast[]> = new BehaviorSubject(this.initialData);
    
  get toasts(){
    return this.toastSubject.value;
  }

  hideToast(id?: number){
      let actual =this.toasts;
      actual = this.toasts.filter(d => d.id !== id);
      this.toastSubject.next(actual);
  }

  setAndShowToast(data: IToast, time = 10000){
    const { title = '' , description = '' , type = TOAST_TYPE.DANGER , userDefaultImage = false ,resourse = ''} = data;
    const id  = Math.floor(Math.random() * (100- 1 ) + 1 );
    this.toastSubject.next([...this.toasts,{
      id,
      title: `${title} ${id}`,
      description,
      type,
      isShow:true,
      userDefaultImage,
      resourse   
    }])
  
  //hide after t time
  setTimeout(() => {
    const finalToast =  this.toasts.filter( d => d.id !== id);
    this.toastSubject.next(finalToast);
  }, time);

}
}
