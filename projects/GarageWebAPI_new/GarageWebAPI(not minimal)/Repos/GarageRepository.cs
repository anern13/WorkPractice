using GarageWebAPI;
using Microsoft.EntityFrameworkCore;

namespace GarageWebAPI_not_minimal_.Repos
{
    public class GarageRepository: Repository<Garage>
    {
        public GarageRepository(GarageContext db) : base(db)
        {}

        public override async Task<Garage?> PutAsync(Garage entity, int id)
        {
            var g = await base._context.Set<Garage>().FindAsync(id);
            if(g is not null)
                g.Name = entity.Name;

            await _context.SaveChangesAsync();

            return g;    
        }

    }
}
