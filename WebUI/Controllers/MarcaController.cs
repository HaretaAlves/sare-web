using Domain.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers
{
    public class MarcaController : BaseController
    {
        public const string ControllerName = "Marca";
        public const string ActionLista = "Lista";
        public const string ActionNovo = "Novo";
        public const string ActionAlterar = "Alterar";
        public const string ActionExcluir = "Excluir";

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        /*
        public ActionResult Lista()
        {
            return View(dbcontext.Marca.ToList());
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Alterar(int id)
        {
            var entity = dbcontext.Marca.Where(o => o.ID == id).FirstOrDefault();

            return View(entity);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            return View(dbcontext.Marca.Where(o => o.Nome.Contains(nome)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(MarcaModel model)
        {
            ActionResult result = null;

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionAlterar, new { id = model.ID });
                    var entity = dbcontext.Marca.Where(o => o.ID == model.ID).FirstOrDefault();
                    entity.Nome = model.Nome;
                    entity.Foto = model.Foto;
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    dbcontext.Marca.Add(model);
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

        [HttpPost, ValidateAntiForgeryToken]
        public void Excluir(string cod)
        {
            try
            {
                int id;
                int.TryParse(cod, out id);
                var model = dbcontext.Clientes.FirstOrDefault(o => o.ID == id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                dbcontext.Clientes.Remove(model);
                dbcontext.SaveChanges();
                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }
        }
        */
    }
}