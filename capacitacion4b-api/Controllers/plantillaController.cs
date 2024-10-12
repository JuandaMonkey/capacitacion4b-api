using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace capacitacion4b_api.Controllers
{
    public class plantillaController : Controller
    {
        // GET: plantillaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: plantillaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: plantillaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: plantillaController/Create
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

        // GET: plantillaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: plantillaController/Edit/5
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

        // GET: plantillaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: plantillaController/Delete/5
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
