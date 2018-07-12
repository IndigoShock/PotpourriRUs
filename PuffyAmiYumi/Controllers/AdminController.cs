using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PuffyAmiYumi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}