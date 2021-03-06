﻿using System.Web;
using System.Web.Mvc;
using FantasyDraftAPI.Models;
using FantasyDraftAPI.Services;

namespace FantasyDraftAPI.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            AdminViewModel model = null;
            try
            {
                DraftUser user = DraftAuthentication.AuthenticateRequest(HttpContext.Request, 1);
                model = new AdminViewModel(user);
            }
            catch (DraftAuthenticationException)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }

    }
}
