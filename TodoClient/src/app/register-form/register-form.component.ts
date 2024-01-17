import { Component } from '@angular/core';
import { AccountService } from '../services/account.service';
import { RegisterFormDto } from './register.model';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent {

  Model : RegisterFormDto = {
    Name: "",
    Password: ""
  }
  
  constructor(private Account: AccountService) {}
  submit()
  {
    this.Account.register(this.Model).subscribe(
    {
      next: response => 
      {
         this.Model.Name = "";
         this.Model.Password = "";
         alert('Registered successfully');
      },
      error: error => console.error(error)
    })
  }

}
