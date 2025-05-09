using CoffeeBeansDemo.Application;
using CoffeeBeansDemo.Infrastructure;
using CoffeeBeansDemo.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices();
builder.Services.AddDbContext<CoffeeBeansDemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeBeansDbConnection"))
    .ConfigureWarnings(w => w.Ignore(SqlServerEventId.SavepointsDisabledBecauseOfMARS))
);
builder.Services.AddInfrastructureServiceInjector();
builder.Services.AddApplicationServices();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .WithOrigins("http://localhost",
                "http://localhost:4200",
                "https://localhost:8080",
                "http://localhost:8080",
                "http://localhost:5173",
                "https://localhost:5173",
                "https://localhost:7285")
            .AllowAnyMethod()
          .AllowCredentials()
          .AllowAnyHeader();


        });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
