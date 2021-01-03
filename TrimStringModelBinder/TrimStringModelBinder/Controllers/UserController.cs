using Microsoft.AspNetCore.Mvc;
using TrimModelBinder.Models;

namespace TrimStringModelBinderSample.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index(UserViewModel userDetails)
        {
            return View(userDetails);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel userDetails)
        {
            try
            {
                return RedirectToAction(nameof(Index), userDetails);
            }
            catch
            {
                return View();
            }
        }
    }
}
