using FormLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormLogin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.IsLogined = Request.IsAuthenticated;
            return View();
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel vm,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //用户名，密码验证


                //FormsAuthentication.SetAuthCookie(vm.UserName, true); //登录,后一个 参数为是否创建持久Cookie。及true为可以在用户浏览器上保存的。false为不在浏览器上保存。
                //if (Url.IsLocalUrl(returnUrl))
                //{
                //    return Redirect(returnUrl);
                //}



                vm.Role = "VIP";
                var authTicket = new FormsAuthenticationTicket(
                                    1,                             // version
                                    vm.UserName,                      // user name
                                    DateTime.Now,                  // created
                                    DateTime.Now.AddMinutes(20),   // expires
                                    vm.Remember,                    // persistent?
                                    vm.Role                        // can be used to store roles
                                  );

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                authCookie.HttpOnly = true;//客户端脚本不能访问
                authCookie.Secure = FormsAuthentication.RequireSSL;//是否仅用https传递cookie
                authCookie.Domain = FormsAuthentication.CookieDomain;//与cookie关联的域
                authCookie.Path = FormsAuthentication.FormsCookiePath;//cookie关联的虚拟路径
                Response.Cookies.Add(authCookie);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Detail");
            }
            else
                return View(vm);
        }

        [HttpGet]
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();//注销
            ViewBag.IsLogined = Request.IsAuthenticated;

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Detail()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
            ViewBag.IsLogined = Request.IsAuthenticated;
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "VIP")]
        public ActionResult Vip()
        {
            return View();
        }
    }
}