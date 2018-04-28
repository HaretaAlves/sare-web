using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;
using Domain.Extensions;

namespace WebUI.Controllers
{
    public class UsuariosController : BaseController
    {
        public const string ControllerName = "Usuarios";
        public const string ActionLista = "Lista";
        public const string ActionNovo = "Novo";
        public const string ActionAlterar = "Alterar";
        public const string ActionExcluir = "Excluir";

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        public ActionResult Lista()
        {
            return View(dbcontext.Usuarios.ToList());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            return View(dbcontext.Usuarios.Where(o => o.Nome.Contains(nome)));
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(UsuarioModel model)
        {
            ActionResult result = null;

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionAlterar, new { id = model.ID });
                    var entity = dbcontext.Usuarios.Where(o => o.ID == model.ID).FirstOrDefault();
                    entity.Login = model.Login;
                    entity.Nome = model.Nome;
                    if (!string.IsNullOrEmpty(model.Senha)) entity.Senha = model.Senha;
                    entity.Email = model.Email;
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    dbcontext.Usuarios.Add(model);
                }
                
                dbcontext.SaveChanges();

                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_SAVE;
                result = RedirectToAction(ActionAlterar, new { id = model.ID });
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }

            return result;
        }

        public ActionResult Alterar(int id)
        {
            var entity = dbcontext.Usuarios.Where(o => o.ID == id).FirstOrDefault();

            return View(entity);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public void Excluir(string cod)
        {
            try
            {
                int id;
                int.TryParse(cod, out id);
                var model = dbcontext.Usuarios.FirstOrDefault(o => o.ID == id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                dbcontext.Usuarios.Remove(model);
                dbcontext.SaveChanges();
                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }
        }
    }
}