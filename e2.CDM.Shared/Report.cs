using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{

  [Serializable()]
  public class Report : Csla.BusinessBase<Report>
  {

    #region Constuctor
    public Report()
    { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<Guid> ReportIDProperty = RegisterProperty<Guid>(c => c.ReportID);
    public Guid ReportID
    {
      get { return GetProperty(ReportIDProperty); }
      set { SetProperty(ReportIDProperty, value); }
    }
    public static readonly PropertyInfo<string> ReportNameProperty = RegisterProperty<string>(nameof(ReportName));
    public string ReportName
    {
      get => GetProperty(ReportNameProperty);
      set => SetProperty(ReportNameProperty, value);
    }
    public static readonly PropertyInfo<string> DisplayNameProperty = RegisterProperty<string>(nameof(DisplayName));
    public string DisplayName
    {
      get => GetProperty(DisplayNameProperty);
      set => SetProperty(DisplayNameProperty, value);
    }
    public static readonly PropertyInfo<string> ReportMRTstrProperty = RegisterProperty<string>(nameof(ReportMRTstr));
    public string ReportMRTstr
    {
      get => GetProperty(ReportMRTstrProperty);
      set => SetProperty(ReportMRTstrProperty, value);
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
    public static readonly PropertyInfo<ReportJsonBO> ReportJsonBOProperty = RegisterProperty<ReportJsonBO>(c => c.ReportJsonBO);
    public ReportJsonBO ReportJsonBO
    {
      get { return GetProperty(ReportJsonBOProperty); }
      set { SetProperty(ReportJsonBOProperty, value); }
    } 
    protected override object GetIdValue()
    {
      return ReportID;
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
      //TODO: Define CanGetObject permission in Report
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
      //	return true;
      //return false;
    }

    public static bool CanAddObject()
    {
      //TODO: Define CanAddObject permission in Report
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
      //	return true;
      //return false;
    }

    public static bool CanEditObject()
    {
      //TODO: Define CanEditObject permission in Report
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
      //	return true;
      //return false;
    }

    public static bool CanDeleteObject()
    {
      //TODO: Define CanDeleteObject permission in Report
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
      //	return true;
      //return false;
    }
    #endregion //Authorization Rules

    #region Factory Methods

    public static async System.Threading.Tasks.Task<Report> NewReportAsync()
    {
      try
      {
        if (!CanAddObject())
          throw new System.Security.SecurityException("User not authorized to add a Report");
        return await DataPortal.CreateAsync<Report>();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public static async System.Threading.Tasks.Task<Report> GetReportAsync(Guid ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a Report");
      return await DataPortal.FetchAsync<Report>(new Criteria(ID));
    }

    public static async void DeleteReportAsync(Guid ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a Report");
      await DataPortal.DeleteAsync<Report>(new Criteria(ID));
    }
#if !SILVERLIGHT && !NETFX_CORE
    public static Report NewReport()
    {
      if (!CanAddObject())
        throw new System.Security.SecurityException("User not authorized to add a Report");
      return DataPortal.Create<Report>();
    }
    public static Report GetReport(Guid ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a Report");
      return DataPortal.Fetch<Report>(new Criteria(ID));
    }
    public static void DeleteReport(Guid ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a Report");
      DataPortal.Delete<Report>(new Criteria(ID));
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
      ReportID = Guid.NewGuid();
      AuditInfoGuid = Guid.NewGuid();
      LastUpdateUTCDT = DateTime.UtcNow;
      Status = "ACTIVE";
      ReportJsonBO = ReportJsonBO.NewReportJSON();
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
          var data = mgr.DataContext.Report_GetByID(criteria.ID).FirstOrDefault();
          if (data != null)
          {
            ReportID = data.ReportID;
            ReportName = data.ReportName;
            ReportMRTstr = data.ReportMRTstr;
            DisplayName = data.DisplayName;
            Status = data.Status;
            AuditInfoGuid = data.AuditInfoGuid;
            if (!string.IsNullOrEmpty(data.ReportJSON))
            {
              CDMDTO cDMDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.ReportJSON);
              if (cDMDTO.ClassName.Equals("ReportJson"))
                ReportJsonBO = DataPortal.FetchChild<ReportJsonBO>(data.ReportJSON);
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
          string ReportJsonBOStr = null;
          if (ReportJsonBO != null)
          {
            ReportJsonBOStr = OdataCDMJson<ReportJsonDTO>.GetJsonString(ReportJsonBO.ConvertToDTO());
          }
          mgr.DataContext.Report_Add(ReportID,ReportName,DisplayName,ReportMRTstr, ReportJsonBOStr, Status, AuditInfoGuid, DateTime.Now);
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
      //if (ReportID == "NEW")
      //{
      //  ReportID = CDMEntityKeys.ReportIDNextId();
      //}

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
          string ReportJsonBOStr = null;
          if (ReportJsonBO != null)
          {
            ReportJsonBOStr = OdataCDMJson<ReportJsonDTO>.GetJsonString(ReportJsonBO.ConvertToDTO());
          }
          mgr.DataContext.Report_Upd(ReportID, ReportName, DisplayName, ReportMRTstr, ReportJsonBOStr, Status, AuditInfoGuid, DateTime.Now);
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
        mgr.DataContext.Report_Void(criteria.ID);
      }//using
    }
    #endregion //Data Access - Delete

#endif
    #endregion //Data Access
  }

  #region ReportJsonDTOJSON

  #region ReportJsonDTO

  public class ReportJsonDTO
  {
    public string ReportDesc { get; set; }

    //public DateTime TranDate { get; set; }
    //public DateTime FromDate { get; set; }
    //public DateTime ToDate { get; set; }
    //public string ApplicableTo { get; set; }     
    //public int NoOfDays { get; set; }
    public string ClassName { get; set; }
    public ReportJsonDTO()
    {
      ClassName = "ReportJson";
    }
  }
  #endregion

  [Serializable()]
  public class ReportJsonBO : BusinessBase<ReportJsonBO>
  {
    #region Constructor
    public ReportJsonBO()
    {
      MarkAsChild();
    }

    public ReportJsonDTO ConvertToDTO()
    {
      ReportJsonDTO b = new ReportJsonDTO();
      b.ReportDesc = this.ReportDesc;
      return b;
    }
    #endregion

    #region Business Properties

    public static readonly PropertyInfo<string> ReportDescProperty = RegisterProperty<string>(c => c.ReportDesc);
    public string ReportDesc
    {
      get { return GetProperty(ReportDescProperty); }
      set { SetProperty(ReportDescProperty, value); }
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

    public static ReportJsonBO NewReportJSON()
    {
      return DataPortal.CreateChild<ReportJsonBO>();
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
        ReportJsonDTO ReportJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ReportJsonDTO>(BlogJsondtojson);
        if (ReportJson != null)
          Child_Fetch(ReportJson);
      }
    }
    private void Child_Fetch(ReportJsonDTO data)
    {

      ReportDesc = data.ReportDesc;
      MarkOld();
    }

    #region Data Access - Insert

    private void Child_Insert(Report parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Insert

    #region Data Access - Update
    private void Child_Update(Report parent)
    {
      MarkOld();
    }

    #endregion //Data Access - Update

    #region Data Access - Delete
    private void Child_DeleteSelf(Report parent)
    {
      MarkNew();
    }
    #endregion //Data Access - Delete
#endif
  }
  #endregion

}