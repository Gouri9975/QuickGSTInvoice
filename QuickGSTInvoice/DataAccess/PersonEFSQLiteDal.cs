//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace DataAccess
//{
//  public class PersonEFSQLiteDal : IPersonDal
//  {
//     RetailDataContext retailDataContext = new RetailDataContext();
//    //private static readonly List<PersonEntity> _personTable = new List<PersonEntity>
//    //{ 
//    //  new PersonEntity { Id = 1, Name = "Andy"},
//    //  new PersonEntity { Id = 3, Name = "Buzz"}
//    //};

//    public bool Delete(int id)
//    {
//      var person = retailDataContext.Persons.Where(p => p.Id == id).FirstOrDefault();
//            retailDataContext.Persons.Remove(person);
//            if (retailDataContext.SaveChanges() > 0)
//                return true;
//            else
//                return false;
     
//    }

//    public bool Exists(int id)
//    {
//      var person = retailDataContext.Persons.Where(p => p.Id == id).FirstOrDefault();
//      return !(person == null);
//    }

//    public PersonEntity Get(int id)
//    {
//      var person = retailDataContext.Persons.Where(p => p.Id == id).FirstOrDefault();
//      if (person != null)
//        return person;
//      else
//        throw new KeyNotFoundException($"Id {id}");
//    }

//    public List<PersonEntity> Get()
//    {
//      // return projection of entire list
//      return retailDataContext.Persons.Where(r => true).ToList();
//    }

//    public PersonEntity Insert(PersonEntity person)
//    {
//      if (Exists(person.Id))
//            throw new InvalidOperationException($"Key exists {person.Id}");
//            int lastId = retailDataContext.Persons.Max(m => m.Id);
//            person.Id = ++lastId;
//            retailDataContext.Persons.Add(person);
//            retailDataContext.SaveChanges();
//            return person;
//   }

//    public PersonEntity Update(PersonEntity person)
//    {
//      //lock (_personTable)
//      {
//        var old = Get(person.Id);
//        old.Name = person.Name;
//        retailDataContext.Persons.Update(person);
//        retailDataContext.SaveChanges();
//        return old;
//      }
//    }
//  }
//}
