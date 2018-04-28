using Domain.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Device.Location;
using Newtonsoft.Json.Linq;
using GoogleMaps.LocationServices;
using System.Threading;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;

namespace WebUI.Controllers.Api
{
    [EnableCors("*", "*", "*")]
    public class MobileController : ApiController
    {
        private SareWebContext dbcontext = new SareWebContext();

        /*
        public HttpResponseMessage GetCampanhas()
        {
            return Request.CreateResponse(HttpStatusCode.OK, dbcontext.Campanhas.Take(50).ToList(), "application/json");
        }
        public HttpResponseMessage GetClientes()
        {
            return Request.CreateResponse(HttpStatusCode.OK, dbcontext.Clientes.Take(50).ToList(), "application/json");
        }
        public HttpResponseMessage GetLookbooks()
        {
            return Request.CreateResponse(HttpStatusCode.OK, dbcontext.LookBooks.Take(50).ToList(), "application/json");
        }
        public HttpResponseMessage GetRevendedores()
        {
            return Request.CreateResponse(HttpStatusCode.OK, dbcontext.Revendedores.Take(50).ToList(), "application/json");
        }
        public HttpResponseMessage GetLoginRevendedora([FromUri] string email, string senha)
        {
            var result = dbcontext.Revendedores.Where(x => x.Email == email && x.Senha == senha).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
        }

        public HttpResponseMessage GetMudarSenha([FromUri] string email, string novaSenha)
        {
            RevendedorModel result = dbcontext.Revendedores.Where(x => x.Email == email).FirstOrDefault();
            result.Senha = novaSenha;

            dbcontext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Senha alterada com sucesso.", "application/json");
        }

        public HttpResponseMessage GetContatos()
        {
            return Request.CreateResponse(HttpStatusCode.OK, dbcontext.Contatos.Take(50).ToList(), "application/json");
        }
        public HttpResponseMessage GetLojas()
        {
            return Request.CreateResponse(HttpStatusCode.OK, dbcontext.Lojas.Take(50).ToList(), "application/json");
        }
        public HttpResponseMessage GetMarcas()
        {
            return Request.CreateResponse(HttpStatusCode.OK, dbcontext.Marca.Take(50).ToList(), "application/json");
        }
        public HttpResponseMessage GetRequestCanditada(string nome, string email, string endereco, string telefone, string cep)
        {
            var entity = new AlunoModel();
            entity.Email = email;
            entity.Nome = nome;
            entity.Endereco = endereco;
            entity.Telefone = telefone;
            entity.Cep = cep;

            dbcontext.Candidatas.Add(entity);
            dbcontext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Cadastrado com sucesso.", "application/json");
        }

        public HttpResponseMessage GetEnviarContato(string nome, string email, string cidade, string telefone, string mensagem)
        {
            var entity = new AvaliacaoGrupoModel();
            entity.Email = email;
            entity.Nome = nome;
            entity.Cidade = cidade;
            entity.Telefone = telefone;
            entity.Mensagem = mensagem;

            dbcontext.Contatos.Add(entity);
            dbcontext.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Mensagem enviada com sucesso.", "application/json");
        }

        //public HttpResponseMessage GetRevendedoresByCep(string cep)
        //{
        //    var locationService = new GoogleLocationService();
        //    Thread.Sleep(1000);
        //    var cepBusca = locationService.GetLatLongFromAddress(cep);
        //    var coordCep = new GeoCoordinate(cepBusca.Latitude, cepBusca.Longitude);

        //    var revendedoras = dbcontext.Revendedores.ToList();
        //    var distance = 0.0;

        //    List<RevendedorModel> lista = new List<RevendedorModel>();

        //    foreach (var item in revendedoras)
        //    {
        //        Thread.Sleep(1000);
        //        var coord = locationService.GetLatLongFromAddress(item.Cep);

        //        var latitude = coord.Latitude;
        //        var longitude = coord.Longitude;

        //        var coordItem = new GeoCoordinate(latitude, longitude);

        //        distance = coordItem.GetDistanceTo(coordCep);

        //        if (distance >= 2000.0)
        //        {
        //            lista.Add(item);
        //        }
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, lista, "application/json");
        //}

        public HttpResponseMessage GetRevendedoresByCep(string cep)
        {
            try
            {
                var url = String.Format(
                 "https://maps.google.com/maps/api/geocode/xml?address={0}&sensor=false",
                  Uri.EscapeDataString(cep));

                XmlDocument doc = new XmlDocument();
                doc.Load(url);

                var lat = doc.GetElementsByTagName("lat")[0].InnerText;
                var lng = doc.GetElementsByTagName("lng")[0].InnerText;

                var results = XElement.Load(url);

                // Check the status
                var status = doc.GetElementsByTagName("status")[0].InnerText;

                if (status == "OVER_QUERY_LIMIT")
                {
                    GetRevendedoresByCep(cep);
                }
                else if (status != "OK" && status != "ZERO_RESULTS")
                {
                    // Whoops, something else was wrong with the request...     
                }

                double latitude = double.Parse(lat, CultureInfo.InvariantCulture);
                double longitude = double.Parse(lng, CultureInfo.InvariantCulture);

                var coordCep = new GeoCoordinate(latitude, longitude);
                var locationService = new GoogleLocationService();

                var revendedoras = dbcontext.Revendedores.ToList();
                var distance = 0.0;

                List<RevendedorModel> lista = new List<RevendedorModel>();

                foreach (var item in revendedoras)
                {
                    var coord = locationService.GetLatLongFromAddress(item.Cep);

                    var revLat = coord.Latitude;
                    var revLong = coord.Longitude;

                    var coordItem = new GeoCoordinate(revLat, revLong);

                    distance = coordItem.GetDistanceTo(coordCep);

                    if (distance <= 2000.0)
                    {
                        lista.Add(item);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista, "application/json");
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc, "application/json");
            }
            

            
        }
        */
    }
}
