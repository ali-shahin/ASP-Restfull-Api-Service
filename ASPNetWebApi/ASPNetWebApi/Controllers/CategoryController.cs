﻿using ASPNetWebApi.Models;
using ASPNetWebApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNetWebApi.Controllers
{
    public class CategoryController : ApiController
    {
        public List<CategoryViewModel> Get()
        {
            MyContext db = new MyContext();
            return db.Categories.Select(x => new CategoryViewModel()
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture
            }).ToList();
        }
        public CategoryViewModel Get(int id)
        {
            MyContext db = new MyContext();
            var category = db.Categories.Find(id);
            if (category == null)
                return null;
            CategoryViewModel model = new CategoryViewModel()
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
            return model;
        }
    }
}
