import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { RecipeBook } from './RecipeBookItems';

@Injectable({
  providedIn: 'root'
})
export class ServiceRecipeService {
  httpClient = inject(HttpClient);
  constructor() { }

  getAllRecipes(){
    return this.httpClient.get<RecipeBook[]>("http://localhost:5182/api/Recipes/GetAll/")
  };

  getByID(id:number){
    return this.httpClient.get<RecipeBook>("http://localhost:5182/api/Recipes/GetById/"+id);
  };
  edit(item:RecipeBook){
    return this.httpClient.put("http://localhost:5182/api/Recipes/Update", item);  
  };
  delete(id:number){
    return this.httpClient.delete("http://localhost:5182/api/Recipes/Delete/"+id);
  };
  create(item:RecipeBook){
    return this.httpClient.post<RecipeBook>("http://localhost:5182/api/Recipes/Create", item);
  };
  getAllCategories(){
    return this.httpClient.get<RecipeBook[]>("http://localhost:5182/api/Category/Get")
  };
}
