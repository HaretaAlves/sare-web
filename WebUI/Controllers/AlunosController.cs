using Business;
using Domain.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Transactions;
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
        private EscolaBusiness escolaBusiness = null;
        private FotoBusiness fotoBusiness = null;

        public AlunosController()
        {
            this.alunoBusiness = new AlunoBusiness();
            this.turmaBusiness = new TurmaBusiness();
            this.escolaBusiness = new EscolaBusiness();
            this.fotoBusiness = new FotoBusiness();
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

            model.Turmas = new List<TurmaModel>();
            model.Escolas = this.escolaBusiness.ListAll().ToList();
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
            model.TurmaID = entity.TurmaID;
            model.TurmaSelecionada = this.turmaBusiness.GetById(model.TurmaID);

            model.Escolas = this.escolaBusiness.ListAll().ToList();
            model.EscolaID = model.TurmaSelecionada.EscolaID;
            model.EscolaSelecionada = model.Escolas.Where(x => x.ID == model.EscolaID).FirstOrDefault();

            model.Turmas = this.turmaBusiness.ListByEscolaID(model.EscolaID).ToList();

            model.Foto = this.fotoBusiness.GetByAlunoId(model.ID);
            model.FotoID = model.Foto != null ? model.Foto.ID : 0;

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
                    aluno.UserID = SessionUtil.UserLogged.ID;

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
                    aluno.UserID = SessionUtil.UserLogged.ID;

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

        public List<TurmaModel> ListTurmasByEscolaID(int escolaID)
        {
            var listaTurmas = this.turmaBusiness.ListByEscolaID(escolaID).ToList();
            return listaTurmas;
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Upload(int id, string nome)
        {
            using (var tran = new TransactionScope())
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var path = System.Web.HttpContext.Current.Server.MapPath("\\_uploads");
                    var file = Request.Files[i];
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string filename = string.Format("{0}_{1}.{2}", DateTime.Now.ToString("dd-MM-yyyy"), nome, file.FileName.Split('.')[1]);
                    string fullname = string.Format("{0}\\{1}", path, filename);
                    file.SaveAs(fullname);

                    Bitmap img = new Bitmap(file.InputStream);
                    int w = img.Width;
                    int h = img.Height;
                    if (w > h)
                    {
                        h = (h * 120 / w);
                        w = 120;
                    }
                    else
                    {
                        w = (w * 120 / h); ;
                        h = 120;
                    }
                    Image thumb = img.GetThumbnailImage(w, h, () => false, IntPtr.Zero);
                    thumb.Save(fullname.Insert(fullname.LastIndexOf("."), "_thumb"));

                    FotoModel foto = new FotoModel();
                    foto.FotoUrl = filename;
                    foto.Status = "ADDED";
                    foto.LastModifiedDate = DateTime.Now;
                    foto.AlunoID = id;

                    this.fotoBusiness.Add(foto);
                }

                tran.Complete();
            }

            return RedirectToAction(ActionAlterar, new { id = id });
        }

        public ActionResult ImportItens()
        {
            ActionResult result = null;
            var pathReader = "";

            try
            {
                using (var tran = new TransactionScope())
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var path = System.Web.HttpContext.Current.Server.MapPath("\\_arquivosCsv");
                        var file = Request.Files[i];
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string filename = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd"), file.FileName);
                        string fullname = string.Format("{0}\\{1}", path, filename);
                        file.SaveAs(fullname);

                        pathReader = fullname;

                    }
                    tran.Complete();
                }

                using (var reader = new StreamReader(pathReader))
                {
                    List<AlunoModel> listaAlunos = new List<AlunoModel>();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (!line.Contains("Cadastros de alunos") && !line.Contains("Nome;Data de Nascimento;Turma"))
                        {
                            var item = new AlunoModel();
                            var values = line.Split(';');
                            item.Nome = values[0];
                            item.DataNascimento = DateTime.Parse(values[1]);
                            item.TurmaID = this.turmaBusiness.GetByNome(values[2]).ID;
                            item.LastModifiedDate = DateTime.Now;
                            item.Status = "ADDED";
                            item.UserID = SessionUtil.UserLogged.ID;

                            listaAlunos.Add(item);
                        }

                    }

                    this.alunoBusiness.AddList(listaAlunos);

                }

                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_SAVE_MANY_ITENS;
                result = RedirectToAction(ActionLista);
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }

            return result;
        }




    }
}