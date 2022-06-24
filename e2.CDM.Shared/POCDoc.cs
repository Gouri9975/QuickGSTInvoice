using System;
using Csla;
using Csla.Serialization;
using System.Linq;

namespace e2.CDM.Lib
{
  [Serializable()]
  public partial class POCDoc : Csla.BusinessBase<POCDoc>
  {
    #region Business Rules

    /// <summary>
    /// All custom rules need to be placed in this method.
    /// </summary>
    /// <returns>Return true to override the generated rules; If false generated rules will be run.</returns>
    protected bool AddBusinessValidationRules()
    {
      // TODO: add validation rules
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(MyProperty));

      return false;
    }

    /// <summary>
    /// Contains the CodeSmith generated validation rules.
    /// </summary>
    protected override void AddBusinessRules()
    {
      // Call the base class, if this call isn't made than any declared System.ComponentModel.DataAnnotations rules will not work.
      base.AddBusinessRules();

      if (AddBusinessValidationRules())
        return;

    }

    #endregion

    #region Authorization Rules
    public static void AddObjectAuthorizationRules()
    {
      //Csla.Rules.BusinessRules.AddRule(typeof(SOInvoice), new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.CreateObject, "SomeRole"));
      //Csla.Rules.BusinessRules.AddRule(typeof(SOInvoice), new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.EditObject, "SomeRole"));
      //Csla.Rules.BusinessRules.AddRule(typeof(SOInvoice), new Csla.Rules.CommonRules.IsInRole(Csla.Rules.AuthorizationActions.DeleteObject, "SomeRole", "SomeAdminRole"));
    }
    #endregion

    #region Business Properties and Methods

    //declare members
    public static readonly PropertyInfo<Guid> POCDocIDProperty = RegisterProperty<Guid>(c => c.POCDocID);
    public Guid POCDocID
    {
      get { return GetProperty(POCDocIDProperty); }
      set { SetProperty(POCDocIDProperty, value); }
    }
    public static readonly PropertyInfo<DateTime> POCDocDateProperty = RegisterProperty<DateTime>(c => c.POCDocDate);
    public DateTime POCDocDate
    {
      get { return GetProperty(POCDocDateProperty); }
      set { SetProperty(POCDocDateProperty, value); }
    }
    public static readonly PropertyInfo<string> ReferenceIDProperty = RegisterProperty<string>(c => c.ReferenceID);
    public string ReferenceID
    {
      get { return GetProperty(ReferenceIDProperty); }
      set { SetProperty(ReferenceIDProperty, value); }
    }
    public static readonly PropertyInfo<DateTime> LastUpdateUTCDTProperty = RegisterProperty<DateTime>(c => c.LastUpdateUTCDT);
    public DateTime LastUpdateUTCDT
    {
      get { return GetProperty(LastUpdateUTCDTProperty); }
      set { SetProperty(LastUpdateUTCDTProperty, value); }
    }
    public static readonly PropertyInfo<string> ReferenceTypeProperty = RegisterProperty<string>(c => c.ReferenceType);
    public string ReferenceType
    {
      get { return GetProperty(ReferenceTypeProperty); }
      set { SetProperty(ReferenceTypeProperty, value); }
    }
    public static readonly PropertyInfo<POCDocJsonBO> POCDocJsonBOProperty = RegisterProperty<POCDocJsonBO>(c => c.POCDocJsonBO);
    public POCDocJsonBO POCDocJsonBO
    {
      get { return GetProperty(POCDocJsonBOProperty); }
      set { SetProperty(POCDocJsonBOProperty, value); }
    }
    public static readonly PropertyInfo<string> CompanyIDProperty = RegisterProperty<string>(c => c.CompanyID);
    public string CompanyID
    {
      get { return GetProperty(CompanyIDProperty); }
      set { SetProperty(CompanyIDProperty, value); }
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

    protected override object GetIdValue()
    {
      return POCDocID;
    }
    public void UpdateObjectID(string ReferenceID, string ReferenceType)
    {
      this.ReferenceID = ReferenceID;
      this.ReferenceType = ReferenceType;


    }

    #endregion //Business Properties and Methods

    #region Factory Methods
    public static bool CanAddObject()
    {
      //TODO: Define CanAddObject permission in Blog
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
      //	return true;
      //return false;
    }

    public POCDoc()
    { /* require use of factory method */ }
    public static POCDoc NewPOCDoc()
    {
      if (!CanAddObject())
        throw new System.Security.SecurityException("User not authorized to add a POC");
      return DataPortal.CreateChild<POCDoc>();
    }
#if !SILVERLIGHT && !NETFX_CORE

		internal static POCDoc GetPOCDocChild(DAL.Lib.POCDoc_GetByIDResult data)
		{
			return DataPortal.FetchChild<POCDoc>(data);
		}
    #region Data Access


    #region Data Access - Child Fetch
    //private void Child_Fetch(Guid POCDocID)
    //{
    //  using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
    //                          .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
    //  {
    //    var data = ctx.DataContext.POCDoc_GetByID(POCDocID).FirstOrDefault();
    //    if (data != null)
    //      Child_Fetch(data);
    //    else
    //      Child_Create();
    //  }

    //}

    private void Child_Fetch(e2.CDM.DAL.Lib.POCDoc_GetByRefIDResult data)
    {
      POCDocID = data.POCDocID;
      POCDocDate = data.POCDocDate;
      ReferenceID = data.ReferenceID;
      ReferenceType = data.ReferenceType;
      //POCDocJSON = data.POCDocJSON;
      CompanyID = data.CompanyID;
      Status = data.Status;
      AuditInfoGuid = data.AuditInfoGuid;
      LastUpdateUTCDT = data.LastUpdateUTCDT;
     
      if (!string.IsNullOrEmpty(data.POCDocJSON))
      {
        CDMDTO ammdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.POCDocJSON);
        if (ammdto.ClassName.Equals("POCDocJson"))
          POCDocJsonBO = DataPortal.FetchChild<POCDocJsonBO>(data.POCDocJSON);

      }
      MarkOld();
    }

