using Domain.Extensions;
using Domain.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers
{
    public class ContatosController : BaseController
    {
        public const string ControllerName = "Contatos";
        public const string ActionLista = "Lista";
        public const string ActionExcluir = "Excluir";

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        /*
        public ActionResult Lista()
        {
            return View(dbcontext.Contatos.ToList());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            return View(dbcontext.Contatos.Where(o => o.Nome.Contains(nome)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(AvaliacaoGrupoModel model)
        {
            ActionResult result = null;

            try
            {
                var entity = dbcontext.Contatos.Where(o => o.ID == model.ID).FirstOrDefault();
                entity.Nome = model.Nome;
                entity.Email = model.Email;
                entity.Telefone = model.Telefone;
                entity.Cidade = model.Cidade;
                entity.Mensagem = model.Mensagem;

                dbcontext.SaveChanges();

                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_SAVE;
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
                var model = dbcontext.Contatos.FirstOrDefault(o => o.ID == id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                dbcontext.Contatos.Remove(model);
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