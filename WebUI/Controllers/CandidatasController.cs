using Domain.Extensions;
using Domain.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers
{
    public class CandidatasController : BaseController
    {
        public const string ControllerName = "Candidatas";
        public const string ActionLista = "Lista";
        public const string ActionExcluir = "Excluir";

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        /*
        public ActionResult Lista()
        {
            return View(dbcontext.Candidatas.ToList());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            return View(dbcontext.Candidatas.Where(o => o.Nome.Contains(nome)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(AlunoModel model)
        {
            ActionResult result = null;

            try
            {
                var entity = dbcontext.Candidatas.Where(o => o.ID == model.ID).FirstOrDefault();
                entity.Nome = model.Nome;
                entity.Telefone = model.Telefone;
                entity.Endereco = model.Endereco;
                entity.Cep = model.Cep;
                entity.Email = model.Email;

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
                var model = dbcontext.Candidatas.FirstOrDefault(o => o.ID == id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                dbcontext.Candidatas.Remove(model);
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