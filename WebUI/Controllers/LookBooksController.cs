using Domain.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;

namespace WebUI.Controllers
{
    public class LookBooksController : BaseController
    {
        public const string ControllerName = "LookBooks";
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
            return View(dbcontext.LookBooks.ToList());
        }

        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Alterar(int id)
        {
            var entity = dbcontext.LookBooks.Where(o => o.ID == id).FirstOrDefault();

            return View(entity);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            return View(dbcontext.LookBooks.Where(o => o.Nome.Contains(nome)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(AvaliacaoRespostasModel model)
        {
            ActionResult result = null;

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionAlterar, new { id = model.ID });
                    var entity = dbcontext.LookBooks.Where(o => o.ID == model.ID).FirstOrDefault();
                    entity.Nome = model.Nome;
                    entity.Foto = model.Foto;
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    dbcontext.LookBooks.Add(model);
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

        public void PopularBanco()
        {
            DirectoryInfo pasta = new DirectoryInfo(@"C:\Users\Hareta\Projetos\Boana\boanajeansapp\trunk\code\mobile\BoanaJeansApp\src\assets\imgs\lookbook");
            FileInfo[] arquivos = pasta.GetFiles();

            for (int i = 0; i < arquivos.Length; i++)
            {
                var model = new AvaliacaoRespostasModel();
                model.Foto = arquivos[i].Name;
                model.isLancamento = false;
                if (i > 25)
                {
                    model.isLancamento = true;
                }

                dbcontext.LookBooks.Add(model);
                dbcontext.SaveChanges();

            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public void Excluir(string cod)
        {
            try
            {
                int id;
                int.TryParse(cod, out id);
                var model = dbcontext.LookBooks.FirstOrDefault(o => o.ID == id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                dbcontext.LookBooks.Remove(model);
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