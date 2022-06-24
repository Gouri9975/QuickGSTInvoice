
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;
using System.Xml;
using System.Xml.Serialization;

namespace e2.CDM.Lib
{
  [Serializable()]
  public class HResourceList : Csla.ReadOnlyListBase<HResourceList, HResourceInfo>
  {
    #region Constuctor
    public HResourceList()
    { }
    #endregion

    #region Authorization Rules

    public static bool CanGetObject()
    {
      //TODO: Define CanGetObject permission in HResourceList
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("HResourceListViewGroup"))
      //	return true;
      //return false;
    }
    #endregion //Authorization Rules

    #region Factory Methods


    /*
    public static HResourceList GetHResourceList(string invReceiptID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a HResourceList");
      return DataPortal.Fetch<HResourceList>(new FilterCriteria(invReceiptID));
    }
    */

    public static async System.Threading.Tasks.Task<HResourceList> GetHResourceListAsync()
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a HResourceList");
      return await DataPortal.FetchAsync<HResourceList>();
    }
    //public static async System.Threading.Tasks.Task<HResourceList> GetHResourceListGetClntLstAsync(string SearchCriteria)
    //{
    //    if (!CanGetObject())
    //        throw new System.Security.SecurityException("User not authorized to view a HResourceList");
    //    return await DataPortal.FetchAsync<HResourceList>(new SingleCriteria<string>(SearchCriteria));
    //}

#if !NETFX_CORE

        public static HResourceList GetHResourceList()
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a HResourceList");
      return DataPortal.Fetch<HResourceList>();
    }
        public static HResourceList GetHResourceListGetClntLst(string SearchCriteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HResourceList");
            return DataPortal.Fetch<HResourceList>(new SingleCriteria<string>(SearchCriteria));
        }
#endif
    #endregion //Factory Methods


    #region Filter Criteria
    [Serializable()]
    private class FilterCriteria : CriteriaBase<FilterCriteria>
    {
      public static readonly PropertyInfo<string> InvReceiptIDProperty = RegisterProperty<string>(c => c.InvReceiptID);
      public string InvReceiptID
      {
        get { return ReadProperty(InvReceiptIDProperty); }
        private set { LoadProperty(InvReceiptIDProperty, value); }
      }
      public FilterCriteria() { }
      public FilterCriteria(string invReceiptID)
      {
        this.InvReceiptID = invReceiptID;
      }
    }


    #region Data Access - Fetch
#if !NETFX_CORE
        private void DataPortal_Fetch()
    {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection,"CDMDb"))
            {
                RaiseListChangedEvents = false;
                IsReadOnly = false;
                this.AddRange(
                  from row in mgr.DataContext.HResource_GetAll()
                  select HResourceInfo.GetHResourceInfo(row)
                );

                IsReadOnly = true;
                RaiseListChangedEvents = true;
            } //using
        }

#endif


    //Standard Ver


    #endregion //Data Access - Fetch
    #endregion //Data Access
  }
}
