using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LimestoneDigitalTask.Attributes;
using LimestoneDigitalTask.Services;

namespace LimestoneDigitalTask.Controllers
{
    [BaseExceptionAttritube]
    public class BaseController : Controller
    {
        protected ProductService productService { get; set; }
        protected CartService cartService { get; set; }
    }
}