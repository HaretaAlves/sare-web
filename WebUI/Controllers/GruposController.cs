﻿using Business;
using Domain.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class GruposController : BaseController
    {
        public const string ControllerName = "Campanhas";
        public const string ActionLista = "Lista";
        public const string ActionNovo = "Novo";
        public const string ActionExcluir = "Excluir";
        public const string ActionAlterar = "Alterar";

        private AlunoBusiness alunoBusiness = null;
        private TurmaBusiness turmaBusiness = null;
        private GrupoBusiness grupoBusiness = null;

        public GruposController()
        {
            this.grupoBusiness = new GrupoBusiness();
            this.alunoBusiness = new AlunoBusiness();
            this.turmaBusiness = new TurmaBusiness();
        }

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        public ActionResult Lista()
        {
            var model = new GrupoViewModel();

            model.Alunos = this.alunoBusiness.ListAll().ToList();
            model.Turmas = this.turmaBusiness.ListAll().ToList();
            model.Grupos = this.grupoBusiness.ListAll().ToList();
            return View(model);
        }

        public ActionResult Novo()
        {
            var model = new GrupoViewModel();

            model.Alunos = this.alunoBusiness.ListAll().ToList();
            model.Turmas = this.turmaBusiness.ListAll().ToList();
            return View(model);
        }

        public ActionResult Alterar(int id)
        {
            var entity = this.grupoBusiness.GetById(id);

            var model = new GrupoViewModel();

            model.ID = entity.ID;
            model.Nome = entity.Nome;
            model.LastModifiedDate = entity.LastModifiedDate;
            model.Status = entity.Status;

            model.Alunos = this.alunoBusiness.ListAll().ToList();
            model.Aluno1ID = entity.Aluno1ID;
            model.Aluno1 = model.Alunos.Where(x => x.ID == model.Aluno1ID).FirstOrDefault();

            model.Aluno2ID = entity.Aluno2ID;
            model.Aluno2 = model.Alunos.Where(x => x.ID == model.Aluno2ID).FirstOrDefault();

            model.Aluno3ID = entity.Aluno3ID;
            model.Aluno3 = model.Alunos.Where(x => x.ID == model.Aluno3ID).FirstOrDefault();

            model.Aluno4ID = entity.Aluno4ID;
            model.Aluno4 = model.Alunos.Where(x => x.ID == model.Aluno4ID).FirstOrDefault();

            model.Turmas = this.turmaBusiness.ListAll().ToList();
            model.TurmaID = entity.TurmaID;
            model.TurmaSelecionada = model.Turmas.Where(x => x.ID == model.TurmaID).FirstOrDefault();            

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            var list = this.grupoBusiness.ListAllByNome(nome);

            GrupoViewModel model = new GrupoViewModel();
            model.Grupos = list.ToList();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(GrupoModel model)
        {
            ActionResult result = null;
            GrupoModel grupo = new GrupoModel();

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionAlterar, new { id = model.ID });

                    grupo.ID = model.ID;
                    grupo.Nome = model.Nome;
                    grupo.LastModifiedDate = DateTime.Now;
                    grupo.Status = "UPDATED";
                    grupo.UserID = 1;

                    grupo.Aluno1ID = model.Aluno1ID;
                    grupo.Aluno2ID = model.Aluno2ID;
                    grupo.Aluno3ID = model.Aluno3ID;
                    grupo.Aluno4ID = model.Aluno4ID;

                    grupo.TurmaID = model.TurmaID;                  

                    this.grupoBusiness.Update(grupo);
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    grupo.ID = model.ID;
                    grupo.Nome = model.Nome;
                    grupo.LastModifiedDate = DateTime.Now;
                    grupo.Status = "ADDED";
                    grupo.UserID = 1;

                    grupo.Aluno1ID = model.Aluno1ID;
                    grupo.Aluno2ID = model.Aluno2ID;
                    grupo.Aluno3ID = model.Aluno3ID;
                    grupo.Aluno4ID = model.Aluno4ID;

                    grupo.TurmaID = model.TurmaID;

                    this.grupoBusiness.Add(grupo);
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
                var model = this.grupoBusiness.GetById(id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                this.grupoBusiness.Delete(model);
                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }
        }

    }
}