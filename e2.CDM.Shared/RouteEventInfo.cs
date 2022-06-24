
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public partial class RouteEventInfo : Csla.ReadOnlyBase<RouteEventInfo>
    {
        #region Constuctor
        public RouteEventInfo()
        {
     
    }
   
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<Guid> EventIDProperty = RegisterProperty<Guid>(c => c.EventID);
        public Guid EventID
        {
            get { return GetProperty(EventIDProperty); }
            set { LoadProperty(EventIDProperty, value); }
        }

        public static readonly PropertyInfo<DateTime> EventDateTimeProperty = RegisterProperty<DateTime>(c => c.EventDateTime);
        public DateTime EventDateTime
        {
            get { return GetProperty(EventDateTimeProperty); }
            set { LoadProperty(EventDateTimeProperty, value); }
        }
        public static readonly PropertyInfo<string> EventStatusProperty = RegisterProperty<string>(c => c.EventStatus);
        public string EventStatus
        {
            get { return GetProperty(EventStatusProperty); }
            set { LoadProperty(EventStatusProperty, value); }
        }
        public static readonly PropertyInfo<string> DriverIDProperty = RegisterProperty<string>(c => c.DriverID);
        public string DriverID
        {
            get { return GetProperty(DriverIDProperty); }
            set { LoadProperty(DriverIDProperty, value); }
        }
        public static readonly PropertyInfo<string> RouteIDProperty = RegisterProperty<string>(c => c.RouteID);
        public string RouteID
        {
            get { return GetProperty(RouteIDProperty); }
            set { LoadProperty(RouteIDProperty, value); }
        }
        public static readonly PropertyInfo<string> RouteStatusProperty = RegisterProperty<string>(c => c.RouteStatus);
        public string RouteStatus
        {
            get { return GetProperty(RouteStatusProperty); }
            set { LoadProperty(RouteStatusProperty, value); }
        }

        public static readonly PropertyInfo<string> RouteEventJsonBOProperty = RegisterProperty<string>(c => c.RouteEventJsonBO);
        public string RouteEventJsonBO
        {
            get { return GetProperty(RouteEventJsonBOProperty); }
            set { LoadProperty(RouteEventJsonBOProperty, value); }
        }

        public CurrentTripInfoModel GetcurrentTripInfoModel()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentTripInfoModel>(RouteEventJsonBO);
        }

        #endregion //Business Properties and Methods

        #region Authorization Rules
        protected void AddAuthorizationRules()
        {


        }

        #endregion //Authorization Rules

        #region Factory Methods

        #endregion //Factory Methods

        #region Data Access

        #region Data Access - Fetch
#if !NETFX_CORE
        internal static RouteEventInfo GetRouteEventInfo(e2.CDM.DAL.Lib.RouteEvent_GetAllResult data)
        {
            RouteEventInfo item = new RouteEventInfo();
            item.Fetch(data);
            return item;
        }

   
        private void Fetch(e2.CDM.DAL.Lib.RouteEvent_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                EventID = data.EventID;
                EventDateTime = data.EventDateTime;
                EventStatus = data.EventStatus;
                DriverID = data.DriverID;
                RouteID = data.RouteID;
                RouteStatus = data.RouteStatus;
                RouteEventJsonBO = data.RouteEventJSON;
                //if (!string.IsNullOrEmpty(data.RouteEventJSON))
                //{
                //  CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.RouteEventJSON);
                //  if (CDMdto.ClassName.Equals("RouteEventJson"))
                //    RouteEventJsonBO = DataPortal.FetchChild<RouteEventJsonBO>(data.RouteEventJSON);
                //}
            }
            OnFetched();
        }
        partial void OnFetching(ref bool cancel);
        partial void OnFetched();

        private void FetchObject(SafeDataReader dr)
        {


        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
#endif

        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
