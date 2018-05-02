using Business;
using Domain.Extensions;
using Domain.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using WebUI.Utils;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class AlunosController : BaseController
    {
        public const string ControllerName = "Alunos";
        public const string ActionLista = "Lista";
        public const string ActionNovo = "Novo";
        public const string ActionAlterar = "Alterar";
        public const string ActionExcluir = "Excluir";

        private AlunoBusiness alunoBusiness = null;
        private TurmaBusiness turmaBusiness = null;

        public AlunosController()
        {
            this.alunoBusiness = new AlunoBusiness();
            this.turmaBusiness = new TurmaBusiness();
        }

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }        

        public ActionResult Lista()
        {
            var model = new AlunoViewModel();

            model.Alunos = this.alunoBusiness.ListAll().ToList();
            model.Turmas = this.turmaBusiness.ListAll().ToList();
            return View(model);
        }

        public ActionResult Novo()
        {
            var model = new AlunoViewModel();

            model.Turmas = this.turmaBusiness.ListAll().ToList();
            return View(model);
        }

        public ActionResult Alterar(int id)
        {
            var entity = this.alunoBusiness.GetById(id);

            var model = new AlunoViewModel();

            model.ID = entity.ID;
            model.Nome = entity.Nome;
            model.DataNascimento = entity.DataNascimento;
            model.LastModifiedDate = entity.LastModifiedDate;
            model.Turmas = this.turmaBusiness.ListAll().ToList();
            model.TurmaID = entity.TurmaID;
            model.TurmaSelecionada = model.Turmas.Where(x => x.ID == model.TurmaID).FirstOrDefault();
            model.Status = entity.Status;

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            var list = this.alunoBusiness.ListAllByNome(nome);

            AlunoViewModel model = new AlunoViewModel();
            model.Alunos = list.ToList();

            return View(model);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(AlunoModel model)
        {
            ActionResult result = null;
            AlunoModel aluno = new AlunoModel();

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionAlterar, new { id = model.ID });
                    aluno = this.alunoBusiness.GetById(model.ID);
                    aluno.Nome = model.Nome;
                    aluno.DataNascimento = model.DataNascimento;
                    aluno.TurmaID = model.TurmaID;
                    aluno.LastModifiedDate = DateTime.Now;
                    aluno.Status = "UPDATED";
                    aluno.UserID = 1;
                    aluno.FotoID = 1;

                    this.alunoBusiness.Update(aluno);
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    aluno.Nome = model.Nome;
                    aluno.DataNascimento = model.DataNascimento;
                    aluno.TurmaID = model.TurmaID;
                    aluno.LastModifiedDate = DateTime.Now;
                    aluno.Status = "ADDED";
                    aluno.UserID = 1;
                    aluno.FotoID = 1;

                    this.alunoBusiness.Add(aluno);
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
                var model = this.alunoBusiness.GetById(id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                this.alunoBusiness.Delete(model);
                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }
        }
        
    }
}