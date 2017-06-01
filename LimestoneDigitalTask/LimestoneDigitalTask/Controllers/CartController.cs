using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LimestoneDigitalTask.Services;

namespace LimestoneDigitalTask.Controllers
{
    public class CartController : BaseController
    {
        public CartController(CartService cart)
        {
            cartService = cart;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            var cartId = Session["CartId"];
            var email = Session["Email"];
            if (cartId != null)
            {
                cartService.AddToCart((int)cartId, productId);
            }
            else if (email != null)
            {
                Session["CartId"] = cartService.FindCartByEmail((string) email, productId);
            }
            else
            {
                Session["CartId"] = cartService.CreateCart(productId);
            }

            return Content("Product added to your cart!");
        }
    }
}