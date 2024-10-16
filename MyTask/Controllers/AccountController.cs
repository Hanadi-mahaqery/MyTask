using Microsoft.AspNetCore.Mvc;

namespace MyTask.Controllers
{
    public class AccountController : Controller
    {
        // عرض صفحة تسجيل الدخول
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // معالجة طلب تسجيل الدخول
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // مباشرة توجيه المستخدم إلى swagger
            return Redirect("/swagger");
        }
    }
}
