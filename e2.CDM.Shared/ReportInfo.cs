
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
  [Serializable()]
  public partial class ReportInfo : Csla.ReadOnlyBase<ReportInfo>
  {
    #region Constuctor
    public ReportInfo()
    { }
    #endregion


    #region Business Properties and Methods

    public static readonly PropertyInfo<Guid> ReportIDProperty = RegisterProperty<Guid>(c => c.ReportID);
    public Guid ReportID
    {
      get { return GetProperty(ReportIDProperty); }
      set { LoadProperty(ReportIDProperty, value); }
    }
    public static readonly PropertyInfo<string> ReportNameProperty = RegisterProperty<string>(nameof(ReportName));
    public string ReportName
    {
      get => GetProperty(ReportNameProperty);
      set => LoadProperty(ReportNameProperty, value);
    }
    public static readonly PropertyInfo<string> DisplayNameProperty = RegisterProperty<string>(nameof(DisplayName));
    public string DisplayName
    {
      get => GetProperty(DisplayNameProperty);
      set => LoadProperty(DisplayNameProperty, value);
    }
    public static readonly PropertyInfo<string> ReportMRTstrProperty = RegisterProperty<string>(nameof(ReportMRTstr));
    public string ReportMRTstr
    {
      get => GetProperty(ReportMRTstrProperty);
      set => LoadProperty(ReportMRTstrProperty, value);
    }
    public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
    public string Status
    {
      get { return GetProperty(StatusProperty); }
      set { LoadProperty(StatusProperty, value); }
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
    public static readonly PropertyInfo<ReportJsonBO> ReportJsonBOProperty = RegisterProperty<ReportJsonBO>(c => c.ReportJsonBO);
    public ReportJsonBO ReportJsonBO
    {
      get { return GetProperty(ReportJsonBOProperty); }
      set { LoadProperty(ReportJsonBOProperty, value); }
    }
    public static readonly PropertyInfo<Report2ScheduleEmails> Report2ScheduleEmailsProperty = RegisterProperty<Report2ScheduleEmails>(nameof(Report2ScheduleEmails));
    public Report2ScheduleEmails Report2ScheduleEmails
    {
      get => GetProperty(Report2ScheduleEmailsProperty);
      set => LoadProperty(Report2ScheduleEmailsProperty, value);
    }
    protected override object GetIdValue()
    {
      return ReportID;
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
       

        internal static ReportInfo GetReportInfo(e2.CDM.DAL.Lib.Report_GetAllResult data)
        {
            ReportInfo item = new ReportInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Report_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
        ReportID = data.ReportID;
        ReportName = data.ReportName;
        ReportMRTstr = data.ReportMRTstr;
        DisplayName = data.DisplayName;
        Status = data.Status;
        AuditInfoGuid = data.AuditInfoGuid;
        if (!string.IsNullOrEmpty(data.ReportJSON))
        {
          CDMDTO cDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.ReportJSON);
          if (cDMDTO.ClassName.Equals("ReportJson"))
            ReportJsonBO = DataPortal.FetchChild<ReportJsonBO>(data.ReportJSON);
        }
        Report2ScheduleEmails = Report2ScheduleEmails.GetItemReport2ScheduleEmails(data.ReportID);

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
