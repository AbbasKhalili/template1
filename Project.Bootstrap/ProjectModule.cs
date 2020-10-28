using System.Data;
using System.Data.Common;
using Autofac;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.DataAccess;
using Project.Domain;
using Project.Query;
using Project.Service;

namespace Project.Bootstrap
{
    internal class ProjectModule : Module
    {
        private readonly string _connectionString;

        public ProjectModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ProjectRepository).Assembly)
                .Where(a => typeof(IRepository).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ProjectService).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ProjectQuery).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


            builder.Register<DbConnection>(z =>
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }).InstancePerLifetimeScope().As<IDbConnection>().OnRelease(a => a.Close());


            builder.Register<ProjectContext>(s =>
            {
                var options = new DbContextOptionsBuilder<ProjectContext>()
                    .UseSqlServer(_connectionString)
                    .Options;
                var context = new ProjectContext(options);
                return context;
            }).InstancePerLifetimeScope().OnRelease(a => a.Dispose());
        }
    }
}
