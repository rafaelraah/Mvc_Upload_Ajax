using Mvc_Upload_Ajax.Models;
using Mvc_Upload_Ajax.Models.NHibernate;
using NHibernate;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Upload_Ajax.Controllers
{
    public class ArquivosController : Controller
    {
        // GET: Arquivos
        public ActionResult Index()
        {
            ViewData["arquivos"] = NHibernateHelper.OpenSession().QueryOver<Arquivo>().List();
            return View();
        }

        public JsonResult Upload()
        {
            string ultimaImagem = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; 
                string fileName = file.FileName;
                Stream fileContent = file.InputStream;
               
                //Persistir o nome do arquivo no banco de dados, e retornar o ID do arquivo.
                Arquivo arquivo = new Arquivo();
                arquivo.NomeArquivo = fileName;
                arquivo.DataCriacao = DateTime.Now;
                using(ISession sessao = NHibernateHelper.OpenSession())
                {
                    using(var transacao = sessao.BeginTransaction()) { 
                        sessao.Save(arquivo);
                        transacao.Commit();
                    }
                }
                file.SaveAs(Server.MapPath("~/Arquivos/") + arquivo.IdArquivo + Path.GetExtension(fileName));
                ultimaImagem = arquivo.IdArquivo + Path.GetExtension(fileName); //Só pra aparecer como nova imagem inserida
            }
            return Json(ultimaImagem);
        }
    }
}