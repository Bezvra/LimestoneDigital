using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LimestoneDigitalTask.Helpers;
using LimestoneDigitalTask.Models.DTO;
using LimestoneDigitalTask.Services;
using Microsoft.Ajax.Utilities;

namespace LimestoneDigitalTask.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ProductService product)
        {
            productService = product;
        }

        public ActionResult Index()
        {
            var code = Request.QueryString["promocode"];
            var products = string.IsNullOrEmpty(code) ? productService.GetProducts() : productService.GetProducts(code);

            return View(products);
        }

        public ActionResult Product()
        {
            return View();
        }
    }
}