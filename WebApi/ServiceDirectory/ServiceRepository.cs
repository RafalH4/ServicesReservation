using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;

namespace WebApi.ServiceDirectory
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;
        public ServiceRepository(Context context)
        {
            _context = context;
        }
        public async Task AddService(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Service> GetService(Guid id)
            => await Task.FromResult(_context.Services.FirstOrDefault(
                service => service.Id == id));

        public async Task<IEnumerable<Service>> GetServices()
            => await Task.FromResult(_context.Services.ToList());

        public async Task RemoveService(Service service)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateService(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
