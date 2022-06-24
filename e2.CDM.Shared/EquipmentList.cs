
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
    public class EquipmentList : Csla.ReadOnlyListBase<EquipmentList, EquipmentInfo>
    {
        #region Constuctor
        public EquipmentList()
        { }
        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in EquipmentList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogInfosViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<EquipmentList> GetEquipmentListAsync()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<EquipmentList>();
        }

#if !NETFX_CORE
#endif
        #endregion //Factory Methods


        #region Filter Criteria

        #endregion //Filter Criteria

        #region Data Access - Fetch
#if !NETFX_CORE
        private void DataPortal_Fetch()
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.Equipment_GetAll()
                  select EquipmentInfo.GetEquipmentInfo(row)
                );

                IsReadOnly = true;
            } //using
        }

#endif


        //Standard Ver


        #endregion //Data Access
    }
}
