import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { Observable } from 'rxjs';
import { Governorate } from '../governorate';
import { City } from '../city';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  url = 'http://localhost:5204';
  userUrl = this.url + '/User';
governorateUrl = this.url + '/Lookup/governorate';
cityUrl = this.url + '/Lookup/city';


  constructor(private http: HttpClient) {}
  postUser(user: User): Observable<User> {
    return this.http.post<User>(this.userUrl, user);
  }

  getGovernorateList():Observable<Governorate[]>{
    return this.http.get<Governorate[]>(this.governorateUrl)
  }

  getCityList():Observable<City[]>{
    return this.http.get<City[]>(this.cityUrl)
  }
}
