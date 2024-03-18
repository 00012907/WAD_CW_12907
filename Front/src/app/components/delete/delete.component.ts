import { Component, inject } from '@angular/core';
import { RecipeBook } from '../../RecipeBookItems';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ServiceRecipeService } from '../../service-recipe-book.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {
  deleteRecipe:RecipeBook={
    id:0,
    title:"",
    description:"",
    categoryID:0,
    preparationTime:0,
    category:{
      id:0,
      name:""    
    }
  
  }
  service = inject(ServiceRecipeService)
  activateRote= inject(ActivatedRoute)
  router = inject(Router)

  ngOnInit(){
    this.service.getByID(this.activateRote.snapshot.params["id"]).subscribe((result)=>{
      this.deleteRecipe = result
    });
  }
  
  onHomeButtonClick(){
    this.router.navigateByUrl("home")
  }


  onDeleteButtonClick(id:number){
    this.service.delete(id).subscribe(r=>{this.router.navigateByUrl('home')});
    alert("Deleted  item with ID: "+id)    
  }
}
