import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RefreshService {
  private refreshSubject = new Subject<void>();
  private userTasks : any;
  private apiUrl = 'http://localhost:5000/api/tasks';


  constructor(private http: HttpClient) { }

  
  Refresh(): void {
    this.http.get(this.apiUrl).subscribe({
      next: response => this.userTasks = response,
      error: error => console.log(error),
      complete: () => console.log('Request completed')
    })
  }
}
