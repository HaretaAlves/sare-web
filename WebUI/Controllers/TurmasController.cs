using Business;
using Domain.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class TurmasController : BaseController
    {
        public const string ControllerName = "Turmas";
        public const string ActionLista = "Lista";
        public const string ActionNovo = "Novo";
        public const string ActionAlterar = "Alterar";
        public const string ActionExcluir = "Excluir";

        private TurmaBusiness turmaBusiness = null;
        private EscolaBusiness escolaBusiness = null;

        public TurmasController()
        {
            this.turmaBusiness = new TurmaBusiness();
            this.escolaBusiness = new EscolaBusiness();
        }

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        public ActionResult Lista()
        {
            var model = new TurmaViewModel();

            model.Escolas = this.escolaBusiness.ListAll().ToList();
            model.Turmas = this.turmaBusiness.ListAll().ToList();
            return View(model);
        }

        public ActionResult Novo()
        {
            var model = new TurmaViewModel();

            model.Escolas = this.escolaBusiness.ListAll().ToList();
            return View(model);
        }

        public ActionResult Alterar(int id)
        {
            var entity = this.turmaBusiness.GetById(id);

            var model = new TurmaViewModel();

            model.ID = entity.ID;
            model.Nome = entity.Nome;
            model.LastModifiedDate = entity.LastModifiedDate;
            model.Escolas = dbcontext.Escolas.ToList();
            model.EscolaID = entity.EscolaID;
            model.EscolaSelecionada = model.Escolas.Where(x => x.ID == model.EscolaID).FirstOrDefault();
            model.Status = entity.Status;

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            var list = this.turmaBusiness.ListAllByNome(nome);

            TurmaViewModel model = new TurmaViewModel();
            model.Turmas = list.ToList();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(TurmaViewModel model)
        {
            ActionResult result = null;
            TurmaModel turma = new TurmaModel();

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionAlterar, new { id = model.ID });
                    turma = this.turmaBusiness.GetById(model.ID);
                    turma.Nome = model.Nome;
                    turma.EscolaID = model.EscolaID;
                    turma.LastModifiedDate = DateTime.Now;
                    turma.Status = "UPDATED";
                    turma.UserID = 1;

                    this.turmaBusiness.Update(turma);
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    turma.Nome = model.Nome;
                    turma.EscolaID = model.EscolaID;
                    turma.LastModifiedDate = DateTime.Now;
                    turma.Status = "ADDED";
                    turma.UserID = 1;

                    this.turmaBusiness.Add(turma);
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
                var model = this.turmaBusiness.GetById(id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                this.turmaBusiness.Delete(model);
                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }
        }
    }
}