
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
    public class ActivityList : Csla.ReadOnlyListBase<ActivityList, ActivityInfo>
    {
        #region Constuctor
        public ActivityList()
        { }
        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ActivityList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogInfosViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<ActivityList> GetActivityListAsync()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<ActivityList>();
        }
        public static async System.Threading.Tasks.Task<ActivityList> GetProjectActivityListAsync()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<ActivityList>(new ActivityCriteria(""));
        }


        public static ActivityList GetActivityList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return DataPortal.Fetch<ActivityList>();
        }
        public static ActivityList GetALL_ProjectActivityList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return DataPortal.Fetch<ActivityList>(new ActivityCriteria(""));
        }

#if !NETFX_CORE
#endif
        #endregion //Factory Methods


        #region Filter Criteria

        [Serializable()]
        private class ActivityCriteria : CriteriaBase<ActivityCriteria>
        {

            public static readonly PropertyInfo<string> ActivityIDProperty = RegisterProperty<string>(c => c.ActivityID);
            public string ActivityID
            {
                get { return ReadProperty(ActivityIDProperty); }
                set { LoadProperty(ActivityIDProperty, value); }
            }
            public ActivityCriteria()
            { }
            public ActivityCriteria(string _ActivityID)
            {
                this.ActivityID = _ActivityID;
            }
        }

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
                  from row in mgr.DataContext.Activities_All()
                  select ActivityInfo.GetActivityInfo(row)
                );

                IsReadOnly = true;
            } //using
        }

        private void DataPortal_Fetch(ActivityCriteria criteria)
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.Activity_GetAll()
                  select ActivityInfo.GetActivityInfo(row)
                );

                IsReadOnly = true;
            } //using
        }

#endif


        //Standard Ver


        #endregion //Data Access
    }
}
