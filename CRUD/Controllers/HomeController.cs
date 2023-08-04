using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.InteropServices;

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
            if(ModelState.IsValid==true)
            {
                pr.products.Add(p);
                int a = pr.SaveChanges();

                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted')</script>";
                    //TempData["Succussc"] = "<script>alert('Data Inserted')</script>";
                    TempData["Succussc"] = "<script>alert('Data add successFully')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted')</script>";
                }

            }
            return View();
        }

        public ActionResult Edit(int id) 
        {
            var row = pr.products.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit( Product pp)
        {
            if (ModelState.IsValid==true) 
            {

                pr.Entry(pp).State = EntityState.Modified;
                int a = pr.SaveChanges();

                if (a > 0)
                {
                    TempData["Succuss"] = "<script>alert('Data Edit Successfully')</script>";

                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data  Not Uppdate')</script>";
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) 
        {
            if(id > 0)
            {
            var  productrow= pr.products.Where(model => model.Id==id).FirstOrDefault();
                if(productrow != null)
                {
                    pr.Entry(productrow).State = EntityState.Deleted;
                    int a = pr.SaveChanges();
                    if(a>0)
                    {
                        TempData["Delete"]= "<script>alert('Data  Delete')</script>";
                    }
                    else
                    {
                        TempData["Delete"] = "<script>alert('Data  Not Delete')</script>";
                    }
                }
              }
            return RedirectToAction("Index");

                }
        public ActionResult Details(int id)
        {
            var DetailsId = pr.products.Where(model => model.Id == id).FirstOrDefault();
            return View(DetailsId);

        }
     }

  
            
        }
       

        
 