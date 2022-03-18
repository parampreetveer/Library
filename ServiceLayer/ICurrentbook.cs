using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ICurrentbook
    {
        IList<PersoBooks> GetPersoBooks();
        IList<PersoBooks> GetCurrentBook(string personid);
    }
}
