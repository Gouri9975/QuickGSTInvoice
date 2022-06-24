using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{


  [Serializable()]
  public class DataSyncInfo : Csla.BusinessBase<DataSyncInfo>
  {

    #region Constuctor
    public DataSyncInfo()
    { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<Guid> DataSyncInfoIDProperty = RegisterProperty<Guid>(c => c.DataSyncInfoID);
    public Guid DataSyncInfoID
    {
      get { return GetProperty(DataSyncInfoIDProperty); }
      set { SetProperty(DataSyncInfoIDProperty, value); }
    }
    public static readonly PropertyInfo<DataSyncInfoJsonBO> DataSyncInfoJsonBOProperty = RegisterProperty<DataSyncInfoJsonBO>(c => c.DataSyncInfoJsonBO);
    public DataSyncInfoJsonBO DataSyncInfoJsonBO
    {
      get { return GetProperty(DataSyncInfoJsonBOProperty); }
      set { SetProperty(DataSyncInfoJsonBOProperty, value); }
    }
    public static readonly PropertyInfo<string> CompanyIDProperty = RegisterProperty<string>(c => c.CompanyID);
    public string CompanyID
    {
      get { return GetProperty(CompanyIDProperty); }
      set { SetProperty(CompanyIDProperty, value); }
    }
    public static readonly PropertyInfo<string> DataSyncInfoTypeProperty = RegisterProperty<string>(c => c.DataSyncInfoType);
    public string DataSyncInfoType
    {
      get { return GetProperty(DataSyncInfoTypeProperty); }
      set { SetProperty(DataSyncInfoTypeProperty, value); }
    }
    public static readonly PropertyInfo<AuditInfoJsonBO> AuditInfoJsonBOProperty = RegisterProperty<AuditInfoJsonBO>(c => c.AuditInfoJsonBO);
    public AuditInfoJsonBO AuditInfoJsonBO
    {
      get { return GetProperty(AuditInfoJsonBOProperty); }
      set { SetProperty(AuditInfoJsonBOProperty, value); }
    }

    public static readonly PropertyInfo<DateTime> LastUpdateUTCDTProperty = RegisterProperty<DateTime>(c => c.LastUpdateUTCDT);
    public DateTime LastUpdateUTCDT
    {
      get { return GetProperty(LastUpdateUTCDTProperty); }
      set { SetProperty(LastUpdateUTCDTProperty, value); }
    }
    protected override object GetIdValue()
    {
      return DataSyncInfoID;
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

    public static async System.Threading.Tasks.Task<DataSyncInfo> NewDataSyncInfoAsync()
    {
      try
      {
        if (!CanAddObject())
          throw new System.Security.SecurityException("User not authorized to add a DataSyncInfo");
        return await DataPortal.CreateAsync<DataSyncInfo>();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public static async System.Threading.Tasks.Task<DataSyncInfo> GetDataSyncInfoAsync(Guid ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a DataSyncInfo");
      return await DataPortal.FetchAsync<DataSyncInfo>(new Criteria(ID));
    }

    public static async void DeleteDataSyncInfoAsync(Guid ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a Task");
      await DataPortal.DeleteAsync<DataSyncInfo>(new Criteria(ID));
    }
#if !SILVERLIGHT && !NETFX_CORE
    public static DataSyncInfo NewDataSyncInfo()
    {
      if (!CanAddObject())
        throw new System.Security.SecurityException("User not authorized to add a Task");
      return DataPortal.Create<DataSyncInfo>();
    }
    public static DataSyncInfo GetDataSyncInfo(Guid ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a Task");
      return DataPortal.Fetch<DataSyncInfo>(new Criteria(ID));
    }
    public static void DeleteDataSyncInfo(Guid ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a Task");
      DataPortal.Delete<DataSyncInfo>(new Criteria(ID));
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
      DataSyncInfoID = Guid.NewGuid();
      LastUpdateUTCDT = DateTime.UtcNow;
      DataSyncInfoJsonBO = DataSyncInfoJsonBO.NewDataSyncInfoJson();
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
          var data = mgr.DataContext.DataSyncInfo_GetByID(criteria.ID).FirstOrDefault();
          if (data != null)
          {
            DataSyncInfoID = data.DataSyncInfoID;
            CompanyID = data.CompanyID;
            DataSyncInfoType = data.DataSyncInfoType;
            LastUpdateUTCDT = data.LastUpdateUTCDT;
            if (!string.IsNullOrEmpty(data.DataSyncInfoJSON))
            {
              CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.DataSyncInfoJSON);
              if (CDMdto.ClassName.Equals("DataSyncInfoJson"))
                DataSyncInfoJsonBO = DataPortal.FetchChild<DataSyncInfoJsonBO>(data.DataSyncInfoJSON);
            }
            if (!string.IsNullOrEmpty(data.AuditInfoJson))
            {
              CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.AuditInfoJson);
              AuditInfoJsonBO = DataPortal.FetchChild<AuditInfoJsonBO>(data.AuditInfoJson);
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
          string auditInfoJsonBOStr = null;
          if (AuditInfoJsonBO != null)
          {
            auditInfoJsonBOStr = OdataCDMJson<AuditInfoJsonDTO>.GetJsonString(AuditInfoJsonBO.ConvertToDTO());
          }
          string DataSyncInfoJsonBOStr = null;
          if (DataSyncInfoJsonBO != null)
          {
            DataSyncInfoJsonBOStr = OdataCDMJson<DataSyncInfoJsonDTO>.GetJsonString(DataSyncInfoJsonBO.ConvertToDTO());
          }
          mgr.DataContext.DataSyncInfo_Add(DataSyncInfoID, DataSyncInfoJsonBOStr, auditInfoJsonBOStr,
            CompanyID, DataSyncInfoType, DateTime.Now);
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
          string auditInfoJsonBOStr = null;
          if (AuditInfoJsonBO != null)
          {
            auditInfoJsonBOStr = OdataCDMJson<AuditInfoJsonDTO>.GetJsonString(AuditInfoJsonBO.ConvertToDTO());
          }
          string DataSyncInfoJsonBOStr = null;
          if (DataSyncInfoJsonBO != null)
          {
            DataSyncInfoJsonBOStr = OdataCDMJson<DataSyncInfoJsonDTO>.GetJsonString(DataSyncInfoJsonBO.ConvertToDTO());
          }
          mgr.DataContext.DataSyncInfo_Upd(DataSyncInfoID, DataSyncInfoJsonBOStr, auditInfoJsonBOStr, CompanyID, DataSyncInfoType, DateTime.UtcNow);
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
        //mgr.DataContext.DataSyncInfo_Void(criteria.ID);
      }//using
    }
    #endregion //Data Access - Delete

#endif
    #endregion //Data Access
  }

  #region DataSyncInfoJson

  #region DataSyncInfoJsonDTO

  public class DataSyncInfoJsonDTO
  {
    public string DataSyncInfoName { get; set; }

    public string DataSyncInfoDesc { get; set; }

    public string ClassName { get; set; }
    public DataSyncInfoJsonDTO()
    {
      ClassName = "DataSyncInfoJson";
    }
  }
  #endregion

  [Serializable()]
  public class DataSyncInfoJsonBO : BusinessBase<DataSyncInfoJsonBO>
  {
    #region Constructor
    public DataSyncInfoJsonBO()
    {
      MarkAsChild();
    }

    public DataSyncInfoJsonDTO ConvertToDTO()
    {
      DataSyncInfoJsonDTO b = new DataSyncInfoJsonDTO();
      b.DataSyncInfoName = this.DataSyncInfoName;
      b.DataSyncInfoDesc = this.DataSyncInfoDesc;
      return b;
    }
    #endregion

    #region Business Properties

    public static readonly PropertyInfo<string> DataSyncInfoDescProperty = RegisterProperty<string>(c => c.DataSyncInfoDesc);
    public string DataSyncInfoDesc
    {
      get { return GetProperty(DataSyncInfoDescProperty); }
      set { SetProperty(DataSyncInfoDescProperty, value); }
    }
    public static readonly PropertyInfo<string> DataSyncInfoNameProperty = RegisterProperty<string>(c => c.DataSyncInfoName);
    public string DataSyncInfoName
    {
      get { return GetProperty(DataSyncInfoNameProperty); }
      set { SetProperty(DataSyncInfoNameProperty, value); }
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

    public static DataSyncInfoJsonBO NewDataSyncInfoJson()
    {
      return DataPortal.CreateChild<DataSyncInfoJsonBO>();
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
        DataSyncInfoJsonDTO DataSyncInfoJson = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSyncInfoJsonDTO>(BlogJsondtojson);
        if (DataSyncInfoJson != null)
          Child_Fetch(DataSyncInfoJson);
      }
    }
    private void Child_Fetch(DataSyncInfoJsonDTO data)
    {

      DataSyncInfoDesc = data.DataSyncInfoDesc;
      DataSyncInfoName = data.DataSyncInfoName;
      MarkOld();
    }

    #region Data Access - Insert

    private void Child_Insert(DataSyncInfo parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Insert

    #region Data Access - Update
    private void Child_Update(DataSyncInfo parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Update

    #region Data Access - Delete
    private void Child_DeleteSelf(DataSyncInfo parent)
    {
      MarkNew();
    }
    #endregion //Data Access - Delete
#endif
  }
  #endregion

  #region AccountGroupJson

  #region AuditInfoJsonDTO
  public class GeoInfo
  {
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Altitude { get; set; }
    public string LandMark { get; set; }
    public string ClassName { get; set; }
  }
  public class AuditInfoJsonDTO
  {
    public string UserName { get; set; }
    public string OperatorName { get; set; }
    public string TerminalID { get; set; }
    public string DeviceID { get; set; }
    public string IpAddress { get; set; }
    public string HostName { get; set; }
    //public GeoInfo GeoInfo { get; set; }
    //public string ClassName { get; set; }
    public AuditInfoJsonDTO()
    {
      //ClassName = "AccountGroupJson";
    }

  }
  #endregion

  [Serializable()]
  public class AuditInfoJsonBO : BusinessBase<AuditInfoJsonBO>
  {
    #region Constructor
    public AuditInfoJsonBO()
    {
      MarkAsChild();
    }

    public AuditInfoJsonDTO ConvertToDTO()
    {
      AuditInfoJsonDTO b = new Lib.AuditInfoJsonDTO();
      b.UserName = this.UserName;
      b.OperatorName = this.OperatorName;
      b.TerminalID = this.TerminalID;
      b.DeviceID = this.DeviceID;
      b.IpAddress = this.IpAddress;
      b.HostName = this.HostName;
      return b;
    }

    #endregion

    #region Business Properties

    public static readonly PropertyInfo<string> UserNameProperty = RegisterProperty<string>(c => c.UserName);
    public string UserName
    {
      get { return GetProperty(UserNameProperty); }
      set { SetProperty(UserNameProperty, value?.ToUpper()); }
    }
    public static readonly PropertyInfo<string> OperatorNameProperty = RegisterProperty<string>(c => c.OperatorName);
    public string OperatorName
    {
      get { return GetProperty(OperatorNameProperty); }
      set { SetProperty(OperatorNameProperty, value); }
    }
    public static readonly PropertyInfo<string> TerminalIDProperty = RegisterProperty<string>(c => c.TerminalID);
    public string TerminalID
    {
      get { return GetProperty(TerminalIDProperty); }
      set { SetProperty(TerminalIDProperty, value); }
    }
    public static readonly PropertyInfo<string> DeviceIDProperty = RegisterProperty<string>(c => c.DeviceID);
    public string DeviceID
    {
      get { return GetProperty(DeviceIDProperty); }
      set { SetProperty(DeviceIDProperty, value); }
    }


    public static readonly PropertyInfo<string> IpAddressProperty = RegisterProperty<string>(c => c.IpAddress);
    public string IpAddress
    {
      get { return GetProperty(IpAddressProperty); }
      set { SetProperty(IpAddressProperty, value); }
    }
    public static readonly PropertyInfo<string> HostNameProperty = RegisterProperty<string>(c => c.HostName);
    public string HostName
    {
      get { return GetProperty(HostNameProperty); }
      set { SetProperty(HostNameProperty, value); }
    }

    #endregion



    #region Validation Rules

    #endregion

    public static AuditInfoJsonBO NewAuditInfoJsonBO()
    {
      return DataPortal.CreateChild<AuditInfoJsonBO>();
    }

    protected override void Child_Create()
    {
      base.Child_Create();
    }

#if !NETFX_CORE
    private void Child_Fetch(string AuditInfoJsontoDTO)
    {
      using (null)
      {
        AuditInfoJsonDTO dtoJson = Newtonsoft.Json.JsonConvert.DeserializeObject<AuditInfoJsonDTO>(AuditInfoJsontoDTO);
        if (dtoJson != null)
          Child_Fetch(dtoJson);
      }

    }

    private void Child_Fetch(AuditInfoJsonDTO data)
    {
      UserName = data.UserName;
      OperatorName = data.OperatorName;
      TerminalID = data.TerminalID;
      DeviceID = data.DeviceID;
      IpAddress = data.IpAddress;
      HostName = data.HostName;
      MarkOld();
    }

    #region Data Access - Insert

    private void Child_Insert(object parent)
    {
      MarkOld();
    }


    #endregion //Data Access - Insert

    #region Data Access - Update
    private void Child_Update(object parent)
    {
      MarkOld();
    }




    #endregion //Data Access - Update

    #region Data Access - Delete
    private void Child_DeleteSelf(object parent)
    {
      MarkNew();
    }



    #endregion //Data Access - Delete
#endif

  }
  #endregion

}