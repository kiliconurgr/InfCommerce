using InfCommerce.BL.Repositories;
using InfCommerce.DAL.DbContexts;
using InfCommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InfCommerce.WebUI.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        SqlRepo<Category> repoCategory;
        public HeaderViewComponent(SqlRepo<Category> _repoCategory)
        {
            repoCategory = _repoCategory;
        }
        public IViewComponentResult Invoke()
        {
            return View(repoCategory.GetAll());  
        }
    }
}
