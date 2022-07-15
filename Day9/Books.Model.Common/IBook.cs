using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Model.Common
{
    public interface IBook
    {
        string Name { get; set; }
        System.Guid Author { get; set; }
        System.Guid Id { get; set; }
        string Genre { get; set; }
    }
}
