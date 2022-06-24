using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public class Activities2Task : Csla.BusinessBase<Activities2Task>
    {
        #region Constuctor
        public Activities2Task()
        {
            BusinessRules.CheckRules();
            MarkAsChild();
        }
        #endregion

        #region Business Properties and Methods
        public static readonly PropertyInfo<Activities2TasklJsonBO> Activities2TasklJsonBOProperty = RegisterProperty<Activities2TasklJsonBO>(c => c.Activities2TasklJsonBO);
        public Activities2TasklJsonBO Activities2TasklJsonBO
        {
            get { return GetProperty(Activities2TasklJsonBOProperty); }
            set { SetProperty(Activities2TasklJsonBOProperty, value); }
        }
        public static readonly PropertyInfo<Guid> Activities2TaskIDProperty = RegisterProperty<Guid>(c => c.Activities2TaskID);
        public Guid Activities2TaskID
        {
            get { return GetProperty(Activities2TaskIDProperty); }
            set { SetProperty(Activities2TaskIDProperty, value); }
        }
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


        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation RulesD:\OdataWorkSpace\e2V55Projects\e2V55Libs\e2.CDM.Shared\Activities2Task - Copy.cs

        #region Authorization Rules
        protected void AddAuthorizationRules()
        {

        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static async System.Threading.Tasks.Task<Activities2Task> NewItemActivities2TaskAsync()
        {
            try
            {
                return await DataPortal.CreateAsync<Activities2Task>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static Activities2Task NewItemActivities2Task()
        {
            return DataPortal.CreateChild<Activities2Task>();
        }

        #endregion //Factory Methods

        #region  Child_Create
        protected override void DataPortal_Create()
        {
            Activities2TaskID = Guid.NewGuid();
            Status = "ACTIVE";
            LastUpdateUTCDT = DateTime.UtcNow;
            Activities2TasklJsonBO = Activities2TasklJsonBO.NewActivities2TasklJsonBO();
            base.DataPortal_Create();
        }
        protected override void Child_Create()
        {
            Activities2TaskID = Guid.NewGuid();
            Status = "ACTIVE";
            LastUpdateUTCDT = DateTime.UtcNow;
            Activities2TasklJsonBO = Activities2TasklJsonBO.NewActivities2TasklJsonBO();
            base.Child_Create();
        }

        #endregion

        #region Data Access
#if !NETFX_CORE

        #region Data Access - Fetch
        private void Child_Fetch(e2.CDM.DAL.Lib.Activities2Tasks_GetByIDResult data)
        {
            Activities2TaskID = data.Activities2TasksID;        
            TaskID = data.TasksID;
            Status = data.Status;
           if(data.LastUpdateUTCDT!=null)
            LastUpdateUTCDT =(DateTime) data.LastUpdateUTCDT;
            if (!string.IsNullOrEmpty(data.Activities2TasksJSON))
            {
                CDMDTO cDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.Activities2TasksJSON);
                if (cDMDTO.ClassName.Equals("Activities2TaskJson"))
                    Activities2TasklJsonBO = DataPortal.FetchChild<Activities2TasklJsonBO>(data.Activities2TasksJSON);
            }
            MarkOld();
            BusinessRules.CheckRules();
        }
        private void Child_Fetch(e2.CDM.DAL.Lib.Activities2Tasks_GetByActivitiesIDResult data)
        {
            Activities2TaskID = data.Activities2TasksID;
            TaskID = data.TasksID;
            Status = data.Status;
           if(data.LastUpdateUTCDT!=null)
            LastUpdateUTCDT =(DateTime) data.LastUpdateUTCDT;
            if (!string.IsNullOrEmpty(data.Activities2TasksJSON))
            {
                CDMDTO cDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.Activities2TasksJSON);
                if (cDMDTO.ClassName.Equals("Activities2TaskJson"))
                    Activities2TasklJsonBO = DataPortal.FetchChild<Activities2TasklJsonBO>(data.Activities2TasksJSON);
            }
            MarkOld();
            BusinessRules.CheckRules();
        }


        #endregion //Data Access - Fetch

        #region Data Access - Insert

        private void Child_Insert(Activity parent)
        {
            if (!this.IsDirty) return;

            using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                             .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {
                try
                {
                    string Activities2TasklJsonStr = null;
                    if (Activities2TasklJsonBO != null)
                    {
                        Activities2TasklJsonStr = OdataCDMJson<Activities2TasklJsonDTO>.GetJsonString(Activities2TasklJsonBO.ConvertToDTO());
                    }
                    ctx.DataContext.Activities2Tasks_Add(Activities2TaskID, parent.ActivityID.ToString(),TaskID, Activities2TasklJsonStr, Status, AuditInfoGuid, DateTime.UtcNow);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            MarkOld();
        }


        #endregion //Data Access - Insert

        #region Data Access - Update
        private void Child_Update(Activity parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                            .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
                {
                    try
                    {
            string Activities2TasklJsonStr = null;
            if (Activities2TasklJsonBO != null)
            {
              Activities2TasklJsonStr = OdataCDMJson<Activities2TasklJsonDTO>.GetJsonString(Activities2TasklJsonBO.ConvertToDTO());
            }
            ctx.DataContext.Activities2Tasks_Upd(Activities2TaskID, parent.ActivityID.ToString(), TaskID, Activities2TasklJsonStr, Status, AuditInfoGuid, DateTime.UtcNow);
          }
          catch (Exception e)
                    {
                        throw e;
                    }
                }
                MarkOld();
            }
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        private void Child_DeleteSelf(Activity parent)
        {
            if (!this.IsDirty) return;

            using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                             .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {
                try
                {
                    ctx.DataContext.Activities2Tasks_Void(Activities2TaskID);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            MarkNew();
        }
        #endregion //Data Access - Delete
#endif
        #endregion //Data Access
    }

    #region Activities2TaskJsonBO

    #region ItemsActivities2TasklJsonDTO

    public class Activities2TasklJsonDTO
    {
        public int SrNo { get; set; }
        public string EntityId { get; set; }
        public bool IsActivity { get; set; }
        public bool IsItemRequired { get; set; }
        public bool IsServiceRequired { get; set; }
        public string TaskType { get; set; }
        public string ClassName { get; set; }
        public Activities2TasklJsonDTO()
        {
            ClassName = "Activities2TaskJson";
        }
    }
    #endregion

    [Serializable()]
    public class Activities2TasklJsonBO : BusinessBase<Activities2TasklJsonBO>
    {
        #region Constructor
        public Activities2TasklJsonBO()
        {
            MarkAsChild();
        }

        public Activities2TasklJsonDTO ConvertToDTO()
        {
            Activities2TasklJsonDTO b = new Activities2TasklJsonDTO();
            b.SrNo = SrNo;
            b.EntityId = EntityId;
            b.IsActivity = IsActivity;
            b.IsItemRequired = IsItemRequired;
            b.IsServiceRequired = IsServiceRequired;
            b.TaskType = TaskType;
            return b;
        }
        #endregion

        #region Business Properties
        public static readonly PropertyInfo<int> SrNoProperty = RegisterProperty<int>(c => c.SrNo);
        public int SrNo
        {
            get { return GetProperty(SrNoProperty); }
            set { SetProperty(SrNoProperty, value); }
        }
        public static readonly PropertyInfo<string> EntityIdProperty = RegisterProperty<string>(c => c.EntityId);
        public string EntityId
        {
            get { return GetProperty(EntityIdProperty); }
            set { SetProperty(EntityIdProperty, value); }
        }
        public static readonly PropertyInfo<string> TaskNameProperty = RegisterProperty<string>(c => c.TaskName);
        public string TaskName
        {
          get { return GetProperty(TaskNameProperty); }
          set { SetProperty(TaskNameProperty, value); }
        }
        public static readonly PropertyInfo<bool> IsActivityProperty = RegisterProperty<bool>(c => c.IsActivity);
        public bool IsActivity
        {
            get { return GetProperty(IsActivityProperty); }
            set { SetProperty(IsActivityProperty, value); }
        }
        public static readonly PropertyInfo<bool> IsItemRequiredProperty = RegisterProperty<bool>(c => c.IsItemRequired);
        public bool IsItemRequired
        {
          get { return GetProperty(IsItemRequiredProperty); }
          set { SetProperty(IsItemRequiredProperty, value); }
        }
        public static readonly PropertyInfo<bool> IsServiceRequiredProperty = RegisterProperty<bool>(c => c.IsServiceRequired);
        public bool IsServiceRequired
        {
          get { return GetProperty(IsServiceRequiredProperty); }
          set { SetProperty(IsServiceRequiredProperty, value); }
        }
        public static readonly PropertyInfo<string> TaskTypeProperty = RegisterProperty<string>(c => c.TaskType);
        public string TaskType
        {
          get { return GetProperty(TaskTypeProperty); }
          set { SetProperty(TaskTypeProperty, value); }
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

        public static Activities2TasklJsonBO NewActivities2TasklJsonBO()
        {
            return DataPortal.CreateChild<Activities2TasklJsonBO>();
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
                Activities2TasklJsonDTO ItemsWorkHoursJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<Activities2TasklJsonDTO>(BlogJsondtojson);
                if (ItemsWorkHoursJSON != null)
                    Child_Fetch(ItemsWorkHoursJSON);
            }

        }
        private void Child_Fetch(Activities2TasklJsonDTO data)
        {                    
            SrNo = data.SrNo;
            EntityId = data.EntityId;
            IsActivity = data.IsActivity;
            IsItemRequired = data.IsItemRequired;
            IsServiceRequired = data.IsServiceRequired;
            TaskType = data.TaskType;
            MarkOld();
        }

        #region Data Access - Insert

        private void Child_Insert(Activity parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        private void Child_Update(Activity parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        private void Child_DeleteSelf(Activity parent)
        {
            MarkNew();
        }
        #endregion //Data Access - Delete
#endif
    }
    #endregion

}
