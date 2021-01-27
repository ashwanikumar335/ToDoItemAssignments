using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Mvc.Ui.Controllers
{
    public class TodoApiController : Controller
    {
        // GET: TodoApi
        public ActionResult Index()
        {
            return View();
        }

        // GET: TodoApi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoApi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoApi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoApi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoApi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoApi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoApi/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}