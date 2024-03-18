import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ServiceRecipeService } from '../../service-recipe-book.service';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule, MatChipsModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  recipeService = inject(ServiceRecipeService);
  
  router = inject(Router);

  cate: any;

  cID: number = 0;

  createRecipe: any = {
    title: "",
    description: "",
    preparationTime:0,
    categoryID: 0
  }

  ngOnInit() {
    this.recipeService.getAllCategories().subscribe((result) => {
      this.cate = result
    });

  };
  create() {
    this.createRecipe.categoryID=this.cID
    this.recipeService.create(this.createRecipe).subscribe(result=>{
      alert("Recipe Saved")
      this.router.navigateByUrl("home")
    });
  };


}
