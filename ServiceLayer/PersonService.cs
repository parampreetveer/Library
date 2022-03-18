using DomainLayer.Model;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class PersonService : IPersonDetails
    {
        public ApplicationContext ApplicationContext;
        

        public PersonService(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public void DeletePerson(int personid)
        {
            PersonDetails c = GetPersonDetails(personid);
            if (personid != null)
            {
                ApplicationContext.Remove<PersonDetails>(c);
                ApplicationContext.SaveChanges();
            }

        }

        public IList<PersonDetails> GetPersonDetails()
        {
            return ApplicationContext.Set<PersonDetails>().ToList();
        }

        public PersonDetails GetPersonDetails(int personid)
        {

            
            return ApplicationContext.Find<PersonDetails>(personid);
        }

        public void InsertPerson(PersonDetails person)
        {
            ApplicationContext.Add<PersonDetails>(person);
            ApplicationContext.SaveChanges();
        }

        public void UpdatePerson(PersonDetails person)
        {
            ApplicationContext.Update<PersonDetails>(person);
            ApplicationContext.SaveChanges();
        }

       
       

    }
}
