using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamSite.Helpers;
using TeamSite.Models;
using TeamSite.Repositories.Abstractions;
using TeamSite.Repositories.Implementations;

namespace JP2.Store.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _productRepository;
        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var cart = GetCart();

            return View(cart);
        }

        public IActionResult AddToCart(int productId)
        {
            var product = _productRepository.GetProducts().FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                var cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }

            return RedirectToAction("Index");

        }

        public IActionResult RemoveFromCart(int productId)
        {
            var product = _productRepository.GetProducts().FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveItem(productId);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        private CartRepository GetCart()
        {
            CartRepository cart = HttpContext.Session.GetJson("Cart") ?? new CartRepository();

            return cart;
        }

        private void SaveCart(CartRepository cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
