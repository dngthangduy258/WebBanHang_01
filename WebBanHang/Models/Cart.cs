using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanHang.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private List<CartItem> _items;
        public Cart()
        {
            _items = new List<CartItem>();
        }
        public List<CartItem> Items { get { return _items; } }
        //Các  phương thức xử lý 
        public void Add(Product p, int qty)
        {
            var item = _items.FirstOrDefault(x => x.Product.Id == p.Id);
            if (item == null)
            {
                _items.Add(new CartItem { Product = p, Quantity = qty });
            }
            else
            {
                item.Quantity += 1;
      
            }
        }
        public void Update(int productId,int qty)
        {
            var item = _items.FirstOrDefault(x => x.Product.Id == productId);
            if (item != null)
            {
                if (qty > 0)
                {
                    item.Quantity = qty;
                }
                else
                {
                    _items.Remove(item);
                }
            }
            
        }
        public void Delete(int productId)
        {
            var item = _items.FirstOrDefault(x => x.Product.Id == productId);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
        public double Total
        {
            get
            {
                double total = _items.Sum(x => x.Quantity * x.Product.Price);
                return total;
            }
        }
        public double Quatity
        {
            get
            {
                double quatity = _items.Sum(x => x.Quantity);
                return quatity;
            }
        }
    }
}
