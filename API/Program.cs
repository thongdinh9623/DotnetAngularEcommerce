using API.Data.Seeders;
using API.Entities;
using API.Extensions;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    var userMongoDbService = app.Services.GetRequiredService<MongoDBService<User>>();
    userMongoDbService.CollectionName = "users";
    await MongoDbDataSeeder.SeedUser(userMongoDbService);
    var productMongoDbService = app.Services.GetRequiredService<MongoDBService<Product>>();
    productMongoDbService.CollectionName = "products";
    await MongoDbDataSeeder.SeedProduct(productMongoDbService);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200"));

app.Run();
