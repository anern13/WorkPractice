using GarageWebAPI;
using GarageWebAPI_not_minimal_.Repos;
using Microsoft.EntityFrameworkCore;


var AllOrigins = "ALLOrigins";
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<GarageContext>
    (options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = GarageDBNew")));

builder.Services.AddTransient<IRepository<Garage>, GarageRepository>();
builder.Services.AddTransient<IRepository<Worker>, WorkerRepository>();
builder.Services.AddTransient<IRepository<Vehicle>, VehicleRepository>();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllOrigins,
    policy =>
    {
        //WithOrigins("http://127.0.0.1:5500/index.htm")//example
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
                    
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
