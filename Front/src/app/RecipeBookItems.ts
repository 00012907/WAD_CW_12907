
export interface RecipeBook {
    id: number;
    title: string;
    description: string;
    preparationTime:number;
    categoryID: number;
    category: {
      id: number;
      name: string;
    };
  }





  