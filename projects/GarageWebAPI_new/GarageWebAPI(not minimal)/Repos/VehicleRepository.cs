using GarageWebAPI;
using GarageWebAPI_not_minimal_.DTO;
using Microsoft.EntityFrameworkCore;

namespace GarageWebAPI_not_minimal_.Repos
{
    public class VehicleRepository : Repository<Vehicle>
    {
        public VehicleRepository(GarageContext db) : base(db)
        {}

        public override async Task<Vehicle?> PutAsync(Vehicle entity, int id)
        {
            var v = await base._context.Set<Vehicle>().FindAsync(id);
            if (v is not null)
                v.Model = entity.Model;

            await _context.SaveChangesAsync();

            return v;
        }
    }
}
