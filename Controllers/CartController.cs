using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StoneStore.Data;
using StoneStore.Models;
using StoneStore.Utility;

namespace StoneStore.Controllers
{
    public class CartController : Controller
    {
        private readonly StoneDbContext _db;
        
        public CartController(StoneDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Any())
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }

            List<int> prodInCart = shoppingCartList.Select(i => i.ProductId).ToList();
            IEnumerable<Product> prodList = _db.Product.Where(u => prodInCart.Contains(u.Id));
            
            return View(prodList);
        }
    }
}