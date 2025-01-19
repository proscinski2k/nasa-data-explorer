using System.Security.AccessControl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace web_api.Controllers
{
    public class Osdr : Controller
    {
        // GET: Osdr
        public ActionResult Index()
        {
            return View();
        }

        // GET: Osdr/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Osdr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Osdr/Create
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

        // GET: Osdr/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Osdr/Edit/5
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

        // GET: Osdr/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Osdr/Delete/5
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
