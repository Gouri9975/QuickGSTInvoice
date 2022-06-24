//using Csla;
//using Csla.Core;
//using e2.BDM.Lib;
//using e2.CDM.Shared;
//using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;

//namespace e2.CDM.Lib
//{
//    /////////////////Contains methods which are used in the client side
//    [Serializable()]
//    public class PaymentGatewayCustomerCommand : CommandBase<PaymentGatewayCustomerCommand>
//    {
//        #region Properties
//        public static readonly PropertyInfo<Guid> PGCustomerIDProperty = RegisterProperty<Guid>(c => c.PGCustomerID);
//        public Guid PGCustomerID
//        {
//            get { return ReadProperty(PGCustomerIDProperty); }
//            set { LoadProperty(PGCustomerIDProperty, value); }
//        }
//        public static readonly PropertyInfo<Guid> CustomerGUIDProperty = RegisterProperty<Guid>(c => c.CustomerGUID);
//        public Guid CustomerGUID
//        {
//            get { return ReadProperty(CustomerGUIDProperty); }
//            set { LoadProperty(CustomerGUIDProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CustomerSGUIDProperty = RegisterProperty<string>(c => c.CustomerSGUID);
//        public string CustomerSGUID
//        {
//            get { return ReadProperty(CustomerSGUIDProperty); }
//            set { LoadProperty(CustomerSGUIDProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CustomerIDProperty = RegisterProperty<string>(c => c.CustomerID);
//        public string CustomerID
//        {
//            get { return ReadProperty(CustomerIDProperty); }
//            set { LoadProperty(CustomerIDProperty, value); }
//        }
//        public static readonly PropertyInfo<string> FirstNameProperty = RegisterProperty<string>(c => c.FirstName);
//        public string FirstName
//        {
//            get { return ReadProperty(FirstNameProperty); }
//            set { LoadProperty(FirstNameProperty, value); }
//        }
//        public static readonly PropertyInfo<string> MiddleNameProperty = RegisterProperty<string>(c => c.MiddleName);
//        public string MiddleName
//        {
//            get { return ReadProperty(MiddleNameProperty); }
//            set { LoadProperty(MiddleNameProperty, value); }
//        }
//        public static readonly PropertyInfo<string> LastNameProperty = RegisterProperty<string>(c => c.LastName);
//        public string LastName
//        {
//            get { return ReadProperty(LastNameProperty); }
//            set { LoadProperty(LastNameProperty, value); }
//        }
//        public static readonly PropertyInfo<int> DOBDayProperty = RegisterProperty<int>(c => c.DOBDay);
//        public int DOBDay
//        {
//            get { return ReadProperty(DOBDayProperty); }
//            set { LoadProperty(DOBDayProperty, value); }
//        }
//        public static readonly PropertyInfo<int> DOBMonthProperty = RegisterProperty<int>(c => c.DOBMonth);
//        public int DOBMonth
//        {
//            get { return ReadProperty(DOBMonthProperty); }
//            set { LoadProperty(DOBMonthProperty, value); }
//        }
//        public static readonly PropertyInfo<int> DOBYearProperty = RegisterProperty<int>(c => c.DOBYear);
//        public int DOBYear
//        {
//            get { return ReadProperty(DOBYearProperty); }
//            set { LoadProperty(DOBYearProperty, value); }
//        }
//        public static readonly PropertyInfo<string> EmailProperty = RegisterProperty<string>(c => c.Email);
//        public string Email
//        {
//            get { return ReadProperty(EmailProperty); }
//            set { LoadProperty(EmailProperty, value); }
//        }
//        public static readonly PropertyInfo<string> PhoneProperty = RegisterProperty<string>(c => c.Phone);
//        public string Phone
//        {
//            get { return ReadProperty(PhoneProperty); }
//            set { LoadProperty(PhoneProperty, value); }
//        }
//        public static readonly PropertyInfo<string> IPProperty = RegisterProperty<string>(c => c.IP);
//        public string IP
//        {
//            get { return ReadProperty(IPProperty); }
//            set { LoadProperty(IPProperty, value); }
//        }
//        public static readonly PropertyInfo<string> GenderProperty = RegisterProperty<string>(c => c.Gender);
//        public string Gender
//        {
//            get { return ReadProperty(GenderProperty); }
//            set { LoadProperty(GenderProperty, value); }
//        }
//        public static readonly PropertyInfo<string> NationalityProperty = RegisterProperty<string>(c => c.Nationality);
//        public string Nationality
//        {
//            get { return ReadProperty(NationalityProperty); }
//            set { LoadProperty(NationalityProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CellPhoneProperty = RegisterProperty<string>(c => c.CellPhone);
//        public string CellPhone
//        {
//            get { return ReadProperty(CellPhoneProperty); }
//            set { LoadProperty(CellPhoneProperty, value); }
//        }
//        public static readonly PropertyInfo<string> LocaleProperty = RegisterProperty<string>(c => c.Locale);
//        public string Locale
//        {
//            get { return ReadProperty(LocaleProperty); }
//            set { LoadProperty(LocaleProperty, value); }
//        }
//        public static readonly PropertyInfo<string> PGCustomerJSONProperty = RegisterProperty<string>(c => c.PGCustomerJSON);
//        public string PGCustomerJSON
//        {
//            get { return ReadProperty(PGCustomerJSONProperty); }
//            set { LoadProperty(PGCustomerJSONProperty, value); }
//        }
//        public static readonly PropertyInfo<Guid> AuditInfoGUIDProperty = RegisterProperty<Guid>(c => c.AuditInfoGUID);
//        public Guid AuditInfoGUID
//        {
//            get { return ReadProperty(AuditInfoGUIDProperty); }
//            set { LoadProperty(AuditInfoGUIDProperty, value); }
//        }
//        public static readonly PropertyInfo<Guid> PGProviderIDProperty = RegisterProperty<Guid>(c => c.PGProviderID);
//        public Guid PGProviderID
//        {
//            get { return ReadProperty(PGProviderIDProperty); }
//            set { LoadProperty(PGProviderIDProperty, value); }
//        }
//        public static readonly PropertyInfo<MobileList<PaymentGatewayAddressCommand>> AddressListProperty = RegisterProperty<MobileList<PaymentGatewayAddressCommand>>(c => c.AddressList);
//        public MobileList<PaymentGatewayAddressCommand> AddressList
//        {
//            get { return ReadProperty(AddressListProperty); }
//            set { LoadProperty(AddressListProperty, value); }
//        }
//        public static readonly PropertyInfo<PaymentGatewayCardCommand> CardProperty = RegisterProperty<PaymentGatewayCardCommand>(c => c.Card);
//        public PaymentGatewayCardCommand Card
//        {
//            get { return ReadProperty(CardProperty); }
//            set { LoadProperty(CardProperty, value); }
//        }
//        public static readonly PropertyInfo<MobileList<PaymentGatewayCardCommand>> CardListProperty = RegisterProperty<MobileList<PaymentGatewayCardCommand>>(c => c.CardList);
//        public MobileList<PaymentGatewayCardCommand> CardList
//        {
//            get { return ReadProperty(CardListProperty); }
//            set { LoadProperty(CardListProperty, value); }
//        }
//        public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
//        public string Status
//        {
//            get { return ReadProperty(StatusProperty); }
//            set { LoadProperty(StatusProperty, value); }
//        }
//        public static readonly PropertyInfo<string> PaymentTokenProperty = RegisterProperty<string>(c => c.PaymentToken);
//        public string PaymentToken
//        {
//            get { return ReadProperty(PaymentTokenProperty); }
//            set { LoadProperty(PaymentTokenProperty, value); }
//        }
//        public static readonly PropertyInfo<bool> IsSucceededProperty = RegisterProperty<bool>(c => c.IsSucceeded);
//        public bool IsSucceeded
//        {
//            get { return ReadProperty(IsSucceededProperty); }
//            set { LoadProperty(IsSucceededProperty, value); }
//        }
//        /// <summary>
//        /// CREATE
//        /// </summary>
//        public static readonly PropertyInfo<string> OperationProperty = RegisterProperty<string>(c => c.Operation);
//        public string Operation
//        {
//            get { return ReadProperty(OperationProperty); }
//            set { LoadProperty(OperationProperty, value); }
//        }
//        #endregion

