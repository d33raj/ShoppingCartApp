using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPercent { get; set; }

        public Product(int id, string name, double price, double discountPrice)
        {
            Id= id;
            Name= name;
            Price= price;
            DiscountPercent= discountPrice;
        }

        public double calculateDiscountedPrice()
        {
            return Price - (Price * DiscountPercent / 100);
        }

    }
}
