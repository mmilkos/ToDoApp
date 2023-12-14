import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TodoClient';
  userTasks : any;
  apiUrl = 'http://localhost:5000/api/tasks';

  constructor(private http: HttpClient) 
  {
    
  }
  ngOnInit(): void {
    this.http.get(this.apiUrl).subscribe({
      next: response => this.userTasks = response,
      error: error => console.log(error),
      complete: () => console.log('Request completed')
    })
  }


}
