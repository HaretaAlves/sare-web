using Business;
using Domain.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class EscolasController : BaseController
    {
        public const string ControllerName = "Escolas";
        public const string ActionLista = "Lista";
        public const string ActionNovo = "Novo";
        public const string ActionAlterar = "Alterar";
        public const string ActionExcluir = "Excluir";

        private EscolaBusiness escolaBusiness = null;

        public EscolasController()
        {
            this.escolaBusiness = new EscolaBusiness();
        }

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }              

        public ActionResult Lista()
        {
            var model = new EscolaViewModel();

            model.Escolas = this.escolaBusiness.ListAll().ToList();
            return View(model);
        }

        
        public ActionResult Novo()
        {
            return View();
        }

        public ActionResult Alterar(int id)
        {
            var entity = this.escolaBusiness.GetById(id);

            var model = new EscolaViewModel();

            model.ID = entity.ID;
            model.Nome = entity.Nome;
            model.LastModifiedDate = entity.LastModifiedDate;
            model.Status = entity.Status;

            return View(model);
        }

        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            var list = this.escolaBusiness.ListAllByNome(nome);

            EscolaViewModel model = new EscolaViewModel();
            model.Escolas = list.ToList();

            return View(model);
        }

        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(EscolaModel model)
        {
            ActionResult result = null;
            EscolaModel escola = new EscolaModel();

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionAlterar, new { id = model.ID });
                    escola = this.escolaBusiness.GetById(model.ID);
                    escola.Nome = model.Nome;
                    escola.LastModifiedDate = DateTime.Now;
                    escola.Status = "UPDATED";
                    escola.UserID = 1;

                    this.escolaBusiness.Update(escola);
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    escola.Nome = model.Nome;
                    escola.LastModifiedDate = DateTime.Now;
                    escola.Status = "ADDED";
                    escola.UserID = 1;

                    this.escolaBusiness.Add(escola);
                }

                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_SAVE;
                result = RedirectToAction(ActionLista);
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }

            return result;
        }
        
        [HttpPost]
        public void Excluir(string cod)
        {
            try
            {
                int id;
                int.TryParse(cod, out id);
                var model = this.escolaBusiness.GetById(id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                this.escolaBusiness.Delete(model);
                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }
        }
        
    }
}