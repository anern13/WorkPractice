// See https://aka.ms/new-console-template for more information
using GarageLib;
using Microsoft.EntityFrameworkCore;

using (var db = new GarageContext())
{
    //db.Database.Migrate();



}








    //var ve = new Vehicle { Model = "Ferari" };
    //ve.Workers.Add(new Worker { WorkerName = "Yosi"});
    //db.Vehicles.Add(ve);

    //db.Workers.Add(new Worker { WorkerName = "Guy" });
    //db.SaveChanges();

    //var buisy_wirkers = db.Workers.Include(w => w.Vehicles).Where(w => w.Vehicles.Count() > 0).ToList();
    //foreach(var w in buisy_wirkers)
    //{
    //    Console.WriteLine($"{w.WorkerName}  {w.Vehicles.Count()}");
    //}

    //var yosi = db.Workers.FirstOrDefault(w => w.WorkerName == "Yosi");
    //if (yosi != null)
    //{
    //    yosi.Vehicles.Add(new Vehicle { Model = "Volvo" });
    //    db.SaveChanges();
    //}

    //var yosi = db.Workers.Include(w => w.Vehicles)
    //    .FirstOrDefault(w => w.WorkerName == "Yosi");
    //if (yosi != null) 
    //{
    //    yosi .Vehicles = new List<Vehicle>();
    //    db.SaveChanges();
    //}


    //yosi = db.Workers
    //    .Include(w => w.Vehicles.Where(v => v.Model == "Volvo"))
    //    .FirstOrDefault(w => w.WorkerName == "Yosi");
    //if (yosi != null)
    //{
    //    yosi.Vehicles.RemoveAt(0);
    //    db.SaveChanges();
    //}