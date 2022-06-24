
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;
using e2.BDM.Lib;

namespace e2.CDM.Lib
{
  [Serializable()]
  public partial class HResourceInfo : Csla.ReadOnlyBase<HResourceInfo>
  {
    #region Constuctor
    public HResourceInfo()
    { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<string> HResourceIDProperty = RegisterProperty<string>(c => c.HResourceID);
    public string HResourceID
    {
      get { return GetProperty(HResourceIDProperty); }
      set { LoadProperty(HResourceIDProperty, value); }
    }
    public static readonly PropertyInfo<string> ResourceTypeProperty = RegisterProperty<string>(c => c.ResourceType);
    public string ResourceType
    {
      get { return GetProperty(ResourceTypeProperty); }
      private set { LoadProperty(ResourceTypeProperty, value); }
    }
    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
    public string Name
    {
      get { return GetProperty(NameProperty); }
      private set { LoadProperty(NameProperty, value); }
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
    public static readonly PropertyInfo<HResourcesJsonBO> HResourcesJsonBOProperty = RegisterProperty<HResourcesJsonBO>(c => c.HResourcesJsonBO);
    public HResourcesJsonBO HResourcesJsonBO
    {
      get { return GetProperty(HResourcesJsonBOProperty); }
      set { LoadProperty(HResourcesJsonBOProperty, value); }
    }
    public static readonly PropertyInfo<ContactAddressesDtls> ContactAddressesDtlsProperty = RegisterProperty<ContactAddressesDtls>(p => p.ContactAddressesDtls, Csla.RelationshipTypes.Child);
    public ContactAddressesDtls ContactAddressesDtls
    {
      get
      {
        if (!FieldManager.FieldExists(ContactAddressesDtlsProperty))
          LoadProperty(ContactAddressesDtlsProperty, DataPortal.CreateChild<ContactAddressesDtls>());
        return GetProperty(ContactAddressesDtlsProperty);
      }
      private set { LoadProperty(ContactAddressesDtlsProperty, value); }
    }

    //public override bool IsValid
    //{
    //	get { return base.IsValid && BlogDtls.IsValid; }
    //}

    //public override bool IsDirty
    //{
    //	get { return base.IsDirty || BlogDtls.IsDirty; }
    //}



    protected override object GetIdValue()
    {
      return HResourceID;
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
        internal static HResourceInfo GetHResourceInfo(e2.CDM.DAL.Lib.HResource_GetAllResult data)
        {
            HResourceInfo item = new HResourceInfo();
            item.Fetch(data);

            return item;
        }
      

        private void Fetch(e2.CDM.DAL.Lib.HResource_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                HResourceID = data.HResourceID;
                ResourceType = data.ResourceType;
                Status = data.Status;
                if (!string.IsNullOrEmpty(data.HResourceJSON))
                {
                    CDMDTO ivmdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.HResourceJSON);
                    if (ivmdto.ClassName.Equals("HResourcesJson"))
                        HResourcesJsonBO = DataPortal.FetchChild<HResourcesJsonBO>(data.HResourceJSON);
                }
                var res = DataPortal.FetchChild<ContactAddressesDtls>(new KeyValuePair<string, string>(HResourcesJsonBO.Code, "WOHRESOURCE")).Where(r => r.AddressTypeID != "BILLTO");
                ContactAddressesDtls.AddRange(res);

                if (HResourcesJsonBO != null)
                Name = HResourcesJsonBO.Name;
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
