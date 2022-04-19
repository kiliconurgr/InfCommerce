using InfCommerce.BL.Repositories;
using InfCommerce.DAL.Entities;
using InfCommerce.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace InfCommerce.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class ProductController : Controller
    {
        SqlRepo<Product> repoProduct;
        SqlRepo<Brand> repoBrand;
        public ProductController(SqlRepo<Product> _repoProduct, SqlRepo<Brand> _repoBrand)
        {
            repoProduct = _repoProduct;
            repoBrand = _repoBrand;
        }

        public IActionResult Index()
        {
            return View(repoProduct.GetAll().OrderByDescending(o=>o.ID));
        }

        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM
            {
                Product = new Product(),
                Brands = repoBrand.GetAll()
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM model)
        {
            if (ModelState.IsValid)
            {

                repoProduct.Add(model.Product);

            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ProductVM productVM = new ProductVM
            {
                Product = repoProduct.GetBy(x => x.ID == id),
                Brands = repoBrand.GetAll()
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Update(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                repoProduct.Update(model.Product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repoProduct.Remove(repoProduct.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
