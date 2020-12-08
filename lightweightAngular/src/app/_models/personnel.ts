import { Role } from "./role";

export class Personnel {
    id: number;
    email:string;
    firstName: string;
    password: string;
    status: boolean;
    role: Role;
}