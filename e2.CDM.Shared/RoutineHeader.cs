using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;


namespace e2.CDM.Lib
{

    [Serializable()]
    public class RoutineHeader : Csla.BusinessBase<RoutineHeader>
    {

        #region Constuctor
        public RoutineHeader()
        {
           
        }
        #endregion

        #region Business Properties and Methods
        public static readonly PropertyInfo<RoutineDetails> RoutineDetailsProperty = RegisterProperty<RoutineDetails>(c => c.RoutineDetails);
        public RoutineDetails RoutineDetails
        {
            get { return GetProperty(RoutineDetailsProperty); }
            set { SetProperty(RoutineDetailsProperty, value); }
        }



        public static readonly PropertyInfo<Guid> RoutineHeaderIDProperty = RegisterProperty<Guid>(c => c.RoutineHeaderID);
        public Guid RoutineHeaderID
        {
            get { return GetProperty(RoutineHeaderIDProperty); }
            set { SetProperty(RoutineHeaderIDProperty, value); }
        }
        
        public static readonly PropertyInfo<DateTime> RoutineDateProperty = RegisterProperty<DateTime>(c => c.RoutineDate);
        public DateTime RoutineDate
        {
            get { return GetProperty(RoutineDateProperty); }
            set { SetProperty(RoutineDateProperty, value); }
        }
        //public static readonly PropertyInfo<ActionDateRange> TaskActionDateRangeRangeProperty = RegisterProperty<ActionDateRange>(nameof(TaskActionDateRange));
        //public ActionDateRange TaskActionDateRange
        //{
        //    get => GetProperty(TaskActionDateRangeRangeProperty);
        //    set => SetProperty(TaskActionDateRangeRangeProperty, value);
        //}
        public static readonly PropertyInfo<string> RefIDProperty = RegisterProperty<string>(nameof(RefID));
        public string RefID
        {
            get => GetProperty(RefIDProperty);
            set => SetProperty(RefIDProperty, value);
        }
        public static readonly PropertyInfo<string> RefTypeProperty = RegisterProperty<string>(nameof(RefType));
        public string RefType
        {
            get => GetProperty(RefTypeProperty);
            set => SetProperty(RefTypeProperty, value);
        }
        public static readonly PropertyInfo<string> RemarkProperty = RegisterProperty<string>(nameof(Remark));
        public string Remark
        {
            get => GetProperty(RemarkProperty);
            set => SetProperty(RemarkProperty, value);
        }
        
