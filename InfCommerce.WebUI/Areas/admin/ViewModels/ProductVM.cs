using InfCommerce.DAL.Entities;
using System.Collections.Generic;

namespace InfCommerce.WebUI.Areas.admin.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
