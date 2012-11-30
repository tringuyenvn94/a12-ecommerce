using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiscellaneousShop.Models
{
    public class FrontViewProductModel
    {
        public int? ProductId                 {get;set;}
        public string ProductName      {get;set;}
        public int? CurrentPrice    {get;set;}
        public string Color               {get;set;}
        public string ProductMainPhoto       {get;set;}
    }

    public class BackViewProductModel
    {

    }

    public class CategoryModel
    {
        public int? CategoryId              {get;set;}
        public string CategoryName          {get;set;}
        public string CategoryDescription { get; set; }

        public List<CategoryModel> CategoryList()
        {
            MiscellaneousShopEntities MSE = new MiscellaneousShopEntities();
            var result = (from c in MSE.Catetories
                          select new CategoryModel { 
                                CategoryId = c.id,
                                CategoryName = c.CategoryName,
                                CategoryDescription = c.CategoryDescription
                          });

            return result.ToList();
        }
    }
}