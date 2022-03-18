using DomainLayer.Model;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PersoBookService : IPersoBookDetails
    {
        public ApplicationContext ApplicationContext;
        public PersoBookService(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;

        }
        public IList<PersoBooks> GetPersoBooks()
        {
            return ApplicationContext.Set<PersoBooks>().ToList();
        }

        public IList<PersoBooks> GetPersoBooks(string bookid)
        {
            return ApplicationContext.PersoBooks.Where(x => x.BookId == bookid).ToList();
        }


       

        public void InsertBookIn(PersoBooks book)
        {
            ApplicationContext.Add<PersoBooks>(book);
            ApplicationContext.SaveChanges();
        }

        public void UpdateBookIn(PersoBooks book)
        {
            ApplicationContext.Update<PersoBooks>(book);
            ApplicationContext.SaveChanges();

        }
    }
}
