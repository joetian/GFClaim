using OnlineShoppingStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class NavsController : Controller
    {
        private IProductRepository repository;

        public NavsController(IProductRepository repo)
        {
            repository = repo;
        }

        // GET: Navs
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);    // 用此Action对应的MenuView传说categories，由 Menu view 返回
        }
    }
}