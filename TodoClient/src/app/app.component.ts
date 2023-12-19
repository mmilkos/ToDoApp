import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CrudService } from './services/crud.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'TodoClient';
  userTasks : any;
  

  constructor(private crud: CrudService) {}

  ngOnInit(): void 
  {
    this.crud.getAllTasks().subscribe(()=>{
      this.userTasks = this.crud.getTasks();
    })
  }
}