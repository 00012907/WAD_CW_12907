import { Component, Input, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { ServiceRecipeService } from '../../service-recipe-book.service';
import { RecipeBook } from '../../RecipeBookItems';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})

export class HomeComponent {

  recipeService=inject(ServiceRecipeService); 
  router = inject(Router)
  items:RecipeBook[]=[];
  ngOnInit(){
    this.recipeService.getAllRecipes().subscribe((result)=>{this.items = result}); 
  }

  displayedColumns: string[] = ['ID','Title','Description','Preparation Time','Category Name','Actions'];
  
  EditClicked(itemID:number){
    console.log(itemID, "From Edit");
    this.router.navigateByUrl("/edit/"+itemID);
  };
  DetailsClicked(itemID:number){
    console.log(itemID, "From Details");
    this.router.navigateByUrl("/details/"+itemID);
  };
  DeleteClicked(itemID:number){
    console.log(itemID, "From Delete");
    this.router.navigateByUrl("/delete/"+itemID);
  }

}

