import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { response } from '../_models/response';


@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }
    header: {}
    getAll() {
     console.log("geldi")
        return this.http.get<response>(`${environment.apiUrl}/user/GetAll`);

    }



    getById(id: number) {
        return this.http.get<response>(`${environment.apiUrl}/user/${id}`);
    }

}