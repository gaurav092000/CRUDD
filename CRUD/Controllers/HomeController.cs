using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {

        ProductContext pr=new ProductContext();
        public ActionResult Index()
        {
            var data=pr.products.ToList();

            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Product p) 
        {
            pr.products.Add(p);
            int a=pr.SaveChanges();
            if(a > 0)
            {
                ViewBag.InsertMessage = "<script>alert('')</script>";
            }
            if(ModelState.IsValid==true)
            {
                ViewData["Succes Data"] = "<script>alert('Data has  been sava ')</script>";
            }
            return Redirect("Index");
        }

        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            pr.products.AddOrUpdate(p);
            pr.SaveChanges();
            return RedirectToAction("Index");
        }


        
    }
}