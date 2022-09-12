import { ICardUser } from './../../../shared/components/cards/card-user/icard-user.metadata';
import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { UserService } from '@data/services/api/user.service';
import { Subscription } from 'rxjs/internal/Subscription';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements AfterViewInit, OnInit ,OnDestroy {


  public users?: ICardUser[] ; //= USERS_DATA;
  public title!:string;
  public userSubscription!: Subscription;

  public pricePesos: number = 0;

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
    console.log(' user list | oninit');
  }


  getUsers(){
   this.userSubscription =  this.userService
   .getAllUser()
   .subscribe(r => {
         this.users=r;
    });
  }




}
