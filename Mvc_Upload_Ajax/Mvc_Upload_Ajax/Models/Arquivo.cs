using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Upload_Ajax.Models
{
    public class Arquivo
    {
        public virtual int IdArquivo { get; set; }
        public virtual string NomeArquivo { get; set; }
        public virtual DateTime DataCriacao { get; set; }
    }
}