        public static readonly PropertyInfo<RoutineHeaderJsonBO> RoutineHeaderJsonBOProperty = RegisterProperty<RoutineHeaderJsonBO>(c => c.RoutineHeaderJsonBO);
        public RoutineHeaderJsonBO RoutineHeaderJsonBO
        {
            get { return GetProperty(RoutineHeaderJsonBOProperty); }
            set { SetProperty(RoutineHeaderJsonBOProperty, value); }
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
            return RoutineHeaderID;
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

        public static async System.Threading.Tasks.Task<RoutineHeader> NewRoutineHeaderAsync()
        {
            try
            {
                if (!CanAddObject())
                    throw new System.Security.SecurityException("User not authorized to add a Task");
                return await DataPortal.CreateAsync<RoutineHeader>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static async System.Threading.Tasks.Task<RoutineHeader> GetRoutineHeaderAsync(Guid ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Task");
            return await DataPortal.FetchAsync<RoutineHeader>(new Criteria(ID));
        }

        public static async void DeleteRoutineHeaderAsync(Guid ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Task");
            await DataPortal.DeleteAsync<RoutineHeader>(new Criteria(ID));
        }
       

#if !SILVERLIGHT && !NETFX_CORE
        public static RoutineHeader NewRoutineHeader()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Task");
            return DataPortal.Create<RoutineHeader>();
        }

        public static RoutineHeader NewItemRoutineHeader()
        {
            return DataPortal.CreateChild<RoutineHeader>();
        }
        public static RoutineHeader GetRoutineHeader(Guid ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Task");
            return DataPortal.Fetch<RoutineHeader>(new Criteria(ID));
        }
        public static void DeleteRoutineHeader(Guid ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Task");
            DataPortal.Delete<RoutineHeader>(new Criteria(ID));
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
            RoutineHeaderID = Guid.NewGuid();
            AuditInfoGuid = Guid.NewGuid();
            LastUpdateUTCDT = DateTime.UtcNow;
            AvailStatusID = "ACTIVE";
            RoutineHeaderJsonBO = RoutineHeaderJsonBO.NewRoutineHeaderJSON();
            RoutineDetails = RoutineDetails.NewRoutineDetails();
            base.DataPortal_Create();

            BusinessRules.CheckRules();
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
                    var data = mgr.DataContext.RoutineHeader_Get(criteria.ID).FirstOrDefault();
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
                        RoutineDetails=RoutineDetails.GetRoutineDetailsList(RoutineHeaderID);
                    }
                    MarkOld();
                }

            }//using
            //catch (Exception e)
            //{
            //    throw;
            //}
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
                    string RoutineHeaderJsonBOStr = null;
                    if (RoutineHeaderJsonBO != null)
                    {
                        RoutineHeaderJsonBOStr = OdataCDMJson<RoutineHeaderJsonDTO>.GetJsonString(RoutineHeaderJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.RoutineHeader_Add(RoutineHeaderID, RoutineDate,RefType, RefID, Remark, AuditInfoGuid, AvailStatusID,RoutineHeaderJsonBOStr, DateTime.UtcNow);

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
                    string RoutineHeaderJsonBOStr = null;
                    if (RoutineHeaderJsonBO != null)
                    {
                        RoutineHeaderJsonBOStr = OdataCDMJson<RoutineHeaderJsonDTO>.GetJsonString(RoutineHeaderJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.RoutineHeader_Upd(RoutineHeaderID,RoutineDate, RefType, RefID, Remark,  AuditInfoGuid,AvailStatusID, RoutineHeaderJsonBOStr,  DateTime.UtcNow);
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
                    mgr.DataContext.RoutineHeader_Del(criteria.ID);
            }//using
        }
     
        #endregion //Data Access - Delete

#endif
        #endregion //Data Access
    }

    #region RoutineHeaderJson

    #region RoutineHeaderJsonDTO

    public class RoutineHeaderJsonDTO
    {

       
        public string RoutineName { get; set; }
        public string ClassName { get; set; }
        public RoutineHeaderJsonDTO()
        {
            ClassName = "RoutineHeaderJson";
        }
    }
    #endregion

    [Serializable()]
    public class RoutineHeaderJsonBO : BusinessBase<RoutineHeaderJsonBO>
    {
        #region Constructor
        public RoutineHeaderJsonBO()
        {
            MarkAsChild();
        }

        public RoutineHeaderJsonDTO ConvertToDTO()
        {
            RoutineHeaderJsonDTO b = new RoutineHeaderJsonDTO();           
            b.RoutineName = this.RoutineName;
            return b;
        }
        #endregion

        #region Business Properties

        
        public static readonly PropertyInfo<string> RoutineNameProperty = RegisterProperty<string>(nameof(RoutineName));
        public string RoutineName
        {
            get => GetProperty(RoutineNameProperty);
            set => SetProperty(RoutineNameProperty, value);
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

        public static RoutineHeaderJsonBO NewRoutineHeaderJSON()
        {
            return DataPortal.CreateChild<RoutineHeaderJsonBO>();
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
                RoutineHeaderJsonDTO RoutineHeaderJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<RoutineHeaderJsonDTO>(BlogJsondtojson);
                if (RoutineHeaderJSON != null)
                    Child_Fetch(RoutineHeaderJSON);
            }
        }
        private void Child_Fetch(RoutineHeaderJsonDTO data)
        {            
            RoutineName = data.RoutineName;
            MarkOld();
        }

        #region Data Access - Insert

        private void Child_Insert(RoutineHeader parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        private void Child_Update(RoutineHeader parent)
        {
            MarkOld();
        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        private void Child_DeleteSelf(RoutineHeader parent)
        {
            MarkNew();
        }
        #endregion //Data Access - Delete
#endif
    }
    #endregion

}