import { Pet } from './pet';

export class Employee {
    id: number;
    name: string;
    lastName: string;
    fullname: string;
    petsCount: number;
    isEmployee:boolean;
    pets: Pet[];
    familyMembers: Employee[];
}

export class EmployeeCommand {
    name: string;
    lastName: string;
}