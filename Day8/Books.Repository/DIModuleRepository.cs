using Autofac;
using Books.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repository
{
    public class DIModuleRepository : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            base.Load(builder);
        }
    }
}
