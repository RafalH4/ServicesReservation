using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AvaiableServiceDirectory.Dtos;

namespace WebApi.AvaiableServiceDirectory
{
    public interface IItemServiceService
    {
        Task Add(AddItemServiceDto itemService);
        Task<IEnumerable<ItemService>> Get();
        Task<ItemService> Get(Guid id);
        Task<ItemService> Get(string name);
        Task Update(ItemService itemService);
        Task Remove(Guid id);

    }
}
