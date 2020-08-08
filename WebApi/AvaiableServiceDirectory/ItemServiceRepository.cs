using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;

namespace WebApi.AvaiableServiceDirectory
{
    public class ItemServiceRepository : IItemServiceRepository
    {
        private readonly Context _context;
        public ItemServiceRepository(Context context)
        {
            _context = context;
        }
        public async Task AddItemSerivce(ItemService itemService)
        {
            await _context.Items.AddAsync(itemService);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task Get()
            => await Task.FromResult(_context.Items);

        public async Task Get(Guid id)
            => await Task.FromResult(_context.Items
                .FirstOrDefault(x => x.Id == id));

        public async Task Get(string name)
            => await Task.FromResult(_context.Items
                .FirstOrDefault(x => x.ServiceName == name));

        public async Task Remomve(ItemService itemService)
        {
            _context.Items.Remove(itemService);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task Update(ItemService itemService)
        {
            _context.Items.Update(itemService);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
