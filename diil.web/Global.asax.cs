using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using diil.web.DataBase;
using diil.web.Services.Imp;
using diil.web.Services.Interface;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace diil.web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static System.Web.Mvc.IDependencyResolver mvcResolver;
        public static System.Web.Http.Dependencies.IDependencyResolver apiResolver;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region IoC
            // 文档参考 http://autofaccn.readthedocs.io/zh/latest/getting-started/index.html
            var builder = new ContainerBuilder();
            // Mvc Register
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).AsSelf().PropertiesAutowired();
            builder.RegisterFilterProvider();

            //WebApi Register
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).AsSelf().PropertiesAutowired();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.RegisterWebApiModelBinderProvider();

            //Services
            builder.RegisterType<ArticleService>().As<IArticleService>().InstancePerDependency();

            // 注册Autofac Module
            builder.RegisterModule(new LoggingModule());

            var connectionString = ConfigurationManager.ConnectionStrings["components"].ConnectionString;
            //数据库
            builder.Register<IDbContext>(c => new DIILContext(connectionString)).InstancePerLifetimeScope();
            //repositories
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            var container = builder.Build();

            // WebApiResolver
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            apiResolver = webApiResolver;
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var resolver = new AutofacDependencyResolver(container);
            mvcResolver = resolver;
            DependencyResolver.SetResolver(mvcResolver);

            #endregion
        }
    }
}
