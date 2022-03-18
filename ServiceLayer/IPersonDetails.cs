using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Model;
using RepositoryLayer;

namespace ServiceLayer
{
    public interface IPersonDetails
    {
        IList<PersonDetails> GetPersonDetails();
        PersonDetails GetPersonDetails(int personid);
        void InsertPerson(PersonDetails person);
        
        void DeletePerson(int personid);
        void UpdatePerson(PersonDetails person);
      
    }
}
