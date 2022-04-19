using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamSite.Helpers;
using TeamSite.Models;
using TeamSite.Repositories.Abstractions;
using TeamSite.Repositories.Implementations;

namespace TeamSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuyNow()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult BuyNow(Order order)
        {
            CartRepository cart = HttpContext.Session.GetJson("Cart");
            if (cart == null)
            {
                ModelState.AddModelError("", "Cart is empty");
                return View(order);
            }
            order.TotalPrice = cart.TotalPrice();
            order.Lines = cart.Lines.ToList();
            _orderRepository.AddOrder(order);
            return RedirectToAction("Completed");
        }

        public IActionResult Completed()
        {
            CartRepository cart = HttpContext.Session.GetJson("Cart");
            cart.Clear();
            HttpContext.Session.SetJson("Cart", cart);
            return View();
        }

        public IActionResult GetOrders()
        {
            var order = _orderRepository.GetOrders().ToList();

            return View(order);

        }
    }
}
