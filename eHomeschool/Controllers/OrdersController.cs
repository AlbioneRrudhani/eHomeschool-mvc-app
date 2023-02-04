﻿using eHomeschool.Data.Cart;
using eHomeschool.Data.Service;
using eHomeschool.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eHomeschool.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(ICourseService courseService, ShoppingCart shoppingCart)
        {
            _courseService = courseService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
    }
}