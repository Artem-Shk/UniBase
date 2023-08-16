using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniBase.Models;
using Microsoft.EntityFrameworkCore;
namespace UniBase.Controllers
{
    public class DBManager : Controller
    {
        private readonly DekanatModel context;
        
        internal DBManager(DekanatModel DataBase)
        {
            context = DataBase;
        }
        // GET: DBManager
        public ActionResult Index()
        {
            return View();
        }

        public async Task<List<ДекВсеДанныеСтудента>> FindStudentByNameAsynch(string name)
        {
            return await context.ДекВсеДанныеСтудента
            .AsNoTracking()
            .Where(entity =>
            entity.Фамилия.ToLower() == name.ToLower()
            || entity.Имя.ToLower() == name.ToLower()
            || entity.ФИО.ToLower() == name.ToLower()
            || entity.Зачетка == name
            || entity.Название.ToLower() == name.ToLower())
            .ToListAsync();
        }
        public List<ДекВсеДанныеСтудента> FindStudentByName(string name)
        {
            return context.ДекВсеДанныеСтудента
                .AsNoTracking()
                .Where(entity => entity.ФИО.Contains(name.ToLower())
                || entity.Зачетка == name
                || entity.Название.ToLower().Contains(name.ToLower()))
                .ToList();
        }
        public async Task<string?[]> AllFacults()
        {
            return await context.ДекСпециальности
                  .AsNoTracking()
                  .Select(f => f.Факультет)
                  .ToArrayAsync();

        }
        public async Task<string?[]> AllGroupsByFaccults()
        {
            return await context.ДекСпециальности
                .AsNoTracking()
                .Select(f => f.Название_Спец)
                .ToArrayAsync();
        }
    


    // GET: DBManager/Details/5
    public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DBManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DBManager/Create
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

        // GET: DBManager/Edit/5
        public ActionResult Edit(int id) 
        {
            return View();
        }

        // POST: DBManager/Edit/5
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

        // GET: DBManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DBManager/Delete/5
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
