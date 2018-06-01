using Business;
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
    public class AvaliacoesGrupoController : BaseController
    {
        public const string ControllerName = "AvaliacoesGrupo";
        public const string ActionLista = "Lista";
        public const string ActionView = "Visualizar";

        private AvaliacaoGrupoBusiness avalicaoGrupoBusiness = null;
        private AvaliacaoAlunoBusiness avalicaoAlunoBusiness = null;
        private AlunoBusiness alunoBusiness = null;
        private TurmaBusiness turmaBusiness = null;
        private GrupoBusiness grupoBusiness = null;
        private EscolaBusiness escolaBusiness = null;

        public AvaliacoesGrupoController()
        {
            this.grupoBusiness = new GrupoBusiness();
            this.alunoBusiness = new AlunoBusiness();
            this.turmaBusiness = new TurmaBusiness();
            this.escolaBusiness = new EscolaBusiness();
            this.avalicaoGrupoBusiness = new AvaliacaoGrupoBusiness();
            this.avalicaoAlunoBusiness = new AvaliacaoAlunoBusiness();
        }

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        public ActionResult Lista()
        {
            var model = new AvaliacaoGrupoViewModel();

            //model.Alunos = this.alunoBusiness.ListAll().ToList();
            //model.Turmas = this.turmaBusiness.ListAll().ToList();
            //model.Grupos = this.grupoBusiness.ListAll().ToList();
            model.AvaliacoesGrupo = this.avalicaoGrupoBusiness.ListAll().ToList();

            foreach (var item in model.AvaliacoesGrupo)
            {
                item.GrupoFK = this.grupoBusiness.GetById(item.GrupoID);
            }

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            var list = this.avalicaoGrupoBusiness.ListAllByNome(nome);

            AvaliacaoGrupoViewModel model = new AvaliacaoGrupoViewModel();
            model.AvaliacoesGrupo = list.ToList();

            return View(model);
        }

        public ActionResult Visualizar(int id)
        {
            var entity = this.avalicaoGrupoBusiness.GetById(id);

            var model = new AvaliacaoGrupoViewModel();
            
            model.ID = entity.ID;
            model.Nome = entity.Nome;
            model.LastModifiedDate = entity.LastModifiedDate;
            model.Status = entity.Status;
            model.Date = entity.Date;
            model.GrupoID = entity.GrupoID;
            model.Grupo = this.grupoBusiness.GetById(model.GrupoID);
            model.Grupo.TurmaFK = this.turmaBusiness.GetById(model.Grupo.TurmaID);
            model.Grupo.TurmaFK.EscolaFK = this.escolaBusiness.GetById(model.Grupo.TurmaFK.EscolaID);

            model.AvaliacoesAlunos = this.avalicaoAlunoBusiness.ListAllByAvGrupoID(model.ID).ToList();

            foreach (var item in model.AvaliacoesAlunos)
            {
                item.AlunoFK = this.alunoBusiness.GetById(item.AlunoID);
                item.FuncaoNome = verificaNomeFuncao(item.Funcao);
            }

            return View(model);
        }

        public string verificaNomeFuncao(int funcao)
        {
            var funcaoNome = "";
            if(funcao == 1){
                funcaoNome = "Construtor";
            }
            else if (funcao == 2)
            {
                funcaoNome = "Organizador";
            }
            else if (funcao == 3)
            {
                funcaoNome = "Programador";
            }
            else if (funcao == 4)
            {
                funcaoNome = "Líder";
            }
            return funcaoNome;
        }

        /*
        [HttpPost]
        public JsonResult TurmasPorEscola(string escolaID)
        {
            try
            {
                int id;
                int.TryParse(escolaID, out id);
                var list = this.ListTurmasByEscolaID(id);

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        */

        /*
        public List<TurmaModel> ListTurmasByEscolaID(int escolaID)
        {
            var listaTurmas = this.turmaBusiness.ListByEscolaID(escolaID).ToList();
            return listaTurmas;
        }
        */

        /*
        [HttpPost]
        public JsonResult AlunosByTurmas(string turmaID)
        {
            try
            {
                int id;
                int.TryParse(turmaID, out id);
                var list = this.ListAlunosByTurmaID(id);

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        */

        /*
        public List<AlunoModel> ListAlunosByTurmaID(int turmaID)
        {
            var listaTurmas = this.alunoBusiness.ListByTurmaID(turmaID).ToList();
            return listaTurmas;
        }
        */

    }
}