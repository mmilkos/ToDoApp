import { Component, OnInit } from '@angular/core';
import { LoginFormDto } from './login.model';
import { AccountService } from '../services/account.service';
import { TasksService } from '../services/tasks.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{
  name :string = 'To do app';

  Model : LoginFormDto = {
    Name: "",
    Password: ""
  }

constructor(public account : AccountService, private tasks : TasksService) {}
ngOnInit(): void {
  this.getCurrentUser();
}
  login()
  {
    this.account.login(this.Model).subscribe(
      { next: response => 
        {
          this.Model.Name = "";
          this.Model.Password = "";
          this.account.loggedIn = true;
          location.reload();
        },
      error: error => console.error(error)}
    )
  }

  logout(){
    this.tasks.clearTaskArray();
    this.account.logout();
    this.account.loggedIn = false;
  }

  getCurrentUser(){
    this.account.currentUser$.subscribe({
      next: user=> this.account.loggedIn = !!user,
      error: error => console.error(error)
    })
  }
}
