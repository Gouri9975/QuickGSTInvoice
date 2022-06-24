﻿
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
    public class SignalRLogList : Csla.ReadOnlyListBase<SignalRLogList, SignalRLogInfo>
    {
        #region Constuctor
        public SignalRLogList()
        { }
        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SignalRLogList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogInfosViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<SignalRLogList> GetSignalRLogListAsync()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<SignalRLogList>();
        }
        public static async System.Threading.Tasks.Task<SignalRLogList> GetSignalRLog_ByIDAsync(string CallType)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<SignalRLogList>(new SignalRLogCriteria(CallType));
        }


        public static SignalRLogList GetSignalRLogList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return DataPortal.Fetch<SignalRLogList>();
        }
        public static SignalRLogList GetSignalRLog_ByID(string CallType)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return DataPortal.Fetch<SignalRLogList>(new SignalRLogCriteria(CallType));
        }

#if !NETFX_CORE
#endif
        #endregion //Factory Methods


        #region Filter Criteria

        [Serializable()]
        private class SignalRLogCriteria : CriteriaBase<SignalRLogCriteria>
        {

            public static readonly PropertyInfo<string> SignalRLogIDProperty = RegisterProperty<string>(c => c.Type);
            public string Type
            {
                get { return ReadProperty(SignalRLogIDProperty); }
                set { LoadProperty(SignalRLogIDProperty, value); }
            }
            public SignalRLogCriteria()
            { }
            public SignalRLogCriteria(string _Type)
            {
                this.Type = _Type;
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
                  from row in mgr.DataContext.SignalRLog_GetAll()
                  select SignalRLogInfo.GetSignalRLogInfo(row)
                );

                IsReadOnly = true;
            } //using
        }
        private void DataPortal_Fetch(SignalRLogCriteria criteria)
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.SignalRLog_GetByType(criteria.Type)
                  select SignalRLogInfo.GetSignalRLogInfo(row)
                );

                IsReadOnly = true;
            } //using
        }

#endif


        //Standard Ver


        #endregion //Data Access
    }
}
