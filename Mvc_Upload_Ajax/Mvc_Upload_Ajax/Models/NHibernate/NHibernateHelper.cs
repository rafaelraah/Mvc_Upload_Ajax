using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Upload_Ajax.Models.NHibernate
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(@"Data Source=(local)\sqlexpress;Initial Catalog=Arquivos;Integrated Security=True")
                              .ShowSql()
                )
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Arquivo>())
               .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
               .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}