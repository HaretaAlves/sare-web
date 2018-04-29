using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class UsuarioViewModel
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Status { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public List<UsuarioModel> Usuarios { get; set; }

    }
}