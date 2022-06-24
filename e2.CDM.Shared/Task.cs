using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;
using System.Collections.ObjectModel;

namespace e2.CDM.Lib
{

    public static class TaskTypes
    {
        public static string WorkOrder = "WORKORDER";
        public static string Quotation = "QUOTATION";
        public static string Planning = "PLANNING";
        public static string FollowUp = "FOLLOWUP";
        public static string VendorBilling = "VENDORBILLING";
        public static string CustomerBilling = "CUSTOMERBILLING";

        public static ObservableCollection<string> GetTaskTypes()
        {
            var lst = new ObservableCollection<string>() { WorkOrder, Quotation, Planning, FollowUp, VendorBilling, CustomerBilling };
            return lst;
        }
    }

  [Serializable()]
    public class Task  : Csla.BusinessBase<Task>
    {

        #region Constuctor
        public Task()
        { }
        #endregion

        #region Business Properties and Methods

        public static readonly PropertyInfo<string> TaskIDProperty = RegisterProperty<string>(c => c.TaskID);
        public string TaskID
        {
            get { return GetProperty(TaskIDProperty); }
            set { SetProperty(TaskIDProperty, value); }
        }
        public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
        public string Status
        {
            get { return GetProperty(StatusProperty); }
            set { SetProperty(StatusProperty, value); }
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
        public static readonly PropertyInfo<TaskJsonBO> TaskJsonBOProperty = RegisterProperty<TaskJsonBO>(c => c.TaskJsonBO);
        public TaskJsonBO TaskJsonBO
        {
            get { return GetProperty(TaskJsonBOProperty); }
            set { SetProperty(TaskJsonBOProperty, value); }
        }
      
        protected override object GetIdValue()
        {
            return TaskID;
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
            //TODO: Define CanGetObject permission in Task
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Task
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Task
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Task
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<Task> NewTaskAsync()
        {
            try
            {
                if (!CanAddObject())
                    throw new System.Security.SecurityException("User not authorized to add a Task");
                return await DataPortal.CreateAsync<Task>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async System.Threading.Tasks.Task<Task> GetTaskAsync(string ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Task");
            return await DataPortal.FetchAsync<Task>(new Criteria(ID));
        }

        public static async void DeleteTaskAsync(string ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Task");
            await DataPortal.DeleteAsync<Task>(new Criteria(ID));
        }
#if !SILVERLIGHT && !NETFX_CORE
        public static Task NewTask()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Task");
            return DataPortal.Create<Task>();
        }
        public static Task GetTask(string ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Task");
            return DataPortal.Fetch<Task>(new Criteria(ID));
        }
        public static void DeleteTask(string ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Task");
            DataPortal.Delete<Task>(new Criteria(ID));
        }
#endif
#endregion //Factory Methods
      
        #region Criteria

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {

            public static readonly PropertyInfo<string> IDProperty = RegisterProperty<string>(c => c.ID);
            public string ID
            {
                get { return ReadProperty(IDProperty); }
                set { LoadProperty(IDProperty, value); }
            }
            public Criteria()
            { }
            public Criteria(string ID)
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
            TaskID = "NEW";
            AuditInfoGuid = Guid.NewGuid();
            LastUpdateUTCDT = DateTime.UtcNow;
            Status = "ACTIVE";
         
            TaskJsonBO = TaskJsonBO.NewTaskJSON();
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
                    var data = mgr.DataContext.Task_GetByID(criteria.ID).FirstOrDefault();
                    if (data != null)
                    {
                        TaskID = data.TaskID;
                        Status = data.Status;
                        AuditInfoGuid = data.AuditInfoGuid;
                        if (!string.IsNullOrEmpty(data.TaskJSON))
                        {
                            CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.TaskJSON);
                            if (CDMdto.ClassName.Equals("TaskJson"))
                                TaskJsonBO = DataPortal.FetchChild<TaskJsonBO>(data.TaskJSON);
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
                    string TaskJsonBOStr = null;
                    if (TaskJsonBO != null)
                    {
                        TaskJsonBOStr = OdataCDMJson<TaskJsonDTO>.GetJsonString(TaskJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.Task_Add(TaskID, TaskJsonBOStr, Status, AuditInfoGuid, DateTime.Now);
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
            if (TaskID == "NEW")
            {
                TaskID = CDMEntityKeys.TaskIDNextId();
            }

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
                    string TaskJsonBOStr = null;
                    if (TaskJsonBO != null)
                    {
                        TaskJsonBOStr = OdataCDMJson<TaskJsonDTO>.GetJsonString(TaskJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.Task_Upd(TaskID, TaskJsonBOStr, Status, AuditInfoGuid, DateTime.UtcNow);
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
                    mgr.DataContext.Task_Void(criteria.ID);
            }//using
        }
        #endregion //Data Access - Delete

#endif
        #endregion //Data Access
    }

    #region TaskJsonDTOJSON

    #region TaskJsonDTO

    public class TaskJsonDTO
    {
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public string TaskType { get; set; }

        public string ClassName { get; set; }
        public TaskJsonDTO()
        {
            ClassName = "TaskJson";
        }
    }
    #endregion

    [Serializable()]
    public class TaskJsonBO : BusinessBase<TaskJsonBO>
    {
        #region Constructor
        public TaskJsonBO()
        {
            MarkAsChild();
        }

        public TaskJsonDTO ConvertToDTO()
        {
            TaskJsonDTO b = new TaskJsonDTO();
            b.TaskName = this.TaskName;
            b.TaskDesc = this.TaskDesc;       
            b.TaskType = this.TaskType;       
            return b;
        }
        #endregion

        #region Business Properties

        public static readonly PropertyInfo<string> TaskTypeProperty = RegisterProperty<string>(nameof(TaskType));
        public string TaskType
        {
            get => GetProperty(TaskTypeProperty);
            set => SetProperty(TaskTypeProperty, value);
        }
        public static readonly PropertyInfo<string> TaskDescProperty = RegisterProperty<string>(c => c.TaskDesc);
        public string TaskDesc
        {
            get { return GetProperty(TaskDescProperty); }
            set { SetProperty(TaskDescProperty, value); }
        }
    public static readonly PropertyInfo<string> TaskNameProperty = RegisterProperty<string>(c => c.TaskName);
    public string TaskName
    {
      get { return GetProperty(TaskNameProperty); }
      set { SetProperty(TaskNameProperty, value); }
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

        public static TaskJsonBO NewTaskJSON()
        {
            return DataPortal.CreateChild<TaskJsonBO>();
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
                TaskJsonDTO TaskJson = Newtonsoft.Json.JsonConvert.DeserializeObject<TaskJsonDTO>(BlogJsondtojson);
                if (TaskJson != null)
                    Child_Fetch(TaskJson);
            }
        }
        private void Child_Fetch(TaskJsonDTO data)
        {
           
            TaskDesc = data.TaskDesc;
            TaskName = data.TaskName;
            TaskType = data.TaskType;
            MarkOld();
        }

        #region Data Access - Insert

        private void Child_Insert(Task parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        private void Child_Update(Task parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        private void Child_DeleteSelf(Task parent)
        {
            MarkNew();
        }
        #endregion //Data Access - Delete
#endif
    }
    #endregion

}