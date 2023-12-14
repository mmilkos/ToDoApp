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

  getRefreshObservable() {
    return this.refreshSubject.asObservable();
  }

   refresh(): void {
    this.http.get(this.apiUrl).subscribe({
      next: (response: any) => {
        this.userTasks = response;
        this.refreshSubject.next(); // Emituje zdarzenie do nasłuchujących komponentów
      },
      error: error => console.log(error),
      complete: () => console.log('Request completed')
    });
   }

   getUserTasks(): any 
   {
    return this.userTasks;
  }
}
