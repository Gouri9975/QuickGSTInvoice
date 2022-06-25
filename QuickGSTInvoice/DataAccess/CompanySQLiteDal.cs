using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
  public class CompanySQLiteDal : ICompanyDal
  {
        SQLiteConnection db;
        public static SQLiteConnection GetConnection(string DbName)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbName + ".sqlite");
            return new SQLiteConnection(dbPath);

        }
        public CompanySQLiteDal()
        {
            db= GetConnection("Company");
            db.CreateTable<CompanyEntity>();
           
        }
       // RetailDataContext retailDataContext = new RetailDataContext();
    //private static readonly List<CompanyEntity> _CompanyTable = new List<CompanyEntity>
    //{ 
    //  new CompanyEntity { Id = 1, Name = "Andy"},
    //  new CompanyEntity { Id = 3, Name = "Buzz"}
    //};

    public bool Delete(Guid id)
    {
      var Company = db.Table<CompanyEntity>().Where(p => p.Id == id).FirstOrDefault();
            
            if (db.Delete(Company) > 0)
                return true;
            else
                return false;
     
    }

    //public bool Exists(int id)
    //{
    //  var Company = db.Table<CompanyEntity>().Where(p => p.Id == id).FirstOrDefault();
    //  return !(Company == null);
    //}

    public CompanyEntity Get(Guid id)
    {
      var Company = db.Table<CompanyEntity>().Where(p => p.Id == id).FirstOrDefault();
      if (Company != null)
        return Company;
      else
        throw new KeyNotFoundException($"Id {id}");
    }

    public List<CompanyEntity> Get()
    {
      // return projection of entire list
      return db.Table<CompanyEntity>().ToList();
    }

    public CompanyEntity Insert(CompanyEntity Company)
    {     
            db.Insert(Company);           
            return Company;
   }

    public CompanyEntity Update(CompanyEntity Company)
    {
      //lock (_CompanyTable)
      {
       // var old = Get(Company.Id);
      //  old.Name = Company.Name;
         db.Update(Company);     
        return Company;
      }
    }
  }
}
