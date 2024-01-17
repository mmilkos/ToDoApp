import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, tap,throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class TasksService {

  tasks: any[] = [];
  apiUrl = "http://localhost:5000/api/tasks/";
  constructor(private http: HttpClient, ) { }


  getAllTasks(headers: HttpHeaders): Observable<any>
  {
    return this.http.get<any[]>(this.apiUrl, {headers: headers}).pipe(
      tap((tasks: any[]) => 
      {
        this.tasks = tasks;
      })
    );
  }


  postTask(formData : any, headers : HttpHeaders): Observable<any>
  {
    return this.http.post(this.apiUrl, formData, {headers: headers}).pipe(
      catchError(this.handleError)
    );
  }


  updateTaskStatus(id : number, headers : HttpHeaders)
  {
    return this.http.put(this.apiUrl + id, null, {headers: headers}).pipe(
      catchError(this.handleError)
    )
  }


  deleteTask(id : number, headers : HttpHeaders): Observable<any>
  {
    return this.http.delete(this.apiUrl + id, {headers: headers}).pipe(
      catchError(this.handleError)
    );
  }


  addTaskToCollection(task : any)
  {
    this.tasks.push(task);
  }

  
  getTasks()
  {
    return this.tasks;
  }

  clearTaskArray(){
    this.tasks.splice(0, this.tasks.length);
  }


  private handleError(error: HttpErrorResponse) 
  {
    if (error.status === 404) 
    {
      alert('Task not found');
    } 
    if (error.status == 400) 
    {
      alert("The field Name must have minimum length of 2")
    }

    return throwError(error);
  }
}

