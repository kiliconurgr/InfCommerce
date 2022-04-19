using InfCommerce.BL.Repositories;
using InfCommerce.DAL.DbContexts;
using InfCommerce.DAL.Entities;
using InfCommerce.WebUI.Tools;
using InfCommerce.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InfCommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        SqlRepo<Product> repoProduct;
        public ProductController(SqlRepo<Product> _repoProduct)
        {
            repoProduct = _repoProduct;
        }
        public IActionResult Index()
        {
            //int notu = 60;
            //string durum;
            
            //if (notu > 50) durum = "Geçti"; else durum = "Kaldı";
            //durum = notu > 60 ? "Geçti" : "Kaldı";

            return View();
        }

        [Route("/urun/{name}-{id}")] //product/ali/Detail
        public IActionResult Detail(string name,int id)
        {
            Product product = repoProduct.GetAll().Include(i=>i.ProductPictures).FirstOrDefault(x => x.ID == id)??null;
            if (product != null) {
                DetailVM detailVM = new DetailVM { 
                    Product = product,
                    RelatedProducts= repoProduct.GetAll().Include(i => i.ProductPictures).Where(w=>w.BrandID==product.BrandID && w.ID!=product.ID).Take(5)
                };
                return View(detailVM);
            }
            else return Redirect("/");
        }
    }
}
