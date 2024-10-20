﻿using Microsoft.AspNetCore.Mvc;

namespace BTTH2.Controllers
{
    public class AccessController : Controller
    {
        QlbanVaLiContext db=new QlbanVaLiContext();
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult Login(TUser user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u=db.TUsers.Where(x=>x.Username.Equals(user.Username)&&x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null) {
                    HttpContext.Session.SetString("UserName", u.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
        }
    }
}
