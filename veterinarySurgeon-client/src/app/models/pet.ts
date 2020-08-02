import { Animal } from './animal';
import { Employee } from './employee';

export class Pet {
    id: number;
    name: string;
    animal: Animal;
    owner: Employee
}