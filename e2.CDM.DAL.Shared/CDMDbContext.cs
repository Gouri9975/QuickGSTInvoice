using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using e2.Data.EFCore;
using Microsoft.Data.SqlClient;     ///This name space should use to exeecute the stored procedure with OutPut parameter
namespace e2.CDM.DAL.Lib
{
  public partial class CDMEntitiesDataContext : Microsoft.EntityFrameworkCore.DbContext
  {
    string _CDMConnectionString;
    public CDMEntitiesDataContext(string connection)
    {
      //_CDMConnectionString = connection;
#if N5
      _CDMConnectionString = Csla.Configuration.ConfigurationManager.ConnectionStrings[connection].ConnectionString;
#endif
#if !N5
            _CDMConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connection].ToString();
#endif
    }

    public CDMEntitiesDataContext(DbContextOptions<CDMEntitiesDataContext> options)
        : base(options)
    {
#if N5
      _CDMConnectionString = Csla.Configuration.ConfigurationManager.ConnectionStrings[e2.CDM.DAL.Lib.Database.CDMConnection].ConnectionString;
#endif
#if !N5
            _CDMConnectionString = System.Configuration.ConfigurationManager.AppSettings[e2.CDM.DAL.Lib.Database.CDMConnection].ToString();
#endif
    }

        #region DBSet Entity
        public DbSet<RouteEvent_GetAllResult> RouteEvent_GetAllResult { get; set; }
        public DbSet<RouteEvent_GetByEventDateTimeResult> RouteEvent_GetByEventDateTimeResult { get; set; }
        public DbSet<RouteEvent_GetByIDResult> RouteEvent_GetByIDResult { get; set; }
        public DbSet<Report_GetAllResult> Report_GetAllResult { get; set; }
        public DbSet<EntityMetaInfoDetail_GetResult> EntityMetaInfoDetail_GetResult { get; set; }
        public DbSet<EntityMetaInfo_GetResult> EntityMetaInfo_GetResult { get; set; }
       
        public DbSet<EntityMetaInfoDetails_GetAllResult> EntityMetaInfoDetails_GetAllResult { get; set; }
        public DbSet<EntityMetaInfos_GetResult> EntityMetaInfos_GetResult { get; set; }
        public DbSet<EntityMetaInfos_GetAllResult> EntityMetaInfos_GetAllResult { get; set; }
       // public DbSet<Report_GetAllResult> Report_GetAllResult { get; set; }
    public DbSet<Report_GetByIDResult> Report_GetByIDResult { get; set; }
    public DbSet<Report2ScheduleEmail_GetByIDResult> Report2ScheduleEmail_GetByIDResult { get; set; }
    public DbSet<Report2ScheduleEmail_GetAllResult> Report2ScheduleEmail_GetAllResult { get; set; }
    public DbSet<SignalRLog_GetAllResult> SignalRLog_GetAllResult { get; set; }
	public DbSet<SignalRLog_GetByIDResult> SignalRLog_GetByIDResult { get; set; }
	public DbSet<SignalRLog_GetByTypeResult> SignalRLog_GetByTypeResult { get; set; }
    public DbSet<DataSyncInfo_GetAllResult> DataSyncInfo_GetAllResult { get; set; }
    public DbSet<DataSyncInfo_GetByIDResult> DataSyncInfo_GetByIDResult { get; set; }
    public DbSet<DataSyncInfo2Device_GetAllResult> DataSyncInfo2Device_GetAllResult { get; set; }
    public DbSet<DataSyncInfo2Device_GetByIDResult> DataSyncInfo2Device_GetByIDResult { get; set; }
    public DbSet<RoutineDetail_GetResult> RoutineDetail_GetResult { get; set; }
    public DbSet<RoutineDetail_GetByRoutineHeaderIDResult> RoutineDetail_GetByRoutineHeaderIDResult { get; set; }
    public DbSet<RoutineHeader_GetResult> RoutineHeader_GetResult { get; set; }
    public DbSet<RoutineHeader_GetRefTypeAndRefIDResult> RoutineHeader_GetRefTypeAndRefIDResult { get; set; }
    public DbSet<References2Notes_GetAllResult> References2Notes_GetAllResult { get; set; }
    public DbSet<References2Notes_GetByIDResult> References2Notes_GetByIDResult { get; set; }
    public DbSet<Project_GetAllResult> Project_GetAllResult { get; set; }
    public DbSet<Project_GetByIDResult> Project_GetByIDResult { get; set; }
    public DbSet<Task_GetAllResult> Task_GetAllResult { get; set; }
    public DbSet<Task_GetByIDResult> Task_GetByIDResult { get; set; }
    public DbSet<Activity_GetAllResult> Activity_GetAllResult { get; set; }
    public DbSet<Activity_GetByIDResult> Activity_GetByIDResult { get; set; }

    public DbSet<Activities_AllResult> Activities_AllResult { get; set; }
    public DbSet<Activities_GetByIDResult> Activities_GetByIDResult { get; set; }
    public DbSet<Activities2Tasks_AllResult> Activities2Tasks_AllResult { get; set; }
    public DbSet<Activities2Tasks_GetByIDResult> Activities2Tasks_GetByIDResult { get; set; }
    public DbSet<GetNextBillingIDExcptSvrID_OUTResult> GetNextBillingIDExcptSvrID_OUTResult { get; set; }
    public DbSet<Tasks_AllResult> Tasks_AllResult { get; set; }
    public DbSet<Tasks_GetByIDResult> Tasks_GetByIDResult { get; set; }
    public DbSet<Activities2Tasks_GetByActivitiesIDResult> Activities2Tasks_GetByActivitiesIDResult { get; set; }
    public DbSet<Equipment_GetAllResult> Equipment_GetAllResult { get; set; }
    public DbSet<Equipment_GetByIDResult> Equipment_GetByIDResult { get; set; }
    public DbSet<HResource_GetAllResult> HResource_GetAllResult { get; set; }
    public DbSet<HResource_GetByIDResult> HResource_GetByIDResult { get; set; }
    public DbSet<CurrencyExchange_GetAllResult> CurrencyExchange_GetAllResult { get; set; }
    public DbSet<CurrencyExchange_GetByIDResult> CurrencyExchange_GetByIDResult { get; set; }
    public DbSet<POCDoc_GetAllResult> POCDoc_GetAllResult { get; set; }
    public DbSet<POCDoc_GetByIDResult> POCDoc_GetByIDResult { get; set; }
    public DbSet<POCDoc_GetByRefIDResult> POCDoc_GetByRefIDResult { get; set; }
    public DbSet<Reference2Image_GetResult> Reference2Image_GetResult { get; set; }
    public DbSet<ReferenceImages_GetByReferenceResult> ReferenceImages_GetByReferenceResult { get; set; }
    public DbSet<ControlSysNo_GetResult> ControlSysNo_GetResult { get; set; }
    public DbSet<ControlSysNoType_GetResult> ControlSysNoType_GetResult { get; set; }
    public DbSet<GetNextBillingIDResult> GetNextBillingIDResult { get; set; }


        #endregion

