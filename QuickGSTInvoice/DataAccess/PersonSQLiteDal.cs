using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
  public class PersonSQLiteDal : IPersonDal
  {
        SQLiteConnection db;
        public static SQLiteConnection GetConnection(string DbName)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbName + ".sqlite");
            return new SQLiteConnection(dbPath);

        }
        public PersonSQLiteDal()
        {
            db= GetConnection("Person");
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Person" + ".sqlite");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<PersonEntity>();
           
        }
       // RetailDataContext retailDataContext = new RetailDataContext();
    //private static readonly List<PersonEntity> _personTable = new List<PersonEntity>
    //{ 
    //  new PersonEntity { Id = 1, Name = "Andy"},
    //  new PersonEntity { Id = 3, Name = "Buzz"}
    //};

    public bool Delete(int id)
    {
      var person = db.Table<PersonEntity>().Where(p => p.Id == id).FirstOrDefault();
            
            if (db.Delete(person) > 0)
                return true;
            else
                return false;
     
    }

    public bool Exists(int id)
    {
      var person = db.Table<PersonEntity>().Where(p => p.Id == id).FirstOrDefault();
      return !(person == null);
    }

    public PersonEntity Get(int id)
    {
      var person = db.Table<PersonEntity>().Where(p => p.Id == id).FirstOrDefault();
      if (person != null)
        return person;
      else
        throw new KeyNotFoundException($"Id {id}");
    }

    public List<PersonEntity> Get()
    {
      // return projection of entire list
      return db.Table<PersonEntity>().ToList();
    }

    public PersonEntity Insert(PersonEntity person)
    {
      if (Exists(person.Id))
            throw new InvalidOperationException($"Key exists {person.Id}");
            int lastId = db.Table<PersonEntity>().Max(m => m.Id);
            person.Id = ++lastId;
            db.Insert(person);           
            return person;
   }

    public PersonEntity Update(PersonEntity person)
    {
      //lock (_personTable)
      {
        var old = Get(person.Id);
        old.Name = person.Name;
         db.Update(old);     
        return old;
      }
    }
  }
}
