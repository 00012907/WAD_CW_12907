import { Component, inject } from '@angular/core';
import { RecipeBook } from '../../RecipeBookItems';
import { ServiceRecipeService } from '../../service-recipe-book.service';
import { ActivatedRoute } from '@angular/router';
import { MatChipsModule } from '@angular/material/chips'
import {MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [MatChipsModule,MatCardModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  // Details of any type, later we can use it 
  detailsRecipe:RecipeBook={
    id:0,
    title:"",
    description:"",
    preparationTime:0,
    categoryID:0,
    category:{
      id:0,
      name:""    
    }
  
  }
  servicRecipe = inject(ServiceRecipeService)
  activatedRoute = inject(ActivatedRoute)
  ngOnInit(){
    
    this.servicRecipe.getByID(this.activatedRoute.snapshot.params["id"]).subscribe((resultedItem)=>{
    this.detailsRecipe=resultedItem  
    });
  }
}
