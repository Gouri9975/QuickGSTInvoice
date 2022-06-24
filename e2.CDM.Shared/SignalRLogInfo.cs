
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public partial class SignalRLogInfo : Csla.ReadOnlyBase<SignalRLogInfo>
    {
        #region Constuctor
        public SignalRLogInfo()
        { }
        #endregion

        #region Business Properties and Methods

        public static readonly PropertyInfo<Guid> SignalRLogIDProperty = RegisterProperty<Guid>(c => c.SignalRLogID);
        public Guid SignalRLogID
        {
            get { return GetProperty(SignalRLogIDProperty); }
            set { LoadProperty(SignalRLogIDProperty, value); }
        }
        public static readonly PropertyInfo<string> CallTypeProperty = RegisterProperty<string>(nameof(CallType));
        public string CallType
        {
            get => GetProperty(CallTypeProperty);
            set => LoadProperty(CallTypeProperty, value);
        }
        public static readonly PropertyInfo<Guid> DeviceIDProperty = RegisterProperty<Guid>(nameof(DeviceID));
        public Guid DeviceID
        {
            get => GetProperty(DeviceIDProperty);
            set => LoadProperty(DeviceIDProperty, value);
        }
        public static readonly PropertyInfo<string> CallInfoProperty = RegisterProperty<string>(nameof(CallInfo));
        public string CallInfo
        {
            get => GetProperty(CallInfoProperty);
            set => LoadProperty(CallInfoProperty, value);
        }
        public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
        public string Status
        {
            get { return GetProperty(StatusProperty); }
            set { LoadProperty(StatusProperty, value); }
        }
        public static readonly PropertyInfo<string> AuditInfoJSONProperty = RegisterProperty<string>(c => c.AuditInfoJSON);
        public string AuditInfoJSON
        {
            get { return GetProperty(AuditInfoJSONProperty); }
            set { LoadProperty(AuditInfoJSONProperty, value); }
        }
        public static readonly PropertyInfo<DateTime> LogDateProperty = RegisterProperty<DateTime>(c => c.LogDate);
        public DateTime LogDate
        {
            get { return GetProperty(LogDateProperty); }
            set { LoadProperty(LogDateProperty, value); }
        }
        public static readonly PropertyInfo<SignalRLogJsonBO> SignalRLogJsonBOProperty = RegisterProperty<SignalRLogJsonBO>(c => c.SignalRLogJsonBO);
        public SignalRLogJsonBO SignalRLogJsonBO
        {
            get { return GetProperty(SignalRLogJsonBOProperty); }
            set { LoadProperty(SignalRLogJsonBOProperty, value); }
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
        internal static SignalRLogInfo GetSignalRLogInfo(e2.CDM.DAL.Lib.SignalRLog_GetAllResult data)
        {
            SignalRLogInfo item = new SignalRLogInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.SignalRLog_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                SignalRLogID = data.SignalRLogID;
                LogDate = data.LogDate ?? DateTime.MinValue;
                CallType = data.CallType;
                DeviceID = data.DeviceID ?? Guid.Empty;
                Status = data.Status;
                CallInfo = data.CallInfo;
                AuditInfoJSON = data.AuditInfoJSON;
                if (!string.IsNullOrEmpty(data.SignalRLogJSON))
                {
                    CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.SignalRLogJSON);
                    if (CDMdto.ClassName.Equals("SignalRLogJson"))
                        SignalRLogJsonBO = DataPortal.FetchChild<SignalRLogJsonBO>(data.SignalRLogJSON);
                }
            }
            OnFetched();
        }

        internal static SignalRLogInfo GetSignalRLogInfo(e2.CDM.DAL.Lib.SignalRLog_GetByTypeResult data)
        {
            SignalRLogInfo item = new SignalRLogInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.SignalRLog_GetByTypeResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                SignalRLogID = data.SignalRLogID;
                LogDate = data.LogDate ?? DateTime.MinValue;
                CallType = data.CallType;
                DeviceID = data.DeviceID ?? Guid.Empty;
                Status = data.Status;
                CallInfo = data.CallInfo;
                AuditInfoJSON = data.AuditInfoJSON;
                if (!string.IsNullOrEmpty(data.SignalRLogJSON))
                {
                    CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.SignalRLogJSON);
                    if (CDMdto.ClassName.Equals("SignalRLogJson"))
                        SignalRLogJsonBO = DataPortal.FetchChild<SignalRLogJsonBO>(data.SignalRLogJSON);
                }
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