//        #region Constructor
//        public PaymentGatewayCustomerCommand()
//        { }

//        public PaymentGatewayCustomerCommand(string customerID, string firstName, string middleName, string lastName, int dobDay, int dobMonth, int dobYear, string email, string phone,
//            pgGender gender, string nationality, string cellPhone, pgLocale locale, string operation, PaymentGatewayCardCommand card = null)
//        {
//            CustomerID = customerID;
//            FirstName = firstName;
//            MiddleName = middleName;
//            LastName = lastName;
//            DOBDay = dobDay;
//            DOBMonth = dobMonth;
//            DOBYear = dobYear;
//            Email = email;
//            Phone = phone;
//            Gender = gender == pgGender.Male ? "M" : "F";
//            Nationality = nationality;
//            CellPhone = cellPhone;
//            Locale = locale.ToString();

//            CustomerGUID = Guid.NewGuid();
//            CustomerSGUID = CustomerGUID.ToShortGUID();
//            AuditInfoGUID = Guid.NewGuid();

//            if (card != null)
//                Card = card;

//            PGProviderID = new Guid("eb32a134-7b18-4ed9-b85e-6edb006b2b51");    //Added for testing

//        }

//        public PaymentGatewayCustomerCommand(Guid pgCustomerID, string operation)
//        {
//            PGCustomerID = pgCustomerID;
//            Operation = operation;
//        }
//        public PaymentGatewayCustomerCommand(string customerID, string operation)
//        {
//            CustomerID = customerID;
//            Operation = operation;
//        }
//        #endregion

