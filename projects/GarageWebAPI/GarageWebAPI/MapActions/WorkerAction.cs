using GarageDomain;
using Microsoft.EntityFrameworkCore;
using System;

namespace GarageWebAPI.MapActions
{
    public class WorkerAction
    {
        public WorkerAction(WebApplication app)
        {
            app.MapGet("/Workers", (GarageContext db) =>
            {
                return db.Workers.ToList();
            });

            app.MapPost("/Workers", (Worker w, GarageContext db) =>
            {
                db.Workers.Add(w);
                db.SaveChanges();

                return Results.Created("/Workers", w);
            });

            /*********************************************************************************************/
            app.MapGet("/Workers/{id}", (int id, GarageContext db) =>
            {
                var worker = db.Workers.Find(id);
                if (worker != null)
                    return Results.Ok(worker);

                return Results.NotFound();
            });

            app.MapPut("/Workers/{id}", (int id, Worker w, GarageContext db) =>
            {
                var worker = db.Workers.Find(id);
                if (worker != null)
                {
                    worker.WorkerName = w.WorkerName;

                    db.SaveChanges();

                    return Results.Ok(worker);
                }

                return Results.NotFound();
            });

            app.MapDelete("/Workers/{id}", (int id, GarageContext db) =>
            {
                var worker = db.Workers.Find(id);
                if (worker != null)
                {
                    db.Workers.Remove(worker);
                    db.SaveChanges();

                    return Results.Ok(worker);
                }

                return Results.NotFound();
            });

            app.MapGet("/Workers/{id}/Garages", (int id, GarageContext db) =>
            {
                var worker = db.Workers.Include(w => w.Garages)
                   .FirstOrDefault(w => w.WorkerId == id);
                if (worker != null)
                {
                    var ret = new List<int>();

                    foreach (var g in worker.Garages)
                    {
                        ret.Add(g.GarageId);
                    }

                    return Results.Ok(ret);
                }

                return Results.NotFound();
            });


            app.MapPut("/Workers/{id}/Garages/{g_id}", (int id, int g_id, GarageContext db) =>
            {
                return AddWorkerToGarage(id, g_id, db);
            });

            app.MapDelete("/Workers/{id}/Garages/{g_id}", (int id, int g_id, GarageContext db) =>
            {
                return RemoveWokerFromGarage(id, g_id, db);
            });
        }

        public static IResult AddWorkerToGarage(int workerid, int garageid, GarageContext db)
        {
            var garage = db.Garages.Find(garageid);
            var worker = db.Workers.Find(workerid);

            if (worker != null && garage != null)
            {
                worker.Garages.Add(garage);
                db.SaveChanges();

                return Results.Ok();
            }

            return Results.NotFound();
        }

        public static IResult RemoveWokerFromGarage(int workerid, int garageid, GarageContext db)
        {
            var worker = db.Workers
                    .Include(w => w.Garages)
                    .Where(w => w.WorkerId == workerid)
                    .FirstOrDefault();

            if (worker != null)
            {
                var garage = worker.Garages.Where(g => g.GarageId == garageid).FirstOrDefault();
                if (garage != null)
                {
                    worker.Garages.Remove(garage);
                    db.SaveChanges();

                    return Results.Ok(garage);
                }
            }

            return Results.NotFound();
        }

    }
}
