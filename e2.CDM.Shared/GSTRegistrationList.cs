using System;
using System.Data;
using Csla;
using Csla.Data;
using System.Collections.Generic;
using e2.CSLA.Lib;

namespace e2.CDM.Lib
{
      [Serializable()] 
  public class GSTRegistrationList : Csla.NameValueListBase<string, string>
  {

        #region Business Methods


        public static async System.Threading.Tasks.Task<string> GSTRegistrationDefaultValueAsync()
        {
      GSTRegistrationList list = await GetGSTregistrationListAsync();
            if (list.Count > 0)
                return list.Items[0].Key;
            else
                throw new NullReferenceException(
                  "No ShipTermList available; default Value can not be returned");
        }

        public static async System.Threading.Tasks.Task<string> GetKeyStringAsync(string value)
        {
      GSTRegistrationList list = await GetGSTregistrationListAsync();
            for (int i = 0; i < list.Count; i++)
            {
                if (list.Items[i].Value == value)
                    return list.Items[i].Key;
            }
            return string.Empty;
        }

        public static async System.Threading.Tasks.Task<string> GetValueStringAsync(string key)
        {
      GSTRegistrationList list = await GetGSTregistrationListAsync();
            for (int i = 0; i < list.Count; i++)
            {
                if (list.Items[i].Key == key)
                    return list.Items[i].Value;
            }
            return string.Empty;
        }

        public static string GSTRegistrationDefaultValue() {
      GSTRegistrationList list = GetGSTregistrationList();
      if (list.Count > 0)
        return list.Items[0].Key;
      else
        throw new NullReferenceException(
          "No ShipTermList available; default Value can not be returned");
    }

    public static string GetKeyString(string value) {
      GSTRegistrationList list = GetGSTregistrationList();
      for (int i = 0; i < list.Count; i++) {
        if (list.Items[i].Value == value)
          return list.Items[i].Key;
      }
      return string.Empty;
    }

    public static string GetValueString(string key) {
      GSTRegistrationList list = GetGSTregistrationList();
      for (int i = 0; i < list.Count; i++) {
        if (list.Items[i].Key == key)
          return list.Items[i].Value;
      }
      return string.Empty;
    }

    #endregion //Business Methods

    #region Factory Methods
    public GSTRegistrationList()
    { /* require use of factory method */ }

    //private static GSTRegistrationList _list;
        private static Dictionary<string, GSTRegistrationList> _Dlist = new Dictionary<string, GSTRegistrationList>();
        private static GSTRegistrationList _list
        {
            get
            {
                return CacheD<GSTRegistrationList>.Get(_Dlist);
            }
            set

            {
                CacheD<GSTRegistrationList>.Set(_Dlist, value);
            }
        }

        public static GSTRegistrationList GetGSTregistrationList()
        {
          if (_list == null)
            _list = DataPortal.Fetch<GSTRegistrationList>();
          return _list;
        }

        public static async System.Threading.Tasks.Task<GSTRegistrationList> GetGSTregistrationListAsync()
        {
            if (_list == null)
                _list = await DataPortal.FetchAsync<GSTRegistrationList>();
            return _list;
        }

        public static void InvalidateCache()
        {
            //_list = null;
            CacheD<GSTRegistrationList>.Set(_Dlist, null);
        }
        #endregion //Factory Methods

        #region Data Access
//#if !NETFX_CORE
        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

      //using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.BDM.DAL.Lib.BDMEntitiesDataContext>
      //                          .GetManager(e2.BDM.DAL.Lib.Database.BDMConnection))
      //{
      //    var list = ctx.DataContext.GSTRegistrations_GetList();

      //foreach (var item in list)
      //    this.Add(new NameValuePair(item.GSTRegistrationID, item.Description));
      // }
      this.Add(new NameValuePair("1", "Regular"));
      this.Add(new NameValuePair("2", "Composition"));
      this.Add(new NameValuePair("3", "Consumer"));
      this.Add(new NameValuePair("4", "Unregistered"));
      IsReadOnly = true;
            RaiseListChangedEvents = true;
        }
//#endif
#endregion //Data Access

  }
}
