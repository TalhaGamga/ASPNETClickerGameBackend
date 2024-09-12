using AutoMapper;
using ClickerGameMVC.Common.DTOs.Item;
using ClickerGameMVC.Models;

namespace ClickerGameMVC.Common.MappingProfiles
{
    public class ItemMappingProfiles : Profile
    {
        public ItemMappingProfiles()
        {
            CreateMap<ItemCreateDTO, Item>();

            CreateMap<Item, ItemResponseDTO>();

            CreateMap<ItemEditDTO, Item>();
        }
    }
}
