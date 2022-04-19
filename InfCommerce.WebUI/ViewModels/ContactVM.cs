using InfCommerce.DAL.Entities;
using System.Collections.Generic;

namespace InfCommerce.WebUI.ViewModels
{
    public class ContactVM
    {
        public Contact Contact { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
