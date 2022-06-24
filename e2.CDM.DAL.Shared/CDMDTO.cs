using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using System.Xml.Linq; 
namespace e2.CDM.DAL.Lib
{
	public class EntityMetaInfoDetail_GetResult
	{
		public String EntityMetaInfoDetailID { get; set; }
		public String MetaInfoTypeID { get; set; }
		public String EntityMetaInfoID { get; set; }
		public String Asile { get; set; }
		public String Rack { get; set; }
		public String Position { get; set; }
		public String Shelf { get; set; }
		public String BinLocation { get; set; }
		public String EntityMetaInfoDetailJSON { get; set; }
		public String AvailStatusID { get; set; }
	}
	public class EntityMetaInfo_GetResult
	{
		public String EntityMetaInfoID { get; set; }
		public String LocationMetaInfoName { get; set; }
		public String AvailStatusID { get; set; }
	}
	public class EntityMetaInfoDetails_GetAllResult
	{
		public String EntityMetaInfoDetailID { get; set; }
		public String MetaInfoTypeID { get; set; }
		public String EntityMetaInfoID { get; set; }
		public String Asile { get; set; }
		public String Rack { get; set; }
		public String Position { get; set; }
		public String Shelf { get; set; }
		public String BinLocation { get; set; }
		public String EntityMetaInfoDetailJSON { get; set; }
		public String AvailStatusID { get; set; }
	}
	public class EntityMetaInfos_GetResult
	{
		public String EntityMetaInfoID { get; set; }
		public String LocationMetaInfoName { get; set; }
		public String AvailStatusID { get; set; }
	}
	public class EntityMetaInfos_GetAllResult
	{
		public String EntityMetaInfoID { get; set; }
		public String LocationMetaInfoName { get; set; }
		public String AvailStatusID { get; set; }
	}
	public class RouteEvent_GetAllResult
	{
		public Guid EventID { get; set; }
		public DateTime EventDateTime { get; set; }
		public String EventStatus { get; set; }
		public String DriverID { get; set; }
		public String RouteID { get; set; }
		public String RouteStatus { get; set; }
		public String RouteEventJSON { get; set; }
	}
	public class RouteEvent_GetByEventDateTimeResult
	{
		public Guid EventID { get; set; }
		public DateTime EventDateTime { get; set; }
		public String EventStatus { get; set; }
		public String DriverID { get; set; }
		public String RouteID { get; set; }
		public String RouteStatus { get; set; }
		public String RouteEventJSON { get; set; }
	}
	public class RouteEvent_GetByIDResult
	{
		public Guid EventID { get; set; }
		public DateTime EventDateTime { get; set; }
		public String EventStatus { get; set; }
		public String DriverID { get; set; }
		public String RouteID { get; set; }
		public String RouteStatus { get; set; }
		public String RouteEventJSON { get; set; }
	}
	public class Report_GetAllResult
	{
		public Guid ReportID { get; set; }
		public String ReportJSON { get; set; }
		public String ReportName { get; set; }
		public String DisplayName { get; set; }
		public String ReportMRTstr { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Report_GetByIDResult
	{
		public Guid ReportID { get; set; }
		public String ReportJSON { get; set; }
		public String ReportName { get; set; }
		public String DisplayName { get; set; }
		public String ReportMRTstr { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Report2ScheduleEmail_GetByIDResult
	{
		public Guid Report2ScheduleEmailID { get; set; }
		public Guid ReportID { get; set; }
		public String DateRange { get; set; }
		public DateTime? Time { get; set; }
		public String Frequency { get; set; }
		public String Report2ScheduleEmailJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Report2ScheduleEmail_GetAllResult
	{
		public Guid Report2ScheduleEmailID { get; set; }
		public Guid ReportID { get; set; }
		public String DateRange { get; set; }
		public DateTime? Time { get; set; }
		public String Frequency { get; set; }
		public String Report2ScheduleEmailJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class SignalRLog_GetAllResult
	{
		public Guid SignalRLogID { get; set; }
		public DateTime? LogDate { get; set; }
		public String CallType { get; set; }
		public Guid? DeviceID { get; set; }
		public String AuditInfoJSON { get; set; }
		public String CallInfo { get; set; }
		public String SignalRLogJSON { get; set; }
		public String Status { get; set; }
	}
	public class SignalRLog_GetByIDResult
	{
		public Guid SignalRLogID { get; set; }
		public DateTime? LogDate { get; set; }
		public String CallType { get; set; }
		public Guid? DeviceID { get; set; }
		public String AuditInfoJSON { get; set; }
		public String CallInfo { get; set; }
		public String SignalRLogJSON { get; set; }
		public String Status { get; set; }
	}
	public class SignalRLog_GetByTypeResult
	{
		public Guid SignalRLogID { get; set; }
		public DateTime? LogDate { get; set; }
		public String CallType { get; set; }
		public Guid? DeviceID { get; set; }
		public String AuditInfoJSON { get; set; }
		public String CallInfo { get; set; }
		public String SignalRLogJSON { get; set; }
		public String Status { get; set; }
	}
	public class DataSyncInfo_GetAllResult
  {
	public Guid DataSyncInfoID { get; set; }
	public String DataSyncInfoJSON { get; set; }
	public String CompanyID { get; set; }
	public String DataSyncInfoType { get; set; }
	public String AuditInfoJson { get; set; }
	public DateTime LastUpdateUTCDT { get; set; }
  }
  public class DataSyncInfo_GetByIDResult
  {
	public Guid DataSyncInfoID { get; set; }
	public String DataSyncInfoJSON { get; set; }
	public String CompanyID { get; set; }
	public String DataSyncInfoType { get; set; }
	public String AuditInfoJson { get; set; }
	public DateTime LastUpdateUTCDT { get; set; }
  }
  public class DataSyncInfo2Device_GetAllResult
  {
	public Guid DataSyncInfo2DeviceID { get; set; }
	public String DataSyncInfo2DeviceJSON { get; set; }
	public String DeviceID { get; set; }
	public String DataSyncInfo2DeviceType { get; set; }
	public String RecordCount { get; set; }
	public String AuditInfoJson { get; set; }
	public DateTime LastUpdateUTCDT { get; set; }
  }
  public class DataSyncInfo2Device_GetByIDResult
  {
	public Guid DataSyncInfo2DeviceID { get; set; }
	public String DataSyncInfo2DeviceJSON { get; set; }
	public String DeviceID { get; set; }
	public String DataSyncInfo2DeviceType { get; set; }
	public String RecordCount { get; set; }
	public String AuditInfoJson { get; set; }
	public DateTime LastUpdateUTCDT { get; set; }
  }
  public class RoutineDetail_GetResult
	{
		public Guid RoutineDetailID { get; set; }
		public Guid RoutineHeaderID { get; set; }
		public String ActivityID { get; set; }
		public String TaskID { get; set; }
		public String Frequency { get; set; }
		public String ClassName { get; set; }
		public String InterfaceName { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public String AvailStatusID { get; set; }
		public String RoutineDetailJSON { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class RoutineDetail_GetByRoutineHeaderIDResult
	{
		public Guid RoutineDetailID { get; set; }
		public Guid RoutineHeaderID { get; set; }
		public String ActivityID { get; set; }
		public String TaskID { get; set; }
		public String Frequency { get; set; }
		public String ClassName { get; set; }
		public String InterfaceName { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public String AvailStatusID { get; set; }
		public String RoutineDetailJSON { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class RoutineHeader_GetResult
	{
		public Guid RoutineHeaderID { get; set; }
		public DateTime RoutineDate { get; set; }
		public String RefType { get; set; }
		public String RefID { get; set; }
		public String Remark { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public String AvailStatusID { get; set; }
		public String RoutineHeaderJSON { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class RoutineHeader_GetRefTypeAndRefIDResult
	{
		public Guid RoutineHeaderID { get; set; }
		public DateTime? RoutineDate { get; set; }
		public String RefType { get; set; }
		public String RefID { get; set; }
		public String Remark { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public String AvailStatusID { get; set; }
		public String RoutineHeaderJSON { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class References2Notes_GetAllResult
	{
		public Guid References2NotesID { get; set; }
		public String RefType { get; set; }
		public String RefID { get; set; }
		public String Notes { get; set; }
		public String References2NotesJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class References2Notes_GetByIDResult
	{
		public Guid References2NotesID { get; set; }
		public String RefType { get; set; }
		public String RefID { get; set; }
		public String Notes { get; set; }
		public String References2NotesJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Project_GetAllResult
	{
		public String ProjectID { get; set; }
		public String ProjectJSON { get; set; }
		public String CompanyID { get; set; }
		public String LocationID { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Project_GetByIDResult
	{
		public String ProjectID { get; set; }
		public String ProjectJSON { get; set; }
		public String CompanyID { get; set; }
		public String LocationID { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Task_GetAllResult
	{
		public String TaskID { get; set; }
		public String TaskJSON { get; set; } 
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Task_GetByIDResult
	{
		public String TaskID { get; set; }
		public String TaskJSON { get; set; } 
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Activity_GetAllResult
	{
		public String ActivityID { get; set; }
		public String ActivityJSON { get; set; } 
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Activity_GetByIDResult
	{
		public String ActivityID { get; set; }
		public String ActivityJSON { get; set; } 
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Activities_AllResult
	{
		public String ActivitiesID { get; set; }
		public String ActivitiesJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Activities_GetByIDResult
	{
		public String ActivitiesID { get; set; }
		public String ActivitiesJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Activities2Tasks_AllResult
	{
		public Guid Activities2TasksID { get; set; }
		public String ActivitiesID { get; set; }
		public String TasksID { get; set; }
		public String Activities2TasksJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Activities2Tasks_GetByIDResult
	{
		public Guid Activities2TasksID { get; set; }
		public String ActivitiesID { get; set; }
		public String TasksID { get; set; }
		public String Activities2TasksJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class GetNextBillingIDExcptSvrID_OUTResult
	{
		public String Column1 { get; set; }
	}
	public class Tasks_AllResult
	{
		public String TasksID { get; set; }
		public String TasksJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Tasks_GetByIDResult
	{
		public String TasksID { get; set; }
		public String TasksJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Activities2Tasks_GetByActivitiesIDResult
	{
		public Guid Activities2TasksID { get; set; }
		public String ActivitiesID { get; set; }
		public String TasksID { get; set; }
		public String Activities2TasksJSON { get; set; }
		public String Status { get; set; }
		public Guid AuditInfoGuid { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
	}
	public class Equipment_GetAllResult
	{
		public String EquipmentID { get; set; }
		public String EquipmentType { get; set; }
		public String EquipmentJSON { get; set; }
		public String Status { get; set; }
		public DateTime? LastUpdatedUTCDT { get; set; }
		public Guid AuditInfoGuid { get; set; }
	}
	public class Equipment_GetByIDResult
	{
		public String EquipmentID { get; set; }
		public String EquipmentType { get; set; }
		public String EquipmentJSON { get; set; }
		public String Status { get; set; }
		public DateTime? LastUpdatedUTCDT { get; set; }
		public Guid AuditInfoGuid { get; set; }
	}
	public class HResource_GetAllResult
	{
		public String HResourceID { get; set; }
		public String ResourceType { get; set; }
		public String HResourceJSON { get; set; }
		public String Status { get; set; }
		public DateTime? LastUpdatedUTCDT { get; set; }
		public Guid AuditInfoGuid { get; set; }
	}
	public class HResource_GetByIDResult
	{
		public String HResourceID { get; set; }
		public String ResourceType { get; set; }
		public String HResourceJSON { get; set; }
		public String Status { get; set; }
		public DateTime? LastUpdatedUTCDT { get; set; }
		public Guid AuditInfoGuid { get; set; }
	}
	public class CurrencyExchange_GetAllResult
	{
		public Guid CurrencyExchangeID { get; set; }
		public DateTime? CurrencyExchangeDate { get; set; }
		public String CurrencyExchangeJSON { get; set; }
		public String Status { get; set; }
		public DateTime? LastUpdatedUTCDT { get; set; }
		public Guid AuditInfoGuid { get; set; }
	}
	public class CurrencyExchange_GetByIDResult
	{
		public Guid CurrencyExchangeID { get; set; }
		public DateTime? CurrencyExchangeDate { get; set; }
		public String CurrencyExchangeJSON { get; set; }
		public String Status { get; set; }
		public DateTime? LastUpdatedUTCDT { get; set; }
		public Guid AuditInfoGuid { get; set; }
	}
	public class POCDoc_GetAllResult
	{
		public Guid POCDocID { get; set; }
		public DateTime POCDocDate { get; set; }
		public String ReferenceID { get; set; }
		public String ReferenceType { get; set; }
		public String POCDocJSON { get; set; }
		public String Status { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
		[NotMapped]
		public Guid AuditInfoGuid { get; set; }
	}
	public class POCDoc_GetByIDResult
	{
		public Guid POCDocID { get; set; }
		public DateTime POCDocDate { get; set; }
		public String ReferenceID { get; set; }
		public String ReferenceType { get; set; }
		public String POCDocJSON { get; set; }
		public String CompanyID { get; set; }
		public String Status { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
		  [NotMapped]
		  public Guid AuditInfoGuid { get; set; }
	}
	public class POCDoc_GetByRefIDResult
	{
		public Guid POCDocID { get; set; }
		public DateTime POCDocDate { get; set; }
		public String ReferenceID { get; set; }
		public String ReferenceType { get; set; }
		public String POCDocJSON { get; set; }
		public String CompanyID { get; set; }
		public String Status { get; set; }
		public DateTime LastUpdateUTCDT { get; set; }
		[NotMapped]
		public Guid AuditInfoGuid { get; set; }
	}
	public class Reference2Image_GetResult
	{
		public String ReferenceID { get; set; }
		public String ReferenceType { get; set; }
		public Guid ItemImageID { get; set; }
		public String ReferenceImageJson { get; set; }
		public Boolean? IsPrimary { get; set; }
	}
	public class ReferenceImages_GetByReferenceResult
	{
		public String ReferenceID { get; set; }
		public String ReferenceType { get; set; }
		public Guid ImageID { get; set; }
		public String ReferenceImageJson { get; set; }
		public Boolean? IsPrimary { get; set; }
		public byte[] ImageData { get; set; }
		public String ImageType { get; set; }
		public String ImageCategory { get; set; }
		public String ImageName { get; set; }
		public Decimal ImgHeight { get; set; }
		public Decimal ImgWidth { get; set; }
		public Decimal ImgSize { get; set; }
	}
	public class ControlSysNo_GetResult
	{
		public String CompanyID { get; set; }
		public String ControlSysNoTypeID { get; set; }
		public String Prefix { get; set; }
		public Int32? BillValue { get; set; }
		public Int32? TotLength { get; set; }
	}
	public class ControlSysNoType_GetResult
	{
		public String ControlSysNoTypeID { get; set; }
		public String Description { get; set; }
		public Int32? SortID { get; set; }
		public String Status { get; set; }
	}
	public class GetNextBillingIDResult
	{
		public String NextBillNo { get; set; }
	}

}
