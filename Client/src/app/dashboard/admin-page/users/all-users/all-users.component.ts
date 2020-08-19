import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.scss']
})
export class AllUsersComponent implements OnInit {

  users: any[];
  constructor(private _userService: UserService) { }

  ngOnInit(): void {
    this._userService.getUsers().subscribe(resp => {
      this.users = resp;
      console.log(resp)
    })
  }

}
