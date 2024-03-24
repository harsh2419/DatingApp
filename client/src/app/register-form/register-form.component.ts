import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent {
  model: any = {}
  @Input() usersFromHome: any = [];
  @Output() cancelRegister = new EventEmitter();


  constructor(
    private accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {

  }

  register() {
    this.accountService.register(this.model).subscribe({
      next: _ => this.router.navigateByUrl('/members'),
      error: error => this.toastr.warning("An error occured!")
    }
    )
    this.cancel();
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
