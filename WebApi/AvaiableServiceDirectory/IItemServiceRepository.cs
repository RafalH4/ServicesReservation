﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AvaiableServiceDirectory
{
    public interface IItemServiceRepository
    {
        Task AddItemSerivce(ItemService itemService);
        Task<IEnumerable<ItemService>> Get();
        Task<ItemService> Get(Guid id);
        Task<ItemService> Get(string name);
        Task Update(ItemService itemService);
        Task Remomve(ItemService itemService);
    }
}
