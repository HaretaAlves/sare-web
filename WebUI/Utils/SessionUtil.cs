using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Utils
{
    public class SessionUtil
    {
        public static UsuarioModel UserLogged
        {
            get
            {
                return HttpContext.Current.Session[typeof(UsuarioModel).Name] as UsuarioModel;
            }
            set
            {
                HttpContext.Current.Session[typeof(UsuarioModel).Name] = value;
            }
        }

        internal static void ClearAll()
        {
            HttpContext.Current.Session.RemoveAll();
        }
    }
}