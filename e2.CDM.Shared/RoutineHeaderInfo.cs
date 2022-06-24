
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
  [Serializable()]
  public partial class RoutineHeaderInfo : Csla.ReadOnlyBase<RoutineHeaderInfo>
  {
    #region Constuctor
    public RoutineHeaderInfo()
    { }
    #endregion
    #region Business Properties and Methods

    

        public static readonly PropertyInfo<RoutineDetails> RoutineDetailsProperty = RegisterProperty<RoutineDetails>(c => c.RoutineDetails);
        public RoutineDetails RoutineDetails
        {
            get { return GetProperty(RoutineDetailsProperty); }
            set { LoadProperty(RoutineDetailsProperty, value); }
        }



        public static readonly PropertyInfo<Guid> RoutineHeaderIDProperty = RegisterProperty<Guid>(c => c.RoutineHeaderID);
        public Guid RoutineHeaderID
        {
            get { return GetProperty(RoutineHeaderIDProperty); }
            set { LoadProperty(RoutineHeaderIDProperty, value); }
        }

        public static readonly PropertyInfo<DateTime> RoutineDateProperty = RegisterProperty<DateTime>(c => c.RoutineDate);
        public DateTime RoutineDate
        {
            get { return GetProperty(RoutineDateProperty); }
            set { LoadProperty(RoutineDateProperty, value); }
        }
        //public static readonly PropertyInfo<ActionDateRange> TaskActionDateRangeRangeProperty = RegisterProperty<ActionDateRange>(nameof(TaskActionDateRange));
        //public ActionDateRange TaskActionDateRange
        //{
        //    get => GetProperty(TaskActionDateRangeRangeProperty);
        //    set => LoadProperty(TaskActionDateRangeRangeProperty, value);
        //}
        public static readonly PropertyInfo<string> RefIDProperty = RegisterProperty<string>(nameof(RefID));
        public string RefID
        {
            get => GetProperty(RefIDProperty);
            set => LoadProperty(RefIDProperty, value);
        }
        public static readonly PropertyInfo<string> RefTypeProperty = RegisterProperty<string>(nameof(RefType));
        public string RefType
        {
            get => GetProperty(RefTypeProperty);
            set => LoadProperty(RefTypeProperty, value);
        }
        public static readonly PropertyInfo<string> RemarkProperty = RegisterProperty<string>(nameof(Remark));
        public string Remark
        {
            get => GetProperty(RemarkProperty);
            set => LoadProperty(RemarkProperty, value);
        }

        public static readonly PropertyInfo<RoutineHeaderJsonBO> RoutineHeaderJsonBOProperty = RegisterProperty<RoutineHeaderJsonBO>(c => c.RoutineHeaderJsonBO);
        public RoutineHeaderJsonBO RoutineHeaderJsonBO
        {
            get { return GetProperty(RoutineHeaderJsonBOProperty); }
            set { LoadProperty(RoutineHeaderJsonBOProperty, value); }
        }

        public static readonly PropertyInfo<string> AvailStatusIDProperty = RegisterProperty<string>(c => c.AvailStatusID);
        public string AvailStatusID
        {
            get { return GetProperty(AvailStatusIDProperty); }
            set { LoadProperty(AvailStatusIDProperty, value); }
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
    internal static RoutineHeaderInfo GetRoutineHeaderInfo(e2.CDM.DAL.Lib.RoutineHeader_GetResult data)
    {
      RoutineHeaderInfo item = new RoutineHeaderInfo();
      item.Fetch(data);
      return item;
    }


    private void Fetch(e2.CDM.DAL.Lib.RoutineHeader_GetResult data)
    {
      bool cancel = false;
      OnFetching(ref cancel);
      if (cancel) return;
      if (data != null)
      {
        RoutineHeaderID = data.RoutineHeaderID;
                        RoutineDate = data.RoutineDate;
                        RefID = data.RefID;
                        RefType = data.RefType;
                        Remark = data.Remark;
                        AvailStatusID = data.AvailStatusID;
                        AuditInfoGuid = data.AuditInfoGuid;
                        if (!string.IsNullOrEmpty(data.RoutineHeaderJSON))
                        {
                            CDMDTO CDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.RoutineHeaderJSON);
                            if (CDMDTO.ClassName.Equals("RoutineHeaderJson"))
                                RoutineHeaderJsonBO = DataPortal.FetchChild<RoutineHeaderJsonBO>(data.RoutineHeaderJSON);
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
