using Autofac;
using Book.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Books.Service
{
    public class DIModuleService : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();
            base.Load(builder);
        }
    }
}
