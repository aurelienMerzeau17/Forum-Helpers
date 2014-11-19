using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.DAL.Data;
using Forum.DAL;

namespace Forum.Controllers
{
    public class FakeMessageController : Controller
    {
        // GET: FakeMessage
        public ActionResult Index()
        {
            List<MessageD> liste = new List<MessageD>();
            MessageDAL mes = new MessageDAL();
            liste = mes.GetListMessage();
            return View(liste);
        }

        // GET: FakeMessage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FakeMessage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FakeMessage/Create
        [HttpPost]
        public ActionResult Create(MessageD collection)
        {
            try
            {
                // TODO: Add insert logic here
                MessageDAL mes = new MessageDAL();
                mes.CreateMessage(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FakeMessage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FakeMessage/Edit/5
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

        // GET: FakeMessage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FakeMessage/Delete/5
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
