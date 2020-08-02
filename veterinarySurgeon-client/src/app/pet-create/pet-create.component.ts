import { Component, OnInit } from '@angular/core';
import { AnimalService } from '../animal.service';
import { Animal } from '../models/animal';
import { Observable } from 'rxjs';
import { PetCommand } from '../models/pet';
import { PetService } from '../pet.service';
import { Router } from '@angular/router';

import {
  FormBuilder,
  FormGroup,
  FormArray,
  FormControl,
  ValidatorFn,
  Validators
} from '@angular/forms';
import { Employee } from '../models/employee';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-pet-create',
  templateUrl: './pet-create.component.html',
  styleUrls: ['./pet-create.component.css']
})
export class PetCreateComponent implements OnInit {
  petCreationForm: FormGroup;
  submitted = false;
  name: string;
  animals: Observable<Animal[]>;
  owners: Observable<Employee[]>;
  pet: PetCommand = new PetCommand();

  constructor(
    private formBuilder: FormBuilder,
    private router: Router, 
    private animalService: AnimalService, 
    private employeeService: EmployeeService,
    private petService: PetService) {
      this.petCreationForm = this.formBuilder.group({
        name: ['', [Validators.required]],
        animals: [null, [Validators.required]],
        owners: [null, [Validators.required]]
      });
    }

  ngOnInit(): void {
    this.animals = this.animalService.getAnimalsList();
    this.owners = this.employeeService.getEmployeesList();
  }

  save(customerData) {
    this.petService.createPet(this.pet)
      .subscribe(data => console.log(data), error => console.log(error));
    this.pet = new PetCommand();
    this.petCreationForm.reset();
    this.gotoList();
  }

  gotoList() {
    this.router.navigate(['/pets']);
  }

  onSubmit(customerData) {
    this.submitted = true;
    this.save(customerData);    
  }

}
