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

        private AvaliacaoGrupoBusiness avalicaoGrupoBusiness = null;
        //private AlunoBusiness alunoBusiness = null;
        //private TurmaBusiness turmaBusiness = null;
        private GrupoBusiness grupoBusiness = null;
        //private EscolaBusiness escolaBusiness = null;

        public AvaliacoesGrupoController()
        {
            this.grupoBusiness = new GrupoBusiness();
            //this.alunoBusiness = new AlunoBusiness();
            //this.turmaBusiness = new TurmaBusiness();
            //this.escolaBusiness = new EscolaBusiness();
            this.avalicaoGrupoBusiness = new AvaliacaoGrupoBusiness();
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