//#if !SILVERLIGHT && !NETFX_CORE
//        public static PaymentGatewayCustomerCommand CreateCustomer(string customerID, string firstName, string middleName, string lastName, int dobDay, int dobMonth, int dobYear, string email, string phone,
//            pgGender gender, string nationality, string cellPhone, pgLocale locale)
//        {
//            return DataPortal.Execute<PaymentGatewayCustomerCommand>(new PaymentGatewayCustomerCommand(customerID, firstName, middleName, lastName, dobDay, dobMonth, dobYear, email, phone, gender, nationality, cellPhone, locale, "CREATE"));
//        }
//        public static PaymentGatewayCustomerCommand CreateCustomer(string customerID, string firstName, string middleName, string lastName, int dobDay, int dobMonth, int dobYear, string email, string phone,
//            pgGender gender, string nationality, string cellPhone, pgLocale locale, PaymentGatewayCardCommand card)
//        {
//            return DataPortal.Execute<PaymentGatewayCustomerCommand>(new PaymentGatewayCustomerCommand(customerID, firstName, middleName, lastName, dobDay, dobMonth, dobYear, email, phone, gender, nationality, cellPhone, locale, "CREATE", card: card));
//        }
//        public static PaymentGatewayCustomerCommand Get(Guid pgCustomerID)
//        {
//            return DataPortal.Execute<PaymentGatewayCustomerCommand>(new PaymentGatewayCustomerCommand(pgCustomerID, "GET"));
//        }
//        public static PaymentGatewayCustomerCommand GetByCustomer(string customerID)
//        {
//            return DataPortal.Execute<PaymentGatewayCustomerCommand>(new PaymentGatewayCustomerCommand(customerID, "GETBYCUSTOMER"));
//        }
//#endif



//#if !SILVERLIGHT && !NETFX_CORE

//        protected void DataPortal_Execute([Inject] IPaymentService paymentService)
//        {
//            switch (Operation)
//            {
//                case "CREATE":
//                    Create(paymentService);
//                    break;
//                case "GET":
//                    Get(paymentService);
//                    break;
//                case "GETBYCUSTOMER":
//                    GetByCustomer(paymentService);
//                    break;
//            }
//        }

