using GarageWebAPI;
using Microsoft.EntityFrameworkCore;

namespace GarageWebAPI_not_minimal_.Repos
{
    public class WorkerRepository : Repository<Worker>
    {  
        public WorkerRepository(GarageContext db) : base(db)
        { }

        public override async Task<Worker?> PutAsync(Worker entity, int id)
        {
            var w = await base._context.Set<Worker>().FindAsync(id);
            if (w is not null)
                w.WorkerName = entity.WorkerName;

            await _context.SaveChangesAsync();

            return w;
        }

        
    }
}
