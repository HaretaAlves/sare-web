using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUI.Utils;

namespace WebUI.Controllers
{
    public class AppController : BaseController
    {
        public const string ControllerName = "App";
        public const string ActionLogout = "Logout";
        public const string ActionIndex = "Index";
        public const string ActionLogin = "Login";

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            SessionUtil.ClearAll();
            FormsAuthentication.SignOut();
            return RedirectToAction(ActionLogin, ControllerName);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(string login, string senha)
        {
            var cli = dbcontext.Usuarios.Where(o => o.Login == login && o.Senha == senha).FirstOrDefault();
            if (cli == null)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = Constants.LOGIN_DENIED;
            }
            else
            {
                SessionUtil.UserLogged = cli;
                FormsAuthentication.SetAuthCookie(cli.ID.ToString(), false);
                return RedirectToAction(UsuariosController.ActionLista, UsuariosController.ControllerName);
            }

            return RedirectToAction(ActionIndex);
        }        

    }
}