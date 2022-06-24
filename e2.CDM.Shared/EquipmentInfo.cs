
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public partial class EquipmentInfo : Csla.ReadOnlyBase<EquipmentInfo>
    {
        #region Constuctor
        public EquipmentInfo()
        { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<string> EquipmentIDProperty = RegisterProperty<string>(c => c.EquipmentID);
    public string EquipmentID
    {
      get { return GetProperty(EquipmentIDProperty); }
      set { LoadProperty(EquipmentIDProperty, value); }
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
    public static readonly PropertyInfo<string> ResourceTypeProperty = RegisterProperty<string>(c => c.ResourceType);
    public string ResourceType
    {
      get { return GetProperty(ResourceTypeProperty); }
      set { LoadProperty(ResourceTypeProperty, value); }
    }
    public static readonly PropertyInfo<EquipmentJsonBO> EquipmentJsonBOProperty = RegisterProperty<EquipmentJsonBO>(c => c.EquipmentJsonBO);
    public EquipmentJsonBO EquipmentJsonBO
    {
      get { return GetProperty(EquipmentJsonBOProperty); }
      set { LoadProperty(EquipmentJsonBOProperty, value); }
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
        internal static EquipmentInfo GetEquipmentInfo(e2.CDM.DAL.Lib.Equipment_GetAllResult data)
        {
            EquipmentInfo item = new EquipmentInfo();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.Equipment_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                EquipmentID = data.EquipmentID;
                Status = data.Status;
                if (!string.IsNullOrEmpty(data.EquipmentJSON))
                {
                  CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.EquipmentJSON);
                  if (CDMdto.ClassName.Equals("EquipmentJson"))
                    EquipmentJsonBO = DataPortal.FetchChild<EquipmentJsonBO>(data.EquipmentJSON);
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
