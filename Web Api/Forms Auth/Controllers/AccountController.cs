using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using WebApi_FormsAuth.Models;

namespace WebApi_FormsAuth.Controllers
{
    public class AccountController : Controller
    {
        //
        // POST: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            // check if all required fields are set
            if (ModelState.IsValid)
            {
                // authenticate user
                var success = UserCredentials.Validate(model.UserName, model.Password);

                if (success)
                {
                    // set authentication cookie
                    FormsAuthentication.SetAuthCookie(model.UserName,false);

                    return RedirectToLocal(returnUrl);
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpStatusCodeResult AjaxLogin(LoginModel model)
        {
            // check if all required fields are set
            if (ModelState.IsValid)
            {
                // authenticate user
                var success = UserCredentials.Validate(model.UserName, model.Password);

                if (success)
                {
                    // set authentication cookie
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
