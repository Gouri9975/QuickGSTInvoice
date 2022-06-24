
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
  [Serializable()]
  public partial class Report2ScheduleEmailInfo : Csla.ReadOnlyBase<Report2ScheduleEmailInfo>
  {
    #region Constuctor
    public Report2ScheduleEmailInfo()
    { }
        #endregion


        #region Business Properties and Methods

        public static readonly PropertyInfo<Report2ScheduleEmailJsonBO> Report2ScheduleEmailJsonBOProperty = RegisterProperty<Report2ScheduleEmailJsonBO>(c => c.Report2ScheduleEmailJsonBO);
        public Report2ScheduleEmailJsonBO Report2ScheduleEmailJsonBO
        {
            get { return GetProperty(Report2ScheduleEmailJsonBOProperty); }
            set { LoadProperty(Report2ScheduleEmailJsonBOProperty, value); }
        }
        public static readonly PropertyInfo<Guid> Report2ScheduleEmailIDProperty = RegisterProperty<Guid>(c => c.Report2ScheduleEmailID);
        public Guid Report2ScheduleEmailID
        {
            get { return GetProperty(Report2ScheduleEmailIDProperty); }
            set { LoadProperty(Report2ScheduleEmailIDProperty, value); }
        }
        public static readonly PropertyInfo<Guid> ReportIDProperty = RegisterProperty<Guid>(nameof(ReportID));
        public Guid ReportID
        {
            get => GetProperty(ReportIDProperty);
            set => LoadProperty(ReportIDProperty, value);
        }
    public static readonly PropertyInfo<string> ReportNameProperty = RegisterProperty<string>(nameof(ReportName));
    public string ReportName
    {
      get => GetProperty(ReportNameProperty);
      set => LoadProperty(ReportNameProperty, value);
    }
    public static readonly PropertyInfo<string> DateRangeProperty = RegisterProperty<string>(nameof(DateRange));
        public string DateRange
        {
            get => GetProperty(DateRangeProperty);
            set => LoadProperty(DateRangeProperty, value);
        }
        public static readonly PropertyInfo<DateTime> TimeProperty = RegisterProperty<DateTime>(nameof(Time));
        public DateTime Time
        {
            get => GetProperty(TimeProperty);
            set => LoadProperty(TimeProperty, value);
        }
        public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
        public string Status
        {
            get { return GetProperty(StatusProperty); }
            set { LoadProperty(StatusProperty, value); }
        }
        public static readonly PropertyInfo<string> FrequencyProperty = RegisterProperty<string>(nameof(Frequency));
        public string Frequency
        {
            get => GetProperty(FrequencyProperty);
            set => LoadProperty(FrequencyProperty, value);
        }
        public static readonly PropertyInfo<Guid> AuditInfoGuidProperty = RegisterProperty<Guid>(c => c.AuditInfoGuid);
        public Guid AuditInfoGuid
        {
            get { return GetProperty(AuditInfoGuidProperty); }
            set { LoadProperty(AuditInfoGuidProperty, value); }
        }
        public static readonly PropertyInfo<DateTime> LastUpdateUTCDTProperty = RegisterProperty<DateTime>(c => c.LastUpdateUTCDT);
        public DateTime LastUpdateUTCDT
        {
            get { return GetProperty(LastUpdateUTCDTProperty); }
            set { LoadProperty(LastUpdateUTCDTProperty, value); }
        }
        //internal void UpdateObjectIDs(Guid _ItemCampaignDtlID)
        //{
        //    this.ItemCampaignDtlID = _ItemCampaignDtlID;
        //}
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
       

        internal static Report2ScheduleEmailInfo GetReport2ScheduleEmailInfo(e2.CDM.DAL.Lib.Report2ScheduleEmail_GetAllResult data)
        {
            Report2ScheduleEmailInfo item = new Report2ScheduleEmailInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Report2ScheduleEmail_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
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
