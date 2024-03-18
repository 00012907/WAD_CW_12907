using Microsoft.EntityFrameworkCore;
using RecipeBook.DAL.Data;
using RecipeBook.DAL.Models;
using RecipeBook.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



builder.Services.AddCors(options =>

{

    options.AddPolicy(MyAllowSpecificOrigins,

               policy =>

               {

                   policy.WithOrigins("http://localhost:4200")

                           .AllowAnyHeader()

                           .AllowAnyMethod()

                           .AllowAnyOrigin();

               });

});





// Add services to the container.



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<RecipeBookDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecipeBookDbContextConnectionString")));



builder.Services.AddScoped<IRepository<Recipe>, RecipesRepository>();

builder.Services.AddScoped<IRepository<Category>,CategoriesRepository>();






var app = builder.Build();



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}





app.UseCors(MyAllowSpecificOrigins);



app.UseAuthorization();



app.MapControllers();







app.Run();




