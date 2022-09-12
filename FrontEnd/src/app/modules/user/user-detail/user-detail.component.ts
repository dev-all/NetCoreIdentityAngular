import { splitNsName } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { USERS_DATA } from '@data/constants/users.const';
import { UserService } from '@data/services/api/user.service';
import { ICardUser } from '@share/components/cards/card-user/icard-user.metadata';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit {
  public users: ICardUser[] = USERS_DATA;

  public currentUser?: ICardUser;
  public id:number;
  public title:string;
  constructor(private route:ActivatedRoute
            , private userServices: UserService) {
     this.id = +this.route.snapshot.params['id'];
     this.currentUser = this.users.find(u => u.id === +this.id);

     this.title= userServices.getTitle();
    console.log(this.currentUser);
   // console.log({users: this.users});

  }

  ngOnInit(): void {

  }
}
