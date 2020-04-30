using Microsoft.EntityFrameworkCore;
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

        public async Task AddListServices(List<Service> services)
        {
            await _context.Services.AddRangeAsync(services);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task AddService(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Service> GetService(Guid id)
            => await Task.FromResult(_context.Services
                .Include(x => x.Client)
                .Include(x => x.ServiceProvider)
                .Include(x => x.CreatedBy)
                .FirstOrDefault(service => service.Id == id));




        public async Task<IEnumerable<Service>> GetServices()
            => await Task.FromResult(_context.Services
                .Include(x => x.Client)
                .Include(x => x.ServiceProvider)
                .Include(x => x.CreatedBy)
                .ToList());

        public async Task<IEnumerable<Service>> GetServicesWithFilters(DateTime? startDate, DateTime? endDate, Guid? clientId, Guid? providerId)
        {
            var services = await Task.FromResult(_context.Services
                .Include(x => x.Client)
                .Include(x => x.ServiceProvider)
                .Include(x => x.CreatedBy)
                .ToList());

            if (startDate is DateTime newStartDate)
                services = services.Where(service => DateTime.Compare(service.Date, newStartDate) >= 0).ToList();
            if (endDate is DateTime newEndDate)
                services = services.Where(service => DateTime.Compare(service.Date, newEndDate) <= 0).ToList();
            if (clientId is Guid newClientId)
                services = services.Where(service => service.Client?.Id == newClientId).ToList();
            if (providerId is Guid newProviderId)
                services = services.Where(service => service.ServiceProvider?.Id == newProviderId).ToList();
            
            return services.OrderBy(d => d.Date);
        }

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
