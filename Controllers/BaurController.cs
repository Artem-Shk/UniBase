using Microsoft.AspNetCore.Mvc;

namespace UniBase.Controllers
{
    public class BaurController : Controller
    {
        // GET: BaurController
        public ActionResult Index()
        {
            return View("sd");
        }

        // GET: BaurController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BaurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaurController/Create
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

        // GET: BaurController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BaurController/Edit/5
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

        // GET: BaurController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BaurController/Delete/5
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
