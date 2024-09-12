using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Common.DTOs.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickerGameMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        IItemBusiness _itemBusiness;

        public ItemController(IItemBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Get All Item Info")]
        public ActionResult<ICollection<ItemResponseDTO>> GetAll()
        {
            var items = _itemBusiness.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetById(int id)
        {
            var itemResponseDTO = _itemBusiness.GetById(id);
            return Ok(itemResponseDTO);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Update([FromBody] ItemEditDTO itemEditDTO)
        {
            _itemBusiness.Update(itemEditDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var itemResponseDTO = _itemBusiness.Delete(id);
            return Ok(itemResponseDTO);
        }
    }
}
