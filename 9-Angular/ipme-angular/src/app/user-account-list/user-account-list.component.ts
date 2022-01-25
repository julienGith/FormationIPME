import { UserAccount } from './../../models/UserAccount/UserAccount';
import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../service/account.service';
import { IUserAccountList } from './../../models/UserAccount/UserAccountList';
import { IPokeApiResult } from '../../models/pokemon/i-poke-api-result';

@Component({
  selector: 'app-user-account-list',
  templateUrl: './user-account-list.component.html',
  styleUrls: ['./user-account-list.component.scss']
})
export class UserAccountListComponent implements OnInit {

  iUserAccountList: IUserAccountList|undefined;
  offset: number = 0;

  constructor(public AccountService : AccountService) { }

  ngOnInit(): void {
    this.CallPage(0);
  }
  CallPage(number:number){
this.AccountService.getAccountList(this.offset)
.subscribe((iUserAccountList: IUserAccountList)=>{
for (let result of iUserAccountList) {


}
})
  }

}
