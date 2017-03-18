using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.WebUI.Models;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository repository;
        public int PageSize = 3;

        public ProductsController(IProductRepository repo)
        {
            repository = repo;
        }

        // GET: Products
        public ViewResult List(string category, int page=1)
        {
            string s = Url.Action("List", new { page = 1, category = "woman" });

            if (category == null)
            {
                ProductsListViewModel model = new ProductsListViewModel
                {
                    Products = repository.Products.OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize),
                    pageInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Count()
                    },
                    CurrentCategory = category
                };
                return View(model);
            }
            else
            {
                ProductsListViewModel model = new ProductsListViewModel
                {
                    Products = repository.Products.Where(p => p.Category == category).OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize),
                    pageInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Count()
                    },
                    CurrentCategory = category
                };
                return View(model);
            }

            
        }
    }
}