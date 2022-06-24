using System;
using Csla;
using Csla.Serialization;
using System.Linq;

namespace e2.CDM.Lib
{ 
	[Serializable()] 
	public partial class Reference2Note : Csla.BusinessBase<Reference2Note>
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
        //public static readonly PropertyInfo<Guid> RefIDProperty = RegisterProperty<Guid>(c => c.RefID);
        //public Guid RefID
        //{
        //  get { return GetProperty(RefIDProperty); }
        //  set { SetProperty(RefIDProperty, value); }
        //}
        //public static readonly PropertyInfo<DateTime> Reference2NoteDateProperty = RegisterProperty<DateTime>(c => c.Reference2NoteDate);
        //public DateTime Reference2NoteDate
        //{
        //  get { return GetProperty(Reference2NoteDateProperty); }
        //  set { SetProperty(Reference2NoteDateProperty, value); }
        //}
        public static readonly PropertyInfo<Guid> References2NotesIDProperty = RegisterProperty<Guid>(nameof(References2NotesID));
        public Guid References2NotesID
        {
            get => GetProperty(References2NotesIDProperty);
            set => SetProperty(References2NotesIDProperty, value);
        }
        public static readonly PropertyInfo<string> RefIDProperty = RegisterProperty<string>(c => c.RefID);
    public string RefID
    {
      get { return GetProperty(RefIDProperty); }
      set { SetProperty(RefIDProperty, value); }
    }
    public static readonly PropertyInfo<DateTime> LastUpdateUTCDTProperty = RegisterProperty<DateTime>(c => c.LastUpdateUTCDT);
    public DateTime LastUpdateUTCDT
    {
      get { return GetProperty(LastUpdateUTCDTProperty); }
      set { SetProperty(LastUpdateUTCDTProperty, value); }
    }
    public static readonly PropertyInfo<string> Reference2NoteTypeProperty = RegisterProperty<string>(c => c.Reference2NoteType);
    public string Reference2NoteType
    {
      get { return GetProperty(Reference2NoteTypeProperty); }
      set { SetProperty(Reference2NoteTypeProperty, value); }
    }
    public static readonly PropertyInfo<Reference2NoteJsonBO> Reference2NoteJsonBOProperty = RegisterProperty<Reference2NoteJsonBO>(c => c.Reference2NoteJson);
    public Reference2NoteJsonBO Reference2NoteJson
    {
      get { return GetProperty(Reference2NoteJsonBOProperty); }
      set { SetProperty(Reference2NoteJsonBOProperty, value); }
    }
        public static readonly PropertyInfo<string> NotesProperty = RegisterProperty<string>(nameof(Notes));
        public string Notes
        {
            get => GetProperty(NotesProperty);
            set => SetProperty(NotesProperty, value);
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
   
    //  protected override object GetIdValue()
    //{
    //	return RefID;
    //}
    public void UpdateObjectID(string ReferenceID, string ReferenceType)
    {
      this.RefID = ReferenceID;
      this.Reference2NoteType = ReferenceType;
    }
    public static Reference2Note NewReference2Note()
    {   
        return DataPortal.CreateChild<Reference2Note>();
    }
    #endregion //Business Properties and Methods

    #region Factory Methods
    public Reference2Note()
		{ /* require use of factory method */ }

#if !SILVERLIGHT && !NETFX_CORE

		internal static Reference2Note GetReference2NoteChild(e2.CDM.DAL.Lib.References2Notes_GetByIDResult data)
		{
			return DataPortal.FetchChild<Reference2Note>(data);
		}
    #region Data Access


    #region Data Access - Child Fetch
    //private void Child_Fetch(Guid RefID)
    //{
    //  using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
    //                          .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
    //  {
    //    var data = ctx.DataContext.Reference2Note_GetByID(RefID).FirstOrDefault();
    //    if (data != null)
    //      Child_Fetch(data);
    //    else
    //      Child_Create();
    //  }

    //}
    private void Child_Fetch(e2.CDM.DAL.Lib.References2Notes_GetByIDResult data)
    {

      References2NotesID = data.References2NotesID;
      Reference2NoteType = data.RefType;
      RefID = data.RefID;   
      Notes = data.Notes;
      Status = data.Status;
      AuditInfoGuid = data.AuditInfoGuid;
      LastUpdateUTCDT = data.LastUpdateUTCDT;
      if (!string.IsNullOrEmpty(data.References2NotesJSON))
      {
        CDMDTO ammdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.References2NotesJSON);
        if (ammdto.ClassName.Equals("Reference2NoteJson"))
          Reference2NoteJson = DataPortal.FetchChild<Reference2NoteJsonBO>(data.References2NotesJSON);       
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
        string Reference2NoteJsonBOStr = null;
        if (Reference2NoteJson != null)
        {
          Reference2NoteJsonBOStr = OdataCDMJson<Reference2NoteJsonDTO>.GetJsonString(Reference2NoteJson.ConvertToDTO());
        }
        ctx.DataContext.References2Notes_Add( References2NotesID,  Reference2NoteType,RefID, Notes, Reference2NoteJsonBOStr,Status,AuditInfoGuid,DateTime.UtcNow);
      }
    }
     

      
    #endregion //Data Access - Child Insert

