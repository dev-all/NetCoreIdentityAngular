import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { USERS_DATA } from '@data/constants/users.const';
import { ICardUser } from '@share/components/cards/card-user/icard-user.metadata';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss'],
})
export class UserProfileComponent implements OnInit {
  public users: ICardUser[] = USERS_DATA;

  public currentUser?: ICardUser;
  public id: number;
  constructor(private route: ActivatedRoute) {
    this.id = +this.route.snapshot.params['id'];
    this.currentUser = this.users.find(u => u.id === +this.id);
    // console.log(this.currentUser);
    // console.log({users: this.users});
  }

  ngOnInit(): void {}
}
