using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;
using System.Collections.ObjectModel;

namespace e2.CDM.Lib
{

  [Serializable()]
  public class CurrencyExchange : Csla.BusinessBase<CurrencyExchange>
  {

    #region Constuctor
    public CurrencyExchange()
    { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<Guid> CurrencyExchangeIDProperty = RegisterProperty<Guid>(c => c.CurrencyExchangeID);
    public Guid CurrencyExchangeID
    {
      get { return GetProperty(CurrencyExchangeIDProperty); }
      set { SetProperty(CurrencyExchangeIDProperty, value); }
    }

    public static readonly PropertyInfo<CurrencyExchangeJsonBO> CurrencyExchangeJsonBOProperty = RegisterProperty<CurrencyExchangeJsonBO>(c => c.CurrencyExchangeJsonBO);
    public CurrencyExchangeJsonBO CurrencyExchangeJsonBO
    {
      get { return GetProperty(CurrencyExchangeJsonBOProperty); }
      set { SetProperty(CurrencyExchangeJsonBOProperty, value); }
    }

    public static readonly PropertyInfo<DateTime> CurrencyExchangeDateProperty = RegisterProperty<DateTime>(c => c.CurrencyExchangeDate);
    public DateTime CurrencyExchangeDate
    {
      get { return GetProperty(CurrencyExchangeDateProperty); }
      set { SetProperty(CurrencyExchangeDateProperty, value); }
    }
    public static readonly PropertyInfo<string> CurrencyExchangeTypeProperty = RegisterProperty<string>(c => c.CurrencyExchangeType);
    public string CurrencyExchangeType
    {
      get { return GetProperty(CurrencyExchangeTypeProperty); }
      set { SetProperty(CurrencyExchangeTypeProperty, value); }
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



    #endregion //Business Properties and Methods

    #region Validation Rules
    private void AddCustomRules()
    {
      //add custom/non-generated rules here...
    }

    private void AddCommonRules()
    {
      //
      // CurrencyExchangeID
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
      //TODO: Define CanGetObject permission in ItemsSaleCampaign
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
      //	return true;
      //return false;
    }

    public static bool CanAddObject()
    {
      //TODO: Define CanAddObject permission in ItemsSaleCampaign
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
      //	return true;
      //return false;
    }

    public static bool CanEditObject()
    {
      //TODO: Define CanEditObject permission in ItemsSaleCampaign
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
      //	return true;
      //return false;
    }

    public static bool CanDeleteObject()
    {
      //TODO: Define CanDeleteObject permission in ItemsSaleCampaign
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
      //	return true;
      //return false;
    }
    #endregion //Authorization Rules

    #region Factory Methods

    public static async System.Threading.Tasks.Task<CurrencyExchange> NewCurrencyExchangeAsync()
    {
      try
      {
        if (!CanAddObject())
          throw new System.Security.SecurityException("User not authorized to add a CurrencyExchange");
        return await DataPortal.CreateAsync<CurrencyExchange>();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public static async System.Threading.Tasks.Task<CurrencyExchange> GetCurrencyExchangeAsync(Guid CurrencyExchangeID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a CurrencyExchange");
      return await DataPortal.FetchAsync<CurrencyExchange>(new Criteria(CurrencyExchangeID));
    }

    public static async void DeleteCurrencyExchangeAsync(Guid CurrencyExchangeID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a CurrencyExchange");
      await DataPortal.DeleteAsync<CurrencyExchange>(new Criteria(CurrencyExchangeID));
    }
#if !SILVERLIGHT && !NETFX_CORE
    public static CurrencyExchange NewCurrencyExchange()
    {
      if (!CanAddObject())
        throw new System.Security.SecurityException("User not authorized to add a CurrencyExchange");
      return DataPortal.Create<CurrencyExchange>();
    }
    public static CurrencyExchange GetCurrencyExchange(Guid CurrencyExchangeID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a CurrencyExchange");
      return DataPortal.Fetch<CurrencyExchange>(new Criteria(CurrencyExchangeID));
    }
    public static void DeleteCurrencyExchange(Guid CurrencyExchangeID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a CurrencyExchange");
      DataPortal.Delete<CurrencyExchange>(new Criteria(CurrencyExchangeID));
    }
#endif
    #endregion //Factory Methods

    #region Criteria

    [Serializable()]
    private class Criteria : CriteriaBase<Criteria>
    {
      public static readonly PropertyInfo<Guid> IDProperty = RegisterProperty<Guid>(c => c.CurrencyExchangeID);
      public Guid CurrencyExchangeID
      {
        get { return ReadProperty(IDProperty); }
        set { LoadProperty(IDProperty, value); }
      }

      public static readonly PropertyInfo<string> TenantIDProperty = RegisterProperty<string>(c => c.TenantID);
      public string TenantID
      {
        get { return ReadProperty(TenantIDProperty); }
        set { LoadProperty(TenantIDProperty, value); }
      }

      public Criteria()
      { }
      public Criteria(Guid CurrencyExchangeID)
      {
        this.CurrencyExchangeID = CurrencyExchangeID;
      }
      public Criteria(Guid CurrencyExchangeID, string TenantID)
      {
        this.CurrencyExchangeID = CurrencyExchangeID;
        this.TenantID = TenantID;
      }
    }

    #endregion //Criteria

    #region Data Access - Create

    protected override void DataPortal_Create()
    {

      CurrencyExchangeID = Guid.NewGuid();
      AuditInfoGuid = Guid.NewGuid();
      Status = "ACTIVE";
      CurrencyExchangeJsonBO = CurrencyExchangeJsonBO.NewCurrencyExchangeJSON();
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
          var data = mgr.DataContext.CurrencyExchange_GetByID(criteria.CurrencyExchangeID).FirstOrDefault();
          if (data != null)
          {
            CurrencyExchangeID = data.CurrencyExchangeID;
            if (data.CurrencyExchangeDate != null)
              CurrencyExchangeDate = (DateTime)data.CurrencyExchangeDate;
           
            AuditInfoGuid = data.AuditInfoGuid;
            if (!string.IsNullOrEmpty(data.CurrencyExchangeJSON))
            {
              CDMDTO somdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.CurrencyExchangeJSON);
              if (somdto.ClassName.Equals("CurrencyExchangeJSON"))
                CurrencyExchangeJsonBO = DataPortal.FetchChild<CurrencyExchangeJsonBO>(data.CurrencyExchangeJSON);
            }
            // InventoryPlanDtls = InventoryPlanDtls.GetItemInventoryPlanDtls(criteria.CurrencyExchangeID);
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
          string CurrencyExchangeJsonBOStr = null;
          if (CurrencyExchangeJsonBO != null)
          {
            CurrencyExchangeJsonBOStr = OdataCDMJson<CurrencyExchangeDTO>.GetJsonString(CurrencyExchangeJsonBO.ConvertToDTO());
          }
          mgr.DataContext.CurrencyExchange_Add(CurrencyExchangeID, CurrencyExchangeDate, CurrencyExchangeJsonBOStr, Status, DateTime.UtcNow, AuditInfoGuid);

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
      //if (InventoryPlanNo == "NEW")
      //{
      //    InventoryPlanNo = SOMEntityKeys.InventoryPlanNextId();
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
          string CurrencyExchangeJsonBOStr = null;
          if (CurrencyExchangeJsonBO != null)
          {
            CurrencyExchangeJsonBOStr = OdataCDMJson<CurrencyExchangeDTO>.GetJsonString(CurrencyExchangeJsonBO.ConvertToDTO());
          }
          mgr.DataContext.CurrencyExchange_Upd(CurrencyExchangeID, CurrencyExchangeDate, CurrencyExchangeJsonBOStr, Status, DateTime.UtcNow, AuditInfoGuid);
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
        mgr.DataContext.CurrencyExchange_Remove(criteria.CurrencyExchangeID);
      }//using
    }
    #endregion //Data Access - Delete

#endif
    #endregion //Data Access
  }

  #region CurrencyExchangeJSON

  #region CurrencyExchangeDTO

  public class CurrencyExchangeDTO
  {
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }   
    public string Symbol { get; set; }
    public decimal Rate { get; set; }
    public string Provider { get; set; }
    public string ClassName { get; set; }
    public CurrencyExchangeDTO()
    {
      ClassName = "CurrencyExchangeJSON";
    }
  }
  #endregion

  [Serializable()]
  public class CurrencyExchangeJsonBO : BusinessBase<CurrencyExchangeJsonBO>
  {
    #region Constructor
    public CurrencyExchangeJsonBO()
    {
      MarkAsChild();
    }

    public CurrencyExchangeDTO ConvertToDTO()
    {
      CurrencyExchangeDTO b = new CurrencyExchangeDTO();
      b.FromCurrency = this.FromCurrency;
      b.ToCurrency = this.ToCurrency;
      b.Symbol = this.Symbol;
      b.Rate = this.Rate;
      b.Provider = this.Provider;
      return b;
    }
    #endregion

    #region Business Properties
    public static readonly PropertyInfo<string> FromCurrencyProperty = RegisterProperty<string>(c => c.FromCurrency);
    public string FromCurrency
    {
      get { return GetProperty(FromCurrencyProperty); }
      set { SetProperty(FromCurrencyProperty, value); }
    }
    public static readonly PropertyInfo<string> ToCurrencyProperty = RegisterProperty<string>(c => c.ToCurrency);
    public string ToCurrency
    {
      get { return GetProperty(ToCurrencyProperty); }
      set { SetProperty(ToCurrencyProperty, value); }
    }
    public static readonly PropertyInfo<string> SymbolProperty = RegisterProperty<string>(c => c.Symbol);
    public string Symbol
    {
      get { return GetProperty(SymbolProperty); }
      set { SetProperty(SymbolProperty, value); }
    }
    public static readonly PropertyInfo<decimal> RateProperty = RegisterProperty<decimal>(c => c.Rate);
    public decimal Rate
    {
      get { return GetProperty(RateProperty); }
      set { SetProperty(RateProperty, value); }
    }
    public static readonly PropertyInfo<string> ProviderProperty = RegisterProperty<string>(c => c.Provider);
    public string Provider
    {
      get { return GetProperty(ProviderProperty); }
      set { SetProperty(ProviderProperty, value); }
    }
    #endregion

    #region Validation Rules
    protected override void AddBusinessRules()
    {
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(HeadingProperty));
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(SubHeadingProperty));
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(CurrencyExchangeJsonBOProperty));
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(TagsProperty));
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(RatingProperty));
    }
    #endregion

    public static CurrencyExchangeJsonBO NewCurrencyExchangeJSON()
    {
      return DataPortal.CreateChild<CurrencyExchangeJsonBO>();
    }
    protected override void Child_Create()
    {
      base.Child_Create();
    }

#if !NETFX_CORE
    private void Child_Fetch(string InventoryplanHjsonBO)
    {
      using (null)
      {
        CurrencyExchangeDTO CurrencyExchangeJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrencyExchangeDTO>(InventoryplanHjsonBO);
        if (CurrencyExchangeJSON != null)
          Child_Fetch(CurrencyExchangeJSON);
      }
    }
    private void Child_Fetch(CurrencyExchangeDTO data)
    {
      FromCurrency = data.FromCurrency;
      ToCurrency = data.ToCurrency;
      Symbol = data.Symbol;
      Rate = data.Rate;
      Provider = data.Provider;
      MarkOld();
    }

    #region Data Access - Insert

    private void Child_Insert(CurrencyExchange parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Insert

    #region Data Access - Update
    private void Child_Update(CurrencyExchange parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Update

    #region Data Access - Delete
    private void Child_DeleteSelf(CurrencyExchange parent)
    {
      MarkNew();
    }
    #endregion //Data Access - Delete
#endif
  }
  #endregion

}