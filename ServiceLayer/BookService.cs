using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer;

namespace ServiceLayer
{
    public class BookService : IBookDetails
    {
        public ApplicationContext ApplicationContext;
        public BookService(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            
        }
   

        public IList<BookDetails> GetBookDetails()
        {
            return ApplicationContext.Set<BookDetails>().ToList();

        }

        public BookDetails GetBookDetails(int bookid)
        {
            return ApplicationContext.Find<BookDetails>(bookid);
        }

        public void InsertBook(BookDetails book)
        {
            ApplicationContext.Add<BookDetails>(book);
            ApplicationContext.SaveChanges();
        }

      
        
    }
}
