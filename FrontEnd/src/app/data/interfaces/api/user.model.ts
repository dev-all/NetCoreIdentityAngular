import { RoleModel } from "./role.model";
import { TenantModel } from "./tenant.model";

export interface UserModel {
    data(data: any): unknown;
    id: string;
    fullName: string | null;
    userName: string | null;
    email: string | null;
    password: string | null;
    agreeTerm: boolean;
    createdAt: string;
    updatedAt: string | null;
    rememberMe: boolean;
    token: string | null;
    appOriginUrl: string | null;
    roleId: string;
    //role: RoleModel | null;
    role: string | null;
    tenantId: string;
    tenant: TenantModel | null;
    google: boolean;
    active: boolean;
}
