using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiscellaneousShop.Models;
using PagedList;

namespace MiscellaneousShop.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index(int? page, string keyword, int? catId)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            MiscellaneousShopEntities MSE = new MiscellaneousShopEntities();
            var result = (from p in MSE.Products
                          select new FrontViewProductModel {
                                ProductId = p.id,
                                ProductName = p.ProductName, 
                                CurrentPrice = p.CurrentPrice,
                                Color = p.Color,
                                ProductMainPhoto = p.ProductMainPhoto}).ToList();

            if (!String.IsNullOrEmpty(keyword))
            {
                result = (from p in MSE.Products
                          where (p.ProductName.ToUpper().Contains(keyword.ToUpper()))
                          select new FrontViewProductModel
                          {
                              ProductId = p.id,
                              ProductName = p.ProductName,
                              CurrentPrice = p.CurrentPrice,
                              Color = p.Color,
                              ProductMainPhoto = p.ProductMainPhoto
                          }).ToList();
            }

            int CategoryId = (catId ?? 0);

            if (CategoryId != 0)
            {
                result = (from p in MSE.Products
                          where (p.CategoryId == CategoryId)
                          select new FrontViewProductModel
                          {
                              ProductId = p.id,
                              ProductName = p.ProductName,
                              CurrentPrice = p.CurrentPrice,
                              Color = p.Color,
                              ProductMainPhoto = p.ProductMainPhoto
                          }).ToList();
            }

            ViewBag.Keyword = keyword;
            return View(result.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Details(int id)
        {
            MiscellaneousShopEntities MSE = new MiscellaneousShopEntities();
            var result = (from p in MSE.Products
                          where p.id == id
                          select new FrontViewProductModel
                          {
                              ProductId = p.id,
                              ProductName = p.ProductName,
                              CurrentPrice = p.CurrentPrice,
                              Color = p.Color,
                              ProductMainPhoto = p.ProductMainPhoto
                          });
            return View(result.SingleOrDefault());
            
        }

    }
}
