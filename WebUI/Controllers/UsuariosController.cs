using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Utils;
using Domain.Extensions;
using Business;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class UsuariosController : BaseController
    {
        public const string ControllerName = "Usuarios";
        public const string ActionLista = "Lista";
        public const string ActionNovo = "Novo";
        public const string ActionAlterar = "Alterar";
        public const string ActionExcluir = "Excluir";

        private UsuarioBusiness usuarioBusiness = null;

        public UsuariosController()
        {
            this.usuarioBusiness = new UsuarioBusiness();
        }

        public ActionResult Index()
        {
            return RedirectToAction(ActionLista);
        }

        public ActionResult Lista()
        {
            var model = new UsuarioViewModel();

            model.Usuarios = this.usuarioBusiness.ListAll().ToList();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Lista(string nome)
        {
            var list = this.usuarioBusiness.ListAllByNome(nome);

            UsuarioViewModel model = new UsuarioViewModel();
            model.Usuarios = list.ToList();

            return View(model);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(UsuarioModel model)
        {
            ActionResult result = null;
            UsuarioModel usuario = new UsuarioModel();

            try
            {
                if (model.ID > 0)
                {
                    result = RedirectToAction(ActionAlterar, new { id = model.ID });
                    usuario = this.usuarioBusiness.GetById(model.ID);
                    usuario.Nome = model.Nome;
                    usuario.Login = model.Login;
                    usuario.Email = model.Email;
                    usuario.LastModifiedDate = DateTime.Now;
                    usuario.Status = "UPDATED";

                    if(model.Senha != null)
                    {
                        usuario.Senha = model.Senha;
                    }

                    this.usuarioBusiness.Update(usuario);
                }
                else
                {
                    result = RedirectToAction(ActionNovo);
                    usuario.Nome = model.Nome;
                    usuario.Login = model.Login;
                    usuario.Senha = model.Senha;
                    usuario.Email = model.Email;
                    usuario.LastModifiedDate = DateTime.Now;
                    usuario.Status = "ADDED";

                    this.usuarioBusiness.Add(usuario);
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

        public ActionResult Alterar(int id)
        {
            var entity = this.usuarioBusiness.GetById(id);

            var model = new UsuarioViewModel();

            model.ID = entity.ID;
            model.Nome = entity.Nome;
            model.Login = entity.Login;
            model.Senha = entity.Senha;
            model.Email = entity.Email;
            model.LastModifiedDate = entity.LastModifiedDate;
            model.Status = entity.Status;

            return View(model);
        }

        [HttpPost]
        public void Excluir(string cod)
        {
            try
            {
                int id;
                int.TryParse(cod, out id);
                var model = this.usuarioBusiness.GetById(id);
                if (model == null)
                {
                    throw new Exception("ID não encontrado");
                }
                this.usuarioBusiness.Delete(model);
                TempData[Constants.KEY_SUCCESS_MESSAGE] = Constants.GENERIC_MSG_FORM_SUCCESS_DELETE;
            }
            catch (Exception ex)
            {
                TempData[Constants.KEY_ERROR_MESSAGE] = ex.ToStringAll();
            }
        }
    }
}