using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{


  [Serializable()]
    public class Project : Csla.BusinessBase<Project>
    {

        #region Constuctor
        public Project()
        { }
        #endregion

        #region Business Properties and Methods

        public static readonly PropertyInfo<string> ProjectIDProperty = RegisterProperty<string>(c => c.ProjectID);
        public string ProjectID
        {
            get { return GetProperty(ProjectIDProperty); }
            set { SetProperty(ProjectIDProperty, value); }
        }
        public static readonly PropertyInfo<ProjectJsonBO> ProjectJsonBOProperty = RegisterProperty<ProjectJsonBO>(c => c.ProjectJsonBO);
        public ProjectJsonBO ProjectJsonBO
        {
            get { return GetProperty(ProjectJsonBOProperty); }
            set { SetProperty(ProjectJsonBOProperty, value); }
        }
        public static readonly PropertyInfo<string> CompanyIDProperty = RegisterProperty<string>(c => c.CompanyID);
        public string CompanyID
        {
            get { return GetProperty(CompanyIDProperty); }
            set { SetProperty(CompanyIDProperty, value); }
        }
        public static readonly PropertyInfo<string> LocationIDProperty = RegisterProperty<string>(c => c.LocationID);
        public string LocationID 
        {
            get { return GetProperty(LocationIDProperty); }
            set { SetProperty(LocationIDProperty, value); }
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
        protected override object GetIdValue()
        {
            return ProjectID;
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

        public static async System.Threading.Tasks.Task<Project> NewProjectAsync()
        {
            try
            {
                if (!CanAddObject())
                    throw new System.Security.SecurityException("User not authorized to add a Project");
                return await DataPortal.CreateAsync<Project>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async System.Threading.Tasks.Task<Project> GetProjectAsync(string ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Project");
            return await DataPortal.FetchAsync<Project>(new Criteria(ID));
        }

        public static async void DeleteProjectAsync(string ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Task");
            await DataPortal.DeleteAsync<Project>(new Criteria(ID));
        }
#if !SILVERLIGHT && !NETFX_CORE
        public static Project NewProject()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a Task");
            return DataPortal.Create<Project>();
        }
        public static Project GetProject(string ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Task");
            return DataPortal.Fetch<Project>(new Criteria(ID));
        }
        public static void DeleteProject(string ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a Task");
            DataPortal.Delete<Project>(new Criteria(ID));
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
            ProjectID = "NEW";
            AuditInfoGuid = Guid.NewGuid();
            LastUpdateUTCDT = DateTime.UtcNow;
            Status = "ACTIVE";
         
            ProjectJsonBO = ProjectJsonBO.NewProjectJSON();
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
                    var data = mgr.DataContext.Project_GetByID(criteria.ID).FirstOrDefault();
                    if (data != null)
                    {
                        ProjectID = data.ProjectID;
                        CompanyID = data.CompanyID;
                        LocationID = data.LocationID;
                        Status = data.Status;
                        AuditInfoGuid = data.AuditInfoGuid;
                        if (!string.IsNullOrEmpty(data.ProjectJSON))
                        {
                            CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.ProjectJSON);
                            if (CDMdto.ClassName.Equals("ProjectJson"))
                                ProjectJsonBO = DataPortal.FetchChild<ProjectJsonBO>(data.ProjectJSON);
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
                    string ProjectJsonBOStr = null;
                    if (ProjectJsonBO != null)
                    {
                        ProjectJsonBOStr = OdataCDMJson<ProjectJsonDTO>.GetJsonString(ProjectJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.Project_Add(ProjectID, ProjectJsonBOStr, CompanyID,LocationID, Status, AuditInfoGuid, DateTime.Now);
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
            if (ProjectID == "NEW")
            {
                ProjectID = CDMEntityKeys.ProjectIDNextId();
            }

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
                    string ProjectJsonBOStr = null;
                    if (ProjectJsonBO != null)
                    {
                        ProjectJsonBOStr = OdataCDMJson<ProjectJsonDTO>.GetJsonString(ProjectJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.Project_Upd(ProjectID, ProjectJsonBOStr, CompanyID, LocationID, Status, AuditInfoGuid, DateTime.Now);
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
                    mgr.DataContext.Project_Void(criteria.ID);
            }//using
        }
        #endregion //Data Access - Delete

#endif
        #endregion //Data Access
    }

    #region ProjectJson
         
    #region ProjectJsonDTO

    public class ProjectJsonDTO
    {
    public string ProjectName { get; set; }

    public string ProjectDesc { get; set; }
    
        public string ClassName { get; set; }
        public ProjectJsonDTO()
        {
            ClassName = "ProjectJson";
        }
    }
    #endregion

    [Serializable()]
    public class ProjectJsonBO : BusinessBase<ProjectJsonBO>
    {
        #region Constructor
        public ProjectJsonBO()
        {
            MarkAsChild();
        }

        public ProjectJsonDTO ConvertToDTO()
        {
            ProjectJsonDTO b = new ProjectJsonDTO();
            b.ProjectName = this.ProjectName;
            b.ProjectDesc = this.ProjectDesc;       
            return b;
        }
        #endregion

        #region Business Properties
       
        public static readonly PropertyInfo<string> ProjectDescProperty = RegisterProperty<string>(c => c.ProjectDesc);
        public string ProjectDesc
        {
            get { return GetProperty(ProjectDescProperty); }
            set { SetProperty(ProjectDescProperty, value); }
        }
    public static readonly PropertyInfo<string> ProjectNameProperty = RegisterProperty<string>(c => c.ProjectName);
    public string ProjectName
    {
      get { return GetProperty(ProjectNameProperty); }
      set { SetProperty(ProjectNameProperty, value); }
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

        public static ProjectJsonBO NewProjectJSON()
        {
            return DataPortal.CreateChild<ProjectJsonBO>();
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
                ProjectJsonDTO ProjectJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectJsonDTO>(BlogJsondtojson);
                if (ProjectJSON != null)
                    Child_Fetch(ProjectJSON);
            }
        }
        private void Child_Fetch(ProjectJsonDTO data)
        {
           
            ProjectDesc = data.ProjectDesc;
            ProjectName = data.ProjectName;
            MarkOld();
        }

    #region Data Access - Insert

        private void Child_Insert(Project parent)
        {
            MarkOld();
        }

    #endregion //Data Access - Insert

    #region Data Access - Update
        private void Child_Update(Project parent)
        {
            MarkOld();
        }

    #endregion //Data Access - Update

    #region Data Access - Delete
        private void Child_DeleteSelf(Project parent)
        {
            MarkNew();
        }
    #endregion //Data Access - Delete
#endif
  }
  #endregion

}