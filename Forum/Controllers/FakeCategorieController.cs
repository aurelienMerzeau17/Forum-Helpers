using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.DAL.Data;
using Forum.DAL;

namespace Forum.Controllers
{
    public class FakeCategorieController : Controller
    {
        // GET: FakeCategorie
        public ActionResult Index()
        {
            List<CategorieD> list = new List<CategorieD>();
            CategorieDAL cat = new CategorieDAL();
            list = cat.GetListCategorie();

            return View(list);
        }

        // GET: FakeCategorie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FakeCategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FakeCategorie/Create
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

        // GET: FakeCategorie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FakeCategorie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FakeCategorie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FakeCategorie/Delete/5
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
        }
    }
}
