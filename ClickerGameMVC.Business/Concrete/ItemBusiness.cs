using AutoMapper;
using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Common.DTOs.Item;
using ClickerGameMVC.Models;
using ClickerGameMVC.Service.Abstract;

namespace ClickerGameMVC.Business.Concrete
{
    public class ItemBusiness : IItemBusiness
    {
        IService<Item> _itemService;
        IMapper _mapper;

        public ItemBusiness(IService<Item> itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        public void Add(ItemCreateDTO itemCreateDTO)
        {
            var item = _mapper.Map<Item>(itemCreateDTO);
            _itemService.Add(item);
        }

        public ICollection<ItemResponseDTO> GetAll()
        {
            var items = _itemService.GetAll();
            var responseDTOs = _mapper.Map<List<ItemResponseDTO>>(items);

            return responseDTOs;
        }

        public ItemResponseDTO GetById(int id)
        {
            var item = _itemService.GetById(id);
            var responseDTO = _mapper.Map<ItemResponseDTO>(item);

            return responseDTO;
        }

        public void Update(ItemEditDTO itemEditDTO)
        {
            var item = _itemService.GetById(itemEditDTO.Id);
            _mapper.Map(itemEditDTO, item);
            _itemService.Update(item);
        }

        public ItemResponseDTO Delete(int id)
        {
            var item = _itemService.Delete(id);

            return new ItemResponseDTO
            {
                Name = item.Name,
                Type = item.Type,
                Description = item.Description,
                Level = item.Level,
                Price = item.Price
            };
        }
    }
}
