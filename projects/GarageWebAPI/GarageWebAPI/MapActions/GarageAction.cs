using GarageDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageWebAPI.MapActions
{
    public class GarageAction
    {
        public GarageAction(WebApplication app)
        {
            app.MapGet("/Garages", (GarageContext db) =>
            {
                return db.Garages.ToList();
            });

            app.MapPost("/Garages", (Garage g, GarageContext db) =>
            {
                db.Garages.Add(g);
                db.SaveChanges();

                return Results.Created("/Garages", g);
            });

            /*********************************************************************************************/
            app.MapGet("/Garages/{id}", (int id, GarageContext db) =>
            {
                var g = db.Garages.Find(id);
                if (g != null)
                    return Results.Ok(g);

                return Results.NotFound();
            });

            app.MapPut("/Garages/{id}", (int id, Garage g, GarageContext db) =>
            {
                var garage = db.Garages.Find(id);
                if (garage == null)
                    return Results.NotFound();

                garage.Name = g.Name;

                db.SaveChanges();

                return Results.Ok(garage);
            });

            app.MapDelete("/Garages/{id}", (int id, GarageContext db) =>
            {
                var garage = db.Garages.Find(id);
                if (garage == null)
                    return Results.NotFound();

                db.Garages.Remove(garage);
                db.SaveChanges();

                return Results.Ok(garage);
            });

            app.MapGet("/Garages/{id}/Workers", (int id, GarageContext db) =>
            {
                var garage = db.Garages.Include(g => g.Workers)
                   .FirstOrDefault(g => g.GarageId == id);

                if (garage != null)
                {
                    var ret = new List<int>();

                    foreach (var w in garage.Workers)
                    {
                        ret.Add(w.WorkerId);
                    }

                    return Results.Ok(ret);
                }

                return Results.NotFound();
            });

            app.MapPut("/Garages/{id}/Workers/{w_id}", (int id, int w_id, GarageContext db) =>
            {
                return WorkerAction.AddWorkerToGarage(w_id, id, db);
            });

            app.MapDelete("/Garages/{id}/Workers/{w_id}", (int id, int w_id, GarageContext db) => 
            {
                return WorkerAction.RemoveWokerFromGarage(w_id, id, db);
            });

            app.MapGet("/Garages/{id}/Vehicles", (int id, GarageContext db) =>
            {
                var garage = db.Garages.Include(g => g.Vehicles)
                   .FirstOrDefault(g => g.GarageId == id);

                if (garage != null)
                {
                    var ret = new List<int>();

                    foreach (var v in garage.Vehicles)
                    {
                        ret.Add(v.VehicleId);
                    }

                    return Results.Ok(ret);
                }

                return Results.NotFound();
            });

            app.MapPut("/Garages/{id}/Vehicles/{v_id}", (int id, int v_id, GarageContext db) =>
            {
                return AddVehicle(id, v_id, db);
            });

            app.MapDelete("/Garages/{id}/Vehicles/{v_id}", (int id, int v_id, GarageContext db) =>
            {
                return RemoveVehicle(id, v_id, db);
            });

        }

        public static IResult AddVehicle(int garageid, int vehicleid, GarageContext db)
        {
            var garage = db.Garages.Find(garageid);
            var vehicle = db.Vehicles.Find(vehicleid);

            if (garage != null && vehicle != null) 
            {
                vehicle.GarageId = garageid;
                db.SaveChanges();

                return Results.Ok(vehicle);
            }

            return Results.NotFound();
        }

        public static IResult RemoveVehicle(int garageid, int vehicleid, GarageContext db)
        {
            var garage = db.Garages.Find(garageid);
            var vehicle = db.Vehicles.Find(vehicleid);

            if (garage != null && vehicle != null)
            {
                vehicle.GarageId = null;
                db.SaveChanges();

                return Results.Ok(vehicle);
            }

            return Results.NotFound();
        }
    }
}
