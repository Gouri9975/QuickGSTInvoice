using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
  public class OdataCsla
  {
    public static Csla.IDataPortalFactory DataPortalFactory { get;  set; }
  }

  [Serializable()]
  public class RouteEvent : Csla.BusinessBase<RouteEvent>
  {

    #region Constuctor
    public RouteEvent()
    {
    

    }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<Guid> EventIDProperty = RegisterProperty<Guid>(c => c.EventID);
    public Guid EventID
    {
      get { return GetProperty(EventIDProperty); }
      set { SetProperty(EventIDProperty, value); }
    }

    public static readonly PropertyInfo<DateTime> EventDateTimeProperty = RegisterProperty<DateTime>(c => c.EventDateTime);
    public DateTime EventDateTime
    {
      get { return GetProperty(EventDateTimeProperty); }
      set { SetProperty(EventDateTimeProperty, value); }
    }
    public static readonly PropertyInfo<string> EventStatusProperty = RegisterProperty<string>(c => c.EventStatus);
    public string EventStatus
    {
      get { return GetProperty(EventStatusProperty); }
      set { SetProperty(EventStatusProperty, value); }
    }
    public static readonly PropertyInfo<string> DriverIDProperty = RegisterProperty<string>(c => c.DriverID);
    public string DriverID
    {
        get { return GetProperty(DriverIDProperty); }
        set { SetProperty(DriverIDProperty, value); }
    }
    public static readonly PropertyInfo<string> RouteIDProperty = RegisterProperty<string>(c => c.RouteID);
    public string RouteID
    {
        get { return GetProperty(RouteIDProperty); }
        set { SetProperty(RouteIDProperty, value); }
    }
    public static readonly PropertyInfo<string> RouteStatusProperty = RegisterProperty<string>(c => c.RouteStatus);
    public string RouteStatus
    {
        get { return GetProperty(RouteStatusProperty); }
        set { SetProperty(RouteStatusProperty, value); }
    }

    public static readonly PropertyInfo<string> RouteEventJsonBOProperty = RegisterProperty<string>(c => c.RouteEventJsonBO);
    public string RouteEventJsonBO
    {
      get { return GetProperty(RouteEventJsonBOProperty); }
      set { SetProperty(RouteEventJsonBOProperty, value); }
    }
    public CurrentTripInfoModel GetcurrentTripInfoModel()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentTripInfoModel>(RouteEventJsonBO);
    }
     
    //public static readonly PropertyInfo<RouteEventJsonBO> RouteEventJsonBOProperty = RegisterProperty<RouteEventJsonBO>(c => c.RouteEventJsonBO);
    //public RouteEventJsonBO RouteEventJsonBO
    //{
    //  get { return GetProperty(RouteEventJsonBOProperty); }
    //  set { SetProperty(RouteEventJsonBOProperty, value); }
    //}
    
    protected override object GetIdValue()
    {
      return EventID;
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

      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(InvReceiptEventStatusProperty));
      //BusinessRules.AddRule(new Csla.Rules.CommonRules.MaxLength(InvReceiptEventStatusProperty, 20));
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
      //TODO: Define CanGetObject permission in RouteEvent
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
      //	return true;
      //return false;
    }

    public static bool CanAddObject()
    {
      //TODO: Define CanAddObject permission in RouteEvent
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
      //	return true;
      //return false;
    }

    public static bool CanEditObject()
    {
      //TODO: Define CanEditObject permission in RouteEvent
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
      //	return true;
      //return false;
    }

    public static bool CanDeleteObject()
    {
      //TODO: Define CanDeleteObject permission in RouteEvent
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
      //	return true;
      //return false;
    }
    #endregion //Authorization Rules

    //public RouteEvent(IDataPortalFactory factory)
    //{
    //  Portal = factory.GetPortal<RouteEvent>();
    //}

    public static IDataPortal<RouteEvent> Portal { get; set; }

    public async System.Threading.Tasks.Task<RouteEvent> GetAsync(int personId)
    {   
      return await Portal.FetchAsync(personId);
    }

    #region Factory Methods

    public static async System.Threading.Tasks.Task<RouteEvent> NewRouteEventAsync()
    {
      try
      {
        if (!CanAddObject())
          throw new System.Security.SecurityException("User not authorized to add a RouteEvent");
        return await Portal.CreateAsync();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public static async System.Threading.Tasks.Task<RouteEvent> GetRouteEventAsync(Guid ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a RouteEvent");
      return await Portal.FetchAsync(new Criteria(ID));
    }

    public static async void DeleteRouteEventAsync(Guid ID, IDataPortal<RouteEvent> dataPortal)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a RouteEvent");
      await Portal.DeleteAsync(new Criteria(ID), dataPortal);
    }
#if !SILVERLIGHT && !NETFX_CORE 
    public static RouteEvent NewRouteEvent()
    {
      if (!CanAddObject())
        throw new System.Security.SecurityException("User not authorized to add a RouteEvent");
      return Portal.Create();
    }
    public  RouteEvent GetRouteEvent(Guid ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a RouteEvent");
      return Portal.Fetch(new Criteria(ID));
    }
    public static void DeleteRouteEvent(Guid ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a RouteEvent");
      Portal.Delete(new Criteria(ID));
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
    [Create]
    protected  void DataPortal_Create()
    {
      EventID = Guid.NewGuid();
      //      AuditInfoGuid = Guid.NewGuid();
      //LastUpdateUTCDT = DateTime.UtcNow;
      EventStatus = "ACTIVE";

      //RouteEventJsonBO = RouteEventJsonBO.NewRouteEventJSON();
     // base.DataPortal_Create();

      BusinessRules.CheckRules();
    }

    #endregion //Data Access - Create

    #region Data Access

#if !NETFX_CORE
    #region Data Access - Fetch
    [Fetch]
    private void DataPortal_Fetch(Criteria criteria)
    {
      try
      {
        //using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
        //      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
        //{
        //  //set option to eager load child object(s)
        //  var data = mgr.DataContext.RouteEvent_GetByID(criteria.ID).FirstOrDefault();
        //  if (data != null)
        //  {
        //    EventID = data.EventID;
        //                EventDateTime = data.EventDateTime;
        //    EventStatus = data.EventStatus;
        //                DriverID = data.DriverID;
        //                RouteID = data.RouteID;
        //                RouteStatus = data.RouteStatus;
        //                RouteEventJsonBO = data.RouteEventJSON;
        //    //if (!string.IsNullOrEmpty(data.RouteEventJSON))
        //    //{
        //    //  CDMDTO CDMdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.RouteEventJSON);
        //    //  if (CDMdto.ClassName.Equals("RouteEventJson"))
        //    //    RouteEventJsonBO = DataPortal.FetchChild<RouteEventJsonBO>(data.RouteEventJSON);
        //    //}
        //  }
        //  MarkOld();
        //}

      }//using
      catch (Exception e)
      {
        throw;
      }
    }

    #endregion //Data Access - Fetch

    #region Data Access - Insert

    [Transactional(TransactionalTypes.TransactionScope)]
    [Insert]
    protected  void DataPortal_Insert()
    {
      try
      {
        UpdateObjectIDs();

        //using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
        //      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
        //{
        //  //string RouteEventJsonBOStr = null;
        //  //if (RouteEventJsonBO != null)
        //  //{
        //  //  RouteEventJsonBOStr = OdataCDMJson<RouteEventJsonDTO>.GetJsonString(RouteEventJsonBO.ConvertToDTO());
        //  //}
        //  mgr.DataContext.RouteEvent_Add(EventID, EventDateTime, EventStatus, DriverID, RouteID, RouteStatus, RouteEventJsonBO);
        //  FieldManager.UpdateChildren(this);
        //}//using
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    #endregion //Data Access - Insert
    private void UpdateObjectIDs()
    {
      //if (EventID == "NEW")
      //{
      //  EventID = CDMEntityKeys.EventIDNextId();
      //}

      //if (sa == "NEW")
      //{
      //    InvReceiptNo = CDMEntityKeys.INVRECEIPTNONextId();
      //}
    }

    #region Data Access - Update
    [Transactional(TransactionalTypes.TransactionScope)]
    [Update]
    protected  void DataPortal_Update()
    {
      try
      {
        UpdateObjectIDs();

        //using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
        //      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
        //{
        //  //string RouteEventJsonBOStr = null;
        //  //if (RouteEventJsonBO != null)
        //  //{
        //  //  RouteEventJsonBOStr = OdataCDMJson<RouteEventJsonDTO>.GetJsonString(RouteEventJsonBO.ConvertToDTO());
        //  //}
        //  mgr.DataContext.RouteEvent_Upd(EventID, EventDateTime, EventStatus, DriverID, RouteID, RouteStatus, RouteEventJsonBO);
        //  FieldManager.UpdateChildren(this);
        //}//using
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    #endregion //Data Access - Update

    #region Data Access - Delete
    [Delete]
    private void DataPortal_Delete(Criteria criteria)
    {
      //using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
      //             .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
      //{
      //  mgr.DataContext.RouteEvent_Remove(criteria.ID);
      //}//using
    }
    #endregion //Data Access - Delete

#endif
    #endregion //Data Access
  }

    //  #region RouteEventJsonDTOJSON

    //  #region RouteEventJsonDTO

    //  public class RouteEventJsonDTO
    //  {

    //    public string RouteEventDesc { get; set; }
    //    public string IdentificationStr { get; set; }
    //    public string RouteEventCategory { get; set; }
    //    public bool AuxRouteEvent { get; set; }
    //    public string GroupCat { get; set; }
    //    public bool TripAssigned { get; set; }
    //    public DateTime TripAssignedDate { get; set; }
    //    public string TripAssignedID { get; set; }
    //    public bool RShipAssigned { get; set; }
    //    public string RouteEventClass { get; set; }
    //    public string RShipAssignedID { get; set; }
    //    public string ClassName { get; set; }
    //    public RouteEventJsonDTO()
    //    {
    //      ClassName = "RouteEventJson";
    //    }
    //  }
    //  #endregion

    //  [Serializable()]
    //  public class RouteEventJsonBO : BusinessBase<RouteEventJsonBO>
    //  {
    //    #region Constructor
    //    public RouteEventJsonBO()
    //    {
    //      MarkAsChild();
    //    }

    //    public RouteEventJsonDTO ConvertToDTO()
    //    {
    //      RouteEventJsonDTO b = new RouteEventJsonDTO();
    //      b.RouteEventDesc = this.RouteEventDesc;
    //      b.IdentificationStr = this.IdentificationStr;
    //      b.RouteEventCategory = this.RouteEventCategory;
    //      b.AuxRouteEvent = this.AuxRouteEvent;
    //      b.GroupCat = this.GroupCat;
    //      b.TripAssigned = this.TripAssigned;
    //      b.TripAssignedDate = this.TripAssignedDate;
    //      b.TripAssignedID = this.TripAssignedID;
    //      b.RShipAssigned = this.RShipAssigned;
    //      b.RShipAssignedID = this.RShipAssignedID;
    //      b.RouteEventClass = RouteEventClass;
    //      return b;
    //    }
    //    #endregion

    //    #region Business Properties
    //    public static readonly PropertyInfo<string> IdentificationStrProperty = RegisterProperty<string>(c => c.IdentificationStr);
    //    public string IdentificationStr
    //    {
    //      get { return GetProperty(IdentificationStrProperty); }
    //      set { SetProperty(IdentificationStrProperty, value); }
    //    }

    //    public static readonly PropertyInfo<string> RouteEventDescProperty = RegisterProperty<string>(c => c.RouteEventDesc);
    //    public string RouteEventDesc
    //    {
    //      get { return GetProperty(RouteEventDescProperty); }
    //      set { SetProperty(RouteEventDescProperty, value); }
    //    }
    //    public static readonly PropertyInfo<string> RouteEventCategoryProperty = RegisterProperty<string>(c => c.RouteEventCategory);
    //    public string RouteEventCategory
    //    {
    //      get { return GetProperty(RouteEventCategoryProperty); }
    //      set { SetProperty(RouteEventCategoryProperty, value); }
    //    }
    //    public static readonly PropertyInfo<bool> AuxRouteEventProperty = RegisterProperty<bool>(c => c.AuxRouteEvent);
    //    public bool AuxRouteEvent
    //    {
    //      get { return GetProperty(AuxRouteEventProperty); }
    //      set { SetProperty(AuxRouteEventProperty, value); }
    //    }
    //    public static readonly PropertyInfo<string> GroupCatProperty = RegisterProperty<string>(c => c.GroupCat);
    //    public string GroupCat
    //    {
    //      get { return GetProperty(GroupCatProperty); }
    //      set { SetProperty(GroupCatProperty, value); }
    //    }
    //    public static readonly PropertyInfo<bool> TripAssignedProperty = RegisterProperty<bool>(c => c.TripAssigned);
    //    public bool TripAssigned
    //    {
    //      get { return GetProperty(TripAssignedProperty); }
    //      set { SetProperty(TripAssignedProperty, value); }
    //    }
    //    public static readonly PropertyInfo<DateTime> TripAssignedDateProperty = RegisterProperty<DateTime>(c => c.TripAssignedDate);
    //    public DateTime TripAssignedDate
    //    {
    //      get { return GetProperty(TripAssignedDateProperty); }
    //      set { SetProperty(TripAssignedDateProperty, value); }
    //    }
    //    public static readonly PropertyInfo<string> TripAssignedIDProperty = RegisterProperty<string>(c => c.TripAssignedID);
    //    public string TripAssignedID
    //    {
    //      get { return GetProperty(TripAssignedIDProperty); }
    //      set { SetProperty(TripAssignedIDProperty, value); }
    //    }
    //    public static readonly PropertyInfo<bool> RShipAssignedProperty = RegisterProperty<bool>(c => c.RShipAssigned);
    //    public bool RShipAssigned
    //    {
    //      get { return GetProperty(RShipAssignedProperty); }
    //      set { SetProperty(RShipAssignedProperty, value); }
    //    }
    //    public static readonly PropertyInfo<DateTime> RShipAssignedDateProperty = RegisterProperty<DateTime>(c => c.RShipAssignedDate);
    //    public DateTime RShipAssignedDate
    //    {
    //      get { return GetProperty(RShipAssignedDateProperty); }
    //      set { SetProperty(RShipAssignedDateProperty, value); }
    //    }
    //    public static readonly PropertyInfo<string> RouteEventClassProperty = RegisterProperty<string>(c => c.RouteEventClass);
    //    public string RouteEventClass
    //    {
    //      get { return GetProperty(RouteEventClassProperty); }
    //      set { SetProperty(RouteEventClassProperty, value); }
    //    }
    //    public static readonly PropertyInfo<string> RShipAssignedIDProperty = RegisterProperty<string>(c => c.RShipAssignedID);
    //    public string RShipAssignedID
    //    {
    //      get { return GetProperty(RShipAssignedIDProperty); }
    //      set { SetProperty(RShipAssignedIDProperty, value); }
    //    }

    //    #endregion

    //    #region Validation Rules
    //    protected override void AddBusinessRules()
    //    {
    //      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(HeadingProperty));
    //      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(SubHeadingProperty));
    //      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(ContentProperty));
    //      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(TagsProperty));
    //      //BusinessRules.AddRule(new Csla.Rules.CommonRules.Required(RatingProperty));
    //    }
    //    #endregion

    //    public static RouteEventJsonBO NewRouteEventJSON()
    //    {
    //      return DataPortal.CreateChild<RouteEventJsonBO>();
    //    }
    //    protected override void Child_Create()
    //    {
    //      base.Child_Create();
    //    }

    //#if !NETFX_CORE
    //    private void Child_Fetch(string BlogJsondtojson)
    //    {
    //      using (null)
    //      {
    //        RouteEventJsonDTO RouteEventJson = Newtonsoft.Json.JsonConvert.DeserializeObject<RouteEventJsonDTO>(BlogJsondtojson);
    //        if (RouteEventJson != null)
    //          Child_Fetch(RouteEventJson);
    //      }
    //    }
    //    private void Child_Fetch(RouteEventJsonDTO data)
    //    {

    //      RouteEventDesc = data.RouteEventDesc;
    //      IdentificationStr = data.IdentificationStr;
    //      RouteEventCategory = data.RouteEventCategory;
    //      AuxRouteEvent = data.AuxRouteEvent;
    //      GroupCat = data.GroupCat;
    //      TripAssigned = data.TripAssigned;
    //      TripAssignedDate = data.TripAssignedDate;
    //      TripAssignedID = data.TripAssignedID;
    //      RShipAssigned = data.RShipAssigned;
    //      RShipAssignedID = data.RShipAssignedID;
    //      RouteEventClass = data.RouteEventClass;
    //      MarkOld();
    //    }

    //    #region Data Access - Insert

    //    private void Child_Insert(RouteEvent parent)
    //    {
    //      MarkOld();
    //    }

    //    #endregion //Data Access - Insert

    //    #region Data Access - Update
    //    private void Child_Update(RouteEvent parent)
    //    {
    //      MarkOld();
    //    }

    //    #endregion //Data Access - Update

    //    #region Data Access - Delete
    //    private void Child_DeleteSelf(RouteEvent parent)
    //    {
    //      MarkNew();
    //    }
    //    #endregion //Data Access - Delete
    //#endif
    //  }
    //  #endregion


    public class CurrentTripInfoModel
    {
        public string DriverID
        {
            get; set;
        }
        public string DriverName
        {
            get; set;
        }
        public string TripID
        {
            get; set;
        }
        public string TripName
        {
            get; set;
        }
        public LocationInfoModel FromLocation
        {
            get; set;
        }
        public LocationInfoModel ToLocation
        {
            get; set;
        }
        public string TripStatus
        {
            get; set;
        }
        public string LastTripStatus
        {
            get; set;
        }
        public decimal DistanceTraveled
        {
            get; set;
        }
        public int TotalTripTimeMin
        {
            get; set;
        }
        public double distanceFromSource
        {
            get; set;
        }
        public double distanceToDestination
        {
            get; set;
        }
        public TimeSpan TripTime
        {
            get; set;
        }
        public string Currentlatitude
        {
            get; set;
        }
        public string Currentlongitude
        {
            get; set;
        }
        public bool IsManualMode
        {
            get; set;
        }
        public decimal FromGeofenceArea
        {
            get; set;
        }
        public decimal ToGeofenceArea
        {
            get; set;
        }
        public bool FromInsideGeofence
        {
            get; set;
        }
        public bool ToInsideGeofence
        {
            get; set;
        }
        public DateTime EventDT
        {
            get; set;
        }

    }

    public class LocationInfoModel
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string AddressInfoID { get; set; }
        public string AddressTypeID { get; set; }
        public Guid AuditInfoGuid { get; set; }
       // public e2.BDM.Lib.LocationJsonDTO LocationJson { get; set; }
      //  public e2.BDM.Lib.GeoInfoJsonDTO GeoInfoJson { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string ContactInfoID { get; set; }
        public string ContactName { get; set; }
        public string ContactType { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string LocationID { get; set; }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Title { get; set; }
    }

}