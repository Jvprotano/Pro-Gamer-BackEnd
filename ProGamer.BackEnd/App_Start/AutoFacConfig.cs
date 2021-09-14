using Autofac;
using Autofac.Integration.WebApi;
using ProGamer.BackEnd.Services.Implements;
using ProGamer.BackEnd.Services.Interfaces;
using System.Web.Http;

namespace ProGamer.BackEnd.App_Start
{
    public class AutoFacConfig
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            //registrar interfaces
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<HomeAppService>().As<IHomeAppService>();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}