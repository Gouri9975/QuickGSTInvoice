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
    public class Report2ScheduleEmail : Csla.BusinessBase<Report2ScheduleEmail>
    {

        #region Constuctor
        public Report2ScheduleEmail()
        { }
        #endregion

        #region Business Properties and Methods

        public static readonly PropertyInfo<Report2ScheduleEmailJsonBO> Report2ScheduleEmailJsonBOProperty = RegisterProperty<Report2ScheduleEmailJsonBO>(c => c.Report2ScheduleEmailJsonBO);
        public Report2ScheduleEmailJsonBO Report2ScheduleEmailJsonBO
        {
            get { return GetProperty(Report2ScheduleEmailJsonBOProperty); }
            set { SetProperty(Report2ScheduleEmailJsonBOProperty, value); }
        }
        public static readonly PropertyInfo<Guid> Report2ScheduleEmailIDProperty = RegisterProperty<Guid>(c => c.Report2ScheduleEmailID);
        public Guid Report2ScheduleEmailID
        {
            get { return GetProperty(Report2ScheduleEmailIDProperty); }
            set { SetProperty(Report2ScheduleEmailIDProperty, value); }
        }
        public static readonly PropertyInfo<Guid> ReportIDProperty = RegisterProperty<Guid>(nameof(ReportID));
        public Guid ReportID
        {
            get => GetProperty(ReportIDProperty);
            set => SetProperty(ReportIDProperty, value);
        }
        public static readonly PropertyInfo<string> DateRangeProperty = RegisterProperty<string>(nameof(DateRange));
        public string DateRange
        {
            get => GetProperty(DateRangeProperty);
            set => SetProperty(DateRangeProperty, value);
        }
        public static readonly PropertyInfo<DateTime> TimeProperty = RegisterProperty<DateTime>(nameof(Time));
        public DateTime Time
        {
            get => GetProperty(TimeProperty);
            set => SetProperty(TimeProperty, value);
        }
        public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
        public string Status
        {
            get { return GetProperty(StatusProperty); }
            set { SetProperty(StatusProperty, value); }
        }
        public static readonly PropertyInfo<string> FrequencyProperty = RegisterProperty<string>(nameof(Frequency));
        public string Frequency
        {
            get => GetProperty(FrequencyProperty);
            set => SetProperty(FrequencyProperty, value);
        }
        public static readonly PropertyInfo<Guid> AuditInfoGuidProperty = RegisterProperty<Guid>(c => c.AuditInfoGuid);
        public Guid AuditInfoGuid
        {
            get { return GetProperty(AuditInfoGuidProperty); }
            set { SetProperty(AuditInfoGuidProperty, value); }
        }
        public static readonly PropertyInfo<DateTime> LastUpdateUTCDTProperty = RegisterProperty<DateTime>(c => c.LastUpdateUTCDT);
        public DateTime LastUpdateUTCDT
        {
            get { return GetProperty(LastUpdateUTCDTProperty); }
            set { SetProperty(LastUpdateUTCDTProperty, value); }
        }
        //internal void UpdateObjectIDs(Guid _ItemCampaignDtlID)
        //{
        //    this.ItemCampaignDtlID = _ItemCampaignDtlID;
        //}
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
            //TODO: Define CanGetObject permission in Report2ScheduleEmail
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Report2ScheduleEmail
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Report2ScheduleEmail
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Report2ScheduleEmail
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<Report2ScheduleEmail> NewReport2ScheduleEmailAsync()
        {
            try
            {
                if (!CanAddObject())
                    throw new System.Security.SecurityException("User not authorized to add a Report2ScheduleEmail");
                return await DataPortal.CreateAsync<Report2ScheduleEmail>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async System.Threading.Tasks.Task<Report2ScheduleEmail> GetReport2ScheduleEmailAsync(Guid ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Report2ScheduleEmail");
            return await DataPortal.FetchAsync<Report2ScheduleEmail>(new Criteria(ID));
        }

        public static async void DeleteReport2ScheduleEmailAsync(Guid ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Report2ScheduleEmail");
            await DataPortal.DeleteAsync<Report2ScheduleEmail>(new Criteria(ID));
        }
#if !SILVERLIGHT && !NETFX_CORE
        public static Report2ScheduleEmail NewReport2ScheduleEmail()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Report2ScheduleEmail");
            return DataPortal.Create<Report2ScheduleEmail>();
        }
        public static Report2ScheduleEmail GetReport2ScheduleEmail(Guid ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Report2ScheduleEmail");
            return DataPortal.Fetch<Report2ScheduleEmail>(new Criteria(ID));
        }
        public static void DeleteReport2ScheduleEmail(Guid ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Report2ScheduleEmail");
            DataPortal.Delete<Report2ScheduleEmail>(new Criteria(ID));
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
            public Criteria(Guid ID)
            {
                this.ID = ID;
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
            Report2ScheduleEmailID = Guid.NewGuid();
            AuditInfoGuid = Guid.NewGuid();
            LastUpdateUTCDT = DateTime.UtcNow;
            Status = "ACTIVE";
            Report2ScheduleEmailJsonBO = Report2ScheduleEmailJsonBO.NewReport2ScheduleEmailJSON();
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
                    var data = mgr.DataContext.Report2ScheduleEmail_GetByID(criteria.ID).FirstOrDefault();
                    if (data != null)
                    {
                        Report2ScheduleEmailID = data.Report2ScheduleEmailID;
                        ReportID = data.ReportID;
                        DateRange = data.DateRange;
                        Time = data.Time ?? DateTime.MinValue;
                        Frequency = data.Frequency;
                        ReportID = data.ReportID;
                        Status = data.Status;
                        if (data.LastUpdateUTCDT != null)
                            LastUpdateUTCDT = (DateTime)data.LastUpdateUTCDT;
                        if (!string.IsNullOrEmpty(data.Report2ScheduleEmailJSON))
                        {
                            CDMDTO cDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.Report2ScheduleEmailJSON);
                            if (cDMDTO.ClassName.Equals("Report2ScheduleEmailJson"))
                                Report2ScheduleEmailJsonBO = DataPortal.FetchChild<Report2ScheduleEmailJsonBO>(data.Report2ScheduleEmailJSON);
                        }
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
                    string Report2ScheduleEmailJsonBOStr = null;
                    if (Report2ScheduleEmailJsonBO != null)
                    {
                        Report2ScheduleEmailJsonBOStr = OdataCDMJson<Report2ScheduleEmailJsonDTO>.GetJsonString(Report2ScheduleEmailJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.Report2ScheduleEmail_Add(Report2ScheduleEmailID, ReportID, DateRange, Time, Frequency, Report2ScheduleEmailJsonBOStr, Status,AuditInfoGuid ,LastUpdateUTCDT);
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
            //if (Report2ScheduleEmailID == "NEW")
            //{
            //  Report2ScheduleEmailID = CDMEntityKeys.Report2ScheduleEmailIDNextId();
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
                    string Report2ScheduleEmailJsonBOStr = null;
                    if (Report2ScheduleEmailJsonBO != null)
                    {
                        Report2ScheduleEmailJsonBOStr = OdataCDMJson<Report2ScheduleEmailJsonDTO>.GetJsonString(Report2ScheduleEmailJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.Report2ScheduleEmail_Upd(Report2ScheduleEmailID, ReportID, DateRange, Time, Frequency, Report2ScheduleEmailJsonBOStr, Status, AuditInfoGuid, LastUpdateUTCDT);
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
                mgr.DataContext.Report2ScheduleEmail_Void(criteria.ID);
            }//using
        }
        #endregion //Data Access - Delete

#endif
        #endregion //Data Access
    }

    #region Report2ScheduleEmailJsonDTOJSON

    #region Report2ScheduleEmailJsonDTO

    public class Report2ScheduleEmailJsonDTO
    {
        public string LocationID { get; set; }
        public ObservableCollection<string> Emails { get; set; }

        public string ClassName { get; set; }
        public Report2ScheduleEmailJsonDTO()
        {
            ClassName = "Report2ScheduleEmailJson";
        }
    }
    #endregion

    [Serializable()]
    public class Report2ScheduleEmailJsonBO : BusinessBase<Report2ScheduleEmailJsonBO>
    {
        #region Constructor
        public Report2ScheduleEmailJsonBO()
        {
            MarkAsChild();
        }

        public Report2ScheduleEmailJsonDTO ConvertToDTO()
        {
            Report2ScheduleEmailJsonDTO b = new Report2ScheduleEmailJsonDTO();
            b.LocationID = LocationID;
            b.Emails = Emails;
            return b;
        }
        #endregion

        #region Business Properties

        public static readonly PropertyInfo<string> LocationIDProperty = RegisterProperty<string>(c => c.LocationID);
        public string LocationID
        {
            get { return GetProperty(LocationIDProperty); }
            set { SetProperty(LocationIDProperty, value); }
        }
        public static readonly PropertyInfo<Csla.Core.MobileObservableCollection<string>> EmailsProperty = RegisterProperty<Csla.Core.MobileObservableCollection<string>>(c => c.Emails);
        public Csla.Core.MobileObservableCollection<string> Emails
        {
            get { return GetProperty(EmailsProperty); }
            set { SetProperty(EmailsProperty, value); }
        }
        public static readonly PropertyInfo<string> ReportNameProperty = RegisterProperty<string>(nameof(ReportName));
        public string ReportName
        {
          get => GetProperty(ReportNameProperty);
          set => SetProperty(ReportNameProperty, value);
        }

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

        public static Report2ScheduleEmailJsonBO NewReport2ScheduleEmailJSON()
        {
            return DataPortal.CreateChild<Report2ScheduleEmailJsonBO>();
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
                Report2ScheduleEmailJsonDTO Report2ScheduleEmailJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Report2ScheduleEmailJsonDTO>(BlogJsondtojson);
                if (Report2ScheduleEmailJson != null)
                    Child_Fetch(Report2ScheduleEmailJson);
            }
        }
        private void Child_Fetch(Report2ScheduleEmailJsonDTO data)
        {
            LocationID = data.LocationID;
            Emails = new Csla.Core.MobileObservableCollection<string>();
            foreach (var item in data.Emails)
            {
                Emails.Add(item);
            }

            MarkOld();
        }

        #region Data Access - Insert

        private void Child_Insert(Report2ScheduleEmail parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        private void Child_Update(Report2ScheduleEmail parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        private void Child_DeleteSelf(Report2ScheduleEmail parent)
        {
            MarkNew();
        }
        #endregion //Data Access - Delete
#endif
    }
    #endregion

}