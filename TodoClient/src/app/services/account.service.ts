import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, catchError, map, tap, throwError } from 'rxjs';
import { User } from '../user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  apiUrl = "http://localhost:5000/api/account/";
  loggedIn : boolean = false;
  currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  

  login(formData: any): Observable<any>
  {
    return this.http.post<User>(this.apiUrl + "login", formData).pipe(
    map((response: User) => {
      const user = response;
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user);
        this.loggedIn = true;
      }
    })
    )
  }

  setCurrentUser(user : User){
    this.currentUserSource.next(user);
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.loggedIn = false;
  }

  register(formData: any): Observable<any>{
    return this.http.post(this.apiUrl + "register", formData).pipe(
      catchError(this.handleError)
    )
  }


  private handleError(error: HttpErrorResponse) 
  {
    if (error.status === 409) 
    {
      alert('This user name is taken');
    } 
    if (error.status == 400) 
    {
      alert("The field Name must have minimum length of 2 and the field Password must be a string type with a minimum length of 8")
    }

    return throwError(error);
  }
}
