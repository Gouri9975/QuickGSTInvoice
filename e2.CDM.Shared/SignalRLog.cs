using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;
using System.Collections.ObjectModel;

namespace e2.CDM.Lib
{

    [Serializable()]
    public class SignalRLog : Csla.BusinessBase<SignalRLog>
    {

        #region Constuctor
        public SignalRLog()
        { }
        #endregion

        #region Business Properties and Methods

        public static readonly PropertyInfo<Guid> SignalRLogIDProperty = RegisterProperty<Guid>(c => c.SignalRLogID);
        public Guid SignalRLogID
        {
            get { return GetProperty(SignalRLogIDProperty); }
            set { SetProperty(SignalRLogIDProperty, value); }
        }
        public static readonly PropertyInfo<string> CallTypeProperty = RegisterProperty<string>(nameof(CallType));
        public string CallType
        {
            get => GetProperty(CallTypeProperty);
            set => SetProperty(CallTypeProperty, value);
        }
        public static readonly PropertyInfo<Guid> DeviceIDProperty = RegisterProperty<Guid>(nameof(DeviceID));
        public Guid DeviceID
        {
            get => GetProperty(DeviceIDProperty);
            set => SetProperty(DeviceIDProperty, value);
        }
        public static readonly PropertyInfo<string> CallInfoProperty = RegisterProperty<string>(nameof(CallInfo));
        public string CallInfo
        {
            get => GetProperty(CallInfoProperty);
            set => SetProperty(CallInfoProperty, value);
        }
        public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
        public string Status
        {
            get { return GetProperty(StatusProperty); }
            set { SetProperty(StatusProperty, value); }
        }
        public static readonly PropertyInfo<string> AuditInfoStrProperty = RegisterProperty<string>(c => c.AuditInfoStr);
        public string AuditInfoStr
        {
            get { return GetProperty(AuditInfoStrProperty); }
            set { SetProperty(AuditInfoStrProperty, value); }
        }
        public static readonly PropertyInfo<DateTime> LogDateProperty = RegisterProperty<DateTime>(c => c.LogDate);
        public DateTime LogDate
        {
            get { return GetProperty(LogDateProperty); }
            set { SetProperty(LogDateProperty, value); }
        }
        public static readonly PropertyInfo<SignalRLogJsonBO> SignalRLogJsonBOProperty = RegisterProperty<SignalRLogJsonBO>(c => c.SignalRLogJsonBO);
        public SignalRLogJsonBO SignalRLogJsonBO
        {
            get { return GetProperty(SignalRLogJsonBOProperty); }
            set { SetProperty(SignalRLogJsonBOProperty, value); }
        }

