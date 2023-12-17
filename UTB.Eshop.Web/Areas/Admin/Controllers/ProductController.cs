﻿using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        IProductAdminService _productAdminService;
        public ProductController(IProductAdminService productAdminService)
        {
            _productAdminService = productAdminService;
        }

        public IActionResult Index()
        {
            IList<Product> products = _productAdminService.Select();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productAdminService.Create(product);

            return RedirectToAction(nameof(ProductController.Index));
        }

        public IActionResult Delete(int Id)
        {
            bool deleted = _productAdminService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(ProductController.Index));
            }
            else
                return NotFound();
        }
    }
}
