using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;

namespace ProGamer.BackEnd.App_Start
{
    public class AutofacConfig
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // registrar interfaces
            //builder.RegisterType<Service>().As<InterfaceService>();
    
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}