
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;
using System.Xml;
using System.Xml.Serialization;

namespace e2.CDM.Lib
{
    [Serializable()]
    public class ProjectList : Csla.ReadOnlyListBase<ProjectList, ProjectInfo>
    {
        #region Constuctor
        public ProjectList()
        { }
        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ProjectList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogInfosViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<ProjectList> GetProjectListAsync()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<ProjectList>();
        }

        public static async System.Threading.Tasks.Task<ProjectList> GetProject_ByProjectIDAsync(string ProjectID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<ProjectList>(new ProjectIDCriteria(ProjectID));
        }

        public static ProjectList GetProject_ByProjectID(string ProjectID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return DataPortal.Fetch<ProjectList>(new ProjectIDCriteria(ProjectID));
        }
        public static ProjectList GetProjectList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return DataPortal.Fetch<ProjectList>();
        }

#if !NETFX_CORE
#endif
        #endregion //Factory Methods


        #region Filter Criteria

        [Serializable()]
        private class ProjectIDCriteria : CriteriaBase<ProjectIDCriteria>
        {

            public static readonly PropertyInfo<string> ProjectIDProperty = RegisterProperty<string>(c => c.ProjectID);
            public string ProjectID
            {
                get { return ReadProperty(ProjectIDProperty); }
                set { LoadProperty(ProjectIDProperty, value); }
            }
            public ProjectIDCriteria()
            { }
            public ProjectIDCriteria(string _ProjectID)
            {
                this.ProjectID = _ProjectID;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
#if !NETFX_CORE
        private void DataPortal_Fetch()
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.Project_GetAll()
                  select ProjectInfo.GetProjectInfo(row)
                );

                IsReadOnly = true;
            } //using
        }
        private void DataPortal_Fetch(ProjectIDCriteria criteria)
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.Project_GetByID(criteria.ProjectID)
                  select ProjectInfo.GetProjectInfo(row)
                );

                IsReadOnly = true;
            } //using
        }

#endif


        //Standard Ver


        #endregion //Data Access
    }
}
