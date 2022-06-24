using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{

    [Serializable()]
    public class RoutineDetail : Csla.BusinessBase<RoutineDetail>
    {

        #region Constuctor
        public RoutineDetail()
        {
            MarkAsChild();
        }
        #endregion

        #region Business Properties and Methods

        public static readonly PropertyInfo<Guid> RoutineDetailIDProperty = RegisterProperty<Guid>(c => c.RoutineDetailID);
        public Guid RoutineDetailID
        {
            get { return GetProperty(RoutineDetailIDProperty); }
            set { SetProperty(RoutineDetailIDProperty, value); }
        }
        public static readonly PropertyInfo<Guid> RoutineHeaderIDProperty = RegisterProperty<Guid>(c => c.RoutineHeaderID);
        public Guid RoutineHeaderID
        {
            get { return GetProperty(RoutineHeaderIDProperty); }
            set { SetProperty(RoutineHeaderIDProperty, value); }
        }
        //public static readonly PropertyInfo<ActionDateRange> TaskActionDateRangeRangeProperty = RegisterProperty<ActionDateRange>(nameof(TaskActionDateRange));
        //public ActionDateRange TaskActionDateRange
        //{
        //    get => GetProperty(TaskActionDateRangeRangeProperty);
        //    set => SetProperty(TaskActionDateRangeRangeProperty, value);
        //}
        public static readonly PropertyInfo<string> ProjectHdrIDProperty = RegisterProperty<string>(nameof(ProjectHdrID));
        public string ProjectHdrID
        {
            get => GetProperty(ProjectHdrIDProperty);
            set => SetProperty(ProjectHdrIDProperty, value);
        }
        public static readonly PropertyInfo<string> ActivityIDProperty = RegisterProperty<string>(nameof(ActivityID));
        public string ActivityID
        {
            get => GetProperty(ActivityIDProperty);
            set => SetProperty(ActivityIDProperty, value);
        }
        public static readonly PropertyInfo<string> ActivityNameProperty = RegisterProperty<string>(nameof(ActivityName));
        public string ActivityName
        {
            get => GetProperty(ActivityNameProperty);
            set => SetProperty(ActivityNameProperty, value);
        }
        public static readonly PropertyInfo<string> TaskNameProperty = RegisterProperty<string>(nameof(TaskName));
        public string TaskName
        {
            get => GetProperty(TaskNameProperty);
            set => SetProperty(TaskNameProperty, value);
        }
        public static readonly PropertyInfo<string> TaskIDProperty = RegisterProperty<string>(nameof(TaskID));
        public string TaskID
        {
            get => GetProperty(TaskIDProperty);
            set => SetProperty(TaskIDProperty, value);
        }
       
         
        public static readonly PropertyInfo<string> ProjectAvailStatusIDListProperty = RegisterProperty<string>(nameof(Frequency));
        public string Frequency
        {
            get => GetProperty(ProjectAvailStatusIDListProperty);
            set => SetProperty(ProjectAvailStatusIDListProperty, value);
        }
        public static readonly PropertyInfo<RoutineDetailJsonBO> RoutineDetailJsonBOProperty = RegisterProperty<RoutineDetailJsonBO>(c => c.RoutineDetailJsonBO);
        public RoutineDetailJsonBO RoutineDetailJsonBO
        {
            get { return GetProperty(RoutineDetailJsonBOProperty); }
            set { SetProperty(RoutineDetailJsonBOProperty, value); }
        }
        public static readonly PropertyInfo<string> InterfaceNameProperty = RegisterProperty<string>(c => c.InterfaceName);
        public string InterfaceName
        {
            get { return GetProperty(InterfaceNameProperty); }
            set { SetProperty(InterfaceNameProperty, value); }
        }
        public static readonly PropertyInfo<string> ClassNameProperty = RegisterProperty<string>(c => c.ClassName);
        public string ClassName 
        {
            get { return GetProperty(ClassNameProperty); }
            set { SetProperty(ClassNameProperty, value); }
        }
        public static readonly PropertyInfo<string> AvailStatusIDProperty = RegisterProperty<string>(c => c.AvailStatusID);
        public string AvailStatusID
        {
            get { return GetProperty(AvailStatusIDProperty); }
            set { SetProperty(AvailStatusIDProperty, value); }
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
       
        protected override object GetIdValue()
        {
            return RoutineDetailID;
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
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(RoutineDetailIDProperty));
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(RoutineHeaderIDProperty));
            BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(AvailStatusIDProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptIDProperty, 20));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(InvReceiptNoProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptNoProperty, 20));

            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(InvReceiptTypeIDProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptTypeIDProperty, 200));

            //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(InvReceiptAvailStatusIDProperty));
            //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptAvailStatusIDProperty, 20));
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

        public static async System.Threading.Tasks.Task<RoutineDetail> NewRoutineDetailAsync()
        {
            try
            {
                if (!CanAddObject())
                    throw new System.Security.SecurityException("User not authorized to add a Task");
                return await DataPortal.CreateAsync<RoutineDetail>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static async System.Threading.Tasks.Task<RoutineDetail> GetRoutineDetailAsync(Guid ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Task");
            return await DataPortal.FetchAsync<RoutineDetail>(new Criteria(ID));
        }

        public static async void DeleteRoutineDetailAsync(Guid ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Task");
            await DataPortal.DeleteAsync<RoutineDetail>(new Criteria(ID));
        }
        

#if !SILVERLIGHT && !NETFX_CORE
        public static RoutineDetail NewRoutineDetail()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Task");
            return DataPortal.Create<RoutineDetail>();
        }

        public static RoutineDetail NewItemRoutineDetail()
        {
            return DataPortal.CreateChild<RoutineDetail>();
        }
        public static RoutineDetail GetRoutineDetail(Guid ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Task");
            return DataPortal.Fetch<RoutineDetail>(new Criteria(ID));
        }
        public static void DeleteRoutineDetail(Guid ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Task");
            DataPortal.Delete<RoutineDetail>(new Criteria(ID));
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
            RoutineDetailID = Guid.NewGuid();
            AuditInfoGuid = Guid.NewGuid();
            LastUpdateUTCDT = DateTime.UtcNow;            
            AvailStatusID = "ACTIVE";
            RoutineDetailJsonBO = RoutineDetailJsonBO.NewRoutineDetailJSON();
            base.DataPortal_Create();

            BusinessRules.CheckRules();
        }


        protected override void Child_Create()
        {
            RoutineDetailID = Guid.NewGuid();
            AuditInfoGuid = Guid.NewGuid();
            LastUpdateUTCDT = DateTime.UtcNow;            
            AvailStatusID = "ACTIVE";
            RoutineDetailJsonBO = RoutineDetailJsonBO.NewRoutineDetailJSON();
            base.Child_Create();
        }

        #endregion //Data Access - Create

        #region Data Access

#if !NETFX_CORE
        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
           // try
            {
                using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
                {
                    //set option to eager load child object(s)
                    var data = mgr.DataContext.RoutineDetail_Get(criteria.ID).FirstOrDefault();
                    if (data != null)
                    {
                        RoutineDetailID = data.RoutineDetailID;
                        RoutineHeaderID = data.RoutineHeaderID;
                        ActivityID = data.ActivityID;
                        TaskID = data.TaskID;
                        InterfaceName = data.InterfaceName;
                        ClassName = data.ClassName;
                        Frequency = data.Frequency;
                        AvailStatusID = data.AvailStatusID;
                        AuditInfoGuid = data.AuditInfoGuid;
                        if (!string.IsNullOrEmpty(data.RoutineDetailJSON))
                        {
                            CDMDTO CDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.RoutineDetailJSON);
                            if (CDMDTO.ClassName.Equals("RoutineDetailJson"))
                                RoutineDetailJsonBO = DataPortal.FetchChild<RoutineDetailJsonBO>(data.RoutineDetailJSON);
                        }
                        
                     

                    }
                    MarkOld();
                }

            }//using
            //catch (Exception e)
            //{
            //    throw;
            //}
        }


        private void Child_Fetch(e2.CDM.DAL.Lib.RoutineDetail_GetByRoutineHeaderIDResult data)
        {
            if (data != null)
            {
                RoutineDetailID = data.RoutineDetailID;
                RoutineHeaderID = data.RoutineHeaderID;
                ActivityID = data.ActivityID;
                TaskID = data.TaskID;
                InterfaceName = data.InterfaceName;
                ClassName = data.ClassName;
                Frequency = data.Frequency;
                AvailStatusID = data.AvailStatusID;
                AuditInfoGuid = data.AuditInfoGuid;
                if (!string.IsNullOrEmpty(data.RoutineDetailJSON))
                {
                    CDMDTO CDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.RoutineDetailJSON);
                    if (CDMDTO.ClassName.Equals("RoutineDetailJson"))
                        RoutineDetailJsonBO = DataPortal.FetchChild<RoutineDetailJsonBO>(data.RoutineDetailJSON);
                }
            }
            MarkOld();
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
                    string RoutineDetailJsonBOStr = null;
                    if (RoutineDetailJsonBO != null)
                    {
                        RoutineDetailJsonBOStr = OdataCDMJson<RoutineDetailJsonDTO>.GetJsonString(RoutineDetailJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.RoutineDetail_Add(RoutineDetailID, RoutineHeaderID, ActivityID, TaskID, Frequency, ClassName, InterfaceName,
                        AuditInfoGuid, AvailStatusID, RoutineDetailJsonBOStr, DateTime.UtcNow);

                    FieldManager.UpdateChildren(this);
 
                }//using
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void Child_Insert(RoutineHeader parent)
        {
            if (!this.IsDirty) return;

            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                     .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {
                try
                {
                    UpdateObjectIDs();
                    string RoutineDetailJsonBOStr = null;
                    if (RoutineDetailJsonBO != null)
                    {
                        RoutineDetailJsonBOStr = OdataCDMJson<RoutineDetailJsonDTO>.GetJsonString(RoutineDetailJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.RoutineDetail_Add(RoutineDetailID, parent.RoutineHeaderID,ActivityID,TaskID,Frequency, ClassName, InterfaceName,
                        AuditInfoGuid, AvailStatusID,  RoutineDetailJsonBOStr, DateTime.UtcNow);

                    FieldManager.UpdateChildren(this);

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            MarkOld();
        }

        #endregion //Data Access - Insert
        private void UpdateObjectIDs()
        {         
            //if (TaskID == "NEW")
            //{
            //    TaskID = CDMEntityKeys.TaskIDNextId();
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
                    string RoutineDetailJsonBOStr = null;
                    if (RoutineDetailJsonBO != null)
                    {
                        RoutineDetailJsonBOStr = OdataCDMJson<RoutineDetailJsonDTO>.GetJsonString(RoutineDetailJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.RoutineDetail_Upd(RoutineDetailID, RoutineHeaderID, ActivityID, TaskID, Frequency, ClassName, InterfaceName,
                        AuditInfoGuid, AvailStatusID, RoutineDetailJsonBOStr, DateTime.UtcNow);
                    FieldManager.UpdateChildren(this);
                }//using
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void Child_Update(RoutineHeader parent)
        {
            if (!IsDirty) return;
            UpdateObjectIDs();
            if (base.IsDirty)
            {
                using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
                {
                    string RoutineDetailJsonBOStr = null;
                    if (RoutineDetailJsonBO != null)
                    {
                        RoutineDetailJsonBOStr = OdataCDMJson<RoutineDetailJsonDTO>.GetJsonString(RoutineDetailJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.RoutineDetail_Upd(RoutineDetailID, parent.RoutineHeaderID, ActivityID, TaskID, Frequency, ClassName, InterfaceName,
                        AuditInfoGuid, AvailStatusID, RoutineDetailJsonBOStr, DateTime.UtcNow);
                    FieldManager.UpdateChildren(this);
                }//using

                MarkOld();
            }
        }
        #endregion //Data Access - Update

        #region Data Access - Delete

        private void DataPortal_Delete(Criteria criteria)
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                         .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {                
                    mgr.DataContext.RoutineDetail_Del(criteria.ID);
            }//using
        }
        private void Child_DeleteSelf(RoutineHeader parent)
        {
            if (!this.IsDirty) return;

            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                    .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {
                try
                {
                    mgr.DataContext.RoutineDetail_Del(RoutineDetailID);
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

    #region RoutineDetailJson

    #region RoutineDetailJsonDTO

    public class RoutineDetailJsonDTO
    {
        public string Frequency { get; set; }
        public bool IsNotify { get; set; }
        public int AlertBeforeMin { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Priority { get; set; }
        public string ClassName { get; set; }
        public RoutineDetailJsonDTO()
        {
            ClassName = "RoutineDetailJson";
        }
    }
    #endregion

    [Serializable()]
    public class RoutineDetailJsonBO : BusinessBase<RoutineDetailJsonBO>
    {
        #region Constructor
        public RoutineDetailJsonBO()
        {
            MarkAsChild();
        }

        public RoutineDetailJsonDTO ConvertToDTO()
        {
            RoutineDetailJsonDTO b = new RoutineDetailJsonDTO();
            b.IsNotify = this.IsNotify;
            b.Frequency = this.Frequency;
            b.AlertBeforeMin = this.AlertBeforeMin;
            b.StartTime = this.StartTime;
            b.EndTime = this.EndTime;
            b.Priority = this.Priority;
            return b;
        }
        #endregion

        #region Business Properties
        
        public static readonly PropertyInfo<string> PriorityProperty = RegisterProperty<string>(nameof(Priority));
        public string Priority
        {
            get => GetProperty(PriorityProperty);
            set => SetProperty(PriorityProperty, value);
        }
        public static readonly PropertyInfo<bool> IsNotifyProperty = RegisterProperty<bool>(nameof(IsNotify));
        public bool IsNotify
        {
            get => GetProperty(IsNotifyProperty);
            set => SetProperty(IsNotifyProperty, value);
        }
        public static readonly PropertyInfo<string> FrequencyProperty = RegisterProperty<string>(nameof(Frequency));
        public string Frequency
        {
            get => GetProperty(FrequencyProperty);
            set => SetProperty(FrequencyProperty, value);
        }
        public static readonly PropertyInfo<int> AlertBeforeMinProperty = RegisterProperty<int>(nameof(AlertBeforeMin));
        public int AlertBeforeMin
        {
            get => GetProperty(AlertBeforeMinProperty);
            set => SetProperty(AlertBeforeMinProperty, value);
        }
        public static readonly PropertyInfo<DateTime> StartTimeProperty = RegisterProperty<DateTime>(nameof(StartTime));
        public DateTime StartTime
        {
            get => GetProperty(StartTimeProperty);
            set => SetProperty(StartTimeProperty, value);
        }
        public static readonly PropertyInfo<DateTime> EndTimeProperty = RegisterProperty<DateTime>(nameof(EndTime));
        public DateTime EndTime
        {
            get => GetProperty(EndTimeProperty);
            set => SetProperty(EndTimeProperty, value);
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

        public static RoutineDetailJsonBO NewRoutineDetailJSON()
        {
            return DataPortal.CreateChild<RoutineDetailJsonBO>();
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
                RoutineDetailJsonDTO RoutineDetailJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<RoutineDetailJsonDTO>(BlogJsondtojson);
                if (RoutineDetailJSON != null)
                    Child_Fetch(RoutineDetailJSON);
            }
        }
        private void Child_Fetch(RoutineDetailJsonDTO data)
        {
            Priority = data.Priority;
            IsNotify = data.IsNotify;
            Frequency = data.Frequency;
            AlertBeforeMin = data.AlertBeforeMin;
            StartTime = data.StartTime;
            EndTime = data.EndTime;
            //TotalEquipmentSalesPrice = data.TotalEquipmentSalesPrice;
            MarkOld();
        }

        #region Data Access - Insert

        private void Child_Insert(RoutineDetail parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        private void Child_Update(RoutineDetail parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        private void Child_DeleteSelf(RoutineDetail parent)
        {
            MarkNew();
        }
        #endregion //Data Access - Delete
#endif
    }
    #endregion

}