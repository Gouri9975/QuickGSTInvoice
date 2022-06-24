
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
  [Serializable()]
  public partial class CurrencyExchangeInfo : Csla.ReadOnlyBase<CurrencyExchangeInfo>
  {
    #region Constuctor
    public CurrencyExchangeInfo()
    { }
    #endregion
    #region Business Properties and Methods

    public static readonly PropertyInfo<Guid> CurrencyExchangeIDProperty = RegisterProperty<Guid>(c => c.CurrencyExchangeID);
    public Guid CurrencyExchangeID
    {
      get { return GetProperty(CurrencyExchangeIDProperty); }
      set { LoadProperty(CurrencyExchangeIDProperty, value); }
    }

    public static readonly PropertyInfo<CurrencyExchangeJsonBO> CurrencyExchangeJsonBOProperty = RegisterProperty<CurrencyExchangeJsonBO>(c => c.CurrencyExchangeJsonBO);
    public CurrencyExchangeJsonBO CurrencyExchangeJsonBO
    {
      get { return GetProperty(CurrencyExchangeJsonBOProperty); }
      set { LoadProperty(CurrencyExchangeJsonBOProperty, value); }
    }

    public static readonly PropertyInfo<DateTime> CurrencyExchangeDateProperty = RegisterProperty<DateTime>(c => c.CurrencyExchangeDate);
    public DateTime CurrencyExchangeDate
    {
      get { return GetProperty(CurrencyExchangeDateProperty); }
      set { LoadProperty(CurrencyExchangeDateProperty, value); }
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
    internal static CurrencyExchangeInfo GetCurrencyExchangeInfo(e2.CDM.DAL.Lib.CurrencyExchange_GetAllResult data)
    {
      CurrencyExchangeInfo item = new CurrencyExchangeInfo();
      item.Fetch(data);
      return item;
    }


    private void Fetch(e2.CDM.DAL.Lib.CurrencyExchange_GetAllResult data)
    {
      bool cancel = false;
      OnFetching(ref cancel);
      if (cancel) return;
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
