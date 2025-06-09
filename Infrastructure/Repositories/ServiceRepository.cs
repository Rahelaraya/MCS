using Application.DTO;
using Application.Interface;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceDto>> GetAllAsync()

        {
            var services = await _context.Services.ToListAsync();
            return services.Select(s => new ServiceDto
            {
                Id = s.Id,
                NameofService = s.Name,
                DescriptionofService = s.Description,
                PriceofService = s.Price
            });


        }


        public Task AddAsync(int userId, ServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



        public Task<ServiceDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ServiceExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ServiceDto serviceDto)
        {
            throw new NotImplementedException();
        }


    }
}
