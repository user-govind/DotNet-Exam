using DotNetExam_210940320044_KH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetExam_210940320044_KH.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDao pdb = new ProductsDao();
        public ActionResult Index()
        {
            return View(pdb.getAllProducts());
        }



        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(pdb.getOneProduct(id));
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p)
        {
            try
            {
                p.ProductId = id;
                pdb.UpdateProduct(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult MyPartialView()
        {
            return View();
        }





        /*

                // GET: Products/Details/5
                public ActionResult Details(int id)
                {
                    return View();
                }

                // GET: Products/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: Products/Create
                [HttpPost]
                public ActionResult Create(FormCollection collection)
                {
                    try
                    {
                        // TODO: Add insert logic here

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }


                // GET: Products/Delete/5
                public ActionResult Delete(int id)
                {
                    return View();
                }

                // POST: Products/Delete/5
                [HttpPost]
                public ActionResult Delete(int id, FormCollection collection)
                {
                    try
                    {
                        // TODO: Add delete logic here

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }*/
    }
}
