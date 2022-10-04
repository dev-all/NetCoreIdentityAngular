import { ICardUser } from './../../../shared/components/cards/card-user/icard-user.metadata';
import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { UserService } from '@data/services/api/user.service';
import { Subscription } from 'rxjs/internal/Subscription';
import { SOLID_BUTTON_TYPE_ENUM } from '@share/components/buttons/solid-button/solid-button-type.enum';
import { SolidButtonComponent } from '@share/components';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements AfterViewInit, OnInit ,OnDestroy {

  @ViewChild('mainBtn') mainBtn!: SolidButtonComponent;

  public users?: ICardUser[] ; //= USERS_DATA;
  public title!:string;
  public userSubscription!: Subscription;

  public pricePesos: number = 0;

  public $btnTypes= SOLID_BUTTON_TYPE_ENUM;




  constructor(private userService:UserService){
    this.pricePesos =0;
    this.userService.setTitle('List User');
    this.title=this.userService.getTitle();
  }
  ngAfterViewInit(): void {
    console.log('User list | afterViewInit se ejecuta cuando la vista esta completa');
  }

  addAmount(){
    this.pricePesos+=10;
  }

  ngOnDestroy(): void {
   if (this.userSubscription){
     this.userSubscription.unsubscribe();
   }
    this.userService.clearTitle();
  }

  ngOnInit() {
    this.getUsers();
    //console.log(' user list | oninit');
  }


  getUsers(){
   this.userSubscription =  this.userService
   .getAllUser()
   .subscribe(r => {
         this.users=r;
    });
  }


  onAction(event: any){   
    switch(event){
      case SOLID_BUTTON_TYPE_ENUM.SUCCESS:
        console.log("ejecutar metodo success");
        break;
        case SOLID_BUTTON_TYPE_ENUM.DANGER:
        console.log("ejecutar metodo  danger");
        break;
        default:
        console.log("ejecutar metodo  PRIMARY");
        break;        
    }
    console.log(event);
    }

  onContinue(status: boolean){
    console.log(status)
  }

  onView(event: SOLID_BUTTON_TYPE_ENUM){
    // send http request
   
    this.mainBtn.title = 'View';
     console.log(event);
     debugger;
  }
}