//        private void Create(IPaymentService paymentService)
//        {
//            IsSucceeded = false;
//            try
//            {
//                bool isServiceRunning = paymentService.CheckCustomerVaultServiceAvailableAsync().Result;
//                if (isServiceRunning)
//                {
//                    e2.CDM.Lib.pgCustomer pgCustomer = new e2.CDM.Lib.pgCustomer()
//                    {
//                        merchantCustomerId = CustomerSGUID,
//                        cellPhone = CellPhone,
//                        email = Email,
//                        firstName = FirstName,
//                        lastName = LastName,
//                        locale = Locale,    // "en_US",
//                        phone = Phone,
//                        dateOfBirth = new CDM.Lib.pgDate() { day = DOBDay, month = DOBMonth, year = DOBYear },
//                        gender = Gender,
//                        //ip = "192.0.126.111",
//                        nationality = Nationality,
//                    };

//                    if (Card != null)
//                        pgCustomer.card = Card.MapToPGModel();

//                    pgCustomer = paymentService.CreateCustomerAsync(pgCustomer).Result;

//                    if (pgCustomer.id.HasValue)
//                        PGCustomerID = pgCustomer.id.Value;


//                    using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
//                                                  .GetManager(e2.CDM.DAL.Lib.Database.BDMConnection))
//                    {

//                        if (pgCustomer != null && !string.IsNullOrEmpty(pgCustomer.status) && pgCustomer.status.Equals("ACTIVE"))
//                        {
//                            //Customer created successfully in Payment Gateway.
//                            string pgCustomerJSON = Newtonsoft.Json.JsonConvert.SerializeObject(pgCustomer);
//                            mgr.DataContext.PGCustomer_Add(PGCustomerID, CustomerGUID, CustomerSGUID, CustomerID, pgCustomerJSON, AuditInfoGUID, PGProviderID, "ACTIVE");
//                            IsSucceeded = true;
//                        }
//                    }
//                }
//                else
//                {
//                    //Service not running
//                }
//            }
//            catch (Exception ex)
//            {
//                IsSucceeded = false;
//                throw ex;
//            }
//        }

//        private void Get(IPaymentService paymentService)
//        {
//            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
//                                                      .GetManager(e2.CDM.DAL.Lib.Database.BDMConnection))
//            {
//                var pgCustomerResult = mgr.DataContext.PGCustomer_Get(PGCustomerID).FirstOrDefault();
//                if (pgCustomerResult != null)
//                {
//                    PGCustomerID = pgCustomerResult.PGCustomerID;
//                    CustomerGUID = pgCustomerResult.CustomerGUID;
//                    CustomerSGUID = pgCustomerResult.CustomerSGUID;
//                    AuditInfoGUID = pgCustomerResult.AuditInfoGUID;

//                    pgCustomer customer = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCustomer>(pgCustomerResult.PGCustomerJSON);
//                    Status = customer.status;
//                    Locale = customer.locale;
//                    FirstName = customer.firstName;
//                    MiddleName = customer.middleName;
//                    LastName = customer.lastName;
//                    DOBDay = customer.dateOfBirth?.day ?? 0;
//                    DOBMonth = customer.dateOfBirth?.month ?? 0;
//                    DOBYear = customer.dateOfBirth?.year ?? 0;
//                    Email = customer.email;
//                    Phone = customer.phone;
//                    IP = customer.ip;
//                    Gender = customer.gender;
//                    Nationality = customer.nationality;
//                    CellPhone = customer.cellPhone;
//                    PaymentToken = customer.paymentToken;


//                    if (customer.addresses != null)
//                    {
//                        AddressList = new MobileList<PaymentGatewayAddressCommand>();
//                        foreach (var pgAddress in customer.addresses)
//                        {
//                            AddressList.Add(pgAddress.MapToCommand());
//                        }
//                    }

//                    if (customer.cards != null)
//                    {
//                        CardList = new MobileList<PaymentGatewayCardCommand>();
//                        foreach (var pgCard in customer.cards)
//                        {
//                            CardList.Add(pgCard.MapToCommand());
//                        }
//                    }

//                }
//                IsSucceeded = true;
//            }
//        }
//        private void GetByCustomer(IPaymentService paymentService)
//        {
//            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
//                                                      .GetManager(e2.CDM.DAL.Lib.Database.BDMConnection))
//            {
//                var pgCustomerResult = mgr.DataContext.PGCustomer_GetByCustomer(CustomerID).FirstOrDefault();
//                if (pgCustomerResult != null)
//                {
//                    PGCustomerID = pgCustomerResult.PGCustomerID;
//                    CustomerGUID = pgCustomerResult.CustomerGUID;
//                    CustomerSGUID = pgCustomerResult.CustomerSGUID;
//                    AuditInfoGUID = pgCustomerResult.AuditInfoGUID;

