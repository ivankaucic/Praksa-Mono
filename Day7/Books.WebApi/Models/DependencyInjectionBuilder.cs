using Autofac;
using Autofac.Integration.WebApi;
using Book.Service.Common;
using Books.Model.Common;
using Books.Model.Models;
using Books.Repository;
using Books.Repository.Common;
using Books.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Books.WebApi.Models
{
    public class DependencyInjectionBuilder
    {
        public void Build()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<DIModuleService>();
            builder.RegisterModule<DIModuleRepository>();
            builder.RegisterModule<DIModuleModel>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }

    }
}