        #region SP Calls
        public Int32 RouteEvent_Upd(Guid eventID, DateTime eventDateTime, String eventStatus, String driverID, String routeID, String routeStatus, String routeEventJSON)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var eventIDParameter = new SqlParameter();
            eventIDParameter.ParameterName = "@EventID";
            eventIDParameter.DbType = DbType.Guid;
            eventIDParameter.Direction = System.Data.ParameterDirection.Input;
            eventIDParameter.Value = eventID;
            parameters.Add(eventIDParameter);
            var eventDateTimeParameter = new SqlParameter();
            eventDateTimeParameter.ParameterName = "@EventDateTime";
            eventDateTimeParameter.DbType = DbType.DateTime;
            eventDateTimeParameter.Direction = System.Data.ParameterDirection.Input;
            eventDateTimeParameter.Value = eventDateTime;
            parameters.Add(eventDateTimeParameter);
            var eventStatusParameter = new SqlParameter();
            eventStatusParameter.ParameterName = "@EventStatus";
            eventStatusParameter.DbType = DbType.String;
            eventStatusParameter.Direction = System.Data.ParameterDirection.Input;
            eventStatusParameter.Size = 20;
            eventStatusParameter.Value = eventStatus;
            parameters.Add(eventStatusParameter);
            var driverIDParameter = new SqlParameter();
            driverIDParameter.ParameterName = "@DriverID";
            driverIDParameter.DbType = DbType.String;
            driverIDParameter.Direction = System.Data.ParameterDirection.Input;
            driverIDParameter.Size = 20;
            driverIDParameter.Value = driverID;
            parameters.Add(driverIDParameter);
            var routeIDParameter = new SqlParameter();
            routeIDParameter.ParameterName = "@RouteID";
            routeIDParameter.DbType = DbType.String;
            routeIDParameter.Direction = System.Data.ParameterDirection.Input;
            routeIDParameter.Size = 20;
            routeIDParameter.Value = routeID;
            parameters.Add(routeIDParameter);
            var routeStatusParameter = new SqlParameter();
            routeStatusParameter.ParameterName = "@RouteStatus";
            routeStatusParameter.DbType = DbType.String;
            routeStatusParameter.Direction = System.Data.ParameterDirection.Input;
            routeStatusParameter.Size = 20;
            routeStatusParameter.Value = routeStatus;
            parameters.Add(routeStatusParameter);
            var routeEventJSONParameter = new SqlParameter();
            routeEventJSONParameter.ParameterName = "@RouteEventJSON";
            routeEventJSONParameter.DbType = DbType.String;
            routeEventJSONParameter.Direction = System.Data.ParameterDirection.Input;
            routeEventJSONParameter.Value = routeEventJSON;
            parameters.Add(routeEventJSONParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RouteEvent_Upd", parameters);
        }
        public Int32 RouteEvent_Add(Guid eventID, DateTime eventDateTime, String eventStatus, String driverID, String routeID, String routeStatus, String routeEventJSON)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var eventIDParameter = new SqlParameter();
            eventIDParameter.ParameterName = "@EventID";
            eventIDParameter.DbType = DbType.Guid;
            eventIDParameter.Direction = System.Data.ParameterDirection.Input;
            eventIDParameter.Value = eventID;
            parameters.Add(eventIDParameter);
            var eventDateTimeParameter = new SqlParameter();
            eventDateTimeParameter.ParameterName = "@EventDateTime";
            eventDateTimeParameter.DbType = DbType.DateTime;
            eventDateTimeParameter.Direction = System.Data.ParameterDirection.Input;
            eventDateTimeParameter.Value = eventDateTime;
            parameters.Add(eventDateTimeParameter);
            var eventStatusParameter = new SqlParameter();
            eventStatusParameter.ParameterName = "@EventStatus";
            eventStatusParameter.DbType = DbType.String;
            eventStatusParameter.Direction = System.Data.ParameterDirection.Input;
            eventStatusParameter.Size = 20;
            eventStatusParameter.Value = eventStatus;
            parameters.Add(eventStatusParameter);
            var driverIDParameter = new SqlParameter();
            driverIDParameter.ParameterName = "@DriverID";
            driverIDParameter.DbType = DbType.String;
            driverIDParameter.Direction = System.Data.ParameterDirection.Input;
            driverIDParameter.Size = 20;
            driverIDParameter.Value = driverID;
            parameters.Add(driverIDParameter);
            var routeIDParameter = new SqlParameter();
            routeIDParameter.ParameterName = "@RouteID";
            routeIDParameter.DbType = DbType.String;
            routeIDParameter.Direction = System.Data.ParameterDirection.Input;
            routeIDParameter.Size = 20;
            routeIDParameter.Value = routeID;
            parameters.Add(routeIDParameter);
            var routeStatusParameter = new SqlParameter();
            routeStatusParameter.ParameterName = "@RouteStatus";
            routeStatusParameter.DbType = DbType.String;
            routeStatusParameter.Direction = System.Data.ParameterDirection.Input;
            routeStatusParameter.Size = 20;
            routeStatusParameter.Value = routeStatus;
            parameters.Add(routeStatusParameter);
            var routeEventJSONParameter = new SqlParameter();
            routeEventJSONParameter.ParameterName = "@RouteEventJSON";
            routeEventJSONParameter.DbType = DbType.String;
            routeEventJSONParameter.Direction = System.Data.ParameterDirection.Input;
            routeEventJSONParameter.Value = routeEventJSON;
            parameters.Add(routeEventJSONParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RouteEvent_Add", parameters);
        }
        public IEnumerable<RouteEvent_GetAllResult> RouteEvent_GetAll()
        {
            return ExecuteQuery<RouteEvent_GetAllResult>.ExecuteStoredProcedure(this, "CDM.RouteEvent_GetAll");
        }
        public IEnumerable<RouteEvent_GetByEventDateTimeResult> RouteEvent_GetByEventDateTime(DateTime eventDateTime)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var eventDateTimeParameter = new SqlParameter();
            eventDateTimeParameter.ParameterName = "@EventDateTime";
            eventDateTimeParameter.DbType = DbType.DateTime;
            eventDateTimeParameter.Direction = System.Data.ParameterDirection.Input;
            eventDateTimeParameter.Value = eventDateTime;
            parameters.Add(eventDateTimeParameter);
            return ExecuteQuery<RouteEvent_GetByEventDateTimeResult>.ExecuteStoredProcedure(this, "CDM.RouteEvent_GetByEventDateTime", parameters);
        }
        public IEnumerable<RouteEvent_GetByIDResult> RouteEvent_GetByID(Guid eventID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var eventIDParameter = new SqlParameter();
            eventIDParameter.ParameterName = "@EventID";
            eventIDParameter.DbType = DbType.Guid;
            eventIDParameter.Direction = System.Data.ParameterDirection.Input;
            eventIDParameter.Value = eventID;
            parameters.Add(eventIDParameter);
            return ExecuteQuery<RouteEvent_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.RouteEvent_GetByID", parameters);
        }
        public Int32 RouteEvent_Remove(Guid eventID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var eventIDParameter = new SqlParameter();
            eventIDParameter.ParameterName = "@EventID";
            eventIDParameter.DbType = DbType.Guid;
            eventIDParameter.Direction = System.Data.ParameterDirection.Input;
            eventIDParameter.Value = eventID;
            parameters.Add(eventIDParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RouteEvent_Remove", parameters);
        }
        public IEnumerable<EntityMetaInfoDetail_GetResult> EntityMetaInfoDetail_Get(String entityMetaInfoDetailID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var entityMetaInfoDetailIDParameter = new SqlParameter();
            entityMetaInfoDetailIDParameter.ParameterName = "@EntityMetaInfoDetailID";
            entityMetaInfoDetailIDParameter.DbType = DbType.String;
            entityMetaInfoDetailIDParameter.Direction = System.Data.ParameterDirection.Input;
            entityMetaInfoDetailIDParameter.Size = 20;
            entityMetaInfoDetailIDParameter.Value = entityMetaInfoDetailID;
            parameters.Add(entityMetaInfoDetailIDParameter);
            return ExecuteQuery<EntityMetaInfoDetail_GetResult>.ExecuteStoredProcedure(this, "CDM.EntityMetaInfoDetail_Get", parameters);
        }
        public IEnumerable<EntityMetaInfo_GetResult> EntityMetaInfo_Get(String entityMetaInfoID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var entityMetaInfoIDParameter = new SqlParameter();
            entityMetaInfoIDParameter.ParameterName = "@EntityMetaInfoID";
            entityMetaInfoIDParameter.DbType = DbType.String;
            entityMetaInfoIDParameter.Direction = System.Data.ParameterDirection.Input;
            entityMetaInfoIDParameter.Size = 20;
            entityMetaInfoIDParameter.Value = entityMetaInfoID;
            parameters.Add(entityMetaInfoIDParameter);
            return ExecuteQuery<EntityMetaInfo_GetResult>.ExecuteStoredProcedure(this, "CDM.EntityMetaInfo_Get", parameters);
        }
        
        public IEnumerable<EntityMetaInfoDetails_GetAllResult> EntityMetaInfoDetails_GetAll()
        {
            return ExecuteQuery<EntityMetaInfoDetails_GetAllResult>.ExecuteStoredProcedure(this, "CDM.EntityMetaInfoDetails_GetAll");
        }
        public IEnumerable<EntityMetaInfos_GetResult> EntityMetaInfos_Get()
        {
            return ExecuteQuery<EntityMetaInfos_GetResult>.ExecuteStoredProcedure(this, "CDM.EntityMetaInfos_Get");
        }
        public IEnumerable<EntityMetaInfos_GetAllResult> EntityMetaInfos_GetAll()
        {
            return ExecuteQuery<EntityMetaInfos_GetAllResult>.ExecuteStoredProcedure(this, "CDM.EntityMetaInfos_GetAll");
        }
        public Int32 Report_Add(Guid reportID, String reportName, String displayName, String reportMRTstr, String reportJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var reportIDParameter = new SqlParameter();
            reportIDParameter.ParameterName = "@ReportID";
            reportIDParameter.DbType = DbType.Guid;
            reportIDParameter.Direction = System.Data.ParameterDirection.Input;
            reportIDParameter.Value = reportID;
            parameters.Add(reportIDParameter);
            var reportNameParameter = new SqlParameter();
            reportNameParameter.ParameterName = "@ReportName";
            reportNameParameter.DbType = DbType.String;
            reportNameParameter.Direction = System.Data.ParameterDirection.Input;
            reportNameParameter.Size = 100;
            reportNameParameter.Value = reportName;
            parameters.Add(reportNameParameter);
            var displayNameParameter = new SqlParameter();
            displayNameParameter.ParameterName = "@DisplayName";
            displayNameParameter.DbType = DbType.String;
            displayNameParameter.Direction = System.Data.ParameterDirection.Input;
            displayNameParameter.Size = 100;
            displayNameParameter.Value = displayName;
            parameters.Add(displayNameParameter);
            var reportMRTstrParameter = new SqlParameter();
            reportMRTstrParameter.ParameterName = "@ReportMRTstr";
            reportMRTstrParameter.DbType = DbType.String;
            reportMRTstrParameter.Direction = System.Data.ParameterDirection.Input;
            reportMRTstrParameter.Value = reportMRTstr;
            parameters.Add(reportMRTstrParameter);
            var reportJSONParameter = new SqlParameter();
            reportJSONParameter.ParameterName = "@ReportJSON";
            reportJSONParameter.DbType = DbType.String;
            reportJSONParameter.Direction = System.Data.ParameterDirection.Input;
            reportJSONParameter.Value = reportJSON;
            parameters.Add(reportJSONParameter);
            var statusParameter = new SqlParameter();
            statusParameter.ParameterName = "@Status";
            statusParameter.DbType = DbType.String;
            statusParameter.Direction = System.Data.ParameterDirection.Input;
            statusParameter.Size = 20;
            statusParameter.Value = status;
            parameters.Add(statusParameter);
            var auditInfoGuidParameter = new SqlParameter();
            auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
            auditInfoGuidParameter.DbType = DbType.Guid;
            auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
            auditInfoGuidParameter.Value = auditInfoGuid;
            parameters.Add(auditInfoGuidParameter);
            var lastUpdateUTCDTParameter = new SqlParameter();
            lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
            lastUpdateUTCDTParameter.DbType = DbType.DateTime;
            lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
            lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
            parameters.Add(lastUpdateUTCDTParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Report_Add", parameters);
        }
        public IEnumerable<Report_GetAllResult> Report_GetAll()
        {
            return ExecuteQuery<Report_GetAllResult>.ExecuteStoredProcedure(this, "CDM.Report_GetAll");
        }
        public IEnumerable<Report_GetByIDResult> Report_GetByID(Guid reportID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var reportIDParameter = new SqlParameter();
            reportIDParameter.ParameterName = "@ReportID";
            reportIDParameter.DbType = DbType.Guid;
            reportIDParameter.Direction = System.Data.ParameterDirection.Input;
            reportIDParameter.Value = reportID;
            parameters.Add(reportIDParameter);
            return ExecuteQuery<Report_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Report_GetByID", parameters);
        }
        public Int32 Report_Remove(Guid reportID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var reportIDParameter = new SqlParameter();
            reportIDParameter.ParameterName = "@ReportID";
            reportIDParameter.DbType = DbType.Guid;
            reportIDParameter.Direction = System.Data.ParameterDirection.Input;
            reportIDParameter.Value = reportID;
            parameters.Add(reportIDParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Report_Remove", parameters);
        }
        public Int32 Report_Upd(Guid reportID, String reportName, String displayName, String reportMRTstr, String reportJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var reportIDParameter = new SqlParameter();
            reportIDParameter.ParameterName = "@ReportID";
            reportIDParameter.DbType = DbType.Guid;
            reportIDParameter.Direction = System.Data.ParameterDirection.Input;
            reportIDParameter.Value = reportID;
            parameters.Add(reportIDParameter);
            var reportNameParameter = new SqlParameter();
            reportNameParameter.ParameterName = "@ReportName";
            reportNameParameter.DbType = DbType.String;
            reportNameParameter.Direction = System.Data.ParameterDirection.Input;
            reportNameParameter.Size = 100;
            reportNameParameter.Value = reportName;
            parameters.Add(reportNameParameter);
            var displayNameParameter = new SqlParameter();
            displayNameParameter.ParameterName = "@DisplayName";
            displayNameParameter.DbType = DbType.String;
            displayNameParameter.Direction = System.Data.ParameterDirection.Input;
            displayNameParameter.Size = 100;
            displayNameParameter.Value = displayName;
            parameters.Add(displayNameParameter);
            var reportMRTstrParameter = new SqlParameter();
            reportMRTstrParameter.ParameterName = "@ReportMRTstr";
            reportMRTstrParameter.DbType = DbType.String;
            reportMRTstrParameter.Direction = System.Data.ParameterDirection.Input;
            reportMRTstrParameter.Value = reportMRTstr;
            parameters.Add(reportMRTstrParameter);
            var reportJSONParameter = new SqlParameter();
            reportJSONParameter.ParameterName = "@ReportJSON";
            reportJSONParameter.DbType = DbType.String;
            reportJSONParameter.Direction = System.Data.ParameterDirection.Input;
            reportJSONParameter.Value = reportJSON;
            parameters.Add(reportJSONParameter);
            var statusParameter = new SqlParameter();
            statusParameter.ParameterName = "@Status";
            statusParameter.DbType = DbType.String;
            statusParameter.Direction = System.Data.ParameterDirection.Input;
            statusParameter.Size = 20;
            statusParameter.Value = status;
            parameters.Add(statusParameter);
            var auditInfoGuidParameter = new SqlParameter();
            auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
            auditInfoGuidParameter.DbType = DbType.Guid;
            auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
            auditInfoGuidParameter.Value = auditInfoGuid;
            parameters.Add(auditInfoGuidParameter);
            var lastUpdateUTCDTParameter = new SqlParameter();
            lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
            lastUpdateUTCDTParameter.DbType = DbType.DateTime;
            lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
            lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
            parameters.Add(lastUpdateUTCDTParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Report_Upd", parameters);
        }
        public Int32 Report_Void(Guid reportID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var reportIDParameter = new SqlParameter();
            reportIDParameter.ParameterName = "@ReportID";
            reportIDParameter.DbType = DbType.Guid;
            reportIDParameter.Direction = System.Data.ParameterDirection.Input;
            reportIDParameter.Value = reportID;
            parameters.Add(reportIDParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Report_Void", parameters);
        }
        public Int32 Report2ScheduleEmail_Add(Guid report2ScheduleEmailID, Guid reportID, String dateRange, DateTime time, String frequency, String report2ScheduleEmailJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var report2ScheduleEmailIDParameter = new SqlParameter();
            report2ScheduleEmailIDParameter.ParameterName = "@Report2ScheduleEmailID";
            report2ScheduleEmailIDParameter.DbType = DbType.Guid;
            report2ScheduleEmailIDParameter.Direction = System.Data.ParameterDirection.Input;
            report2ScheduleEmailIDParameter.Value = report2ScheduleEmailID;
            parameters.Add(report2ScheduleEmailIDParameter);
            var reportIDParameter = new SqlParameter();
            reportIDParameter.ParameterName = "@ReportID";
            reportIDParameter.DbType = DbType.Guid;
            reportIDParameter.Direction = System.Data.ParameterDirection.Input;
            reportIDParameter.Value = reportID;
            parameters.Add(reportIDParameter);
            var dateRangeParameter = new SqlParameter();
            dateRangeParameter.ParameterName = "@DateRange";
            dateRangeParameter.DbType = DbType.String;
            dateRangeParameter.Direction = System.Data.ParameterDirection.Input;
            dateRangeParameter.Size = 100;
            dateRangeParameter.Value = dateRange;
            parameters.Add(dateRangeParameter);
            var timeParameter = new SqlParameter();
            timeParameter.ParameterName = "@Time";
            timeParameter.DbType = DbType.DateTime;
            timeParameter.Direction = System.Data.ParameterDirection.Input;
            timeParameter.Value = time;
            parameters.Add(timeParameter);
            var frequencyParameter = new SqlParameter();
            frequencyParameter.ParameterName = "@Frequency";
            frequencyParameter.DbType = DbType.String;
            frequencyParameter.Direction = System.Data.ParameterDirection.Input;
            frequencyParameter.Size = 100;
            frequencyParameter.Value = frequency;
            parameters.Add(frequencyParameter);
            var report2ScheduleEmailJSONParameter = new SqlParameter();
            report2ScheduleEmailJSONParameter.ParameterName = "@Report2ScheduleEmailJSON";
            report2ScheduleEmailJSONParameter.DbType = DbType.String;
            report2ScheduleEmailJSONParameter.Direction = System.Data.ParameterDirection.Input;
            report2ScheduleEmailJSONParameter.Value = report2ScheduleEmailJSON;
            parameters.Add(report2ScheduleEmailJSONParameter);
            var statusParameter = new SqlParameter();
            statusParameter.ParameterName = "@Status";
            statusParameter.DbType = DbType.String;
            statusParameter.Direction = System.Data.ParameterDirection.Input;
            statusParameter.Size = 20;
            statusParameter.Value = status;
            parameters.Add(statusParameter);
            var auditInfoGuidParameter = new SqlParameter();
            auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
            auditInfoGuidParameter.DbType = DbType.Guid;
            auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
            auditInfoGuidParameter.Value = auditInfoGuid;
            parameters.Add(auditInfoGuidParameter);
            var lastUpdateUTCDTParameter = new SqlParameter();
            lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
            lastUpdateUTCDTParameter.DbType = DbType.DateTime;
            lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
            lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
            parameters.Add(lastUpdateUTCDTParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Report2ScheduleEmail_Add", parameters);
        }
        public IEnumerable<Report2ScheduleEmail_GetByIDResult> Report2ScheduleEmail_GetByID(Guid report2ScheduleEmailID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var report2ScheduleEmailIDParameter = new SqlParameter();
            report2ScheduleEmailIDParameter.ParameterName = "@Report2ScheduleEmailID";
            report2ScheduleEmailIDParameter.DbType = DbType.Guid;
            report2ScheduleEmailIDParameter.Direction = System.Data.ParameterDirection.Input;
            report2ScheduleEmailIDParameter.Value = report2ScheduleEmailID;
            parameters.Add(report2ScheduleEmailIDParameter);
            return ExecuteQuery<Report2ScheduleEmail_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Report2ScheduleEmail_GetByID", parameters);
        }
        public IEnumerable<Report2ScheduleEmail_GetAllResult> Report2ScheduleEmail_GetAll()
        {
            return ExecuteQuery<Report2ScheduleEmail_GetAllResult>.ExecuteStoredProcedure(this, "CDM.Report2ScheduleEmail_GetAll");
        }
        public Int32 Report2ScheduleEmail_Remove(Guid report2ScheduleEmailID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var report2ScheduleEmailIDParameter = new SqlParameter();
            report2ScheduleEmailIDParameter.ParameterName = "@Report2ScheduleEmailID";
            report2ScheduleEmailIDParameter.DbType = DbType.Guid;
            report2ScheduleEmailIDParameter.Direction = System.Data.ParameterDirection.Input;
            report2ScheduleEmailIDParameter.Value = report2ScheduleEmailID;
            parameters.Add(report2ScheduleEmailIDParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Report2ScheduleEmail_Remove", parameters);
        }
        public Int32 Report2ScheduleEmail_Upd(Guid report2ScheduleEmailID, Guid reportID, String dateRange, DateTime time, String frequency, String report2ScheduleEmailJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var report2ScheduleEmailIDParameter = new SqlParameter();
            report2ScheduleEmailIDParameter.ParameterName = "@Report2ScheduleEmailID";
            report2ScheduleEmailIDParameter.DbType = DbType.Guid;
            report2ScheduleEmailIDParameter.Direction = System.Data.ParameterDirection.Input;
            report2ScheduleEmailIDParameter.Value = report2ScheduleEmailID;
            parameters.Add(report2ScheduleEmailIDParameter);
            var reportIDParameter = new SqlParameter();
            reportIDParameter.ParameterName = "@ReportID";
            reportIDParameter.DbType = DbType.Guid;
            reportIDParameter.Direction = System.Data.ParameterDirection.Input;
            reportIDParameter.Value = reportID;
            parameters.Add(reportIDParameter);
            var dateRangeParameter = new SqlParameter();
            dateRangeParameter.ParameterName = "@DateRange";
            dateRangeParameter.DbType = DbType.String;
            dateRangeParameter.Direction = System.Data.ParameterDirection.Input;
            dateRangeParameter.Size = 100;
            dateRangeParameter.Value = dateRange;
            parameters.Add(dateRangeParameter);
            var timeParameter = new SqlParameter();
            timeParameter.ParameterName = "@Time";
            timeParameter.DbType = DbType.DateTime;
            timeParameter.Direction = System.Data.ParameterDirection.Input;
            timeParameter.Value = time;
            parameters.Add(timeParameter);
            var frequencyParameter = new SqlParameter();
            frequencyParameter.ParameterName = "@Frequency";
            frequencyParameter.DbType = DbType.String;
            frequencyParameter.Direction = System.Data.ParameterDirection.Input;
            frequencyParameter.Size = 100;
            frequencyParameter.Value = frequency;
            parameters.Add(frequencyParameter);
            var report2ScheduleEmailJSONParameter = new SqlParameter();
            report2ScheduleEmailJSONParameter.ParameterName = "@Report2ScheduleEmailJSON";
            report2ScheduleEmailJSONParameter.DbType = DbType.String;
            report2ScheduleEmailJSONParameter.Direction = System.Data.ParameterDirection.Input;
            report2ScheduleEmailJSONParameter.Value = report2ScheduleEmailJSON;
            parameters.Add(report2ScheduleEmailJSONParameter);
            var statusParameter = new SqlParameter();
            statusParameter.ParameterName = "@Status";
            statusParameter.DbType = DbType.String;
            statusParameter.Direction = System.Data.ParameterDirection.Input;
            statusParameter.Size = 20;
            statusParameter.Value = status;
            parameters.Add(statusParameter);
            var auditInfoGuidParameter = new SqlParameter();
            auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
            auditInfoGuidParameter.DbType = DbType.Guid;
            auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
            auditInfoGuidParameter.Value = auditInfoGuid;
            parameters.Add(auditInfoGuidParameter);
            var lastUpdateUTCDTParameter = new SqlParameter();
            lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
            lastUpdateUTCDTParameter.DbType = DbType.DateTime;
            lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
            lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
            parameters.Add(lastUpdateUTCDTParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Report2ScheduleEmail_Upd", parameters);
        }
        public Int32 Report2ScheduleEmail_Void(Guid report2ScheduleEmailID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var report2ScheduleEmailIDParameter = new SqlParameter();
            report2ScheduleEmailIDParameter.ParameterName = "@Report2ScheduleEmailID";
            report2ScheduleEmailIDParameter.DbType = DbType.Guid;
            report2ScheduleEmailIDParameter.Direction = System.Data.ParameterDirection.Input;
            report2ScheduleEmailIDParameter.Value = report2ScheduleEmailID;
            parameters.Add(report2ScheduleEmailIDParameter);
            return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Report2ScheduleEmail_Void", parameters);
        }
        public Int32 SignalRLog_Add(Guid signalRLogID,DateTime logDate,String callType,Guid deviceID,String auditInfoJSON,String callInfo,String signalRLogJSON,String status)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			var signalRLogIDParameter = new SqlParameter();
			signalRLogIDParameter.ParameterName = "@SignalRLogID";
			signalRLogIDParameter.DbType = DbType.Guid;
			signalRLogIDParameter.Direction = System.Data.ParameterDirection.Input;
			signalRLogIDParameter.Value = signalRLogID; 
			parameters.Add(signalRLogIDParameter); 
			var logDateParameter = new SqlParameter();
			logDateParameter.ParameterName = "@LogDate";
			logDateParameter.DbType = DbType.DateTime;
			logDateParameter.Direction = System.Data.ParameterDirection.Input;
			logDateParameter.Value = logDate; 
			parameters.Add(logDateParameter); 
			var callTypeParameter = new SqlParameter();
			callTypeParameter.ParameterName = "@CallType";
			callTypeParameter.DbType = DbType.String;
			callTypeParameter.Direction = System.Data.ParameterDirection.Input;
			callTypeParameter.Size = 20;
			callTypeParameter.Value = callType; 
			parameters.Add(callTypeParameter); 
			var deviceIDParameter = new SqlParameter();
			deviceIDParameter.ParameterName = "@DeviceID";
			deviceIDParameter.DbType = DbType.Guid;
			deviceIDParameter.Direction = System.Data.ParameterDirection.Input;
			deviceIDParameter.Value = deviceID; 
			parameters.Add(deviceIDParameter); 
			var auditInfoJSONParameter = new SqlParameter();
			auditInfoJSONParameter.ParameterName = "@AuditInfoJSON";
			auditInfoJSONParameter.DbType = DbType.String;
			auditInfoJSONParameter.Direction = System.Data.ParameterDirection.Input;
			auditInfoJSONParameter.Value = auditInfoJSON; 
			parameters.Add(auditInfoJSONParameter); 
			var callInfoParameter = new SqlParameter();
			callInfoParameter.ParameterName = "@CallInfo";
			callInfoParameter.DbType = DbType.String;
			callInfoParameter.Direction = System.Data.ParameterDirection.Input;
			callInfoParameter.Value = callInfo; 
			parameters.Add(callInfoParameter); 
			var signalRLogJSONParameter = new SqlParameter();
			signalRLogJSONParameter.ParameterName = "@SignalRLogJSON";
			signalRLogJSONParameter.DbType = DbType.String;
			signalRLogJSONParameter.Direction = System.Data.ParameterDirection.Input;
			signalRLogJSONParameter.Value = signalRLogJSON; 
			parameters.Add(signalRLogJSONParameter); 
			var statusParameter = new SqlParameter();
			statusParameter.ParameterName = "@Status";
			statusParameter.DbType = DbType.String;
			statusParameter.Direction = System.Data.ParameterDirection.Input;
			statusParameter.Size = 20;
			statusParameter.Value = status; 
			parameters.Add(statusParameter); 
			return ExecuteNonQuery.ExecuteStoredProcedure(this,"CDM.SignalRLog_Add",  parameters);
		}
		public Int32 SignalRLog_Void(Guid signalRLogID)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			var signalRLogIDParameter = new SqlParameter();
			signalRLogIDParameter.ParameterName = "@SignalRLogID";
			signalRLogIDParameter.DbType = DbType.Guid;
			signalRLogIDParameter.Direction = System.Data.ParameterDirection.Input;
			signalRLogIDParameter.Value = signalRLogID; 
			parameters.Add(signalRLogIDParameter); 
			return ExecuteNonQuery.ExecuteStoredProcedure(this,"CDM.SignalRLog_Void",  parameters);
		}
		public IEnumerable<SignalRLog_GetAllResult> SignalRLog_GetAll( )
		{
			return ExecuteQuery<SignalRLog_GetAllResult>.ExecuteStoredProcedure(this,"CDM.SignalRLog_GetAll");
		}
		public IEnumerable<SignalRLog_GetByIDResult> SignalRLog_GetByID(Guid signalRLogID)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			var signalRLogIDParameter = new SqlParameter();
			signalRLogIDParameter.ParameterName = "@SignalRLogID";
			signalRLogIDParameter.DbType = DbType.Guid;
			signalRLogIDParameter.Direction = System.Data.ParameterDirection.Input;
			signalRLogIDParameter.Value = signalRLogID; 
			parameters.Add(signalRLogIDParameter); 
			return ExecuteQuery<SignalRLog_GetByIDResult>.ExecuteStoredProcedure(this,"CDM.SignalRLog_GetByID",  parameters);
		}
		public IEnumerable<SignalRLog_GetByTypeResult> SignalRLog_GetByType(String callType)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			var callTypeParameter = new SqlParameter();
			callTypeParameter.ParameterName = "@CallType";
			callTypeParameter.DbType = DbType.String;
			callTypeParameter.Direction = System.Data.ParameterDirection.Input;
			callTypeParameter.Size = 20;
			callTypeParameter.Value = callType; 
			parameters.Add(callTypeParameter); 
			return ExecuteQuery<SignalRLog_GetByTypeResult>.ExecuteStoredProcedure(this,"CDM.SignalRLog_GetByType",  parameters);
		}
		public Int32 SignalRLog_Remove(Guid signalRLogID)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			var signalRLogIDParameter = new SqlParameter();
			signalRLogIDParameter.ParameterName = "@SignalRLogID";
			signalRLogIDParameter.DbType = DbType.Guid;
			signalRLogIDParameter.Direction = System.Data.ParameterDirection.Input;
			signalRLogIDParameter.Value = signalRLogID; 
			parameters.Add(signalRLogIDParameter); 
			return ExecuteNonQuery.ExecuteStoredProcedure(this,"CDM.SignalRLog_Remove",  parameters);
		}
		public Int32 SignalRLog_Upd(Guid signalRLogID,DateTime logDate,String callType,Guid deviceID,String auditInfoJSON,String callInfo,String signalRLogJSON,String status)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			var signalRLogIDParameter = new SqlParameter();
			signalRLogIDParameter.ParameterName = "@SignalRLogID";
			signalRLogIDParameter.DbType = DbType.Guid;
			signalRLogIDParameter.Direction = System.Data.ParameterDirection.Input;
			signalRLogIDParameter.Value = signalRLogID; 
			parameters.Add(signalRLogIDParameter); 
			var logDateParameter = new SqlParameter();
			logDateParameter.ParameterName = "@LogDate";
			logDateParameter.DbType = DbType.DateTime;
			logDateParameter.Direction = System.Data.ParameterDirection.Input;
			logDateParameter.Value = logDate; 
			parameters.Add(logDateParameter); 
			var callTypeParameter = new SqlParameter();
			callTypeParameter.ParameterName = "@CallType";
			callTypeParameter.DbType = DbType.String;
			callTypeParameter.Direction = System.Data.ParameterDirection.Input;
			callTypeParameter.Size = 20;
			callTypeParameter.Value = callType; 
			parameters.Add(callTypeParameter); 
			var deviceIDParameter = new SqlParameter();
			deviceIDParameter.ParameterName = "@DeviceID";
			deviceIDParameter.DbType = DbType.Guid;
			deviceIDParameter.Direction = System.Data.ParameterDirection.Input;
			deviceIDParameter.Value = deviceID; 
			parameters.Add(deviceIDParameter); 
			var auditInfoJSONParameter = new SqlParameter();
			auditInfoJSONParameter.ParameterName = "@AuditInfoJSON";
			auditInfoJSONParameter.DbType = DbType.String;
			auditInfoJSONParameter.Direction = System.Data.ParameterDirection.Input;
			auditInfoJSONParameter.Value = auditInfoJSON; 
			parameters.Add(auditInfoJSONParameter); 
			var callInfoParameter = new SqlParameter();
			callInfoParameter.ParameterName = "@CallInfo";
			callInfoParameter.DbType = DbType.String;
			callInfoParameter.Direction = System.Data.ParameterDirection.Input;
			callInfoParameter.Value = callInfo; 
			parameters.Add(callInfoParameter); 
			var signalRLogJSONParameter = new SqlParameter();
			signalRLogJSONParameter.ParameterName = "@SignalRLogJSON";
			signalRLogJSONParameter.DbType = DbType.String;
			signalRLogJSONParameter.Direction = System.Data.ParameterDirection.Input;
			signalRLogJSONParameter.Value = signalRLogJSON; 
			parameters.Add(signalRLogJSONParameter); 
			var statusParameter = new SqlParameter();
			statusParameter.ParameterName = "@Status";
			statusParameter.DbType = DbType.String;
			statusParameter.Direction = System.Data.ParameterDirection.Input;
			statusParameter.Size = 20;
			statusParameter.Value = status; 
			parameters.Add(statusParameter); 
			return ExecuteNonQuery.ExecuteStoredProcedure(this,"CDM.SignalRLog_Upd",  parameters);
		}

    public Int32 DataSyncInfo_Add(Guid dataSyncInfoID, String dataSyncInfoJSON, String auditInfoJson, String companyID, String dataSyncInfoType, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var dataSyncInfoIDParameter = new SqlParameter();
      dataSyncInfoIDParameter.ParameterName = "@DataSyncInfoID";
      dataSyncInfoIDParameter.DbType = DbType.Guid;
      dataSyncInfoIDParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfoIDParameter.Value = dataSyncInfoID;
      parameters.Add(dataSyncInfoIDParameter);
      var dataSyncInfoJSONParameter = new SqlParameter();
      dataSyncInfoJSONParameter.ParameterName = "@DataSyncInfoJSON";
      dataSyncInfoJSONParameter.DbType = DbType.String;
      dataSyncInfoJSONParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfoJSONParameter.Value = dataSyncInfoJSON;
      parameters.Add(dataSyncInfoJSONParameter);
      var auditInfoJsonParameter = new SqlParameter();
      auditInfoJsonParameter.ParameterName = "@AuditInfoJson";
      auditInfoJsonParameter.DbType = DbType.String;
      auditInfoJsonParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoJsonParameter.Value = auditInfoJson;
      parameters.Add(auditInfoJsonParameter);
      var companyIDParameter = new SqlParameter();
      companyIDParameter.ParameterName = "@CompanyID";
      companyIDParameter.DbType = DbType.String;
      companyIDParameter.Direction = System.Data.ParameterDirection.Input;
      companyIDParameter.Size = 20;
      companyIDParameter.Value = companyID;
      parameters.Add(companyIDParameter);
      var dataSyncInfoTypeParameter = new SqlParameter();
      dataSyncInfoTypeParameter.ParameterName = "@DataSyncInfoType";
      dataSyncInfoTypeParameter.DbType = DbType.String;
      dataSyncInfoTypeParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfoTypeParameter.Size = 20;
      dataSyncInfoTypeParameter.Value = dataSyncInfoType;
      parameters.Add(dataSyncInfoTypeParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.DataSyncInfo_Add", parameters);
    }
    public Int32 DataSyncInfo2Device_Upd(Guid dataSyncInfo2DeviceID, String dataSyncInfo2DeviceJSON, String auditInfoJson, String deviceID, String dataSyncInfo2DeviceType, String recordCount, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var dataSyncInfo2DeviceIDParameter = new SqlParameter();
      dataSyncInfo2DeviceIDParameter.ParameterName = "@DataSyncInfo2DeviceID";
      dataSyncInfo2DeviceIDParameter.DbType = DbType.Guid;
      dataSyncInfo2DeviceIDParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfo2DeviceIDParameter.Value = dataSyncInfo2DeviceID;
      parameters.Add(dataSyncInfo2DeviceIDParameter);
      var dataSyncInfo2DeviceJSONParameter = new SqlParameter();
      dataSyncInfo2DeviceJSONParameter.ParameterName = "@DataSyncInfo2DeviceJSON";
      dataSyncInfo2DeviceJSONParameter.DbType = DbType.String;
      dataSyncInfo2DeviceJSONParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfo2DeviceJSONParameter.Value = dataSyncInfo2DeviceJSON;
      parameters.Add(dataSyncInfo2DeviceJSONParameter);
      var auditInfoJsonParameter = new SqlParameter();
      auditInfoJsonParameter.ParameterName = "@AuditInfoJson";
      auditInfoJsonParameter.DbType = DbType.String;
      auditInfoJsonParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoJsonParameter.Value = auditInfoJson;
      parameters.Add(auditInfoJsonParameter);
      var deviceIDParameter = new SqlParameter();
      deviceIDParameter.ParameterName = "@DeviceID";
      deviceIDParameter.DbType = DbType.String;
      deviceIDParameter.Direction = System.Data.ParameterDirection.Input;
      deviceIDParameter.Size = 40;
      deviceIDParameter.Value = deviceID;
      parameters.Add(deviceIDParameter);
      var dataSyncInfo2DeviceTypeParameter = new SqlParameter();
      dataSyncInfo2DeviceTypeParameter.ParameterName = "@DataSyncInfo2DeviceType";
      dataSyncInfo2DeviceTypeParameter.DbType = DbType.String;
      dataSyncInfo2DeviceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfo2DeviceTypeParameter.Size = 20;
      dataSyncInfo2DeviceTypeParameter.Value = dataSyncInfo2DeviceType;
      parameters.Add(dataSyncInfo2DeviceTypeParameter);
      var recordCountParameter = new SqlParameter();
      recordCountParameter.ParameterName = "@RecordCount";
      recordCountParameter.DbType = DbType.String;
      recordCountParameter.Direction = System.Data.ParameterDirection.Input;
      recordCountParameter.Size = 20;
      recordCountParameter.Value = recordCount;
      parameters.Add(recordCountParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.DataSyncInfo2Device_Upd", parameters);
    }
    public IEnumerable<DataSyncInfo_GetAllResult> DataSyncInfo_GetAll()
    {
      return ExecuteQuery<DataSyncInfo_GetAllResult>.ExecuteStoredProcedure(this, "CDM.DataSyncInfo_GetAll");
    }
    public IEnumerable<DataSyncInfo_GetByIDResult> DataSyncInfo_GetByID(Guid dataSyncInfoID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var dataSyncInfoIDParameter = new SqlParameter();
      dataSyncInfoIDParameter.ParameterName = "@DataSyncInfoID";
      dataSyncInfoIDParameter.DbType = DbType.Guid;
      dataSyncInfoIDParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfoIDParameter.Value = dataSyncInfoID;
      parameters.Add(dataSyncInfoIDParameter);
      return ExecuteQuery<DataSyncInfo_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.DataSyncInfo_GetByID", parameters);
    }
    public Int32 DataSyncInfo_Upd(Guid dataSyncInfoID, String dataSyncInfoJSON, String auditInfoJson, String companyID, String dataSyncInfoType, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var dataSyncInfoIDParameter = new SqlParameter();
      dataSyncInfoIDParameter.ParameterName = "@DataSyncInfoID";
      dataSyncInfoIDParameter.DbType = DbType.Guid;
      dataSyncInfoIDParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfoIDParameter.Value = dataSyncInfoID;
      parameters.Add(dataSyncInfoIDParameter);
      var dataSyncInfoJSONParameter = new SqlParameter();
      dataSyncInfoJSONParameter.ParameterName = "@DataSyncInfoJSON";
      dataSyncInfoJSONParameter.DbType = DbType.String;
      dataSyncInfoJSONParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfoJSONParameter.Value = dataSyncInfoJSON;
      parameters.Add(dataSyncInfoJSONParameter);
      var auditInfoJsonParameter = new SqlParameter();
      auditInfoJsonParameter.ParameterName = "@AuditInfoJson";
      auditInfoJsonParameter.DbType = DbType.String;
      auditInfoJsonParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoJsonParameter.Value = auditInfoJson;
      parameters.Add(auditInfoJsonParameter);
      var companyIDParameter = new SqlParameter();
      companyIDParameter.ParameterName = "@CompanyID";
      companyIDParameter.DbType = DbType.String;
      companyIDParameter.Direction = System.Data.ParameterDirection.Input;
      companyIDParameter.Size = 20;
      companyIDParameter.Value = companyID;
      parameters.Add(companyIDParameter);
      var dataSyncInfoTypeParameter = new SqlParameter();
      dataSyncInfoTypeParameter.ParameterName = "@DataSyncInfoType";
      dataSyncInfoTypeParameter.DbType = DbType.String;
      dataSyncInfoTypeParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfoTypeParameter.Size = 20;
      dataSyncInfoTypeParameter.Value = dataSyncInfoType;
      parameters.Add(dataSyncInfoTypeParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.DataSyncInfo_Upd", parameters);
    }
    public Int32 DataSyncInfo2Device_Add(Guid dataSyncInfo2DeviceID, String dataSyncInfo2DeviceJSON, String auditInfoJson, String deviceID, String dataSyncInfo2DeviceType, String recordCount, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var dataSyncInfo2DeviceIDParameter = new SqlParameter();
      dataSyncInfo2DeviceIDParameter.ParameterName = "@DataSyncInfo2DeviceID";
      dataSyncInfo2DeviceIDParameter.DbType = DbType.Guid;
      dataSyncInfo2DeviceIDParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfo2DeviceIDParameter.Value = dataSyncInfo2DeviceID;
      parameters.Add(dataSyncInfo2DeviceIDParameter);
      var dataSyncInfo2DeviceJSONParameter = new SqlParameter();
      dataSyncInfo2DeviceJSONParameter.ParameterName = "@DataSyncInfo2DeviceJSON";
      dataSyncInfo2DeviceJSONParameter.DbType = DbType.String;
      dataSyncInfo2DeviceJSONParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfo2DeviceJSONParameter.Value = dataSyncInfo2DeviceJSON;
      parameters.Add(dataSyncInfo2DeviceJSONParameter);
      var auditInfoJsonParameter = new SqlParameter();
      auditInfoJsonParameter.ParameterName = "@AuditInfoJson";
      auditInfoJsonParameter.DbType = DbType.String;
      auditInfoJsonParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoJsonParameter.Value = auditInfoJson;
      parameters.Add(auditInfoJsonParameter);
      var deviceIDParameter = new SqlParameter();
      deviceIDParameter.ParameterName = "@DeviceID";
      deviceIDParameter.DbType = DbType.String;
      deviceIDParameter.Direction = System.Data.ParameterDirection.Input;
      deviceIDParameter.Size = 40;
      deviceIDParameter.Value = deviceID;
      parameters.Add(deviceIDParameter);
      var dataSyncInfo2DeviceTypeParameter = new SqlParameter();
      dataSyncInfo2DeviceTypeParameter.ParameterName = "@DataSyncInfo2DeviceType";
      dataSyncInfo2DeviceTypeParameter.DbType = DbType.String;
      dataSyncInfo2DeviceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfo2DeviceTypeParameter.Size = 100;
      dataSyncInfo2DeviceTypeParameter.Value = dataSyncInfo2DeviceType;
      parameters.Add(dataSyncInfo2DeviceTypeParameter);
      var recordCountParameter = new SqlParameter();
      recordCountParameter.ParameterName = "@RecordCount";
      recordCountParameter.DbType = DbType.String;
      recordCountParameter.Direction = System.Data.ParameterDirection.Input;
      recordCountParameter.Size = 20;
      recordCountParameter.Value = recordCount;
      parameters.Add(recordCountParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.DataSyncInfo2Device_Add", parameters);
    }
    public IEnumerable<DataSyncInfo2Device_GetAllResult> DataSyncInfo2Device_GetAll()
    {
      return ExecuteQuery<DataSyncInfo2Device_GetAllResult>.ExecuteStoredProcedure(this, "CDM.DataSyncInfo2Device_GetAll");
    }
    public IEnumerable<DataSyncInfo2Device_GetByIDResult> DataSyncInfo2Device_GetByID(Guid dataSyncInfo2DeviceID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var dataSyncInfo2DeviceIDParameter = new SqlParameter();
      dataSyncInfo2DeviceIDParameter.ParameterName = "@DataSyncInfo2DeviceID";
      dataSyncInfo2DeviceIDParameter.DbType = DbType.Guid;
      dataSyncInfo2DeviceIDParameter.Direction = System.Data.ParameterDirection.Input;
      dataSyncInfo2DeviceIDParameter.Value = dataSyncInfo2DeviceID;
      parameters.Add(dataSyncInfo2DeviceIDParameter);
      return ExecuteQuery<DataSyncInfo2Device_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.DataSyncInfo2Device_GetByID", parameters);
    }
    public IEnumerable<RoutineHeader_GetResult> RoutineHeader_GetAll()
    {
      return ExecuteQuery<RoutineHeader_GetResult>.ExecuteStoredProcedure(this, "CDM.RoutineHeader_GetAll");
    }
    public Int32 RoutineHeader_Upd(Guid routineHeaderID, DateTime routineDate, String refType, String refID, String remark, Guid auditInfoGuid, String availStatusID, String routineHeaderJSON, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineHeaderIDParameter = new SqlParameter();
      routineHeaderIDParameter.ParameterName = "@RoutineHeaderID";
      routineHeaderIDParameter.DbType = DbType.Guid;
      routineHeaderIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderIDParameter.Value = routineHeaderID;
      parameters.Add(routineHeaderIDParameter);
      var routineDateParameter = new SqlParameter();
      routineDateParameter.ParameterName = "@RoutineDate";
      routineDateParameter.DbType = DbType.DateTime;
      routineDateParameter.Direction = System.Data.ParameterDirection.Input;
      routineDateParameter.Value = routineDate;
      parameters.Add(routineDateParameter);
      var refTypeParameter = new SqlParameter();
      refTypeParameter.ParameterName = "@RefType";
      refTypeParameter.DbType = DbType.String;
      refTypeParameter.Direction = System.Data.ParameterDirection.Input;
      refTypeParameter.Size = 20;
      refTypeParameter.Value = refType;
      parameters.Add(refTypeParameter);
      var refIDParameter = new SqlParameter();
      refIDParameter.ParameterName = "@RefID";
      refIDParameter.DbType = DbType.String;
      refIDParameter.Direction = System.Data.ParameterDirection.Input;
      refIDParameter.Size = 50;
      refIDParameter.Value = refID;
      parameters.Add(refIDParameter);
      var remarkParameter = new SqlParameter();
      remarkParameter.ParameterName = "@Remark";
      remarkParameter.DbType = DbType.String;
      remarkParameter.Direction = System.Data.ParameterDirection.Input;
      remarkParameter.Size = 20;
      remarkParameter.Value = remark;
      parameters.Add(remarkParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var availStatusIDParameter = new SqlParameter();
      availStatusIDParameter.ParameterName = "@AvailStatusID";
      availStatusIDParameter.DbType = DbType.String;
      availStatusIDParameter.Direction = System.Data.ParameterDirection.Input;
      availStatusIDParameter.Size = 20;
      availStatusIDParameter.Value = availStatusID;
      parameters.Add(availStatusIDParameter);
      var routineHeaderJSONParameter = new SqlParameter();
      routineHeaderJSONParameter.ParameterName = "@RoutineHeaderJSON";
      routineHeaderJSONParameter.DbType = DbType.String;
      routineHeaderJSONParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderJSONParameter.Value = routineHeaderJSON;
      parameters.Add(routineHeaderJSONParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RoutineHeader_Upd", parameters);
    }
    public Int32 RoutineDetail_Add(Guid routineDetailID, Guid routineHeaderID, String activityID, String taskID, String frequency, String className, String interfaceName, Guid auditInfoGuid, string availStatusID, String routineDetailJSON, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineDetailIDParameter = new SqlParameter();
      routineDetailIDParameter.ParameterName = "@RoutineDetailID";
      routineDetailIDParameter.DbType = DbType.Guid;
      routineDetailIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineDetailIDParameter.Value = routineDetailID;
      parameters.Add(routineDetailIDParameter);
      var routineHeaderIDParameter = new SqlParameter();
      routineHeaderIDParameter.ParameterName = "@RoutineHeaderID";
      routineHeaderIDParameter.DbType = DbType.Guid;
      routineHeaderIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderIDParameter.Value = routineHeaderID;
      parameters.Add(routineHeaderIDParameter);
      var activityIDParameter = new SqlParameter();
      activityIDParameter.ParameterName = "@ActivityID";
      activityIDParameter.DbType = DbType.String;
      activityIDParameter.Direction = System.Data.ParameterDirection.Input;
      activityIDParameter.Size = 30;
      activityIDParameter.Value = activityID;
      parameters.Add(activityIDParameter);
      var taskIDParameter = new SqlParameter();
      taskIDParameter.ParameterName = "@TaskID";
      taskIDParameter.DbType = DbType.String;
      taskIDParameter.Direction = System.Data.ParameterDirection.Input;
      taskIDParameter.Size = 50;
      taskIDParameter.Value = taskID;
      parameters.Add(taskIDParameter);
      var frequencyParameter = new SqlParameter();
      frequencyParameter.ParameterName = "@Frequency";
      frequencyParameter.DbType = DbType.String;
      frequencyParameter.Direction = System.Data.ParameterDirection.Input;
      frequencyParameter.Size = 30;
      frequencyParameter.Value = frequency;
      parameters.Add(frequencyParameter);
      var classNameParameter = new SqlParameter();
      classNameParameter.ParameterName = "@ClassName";
      classNameParameter.DbType = DbType.String;
      classNameParameter.Direction = System.Data.ParameterDirection.Input;
      classNameParameter.Size = 30;
      classNameParameter.Value = className;
      parameters.Add(classNameParameter);
      var interfaceNameParameter = new SqlParameter();
      interfaceNameParameter.ParameterName = "@InterfaceName";
      interfaceNameParameter.DbType = DbType.String;
      interfaceNameParameter.Direction = System.Data.ParameterDirection.Input;
      interfaceNameParameter.Size = 30;
      interfaceNameParameter.Value = interfaceName;
      parameters.Add(interfaceNameParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var availStatusIDParameter = new SqlParameter();
      availStatusIDParameter.ParameterName = "@AvailStatusID";
      availStatusIDParameter.DbType = DbType.String;
      availStatusIDParameter.Direction = System.Data.ParameterDirection.Input;
      availStatusIDParameter.Size = 30;
      availStatusIDParameter.Value = availStatusID;
      parameters.Add(availStatusIDParameter);
      var routineDetailJSONParameter = new SqlParameter();
      routineDetailJSONParameter.ParameterName = "@RoutineDetailJSON";
      routineDetailJSONParameter.DbType = DbType.String;
      routineDetailJSONParameter.Direction = System.Data.ParameterDirection.Input;
      routineDetailJSONParameter.Value = routineDetailJSON;
      parameters.Add(routineDetailJSONParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RoutineDetail_Add", parameters);
    }
    public Int32 RoutineDetail_Del(Guid routineDetailID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineDetailIDParameter = new SqlParameter();
      routineDetailIDParameter.ParameterName = "@RoutineDetailID";
      routineDetailIDParameter.DbType = DbType.Guid;
      routineDetailIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineDetailIDParameter.Value = routineDetailID;
      parameters.Add(routineDetailIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RoutineDetail_Del", parameters);
    }
    public IEnumerable<RoutineDetail_GetResult> RoutineDetail_Get(Guid routineDetailID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineDetailIDParameter = new SqlParameter();
      routineDetailIDParameter.ParameterName = "@RoutineDetailID";
      routineDetailIDParameter.DbType = DbType.Guid;
      routineDetailIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineDetailIDParameter.Value = routineDetailID;
      parameters.Add(routineDetailIDParameter);
      return ExecuteQuery<RoutineDetail_GetResult>.ExecuteStoredProcedure(this, "CDM.RoutineDetail_Get", parameters);
    }
    public IEnumerable<RoutineDetail_GetByRoutineHeaderIDResult> RoutineDetail_GetByRoutineHeaderID(Guid routineHeaderID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineHeaderIDParameter = new SqlParameter();
      routineHeaderIDParameter.ParameterName = "@RoutineHeaderID";
      routineHeaderIDParameter.DbType = DbType.Guid;
      routineHeaderIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderIDParameter.Value = routineHeaderID;
      parameters.Add(routineHeaderIDParameter);
      return ExecuteQuery<RoutineDetail_GetByRoutineHeaderIDResult>.ExecuteStoredProcedure(this, "CDM.RoutineDetail_GetByRoutineHeaderID", parameters);
    }
    public Int32 RoutineDetail_Upd(Guid routineDetailID, Guid routineHeaderID, String activityID, String taskID, String frequency, String className, String interfaceName, Guid auditInfoGuid, String availStatusID, String routineDetailJSON, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineDetailIDParameter = new SqlParameter();
      routineDetailIDParameter.ParameterName = "@RoutineDetailID";
      routineDetailIDParameter.DbType = DbType.Guid;
      routineDetailIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineDetailIDParameter.Value = routineDetailID;
      parameters.Add(routineDetailIDParameter);
      var routineHeaderIDParameter = new SqlParameter();
      routineHeaderIDParameter.ParameterName = "@RoutineHeaderID";
      routineHeaderIDParameter.DbType = DbType.Guid;
      routineHeaderIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderIDParameter.Value = routineHeaderID;
      parameters.Add(routineHeaderIDParameter);
      var activityIDParameter = new SqlParameter();
      activityIDParameter.ParameterName = "@ActivityID";
      activityIDParameter.DbType = DbType.String;
      activityIDParameter.Direction = System.Data.ParameterDirection.Input;
      activityIDParameter.Size = 30;
      activityIDParameter.Value = activityID;
      parameters.Add(activityIDParameter);
      var taskIDParameter = new SqlParameter();
      taskIDParameter.ParameterName = "@TaskID";
      taskIDParameter.DbType = DbType.String;
      taskIDParameter.Direction = System.Data.ParameterDirection.Input;
      taskIDParameter.Size = 50;
      taskIDParameter.Value = taskID;
      parameters.Add(taskIDParameter);
      var frequencyParameter = new SqlParameter();
      frequencyParameter.ParameterName = "@Frequency";
      frequencyParameter.DbType = DbType.String;
      frequencyParameter.Direction = System.Data.ParameterDirection.Input;
      frequencyParameter.Size = 30;
      frequencyParameter.Value = frequency;
      parameters.Add(frequencyParameter);
      var classNameParameter = new SqlParameter();
      classNameParameter.ParameterName = "@ClassName";
      classNameParameter.DbType = DbType.String;
      classNameParameter.Direction = System.Data.ParameterDirection.Input;
      classNameParameter.Size = 30;
      classNameParameter.Value = className;
      parameters.Add(classNameParameter);
      var interfaceNameParameter = new SqlParameter();
      interfaceNameParameter.ParameterName = "@InterfaceName";
      interfaceNameParameter.DbType = DbType.String;
      interfaceNameParameter.Direction = System.Data.ParameterDirection.Input;
      interfaceNameParameter.Size = 30;
      interfaceNameParameter.Value = interfaceName;
      parameters.Add(interfaceNameParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var availStatusIDParameter = new SqlParameter();
      availStatusIDParameter.ParameterName = "@AvailStatusID";
      availStatusIDParameter.DbType = DbType.String;
      availStatusIDParameter.Direction = System.Data.ParameterDirection.Input;
      availStatusIDParameter.Size = 30;
      availStatusIDParameter.Value = availStatusID;
      parameters.Add(availStatusIDParameter);
      var routineDetailJSONParameter = new SqlParameter();
      routineDetailJSONParameter.ParameterName = "@RoutineDetailJSON";
      routineDetailJSONParameter.DbType = DbType.String;
      routineDetailJSONParameter.Direction = System.Data.ParameterDirection.Input;
      routineDetailJSONParameter.Value = routineDetailJSON;
      parameters.Add(routineDetailJSONParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RoutineDetail_Upd", parameters);
    }
    public Int32 RoutineHeader_Add(Guid routineHeaderID, DateTime routineDate, String refType, String refID, String remark, Guid auditInfoGuid, String availStatusID, String routineHeaderJSON, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineHeaderIDParameter = new SqlParameter();
      routineHeaderIDParameter.ParameterName = "@RoutineHeaderID";
      routineHeaderIDParameter.DbType = DbType.Guid;
      routineHeaderIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderIDParameter.Value = routineHeaderID;
      parameters.Add(routineHeaderIDParameter);
      var routineDateParameter = new SqlParameter();
      routineDateParameter.ParameterName = "@RoutineDate";
      routineDateParameter.DbType = DbType.DateTime;
      routineDateParameter.Direction = System.Data.ParameterDirection.Input;
      routineDateParameter.Value = routineDate;
      parameters.Add(routineDateParameter);
      var refTypeParameter = new SqlParameter();
      refTypeParameter.ParameterName = "@RefType";
      refTypeParameter.DbType = DbType.String;
      refTypeParameter.Direction = System.Data.ParameterDirection.Input;
      refTypeParameter.Size = 20;
      refTypeParameter.Value = refType;
      parameters.Add(refTypeParameter);
      var refIDParameter = new SqlParameter();
      refIDParameter.ParameterName = "@RefID";
      refIDParameter.DbType = DbType.String;
      refIDParameter.Direction = System.Data.ParameterDirection.Input;
      refIDParameter.Size = 50;
      refIDParameter.Value = refID;
      parameters.Add(refIDParameter);
      var remarkParameter = new SqlParameter();
      remarkParameter.ParameterName = "@Remark";
      remarkParameter.DbType = DbType.String;
      remarkParameter.Direction = System.Data.ParameterDirection.Input;
      remarkParameter.Size = 20;
      remarkParameter.Value = remark;
      parameters.Add(remarkParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var availStatusIDParameter = new SqlParameter();
      availStatusIDParameter.ParameterName = "@AvailStatusID";
      availStatusIDParameter.DbType = DbType.String;
      availStatusIDParameter.Direction = System.Data.ParameterDirection.Input;
      availStatusIDParameter.Size = 20;
      availStatusIDParameter.Value = availStatusID;
      parameters.Add(availStatusIDParameter);
      var routineHeaderJSONParameter = new SqlParameter();
      routineHeaderJSONParameter.ParameterName = "@RoutineHeaderJSON";
      routineHeaderJSONParameter.DbType = DbType.String;
      routineHeaderJSONParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderJSONParameter.Value = routineHeaderJSON;
      parameters.Add(routineHeaderJSONParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RoutineHeader_Add", parameters);
    }
    public Int32 RoutineHeader_Del(Guid routineHeaderID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineHeaderIDParameter = new SqlParameter();
      routineHeaderIDParameter.ParameterName = "@RoutineHeaderID";
      routineHeaderIDParameter.DbType = DbType.Guid;
      routineHeaderIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderIDParameter.Value = routineHeaderID;
      parameters.Add(routineHeaderIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.RoutineHeader_Del", parameters);
    }
    public IEnumerable<RoutineHeader_GetResult> RoutineHeader_Get(Guid routineHeaderID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var routineHeaderIDParameter = new SqlParameter();
      routineHeaderIDParameter.ParameterName = "@RoutineHeaderID";
      routineHeaderIDParameter.DbType = DbType.Guid;
      routineHeaderIDParameter.Direction = System.Data.ParameterDirection.Input;
      routineHeaderIDParameter.Value = routineHeaderID;
      parameters.Add(routineHeaderIDParameter);
      return ExecuteQuery<RoutineHeader_GetResult>.ExecuteStoredProcedure(this, "CDM.RoutineHeader_Get", parameters);
    }
    public IEnumerable<RoutineHeader_GetRefTypeAndRefIDResult> RoutineHeader_GetRefTypeAndRefID(String refType, String refID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var refTypeParameter = new SqlParameter();
      refTypeParameter.ParameterName = "@RefType";
      refTypeParameter.DbType = DbType.String;
      refTypeParameter.Direction = System.Data.ParameterDirection.Input;
      refTypeParameter.Size = 30;
      refTypeParameter.Value = refType;
      parameters.Add(refTypeParameter);
      var refIDParameter = new SqlParameter();
      refIDParameter.ParameterName = "@RefID";
      refIDParameter.DbType = DbType.String;
      refIDParameter.Direction = System.Data.ParameterDirection.Input;
      refIDParameter.Size = 30;
      refIDParameter.Value = refID;
      parameters.Add(refIDParameter);
      return ExecuteQuery<RoutineHeader_GetRefTypeAndRefIDResult>.ExecuteStoredProcedure(this, "CDM.RoutineHeader_GetRefTypeAndRefID", parameters);
    }

    public Int32 References2Notes_Add(Guid references2NotesID, String refType, String refID, String notes, String references2NotesJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var references2NotesIDParameter = new SqlParameter();
      references2NotesIDParameter.ParameterName = "@References2NotesID";
      references2NotesIDParameter.DbType = DbType.Guid;
      references2NotesIDParameter.Direction = System.Data.ParameterDirection.Input;
      references2NotesIDParameter.Value = references2NotesID;
      parameters.Add(references2NotesIDParameter);
      var refTypeParameter = new SqlParameter();
      refTypeParameter.ParameterName = "@RefType";
      refTypeParameter.DbType = DbType.String;
      refTypeParameter.Direction = System.Data.ParameterDirection.Input;
      refTypeParameter.Size = 20;
      refTypeParameter.Value = refType;
      parameters.Add(refTypeParameter);
      var refIDParameter = new SqlParameter();
      refIDParameter.ParameterName = "@RefID";
      refIDParameter.DbType = DbType.String;
      refIDParameter.Direction = System.Data.ParameterDirection.Input;
      refIDParameter.Size = 20;
      refIDParameter.Value = refID;
      parameters.Add(refIDParameter);
      var notesParameter = new SqlParameter();
      notesParameter.ParameterName = "@Notes";
      notesParameter.DbType = DbType.String;
      notesParameter.Direction = System.Data.ParameterDirection.Input;
      notesParameter.Size = 500;
      notesParameter.Value = notes;
      parameters.Add(notesParameter);
      var references2NotesJSONParameter = new SqlParameter();
      references2NotesJSONParameter.ParameterName = "@References2NotesJSON";
      references2NotesJSONParameter.DbType = DbType.String;
      references2NotesJSONParameter.Direction = System.Data.ParameterDirection.Input;
      references2NotesJSONParameter.Value = references2NotesJSON;
      parameters.Add(references2NotesJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.References2Notes_Add", parameters);
    }
    public IEnumerable<References2Notes_GetAllResult> References2Notes_GetAll()
    {
      return ExecuteQuery<References2Notes_GetAllResult>.ExecuteStoredProcedure(this, "CDM.References2Notes_GetAll");
    }
    public IEnumerable<References2Notes_GetByIDResult> References2Notes_GetByID(Guid references2NotesID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var references2NotesIDParameter = new SqlParameter();
      references2NotesIDParameter.ParameterName = "@References2NotesID";
      references2NotesIDParameter.DbType = DbType.Guid;
      references2NotesIDParameter.Direction = System.Data.ParameterDirection.Input;
      references2NotesIDParameter.Value = references2NotesID;
      parameters.Add(references2NotesIDParameter);
      return ExecuteQuery<References2Notes_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.References2Notes_GetByID", parameters);
    }
    public Int32 References2Notes_Remove(Guid references2NotesID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var references2NotesIDParameter = new SqlParameter();
      references2NotesIDParameter.ParameterName = "@References2NotesID";
      references2NotesIDParameter.DbType = DbType.Guid;
      references2NotesIDParameter.Direction = System.Data.ParameterDirection.Input;
      references2NotesIDParameter.Value = references2NotesID;
      parameters.Add(references2NotesIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.References2Notes_Remove", parameters);
    }
    public Int32 References2Notes_Upd(Guid references2NotesID, String refType, String refID, String notes, String references2NotesJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var references2NotesIDParameter = new SqlParameter();
      references2NotesIDParameter.ParameterName = "@References2NotesID";
      references2NotesIDParameter.DbType = DbType.Guid;
      references2NotesIDParameter.Direction = System.Data.ParameterDirection.Input;
      references2NotesIDParameter.Value = references2NotesID;
      parameters.Add(references2NotesIDParameter);
      var refTypeParameter = new SqlParameter();
      refTypeParameter.ParameterName = "@RefType";
      refTypeParameter.DbType = DbType.String;
      refTypeParameter.Direction = System.Data.ParameterDirection.Input;
      refTypeParameter.Size = 20;
      refTypeParameter.Value = refType;
      parameters.Add(refTypeParameter);
      var refIDParameter = new SqlParameter();
      refIDParameter.ParameterName = "@RefID";
      refIDParameter.DbType = DbType.String;
      refIDParameter.Direction = System.Data.ParameterDirection.Input;
      refIDParameter.Size = 20;
      refIDParameter.Value = refID;
      parameters.Add(refIDParameter);
      var notesParameter = new SqlParameter();
      notesParameter.ParameterName = "@Notes";
      notesParameter.DbType = DbType.String;
      notesParameter.Direction = System.Data.ParameterDirection.Input;
      notesParameter.Size = 500;
      notesParameter.Value = notes;
      parameters.Add(notesParameter);
      var references2NotesJSONParameter = new SqlParameter();
      references2NotesJSONParameter.ParameterName = "@References2NotesJSON";
      references2NotesJSONParameter.DbType = DbType.String;
      references2NotesJSONParameter.Direction = System.Data.ParameterDirection.Input;
      references2NotesJSONParameter.Value = references2NotesJSON;
      parameters.Add(references2NotesJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.References2Notes_Upd", parameters);
    }
    public Int32 References2Notes_Void(Guid references2NotesID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var references2NotesIDParameter = new SqlParameter();
      references2NotesIDParameter.ParameterName = "@References2NotesID";
      references2NotesIDParameter.DbType = DbType.Guid;
      references2NotesIDParameter.Direction = System.Data.ParameterDirection.Input;
      references2NotesIDParameter.Value = references2NotesID;
      parameters.Add(references2NotesIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.References2Notes_Void", parameters);
    }

    public IEnumerable<References2Notes_GetByIDResult> References2Notes_GetByReference(String referenceID, String referenceType)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var referenceIDParameter = new SqlParameter();
      referenceIDParameter.ParameterName = "@ReferenceID";
      referenceIDParameter.DbType = DbType.String;
      referenceIDParameter.Direction = System.Data.ParameterDirection.Input;
      referenceIDParameter.Size = 36;
      referenceIDParameter.Value = referenceID;
      parameters.Add(referenceIDParameter);
      var referenceTypeParameter = new SqlParameter();
      referenceTypeParameter.ParameterName = "@ReferenceType";
      referenceTypeParameter.DbType = DbType.String;
      referenceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      referenceTypeParameter.Size = 20;
      referenceTypeParameter.Value = referenceType;
      parameters.Add(referenceTypeParameter);
      return ExecuteQuery<References2Notes_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.References2Notes_GetByReference", parameters);
    }

    public Int32 Project_Add(String projectID, String projectJSON, String companyID, String locationID, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var projectIDParameter = new SqlParameter();
      projectIDParameter.ParameterName = "@ProjectID";
      projectIDParameter.DbType = DbType.String;
      projectIDParameter.Size = 20;
      projectIDParameter.Direction = System.Data.ParameterDirection.Input;
      projectIDParameter.Value = projectID;
      parameters.Add(projectIDParameter);
      var projectJSONParameter = new SqlParameter();
      projectJSONParameter.ParameterName = "@ProjectJSON";
      projectJSONParameter.DbType = DbType.String;
      projectJSONParameter.Direction = System.Data.ParameterDirection.Input;
      projectJSONParameter.Value = projectJSON;
      parameters.Add(projectJSONParameter);
      var companyIDParameter = new SqlParameter();
      companyIDParameter.ParameterName = "@CompanyID";
      companyIDParameter.DbType = DbType.String;
      companyIDParameter.Direction = System.Data.ParameterDirection.Input;
      companyIDParameter.Size = 20;
      companyIDParameter.Value = companyID;
      parameters.Add(companyIDParameter);
      var locationIDParameter = new SqlParameter();
      locationIDParameter.ParameterName = "@LocationID";
      locationIDParameter.DbType = DbType.String;
      locationIDParameter.Direction = System.Data.ParameterDirection.Input;
      locationIDParameter.Size = 20;
      locationIDParameter.Value = locationID;
      parameters.Add(locationIDParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Project_Add", parameters);
    }
    public Int32 Project_Void(String projectID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var projectIDParameter = new SqlParameter();
      projectIDParameter.ParameterName = "@ProjectID";
      projectIDParameter.DbType = DbType.String;
      projectIDParameter.Size = 20;
      projectIDParameter.Direction = System.Data.ParameterDirection.Input;
      projectIDParameter.Value = projectID;
      parameters.Add(projectIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Project_Void", parameters);
    }
    public IEnumerable<Project_GetAllResult> Project_GetAll()
    {
      return ExecuteQuery<Project_GetAllResult>.ExecuteStoredProcedure(this, "CDM.Project_GetAll");
    }
    public IEnumerable<Project_GetByIDResult> Project_GetByID(String projectID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var projectIDParameter = new SqlParameter();
      projectIDParameter.ParameterName = "@ProjectID";
      projectIDParameter.DbType = DbType.String;
      projectIDParameter.Size = 20;
      projectIDParameter.Direction = System.Data.ParameterDirection.Input;
      projectIDParameter.Value = projectID;
      parameters.Add(projectIDParameter);
      return ExecuteQuery<Project_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Project_GetByID", parameters);
    }
    public Int32 Project_Remove(String projectID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var projectIDParameter = new SqlParameter();
      projectIDParameter.ParameterName = "@ProjectID";
      projectIDParameter.DbType = DbType.String;
      projectIDParameter.Size = 20;
      projectIDParameter.Direction = System.Data.ParameterDirection.Input;
      projectIDParameter.Value = projectID;
      parameters.Add(projectIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Project_Remove", parameters);
    }
    public Int32 Project_Upd(String projectID, String projectJSON, String companyID, String locationID, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var projectIDParameter = new SqlParameter();
      projectIDParameter.ParameterName = "@ProjectID";
      projectIDParameter.DbType = DbType.String;
      projectIDParameter.Size = 20;
      projectIDParameter.Direction = System.Data.ParameterDirection.Input;
      projectIDParameter.Value = projectID;
      parameters.Add(projectIDParameter);
      var projectJSONParameter = new SqlParameter();
      projectJSONParameter.ParameterName = "@ProjectJSON";
      projectJSONParameter.DbType = DbType.String;
      projectJSONParameter.Direction = System.Data.ParameterDirection.Input;
      projectJSONParameter.Value = projectJSON;
      parameters.Add(projectJSONParameter);
      var companyIDParameter = new SqlParameter();
      companyIDParameter.ParameterName = "@CompanyID";
      companyIDParameter.DbType = DbType.String;
      companyIDParameter.Direction = System.Data.ParameterDirection.Input;
      companyIDParameter.Size = 20;
      companyIDParameter.Value = companyID;
      parameters.Add(companyIDParameter);
      var locationIDParameter = new SqlParameter();
      locationIDParameter.ParameterName = "@LocationID";
      locationIDParameter.DbType = DbType.String;
      locationIDParameter.Direction = System.Data.ParameterDirection.Input;
      locationIDParameter.Size = 20;
      locationIDParameter.Value = locationID;
      parameters.Add(locationIDParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Project_Upd", parameters);
    }
    public Int32 Task_Add(String taskID, String taskJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var taskIDParameter = new SqlParameter();
      taskIDParameter.ParameterName = "@TaskID";
      taskIDParameter.DbType = DbType.String;
      taskIDParameter.Size = 20;
      taskIDParameter.Direction = System.Data.ParameterDirection.Input;
      taskIDParameter.Value = taskID;
      parameters.Add(taskIDParameter);
      var taskJSONParameter = new SqlParameter();
      taskJSONParameter.ParameterName = "@TaskJSON";
      taskJSONParameter.DbType = DbType.String;
      taskJSONParameter.Direction = System.Data.ParameterDirection.Input;
      taskJSONParameter.Value = taskJSON;
      parameters.Add(taskJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Task_Add", parameters);
    }
    public Int32 Task_Remove(String taskID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var taskIDParameter = new SqlParameter();
      taskIDParameter.ParameterName = "@TaskID";
      taskIDParameter.DbType = DbType.String;
      taskIDParameter.Size = 20;
      taskIDParameter.Direction = System.Data.ParameterDirection.Input;
      taskIDParameter.Value = taskID;
      parameters.Add(taskIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Task_Remove", parameters);
    }
    public IEnumerable<Task_GetAllResult> Task_GetAll()
    {
      return ExecuteQuery<Task_GetAllResult>.ExecuteStoredProcedure(this, "CDM.Task_GetAll");
    }
    public IEnumerable<Task_GetByIDResult> Task_GetByID(String taskID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var taskIDParameter = new SqlParameter();
      taskIDParameter.ParameterName = "@TaskID";
      taskIDParameter.DbType = DbType.String;
      taskIDParameter.Size = 20;
      taskIDParameter.Direction = System.Data.ParameterDirection.Input;
      taskIDParameter.Value = taskID;
      parameters.Add(taskIDParameter);
      return ExecuteQuery<Task_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Task_GetByID", parameters);
    }
    public Int32 Task_Upd(String taskID, String taskJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var taskIDParameter = new SqlParameter();
      taskIDParameter.ParameterName = "@TaskID";
      taskIDParameter.DbType = DbType.String;
      taskIDParameter.Size = 20;
      taskIDParameter.Direction = System.Data.ParameterDirection.Input;
      taskIDParameter.Value = taskID;
      parameters.Add(taskIDParameter);
      var taskJSONParameter = new SqlParameter();
      taskJSONParameter.ParameterName = "@TaskJSON";
      taskJSONParameter.DbType = DbType.String;
      taskJSONParameter.Direction = System.Data.ParameterDirection.Input;
      taskJSONParameter.Value = taskJSON;
      parameters.Add(taskJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Task_Upd", parameters);
    }
    public Int32 Task_Void(String taskID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var taskIDParameter = new SqlParameter();
      taskIDParameter.ParameterName = "@TaskID";
      taskIDParameter.DbType = DbType.String;
      taskIDParameter.Size = 20;
      taskIDParameter.Direction = System.Data.ParameterDirection.Input;
      taskIDParameter.Value = taskID;
      parameters.Add(taskIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Task_Void", parameters);
    }
    public Int32 Activity_Add(String activityID, String activityJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activityIDParameter = new SqlParameter();
      activityIDParameter.ParameterName = "@ActivityID";
      activityIDParameter.DbType = DbType.String;
      activityIDParameter.Size = 20;
      activityIDParameter.Direction = System.Data.ParameterDirection.Input;
      activityIDParameter.Value = activityID;
      parameters.Add(activityIDParameter);
      var activityJSONParameter = new SqlParameter();
      activityJSONParameter.ParameterName = "@ActivityJSON";
      activityJSONParameter.DbType = DbType.String;
      activityJSONParameter.Direction = System.Data.ParameterDirection.Input;
      activityJSONParameter.Value = activityJSON;
      parameters.Add(activityJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activity_Add", parameters);
    }
    public Int32 Activity_Void(String activityID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activityIDParameter = new SqlParameter();
      activityIDParameter.ParameterName = "@ActivityID";
      activityIDParameter.DbType = DbType.String;
      activityIDParameter.Size = 20;
      activityIDParameter.Direction = System.Data.ParameterDirection.Input;
      activityIDParameter.Value = activityID;
      parameters.Add(activityIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activity_Void", parameters);
    }
    public IEnumerable<Activity_GetAllResult> Activity_GetAll()
    {
      return ExecuteQuery<Activity_GetAllResult>.ExecuteStoredProcedure(this, "CDM.Activity_GetAll");
    }
    public IEnumerable<Activity_GetByIDResult> Activity_GetByID(String activityID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activityIDParameter = new SqlParameter();
      activityIDParameter.ParameterName = "@ActivityID";
      activityIDParameter.DbType = DbType.String;
      activityIDParameter.Size = 20;
      activityIDParameter.Direction = System.Data.ParameterDirection.Input;
      activityIDParameter.Value = activityID;
      parameters.Add(activityIDParameter);
      return ExecuteQuery<Activity_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Activity_GetByID", parameters);
    }
    public Int32 Activity_Remove(String activityID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activityIDParameter = new SqlParameter();
      activityIDParameter.ParameterName = "@ActivityID";
      activityIDParameter.DbType = DbType.String;
      activityIDParameter.Size = 20;
      activityIDParameter.Direction = System.Data.ParameterDirection.Input;
      activityIDParameter.Value = activityID;
      parameters.Add(activityIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activity_Remove", parameters);
    }
    public Int32 Activity_Upd(String activityID, String activityJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activityIDParameter = new SqlParameter();
      activityIDParameter.ParameterName = "@ActivityID";
      activityIDParameter.DbType = DbType.String;
      activityIDParameter.Size = 20;
      activityIDParameter.Direction = System.Data.ParameterDirection.Input;
      activityIDParameter.Value = activityID;
      parameters.Add(activityIDParameter);
      var activityJSONParameter = new SqlParameter();
      activityJSONParameter.ParameterName = "@ActivityJSON";
      activityJSONParameter.DbType = DbType.String;
      activityJSONParameter.Direction = System.Data.ParameterDirection.Input;
      activityJSONParameter.Value = activityJSON;
      parameters.Add(activityJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activity_Upd", parameters);
    }

    public Int32 Activities_Add(String activitiesID, String activitiesJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activitiesIDParameter = new SqlParameter();
      activitiesIDParameter.ParameterName = "@ActivitiesID";
      activitiesIDParameter.DbType = DbType.String;
      activitiesIDParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesIDParameter.Size = 20;
      activitiesIDParameter.Value = activitiesID;
      parameters.Add(activitiesIDParameter);
      var activitiesJSONParameter = new SqlParameter();
      activitiesJSONParameter.ParameterName = "@ActivitiesJSON";
      activitiesJSONParameter.DbType = DbType.String;
      activitiesJSONParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesJSONParameter.Value = activitiesJSON;
      parameters.Add(activitiesJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activities_Add", parameters);
    }
    public IEnumerable<Activities_AllResult> Activities_All()
    {
      return ExecuteQuery<Activities_AllResult>.ExecuteStoredProcedure(this, "CDM.Activities_All");
    }
    public IEnumerable<Activities_GetByIDResult> Activities_GetByID(String activitiesID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activitiesIDParameter = new SqlParameter();
      activitiesIDParameter.ParameterName = "@ActivitiesID";
      activitiesIDParameter.DbType = DbType.String;
      activitiesIDParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesIDParameter.Size = 20;
      activitiesIDParameter.Value = activitiesID;
      parameters.Add(activitiesIDParameter);
      return ExecuteQuery<Activities_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Activities_GetByID", parameters);
    }
    public Int32 Activities_Remove(String activitiesID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activitiesIDParameter = new SqlParameter();
      activitiesIDParameter.ParameterName = "@ActivitiesID";
      activitiesIDParameter.DbType = DbType.String;
      activitiesIDParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesIDParameter.Size = 20;
      activitiesIDParameter.Value = activitiesID;
      parameters.Add(activitiesIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activities_Remove", parameters);
    }
    public Int32 Activities_Upd(String activitiesID, String activitiesJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activitiesIDParameter = new SqlParameter();
      activitiesIDParameter.ParameterName = "@ActivitiesID";
      activitiesIDParameter.DbType = DbType.String;
      activitiesIDParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesIDParameter.Size = 20;
      activitiesIDParameter.Value = activitiesID;
      parameters.Add(activitiesIDParameter);
      var activitiesJSONParameter = new SqlParameter();
      activitiesJSONParameter.ParameterName = "@ActivitiesJSON";
      activitiesJSONParameter.DbType = DbType.String;
      activitiesJSONParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesJSONParameter.Value = activitiesJSON;
      parameters.Add(activitiesJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activities_Upd", parameters);
    }
    public Int32 Activities_Void(String activitiesID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activitiesIDParameter = new SqlParameter();
      activitiesIDParameter.ParameterName = "@ActivitiesID";
      activitiesIDParameter.DbType = DbType.String;
      activitiesIDParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesIDParameter.Size = 20;
      activitiesIDParameter.Value = activitiesID;
      parameters.Add(activitiesIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activities_Void", parameters);
    }
    public Int32 Activities2Tasks_Add(Guid activities2TasksID, String activitiesID, String tasksID, String activities2TasksJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activities2TasksIDParameter = new SqlParameter();
      activities2TasksIDParameter.ParameterName = "@Activities2TasksID";
      activities2TasksIDParameter.DbType = DbType.Guid;
      activities2TasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      activities2TasksIDParameter.Value = activities2TasksID;
      parameters.Add(activities2TasksIDParameter);
      var activitiesIDParameter = new SqlParameter();
      activitiesIDParameter.ParameterName = "@ActivitiesID";
      activitiesIDParameter.DbType = DbType.String;
      activitiesIDParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesIDParameter.Size = 20;
      activitiesIDParameter.Value = activitiesID;
      parameters.Add(activitiesIDParameter);
      var tasksIDParameter = new SqlParameter();
      tasksIDParameter.ParameterName = "@TasksID";
      tasksIDParameter.DbType = DbType.String;
      tasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      tasksIDParameter.Size = 20;
      tasksIDParameter.Value = tasksID;
      parameters.Add(tasksIDParameter);
      var activities2TasksJSONParameter = new SqlParameter();
      activities2TasksJSONParameter.ParameterName = "@Activities2TasksJSON";
      activities2TasksJSONParameter.DbType = DbType.String;
      activities2TasksJSONParameter.Direction = System.Data.ParameterDirection.Input;
      activities2TasksJSONParameter.Value = activities2TasksJSON;
      parameters.Add(activities2TasksJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activities2Tasks_Add", parameters);
    }
    public IEnumerable<Activities2Tasks_AllResult> Activities2Tasks_All()
    {
      return ExecuteQuery<Activities2Tasks_AllResult>.ExecuteStoredProcedure(this, "CDM.Activities2Tasks_All");
    }
    public IEnumerable<Activities2Tasks_GetByIDResult> Activities2Tasks_GetByID(Guid activities2TasksID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activities2TasksIDParameter = new SqlParameter();
      activities2TasksIDParameter.ParameterName = "@Activities2TasksID";
      activities2TasksIDParameter.DbType = DbType.Guid;
      activities2TasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      activities2TasksIDParameter.Value = activities2TasksID;
      parameters.Add(activities2TasksIDParameter);
      return ExecuteQuery<Activities2Tasks_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Activities2Tasks_GetByID", parameters);
    }
    public Int32 Activities2Tasks_Remove(Guid activities2TasksID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activities2TasksIDParameter = new SqlParameter();
      activities2TasksIDParameter.ParameterName = "@Activities2TasksID";
      activities2TasksIDParameter.DbType = DbType.Guid;
      activities2TasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      activities2TasksIDParameter.Value = activities2TasksID;
      parameters.Add(activities2TasksIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activities2Tasks_Remove", parameters);
    }
    public Int32 Activities2Tasks_Upd(Guid activities2TasksID, String activitiesID, String tasksID, String activities2TasksJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activities2TasksIDParameter = new SqlParameter();
      activities2TasksIDParameter.ParameterName = "@Activities2TasksID";
      activities2TasksIDParameter.DbType = DbType.Guid;
      activities2TasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      activities2TasksIDParameter.Value = activities2TasksID;
      parameters.Add(activities2TasksIDParameter);
      var activitiesIDParameter = new SqlParameter();
      activitiesIDParameter.ParameterName = "@ActivitiesID";
      activitiesIDParameter.DbType = DbType.String;
      activitiesIDParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesIDParameter.Size = 20;
      activitiesIDParameter.Value = activitiesID;
      parameters.Add(activitiesIDParameter);
      var tasksIDParameter = new SqlParameter();
      tasksIDParameter.ParameterName = "@TasksID";
      tasksIDParameter.DbType = DbType.String;
      tasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      tasksIDParameter.Size = 20;
      tasksIDParameter.Value = tasksID;
      parameters.Add(tasksIDParameter);
      var activities2TasksJSONParameter = new SqlParameter();
      activities2TasksJSONParameter.ParameterName = "@Activities2TasksJSON";
      activities2TasksJSONParameter.DbType = DbType.String;
      activities2TasksJSONParameter.Direction = System.Data.ParameterDirection.Input;
      activities2TasksJSONParameter.Value = activities2TasksJSON;
      parameters.Add(activities2TasksJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activities2Tasks_Upd", parameters);
    }
    public Int32 Activities2Tasks_Void(Guid activities2TasksID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activities2TasksIDParameter = new SqlParameter();
      activities2TasksIDParameter.ParameterName = "@Activities2TasksID";
      activities2TasksIDParameter.DbType = DbType.Guid;
      activities2TasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      activities2TasksIDParameter.Value = activities2TasksID;
      parameters.Add(activities2TasksIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Activities2Tasks_Void", parameters);
    }
    public Int32 GetNextBillingID_OUT(String billTypeID, ref String nxtBillNo)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var billTypeIDParameter = new SqlParameter();
      billTypeIDParameter.ParameterName = "@BillTypeID";
      billTypeIDParameter.DbType = DbType.String;
      billTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      billTypeIDParameter.Size = 20;
      billTypeIDParameter.Value = billTypeID;
      parameters.Add(billTypeIDParameter);
      var nxtBillNoParameter = new SqlParameter();
      nxtBillNoParameter.ParameterName = "@NxtBillNo";
      nxtBillNoParameter.DbType = DbType.String;
      nxtBillNoParameter.Size = 20;
      nxtBillNoParameter.Direction = System.Data.ParameterDirection.Output;
      parameters.Add(nxtBillNoParameter);
      var result1 = ExecuteNonQuery.ExecuteStoredProcedure(this, "BDM.GetNextBillingID_OUT", ref parameters);
      try
      {
        nxtBillNo = (String)parameters[parameters.IndexOf(nxtBillNoParameter)].Value;
      }
      catch (Exception ex)
      {
      }
      return result1;
    }
    // Please Verify SP
    public int GetNextBillingIDExcptSvrID_OUT(String billTypeID, ref String nxtBillNo)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var billTypeIDParameter = new SqlParameter();
      billTypeIDParameter.ParameterName = "@BillTypeID";
      billTypeIDParameter.DbType = DbType.String;
      billTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      billTypeIDParameter.Size = 20;
      billTypeIDParameter.Value = billTypeID;
      parameters.Add(billTypeIDParameter);
      var nxtBillNoParameter = new SqlParameter();
      nxtBillNoParameter.ParameterName = "@NxtBillNo";
      nxtBillNoParameter.DbType = DbType.String;
      nxtBillNoParameter.Size = 20;
      nxtBillNoParameter.Direction = System.Data.ParameterDirection.Output;
      parameters.Add(nxtBillNoParameter);
      var result1 = ExecuteNonQuery.ExecuteStoredProcedure(this, "BDM.GetNextBillingIDExcptSvrID_OUT", ref parameters);
      try
      {
        nxtBillNo = (String)parameters[parameters.IndexOf(nxtBillNoParameter)].Value;
      }
      catch (Exception ex)
      {
      }
      return result1;
    }
    public Int32 Tasks_Add(String tasksID, String tasksJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var tasksIDParameter = new SqlParameter();
      tasksIDParameter.ParameterName = "@TasksID";
      tasksIDParameter.DbType = DbType.String;
      tasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      tasksIDParameter.Size = 20;
      tasksIDParameter.Value = tasksID;
      parameters.Add(tasksIDParameter);
      var tasksJSONParameter = new SqlParameter();
      tasksJSONParameter.ParameterName = "@TasksJSON";
      tasksJSONParameter.DbType = DbType.String;
      tasksJSONParameter.Direction = System.Data.ParameterDirection.Input;
      tasksJSONParameter.Value = tasksJSON;
      parameters.Add(tasksJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Tasks_Add", parameters);
    }
    public IEnumerable<Tasks_AllResult> Tasks_All()
    {
      return ExecuteQuery<Tasks_AllResult>.ExecuteStoredProcedure(this, "CDM.Tasks_All");
    }
    public IEnumerable<Tasks_GetByIDResult> Tasks_GetByID(String tasksID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var tasksIDParameter = new SqlParameter();
      tasksIDParameter.ParameterName = "@TasksID";
      tasksIDParameter.DbType = DbType.String;
      tasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      tasksIDParameter.Size = 20;
      tasksIDParameter.Value = tasksID;
      parameters.Add(tasksIDParameter);
      return ExecuteQuery<Tasks_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Tasks_GetByID", parameters);
    }
    public Int32 Tasks_Remove(String tasksID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var tasksIDParameter = new SqlParameter();
      tasksIDParameter.ParameterName = "@TasksID";
      tasksIDParameter.DbType = DbType.String;
      tasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      tasksIDParameter.Size = 20;
      tasksIDParameter.Value = tasksID;
      parameters.Add(tasksIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Tasks_Remove", parameters);
    }
    public Int32 Tasks_Upd(String tasksID, String tasksJSON, String status, Guid auditInfoGuid, DateTime lastUpdateUTCDT)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var tasksIDParameter = new SqlParameter();
      tasksIDParameter.ParameterName = "@TasksID";
      tasksIDParameter.DbType = DbType.String;
      tasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      tasksIDParameter.Size = 20;
      tasksIDParameter.Value = tasksID;
      parameters.Add(tasksIDParameter);
      var tasksJSONParameter = new SqlParameter();
      tasksJSONParameter.ParameterName = "@TasksJSON";
      tasksJSONParameter.DbType = DbType.String;
      tasksJSONParameter.Direction = System.Data.ParameterDirection.Input;
      tasksJSONParameter.Value = tasksJSON;
      parameters.Add(tasksJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      var lastUpdateUTCDTParameter = new SqlParameter();
      lastUpdateUTCDTParameter.ParameterName = "@LastUpdateUTCDT";
      lastUpdateUTCDTParameter.DbType = DbType.DateTime;
      lastUpdateUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdateUTCDTParameter.Value = lastUpdateUTCDT;
      parameters.Add(lastUpdateUTCDTParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Tasks_Upd", parameters);
    }
    public Int32 Tasks_Void(String tasksID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var tasksIDParameter = new SqlParameter();
      tasksIDParameter.ParameterName = "@TasksID";
      tasksIDParameter.DbType = DbType.String;
      tasksIDParameter.Direction = System.Data.ParameterDirection.Input;
      tasksIDParameter.Size = 20;
      tasksIDParameter.Value = tasksID;
      parameters.Add(tasksIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Tasks_Void", parameters);
    }
    public IEnumerable<Activities2Tasks_GetByActivitiesIDResult> Activities2Tasks_GetByActivitiesID(String activitiesID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var activitiesIDParameter = new SqlParameter();
      activitiesIDParameter.ParameterName = "@ActivitiesID";
      activitiesIDParameter.DbType = DbType.String;
      activitiesIDParameter.Direction = System.Data.ParameterDirection.Input;
      activitiesIDParameter.Size = 20;
      activitiesIDParameter.Value = activitiesID;
      parameters.Add(activitiesIDParameter);
      return ExecuteQuery<Activities2Tasks_GetByActivitiesIDResult>.ExecuteStoredProcedure(this, "CDM.Activities2Tasks_GetByActivitiesID", parameters);
    }
    public Int32 Equipment_Add(String equipmentID, String equipmentType, String equipmentJSON, String status, DateTime lastUpdatedUTCDT, Guid auditInfoGuid)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var equipmentIDParameter = new SqlParameter();
      equipmentIDParameter.ParameterName = "@EquipmentID";
      equipmentIDParameter.DbType = DbType.String;
      equipmentIDParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentIDParameter.Size = 20;
      equipmentIDParameter.Value = equipmentID;
      parameters.Add(equipmentIDParameter);
      var equipmentTypeParameter = new SqlParameter();
      equipmentTypeParameter.ParameterName = "@EquipmentType";
      equipmentTypeParameter.DbType = DbType.String;
      equipmentTypeParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentTypeParameter.Size = 100;
      equipmentTypeParameter.Value = equipmentType;
      parameters.Add(equipmentTypeParameter);
      var equipmentJSONParameter = new SqlParameter();
      equipmentJSONParameter.ParameterName = "@EquipmentJSON";
      equipmentJSONParameter.DbType = DbType.String;
      equipmentJSONParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentJSONParameter.Value = equipmentJSON;
      parameters.Add(equipmentJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var lastUpdatedUTCDTParameter = new SqlParameter();
      lastUpdatedUTCDTParameter.ParameterName = "@LastUpdatedUTCDT";
      lastUpdatedUTCDTParameter.DbType = DbType.DateTime;
      lastUpdatedUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCDTParameter.Value = lastUpdatedUTCDT;
      parameters.Add(lastUpdatedUTCDTParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Equipment_Add", parameters);
    }
    public IEnumerable<Equipment_GetAllResult> Equipment_GetAll()
    {
      return ExecuteQuery<Equipment_GetAllResult>.ExecuteStoredProcedure(this, "CDM.Equipment_GetAll");
    }
    public IEnumerable<Equipment_GetByIDResult> Equipment_GetByID(String equipmentID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var equipmentIDParameter = new SqlParameter();
      equipmentIDParameter.ParameterName = "@EquipmentID";
      equipmentIDParameter.DbType = DbType.String;
      equipmentIDParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentIDParameter.Size = 20;
      equipmentIDParameter.Value = equipmentID;
      parameters.Add(equipmentIDParameter);
      return ExecuteQuery<Equipment_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.Equipment_GetByID", parameters);
    }
    public Int32 Equipment_Remove(String equipmentID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var equipmentIDParameter = new SqlParameter();
      equipmentIDParameter.ParameterName = "@EquipmentID";
      equipmentIDParameter.DbType = DbType.String;
      equipmentIDParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentIDParameter.Size = 20;
      equipmentIDParameter.Value = equipmentID;
      parameters.Add(equipmentIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Equipment_Remove", parameters);
    }
    public Int32 Equipment_Upd(String equipmentID, String equipmentType, String equipmentJSON, String status, DateTime lastUpdatedUTCDT, Guid auditInfoGuid)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var equipmentIDParameter = new SqlParameter();
      equipmentIDParameter.ParameterName = "@EquipmentID";
      equipmentIDParameter.DbType = DbType.String;
      equipmentIDParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentIDParameter.Size = 20;
      equipmentIDParameter.Value = equipmentID;
      parameters.Add(equipmentIDParameter);
      var equipmentTypeParameter = new SqlParameter();
      equipmentTypeParameter.ParameterName = "@EquipmentType";
      equipmentTypeParameter.DbType = DbType.String;
      equipmentTypeParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentTypeParameter.Size = 100;
      equipmentTypeParameter.Value = equipmentType;
      parameters.Add(equipmentTypeParameter);
      var equipmentJSONParameter = new SqlParameter();
      equipmentJSONParameter.ParameterName = "@EquipmentJSON";
      equipmentJSONParameter.DbType = DbType.String;
      equipmentJSONParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentJSONParameter.Value = equipmentJSON;
      parameters.Add(equipmentJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var lastUpdatedUTCDTParameter = new SqlParameter();
      lastUpdatedUTCDTParameter.ParameterName = "@LastUpdatedUTCDT";
      lastUpdatedUTCDTParameter.DbType = DbType.DateTime;
      lastUpdatedUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCDTParameter.Value = lastUpdatedUTCDT;
      parameters.Add(lastUpdatedUTCDTParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Equipment_Upd", parameters);
    }
    public Int32 Equipment_Void(String equipmentID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var equipmentIDParameter = new SqlParameter();
      equipmentIDParameter.ParameterName = "@EquipmentID";
      equipmentIDParameter.DbType = DbType.String;
      equipmentIDParameter.Direction = System.Data.ParameterDirection.Input;
      equipmentIDParameter.Size = 20;
      equipmentIDParameter.Value = equipmentID;
      parameters.Add(equipmentIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.Equipment_Void", parameters);
    }
    public Int32 HResource_Add(String hResourceID, String resourceType, String hResourceJSON, String status, DateTime lastUpdatedUTCDT, Guid auditInfoGuid)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var hResourceIDParameter = new SqlParameter();
      hResourceIDParameter.ParameterName = "@HResourceID";
      hResourceIDParameter.DbType = DbType.String;
      hResourceIDParameter.Direction = System.Data.ParameterDirection.Input;
      hResourceIDParameter.Size = 20;
      hResourceIDParameter.Value = hResourceID;
      parameters.Add(hResourceIDParameter);
      var resourceTypeParameter = new SqlParameter();
      resourceTypeParameter.ParameterName = "@ResourceType";
      resourceTypeParameter.DbType = DbType.String;
      resourceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      resourceTypeParameter.Size = 100;
      resourceTypeParameter.Value = resourceType;
      parameters.Add(resourceTypeParameter);
      var hResourceJSONParameter = new SqlParameter();
      hResourceJSONParameter.ParameterName = "@HResourceJSON";
      hResourceJSONParameter.DbType = DbType.String;
      hResourceJSONParameter.Direction = System.Data.ParameterDirection.Input;
      hResourceJSONParameter.Value = hResourceJSON;
      parameters.Add(hResourceJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var lastUpdatedUTCDTParameter = new SqlParameter();
      lastUpdatedUTCDTParameter.ParameterName = "@LastUpdatedUTCDT";
      lastUpdatedUTCDTParameter.DbType = DbType.DateTime;
      lastUpdatedUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCDTParameter.Value = lastUpdatedUTCDT;
      parameters.Add(lastUpdatedUTCDTParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.HResource_Add", parameters);
    }
    public IEnumerable<HResource_GetAllResult> HResource_GetAll()
    {
      return ExecuteQuery<HResource_GetAllResult>.ExecuteStoredProcedure(this, "CDM.HResource_GetAll");
    }
    public IEnumerable<HResource_GetByIDResult> HResource_GetByID(String hResourceID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var hResourceIDParameter = new SqlParameter();
      hResourceIDParameter.ParameterName = "@HResourceID";
      hResourceIDParameter.DbType = DbType.String;
      hResourceIDParameter.Direction = System.Data.ParameterDirection.Input;
      hResourceIDParameter.Size = 20;
      hResourceIDParameter.Value = hResourceID;
      parameters.Add(hResourceIDParameter);
      return ExecuteQuery<HResource_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.HResource_GetByID", parameters);
    }
    public Int32 HResource_Remove(String hResourceID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var hResourceIDParameter = new SqlParameter();
      hResourceIDParameter.ParameterName = "@HResourceID";
      hResourceIDParameter.DbType = DbType.String;
      hResourceIDParameter.Direction = System.Data.ParameterDirection.Input;
      hResourceIDParameter.Size = 20;
      hResourceIDParameter.Value = hResourceID;
      parameters.Add(hResourceIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.HResource_Remove", parameters);
    }
    public Int32 HResource_Upd(String hResourceID, String resourceType, String hResourceJSON, String status, DateTime lastUpdatedUTCDT, Guid auditInfoGuid)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var hResourceIDParameter = new SqlParameter();
      hResourceIDParameter.ParameterName = "@HResourceID";
      hResourceIDParameter.DbType = DbType.String;
      hResourceIDParameter.Direction = System.Data.ParameterDirection.Input;
      hResourceIDParameter.Size = 20;
      hResourceIDParameter.Value = hResourceID;
      parameters.Add(hResourceIDParameter);
      var resourceTypeParameter = new SqlParameter();
      resourceTypeParameter.ParameterName = "@ResourceType";
      resourceTypeParameter.DbType = DbType.String;
      resourceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      resourceTypeParameter.Size = 100;
      resourceTypeParameter.Value = resourceType;
      parameters.Add(resourceTypeParameter);
      var hResourceJSONParameter = new SqlParameter();
      hResourceJSONParameter.ParameterName = "@HResourceJSON";
      hResourceJSONParameter.DbType = DbType.String;
      hResourceJSONParameter.Direction = System.Data.ParameterDirection.Input;
      hResourceJSONParameter.Value = hResourceJSON;
      parameters.Add(hResourceJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var lastUpdatedUTCDTParameter = new SqlParameter();
      lastUpdatedUTCDTParameter.ParameterName = "@LastUpdatedUTCDT";
      lastUpdatedUTCDTParameter.DbType = DbType.DateTime;
      lastUpdatedUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCDTParameter.Value = lastUpdatedUTCDT;
      parameters.Add(lastUpdatedUTCDTParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.HResource_Upd", parameters);
    }
    public Int32 HResource_Void(String hResourceID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var hResourceIDParameter = new SqlParameter();
      hResourceIDParameter.ParameterName = "@HResourceID";
      hResourceIDParameter.DbType = DbType.String;
      hResourceIDParameter.Direction = System.Data.ParameterDirection.Input;
      hResourceIDParameter.Size = 20;
      hResourceIDParameter.Value = hResourceID;
      parameters.Add(hResourceIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.HResource_Void", parameters);
    }
    public Int32 ContactAddressesDtl_InsUpdKeysByEntityTypeID(String entityType, XElement contactAddressDtlKeysInfo)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var entityTypeParameter = new SqlParameter();
      entityTypeParameter.ParameterName = "@EntityType";
      entityTypeParameter.DbType = DbType.String;
      entityTypeParameter.Direction = System.Data.ParameterDirection.Input;
      entityTypeParameter.Size = 20;
      entityTypeParameter.Value = entityType;
      parameters.Add(entityTypeParameter);
      var contactAddressDtlKeysInfoParameter = new SqlParameter();
      contactAddressDtlKeysInfoParameter.ParameterName = "@ContactAddressDtlKeysInfo";
      contactAddressDtlKeysInfoParameter.DbType = DbType.Xml;
      contactAddressDtlKeysInfoParameter.Direction = System.Data.ParameterDirection.Input;
      contactAddressDtlKeysInfoParameter.Value = contactAddressDtlKeysInfo?.ToString();
      parameters.Add(contactAddressDtlKeysInfoParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "BDM.ContactAddressesDtl_InsUpdKeysByEntityTypeID", parameters);
    }
    public Int32 CurrencyExchange_Add(Guid currencyExchangeID, DateTime currencyExchangeDate, String currencyExchangeJSON, String status, DateTime lastUpdatedUTCDT, Guid auditInfoGuid)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var currencyExchangeIDParameter = new SqlParameter();
      currencyExchangeIDParameter.ParameterName = "@CurrencyExchangeID";
      currencyExchangeIDParameter.DbType = DbType.Guid;
      currencyExchangeIDParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeIDParameter.Value = currencyExchangeID;
      parameters.Add(currencyExchangeIDParameter);
      var currencyExchangeDateParameter = new SqlParameter();
      currencyExchangeDateParameter.ParameterName = "@CurrencyExchangeDate";
      currencyExchangeDateParameter.DbType = DbType.DateTime;
      currencyExchangeDateParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeDateParameter.Value = currencyExchangeDate;
      parameters.Add(currencyExchangeDateParameter);
      var currencyExchangeJSONParameter = new SqlParameter();
      currencyExchangeJSONParameter.ParameterName = "@CurrencyExchangeJSON";
      currencyExchangeJSONParameter.DbType = DbType.String;
      currencyExchangeJSONParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeJSONParameter.Value = currencyExchangeJSON;
      parameters.Add(currencyExchangeJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var lastUpdatedUTCDTParameter = new SqlParameter();
      lastUpdatedUTCDTParameter.ParameterName = "@LastUpdatedUTCDT";
      lastUpdatedUTCDTParameter.DbType = DbType.DateTime;
      lastUpdatedUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCDTParameter.Value = lastUpdatedUTCDT;
      parameters.Add(lastUpdatedUTCDTParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.CurrencyExchange_Add", parameters);
    }
    public IEnumerable<CurrencyExchange_GetAllResult> CurrencyExchange_GetAll()
    {
      return ExecuteQuery<CurrencyExchange_GetAllResult>.ExecuteStoredProcedure(this, "CDM.CurrencyExchange_GetAll");
    }
    public IEnumerable<CurrencyExchange_GetByIDResult> CurrencyExchange_GetByID(Guid currencyExchangeID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var currencyExchangeIDParameter = new SqlParameter();
      currencyExchangeIDParameter.ParameterName = "@CurrencyExchangeID";
      currencyExchangeIDParameter.DbType = DbType.Guid;
      currencyExchangeIDParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeIDParameter.Value = currencyExchangeID;
      parameters.Add(currencyExchangeIDParameter);
      return ExecuteQuery<CurrencyExchange_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.CurrencyExchange_GetByID", parameters);
    }
    public Int32 CurrencyExchange_Remove(Guid currencyExchangeID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var currencyExchangeIDParameter = new SqlParameter();
      currencyExchangeIDParameter.ParameterName = "@CurrencyExchangeID";
      currencyExchangeIDParameter.DbType = DbType.Guid;
      currencyExchangeIDParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeIDParameter.Value = currencyExchangeID;
      parameters.Add(currencyExchangeIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.CurrencyExchange_Remove", parameters);
    }
    public Int32 CurrencyExchange_Upd(Guid currencyExchangeID, DateTime currencyExchangeDate, String currencyExchangeJSON, String status, DateTime lastUpdatedUTCDT, Guid auditInfoGuid)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var currencyExchangeIDParameter = new SqlParameter();
      currencyExchangeIDParameter.ParameterName = "@CurrencyExchangeID";
      currencyExchangeIDParameter.DbType = DbType.Guid;
      currencyExchangeIDParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeIDParameter.Value = currencyExchangeID;
      parameters.Add(currencyExchangeIDParameter);
      var currencyExchangeDateParameter = new SqlParameter();
      currencyExchangeDateParameter.ParameterName = "@CurrencyExchangeDate";
      currencyExchangeDateParameter.DbType = DbType.DateTime;
      currencyExchangeDateParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeDateParameter.Value = currencyExchangeDate;
      parameters.Add(currencyExchangeDateParameter);
      var currencyExchangeJSONParameter = new SqlParameter();
      currencyExchangeJSONParameter.ParameterName = "@CurrencyExchangeJSON";
      currencyExchangeJSONParameter.DbType = DbType.String;
      currencyExchangeJSONParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeJSONParameter.Value = currencyExchangeJSON;
      parameters.Add(currencyExchangeJSONParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var lastUpdatedUTCDTParameter = new SqlParameter();
      lastUpdatedUTCDTParameter.ParameterName = "@LastUpdatedUTCDT";
      lastUpdatedUTCDTParameter.DbType = DbType.DateTime;
      lastUpdatedUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCDTParameter.Value = lastUpdatedUTCDT;
      parameters.Add(lastUpdatedUTCDTParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.CurrencyExchange_Upd", parameters);
    }
    public Int32 CurrencyExchange_Void(Guid currencyExchangeID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var currencyExchangeIDParameter = new SqlParameter();
      currencyExchangeIDParameter.ParameterName = "@CurrencyExchangeID";
      currencyExchangeIDParameter.DbType = DbType.Guid;
      currencyExchangeIDParameter.Direction = System.Data.ParameterDirection.Input;
      currencyExchangeIDParameter.Value = currencyExchangeID;
      parameters.Add(currencyExchangeIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.CurrencyExchange_Void", parameters);
    }
    public Int32 POCDoc_Add(Guid pOCDocID, DateTime pOCDocDate, String referenceID, String referenceType, String pOCDocJSON, String companyID, String status, DateTime lastUpdatedUTCDT, Guid auditInfoGuid)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var pOCDocIDParameter = new SqlParameter();
      pOCDocIDParameter.ParameterName = "@POCDocID";
      pOCDocIDParameter.DbType = DbType.Guid;
      pOCDocIDParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocIDParameter.Value = pOCDocID;
      parameters.Add(pOCDocIDParameter);
      var pOCDocDateParameter = new SqlParameter();
      pOCDocDateParameter.ParameterName = "@POCDocDate";
      pOCDocDateParameter.DbType = DbType.DateTime;
      pOCDocDateParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocDateParameter.Value = pOCDocDate;
      parameters.Add(pOCDocDateParameter);
      var referenceIDParameter = new SqlParameter();
      referenceIDParameter.ParameterName = "@ReferenceID";
      referenceIDParameter.DbType = DbType.String;
      referenceIDParameter.Direction = System.Data.ParameterDirection.Input;
      referenceIDParameter.Size = 20;
      referenceIDParameter.Value = referenceID;
      parameters.Add(referenceIDParameter);
      var referenceTypeParameter = new SqlParameter();
      referenceTypeParameter.ParameterName = "@ReferenceType";
      referenceTypeParameter.DbType = DbType.String;
      referenceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      referenceTypeParameter.Size = 20;
      referenceTypeParameter.Value = referenceType;
      parameters.Add(referenceTypeParameter);
      var pOCDocJSONParameter = new SqlParameter();
      pOCDocJSONParameter.ParameterName = "@POCDocJSON";
      pOCDocJSONParameter.DbType = DbType.String;
      pOCDocJSONParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocJSONParameter.Value = pOCDocJSON;
      parameters.Add(pOCDocJSONParameter);
      var companyIDParameter = new SqlParameter();
      companyIDParameter.ParameterName = "@CompanyID";
      companyIDParameter.DbType = DbType.String;
      companyIDParameter.Direction = System.Data.ParameterDirection.Input;
      companyIDParameter.Size = 50;
      companyIDParameter.Value = companyID;
      parameters.Add(companyIDParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var lastUpdatedUTCDTParameter = new SqlParameter();
      lastUpdatedUTCDTParameter.ParameterName = "@LastUpdatedUTCDT";
      lastUpdatedUTCDTParameter.DbType = DbType.DateTime;
      lastUpdatedUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCDTParameter.Value = lastUpdatedUTCDT;
      parameters.Add(lastUpdatedUTCDTParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.POCDoc_Add", parameters);
    }
    public IEnumerable<POCDoc_GetAllResult> POCDoc_GetAll()
    {
      return ExecuteQuery<POCDoc_GetAllResult>.ExecuteStoredProcedure(this, "CDM.POCDoc_GetAll");
    }
    public IEnumerable<POCDoc_GetByIDResult> POCDoc_GetByID(Guid pOCDocID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var pOCDocIDParameter = new SqlParameter();
      pOCDocIDParameter.ParameterName = "@POCDocID";
      pOCDocIDParameter.DbType = DbType.Guid;
      pOCDocIDParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocIDParameter.Value = pOCDocID;
      parameters.Add(pOCDocIDParameter);
      return ExecuteQuery<POCDoc_GetByIDResult>.ExecuteStoredProcedure(this, "CDM.POCDoc_GetByID", parameters);
    }
    public IEnumerable<POCDoc_GetByRefIDResult> POCDoc_GetByRefID(String referenceID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var referenceIDParameter = new SqlParameter();
      referenceIDParameter.ParameterName = "@ReferenceID";
      referenceIDParameter.DbType = DbType.String;
      referenceIDParameter.Direction = System.Data.ParameterDirection.Input;
      referenceIDParameter.Size = 40;
      referenceIDParameter.Value = referenceID;
      parameters.Add(referenceIDParameter);
      return ExecuteQuery<POCDoc_GetByRefIDResult>.ExecuteStoredProcedure(this, "CDM.POCDoc_GetByRefID", parameters);
    }
    public Int32 POCDoc_Void(Guid pOCDocID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var pOCDocIDParameter = new SqlParameter();
      pOCDocIDParameter.ParameterName = "@POCDocID";
      pOCDocIDParameter.DbType = DbType.Guid;
      pOCDocIDParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocIDParameter.Value = pOCDocID;
      parameters.Add(pOCDocIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.POCDoc_Void", parameters);
    }
    public Int32 POCDoc_Remove(Guid pOCDocID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var pOCDocIDParameter = new SqlParameter();
      pOCDocIDParameter.ParameterName = "@POCDocID";
      pOCDocIDParameter.DbType = DbType.Guid;
      pOCDocIDParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocIDParameter.Value = pOCDocID;
      parameters.Add(pOCDocIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.POCDoc_Remove", parameters);
    }
    public Int32 POCDoc_Upd(Guid pOCDocID, DateTime pOCDocDate, String referenceID, String referenceType, String pOCDocJSON, String companyID, String status, DateTime lastUpdatedUTCDT, Guid auditInfoGuid)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var pOCDocIDParameter = new SqlParameter();
      pOCDocIDParameter.ParameterName = "@POCDocID";
      pOCDocIDParameter.DbType = DbType.Guid;
      pOCDocIDParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocIDParameter.Value = pOCDocID;
      parameters.Add(pOCDocIDParameter);
      var pOCDocDateParameter = new SqlParameter();
      pOCDocDateParameter.ParameterName = "@POCDocDate";
      pOCDocDateParameter.DbType = DbType.DateTime;
      pOCDocDateParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocDateParameter.Value = pOCDocDate;
      parameters.Add(pOCDocDateParameter);
      var referenceIDParameter = new SqlParameter();
      referenceIDParameter.ParameterName = "@ReferenceID";
      referenceIDParameter.DbType = DbType.String;
      referenceIDParameter.Direction = System.Data.ParameterDirection.Input;
      referenceIDParameter.Size = 40;
      referenceIDParameter.Value = referenceID;
      parameters.Add(referenceIDParameter);
      var referenceTypeParameter = new SqlParameter();
      referenceTypeParameter.ParameterName = "@ReferenceType";
      referenceTypeParameter.DbType = DbType.String;
      referenceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      referenceTypeParameter.Size = 20;
      referenceTypeParameter.Value = referenceType;
      parameters.Add(referenceTypeParameter);
      var pOCDocJSONParameter = new SqlParameter();
      pOCDocJSONParameter.ParameterName = "@POCDocJSON";
      pOCDocJSONParameter.DbType = DbType.String;
      pOCDocJSONParameter.Direction = System.Data.ParameterDirection.Input;
      pOCDocJSONParameter.Value = pOCDocJSON;
      parameters.Add(pOCDocJSONParameter);
      var companyIDParameter = new SqlParameter();
      companyIDParameter.ParameterName = "@CompanyID";
      companyIDParameter.DbType = DbType.String;
      companyIDParameter.Direction = System.Data.ParameterDirection.Input;
      companyIDParameter.Size = 50;
      companyIDParameter.Value = companyID;
      parameters.Add(companyIDParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      var lastUpdatedUTCDTParameter = new SqlParameter();
      lastUpdatedUTCDTParameter.ParameterName = "@LastUpdatedUTCDT";
      lastUpdatedUTCDTParameter.DbType = DbType.DateTime;
      lastUpdatedUTCDTParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCDTParameter.Value = lastUpdatedUTCDT;
      parameters.Add(lastUpdatedUTCDTParameter);
      var auditInfoGuidParameter = new SqlParameter();
      auditInfoGuidParameter.ParameterName = "@AuditInfoGuid";
      auditInfoGuidParameter.DbType = DbType.Guid;
      auditInfoGuidParameter.Direction = System.Data.ParameterDirection.Input;
      auditInfoGuidParameter.Value = auditInfoGuid;
      parameters.Add(auditInfoGuidParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.POCDoc_Upd", parameters);
    }
    public IEnumerable<Reference2Image_GetResult> Reference2Image_Get(Guid referenceID, String referenceType, Guid itemImageID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var referenceIDParameter = new SqlParameter();
      referenceIDParameter.ParameterName = "@ReferenceID";
      referenceIDParameter.DbType = DbType.Guid;
      referenceIDParameter.Direction = System.Data.ParameterDirection.Input;
      referenceIDParameter.Value = referenceID;
      parameters.Add(referenceIDParameter);
      var referenceTypeParameter = new SqlParameter();
      referenceTypeParameter.ParameterName = "@ReferenceType";
      referenceTypeParameter.DbType = DbType.String;
      referenceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      referenceTypeParameter.Size = 20;
      referenceTypeParameter.Value = referenceType;
      parameters.Add(referenceTypeParameter);
      var itemImageIDParameter = new SqlParameter();
      itemImageIDParameter.ParameterName = "@ItemImageID";
      itemImageIDParameter.DbType = DbType.Guid;
      itemImageIDParameter.Direction = System.Data.ParameterDirection.Input;
      itemImageIDParameter.Value = itemImageID;
      parameters.Add(itemImageIDParameter);
      return ExecuteQuery<Reference2Image_GetResult>.ExecuteStoredProcedure(this, "CDM.Reference2Image_Get", parameters);
    }
    public Int32 ReferenceImage_Add(Guid imageID, String referenceID, String referenceType, String referenceImageJson, Boolean isPrimary, String imageType, String imageCategory, String imageName, byte[] imageData, Decimal imageHeight, Decimal imageWidth, Decimal imageSize, DateTime lastUpdatedUTC)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var imageIDParameter = new SqlParameter();
      imageIDParameter.ParameterName = "@ImageID";
      imageIDParameter.DbType = DbType.Guid;
      imageIDParameter.Direction = System.Data.ParameterDirection.Input;
      imageIDParameter.Value = imageID;
      parameters.Add(imageIDParameter);
      var referenceIDParameter = new SqlParameter();
      referenceIDParameter.ParameterName = "@ReferenceID";
      referenceIDParameter.DbType = DbType.String;
      referenceIDParameter.Direction = System.Data.ParameterDirection.Input;
      referenceIDParameter.Size = 36;
      referenceIDParameter.Value = referenceID;
      parameters.Add(referenceIDParameter);
      var referenceTypeParameter = new SqlParameter();
      referenceTypeParameter.ParameterName = "@ReferenceType";
      referenceTypeParameter.DbType = DbType.String;
      referenceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      referenceTypeParameter.Size = 20;
      referenceTypeParameter.Value = referenceType;
      parameters.Add(referenceTypeParameter);
      var referenceImageJsonParameter = new SqlParameter();
      referenceImageJsonParameter.ParameterName = "@ReferenceImageJson";
      referenceImageJsonParameter.DbType = DbType.String;
      referenceImageJsonParameter.Direction = System.Data.ParameterDirection.Input;
      referenceImageJsonParameter.Value = referenceImageJson;
      parameters.Add(referenceImageJsonParameter);
      var isPrimaryParameter = new SqlParameter();
      isPrimaryParameter.ParameterName = "@IsPrimary";
      isPrimaryParameter.DbType = DbType.Boolean;
      isPrimaryParameter.Direction = System.Data.ParameterDirection.Input;
      isPrimaryParameter.Value = isPrimary;
      parameters.Add(isPrimaryParameter);
      var imageTypeParameter = new SqlParameter();
      imageTypeParameter.ParameterName = "@ImageType";
      imageTypeParameter.DbType = DbType.String;
      imageTypeParameter.Direction = System.Data.ParameterDirection.Input;
      imageTypeParameter.Size = 20;
      imageTypeParameter.Value = imageType;
      parameters.Add(imageTypeParameter);
      var imageCategoryParameter = new SqlParameter();
      imageCategoryParameter.ParameterName = "@ImageCategory";
      imageCategoryParameter.DbType = DbType.String;
      imageCategoryParameter.Direction = System.Data.ParameterDirection.Input;
      imageCategoryParameter.Size = 20;
      imageCategoryParameter.Value = imageCategory;
      parameters.Add(imageCategoryParameter);
      var imageNameParameter = new SqlParameter();
      imageNameParameter.ParameterName = "@ImageName";
      imageNameParameter.DbType = DbType.String;
      imageNameParameter.Direction = System.Data.ParameterDirection.Input;
      imageNameParameter.Size = 50;
      imageNameParameter.Value = imageName;
      parameters.Add(imageNameParameter);
      var imageDataParameter = new SqlParameter();
      imageDataParameter.ParameterName = "@ImageData";
      imageDataParameter.DbType = DbType.Binary;
      imageDataParameter.Direction = System.Data.ParameterDirection.Input;
      imageDataParameter.Value = imageData;
      parameters.Add(imageDataParameter);
      var imageHeightParameter = new SqlParameter();
      imageHeightParameter.ParameterName = "@ImageHeight";
      imageHeightParameter.DbType = DbType.Decimal;
      imageHeightParameter.Direction = System.Data.ParameterDirection.Input;
      imageHeightParameter.Value = imageHeight;
      parameters.Add(imageHeightParameter);
      var imageWidthParameter = new SqlParameter();
      imageWidthParameter.ParameterName = "@ImageWidth";
      imageWidthParameter.DbType = DbType.Decimal;
      imageWidthParameter.Direction = System.Data.ParameterDirection.Input;
      imageWidthParameter.Value = imageWidth;
      parameters.Add(imageWidthParameter);
      var imageSizeParameter = new SqlParameter();
      imageSizeParameter.ParameterName = "@ImageSize";
      imageSizeParameter.DbType = DbType.Decimal;
      imageSizeParameter.Direction = System.Data.ParameterDirection.Input;
      imageSizeParameter.Value = imageSize;
      parameters.Add(imageSizeParameter);
      var lastUpdatedUTCParameter = new SqlParameter();
      lastUpdatedUTCParameter.ParameterName = "@LastUpdatedUTC";
      lastUpdatedUTCParameter.DbType = DbType.DateTime;
      lastUpdatedUTCParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCParameter.Value = lastUpdatedUTC;
      parameters.Add(lastUpdatedUTCParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ReferenceImage_Add", parameters);
    }
    public Int32 ReferenceImage_Remove(Guid imageID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var imageIDParameter = new SqlParameter();
      imageIDParameter.ParameterName = "@ImageID";
      imageIDParameter.DbType = DbType.Guid;
      imageIDParameter.Direction = System.Data.ParameterDirection.Input;
      imageIDParameter.Value = imageID;
      parameters.Add(imageIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ReferenceImage_Remove", parameters);
    }
    public Int32 ReferenceImage_Upd(Guid imageID, String referenceID, String referenceType, String referenceImageJson, Boolean isPrimary, String imageType, String imageCategory, String imageName, byte[] imageData, Decimal imageHeight, Decimal imageWidth, Decimal imageSize, DateTime lastUpdatedUTC)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var imageIDParameter = new SqlParameter();
      imageIDParameter.ParameterName = "@ImageID";
      imageIDParameter.DbType = DbType.Guid;
      imageIDParameter.Direction = System.Data.ParameterDirection.Input;
      imageIDParameter.Value = imageID;
      parameters.Add(imageIDParameter);
      var referenceIDParameter = new SqlParameter();
      referenceIDParameter.ParameterName = "@ReferenceID";
      referenceIDParameter.DbType = DbType.String;
      referenceIDParameter.Direction = System.Data.ParameterDirection.Input;
      referenceIDParameter.Size = 36;
      referenceIDParameter.Value = referenceID;
      parameters.Add(referenceIDParameter);
      var referenceTypeParameter = new SqlParameter();
      referenceTypeParameter.ParameterName = "@ReferenceType";
      referenceTypeParameter.DbType = DbType.String;
      referenceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      referenceTypeParameter.Size = 20;
      referenceTypeParameter.Value = referenceType;
      parameters.Add(referenceTypeParameter);
      var referenceImageJsonParameter = new SqlParameter();
      referenceImageJsonParameter.ParameterName = "@ReferenceImageJson";
      referenceImageJsonParameter.DbType = DbType.String;
      referenceImageJsonParameter.Direction = System.Data.ParameterDirection.Input;
      referenceImageJsonParameter.Value = referenceImageJson;
      parameters.Add(referenceImageJsonParameter);
      var isPrimaryParameter = new SqlParameter();
      isPrimaryParameter.ParameterName = "@IsPrimary";
      isPrimaryParameter.DbType = DbType.Boolean;
      isPrimaryParameter.Direction = System.Data.ParameterDirection.Input;
      isPrimaryParameter.Value = isPrimary;
      parameters.Add(isPrimaryParameter);
      var imageTypeParameter = new SqlParameter();
      imageTypeParameter.ParameterName = "@ImageType";
      imageTypeParameter.DbType = DbType.String;
      imageTypeParameter.Direction = System.Data.ParameterDirection.Input;
      imageTypeParameter.Size = 20;
      imageTypeParameter.Value = imageType;
      parameters.Add(imageTypeParameter);
      var imageCategoryParameter = new SqlParameter();
      imageCategoryParameter.ParameterName = "@ImageCategory";
      imageCategoryParameter.DbType = DbType.String;
      imageCategoryParameter.Direction = System.Data.ParameterDirection.Input;
      imageCategoryParameter.Size = 20;
      imageCategoryParameter.Value = imageCategory;
      parameters.Add(imageCategoryParameter);
      var imageNameParameter = new SqlParameter();
      imageNameParameter.ParameterName = "@ImageName";
      imageNameParameter.DbType = DbType.String;
      imageNameParameter.Direction = System.Data.ParameterDirection.Input;
      imageNameParameter.Size = 50;
      imageNameParameter.Value = imageName;
      parameters.Add(imageNameParameter);
      var imageDataParameter = new SqlParameter();
      imageDataParameter.ParameterName = "@ImageData";
      imageDataParameter.DbType = DbType.Binary;
      imageDataParameter.Direction = System.Data.ParameterDirection.Input;
      imageDataParameter.Value = imageData;
      parameters.Add(imageDataParameter);
      var imageHeightParameter = new SqlParameter();
      imageHeightParameter.ParameterName = "@ImageHeight";
      imageHeightParameter.DbType = DbType.Decimal;
      imageHeightParameter.Direction = System.Data.ParameterDirection.Input;
      imageHeightParameter.Value = imageHeight;
      parameters.Add(imageHeightParameter);
      var imageWidthParameter = new SqlParameter();
      imageWidthParameter.ParameterName = "@ImageWidth";
      imageWidthParameter.DbType = DbType.Decimal;
      imageWidthParameter.Direction = System.Data.ParameterDirection.Input;
      imageWidthParameter.Value = imageWidth;
      parameters.Add(imageWidthParameter);
      var imageSizeParameter = new SqlParameter();
      imageSizeParameter.ParameterName = "@ImageSize";
      imageSizeParameter.DbType = DbType.Decimal;
      imageSizeParameter.Direction = System.Data.ParameterDirection.Input;
      imageSizeParameter.Value = imageSize;
      parameters.Add(imageSizeParameter);
      var lastUpdatedUTCParameter = new SqlParameter();
      lastUpdatedUTCParameter.ParameterName = "@LastUpdatedUTC";
      lastUpdatedUTCParameter.DbType = DbType.DateTime;
      lastUpdatedUTCParameter.Direction = System.Data.ParameterDirection.Input;
      lastUpdatedUTCParameter.Value = lastUpdatedUTC;
      parameters.Add(lastUpdatedUTCParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ReferenceImage_Upd", parameters);
    }
    public IEnumerable<ReferenceImages_GetByReferenceResult> ReferenceImages_GetByReference(String referenceID, String referenceType)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var referenceIDParameter = new SqlParameter();
      referenceIDParameter.ParameterName = "@ReferenceID";
      referenceIDParameter.DbType = DbType.String;
      referenceIDParameter.Direction = System.Data.ParameterDirection.Input;
      referenceIDParameter.Size = 36;
      referenceIDParameter.Value = referenceID;
      parameters.Add(referenceIDParameter);
      var referenceTypeParameter = new SqlParameter();
      referenceTypeParameter.ParameterName = "@ReferenceType";
      referenceTypeParameter.DbType = DbType.String;
      referenceTypeParameter.Direction = System.Data.ParameterDirection.Input;
      referenceTypeParameter.Size = 20;
      referenceTypeParameter.Value = referenceType;
      parameters.Add(referenceTypeParameter);
      return ExecuteQuery<ReferenceImages_GetByReferenceResult>.ExecuteStoredProcedure(this, "CDM.ReferenceImages_GetByReference", parameters);
    }
    public Int32 ControlSysNo_Add(String companyCode, String controlSysNoTypeID, String prefix, Int32 billValue, Int32 totLength)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var companyCodeParameter = new SqlParameter();
      companyCodeParameter.ParameterName = "@CompanyCode";
      companyCodeParameter.DbType = DbType.String;
      companyCodeParameter.Direction = System.Data.ParameterDirection.Input;
      companyCodeParameter.Size = 20;
      companyCodeParameter.Value = companyCode;
      parameters.Add(companyCodeParameter);
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      var prefixParameter = new SqlParameter();
      prefixParameter.ParameterName = "@Prefix";
      prefixParameter.DbType = DbType.String;
      prefixParameter.Direction = System.Data.ParameterDirection.Input;
      prefixParameter.Size = 20;
      prefixParameter.Value = prefix;
      parameters.Add(prefixParameter);
      var billValueParameter = new SqlParameter();
      billValueParameter.ParameterName = "@BillValue";
      billValueParameter.DbType = DbType.Int32;
      billValueParameter.Direction = System.Data.ParameterDirection.Input;
      billValueParameter.Value = billValue;
      parameters.Add(billValueParameter);
      var totLengthParameter = new SqlParameter();
      totLengthParameter.ParameterName = "@TotLength";
      totLengthParameter.DbType = DbType.Int32;
      totLengthParameter.Direction = System.Data.ParameterDirection.Input;
      totLengthParameter.Value = totLength;
      parameters.Add(totLengthParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ControlSysNo_Add", parameters);
    }
    public Int32 ControlSysNoType_Upd(String controlSysNoTypeID, String description, Int32 sortID, String status)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      var descriptionParameter = new SqlParameter();
      descriptionParameter.ParameterName = "@Description";
      descriptionParameter.DbType = DbType.String;
      descriptionParameter.Direction = System.Data.ParameterDirection.Input;
      descriptionParameter.Size = 50;
      descriptionParameter.Value = description;
      parameters.Add(descriptionParameter);
      var sortIDParameter = new SqlParameter();
      sortIDParameter.ParameterName = "@SortID";
      sortIDParameter.DbType = DbType.Int32;
      sortIDParameter.Direction = System.Data.ParameterDirection.Input;
      sortIDParameter.Value = sortID;
      parameters.Add(sortIDParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ControlSysNoType_Upd", parameters);
    }
    public Int32 ControlSysNo_Del(String companyID, String controlSysNoTypeID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var companyIDParameter = new SqlParameter();
      companyIDParameter.ParameterName = "@CompanyID";
      companyIDParameter.DbType = DbType.String;
      companyIDParameter.Direction = System.Data.ParameterDirection.Input;
      companyIDParameter.Size = 20;
      companyIDParameter.Value = companyID;
      parameters.Add(companyIDParameter);
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ControlSysNo_Del", parameters);
    }
    public IEnumerable<ControlSysNo_GetResult> ControlSysNo_Get(String companyCode, String controlSysNoTypeID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var companyCodeParameter = new SqlParameter();
      companyCodeParameter.ParameterName = "@CompanyCode";
      companyCodeParameter.DbType = DbType.String;
      companyCodeParameter.Direction = System.Data.ParameterDirection.Input;
      companyCodeParameter.Size = 20;
      companyCodeParameter.Value = companyCode;
      parameters.Add(companyCodeParameter);
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      return ExecuteQuery<ControlSysNo_GetResult>.ExecuteStoredProcedure(this, "CDM.ControlSysNo_Get", parameters);
    }
    public Int32 ControlSysNo_Upd(String companyID, String controlSysNoTypeID, String prefix, Int32 billValue, Int32 totLength)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var companyIDParameter = new SqlParameter();
      companyIDParameter.ParameterName = "@CompanyID";
      companyIDParameter.DbType = DbType.String;
      companyIDParameter.Direction = System.Data.ParameterDirection.Input;
      companyIDParameter.Size = 20;
      companyIDParameter.Value = companyID;
      parameters.Add(companyIDParameter);
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      var prefixParameter = new SqlParameter();
      prefixParameter.ParameterName = "@Prefix";
      prefixParameter.DbType = DbType.String;
      prefixParameter.Direction = System.Data.ParameterDirection.Input;
      prefixParameter.Size = 20;
      prefixParameter.Value = prefix;
      parameters.Add(prefixParameter);
      var billValueParameter = new SqlParameter();
      billValueParameter.ParameterName = "@BillValue";
      billValueParameter.DbType = DbType.Int32;
      billValueParameter.Direction = System.Data.ParameterDirection.Input;
      billValueParameter.Value = billValue;
      parameters.Add(billValueParameter);
      var totLengthParameter = new SqlParameter();
      totLengthParameter.ParameterName = "@TotLength";
      totLengthParameter.DbType = DbType.Int32;
      totLengthParameter.Direction = System.Data.ParameterDirection.Input;
      totLengthParameter.Value = totLength;
      parameters.Add(totLengthParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ControlSysNo_Upd", parameters);
    }
    public Int32 ControlSysNoType_Add(String controlSysNoTypeID, String description, Int32 sortID, String status)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      var descriptionParameter = new SqlParameter();
      descriptionParameter.ParameterName = "@Description";
      descriptionParameter.DbType = DbType.String;
      descriptionParameter.Direction = System.Data.ParameterDirection.Input;
      descriptionParameter.Size = 50;
      descriptionParameter.Value = description;
      parameters.Add(descriptionParameter);
      var sortIDParameter = new SqlParameter();
      sortIDParameter.ParameterName = "@SortID";
      sortIDParameter.DbType = DbType.Int32;
      sortIDParameter.Direction = System.Data.ParameterDirection.Input;
      sortIDParameter.Value = sortID;
      parameters.Add(sortIDParameter);
      var statusParameter = new SqlParameter();
      statusParameter.ParameterName = "@Status";
      statusParameter.DbType = DbType.String;
      statusParameter.Direction = System.Data.ParameterDirection.Input;
      statusParameter.Size = 20;
      statusParameter.Value = status;
      parameters.Add(statusParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ControlSysNoType_Add", parameters);
    }
    public Int32 ControlSysNoType_Del(String controlSysNoTypeID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ControlSysNoType_Del", parameters);
    }
    public Int32 ControlSysNoType_Exists(String controlSysNoTypeID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      return ExecuteNonQuery.ExecuteStoredProcedure(this, "CDM.ControlSysNoType_Exists", parameters);
    }
    public IEnumerable<ControlSysNoType_GetResult> ControlSysNoType_Get(String controlSysNoTypeID)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      return ExecuteQuery<ControlSysNoType_GetResult>.ExecuteStoredProcedure(this, "CDM.ControlSysNoType_Get", parameters);
    }
    // Please Verify SP - Not Used
    public IEnumerable<GetNextBillingIDResult> GetNextBillingID(String controlSysNoTypeID, ref String nxtBillNo)
    {
      List<SqlParameter> parameters = new List<SqlParameter>();
      var controlSysNoTypeIDParameter = new SqlParameter();
      controlSysNoTypeIDParameter.ParameterName = "@ControlSysNoTypeID";
      controlSysNoTypeIDParameter.DbType = DbType.String;
      controlSysNoTypeIDParameter.Direction = System.Data.ParameterDirection.Input;
      controlSysNoTypeIDParameter.Size = 20;
      controlSysNoTypeIDParameter.Value = controlSysNoTypeID;
      parameters.Add(controlSysNoTypeIDParameter);
      var nxtBillNoParameter = new SqlParameter();
      nxtBillNoParameter.ParameterName = "@NxtBillNo";
      nxtBillNoParameter.DbType = DbType.String;
      nxtBillNoParameter.Size = 20;
      nxtBillNoParameter.Direction = System.Data.ParameterDirection.Output;
      parameters.Add(nxtBillNoParameter);
      var result1 = ExecuteNonQuery<GetNextBillingIDResult>.ExecuteStoredProcedure(this, "CDM.GetNextBillingID", ref parameters);
      try
      {
        nxtBillNo = (String)parameters[parameters.IndexOf(nxtBillNoParameter)].Value;
      }
      catch (Exception ex)
      {
      }
      return result1;
    }



    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseSqlServer(_CDMConnectionString);
      }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<EntityMetaInfoDetail_GetResult>().HasNoKey();
            modelBuilder.Entity<EntityMetaInfo_GetResult>().HasNoKey();
            //modelBuilder.Entity<EntityMetaInfoDetails_GetResult>().HasNoKey();
            modelBuilder.Entity<EntityMetaInfoDetails_GetAllResult>().HasNoKey();
            modelBuilder.Entity<EntityMetaInfos_GetResult>().HasNoKey();
            modelBuilder.Entity<EntityMetaInfos_GetAllResult>().HasNoKey();
            modelBuilder.Entity<Report_GetAllResult>().HasNoKey();

            modelBuilder.Entity<RouteEvent_GetAllResult>().HasNoKey();
            modelBuilder.Entity<RouteEvent_GetByEventDateTimeResult>().HasNoKey();
            modelBuilder.Entity<RouteEvent_GetByIDResult>().HasNoKey();
            modelBuilder.Entity<Report_GetAllResult>().HasNoKey();
      modelBuilder.Entity<Report_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<Report2ScheduleEmail_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<Report2ScheduleEmail_GetAllResult>().HasNoKey();
      modelBuilder.Entity<SignalRLog_GetAllResult>().HasNoKey();
      modelBuilder.Entity<SignalRLog_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<SignalRLog_GetByTypeResult>().HasNoKey();
      modelBuilder.Entity<DataSyncInfo_GetAllResult>().HasNoKey();
      modelBuilder.Entity<DataSyncInfo_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<DataSyncInfo2Device_GetAllResult>().HasNoKey();
      modelBuilder.Entity<DataSyncInfo2Device_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<RoutineDetail_GetResult>().HasNoKey();
      modelBuilder.Entity<RoutineDetail_GetByRoutineHeaderIDResult>().HasNoKey();
      modelBuilder.Entity<RoutineHeader_GetResult>().HasNoKey();
      modelBuilder.Entity<RoutineHeader_GetRefTypeAndRefIDResult>().HasNoKey();
      modelBuilder.Entity<References2Notes_GetAllResult>().HasNoKey();
      modelBuilder.Entity<References2Notes_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<Activities_AllResult>().HasNoKey();
      modelBuilder.Entity<Activities_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<Activities2Tasks_AllResult>().HasNoKey();
      modelBuilder.Entity<Activities2Tasks_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<GetNextBillingIDExcptSvrID_OUTResult>().HasNoKey();
      modelBuilder.Entity<Tasks_AllResult>().HasNoKey();
      modelBuilder.Entity<Tasks_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<Activities2Tasks_GetByActivitiesIDResult>().HasNoKey();
      modelBuilder.Entity<Equipment_GetAllResult>().HasNoKey();
      modelBuilder.Entity<Equipment_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<HResource_GetAllResult>().HasNoKey();
      modelBuilder.Entity<HResource_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<CurrencyExchange_GetAllResult>().HasNoKey();
      modelBuilder.Entity<CurrencyExchange_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<POCDoc_GetAllResult>().HasNoKey();
      modelBuilder.Entity<POCDoc_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<POCDoc_GetByRefIDResult>().HasNoKey();
      modelBuilder.Entity<Reference2Image_GetResult>().HasNoKey();
      modelBuilder.Entity<ReferenceImages_GetByReferenceResult>().HasNoKey();
      modelBuilder.Entity<ControlSysNo_GetResult>().HasNoKey();
      modelBuilder.Entity<ControlSysNoType_GetResult>().HasNoKey();
      modelBuilder.Entity<GetNextBillingIDResult>().HasNoKey();
      modelBuilder.Entity<Project_GetAllResult>().HasNoKey();
      modelBuilder.Entity<Project_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<Task_GetAllResult>().HasNoKey();
      modelBuilder.Entity<Task_GetByIDResult>().HasNoKey();
      modelBuilder.Entity<Activity_GetAllResult>().HasNoKey();
      modelBuilder.Entity<Activity_GetByIDResult>().HasNoKey();

      base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

  }

}
