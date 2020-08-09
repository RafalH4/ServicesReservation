using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AvaiableServiceDirectory.Dtos;

namespace WebApi.AvaiableServiceDirectory
{
    public class ItemServiceService : IItemServiceService
    {
        private readonly IItemServiceRepository _itemServiceRepository;
        private readonly IMapper _mapper;
        public ItemServiceService(IItemServiceRepository itemServiceRepository,
            IMapper mapper)
        {
            _itemServiceRepository = itemServiceRepository;
            _mapper = mapper;
        }
        public async Task Add(AddItemServiceDto itemService)
        {
            var tempItem = await _itemServiceRepository.Get(itemService.ServiceName);
            if (tempItem != null)
                throw new Exception("Bad service name");
            var itemToDb = _mapper.Map<AddItemServiceDto, ItemService>(itemService);
            await _itemServiceRepository.AddItemSerivce(itemToDb);
            
        }

        public async Task<IEnumerable<ItemService>> Get()
            => await _itemServiceRepository.Get();

        public async Task<ItemService> Get(Guid id)
        {
            var item = await _itemServiceRepository.Get(id);
            if (item == null)
                throw new Exception("Bad id");
            return item;
        }

        public async Task<ItemService> Get(string name)
        {
            var item = await _itemServiceRepository.Get(name);
            if (item == null)
                throw new Exception("Bad id");
            return item;
        }

        public async Task Remove(Guid id)
        {
            var item = await _itemServiceRepository.Get(id);
            if (item == null)
                throw new Exception("Bad id");
            await _itemServiceRepository.Remomve(item);
        }

        public async Task Update(ItemService itemService)
        {
            var newItem = await _itemServiceRepository.Get(itemService.Id);
            if (newItem == null)
                throw new Exception("Bad Id");
            newItem.ServiceName = itemService.ServiceName;
            newItem.DurationInMinutes = itemService.DurationInMinutes;
        }
    }
}
