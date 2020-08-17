import { Component, OnInit } from '@angular/core';
import { ProvidersService } from 'src/app/services/providers.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  users: any[];
  constructor(private _providersService: ProvidersService) { }

  ngOnInit(): void {
    this._providersService.getProviders().subscribe(resp => {
      this.users = resp;
      console.log(resp)
    })
  }

}
