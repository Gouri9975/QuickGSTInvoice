
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
    public class TaskList : Csla.ReadOnlyListBase<TaskList, TaskInfo>
    {
        #region Constuctor
        public TaskList()
        { }
        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TaskList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogInfosViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<TaskList> GetTaskListAsync()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<TaskList>();
        }
        public static async System.Threading.Tasks.Task<TaskList> GetProjectTaskListAsync()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<TaskList>(new TaskCriteria(""));
        }


        public static TaskList GetTaskList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return DataPortal.Fetch<TaskList>();
        }
        public static TaskList GetProjectTaskList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return DataPortal.Fetch<TaskList>(new TaskCriteria(""));
        }

#if !NETFX_CORE
#endif
        #endregion //Factory Methods


        #region Filter Criteria

        [Serializable()]
        private class TaskCriteria : CriteriaBase<TaskCriteria>
        {

            public static readonly PropertyInfo<string> TaskIDProperty = RegisterProperty<string>(c => c.TaskID);
            public string TaskID
            {
                get { return ReadProperty(TaskIDProperty); }
                set { LoadProperty(TaskIDProperty, value); }
            }
            public TaskCriteria()
            { }
            public TaskCriteria(string _TaskID)
            {
                this.TaskID = _TaskID;
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
                  from row in mgr.DataContext.Tasks_All()
                  select TaskInfo.GetTaskInfo(row)
                );

                IsReadOnly = true;
            } //using
        }
        private void DataPortal_Fetch(TaskCriteria criteria)
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.Task_GetAll()
                  select TaskInfo.GetTaskInfo(row)
                );

                IsReadOnly = true;
            } //using
        }

#endif


        //Standard Ver


        #endregion //Data Access
    }
}
