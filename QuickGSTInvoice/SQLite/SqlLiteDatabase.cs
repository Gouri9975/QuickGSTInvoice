using Maui.Common.Common;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui;

namespace Maui.Common.Sqlite
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection(string DbName);
    }
    [Serializable]
    public class KeyValueSql
    {
        [PrimaryKey]
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime SyncDate { get; set; }
        public string SyncComapnyAPI { get; set; }
    }
    public class SqLiteOdata<T>
    {
        private SQLiteConnection conn;


        //CREATE  
        public SqLiteOdata()
        {
           // conn = DependencyService.Get<ISQLite>().GetConnection(DbName);
           // conn.CreateTable<KeyValueSql>();
        }

        //READ  
        //public IEnumerable<T> GetMembers()
        //{
        //    var members = (from mem in conn.Table<KeyValueSql>() select mem);
            
        //    return members.ToList();
        //}
        //INSERT  
        public static SQLiteConnection GetConnection(string DbName)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbName + ".sqlite");
             return new SQLiteConnection(dbPath);

        }
        public string InsertUpdate(string DbName,string tablename, MyObservableCollection<T> List,bool IsUpdateLastSyncDT=true)
        {
            
            using (conn =GetConnection(DbName))
            {
                //conn.CreateTable<KeyValueSql>();
                KeyValueSql Table = new KeyValueSql();
                JsonSerializerSettings s = new JsonSerializerSettings();
                string json = JsonConvert.SerializeObject(List,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                //string json = JsonConvert.SerializeObject(List);
                Table.Key = tablename;
                Table.Value = json;
                Table.SyncDate = DateTime.UtcNow;
                Table.SyncComapnyAPI = "";

                object JsonDe = null;
                TableQuery<KeyValueSql> query = null;            
                query = conn.Table<KeyValueSql>();                          
                string result = string.Empty;
                //MyObservableCollection<T> list = new Common.MyObservableCollection<T>();
                bool IsTableKeyExist = false;
                try
                {
                    foreach (var item in query)
                    {
                        if (item.Key == tablename)
                        {
                            IsTableKeyExist = true;
                            if (IsUpdateLastSyncDT == false)
                                Table.SyncDate = item.SyncDate;
                            var add = conn.Update(Table);
                        }
                    }
                    if (IsTableKeyExist == false)
                    {
                        var add = conn.Insert(Table);
                    }
                }
                catch(Exception e)
                {
                    conn.CreateTable<KeyValueSql>();
                    foreach (var item in query)
                    {
                        if (item.Key == tablename)
                        {
                            IsTableKeyExist = true;
                            var add = conn.Update(Table);
                        }
                    }
                    if (IsTableKeyExist == false)
                    {
                        var add = conn.Insert(Table);
                    }

                }
                conn.Close();
            }
           
            return "success";
        }


        public MyObservableCollection<T> GetCacheFromSqLiteDB(string DbName, string tablename)
        {
            using (conn = GetConnection(DbName))
            {
                object JsonDe = null;
                var query = conn.Table<KeyValueSql>();
                string result = string.Empty;
                MyObservableCollection<T> list = new Common.MyObservableCollection<T>();
        try
        {
          //foreach (var item in query)
          {
              var   item = query.Where(p=>p.Key== tablename).FirstOrDefault();   
            if (item.Key == tablename)
            {
              JsonDe = JsonConvert.DeserializeObject(item.Value, list.GetType());
              list = (MyObservableCollection<T>)JsonDe;
              list.SyncDate = item.SyncDate;
              list.SyncComapnyAPI = item.SyncComapnyAPI;

            }
          }
        }
        catch(Exception e)
        {         
          conn.CreateTable<KeyValueSql>();
          foreach (var item in query)
          {
            if (item.Key == tablename)
            {
              JsonDe = JsonConvert.DeserializeObject(item.Value, list.GetType());
              list = (MyObservableCollection<T>)JsonDe;
              list.SyncDate = item.SyncDate;
              list.SyncComapnyAPI = item.SyncComapnyAPI;

            }
          }
        }
                conn.Close();
               
                return list;
                //path = null;
                //return list;
            }
        }
    public  void DeleteKeyValue(string DbName, string tablename)
    {
       using (conn = GetConnection(DbName))
      {
        conn.Delete<KeyValueSql>(tablename);
        conn.Close();
      }       
    }

        public static void DeleteKeyValue(string DbName, string tablename,bool IsNew=false)
        {
            try
            {
                using (var conn1 = GetConnection(DbName))
                {
                    conn1.Delete<KeyValueSql>(tablename);
                    conn1.Close();
                }
            }
            catch(Exception ex)
            {

            }
        }

        //DELETE  
        //public string Delete(int id)
        //{
        //    conn.Delete<Member>(id);
        //    return "success";
        //}
    }


}
