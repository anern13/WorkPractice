using Microsoft.EntityFrameworkCore;
using OneToOne;

using (var db = new GarageContext())
{
    //db.Workers.Add(new Worker("Yossi") { Vehicle = new Vehicle("chevrolet") });
    //db.SaveChanges();

    //db.Workers.Add(new Worker("Dannei"));
    //db.SaveChanges();

    //db.Vehicles.Add(new Vehicle("Honda"));
    //db.SaveChanges();


    var w = db.Workers.Include(w => w.Vehicle).Where(w => w.Id == 3);
    //db.Workers.Remove(w);
    //db.SaveChanges();

}