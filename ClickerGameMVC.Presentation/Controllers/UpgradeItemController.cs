using ClickerGameMVC.Models;
using ClickerGameMVC.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace ClickerGameMVC.Presentation.Controllers
{
    public class UpgradeItemController : Controller
    {
        IUpgradeItemService upgradeItemService;

        public UpgradeItemController(IUpgradeItemService upgradeItemService)
        {
            this.upgradeItemService = upgradeItemService;
        }

        UpgradeItem GetById(int id)
        {
            return upgradeItemService.GetById(id);
        }

        ICollection<UpgradeItem> GetAll()
        {
            return upgradeItemService.GetAll();
        }

        void Add(UpgradeItem entity)
        {
            upgradeItemService.Add(entity);
        }

        void Update(UpgradeItem entity)
        {
            upgradeItemService.Update(entity);
        }

        void Delete(UpgradeItem entity)
        {
            upgradeItemService.Delete(entity);
        }
    }
}