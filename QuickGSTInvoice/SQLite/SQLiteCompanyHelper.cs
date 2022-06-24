using BusinessLibrary;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickGSTInvoice.SQLite
{


    public class SQLiteCompanyHelper
    {
        SQLiteConnection db;
        public SQLiteCompanyHelper(string DbName)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbName + ".sqlite");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<CompanyDTO>();
        }

        //Insert and Update new record  
        public int SaveItemAsync(CompanyDTO company)
        {
            if (!(company.ID.Equals(Guid.Empty)))
            {
                return db.Update(company);
            }
            else
            {
                return db.Insert(company);
            }
        }

        //Delete  
        public int DeleteItemAsync(CompanyDTO company)
        {
            return db.Delete(company);
        }

        //Read All Items  
        public List<CompanyDTO> GetItemsAsync()
        {
            return db.Table<CompanyDTO>().ToList();
        }


        //Read Item  
        public CompanyDTO GetItemAsync(Guid ID)
        {
            return db.Table<CompanyDTO>().Where(i => i.ID == ID).FirstOrDefault();
        }
    }
}
