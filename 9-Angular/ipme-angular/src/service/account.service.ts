
import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Account} from "../models/steamish/account";
import {Observable} from "rxjs";
<<<<<<< Updated upstream
=======
import { UserAccount } from './../models/UserAccount/UserAccount';
import { IUserAccountList } from '../models/UserAccount/UserAccountList';
>>>>>>> Stashed changes

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  rawUrl: string = 'https://steam-ish.test-02.drosalys.net/api/accounts';
  headers: {headers: HttpHeaders} = {
    headers: new HttpHeaders({
      'Content-Type': 'application/ld+json',
    })
  };

  constructor(private httpClient: HttpClient) { }

<<<<<<< Updated upstream
  postAccount(account: Account): Observable<Account> {
=======
  getAccountList(offset:number): Observable<IUserAccountList> {
      return this.httpClient.get<IUserAccountList>(this.rawUrl + offset);

  }
  postAccount(account: Account): void {
>>>>>>> Stashed changes
    const body = {
      'name': account.name,
      'nickname': account.nickname,
      'email': account.email,
      'wallet': account.wallet,
      'libraries': account.libraries,
    };
    return this.httpClient.post<Account>(this.rawUrl, body, this.headers);
  }
}
