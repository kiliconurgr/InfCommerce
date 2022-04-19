using InfCommerce.DAL.Entities;
using System.Collections.Generic;

namespace InfCommerce.WebUI.ViewModels
{
    public class DetailVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}
