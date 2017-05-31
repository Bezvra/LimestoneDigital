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
            var products = productService.GetProducts();
            return View();
        }
    }
}