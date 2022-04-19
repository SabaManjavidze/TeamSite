using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamSite.Models.ViewModels;
using TeamSite.Repositories.Abstractions;

namespace TeamSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        int PageSize = 3;
        public IActionResult Shop(string category, int productPage = 1)
        {
            var products = _productRepository.GetProducts()
                                             .Where(p => p.Category.ToString() == category || string.IsNullOrWhiteSpace(category));
            ListWithPaging listWithPaging = new ListWithPaging();

            var totalItems = products.Count();

            var TotalPages = (int)Math.Ceiling((decimal)totalItems / PageSize);
            products = products.Skip((productPage - 1) * PageSize).Take(PageSize);

            var pagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                TotalItems = totalItems,
                TotalPages = TotalPages,
                ItemPerPage = PageSize
            };

            listWithPaging.products = products;
            listWithPaging.PagingInfo = pagingInfo;


            return View(listWithPaging);
        }
    }
}