        protected override object GetIdValue()
        {
            return SignalRLogID;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //
            // ID
            //
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(InvReceiptIDProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptIDProperty, 20));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(InvReceiptNoProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptNoProperty, 20));

            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(InvReceiptTypeIDProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptTypeIDProperty, 200));

            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(InvReceiptStatusProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptStatusProperty, 20));
            //
            // CarrierID
            //
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        protected void AddAuthorizationRules()
        {
        }

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SignalRLog
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SignalRLog
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SignalRLog
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SignalRLog
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<SignalRLog> NewSignalRLogAsync()
        {
            try
            {
                if (!CanAddObject())
                    throw new System.Security.SecurityException("User not authorized to add a SignalRLog");
                return await DataPortal.CreateAsync<SignalRLog>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async System.Threading.Tasks.Task<SignalRLog> GetSignalRLogAsync(Guid ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SignalRLog");
            return await DataPortal.FetchAsync<SignalRLog>(new Criteria(ID));
        }

        public static async void DeleteSignalRLogAsync(Guid ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SignalRLog");
            await DataPortal.DeleteAsync<SignalRLog>(new Criteria(ID));
        }
#if !SILVERLIGHT && !NETFX_CORE
        public static SignalRLog NewSignalRLog()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SignalRLog");
            return DataPortal.Create<SignalRLog>();
        }
        public static SignalRLog GetSignalRLog(Guid ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SignalRLog");
            return DataPortal.Fetch<SignalRLog>(new Criteria(ID));
        }
        public static void DeleteSignalRLog(Guid ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SignalRLog");
            DataPortal.Delete<SignalRLog>(new Criteria(ID));
        }
#endif
        #endregion //Factory Methods

        #region Criteria

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {

            public static readonly PropertyInfo<Guid> IDProperty = RegisterProperty<Guid>(c => c.ID);
            public Guid ID
            {
                get { return ReadProperty(IDProperty); }
                set { LoadProperty(IDProperty, value); }
            }
            public Criteria()
            { }
            public Criteria(Guid _ID)
            {
                this.ID = _ID;
            }
        }
        [Serializable()]
        private class DateCriteria : CriteriaBase<DateCriteria>
        {

            public static readonly PropertyInfo<DateTime> DateProperty = RegisterProperty<DateTime>(c => c.Date);
            public DateTime Date
            {
                get { return ReadProperty(DateProperty); }
                set { LoadProperty(DateProperty, value); }
            }

            public DateCriteria()
            { }
            public DateCriteria(DateTime Date)
            {
                this.Date = Date;
            }
        }
        #endregion //Criteria

        #region Data Access - Create

        protected override void DataPortal_Create()
        {
            SignalRLogID = Guid.NewGuid();
            AuditInfoStr = "";
            LogDate = DateTime.UtcNow;
            Status = "ACTIVE";

            SignalRLogJsonBO = SignalRLogJsonBO.NewSignalRLogJSON();
            base.DataPortal_Create();

            BusinessRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access

#if !NETFX_CORE
        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            try
            {
                using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
                {
                    //set option to eager load child object(s)
                    var data = mgr.DataContext.SignalRLog_GetByID(criteria.ID).FirstOrDefault();
                    if (data != null)
                    {
                        SignalRLogID = data.SignalRLogID;
                        LogDate = data.LogDate ?? DateTime.MinValue;
                        CallType = data.CallType;
                        DeviceID = data.DeviceID ?? Guid.Empty;
                        Status = data.Status;
                        CallInfo = data.CallInfo;
                        AuditInfoStr = data.AuditInfoJSON;
                        if (!string.IsNullOrEmpty(data.SignalRLogJSON))
                        {
                            CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.SignalRLogJSON);
                            if (CDMdto.ClassName.Equals("SignalRLogJson"))
                                SignalRLogJsonBO = DataPortal.FetchChild<SignalRLogJsonBO>(data.SignalRLogJSON);
                        }
                        //if (!string.IsNullOrEmpty(data.AuditInfoStr))
                        //    AuditInfoStr = Newtonsoft.Json.JsonConvert.DeserializeObject<AuditInfoJsonDTO>(data.AuditInfoStr);
                    }
                    MarkOld();
                }

            }//using
            catch (Exception e)
            {
                throw;
            }
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            try
            {
                UpdateObjectIDs();

                using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
                {

                    string AuditInfoJsonStr = e2.BDM.Lib.AuditInfoJsonDTO.GetAuditInfoJsonStr();

                    string SignalRLogJsonBOStr = null;
                    if (SignalRLogJsonBO != null)
                    {
                        SignalRLogJsonBOStr = OdataCDMJson<SignalRLogJsonDTO>.GetJsonString(SignalRLogJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.SignalRLog_Add(SignalRLogID, LogDate, CallType, DeviceID, AuditInfoJsonStr, CallInfo, SignalRLogJsonBOStr, Status);
                    FieldManager.UpdateChildren(this);
                }//using
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion //Data Access - Insert
        private void UpdateObjectIDs()
        {
            //if (SignalRLogID == "NEW")
            //{
            //    SignalRLogID = CDMEntityKeys.SignalRLogIDNextId();
            //}

            //if (sa == "NEW")
            //{
            //    InvReceiptNo = CDMEntityKeys.INVRECEIPTNONextId();
            //}
        }

        #region Data Access - Update
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            try
            {
                UpdateObjectIDs();

                using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
                {
                    string AuditInfoJsonStr = e2.BDM.Lib.AuditInfoJsonDTO.GetAuditInfoJsonStr();
                    string SignalRLogJsonBOStr = null;
                    if (SignalRLogJsonBO != null)
                    {
                        SignalRLogJsonBOStr = OdataCDMJson<SignalRLogJsonDTO>.GetJsonString(SignalRLogJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.SignalRLog_Upd(SignalRLogID, LogDate, CallType, DeviceID, AuditInfoJsonStr, AuditInfoJsonStr, SignalRLogJsonBOStr, Status);
                    FieldManager.UpdateChildren(this);
                }//using
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion //Data Access - Update

        #region Data Access - Delete

        private void DataPortal_Delete(Criteria criteria)
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                         .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {
                mgr.DataContext.SignalRLog_Void(criteria.ID);
            }//using
        }
        #endregion //Data Access - Delete

#endif
        #endregion //Data Access
    }

    #region SignalRLogJsonDTOJSON

    #region SignalRLogJsonDTO

    public class SignalRLogJsonDTO
    {
        //public string SignalRLogName { get; set; }
        //public string SignalRLogDesc { get; set; }
        //public string SignalRLogType { get; set; }

        public string ClassName { get; set; }
        public SignalRLogJsonDTO()
        {
            ClassName = "SignalRLogJson";
        }
    }
    #endregion

    [Serializable()]
    public class SignalRLogJsonBO : BusinessBase<SignalRLogJsonBO>
    {
        #region Constructor
        public SignalRLogJsonBO()
        {
            MarkAsChild();
        }

        public SignalRLogJsonDTO ConvertToDTO()
        {
            SignalRLogJsonDTO b = new SignalRLogJsonDTO();
            //b.SignalRLogName = this.SignalRLogName;
            //b.SignalRLogDesc = this.SignalRLogDesc;       
            //b.SignalRLogType = this.SignalRLogType;       
            return b;
        }
        #endregion

        #region Business Properties

        //    public static readonly PropertyInfo<string> SignalRLogTypeProperty = RegisterProperty<string>(nameof(SignalRLogType));
        //    public string SignalRLogType
        //    {
        //        get => GetProperty(SignalRLogTypeProperty);
        //        set => SetProperty(SignalRLogTypeProperty, value);
        //    }
        //    public static readonly PropertyInfo<string> SignalRLogDescProperty = RegisterProperty<string>(c => c.SignalRLogDesc);
        //    public string SignalRLogDesc
        //    {
        //        get { return GetProperty(SignalRLogDescProperty); }
        //        set { SetProperty(SignalRLogDescProperty, value); }
        //    }
        //public static readonly PropertyInfo<string> SignalRLogNameProperty = RegisterProperty<string>(c => c.SignalRLogName);
        //public string SignalRLogName
        //{
        //  get { return GetProperty(SignalRLogNameProperty); }
        //  set { SetProperty(SignalRLogNameProperty, value); }
        //}
        #endregion

        #region Validation Rules
        protected override void AddBusinessRules()
        {
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(HeadingProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(SubHeadingProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(ContentProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(TagsProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(RatingProperty));
        }
        #endregion

        public static SignalRLogJsonBO NewSignalRLogJSON()
        {
            return DataPortal.CreateChild<SignalRLogJsonBO>();
        }
        protected override void Child_Create()
        {
            base.Child_Create();
        }

#if !NETFX_CORE
        private void Child_Fetch(string BlogJsondtojson)
        {
            using (null)
            {
                SignalRLogJsonDTO SignalRLogJson = Newtonsoft.Json.JsonConvert.DeserializeObject<SignalRLogJsonDTO>(BlogJsondtojson);
                if (SignalRLogJson != null)
                    Child_Fetch(SignalRLogJson);
            }
        }
        private void Child_Fetch(SignalRLogJsonDTO data)
        {

            //SignalRLogDesc = data.SignalRLogDesc;
            //SignalRLogName = data.SignalRLogName;
            //SignalRLogType = data.SignalRLogType;
            MarkOld();
        }

        #region Data Access - Insert

        private void Child_Insert(SignalRLog parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        private void Child_Update(SignalRLog parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        private void Child_DeleteSelf(SignalRLog parent)
        {
            MarkNew();
        }
        #endregion //Data Access - Delete
#endif
    }
    #endregion

}