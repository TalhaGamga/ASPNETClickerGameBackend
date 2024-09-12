using ClickerGameMVC.Common.DTOs.Item;

namespace ClickerGameMVC.Business.Abstract
{
    public interface IItemBusiness
    {
        ItemResponseDTO GetById(int id);
        ICollection<ItemResponseDTO> GetAll();
        public void Add(ItemCreateDTO itemCreateDTO);
        public void Update(ItemEditDTO itemEditDTO);
        public ItemResponseDTO Delete(int id);
    }
}