//                    pgCustomer customer = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCustomer>(pgCustomerResult.PGCustomerJSON);
//                    Status = customer.status;
//                    Locale = customer.locale;
//                    FirstName = customer.firstName;
//                    MiddleName = customer.middleName;
//                    LastName = customer.lastName;
//                    DOBDay = customer.dateOfBirth?.day ?? 0;
//                    DOBMonth = customer.dateOfBirth?.month ?? 0;
//                    DOBYear = customer.dateOfBirth?.year ?? 0;
//                    Email = customer.email;
//                    Phone = customer.phone;
//                    IP = customer.ip;
//                    Gender = customer.gender;
//                    Nationality = customer.nationality;
//                    CellPhone = customer.cellPhone;
//                    PaymentToken = customer.paymentToken;


//                    if (customer.addresses != null)
//                    {
//                        AddressList = new MobileList<PaymentGatewayAddressCommand>();
//                        foreach (var pgAddress in customer.addresses)
//                        {
//                            AddressList.Add(pgAddress.MapToCommand());
//                        }
//                    }

//                    if (customer.cards != null)
//                    {
//                        CardList = new MobileList<PaymentGatewayCardCommand>();
//                        foreach (var pgCard in customer.cards)
//                        {
//                            CardList.Add(pgCard.MapToCommand());
//                        }
//                    }

//                }
//                IsSucceeded = true;
//            }
//        }


//#endif
//    }

//    [Serializable]
//    public class PaymentGatewayAddressCommand : Csla.BusinessBase<PaymentGatewayAddressCommand>
//    {

//#region Properties
//        public static readonly PropertyInfo<Guid> PGAddressIDProperty = RegisterProperty<Guid>(c => c.PGAddressID);
//        public Guid PGAddressID
//        {
//            get { return ReadProperty(PGAddressIDProperty); }
//            private set { LoadProperty(PGAddressIDProperty, value); }
//        }
//        public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
//        public string Status
//        {
//            get { return ReadProperty(StatusProperty); }
//            private set { LoadProperty(StatusProperty, value); }
//        }
//        public static readonly PropertyInfo<string> NickNameProperty = RegisterProperty<string>(c => c.NickName);
//        public string NickName
//        {
//            get { return ReadProperty(NickNameProperty); }
//            private set { LoadProperty(NickNameProperty, value); }
//        }
//        public static readonly PropertyInfo<string> StreetProperty = RegisterProperty<string>(c => c.Street);
//        public string Street
//        {
//            get { return ReadProperty(StreetProperty); }
//            private set { LoadProperty(StreetProperty, value); }
//        }
//        public static readonly PropertyInfo<string> Street2Property = RegisterProperty<string>(c => c.Street2);
//        public string Street2
//        {
//            get { return ReadProperty(Street2Property); }
//            private set { LoadProperty(Street2Property, value); }
//        }
//        public static readonly PropertyInfo<string> CityProperty = RegisterProperty<string>(c => c.City);
//        public string City
//        {
//            get { return ReadProperty(CityProperty); }
//            private set { LoadProperty(CityProperty, value); }
//        }
//        public static readonly PropertyInfo<string> ZipProperty = RegisterProperty<string>(c => c.Zip);
//        public string Zip
//        {
//            get { return ReadProperty(ZipProperty); }
//            private set { LoadProperty(ZipProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CountryProperty = RegisterProperty<string>(c => c.Country);
//        public string Country
//        {
//            get { return ReadProperty(CountryProperty); }
//            private set { LoadProperty(CountryProperty, value); }
//        }
//        public static readonly PropertyInfo<string> StateProperty = RegisterProperty<string>(c => c.State);
//        public string State
//        {
//            get { return ReadProperty(StateProperty); }
//            private set { LoadProperty(StateProperty, value); }
//        }
//        public static readonly PropertyInfo<string> RecipientNameProperty = RegisterProperty<string>(c => c.RecipientName);
//        public string RecipientName
//        {
//            get { return ReadProperty(RecipientNameProperty); }
//            private set { LoadProperty(RecipientNameProperty, value); }
//        }
//        public static readonly PropertyInfo<string> PhoneProperty = RegisterProperty<string>(c => c.Phone);
//        public string Phone
//        {
//            get { return ReadProperty(PhoneProperty); }
//            private set { LoadProperty(PhoneProperty, value); }
//        }
//        public static readonly PropertyInfo<bool> DefaultShippingAddressIndicatorProperty = RegisterProperty<bool>(c => c.DefaultShippingAddressIndicator);
//        public bool DefaultShippingAddressIndicator
//        {
//            get { return ReadProperty(DefaultShippingAddressIndicatorProperty); }
//            private set { LoadProperty(DefaultShippingAddressIndicatorProperty, value); }
//        }

