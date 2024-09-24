using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate.Driver;
using NHibernate;
using System.Reflection;

namespace MyWallet
{
    public static class NHibernateConfig
    {
        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(connectionString)
                    .Driver<SqlClientDriver>())
                .Mappings(m =>
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    m.FluentMappings.AddFromAssembly(assembly);
                })
                .BuildSessionFactory();
        }
    }

}
