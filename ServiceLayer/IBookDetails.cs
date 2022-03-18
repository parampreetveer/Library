using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Model;
using RepositoryLayer;

namespace ServiceLayer
{
    public interface IBookDetails
    {
        IList<BookDetails> GetBookDetails();
        BookDetails GetBookDetails(int bookid);
        void InsertBook(BookDetails book);
        
      

        

    }
}