//        //public string recipientName { get; set; } //No need to set
//        //public string phone { get; set; } //No need to set
//        //public bool defaultShippingAddressIndicator { get; set; }   //Adding an address

//#endregion

//#region Constructor
//        public PaymentGatewayAddressCommand()
//        { }
//        private PaymentGatewayAddressCommand(string nickName, string street, string street2, string city, string state, string country, string zip)
//        {
//            NickName = nickName;
//            Street = street;
//            Street2 = street2;
//            City = city;
//            State = state;
//            Country = country;
//            Zip = zip;
//        }
//        private PaymentGatewayAddressCommand(pgAddress address)
//        {
//            if (address.id.HasValue)
//                PGAddressID = address.id.Value;
//            NickName = address.nickName;
//            Street = address.street;
//            Street2 = address.street2;
//            City = address.city;
//            State = address.state;
//            Country = address.country;
//            Zip = address.zip;
//        }
//#endregion

//        public static PaymentGatewayAddressCommand NewPaymentGatewayAddressCommand(string nickName, string street, string street2, string city, string state, string country, string zip)
//        {
//            return new PaymentGatewayAddressCommand(nickName, street, street2, city, state, country, zip);
//        }

//        public static PaymentGatewayAddressCommand NewPaymentGatewayAddressCommand(pgAddress address)
//        {
//            return new PaymentGatewayAddressCommand(address);
//        }


//    }

