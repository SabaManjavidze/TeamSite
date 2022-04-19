using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models;
using TeamSite.Repositories.Abstractions;

namespace TeamSite.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private List<CartLine> cartLineList = new List<CartLine>();
        
        public void AddItem(Product product, int quantity)
        {
            CartLine line = cartLineList.FirstOrDefault(cartline => cartline.product.Id == product.Id);

            if (line == null)
            {
                CartLine cartLine = new CartLine()
                {
                    product = product,
                    Quantity = quantity,
                };
                cartLineList.Add(cartLine);
            }
            else
            {
                line.Quantity += quantity;
            }
        }


        public void RemoveItem(int productId) => cartLineList.RemoveAll(l => l.product.Id == productId);

        public decimal TotalPrice() => cartLineList.Sum(l => l.product.Price * l.Quantity);

        public void Clear() => cartLineList.Clear();

        public IEnumerable<CartLine> Lines => cartLineList;

        public class CartLine
        {
            public Product product { get; set; }

            public int Quantity { get; set; }

            public int Id { get; set; }

        }
    }
}
