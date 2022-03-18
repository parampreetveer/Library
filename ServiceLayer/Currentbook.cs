using DomainLayer.Model;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Currentbook : ICurrentbook
    {
        public ApplicationContext ApplicationContext;
        public Currentbook(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;

        }
        public IList<PersoBooks> GetPersoBooks()
        {
            return ApplicationContext.Set<PersoBooks>().ToList();
        }
        public IList<PersoBooks> GetCurrentBook(string personid)
        {
            return ApplicationContext.PersoBooks.Where(x=>x.PersonId==personid).ToList();
        }
    }
}
