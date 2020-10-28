using Autofac;

namespace Project.Bootstrap
{
    public static class RegisterQueueModule
    {
        public static void AddModule(this ContainerBuilder builder, string connectionString)
        {
            builder.RegisterModule(new ProjectModule(connectionString));
        }
    }
}