    #endregion //Data Access - Child Fetch

    #region Data Access - Child Insert
    private void Child_Insert(System.Object parent)
    {
      if (!IsDirty) return;

      using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection,"CDMDb"))
      {
        string POCDocJsonBOStr = null;
        if (POCDocJsonBO != null)
        {
          POCDocJsonBOStr = OdataCDMJson<POCDocJsonDTO>.GetJsonString(POCDocJsonBO.ConvertToDTO());
        }
        ctx.DataContext.POCDoc_Add(POCDocID, POCDocDate, ReferenceID, ReferenceType, POCDocJsonBOStr, CompanyID, Status, DateTime.UtcNow, AuditInfoGuid);
      }
    }
     

      
    #endregion //Data Access - Child Insert

    #region Data Access - Child Update
    private void Child_Update()
    {
      if (base.IsDirty)
      {
        using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
        {
          string POCDocJsonBOStr = null;
          if (POCDocJsonBO != null)
          {
            POCDocJsonBOStr = OdataCDMJson<POCDocJsonDTO>.GetJsonString(POCDocJsonBO.ConvertToDTO());
          }
          ctx.DataContext.POCDoc_Upd(POCDocID, POCDocDate, ReferenceID, ReferenceType, POCDocJsonBOStr, CompanyID, Status, DateTime.UtcNow, AuditInfoGuid);
        }
      }
    }

    #endregion //Data Access - Child Update

    #region Data Access - Child Delete
    private void Child_DeleteSelf()
    {
      using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
      {
        ctx.DataContext.POCDoc_Void(POCDocID);
      }
    }

    #endregion //Data Access - Child Delete

    #endregion //Data Access


