using GarageWebAPI;
using GarageDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using GarageWebAPI.MapActions;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<GarageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source = (localdb)\\\\MSSQLLocalDB; Initial Catalog = GarageServerDB")));

    var app = builder.Build();

    app.MapGet("/", () => "Wellcom to the GarageWebAPI");

    //Vehicles/////////////////////////////////////////////////////////////////////////////////////
    new VehicleAction(app);
    //Garages//////////////////////////////////////////////////////////////////////////////////////
    new GarageAction(app);
    //Workers//////////////////////////////////////////////////////////////////////////////////////
    new WorkerAction(app);


    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}" +
        $"{ex.StackTrace}" +
        $"{ex.Source}");
}

