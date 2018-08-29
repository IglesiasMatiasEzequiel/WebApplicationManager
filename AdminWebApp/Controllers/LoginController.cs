using System.Web.Mvc;
using System.Web.Security;
using WebApp.DAL.Entities;

namespace AdminWebApp.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            //Run.RunQuery(2, new List<SQLParam> { new SQLParam("USERNAME", )})

            return PartialView();
        }


        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie("MIGLESIAS", false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            return Index();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}