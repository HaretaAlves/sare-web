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

namespace WebUI.Controllers
{
    public class CampanhasController : BaseController
    {
        public const string ControllerName = "Campanhas";
        public const string ActionLista = "Lista";
        public const string ActionNovo = "Novo";
        public const string ActionExcluir = "Excluir";

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        /*
        public ActionResult Lista()
        {
            return View(dbcontext.Campanhas.ToList());
        }

        public ActionResult Novo(int? id)
        {
            TurmaModel entity = new TurmaModel();
            if (id != null)
            {
                entity = dbcontext.Campanhas.Where(o => o.ID == id).FirstOrDefault();
            }

            return View(entity);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string desc)
        {
            return View(dbcontext.Campanhas.Where(o => o.Descricao.Contains(desc)));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(TurmaModel model)
        {
            ActionResult result = null;

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionNovo, new { id = model.ID });
                    var entity = dbcontext.Campanhas.Where(o => o.ID == model.ID).FirstOrDefault();
                    entity.Video = model.Video;
                    entity.Descricao = model.Descricao;
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    dbcontext.Campanhas.Add(model);
                }

                dbcontext.SaveChanges();

                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_SAVE;
                result = RedirectToAction(ActionNovo, new { id = model.ID });
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }

            return result;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public void Excluir(int id)
        {
            try
            {
                using (var tran = new TransactionScope())
                {
                    var model = dbcontext.Campanhas.FirstOrDefault(o => o.ID == id);
                    if (model == null)
                    {
                        throw new Exception("ID não encontrado");
                    }

                    var fotos = dbcontext.CampanhaFotos.Where(o => o.CampanhaID == id);
                    foreach (var item in fotos)
                    {
                        dbcontext.CampanhaFotos.Remove(item);
                        ExcluirArquivoFoto(item.Foto);
                    }
                    dbcontext.Campanhas.Remove(model);
                    dbcontext.SaveChanges();

                    tran.Complete();
                }

                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Upload(int id)
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
                    string filename = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), file.FileName);
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

                    dbcontext.CampanhaFotos.Add(new EscolaModel { Foto = filename, CampanhaID = id });
                }
                dbcontext.SaveChanges();
                tran.Complete();
            }

            return RedirectToAction(ActionNovo, new { id = id });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ExcluirFoto(int id)
        {
            var model = dbcontext.CampanhaFotos.FirstOrDefault(o => o.ID == id);
            if (model == null)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = Constants.GENERIC_MSG_FORM_ITEM_NOT_FOUND;
            }

            using (var tran = new TransactionScope())
            {
                dbcontext.CampanhaFotos.Remove(model);
                dbcontext.SaveChanges();

                ExcluirArquivoFoto(model.Foto);

                tran.Complete();
            }

            TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;

            return RedirectToAction(ActionNovo, new { id = model.ID });
        }

        private void ExcluirArquivoFoto(string fitename)
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("\\_uploads");
            string fullname = string.Format("{0}\\{1}", path, fitename);
            System.IO.File.Delete(fullname);
            System.IO.File.Delete(fullname.Insert(fullname.LastIndexOf("."), "_thumb"));
        }

        */
    }
}