import { Component, OnInit } from "@angular/core";
import { Personnel, Role } from "src/app/_models";
import { User } from "../../_models/user";
import { Repository } from "../../_services";

@Component({
  selector: "app-icons",
  templateUrl: "./users.component.html",
  styleUrls: ["./users.component.scss"],
})
export class UsersComponent implements OnInit {
  public copy: string;
  registeredPersonnels: any;
  personnelModel: Personnel = {
    email: "",
    firstName: "",
    password: "",
    status: true,
    role: Role.User,

  };
  constructor(
    private repository: Repository
  ) {}

  ngOnInit() {
   this.fetchPersonnels()
  }
  onSubmit() {

    this.repository
      .postEntity("Personnel/AddNewPersonnel", this.personnelModel)
      .pipe()
      .subscribe((response) => {
        if (response.isSuccessful) {alert("eklendi");
        this.fetchPersonnels()}
        else
        alert(response.exceptionMessage || "bilinmeyen hata");
      });

    
  }

  openDialog(){
    alert("görev kartı pop açılacak");
  }
  fetchPersonnels(){
    this.repository
    .getAll("Personnel/GetAll")
    .pipe()
    .subscribe((response) => {
      if (response.hasExceptionError)
      alert(response.exceptionMessage || "bilinmeyen hata");
      this.registeredPersonnels = response.list;
    });
  }
  
}
