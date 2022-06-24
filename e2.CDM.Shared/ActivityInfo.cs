
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public partial class ActivityInfo : Csla.ReadOnlyBase<ActivityInfo>
    {
        #region Constuctor
        public ActivityInfo()
        { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<string> ActivityIDProperty = RegisterProperty<string>(c => c.ActivityID);
    public string ActivityID
    {
      get { return GetProperty(ActivityIDProperty); }
      set { LoadProperty(ActivityIDProperty, value); }
    }
    public static readonly PropertyInfo<string> ActivityNameProperty = RegisterProperty<string>(nameof(ActivityName));
    public string ActivityName
    {
        get => GetProperty(ActivityNameProperty);
        set => LoadProperty(ActivityNameProperty, value);
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
    public static readonly PropertyInfo<ActivityJsonBO> ActivityJsonBOProperty = RegisterProperty<ActivityJsonBO>(c => c.ActivityJsonBO);
    public ActivityJsonBO ActivityJsonBO
    {
      get { return GetProperty(ActivityJsonBOProperty); }
      set { LoadProperty(ActivityJsonBOProperty, value); }
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
        internal static ActivityInfo GetActivityInfo(e2.CDM.DAL.Lib.Activity_GetAllResult data)
        {
            ActivityInfo item = new ActivityInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Activity_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                ActivityID = data.ActivityID;
                Status = data.Status;
                if (!string.IsNullOrEmpty(data.ActivityJSON))
                {
                  CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.ActivityJSON);
                  if (CDMdto.ClassName.Equals("ActivityJson"))
                    ActivityJsonBO = DataPortal.FetchChild<ActivityJsonBO>(data.ActivityJSON);
                }
                if(ActivityJsonBO != null)
                {
                    ActivityName = ActivityJsonBO.ActivityDesc;
                }

            }
            OnFetched();
        }

        internal static ActivityInfo GetActivityInfo(e2.CDM.DAL.Lib.Activities_AllResult data)
        {
            ActivityInfo item = new ActivityInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Activities_AllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                ActivityID = data.ActivitiesID;
                Status = data.Status;
                if (!string.IsNullOrEmpty(data.ActivitiesJSON))
                {
                  CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.ActivitiesJSON);
                  if (CDMdto.ClassName.Equals("ActivityJson"))
                    ActivityJsonBO = DataPortal.FetchChild<ActivityJsonBO>(data.ActivitiesJSON);
                }
                if(ActivityJsonBO != null)
                {
                    ActivityName = ActivityJsonBO.ActivityDesc;
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
