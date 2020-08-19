import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss']
})
export class EditUserComponent implements OnInit {

  user: any
  id: any
  constructor(
    private _userService: UserService,
    private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this.id = this._route.snapshot.paramMap.get('id');
    this._userService.getUser(this.id).subscribe(resp =>{
      this.user = resp;
      console.log(this.user);
    })
  }


}