//    [Serializable]
//    public class PaymentGatewayCardCommand : CommandBase<PaymentGatewayCardCommand>
//    {
//#region Properties
//        public static readonly PropertyInfo<Guid> PGCardIDProperty = RegisterProperty<Guid>(c => c.PGCardID);
//        public Guid PGCardID
//        {
//            get { return ReadProperty(PGCardIDProperty); }
//            set { LoadProperty(PGCardIDProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CardBinProperty = RegisterProperty<string>(c => c.CardBin);
//        public string CardBin
//        {
//            get { return ReadProperty(CardBinProperty); }
//            set { LoadProperty(CardBinProperty, value); }
//        }
//        public static readonly PropertyInfo<string> LastDigitsProperty = RegisterProperty<string>(c => c.LastDigits);
//        public string LastDigits
//        {
//            get { return ReadProperty(LastDigitsProperty); }
//            set { LoadProperty(LastDigitsProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CardNumProperty = RegisterProperty<string>(c => c.CardNum);
//        public string CardNum
//        {
//            get { return ReadProperty(CardNumProperty); }
//            set { LoadProperty(CardNumProperty, value); }
//        }
//        public static readonly PropertyInfo<int> ExpiryMonthProperty = RegisterProperty<int>(c => c.ExpiryMonth);
//        public int ExpiryMonth
//        {
//            get { return ReadProperty(ExpiryMonthProperty); }
//            set { LoadProperty(ExpiryMonthProperty, value); }
//        }
//        public static readonly PropertyInfo<int> ExpiryYearProperty = RegisterProperty<int>(c => c.ExpiryYear);
//        public int ExpiryYear
//        {
//            get { return ReadProperty(ExpiryYearProperty); }
//            set { LoadProperty(ExpiryYearProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CVVProperty = RegisterProperty<string>(c => c.CVV);
//        public string CVV
//        {
//            get { return ReadProperty(CVVProperty); }
//            set { LoadProperty(CVVProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CardTypeProperty = RegisterProperty<string>(c => c.CardType);
//        public string CardType
//        {
//            get { return ReadProperty(CardTypeProperty); }
//            set { LoadProperty(CardTypeProperty, value); }
//        }
//        public static readonly PropertyInfo<string> CardCategoryProperty = RegisterProperty<string>(c => c.CardCategory);
//        public string CardCategory
//        {
//            get { return ReadProperty(CardCategoryProperty); }
//            set { LoadProperty(CardCategoryProperty, value); }
//        }
//        public static readonly PropertyInfo<string> NickNameProperty = RegisterProperty<string>(c => c.NickName);
//        public string NickName
//        {
//            get { return ReadProperty(NickNameProperty); }
//            set { LoadProperty(NickNameProperty, value); }
//        }
//        public static readonly PropertyInfo<string> MerchantRefNumProperty = RegisterProperty<string>(c => c.MerchantRefNum);
//        public string MerchantRefNum
//        {
//            get { return ReadProperty(MerchantRefNumProperty); }
//            set { LoadProperty(MerchantRefNumProperty, value); }
//        }
//        public static readonly PropertyInfo<string> HolderNameProperty = RegisterProperty<string>(c => c.HolderName);
//        public string HolderName
//        {
//            get { return ReadProperty(HolderNameProperty); }
//            set { LoadProperty(HolderNameProperty, value); }
//        }
//        public static readonly PropertyInfo<Guid> BillingAddressIDProperty = RegisterProperty<Guid>(c => c.BillingAddressID);
//        public Guid BillingAddressID
//        {
//            get { return ReadProperty(BillingAddressIDProperty); }
//            set { LoadProperty(BillingAddressIDProperty, value); }
//        }
//        public static readonly PropertyInfo<string> DefaultCardIndicatorProperty = RegisterProperty<string>(c => c.DefaultCardIndicator);
//        public string DefaultCardIndicator
//        {
//            get { return ReadProperty(DefaultCardIndicatorProperty); }
//            set { LoadProperty(DefaultCardIndicatorProperty, value); }
//        }
//        public static readonly PropertyInfo<string> PaymentTokenProperty = RegisterProperty<string>(c => c.PaymentToken);
//        public string PaymentToken
//        {
//            get { return ReadProperty(PaymentTokenProperty); }
//            set { LoadProperty(PaymentTokenProperty, value); }
//        }
//        public static readonly PropertyInfo<string> StatusProperty = RegisterProperty<string>(c => c.Status);
//        public string Status
//        {
//            get { return ReadProperty(StatusProperty); }
//            set { LoadProperty(StatusProperty, value); }
//        }
//        public static readonly PropertyInfo<PaymentGatewayAddressCommand> BillingAddressProperty = RegisterProperty<PaymentGatewayAddressCommand>(c => c.BillingAddress);
//        public PaymentGatewayAddressCommand BillingAddress
//        {
//            get { return ReadProperty(BillingAddressProperty); }
//            set { LoadProperty(BillingAddressProperty, value); }
//        }
//#endregion
//#region Constructor
//        public PaymentGatewayCardCommand()
//        { }
//        public PaymentGatewayCardCommand(string cardNum, int expiryMonth, int expiryYear, string nickName, string merchantRefNum, string holderName, Guid? billingAddressID = null, PaymentGatewayAddressCommand billingAddress = null)
//        {
//            CardNum = cardNum;
//            ExpiryMonth = expiryMonth;
//            ExpiryYear = expiryYear;
//            NickName = nickName;
//            MerchantRefNum = merchantRefNum;
//            HolderName = holderName;
//            if (billingAddressID.HasValue)
//                BillingAddressID = billingAddressID.Value;
//            if (billingAddress != null)
//                BillingAddress = billingAddress;
//        }
//        public PaymentGatewayCardCommand(pgCard card)
//        {
//            if (card.id.HasValue)
//                PGCardID = card.id.Value;
//            CardNum = card.cardNum;
//            ExpiryMonth = card.cardExpiry?.month ?? 0;
//            ExpiryYear = card.cardExpiry?.year ?? 0;
//            NickName = card.nickName;
//            MerchantRefNum = card.merchantRefNum;
//            HolderName = card.holderName;

