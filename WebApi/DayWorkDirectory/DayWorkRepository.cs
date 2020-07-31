using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;

namespace WebApi.DayWorkDirectory
{
    public class DayWorkRepository : IDayWorkRepository
    {
        private readonly Context _context;
        public DayWorkRepository(Context context)
        {
            _context = context;
        }
        public async Task Add(DayWork dayWork)
        {
            await _context.DayWorks.AddAsync(dayWork);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<DayWork>> Get()
            => await Task.FromResult(_context.DayWorks
                .Include(x => x.Services)
                .ToList());

        public async Task<DayWork> Get(Guid id)
            => await Task.FromResult(_context.DayWorks
                .Include(x => x.Services)
                .FirstOrDefault(x => x.Id == id));

        public async Task<IEnumerable<DayWork>> Get(DateTime startDateTime, DateTime endDateTime)
            => await Task.FromResult(_context.DayWorks
                .Include(x => x.Services)
                .Where(service => DateTime.Compare(service.StartDateTime, startDateTime) >= 0)
                .Where(service => DateTime.Compare(service.StartDateTime, endDateTime) >= 1)
                .ToList());
        public async Task Update(DayWork dayWork)
        {
            _context.DayWorks.Update(dayWork);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task Remove(DayWork dayWork)
        {
            _context.DayWorks.Remove(dayWork);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

    }
}
