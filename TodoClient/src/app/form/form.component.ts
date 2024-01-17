import { Component, OnInit } from '@angular/core';
import { TaskFormDto } from './form.model';
import { TasksService } from '../services/tasks.service';
import { AccountService } from '../services/account.service';
import { HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent  {
  Model : TaskFormDto = {
    Name: "",
    Description: ""
  }


  constructor(private Tasks: TasksService, private Account: AccountService) {}

  submit()
  {
    let headers = new HttpHeaders().set('Authorization', 'Bearer ' + this.Account.currentUserSource.value?.token)
    this.Tasks.postTask(this.Model, headers).subscribe(
    {
      next: response => 
      {
        this.Tasks.addTaskToCollection(response)
         this.Model.Description = "";
         this.Model.Name = "";
      },
      error: error => console.error(error)
    })
  }

}