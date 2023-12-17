import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RefreshService } from './services/refresh.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'TodoClient';
  userTasks : any;
  

  constructor(private refreshService: RefreshService) {}

  ngOnInit(): void 
  {
    this.userTasks = this.refreshService.getUserTasks();
    this.refreshService.getRefreshObservable().subscribe(
      ()=> 
      {
        this.userTasks = this.refreshService.getUserTasks();
      });
      this.refreshService.refresh();
  }
}