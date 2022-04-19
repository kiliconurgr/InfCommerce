using InfCommerce.DAL.Entities;
using System.Collections.Generic;

namespace InfCommerce.WebUI.ViewModels
{
    public class FooterVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<News> Newses { get; set; }
    }
}
