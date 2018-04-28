using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        internal SareWebContext dbcontext = new SareWebContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            dbcontext.Dispose();
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (SessionUtil.UserLogged == null)
            {
                string action = filterContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
                if (action != AppController.ActionLogin && action != AppController.ActionLogout)
                {
                    filterContext.Result = RedirectToAction(AppController.ActionLogout, AppController.ControllerName);
                }
            }
            else if (!hasUserPermission(filterContext))
            {
                filterContext.Controller.TempData[Constants.KEY_ERROR_MESSAGE] = Constants.GENERIC_PERMISSION_DENIED;
                filterContext.Result = RedirectToAction(AppController.ActionIndex, AppController.ControllerName);
            }
        }

        private bool hasUserPermission(AuthorizationContext filterContext)
        {
            string action = filterContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
            string controller = filterContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();

            bool result = true;

            //if (SessionUtil.UserLogged.Grupo == 4)
            //{
            //    switch (action)
            //    {
            //        case "ListaClientes":
            //            result = false;
            //            break;
            //    }
            //}

            return result;
        }
    }
}