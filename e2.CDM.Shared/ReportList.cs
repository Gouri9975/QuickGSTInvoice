
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
  public class ReportList : Csla.ReadOnlyListBase<ReportList, ReportInfo>
  {
    #region Constuctor
    public ReportList()
    { }
    #endregion

    #region Authorization Rules

    public static bool CanGetObject()
    {
      //TODO: Define CanGetObject permission in ReportList
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogInfosViewGroup"))
      //	return true;
      //return false;
    }
    #endregion //Authorization Rules

    #region Factory Methods

    public static async System.Threading.Tasks.Task<ReportList> GetReportListAsync()
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
      return await DataPortal.FetchAsync<ReportList>();
    }
  


    public static ReportList GetReportList()
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
      return DataPortal.Fetch<ReportList>();
    }
   

#if !NETFX_CORE
#endif
    #endregion //Factory Methods


  

    #region Data Access - Fetch
#if !NETFX_CORE
        private void DataPortal_Fetch()
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.Report_GetAll()
                  select ReportInfo.GetReportInfo(row)
                );

                IsReadOnly = true;
            } //using
        }

       
#endif


    //Standard Ver


    #endregion //Data Access
  }
}