#endif

    #endregion //Factory Methods

    #region Data Access - Child Create
    protected override void Child_Create()
    {
      AuditInfoGuid = Guid.NewGuid();
      POCDocID = Guid.NewGuid();
      POCDocDate = DateTime.Now;
      POCDocJsonBO = POCDocJsonBO.NewOrGetPOCDocJson(this);
      base.Child_Create();
    }
    #endregion //Data Access - Child Create
  }


  #region POCDocJson

  #region POCDocJsonDTO

  public class POCDocJsonDTO
  {
    public string Name { get; set; }
    public string Type { get; set; }
    public string Notes { get; set; }
    public bool IsConfirmed { get; set; }
    public byte[] Signature { get; set; }
    public string ClassName { get; set; }
    public POCDocJsonDTO()
    {
      ClassName = "POCDocJson";
    }

  }
  #endregion

  [Serializable()]
  public class POCDocJsonBO : BusinessBase<POCDocJsonBO>
  {
    #region Constructor
    public POCDocJsonBO()
    {
      MarkAsChild();
    }

    public POCDocJsonDTO ConvertToDTO()
    {
      POCDocJsonDTO b = new Lib.POCDocJsonDTO();
      b.Name = this.Name;
      b.Notes = this.Notes;
      b.Signature = this.Signature;
      b.Type = this.Type;
      b.IsConfirmed = this.IsConfirmed;
      return b;
    }

    #endregion

    #region Business Properties

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
    public string Name
    {
      get { return GetProperty(NameProperty); }
      set { SetProperty(NameProperty, value); }
    }
    public static readonly PropertyInfo<string> NotesProperty = RegisterProperty<string>(c => c.Notes);
    public string Notes
    {
      get { return GetProperty(NotesProperty); }
      set { SetProperty(NotesProperty, value); }
    }
    public static readonly PropertyInfo<string> TypeProperty = RegisterProperty<string>(c => c.Type);
    public string Type
    {
      get { return GetProperty(TypeProperty); }
      set { SetProperty(TypeProperty, value); }
    }
    public static readonly PropertyInfo<bool> IsConfirmedProperty = RegisterProperty<bool>(c => c.IsConfirmed);
    public bool IsConfirmed
    {
      get { return GetProperty(IsConfirmedProperty); }
      set { SetProperty(IsConfirmedProperty, value); }
    }
    public static readonly PropertyInfo<byte[]> SignatureProperty = RegisterProperty<byte[]>(c => c.Signature);
    public byte[] Signature
    {
      get { return GetProperty(SignatureProperty); }
      set { SetProperty(SignatureProperty, value); }
    }
    #endregion



    #region Validation Rules

    protected override void AddBusinessRules()
    {
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(LatitudeProperty));
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(ScheduleNoProperty));
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(LongitudeProperty));
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(SortNoProperty));
    }

    #endregion

    public static POCDocJsonBO NewPOCDocJson()
    {
      return DataPortal.CreateChild<POCDocJsonBO>();
    }
    public static POCDocJsonBO NewOrGetPOCDocJson(POCDoc obj)
    {
      if (obj.POCDocJsonBO != null)
        return obj.POCDocJsonBO;
      else
        return DataPortal.CreateChild<POCDocJsonBO>();
    }
    protected override void Child_Create()
    {
      base.Child_Create();
    }

#if !NETFX_CORE
    private void Child_Fetch(string POCDocJsondtojson)
    {
      using (null)
      {
        POCDocJsonDTO POCDocJson = Newtonsoft.Json.JsonConvert.DeserializeObject<POCDocJsonDTO>(POCDocJsondtojson);
        if (POCDocJson != null)
          Child_Fetch(POCDocJson);
      }
    }

    private void Child_Fetch(POCDocJsonDTO data)
    {     
      Name = data.Name;
      Notes = data.Notes;
      Signature = data.Signature;
      Type=data.Type;
      IsConfirmed=data.IsConfirmed;
      MarkOld();
    }

    #region Data Access - Insert

    private void Child_Insert(POCDoc parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Insert

    #region Data Access - Update
    private void Child_Update(POCDoc parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Update

    #region Data Access - Delete
    private void Child_DeleteSelf(POCDoc parent)
    {
      MarkNew();
    }



    #endregion //Data Access - Delete
#endif

  }
  #endregion
}
