using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;
using e2.BDM.Lib;
using System.Xml.Linq;

namespace e2.CDM.Lib
{
  [Serializable()]
  public class HResource : Csla.BusinessBase<HResource>
  {

    #region Constuctor
    public HResource()
    { }
    #endregion

    #region Business Properties and Methods

    public static readonly PropertyInfo<string> HResourceIDProperty = RegisterProperty<string>(c => c.HResourceID);
    public string HResourceID
    {
      get { return GetProperty(HResourceIDProperty); }
      set { SetProperty(HResourceIDProperty, value); }
    }
    public static readonly PropertyInfo<string> ResourceTypeProperty = RegisterProperty<string>(c => c.ResourceType);
    public string ResourceType
    {
      get { return GetProperty(ResourceTypeProperty); }
      set { SetProperty(ResourceTypeProperty, value); }
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
    public static readonly PropertyInfo<DateTime?> LastUpdateUTCDTProperty = RegisterProperty<DateTime?>(c => c.LastUpdateUTCDT);
    public DateTime? LastUpdateUTCDT
    {
      get { return GetProperty(LastUpdateUTCDTProperty); }
      set { SetProperty(LastUpdateUTCDTProperty, value); }
    }
    public static readonly PropertyInfo<HResourcesJsonBO> HResourcesJsonBOProperty = RegisterProperty<HResourcesJsonBO>(c => c.HResourcesJsonBO);
    public HResourcesJsonBO HResourcesJsonBO
    {
      get { return GetProperty(HResourcesJsonBOProperty); }
      set { SetProperty(HResourcesJsonBOProperty, value); }
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
      private set { SetProperty(ContactAddressesDtlsProperty, value); }
    }
    protected override object GetIdValue()
    {
      return HResourceID;
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
      //TODO: Define CanGetObject permission in ItemsHResource
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogViewGroup"))
      //	return true;
      //return false;
    }

    public static bool CanAddObject()
    {
      //TODO: Define CanAddObject permission in ItemsHResource
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogAddGroup"))
      //	return true;
      //return false;
    }

    public static bool CanEditObject()
    {
      //TODO: Define CanEditObject permission in ItemsHResource
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogEditGroup"))
      //	return true;
      //return false;
    }

    public static bool CanDeleteObject()
    {
      //TODO: Define CanDeleteObject permission in ItemsHResource
      return true;
      //if (Csla.ApplicationContext.User.IsInRole("BlogDeleteGroup"))
      //	return true;
      //return false;
    }
    #endregion //Authorization Rules

    #region Factory Methods

    public static async System.Threading.Tasks.Task<HResource> NewHResourceAsync()
    {
      try
      {
        if (!CanAddObject())
          throw new System.Security.SecurityException("User not authorized to add a HResource");
        return await DataPortal.CreateAsync<HResource>();
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public static async System.Threading.Tasks.Task<HResource> GetHResourcesAsync(String ID)
    {
      if (!CanGetObject())
        throw new System.Security.SecurityException("User not authorized to view a HResource");
      return await DataPortal.FetchAsync<HResource>(new Criteria(ID));
    }

    public static async void DeleteHResourceAsync(string ID)
    {
      if (!CanDeleteObject())
        throw new System.Security.SecurityException("User not authorized to remove a HResource");
      await DataPortal.DeleteAsync<HResource>(new Criteria(ID));
    }
#if !SILVERLIGHT && !NETFX_CORE
        public static HResource NewHResources()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ItemsHResource");
            return DataPortal.Create<HResource>();
        }
        public static HResource GetHResource(string ID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ItemsHResource");
            return DataPortal.Fetch<HResource>(new Criteria(ID));
        }
        public static void DeleteHResource(string ID)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ItemsHResource");
            DataPortal.Delete<HResource>(new Criteria(ID));
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
      HResourceID = "NEW";
      AuditInfoGuid = Guid.NewGuid();
      LastUpdateUTCDT = DateTime.UtcNow;
      Status = "ACTIVE";
      HResourcesJsonBO = HResourcesJsonBO.NewHResourcesJSON();
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
                    var data = mgr.DataContext.HResource_GetByID(criteria.ID).FirstOrDefault();
                    if (data != null)
                    {
                        HResourceID = data.HResourceID;
                        ResourceType = data.ResourceType;
                        Status = data.Status;
                        AuditInfoGuid = data.AuditInfoGuid;
                        if (!string.IsNullOrEmpty(data.HResourceJSON))
                        {
                            CDMDTO ivmdto = Newtonsoft.Json.JsonConvert.DeserializeObject<CDMDTO>(data.HResourceJSON);
                            if (ivmdto.ClassName.Equals("HResourcesJson"))
                                HResourcesJsonBO = DataPortal.FetchChild<HResourcesJsonBO>(data.HResourceJSON);
                        }
                        var res = DataPortal.FetchChild<ContactAddressesDtls>(new KeyValuePair<string, string>(HResourcesJsonBO.Code, "WOHRESOURCE")).Where(r => r.AddressTypeID != "BILLTO");
                        ContactAddressesDtls.AddRange(res);
                    
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
                    string HResourcesJsonBOStr = null;
                    if (HResourcesJsonBO != null)
                    {
                        HResourcesJsonBOStr = OdataCDMJson<HResourcesJsonDTO>.GetJsonString(HResourcesJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.HResource_Add(HResourceID, ResourceType, HResourcesJsonBOStr, Status, DateTime.UtcNow, AuditInfoGuid);
                    UpdateContactAddressDtlKeys(mgr);
                    FieldManager.UpdateChildren(this);
                }//using
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void UpdateContactAddressDtlKeys(Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext> mgr)
        {
            XElement keysInfo = new XElement("ContactAddressDtlKeys");

            foreach (ContactAddressDtl child in ContactAddressesDtls)
            {
                string isPrimary = "false";
                if (child.PrimaryAddress)
                {
                    isPrimary = "true";
                }
                keysInfo.Add(new XElement("KeyInfo",
                                 new XAttribute("EntityID", this.HResourceID),
                                 new XAttribute("ContactAddressDtlID", child.ContactAddressDtlID),
                                 new XAttribute("IsPrimary", isPrimary),
                                 new XAttribute("ContactAddressTypeID", child.PrimaryAddress ? "PRIMARY" : child.AddressTypeID)
                                 ));
            }

            //using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.BDM.DAL.Lib.BDMEntitiesDataContext>
            //                          .GetManager(e2.BDM.DAL.Lib.Database.BDMConnection))
            //{
                mgr.DataContext.ContactAddressesDtl_InsUpdKeysByEntityTypeID("WOHRESOURCE", keysInfo);
           // }
        }

    #endregion //Data Access - Insert
        private void UpdateObjectIDs()
        {
            if (HResourceID == "NEW")
            {
                HResourceID = CDMEntityKeys.HResourceIDNextId();
                HResourcesJsonBO.Code= CDMEntityKeys.HResourceCodeNextId();
            }
            ContactAddressesDtls.UpdateObjectIDs(HResourceID, HResourcesJsonBO.Code);
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
                    string HResourcesJsonBOStr = null;
                    if (HResourcesJsonBO != null)
                    {
                        HResourcesJsonBOStr = OdataCDMJson<HResourcesJsonDTO>.GetJsonString(HResourcesJsonBO.ConvertToDTO());
                    }
                    mgr.DataContext.HResource_Upd(HResourceID, ResourceType, HResourcesJsonBOStr, Status, DateTime.UtcNow, AuditInfoGuid);
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
                    mgr.DataContext.HResource_Void(criteria.ID);
            }//using
        }
    #endregion //Data Access - Delete

#endif
    #endregion //Data Access
  }

  #region HResourcesJsonDTOJSON

  #region HResourcesJsonDTO

  public class HResourcesJsonDTO
  {
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string PhoneNo { get; set; }
    public string Gender { get; set; }
    public string Code { get; set; }
    public string EmailId { get; set; }
    public string Location { get; set; }
    public string PostalCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DriverLicenseNo { get; set; }
    public string DriverClass { get; set; }
    public bool IsSourceAgency { get; set; }
    public bool TripAssigned { get; set; }
    public string TripAssignedID { get; set; }
    public DateTime AssignedDate { get; set; }
    public bool TripPlanned { get; set; }
    public string TripPlannedID { get; set; }                               
    public string Latitude { get; set; }                                    
    public string Longitude { get; set; }                                   
    public string Altitude { get; set; }
    public DateTime PlannedDate { get; set; }
    public string ClassName { get; set; }
    public HResourcesJsonDTO()
    {
      ClassName = "HResourcesJson";
    }
  }
  #endregion

  [Serializable()]
  public class HResourcesJsonBO : BusinessBase<HResourcesJsonBO>
  {
    #region Constructor
    public HResourcesJsonBO()
    {
      MarkAsChild();
    }

    public HResourcesJsonDTO ConvertToDTO()
    {
      HResourcesJsonDTO b = new HResourcesJsonDTO();
      b.Name = this.Name;
      b.Address = Address;
      b.FirstName = this.FirstName;
      b.LastName = this.LastName;
      b.DriverLicenseNo = this.DriverLicenseNo;
      b.DriverClass = this.DriverClass;
      b.IsSourceAgency = this.IsSourceAgency;
      b.TripAssigned = this.TripAssigned;
      b.TripAssignedID = this.TripAssignedID;
      b.TripPlannedID = this.TripPlannedID;
      b.AssignedDate = this.AssignedDate;
      b.TripPlanned = this.TripPlanned;
      b.PlannedDate = this.PlannedDate;
      b.City = this.City;
      b.Province = this.Province;
      b.PhoneNo = this.PhoneNo;
      b.Gender = this.Gender;
      b.Code = this.Code;
      b.Latitude = this.Latitude;
      b.Longitude = this.Longitude;
      b.Altitude = this.Altitude;
      return b;
    }
    #endregion

    #region Business Properties

    public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
    public string FirstName
    {
      get { return GetProperty(FirstNameProperty); }
      set { SetProperty(FirstNameProperty, value); }
    }
    public static readonly PropertyInfo<string> AddressProperty = RegisterProperty<string>(c => c.Address);
    public string Address
    {
      get { return GetProperty(AddressProperty); }
      set { SetProperty(AddressProperty, value); }
    }
    public static readonly PropertyInfo<string> AltitudeProperty = RegisterProperty<string>(c => c.Altitude);
    public string Altitude
    {
      get { return GetProperty(AltitudeProperty); }
      set { SetProperty(AltitudeProperty, value); }
    }
    public static readonly PropertyInfo<string> LongitudeProperty = RegisterProperty<string>(c => c.Longitude);
    public string Longitude
    {
      get { return GetProperty(LongitudeProperty); }
      set { SetProperty(LongitudeProperty, value); }
    }
    public static readonly PropertyInfo<string> LatitudeProperty = RegisterProperty<string>(c => c.Latitude);
    public string Latitude
    {
      get { return GetProperty(LatitudeProperty); }
      set { SetProperty(LatitudeProperty, value); }
    }
    public static readonly PropertyInfo<string> CodeProperty = RegisterProperty<string>(c => c.Code);
    public string Code
    {
      get { return GetProperty(CodeProperty); }
      set { SetProperty(CodeProperty, value); }
    }
    public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
    public string LastName
    {
      get { return GetProperty(LastNameProperty); }
      set { SetProperty(LastNameProperty, value); }
    }
    public static readonly PropertyInfo<string> DriverLicenseNoProperty = RegisterProperty<string>(c => c.DriverLicenseNo);
    public string DriverLicenseNo
    {
      get { return GetProperty(DriverLicenseNoProperty); }
      set { SetProperty(DriverLicenseNoProperty, value); }
    }
    public static readonly PropertyInfo<string> DriverClassProperty = RegisterProperty<string>(c => c.DriverClass);
    public string DriverClass
    {
      get { return GetProperty(DriverClassProperty); }
      set { SetProperty(DriverClassProperty, value); }
    }
    public static readonly PropertyInfo<bool> IsSourceAgencyProperty = RegisterProperty<bool>(c => c.IsSourceAgency);
    public bool IsSourceAgency
    {
      get { return GetProperty(IsSourceAgencyProperty); }
      set { SetProperty(IsSourceAgencyProperty, value); }
    }
    public static readonly PropertyInfo<bool> TripAssignedProperty = RegisterProperty<bool>(c => c.TripAssigned);
    public bool TripAssigned
    {
      get { return GetProperty(TripAssignedProperty); }
      set { SetProperty(TripAssignedProperty, value); }
    }
    public static readonly PropertyInfo<string> TripAssignedIDProperty = RegisterProperty<string>(c => c.TripAssignedID);
    public string TripAssignedID
    {
      get { return GetProperty(TripAssignedIDProperty); }
      set { SetProperty(TripAssignedIDProperty, value); }
    }
    public static readonly PropertyInfo<DateTime> AssignedDateProperty = RegisterProperty<DateTime>(c => c.AssignedDate);
    public DateTime AssignedDate
    {
      get { return GetProperty(AssignedDateProperty); }
      set { SetProperty(AssignedDateProperty, value); }
    }
    public static readonly PropertyInfo<bool> TripPlannedProperty = RegisterProperty<bool>(c => c.TripPlanned);
    public bool TripPlanned
    {
      get { return GetProperty(TripPlannedProperty); }
      set { SetProperty(TripPlannedProperty, value); }
    }
    public static readonly PropertyInfo<string> TripPlannedIDProperty = RegisterProperty<string>(c => c.TripPlannedID);
    public string TripPlannedID
    {
      get { return GetProperty(TripPlannedIDProperty); }
      set { SetProperty(TripPlannedIDProperty, value); }
    }
    public static readonly PropertyInfo<DateTime> PlannedDateProperty = RegisterProperty<DateTime>(c => c.PlannedDate);
    public DateTime PlannedDate
    {
      get { return GetProperty(PlannedDateProperty); }
      set { SetProperty(PlannedDateProperty, value); }
    }

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
    public string Name
    {
      get { return GetProperty(NameProperty); }
      set { SetProperty(NameProperty, value); }
    }

    public static readonly PropertyInfo<string> CityProperty = RegisterProperty<string>(c => c.City);
    public string City
    {
      get { return GetProperty(CityProperty); }
      set { SetProperty(CityProperty, value); }
    }

    public static readonly PropertyInfo<string> ProvinceProperty = RegisterProperty<string>(c => c.Province);
    public string Province
    {
      get { return GetProperty(ProvinceProperty); }
      set { SetProperty(ProvinceProperty, value); }
    }

    public static readonly PropertyInfo<string> PhoneNoProperty = RegisterProperty<string>(c => c.PhoneNo);
    public string PhoneNo
    {
      get { return GetProperty(PhoneNoProperty); }
      set { SetProperty(PhoneNoProperty, value); }
    }
    public static readonly PropertyInfo<string> GenderProperty = RegisterProperty<string>(c => c.Gender);
    public string Gender
    {
      get { return GetProperty(GenderProperty); }
      set { SetProperty(GenderProperty, value); }
    }
    public static readonly PropertyInfo<string> EmailIdProperty = RegisterProperty<string>(c => c.EmailId);
    public string EmailId
    {
      get { return GetProperty(EmailIdProperty); }
      set { SetProperty(EmailIdProperty, value); }
    }
    public static readonly PropertyInfo<string> PostalCodeProperty = RegisterProperty<string>(c => c.PostalCode);
    public string PostalCode
    {
      get { return GetProperty(PostalCodeProperty); }
      set { SetProperty(PostalCodeProperty, value); }
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

    public static HResourcesJsonBO NewHResourcesJSON()
    {
      return DataPortal.CreateChild<HResourcesJsonBO>();
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
                HResourcesJsonDTO HResourcesJson = Newtonsoft.Json.JsonConvert.DeserializeObject<HResourcesJsonDTO>(BlogJsondtojson);
                if (HResourcesJson != null)
                    Child_Fetch(HResourcesJson);
            }
        }
        private void Child_Fetch(HResourcesJsonDTO data)
        {
            Name = data.Name;
            FirstName = data.FirstName;
            LastName = data.LastName;
            Address = data.Address;
            DriverLicenseNo = data.DriverLicenseNo;
            DriverClass = data.DriverClass;
            IsSourceAgency = data.IsSourceAgency;
            TripAssigned = data.TripAssigned;
            TripAssignedID = data.TripAssignedID;
            TripPlannedID = data.TripPlannedID;
            AssignedDate = data.AssignedDate;
            TripPlanned = data.TripPlanned;
            PlannedDate = data.PlannedDate;
            City = data.City;
            Province = data.Province;
            PhoneNo = data.PhoneNo;
            Gender = data.Gender;
            EmailId = data.EmailId;
            PostalCode = data.PostalCode;
            Code = data.Code;
            Latitude = data.Latitude;
            Longitude = data.Longitude;
            Altitude = data.Altitude;
            MarkOld();
        }

    #region Data Access - Insert

        private void Child_Insert(HResource parent)
        {
            MarkOld();
        }

    #endregion //Data Access - Insert

    #region Data Access - Update
        private void Child_Update(HResource parent)
        {
            MarkOld();
        }

    #endregion //Data Access - Update

    #region Data Access - Delete
        private void Child_DeleteSelf(HResource parent)
        {
            MarkNew();
        }
    #endregion //Data Access - Delete
#endif
  }
  #endregion

}