//            if (card.billingAddressId.HasValue)
//                BillingAddressID = card.billingAddressId.Value;
//            if (card.billingAddress != null)
//                BillingAddress = card.billingAddress.MapToCommand();
//        }

//#endregion

//        public static PaymentGatewayCardCommand NewPaymentGatewayCardCommand(string cardNum, int expiryMonth, int expiryYear, string nickName, string merchantRefNum, string holderName)
//        {
//            return new PaymentGatewayCardCommand(cardNum, expiryMonth, expiryYear, nickName, merchantRefNum, holderName);
//        }
//        public static PaymentGatewayCardCommand NewPaymentGatewayCardCommand(string cardNum, int expiryMonth, int expiryYear, string nickName, string merchantRefNum, string holderName, Guid billingAddressID)
//        {
//            return new PaymentGatewayCardCommand(cardNum, expiryMonth, expiryYear, nickName, merchantRefNum, holderName, billingAddressID);
//        }
//        public static PaymentGatewayCardCommand NewPaymentGatewayCardCommand(string cardNum, int expiryMonth, int expiryYear, string nickName, string merchantRefNum, string holderName, PaymentGatewayAddressCommand billingAddress)
//        {
//            return new PaymentGatewayCardCommand(cardNum, expiryMonth, expiryYear, nickName, merchantRefNum, holderName, billingAddress: billingAddress);
//        }
//        public static PaymentGatewayCardCommand NewPaymentGatewayCardCommand(pgCard card)
//        {
//            return new PaymentGatewayCardCommand(card);
//        }


//    }

//    public static class Mapper
//    {
//        public static pgAddress MapToPGModel(this PaymentGatewayAddressCommand addressCommand)
//        {
//            if (addressCommand != null)
//            {
//                pgAddress address = new pgAddress();
//                address.nickName = addressCommand.NickName;
//                address.street = addressCommand.Street;
//                address.street2 = addressCommand.Street2;
//                address.city = addressCommand.City;
//                address.zip = addressCommand.Zip;
//                address.country = addressCommand.Country;
//                address.state = addressCommand.State;
//                address.recipientName = addressCommand.RecipientName;
//                address.phone = addressCommand.Phone;
//                address.defaultShippingAddressIndicator = addressCommand.DefaultShippingAddressIndicator;
//                return address;
//            }
//            else
//                return null;
//        }
//        public static pgCard MapToPGModel(this PaymentGatewayCardCommand cardCommand)
//        {
//            if (cardCommand != null)
//            {
//                pgCard card = new pgCard();
//                card.cardNum = cardCommand.CardNum;
//                card.cardExpiry = new pgDate() { month = cardCommand.ExpiryMonth, year = cardCommand.ExpiryYear };
//                card.nickName = cardCommand.NickName;
//                card.merchantRefNum = cardCommand.MerchantRefNum;
//                card.holderName = cardCommand.HolderName;
//                if (cardCommand.BillingAddressID != null && cardCommand.BillingAddressID != new Guid())
//                    card.billingAddressId = cardCommand.BillingAddressID;
//                if (cardCommand.BillingAddress != null)
//                    card.billingAddress = cardCommand.BillingAddress.MapToPGModel();
//                return card;
//            }
//            else return null;
//        }

//        public static PaymentGatewayAddressCommand MapToCommand(this pgAddress pgAddress)
//        {
//            if (pgAddress != null)
//            {
//                return PaymentGatewayAddressCommand.NewPaymentGatewayAddressCommand(pgAddress);
//            }
//            else
//                return null;
//        }

//        public static PaymentGatewayCardCommand MapToCommand(this pgCard pgCard)
//        {
//            if (pgCard != null)
//            {
//                //if (pgCard.billingAddress != null)
//                //{
//                return PaymentGatewayCardCommand.NewPaymentGatewayCardCommand(pgCard);
//                //}
//            }
//            return null;
//        }
//    }

//}
