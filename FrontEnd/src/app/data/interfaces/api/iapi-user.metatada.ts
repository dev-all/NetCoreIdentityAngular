import { RoleModel } from "./role.model";
import { TenantModel } from "./tenant.model";

export interface IApiUser {   
    id: string;
    name: string | null;
    lastname : string | null;
    age: number;
    position: string;
}