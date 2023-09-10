// See https://aka.ms/new-console-template for more information


using Microsoft.EntityFrameworkCore;
using Garage;

using (var context = new GarageContext())
{
    context.Database.Migrate();

    //AddWorker(new Worker { Name = "yosi" }).Vehicles.Add(new Vehicle { Model = "Civic", PlateNumber = 1234569890 });
    context.Vehicles.Add(new Vehicle { Model = "Civic", PlateNumber = 2000000000 ,WorkerId = 1});
    context.Vehicles.i
    context.SaveChanges();

    
    Worker AddWorker(Worker worker)
    {
        context.Add(worker);
        context.SaveChanges();

        return worker;
    }
}