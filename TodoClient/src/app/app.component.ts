import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { TasksService } from './services/tasks.service';
import { AccountService } from './services/account.service';
import { User } from './user';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.Default
})

export class AppComponent implements OnInit {
  title = 'TodoClient';
  userTasks : any;


  constructor(private Tasks: TasksService, public Account : AccountService) {}

  ngOnInit(): void 
  {
    this.setCurrentUser();
    if (true) {
      let headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.Account.currentUserSource.value?.token);
      this.Tasks.getAllTasks(headers).subscribe(
        ()=>{this.userTasks = this.Tasks.getTasks();}
      ) 
    }
    
  }


  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if (!userString) {return}

    const user : User = JSON.parse(userString);
    this.Account.setCurrentUser(user);
  }
}