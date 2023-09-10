using GarageDomain;

namespace GarageWebAPI.MapActions
{
    public class VehicleAction
    {
        public VehicleAction(WebApplication app)
        {
            app.MapGet("/Vehicles", (GarageContext db) => db.ReadVehicle());

            app.MapPost("/Vehicles", (Vehicle v, GarageContext db) =>
            {
                return Results.Created("/Vehicles", db.AddVehicle(v));
            });
            /*********************************************************************************************/
            app.MapGet("/Vehicles/{id}", (int id, GarageContext db) =>
            {
                var v = db.Vehicles.Find(id);

                if (v != null)
                    return Results.Ok(v);

                return Results.NotFound();
            });

            app.MapPut("/Vehicles/{id}", (int id, Vehicle v, GarageContext db) =>
            {
                var vehicle = db.UpdateVehicle(id, v);

                if (vehicle != null)
                    return Results.Ok(vehicle);

                return Results.NotFound();
            });

            app.MapDelete("/Vehicles/{id}", (int id, GarageContext db) =>
            {
                var v = db.DeleteVehicle(id);
                if (v != null)
                    return Results.Ok(v);

                return Results.NotFound();
            });
        }
    }
}
