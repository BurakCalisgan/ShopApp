using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopApp.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        #region Index

        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region AddToCart

        [HttpPost]
        public IActionResult AddToCart()
        {
            return View();
        }

        #endregion
    }
}