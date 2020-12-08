import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { environment } from "../../environments/environment";
import { response } from "../_models/response";
import { Personnel, User } from "../_models";

@Injectable({ providedIn: "root" })
export class Repository {
  constructor(private http: HttpClient) {}

  getAll(action) {
    return this.http.get<response>(`${environment.apiUrl}/${action}`);
  }

  getWithId(action, param) {
    return this.http.get<response>(
      `${environment.apiUrl}` + `${action}?id=${param}`
    );
  }

  postEntity(action: string, param) {
    return this.http.post<any>(`${environment.apiUrl}/${action}`, param );
  }


}
