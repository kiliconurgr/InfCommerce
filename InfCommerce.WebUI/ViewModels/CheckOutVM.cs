using InfCommerce.DAL.Entities;
using InfCommerce.WebUI.Models;
using System.Collections.Generic;

namespace InfCommerce.WebUI.ViewModels
{
    public class CheckOutVM
    {
        public Order Order { get; set; }
        public List<Cart> Carts { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
