using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AvaiableServiceDirectory
{
    public interface IItemServiceRepository
    {
        Task AddItemSerivce(ItemService itemService);
        Task Get();
        Task Get(Guid id);
        Task Get(string name);
        Task Update(ItemService itemService);
        Task Remomve(ItemService itemService);
    }
}
