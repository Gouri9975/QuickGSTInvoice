using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{

    [Serializable()]
    public class Activity  : Csla.BusinessBase<Activity>
    {

        #region Constuctor
        public Activity()
        { }
        #endregion

        #region Business Properties and Methods

        public static readonly PropertyInfo<string> ActivityIDProperty = RegisterProperty<string>(c => c.ActivityID);
        public string ActivityID
        {
            get { return GetProperty(ActivityIDProperty); }
            set { SetProperty(ActivityIDProperty, value); }
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
        public static readonly PropertyInfo<ActivityJsonBO> ActivityJsonBOProperty = RegisterProperty<ActivityJsonBO>(c => c.ActivityJsonBO);
        public ActivityJsonBO ActivityJsonBO
        {
            get { return GetProperty(ActivityJsonBOProperty); }
            set { SetProperty(ActivityJsonBOProperty, value); }
        }
        public static readonly PropertyInfo<Activities2Tasks> Activities2TasksProperty = RegisterProperty<Activities2Tasks>(c => c.Activities2Tasks);
        public Activities2Tasks Activities2Tasks
        {
            get { return GetProperty(Activities2TasksProperty); }
            set { SetProperty(Activities2TasksProperty, value); }
        }
        protected override object GetIdValue()
        {
            return ActivityID;
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
            //TODO: Define CanGetObject permission in Activity
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in Activity
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in Activity
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in Activity
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<Activity> NewActivityAsync()
        {
            try
            {
                if (!CanAddObject())
                    throw new System.Security.SecurityException("User not authorized to add a Activity");
                return await DataPortal.CreateAsync<Activity>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async System.Threading.Tasks.Task<Activity> GetActivityAsync(string ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Activity");
            return await DataPortal.FetchAsync<Activity>(new Criteria(ID));
        }

        public static async void DeleteActivityAsync(string ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Activity");
            await DataPortal.DeleteAsync<Activity>(new Criteria(ID));
        }
#if !SILVERLIGHT && !NETFX_CORE
        public static Activity NewActivity()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Activity");
            return DataPortal.Create<Activity>();
        }
        public static Activity GetActivity(string ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Activity");
            return DataPortal.Fetch<Activity>(new Criteria(ID));
        }
        public static void DeleteActivity(string ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Activity");
            DataPortal.Delete<Activity>(new Criteria(ID));
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
            ActivityID = "NEW";
            AuditInfoGuid = Guid.NewGuid();
            LastUpdateUTCDT = DateTime.UtcNow;
            Status = "ACTIVE";
            Activities2Tasks = Activities2Tasks.NewActivities2Tasks();
            ActivityJsonBO = ActivityJsonBO.NewActivityJSON();
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
                    var data = mgr.DataContext.Activity_GetByID(criteria.ID).FirstOrDefault();
                    if (data != null)
                    {
                        ActivityID = data.ActivityID;
                        Status = data.Status;
                        AuditInfoGuid = data.AuditInfoGuid;
                        if (!string.IsNullOrEmpty(data.ActivityJSON))
                        {
                            CDMDTO cDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.ActivityJSON);
                            if (cDMDTO.ClassName.Equals("ActivityJson"))
                                ActivityJsonBO = DataPortal.FetchChild<ActivityJsonBO>(data.ActivityJSON);
                        }
                       // Activities2Tasks = Activities2Tasks.GetItemActivities2Tasks_ByActivitiesID(criteria.ID.ToString());
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
                    string ActivityJsonBOStr = null;
                    if (ActivityJsonBO != null)
                    {
                        ActivityJsonBOStr = OdataCDMJson<ActivityJsonDTO>.GetJsonString(ActivityJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.Activity_Add(ActivityID, ActivityJsonBOStr, Status, AuditInfoGuid, DateTime.Now);
                    //FieldManager.UpdateChildren(this);
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
            if (ActivityID == "NEW")
            {
                ActivityID = CDMEntityKeys.ActivityIDNextId();
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
                    string ActivityJsonBOStr = null;
                    if (ActivityJsonBO != null)
                    {
                        ActivityJsonBOStr = OdataCDMJson<ActivityJsonDTO>.GetJsonString(ActivityJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.Activity_Upd(ActivityID, ActivityJsonBOStr, Status, AuditInfoGuid, DateTime.UtcNow);
                    //FieldManager.UpdateChildren(this);
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
                    mgr.DataContext.Activity_Void(criteria.ID);
            }//using
        }
        #endregion //Data Access - Delete

#endif
        #endregion //Data Access
    }

    #region ActivityJsonDTOJSON

    #region ActivityJsonDTO

    public class ActivityJsonDTO
    {
        public string ActivityDesc { get; set; }

        //public DateTime TranDate { get; set; }
        //public DateTime FromDate { get; set; }
        //public DateTime ToDate { get; set; }
        //public string ApplicableTo { get; set; }     
        //public int NoOfDays { get; set; }
        public string ClassName { get; set; }
        public ActivityJsonDTO()
        {
            ClassName = "ActivityJson";
        }
    }
    #endregion

    [Serializable()]
    public class ActivityJsonBO : BusinessBase<ActivityJsonBO>
    {
        #region Constructor
        public ActivityJsonBO()
        {
            MarkAsChild();
        }

        public ActivityJsonDTO ConvertToDTO()
        {
            ActivityJsonDTO b = new ActivityJsonDTO();
            b.ActivityDesc = this.ActivityDesc;        
            return b;
        }
        #endregion

        #region Business Properties
      
        public static readonly PropertyInfo<string> ActivityDescProperty = RegisterProperty<string>(c => c.ActivityDesc);
        public string ActivityDesc
        {
            get { return GetProperty(ActivityDescProperty); }
            set { SetProperty(ActivityDescProperty, value); }
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

        public static ActivityJsonBO NewActivityJSON()
        {
            return DataPortal.CreateChild<ActivityJsonBO>();
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
                ActivityJsonDTO ActivityJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ActivityJsonDTO>(BlogJsondtojson);
                if (ActivityJson != null)
                    Child_Fetch(ActivityJson);
            }
        }
        private void Child_Fetch(ActivityJsonDTO data)
        {
            
            ActivityDesc = data.ActivityDesc;           
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