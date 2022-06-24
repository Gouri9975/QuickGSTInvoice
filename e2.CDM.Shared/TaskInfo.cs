
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public partial class TaskInfo : Csla.ReadOnlyBase<TaskInfo>
    {
        #region Constuctor
        public TaskInfo()
        { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<string> TaskIDProperty = RegisterProperty<string>(c => c.TaskID);
    public string TaskID
    {
      get { return GetProperty(TaskIDProperty); }
      set { LoadProperty(TaskIDProperty, value); }
    }
    public static readonly PropertyInfo<string> TaskNameProperty = RegisterProperty<string>(nameof(TaskName));
    public string TaskName
    {
        get => GetProperty(TaskNameProperty);
        set => LoadProperty(TaskNameProperty, value);
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
    public static readonly PropertyInfo<TaskJsonBO> TaskJsonBOProperty = RegisterProperty<TaskJsonBO>(c => c.TaskJsonBO);
    public TaskJsonBO TaskJsonBO
    {
      get { return GetProperty(TaskJsonBOProperty); }
      set { LoadProperty(TaskJsonBOProperty, value); }
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
        internal static TaskInfo GetTaskInfo(e2.CDM.DAL.Lib.Task_GetAllResult data)
        {
            TaskInfo item = new TaskInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Task_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                TaskID = data.TaskID;
                Status = data.Status;
                if (!string.IsNullOrEmpty(data.TaskJSON))
                {
                    CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.TaskJSON);
                    if (CDMdto.ClassName.Equals("TaskJson"))
                        TaskJsonBO = DataPortal.FetchChild<TaskJsonBO>(data.TaskJSON);
                }
                if (TaskJsonBO != null)
                {
                    TaskName = TaskJsonBO.TaskName;
                }
            }
            OnFetched();
        }

        internal static TaskInfo GetTaskInfo(e2.CDM.DAL.Lib.Tasks_AllResult data)
        {
            TaskInfo item = new TaskInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Tasks_AllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                TaskID = data.TasksID;
                Status = data.Status;
                if (!string.IsNullOrEmpty(data.TasksJSON))
                {
                  CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.TasksJSON);
                  if (CDMdto.ClassName.Equals("TaskJson"))
                    TaskJsonBO = DataPortal.FetchChild<TaskJsonBO>(data.TasksJSON);
                }
                if(TaskJsonBO != null)
                {
                    TaskName = TaskJsonBO.TaskName;
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
