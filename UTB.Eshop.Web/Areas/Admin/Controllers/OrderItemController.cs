﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity.Enums;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class OrderItemController : Controller
    {
        IOrderItemService _orderItemService;
        IProductAdminService _productService;
        IOrderService _orderService;
        public OrderItemController(IOrderItemService orderItemService, IProductAdminService productService, IOrderService orderService)
        {
            _orderItemService = orderItemService;
            _productService = productService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            IList<OrderItem> orderItems = _orderItemService.Select();
            return View(orderItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SetOrderAndProductSelectLists();
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _orderItemService.Create(orderItem);
                return RedirectToAction(nameof(OrderItemController.Index));
            }
            else
            {
                SetOrderAndProductSelectLists();
                return View(orderItem);
            }
        }

        void SetOrderAndProductSelectLists()
        {
            IList<Product> products = _productService.Select();
            ViewData[nameof(OrderItem.ProductID)] = new SelectList(products, nameof(Product.Id), nameof(Product.Name));

            IList<Order> orders = _orderService.Select();
            ViewData[nameof(OrderItem.OrderID)] = new SelectList(orders, nameof(Order.Id), nameof(Order.OrderNumber));
        }
    }
}

