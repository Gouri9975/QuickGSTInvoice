
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public partial class ProjectInfo : Csla.ReadOnlyBase<ProjectInfo>
    {
        #region Constuctor
        public ProjectInfo()
        { }
        #endregion

        #region Business Properties and Methods


        public static readonly PropertyInfo<string> ProjectIDProperty = RegisterProperty<string>(c => c.ProjectID);
        public string ProjectID
        {
            get { return GetProperty(ProjectIDProperty); }
            set { LoadProperty(ProjectIDProperty, value); }
        }
        public static readonly PropertyInfo<string> ProjectNameProperty = RegisterProperty<string>(nameof(ProjectName));
        public string ProjectName
        {
            get => GetProperty(ProjectNameProperty);
            set => LoadProperty(ProjectNameProperty, value);
        }
        public static readonly PropertyInfo<string> CompanyIDProperty = RegisterProperty<string>(c => c.CompanyID);
        public string CompanyID
        {
            get { return GetProperty(CompanyIDProperty); }
            set { LoadProperty(CompanyIDProperty, value); }
        }
        public static readonly PropertyInfo<string> LocationIDProperty = RegisterProperty<string>(c => c.LocationID);
        public string LocationID
        {
            get { return GetProperty(LocationIDProperty); }
            set { LoadProperty(LocationIDProperty, value); }
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
        public static readonly PropertyInfo<ProjectJsonBO> ProjectJsonBOProperty = RegisterProperty<ProjectJsonBO>(c => c.ProjectJsonBO);
        public ProjectJsonBO ProjectJsonBO
        {
          get { return GetProperty(ProjectJsonBOProperty); }
          set { LoadProperty(ProjectJsonBOProperty, value); }
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
        internal static ProjectInfo GetProjectInfo(e2.CDM.DAL.Lib.Project_GetAllResult data)
        {
            ProjectInfo item = new ProjectInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Project_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                ProjectID = data.ProjectID;
                CompanyID = data.CompanyID;
                LocationID = data.LocationID;
                Status = data.Status;
                if (!string.IsNullOrEmpty(data.ProjectJSON))
                {
                  CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.ProjectJSON);
                  if (CDMdto.ClassName.Equals("ProjectJson"))
                    ProjectJsonBO = DataPortal.FetchChild<ProjectJsonBO>(data.ProjectJSON);
                }
                if(ProjectJsonBO != null)
                {
                    ProjectName = ProjectJsonBO.ProjectName;
                }
            }
            OnFetched();
        }
        internal static ProjectInfo GetProjectInfo(e2.CDM.DAL.Lib.Project_GetByIDResult data)
        {
            ProjectInfo item = new ProjectInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Project_GetByIDResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                ProjectID = data.ProjectID;
                CompanyID = data.CompanyID;
                LocationID = data.LocationID;
                Status = data.Status;
                if (!string.IsNullOrEmpty(data.ProjectJSON))
                {
                  CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.ProjectJSON);
                  if (CDMdto.ClassName.Equals("ProjectJson"))
                    ProjectJsonBO = DataPortal.FetchChild<ProjectJsonBO>(data.ProjectJSON);
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
