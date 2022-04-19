using InfCommerce.BL.Repositories;
using InfCommerce.DAL.DbContexts;
using InfCommerce.DAL.Entities;
using InfCommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InfCommerce.WebUI.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        SqlRepo<Brand> repoBrand;
        SqlRepo<News> repoNews;
        public FooterViewComponent(SqlRepo<Brand> _repoBrand, SqlRepo<News> _repoNews)
        {
            repoBrand = _repoBrand;
            repoNews = _repoNews;
        }
        public IViewComponentResult Invoke()
        {
            FooterVM footerVM = new FooterVM { 
                Brands= repoBrand.GetAll(),
                Newses=repoNews.GetAll().OrderByDescending(o=>o.RecDate).Take(2)
            }; 
            return View(footerVM);
        }
    }
}
