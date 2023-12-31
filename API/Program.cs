using API.Data;
using API.Data.Destroyers;
using API.Data.Seeders;
using API.Entities;
using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var userMongoDbService
        = app.Services.GetRequiredService<MongoDbService<User>>();
    userMongoDbService.CollectionName = "users";
    var productMongoDbService
        = app.Services.GetRequiredService<MongoDbService<Product>>();
    productMongoDbService.CollectionName = "products";

    // Destroy data
    await MongoDbDataDestroyer.DestroyUser(userMongoDbService);
    await MongoDbDataDestroyer.DestroyProduct(productMongoDbService);

    // Seed data
    await MongoDbDataSeeder.Seed(productMongoDbService, userMongoDbService);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200"));

app.Run();
