using QLDV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLDV1.Controllers
{
    public class AccountController : Controller
    {
        private QLDVConnect db = new QLDVConnect();
        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountModel acc, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var account = db.AccountModels.Where(u => u.Username.Equals(acc.Username) && u.Password.Equals(acc.Password)).Count();
                if(account == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.Username, true);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");
            }
            ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không được để trống");
            return View(acc);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username, Password")] AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                db.AccountModels.Add(accountModel);
                db.SaveChanges();
                return RedirectToAction("login");
            }

            return View(accountModel);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if(Url.IsLocalUrl(returnUrl))
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