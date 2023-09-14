using GarageWebAPI;
using GarageWebAPI_not_minimal_.DTO;
using Microsoft.EntityFrameworkCore;

namespace GarageWebAPI_not_minimal_.Repos
{
    public class GarageEntityRepository : IRepository<GarageEntity>
    {
        private readonly GarageContext _context;
        public GarageEntityRepository(GarageContext context) 
        {
            _context = context;
        }
        public Task<GarageEntity?> DeleteAsync(int id)
        {
            
        }

        public Task<IEnumerable<GarageEntity>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GarageEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GarageEntity?> PostAsync(GarageEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<GarageEntity?> PutAsync(GarageEntity entity, int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
