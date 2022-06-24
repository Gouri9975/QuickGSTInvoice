using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{



  [Serializable()]
  public class Equipment : Csla.BusinessBase<Equipment>
  {

    #region Constuctor
    public Equipment()
    { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<string> EquipmentIDProperty = RegisterProperty<string>(c => c.EquipmentID);
    public string EquipmentID
    {
      get { return GetProperty(EquipmentIDProperty); }
      set { SetProperty(EquipmentIDProperty, value); }
    }

    public static readonly PropertyInfo<string> EquipmentTypeProperty = RegisterProperty<string>(c => c.EquipmentType);
    public string EquipmentType
    {
      get { return GetProperty(EquipmentTypeProperty); }
      set { SetProperty(EquipmentTypeProperty, value); }
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
    public static readonly PropertyInfo<EquipmentJsonBO> EquipmentJsonBOProperty = RegisterProperty<EquipmentJsonBO>(c => c.EquipmentJsonBO);
    public EquipmentJsonBO EquipmentJsonBO
    {
      get { return GetProperty(EquipmentJsonBOProperty); }
      set { SetProperty(EquipmentJsonBOProperty, value); }
    }

    protected override object GetIdValue()
    {
      return EquipmentID;
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
      //TODO: Define CanGetObject permission in Equipment
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
      //	return true;
      //return false;
    }

    public static bool CanAddObject()
    {
      //TODO: Define CanAddObject permission in Equipment
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
      //	return true;
      //return false;
    }

    public static bool CanEditObject()
    {
      //TODO: Define CanEditObject permission in Equipment
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
      //	return true;
      //return false;
    }

    public static bool CanDeleteObject()
    {
      //TODO: Define CanDeleteObject permission in Equipment
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
      //	return true;
      //return false;
    }
    #endregion //Authorization Rules

    #region Factory Methods

    public static async System.Threading.Tasks.Task<Equipment> NewEquipmentAsync()
    {
      try
      {
        if (!CanAddObject())
          throw new System.Security.SecurityException("User not authorized to add a Equipment");
        return await DataPortal.CreateAsync<Equipment>();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public static async System.Threading.Tasks.Task<Equipment> GetEquipmentAsync(String ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a Equipment");
      return await DataPortal.FetchAsync<Equipment>(new Criteria(ID));
    }

    public static async void DeleteEquipmentAsync(string ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a Equipment");
      await DataPortal.DeleteAsync<Equipment>(new Criteria(ID));
    }
#if !SILVERLIGHT && !NETFX_CORE
    public static Equipment NewEquipment()
    {
      if (!CanAddObject())
        throw new System.Security.SecurityException("User not authorized to add a Equipment");
      return DataPortal.Create<Equipment>();
    }
    public static Equipment GetEquipment(string ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a Equipment");
      return DataPortal.Fetch<Equipment>(new Criteria(ID));
    }
    public static void DeleteEquipment(string ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a Equipment");
      DataPortal.Delete<Equipment>(new Criteria(ID));
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
      EquipmentID = "NEW";
      AuditInfoGuid = Guid.NewGuid();
      LastUpdateUTCDT = DateTime.UtcNow;
      Status = "ACTIVE";

      EquipmentJsonBO = EquipmentJsonBO.NewEquipmentJSON();
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
          var data = mgr.DataContext.Equipment_GetByID(criteria.ID).FirstOrDefault();
          if (data != null)
          {
            EquipmentID = data.EquipmentID;
            Status = data.Status;
            AuditInfoGuid = data.AuditInfoGuid;
            EquipmentType = data.EquipmentType;
            if (!string.IsNullOrEmpty(data.EquipmentJSON))
            {
              CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.EquipmentJSON);
              if (CDMdto.ClassName.Equals("EquipmentJson"))
                EquipmentJsonBO = DataPortal.FetchChild<EquipmentJsonBO>(data.EquipmentJSON);
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
          string EquipmentJsonBOStr = null;
          if (EquipmentJsonBO != null)
          {
            EquipmentJsonBOStr = OdataCDMJson<EquipmentJsonDTO>.GetJsonString(EquipmentJsonBO.ConvertToDTO());
          }
          mgr.DataContext.Equipment_Add(EquipmentID, EquipmentType, EquipmentJsonBOStr, Status, DateTime.Now, AuditInfoGuid);
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
      if (EquipmentID == "NEW")
      {
        EquipmentID = CDMEntityKeys.EquipmentIDNextId();
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
          string EquipmentJsonBOStr = null;
          if (EquipmentJsonBO != null)
          {
            EquipmentJsonBOStr = OdataCDMJson<EquipmentJsonDTO>.GetJsonString(EquipmentJsonBO.ConvertToDTO());
          }
          mgr.DataContext.Equipment_Upd(EquipmentID, EquipmentType, EquipmentJsonBOStr, Status, DateTime.UtcNow, AuditInfoGuid);
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
        mgr.DataContext.Equipment_Void(criteria.ID);
      }//using
    }
    #endregion //Data Access - Delete

#endif
    #endregion //Data Access
  }

  #region EquipmentJsonDTOJSON

  #region EquipmentJsonDTO

  public class EquipmentJsonDTO
  {

    public string EquipmentDesc { get; set; }
    public string IdentificationStr { get; set; }
    public string EquipmentCategory { get; set; }
    public bool AuxEquipment { get; set; }
    public string GroupCat { get; set; }
    public bool TripAssigned { get; set; }
    public DateTime TripAssignedDate { get; set; }
    public string TripAssignedID { get; set; }
    public bool RShipAssigned { get; set; }
    public string EquipmentClass { get; set; }
    public string RShipAssignedID { get; set; }
    public string ClassName { get; set; }
    public EquipmentJsonDTO()
    {
      ClassName = "EquipmentJson";
    }
  }
  #endregion

  [Serializable()]
  public class EquipmentJsonBO : BusinessBase<EquipmentJsonBO>
  {
    #region Constructor
    public EquipmentJsonBO()
    {
      MarkAsChild();
    }

    public EquipmentJsonDTO ConvertToDTO()
    {
      EquipmentJsonDTO b = new EquipmentJsonDTO();
      b.EquipmentDesc = this.EquipmentDesc;
      b.IdentificationStr = this.IdentificationStr;
      b.EquipmentCategory = this.EquipmentCategory;
      b.AuxEquipment = this.AuxEquipment;
      b.GroupCat = this.GroupCat;
      b.TripAssigned = this.TripAssigned;
      b.TripAssignedDate = this.TripAssignedDate;
      b.TripAssignedID = this.TripAssignedID;
      b.RShipAssigned = this.RShipAssigned;
      b.RShipAssignedID = this.RShipAssignedID;
      b.EquipmentClass = EquipmentClass;
      return b;
    }
    #endregion

    #region Business Properties
    public static readonly PropertyInfo<string> IdentificationStrProperty = RegisterProperty<string>(c => c.IdentificationStr);
    public string IdentificationStr
    {
      get { return GetProperty(IdentificationStrProperty); }
      set { SetProperty(IdentificationStrProperty, value); }
    }

    public static readonly PropertyInfo<string> EquipmentDescProperty = RegisterProperty<string>(c => c.EquipmentDesc);
    public string EquipmentDesc
    {
      get { return GetProperty(EquipmentDescProperty); }
      set { SetProperty(EquipmentDescProperty, value); }
    }
    public static readonly PropertyInfo<string> EquipmentCategoryProperty = RegisterProperty<string>(c => c.EquipmentCategory);
    public string EquipmentCategory
    {
      get { return GetProperty(EquipmentCategoryProperty); }
      set { SetProperty(EquipmentCategoryProperty, value); }
    }
    public static readonly PropertyInfo<bool> AuxEquipmentProperty = RegisterProperty<bool>(c => c.AuxEquipment);
    public bool AuxEquipment
    {
      get { return GetProperty(AuxEquipmentProperty); }
      set { SetProperty(AuxEquipmentProperty, value); }
    }
    public static readonly PropertyInfo<string> GroupCatProperty = RegisterProperty<string>(c => c.GroupCat);
    public string GroupCat
    {
      get { return GetProperty(GroupCatProperty); }
      set { SetProperty(GroupCatProperty, value); }
    }
    public static readonly PropertyInfo<bool> TripAssignedProperty = RegisterProperty<bool>(c => c.TripAssigned);
    public bool TripAssigned
    {
      get { return GetProperty(TripAssignedProperty); }
      set { SetProperty(TripAssignedProperty, value); }
    }
    public static readonly PropertyInfo<DateTime> TripAssignedDateProperty = RegisterProperty<DateTime>(c => c.TripAssignedDate);
    public DateTime TripAssignedDate
    {
      get { return GetProperty(TripAssignedDateProperty); }
      set { SetProperty(TripAssignedDateProperty, value); }
    }
    public static readonly PropertyInfo<string> TripAssignedIDProperty = RegisterProperty<string>(c => c.TripAssignedID);
    public string TripAssignedID
    {
      get { return GetProperty(TripAssignedIDProperty); }
      set { SetProperty(TripAssignedIDProperty, value); }
    }
    public static readonly PropertyInfo<bool> RShipAssignedProperty = RegisterProperty<bool>(c => c.RShipAssigned);
    public bool RShipAssigned
    {
      get { return GetProperty(RShipAssignedProperty); }
      set { SetProperty(RShipAssignedProperty, value); }
    }
    public static readonly PropertyInfo<DateTime> RShipAssignedDateProperty = RegisterProperty<DateTime>(c => c.RShipAssignedDate);
    public DateTime RShipAssignedDate
    {
      get { return GetProperty(RShipAssignedDateProperty); }
      set { SetProperty(RShipAssignedDateProperty, value); }
    }
    public static readonly PropertyInfo<string> EquipmentClassProperty = RegisterProperty<string>(c => c.EquipmentClass);
    public string EquipmentClass
    {
      get { return GetProperty(EquipmentClassProperty); }
      set { SetProperty(EquipmentClassProperty, value); }
    }
    public static readonly PropertyInfo<string> RShipAssignedIDProperty = RegisterProperty<string>(c => c.RShipAssignedID);
    public string RShipAssignedID
    {
      get { return GetProperty(RShipAssignedIDProperty); }
      set { SetProperty(RShipAssignedIDProperty, value); }
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

    public static EquipmentJsonBO NewEquipmentJSON()
    {
      return DataPortal.CreateChild<EquipmentJsonBO>();
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
        EquipmentJsonDTO EquipmentJson = Newtonsoft.Json.JsonConvert.DeserializeObject<EquipmentJsonDTO>(BlogJsondtojson);
        if (EquipmentJson != null)
          Child_Fetch(EquipmentJson);
      }
    }
    private void Child_Fetch(EquipmentJsonDTO data)
    {

      EquipmentDesc = data.EquipmentDesc;
      IdentificationStr = data.IdentificationStr;
      EquipmentCategory = data.EquipmentCategory;
      AuxEquipment = data.AuxEquipment;
      GroupCat = data.GroupCat;
      TripAssigned = data.TripAssigned;
      TripAssignedDate = data.TripAssignedDate;
      TripAssignedID = data.TripAssignedID;
      RShipAssigned = data.RShipAssigned;
      RShipAssignedID = data.RShipAssignedID;
      EquipmentClass = data.EquipmentClass;
      MarkOld();
    }

    #region Data Access - Insert

    private void Child_Insert(Equipment parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Insert

    #region Data Access - Update
    private void Child_Update(Equipment parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Update

    #region Data Access - Delete
    private void Child_DeleteSelf(Equipment parent)
    {
      MarkNew();
    }
    #endregion //Data Access - Delete
#endif
  }
  #endregion

}