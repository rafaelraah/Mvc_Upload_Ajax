using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Upload_Ajax.Models.Map
{
    public class ArquivoMap : ClassMap<Arquivo>
    {
        public ArquivoMap()
        {
            Id(x => x.IdArquivo).GeneratedBy.Identity();
            Map(x => x.NomeArquivo);
            Map(x => x.DataCriacao);
        }
    }
}