    #region Data Access - Child Update
    private void Child_Update(System.Object parent)
    {
      if (base.IsDirty)
      {
        using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
        {
                    string Reference2NoteJsonBOStr = null;
                    if (Reference2NoteJson != null)
                    {
                        Reference2NoteJsonBOStr = OdataCDMJson<Reference2NoteJsonDTO>.GetJsonString(Reference2NoteJson.ConvertToDTO());
                    }
                    ctx.DataContext.References2Notes_Upd(References2NotesID, Reference2NoteType, RefID, Notes, Reference2NoteJsonBOStr, Status, AuditInfoGuid, DateTime.UtcNow);
                }
      }
    }

    #endregion //Data Access - Child Update

    #region Data Access - Child Delete
    private void Child_DeleteSelf(System.Object parent)
    {
      using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
      {
        ctx.DataContext.References2Notes_Void(References2NotesID);
      }
    }

    #endregion //Data Access - Child Delete

    #endregion //Data Access


#endif

    #endregion //Factory Methods

    #region Data Access - Child Create
    protected override void Child_Create()
        {
            References2NotesID= Guid.NewGuid();
            AuditInfoGuid = Guid.NewGuid();
            Reference2NoteJson = Reference2NoteJsonBO.NewOrGetReference2NoteJson(this);
            base.Child_Create();
        }

        #endregion //Data Access - Child Create


    }


    #region Reference2NoteJson

    #region Reference2NoteJsonDTO

    public class Reference2NoteJsonDTO
    {
    public string ProjectID { get; set; }
  
    public string ClassName { get; set; }
    public Reference2NoteJsonDTO()
    {
      ClassName = "Reference2NoteJson";
    }

  }
  #endregion

  [Serializable()]
  public class Reference2NoteJsonBO : BusinessBase<Reference2NoteJsonBO>
  {
    #region Constructor
    public Reference2NoteJsonBO()
    {
      MarkAsChild();
    }

    public Reference2NoteJsonDTO ConvertToDTO()
    {
      Reference2NoteJsonDTO b = new Lib.Reference2NoteJsonDTO();
      b.ProjectID = this.ProjectID;
      return b;
    }

    #endregion

    #region Business Properties 
    public static readonly PropertyInfo<string> ProjectIDProperty = RegisterProperty<string>(c => c.ProjectID);
    public string ProjectID
    {
      get { return GetProperty(ProjectIDProperty); }
      set { SetProperty(ProjectIDProperty, value); }
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

    public static Reference2NoteJsonBO NewReference2NoteJson()
    {
      return DataPortal.CreateChild<Reference2NoteJsonBO>();
    }
    public static Reference2NoteJsonBO NewOrGetReference2NoteJson(Reference2Note obj)
    {
      if (obj.Reference2NoteJson != null)
        return obj.Reference2NoteJson;
      else
        return DataPortal.CreateChild<Reference2NoteJsonBO>();
    }
    protected override void Child_Create()
    {
      base.Child_Create();
    }

#if !NETFX_CORE
    private void Child_Fetch(string Reference2NoteJsondtojson)
    {
      using (null)
      {
        Reference2NoteJsonDTO Reference2NoteJson = Newtonsoft.Json.JsonConvert.DeserializeObject<Reference2NoteJsonDTO>(Reference2NoteJsondtojson);
        if (Reference2NoteJson != null)
          Child_Fetch(Reference2NoteJson);
      }
    }

    private void Child_Fetch(Reference2NoteJsonDTO data)
    {         
      ProjectID = data.ProjectID;
      MarkOld();
    }

        #region Data Access - Insert

    private void Child_Insert(Reference2Note parent)
    {
      MarkOld();
    }

        #endregion //Data Access - Insert

        #region Data Access - Update
    private void Child_Update(Reference2Note parent)
    {
      MarkOld();
    }

        #endregion //Data Access - Update

        #region Data Access - Delete
    private void Child_DeleteSelf(Reference2Note parent)
    {
      MarkNew();
    }



        #endregion //Data Access - Delete
#endif

    }
    #endregion
}
