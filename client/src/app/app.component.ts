import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';

  constructor(private accountService: AccountService) {

  }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser() {
    var userString = localStorage.getItem('user');

    if (userString) {
      var user: User = JSON.parse(userString);

      if (user.token && user.username)
        this.accountService.setCurrentUser(user);
    }
  }
}
