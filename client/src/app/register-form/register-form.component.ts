import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent {
  model: any = {}
  @Input() usersFromHome: any = [];
  @Output() cancelRegister = new EventEmitter();


  constructor(private accountService: AccountService) {

  }

  register() {
    this.accountService.register(this.model).subscribe({
      next: user => console.log(user),
      error: error => console.log(error)
    }
    )
    this.cancel();
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
