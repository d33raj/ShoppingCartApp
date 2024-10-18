using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    internal class Order
    {
        public int Id { get; set; } 
        public DateTime Date {  get; set; }
        public List<LineItem> Items { get; set; }

        public Order(int id, DateTime date)
        {
            Id = id;
            Date = date;
            Items = new List<LineItem>();
        }

        public void AddLineItem(LineItem lineItem)
        {
            Items.Add(lineItem);
        }
        public double CalculateOrderPrice()
        {
            double total = 0;
            foreach (var item in Items)
            {
                total += item.CalculateItemCost();
            }
            return total;
        }
    }
}
