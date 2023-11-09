using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniBase.CORE;
using UniBase.Models;

namespace UniBase.Controllers
{
    public class JournalAnaliticController : Controller
    {
        private JournalFabric journal = new JournalFabric();
        
        // GET: JournalAnaliticController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JournalAnaliticController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JournalAnaliticController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JournalAnaliticController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JournalAnaliticController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JournalAnaliticController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: JournalAnaliticController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: JournalAnaliticController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
