using Autofac;
using Books.Common;
using Books.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Models
{
    public class DIModuleModel : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Book>().As<IBook>();
            builder.RegisterType<Author>().As<IAuthor>();
            base.Load(builder);
        }
    }
}
