using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LimestoneDigitalTask.Models.DTO;
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
            var cart = new CartDTO();
            var cartId = Session["CartId"];
            var code = Request.QueryString["promocode"];
            if (string.IsNullOrEmpty(code))
            {
                if (cartId != null)
                {
                    cart = cartService.GetCart((int)cartId);
                }
            }
            else
            {
                if (cartId != null)
                {
                    cart = cartService.GetCart((int)cartId, code);
                }
            }

            return View(cart);
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
                Session["CartId"] = cartService.FindCartByEmail((string)email, productId);
            }
            else
            {
                Session["CartId"] = cartService.CreateCart(productId);
            }

            return Content("Product added to your cart!");
        }

        [HttpPost]
        public ActionResult SaveEmail(int id, string email)
        {
            cartService.SaveEmail(id, email);
            Session["Email"] = email;

            return Content("Email saved!");
        }

        [HttpPost]
        public ActionResult SavePromocode(int id, string promocode)
        {
            cartService.SavePromocode(id, promocode);

            return Content("Promocode saved!");
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            cartService.DeleteProduct(id);

            return Content("Product deleted from shopping cart!");
        }
    }
}