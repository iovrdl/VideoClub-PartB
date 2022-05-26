using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;
using VideoClub.Infrastructure.Services.Implementations;
using VideoClub.Infrastructure.Services.Interfaces;

namespace VideoClub.Web
{
    public class ContainerConfig
    {
        public static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CustomerService>()
                .As<ICustomerService>()
                .InstancePerRequest();

            //TODO
            /*builder.RegisterType<FavoriteService>()
                .As<IFavoriteService>()
                .InstancePerRequest();*/

            builder.RegisterType<FilmService>()
                .As<IFilmService>()
                .InstancePerRequest();

            builder.RegisterType<CopyService>()
                .As<ICopyService>()
                .InstancePerRequest();

            builder.RegisterType<RentalService>()
                .As<IRentalService>()
                .InstancePerRequest();
            
            builder.RegisterType<PaginationService>()
                .As<IPaginationService>()
                .InstancePerRequest();

            builder.RegisterType<VideoClubDbContext>()
                .InstancePerRequest();

            builder.RegisterType<LoggingService>()
                .As<ILoggingService>()
                .InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}