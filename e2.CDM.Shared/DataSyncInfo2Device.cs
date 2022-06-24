using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{


  [Serializable()]
  public class DataSyncInfo2Device : Csla.BusinessBase<DataSyncInfo2Device>
  {

    #region Constuctor
    public DataSyncInfo2Device()
    { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<Guid> DataSyncInfo2DeviceIDProperty = RegisterProperty<Guid>(c => c.DataSyncInfo2DeviceID);
    public Guid DataSyncInfo2DeviceID
    {
      get { return GetProperty(DataSyncInfo2DeviceIDProperty); }
      set { SetProperty(DataSyncInfo2DeviceIDProperty, value); }
    }
    public static readonly PropertyInfo<DataSyncInfo2DeviceJsonBO> DataSyncInfo2DeviceJsonBOProperty = RegisterProperty<DataSyncInfo2DeviceJsonBO>(c => c.DataSyncInfo2DeviceJsonBO);
    public DataSyncInfo2DeviceJsonBO DataSyncInfo2DeviceJsonBO
    {
      get { return GetProperty(DataSyncInfo2DeviceJsonBOProperty); }
      set { SetProperty(DataSyncInfo2DeviceJsonBOProperty, value); }
    }
    public static readonly PropertyInfo<string> DeviceIDProperty = RegisterProperty<string>(c => c.DeviceID);
    public string DeviceID
    {
      get { return GetProperty(DeviceIDProperty); }
      set { SetProperty(DeviceIDProperty, value); }
    }
    public static readonly PropertyInfo<string> RecordCountProperty = RegisterProperty<string>(c => c.RecordCount);
    public string RecordCount
    {
      get { return GetProperty(RecordCountProperty); }
      set { SetProperty(RecordCountProperty, value); }
    }
    public static readonly PropertyInfo<string> DataSyncInfo2DeviceTypeProperty = RegisterProperty<string>(c => c.DataSyncInfo2DeviceType);
    public string DataSyncInfo2DeviceType
    {
      get { return GetProperty(DataSyncInfo2DeviceTypeProperty); }
      set { SetProperty(DataSyncInfo2DeviceTypeProperty, value); }
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
      return DataSyncInfo2DeviceID;
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

    public static async System.Threading.Tasks.Task<DataSyncInfo2Device> NewDataSyncInfo2DeviceAsync()
    {
      try
      {
        if (!CanAddObject())
          throw new System.Security.SecurityException("User not authorized to add a DataSyncInfo2Device");
        return await DataPortal.CreateAsync<DataSyncInfo2Device>();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public static async System.Threading.Tasks.Task<DataSyncInfo2Device> GetDataSyncInfo2DeviceAsync(Guid ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a DataSyncInfo2Device");
      return await DataPortal.FetchAsync<DataSyncInfo2Device>(new Criteria(ID));
    }

    public static async void DeleteDataSyncInfo2DeviceAsync(Guid ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a Task");
      await DataPortal.DeleteAsync<DataSyncInfo2Device>(new Criteria(ID));
    }
#if !SILVERLIGHT && !NETFX_CORE
    public static DataSyncInfo2Device NewDataSyncInfo2Device()
    {
      if (!CanAddObject())
        throw new System.Security.SecurityException("User not authorized to add a Task");
      return DataPortal.Create<DataSyncInfo2Device>();
    }
    public static DataSyncInfo2Device GetDataSyncInfo2Device(Guid ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a Task");
      return DataPortal.Fetch<DataSyncInfo2Device>(new Criteria(ID));
    }
    public static void DeleteDataSyncInfo2Device(Guid ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a Task");
      DataPortal.Delete<DataSyncInfo2Device>(new Criteria(ID));
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
      DataSyncInfo2DeviceID = Guid.NewGuid();
      LastUpdateUTCDT = DateTime.UtcNow;
      DataSyncInfo2DeviceJsonBO = DataSyncInfo2DeviceJsonBO.NewDataSyncInfo2DeviceJson();
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
          var data = mgr.DataContext.DataSyncInfo2Device_GetByID(criteria.ID).FirstOrDefault();
          if (data != null)
          {
            DataSyncInfo2DeviceID = data.DataSyncInfo2DeviceID;
            DeviceID = data.DeviceID;
            RecordCount = data.RecordCount;
            DataSyncInfo2DeviceType = data.DataSyncInfo2DeviceType;
            LastUpdateUTCDT = data.LastUpdateUTCDT;
            if (!string.IsNullOrEmpty(data.DataSyncInfo2DeviceJSON))
            {
              CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.DataSyncInfo2DeviceJSON);
              if (CDMdto.ClassName.Equals("DataSyncInfo2DeviceJson"))
                DataSyncInfo2DeviceJsonBO = DataPortal.FetchChild<DataSyncInfo2DeviceJsonBO>(data.DataSyncInfo2DeviceJSON);
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
          string DataSyncInfo2DeviceJsonBOStr = null;
          if (DataSyncInfo2DeviceJsonBO != null)
          {
            DataSyncInfo2DeviceJsonBOStr = OdataCDMJson<DataSyncInfo2DeviceJsonDTO>.GetJsonString(DataSyncInfo2DeviceJsonBO.ConvertToDTO());
          }
          mgr.DataContext.DataSyncInfo2Device_Add(DataSyncInfo2DeviceID,
            DataSyncInfo2DeviceJsonBOStr,
            auditInfoJsonBOStr,
            DeviceID,
          DataSyncInfo2DeviceType,
          RecordCount,
          DateTime.Now);
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
          string DataSyncInfo2DeviceJsonBOStr = null;
          if (DataSyncInfo2DeviceJsonBO != null)
          {
            DataSyncInfo2DeviceJsonBOStr = OdataCDMJson<DataSyncInfo2DeviceJsonDTO>.GetJsonString(DataSyncInfo2DeviceJsonBO.ConvertToDTO());
          }
          mgr.DataContext.DataSyncInfo2Device_Upd(DataSyncInfo2DeviceID,
                      DataSyncInfo2DeviceJsonBOStr,
                      auditInfoJsonBOStr,
                      DeviceID,
                    DataSyncInfo2DeviceType,
                    RecordCount,
                    DateTime.Now); FieldManager.UpdateChildren(this);
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
        //mgr.DataContext.DataSyncInfo2Device_Void(criteria.ID);
      }//using
    }
    #endregion //Data Access - Delete

#endif
    #endregion //Data Access
  }

  #region DataSyncInfo2DeviceJson

  #region DataSyncInfo2DeviceJsonDTO

  public class DataSyncInfo2DeviceJsonDTO
  {
    public string DataSyncInfo2DeviceName { get; set; }

    public string DataSyncInfo2DeviceDesc { get; set; }

    public string ClassName { get; set; }
    public DataSyncInfo2DeviceJsonDTO()
    {
      ClassName = "DataSyncInfo2DeviceJson";
    }
  }
  #endregion

  [Serializable()]
  public class DataSyncInfo2DeviceJsonBO : BusinessBase<DataSyncInfo2DeviceJsonBO>
  {
    #region Constructor
    public DataSyncInfo2DeviceJsonBO()
    {
      MarkAsChild();
    }

    public DataSyncInfo2DeviceJsonDTO ConvertToDTO()
    {
      DataSyncInfo2DeviceJsonDTO b = new DataSyncInfo2DeviceJsonDTO();
      b.DataSyncInfo2DeviceName = this.DataSyncInfo2DeviceName;
      b.DataSyncInfo2DeviceDesc = this.DataSyncInfo2DeviceDesc;
      return b;
    }
    #endregion

    #region Business Properties

    public static readonly PropertyInfo<string> DataSyncInfo2DeviceDescProperty = RegisterProperty<string>(c => c.DataSyncInfo2DeviceDesc);
    public string DataSyncInfo2DeviceDesc
    {
      get { return GetProperty(DataSyncInfo2DeviceDescProperty); }
      set { SetProperty(DataSyncInfo2DeviceDescProperty, value); }
    }
    public static readonly PropertyInfo<string> DataSyncInfo2DeviceNameProperty = RegisterProperty<string>(c => c.DataSyncInfo2DeviceName);
    public string DataSyncInfo2DeviceName
    {
      get { return GetProperty(DataSyncInfo2DeviceNameProperty); }
      set { SetProperty(DataSyncInfo2DeviceNameProperty, value); }
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

    public static DataSyncInfo2DeviceJsonBO NewDataSyncInfo2DeviceJson()
    {
      return DataPortal.CreateChild<DataSyncInfo2DeviceJsonBO>();
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
        DataSyncInfo2DeviceJsonDTO DataSyncInfo2DeviceJson = Newtonsoft.Json.JsonConvert.DeserializeObject<DataSyncInfo2DeviceJsonDTO>(BlogJsondtojson);
        if (DataSyncInfo2DeviceJson != null)
          Child_Fetch(DataSyncInfo2DeviceJson);
      }
    }
    private void Child_Fetch(DataSyncInfo2DeviceJsonDTO data)
    {

      DataSyncInfo2DeviceDesc = data.DataSyncInfo2DeviceDesc;
      DataSyncInfo2DeviceName = data.DataSyncInfo2DeviceName;
      MarkOld();
    }

    #region Data Access - Insert

    private void Child_Insert(DataSyncInfo2Device parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Insert

    #region Data Access - Update
    private void Child_Update(DataSyncInfo2Device parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Update

    #region Data Access - Delete
    private void Child_DeleteSelf(DataSyncInfo2Device parent)
    {
      MarkNew();
    }
    #endregion //Data Access - Delete
#endif
  }
  #endregion


}