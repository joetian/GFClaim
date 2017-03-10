using GFClaim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GFClaim.ViewModels;

namespace GFClaim.Controllers
{
    public class ProvidersController : Controller
    {
        ApplicationDbContext dbContext;

        public ProvidersController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: Providers
        public ActionResult Index()
        {
            // Provider class引用ProviderType, 需要用Include方法，该方法定义在using System.Data.Entity里
            IEnumerable<Provider> providers = dbContext.Providers.Include(p => p.ProviderType).ToList();
            return View(providers);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            var providerInDb = dbContext.Providers.Include(p=>p.ProviderType).SingleOrDefault(p => p.Id == id);
            if (providerInDb == null)
                return HttpNotFound();
            return View(providerInDb);
        }

        public ActionResult New()
        {
            // New/Edit的View里需传递ProviderType，所以需要传ProviderTypeViewModel，而不是仅仅Provider, 添加using GFClaim.ViewModels;//
            ProviderFormViewModel providerFormViewModel = new ProviderFormViewModel
            {
                ProviderTypes = dbContext.ProviderTypes.ToList(),
                Provider = new Provider()
            };
            return View("ProviderForm", providerFormViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            var provider = dbContext.Providers.SingleOrDefault(p => p.Id == id);
            if (provider == null)
                return HttpNotFound();

            ProviderFormViewModel providerFormViewModel = new ProviderFormViewModel
            {
                ProviderTypes = dbContext.ProviderTypes.ToList(),
                Provider = provider
            };
            return View("ProviderForm", providerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // AntiForgeryToken俩步走，1. 在VIEW里添加@Html.AntiForgeryToken()    2. 在action上加入attribute [ValidateAntiForgeryToken] 
        public ActionResult Save(ProviderFormViewModel p)
        {
            // Validation三步走的第二步，1.在model class的属性上加，2. 在controller的POST SAVE里加ModelState.IsValid,
            //3. 在View里加@Html.ValidationMessageFor和客户端验证 @Scripts.Render("~/bundles/jqueryval")
            if (!ModelState.IsValid)
            {
                ProviderFormViewModel providerFormViewModel = new ProviderFormViewModel
                {
                    Provider = p.Provider,
                    ProviderTypes = dbContext.ProviderTypes
                };
                // 验证不成功，返回原来的VIEW，并保留填入的数据。
                return View("ProviderForm", providerFormViewModel);
            }

            // New Provider
            if (p.Provider.Id == 0)
            {
                dbContext.Providers.Add(p.Provider);
            }
            else
            {
                Provider providerInDb = dbContext.Providers.Single(pDb => pDb.Id == p.Provider.Id);
                providerInDb.Name = p.Provider.Name;
                providerInDb.Phone = p.Provider.Phone;
                providerInDb.ProviderTypeId = p.Provider.ProviderTypeId;
                providerInDb.Address1 = p.Provider.Address1;
                providerInDb.Address2 = p.Provider.Address2;
                providerInDb.City = p.Provider.City;
                providerInDb.State = p.Provider.State;
                providerInDb.Zipcode = p.Provider.Zipcode;
                providerInDb.TaxIdentity = p.Provider.TaxIdentity;

            }
            dbContext.SaveChanges();

            // 验证成功，上代码保存数据库，下面返回到主页面
            return RedirectToAction("Index", "Providers");
        }

        public ActionResult Delete(int id)
        {
            var Provider = dbContext.Providers.SingleOrDefault(p => p.Id == id);
            if (Provider == null)
                return HttpNotFound();

            dbContext.Providers.Remove(Provider);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Providers");
        }



    }
}