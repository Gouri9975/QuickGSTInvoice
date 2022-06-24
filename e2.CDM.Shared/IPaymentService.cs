//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace e2.CDM.Lib
//{
//    public interface IPaymentService
//    {
//        Task<bool> CheckCardPaymentServiceAvailableAsync();
//        Task<bool> CheckCustomerVaultServiceAvailableAsync();
//        Task<pgCustomer> CreateCustomerAsync(pgCustomer customer);
//        Task<pgCustomer> CreateCustomerWithCardAsync(pgCustomer customer);
//        Task<pgCustomer> CreateCustomerWithAddressAsync(pgCustomer customer);
//        Task<pgCustomer> GetCustomerWithDetailsAsync(Guid customerID);
//        Task<pgCustomer> UpdateCustomerAsync(pgCustomer customer);

//        Task<pgCustomer> GetCustomerAsync(Guid customerID);

//        Task<pgAddress> AddCustomerAddressAsync(Guid customerID, pgAddress address);
//        Task<pgAddress> GetAddressAsync(Guid customerID, Guid addressID);
//        Task<pgAddress> UpdateAddressAsync(Guid customerID, pgAddress address);
//        Task<string> DeleteAddressAsync(Guid customerID, Guid addressID);

//        Task<pgCard> AddCustomerCreditCardAsync(Guid customerID, pgCard card);

//        Task<pgCard> GetCardAsync(Guid customerID, Guid cardID);
//        Task<pgCard> UpdateCardAsync(Guid customerID, pgCard card);
//        Task<string> DeleteCardAsync(Guid customerID, Guid cardID);

//        #region Authorization

//        Task<pgAuthorization> AuthorizeByPaymentTokenAsync(pgAuthorization authorization);
//        Task<pgAuthorization> GetAuthorizationAsync(string authorizationID);
//        Task<pgAuthorizations> GetAuthorizationByMerchantReferenceNumberAsync(string merchantReferenceNumber, int limit, int offset, DateTime startDate, DateTime endDate);
//        Task<bool> CompleteAuthorizationAsync(Guid authorizationID);
//        Task<bool> VoidAuthorization(Guid authorizationID, pgAuthorization authorization);
//        Task<pgAuthorization> GetVoidAuthorization(Guid authorizationID);
//        #endregion

//        #region Settlement
//        Task<pgSettlement> CreateSettlement(Guid authorizationID, string merchantReferenceNumber, bool duplicateCheck = true);
//        Task<bool> cancelSettlement(Guid settlementID);
//        Task<pgSettlement> GetSettlement(Guid settlementID);
//        Task<pgSettlements> GetSettlementByMerchantReferenceNumberAsync(string merchantReferenceNumber, int limit, int offset, DateTime startDate, DateTime endDate);

//        #endregion
//    }

//    public class PaySafeService : IPaymentService
//    {
//        private readonly string _accountID;
//        private readonly string _cardPaymentBaseUrl;
//        private readonly string _customerVaultBaseURL;

//        public PaySafeService()
//        {
//            _accountID = "1001723040";
//            _cardPaymentBaseUrl = "https://api.test.paysafe.com/cardpayments/";
//            _customerVaultBaseURL = "https://api.test.paysafe.com/customervault/";
//        }
//        #region CRUD - Customer, Address, Card

//        public async Task<bool> CheckCustomerVaultServiceAvailableAsync()
//        {
//            var resultJson = await HttpGETAsync(_customerVaultBaseURL + "monitor");
//            pStatusModel statusModel = Newtonsoft.Json.JsonConvert.DeserializeObject<pStatusModel>(resultJson);
//            return statusModel.status.Equals("READY", StringComparison.OrdinalIgnoreCase);
//        }

//        public async Task<pgCustomer> CreateCustomerAsync(pgCustomer customer)
//        {
//            string createCustomerURL = "v1/profiles";
//            string resultJson = await HttpPOSTAsync(_customerVaultBaseURL + createCustomerURL, customer);
//            pgCustomer result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCustomer>(resultJson);
//            return result;
//        }
//        public async Task<pgCustomer> CreateCustomerWithCardAsync(pgCustomer customer)
//       {
//            return await CreateCustomerAsync(customer);
//            string createCustomerWithCardUrl = "v1/profiles";
//            string resultJson = await HttpPOSTAsync(_customerVaultBaseURL + createCustomerWithCardUrl, customer);
//            pgCustomer result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCustomer>(resultJson);
//            return result;
//        }
//        public async Task<pgCustomer> CreateCustomerWithAddressAsync(pgCustomer customer)
//        {
//            return await CreateCustomerAsync(customer);
           
//        }

//        public async Task<pgCustomer> GetCustomerAsync(Guid customerID)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID;
//            string resultJson = await HttpGETAsync(url);
//            pgCustomer result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCustomer>(resultJson);
//            return result;
//        }

//        public async Task<string> DeleteCustomerAsync(Guid customerID)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID;
//            string resultJson = await HttpDeleteAsync(url);
//            return resultJson;
//        }

//        public async Task<pgCustomer> GetCustomerWithDetailsAsync(Guid customerID)
//        {
//            //cards,addresses,achbankaccounts,bacsbankaccounts,eftbankaccounts,sepabankaccounts  --------fields
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID;
//            string resultJson = await HttpGETAsync(url, new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("fields", "addresses,cards") });
//            pgCustomer result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCustomer>(resultJson);
//            return result;
//        }

//        public async Task<pgCustomer> UpdateCustomerAsync(pgCustomer customer)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customer.id;
//            string resultJson = await HttpPUTAsync(url, customer);
//            pgCustomer result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCustomer>(resultJson);
//            return result;

//        }

//        public async Task<pgAddress> AddCustomerAddressAsync(Guid customerID, pgAddress address)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID + "/addresses";
//            string resultJson = await HttpPOSTAsync(url, address);
//            pgAddress result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAddress>(resultJson);
//            return result;
//        }

//        public async Task<pgAddress> GetAddressAsync(Guid customerID, Guid addressID)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID + "/addresses/" + addressID;
//            string resultJson = await HttpGETAsync(url);
//            pgAddress result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAddress>(resultJson);
//            return result;
//        }

//        public async Task<pgAddress> UpdateAddressAsync(Guid customerID, pgAddress address)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID + "/addresses/" + address.id;
//            string resultJson = await HttpPUTAsync(url, address);
//            pgAddress result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAddress>(resultJson);
//            return result;
//        }

//        public async Task<string> DeleteAddressAsync(Guid customerID, Guid addressID)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID + "/addresses/" + addressID;
//            string resultJson = await HttpDeleteAsync(url);
//            //pgAddress result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAddress>(resultJson);
//            return resultJson;
//        }

//        public async Task<pgCard> AddCustomerCreditCardAsync(Guid customerID, pgCard card)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID + "/cards";
//            string resultJson = await HttpPOSTAsync(url, card);
//            pgCard result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCard>(resultJson);
//            return result;
//        }

//        public async Task<pgCard> GetCardAsync(Guid customerID, Guid cardID)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID + "/cards/" + cardID;
//            string resultJson = await HttpGETAsync(url);
//            pgCard result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCard>(resultJson);
//            return result;
//        }

//        public async Task<pgCard> UpdateCardAsync(Guid customerID, pgCard card)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID + "/cards/" + card.id;
//            string resultJson = await HttpPUTAsync(url, card);
//            pgCard result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgCard>(resultJson);
//            return result;
//        }

//        public async Task<string> DeleteCardAsync(Guid customerID, Guid cardID)
//        {
//            string url = _customerVaultBaseURL + "v1/profiles/" + customerID + "/cards/" + cardID;
//            string resultJson = await HttpDeleteAsync(url);
//            //pgAddress result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAddress>(resultJson);
//            return resultJson;
//        }
//        #endregion

//        #region Authorization
//        public async Task<bool> CheckCardPaymentServiceAvailableAsync()
//        {
//            var resultJson = await HttpGETAsync(_cardPaymentBaseUrl + "monitor");
//            pStatusModel statusModel = Newtonsoft.Json.JsonConvert.DeserializeObject<pStatusModel>(resultJson);
//            return statusModel.status.Equals("READY", StringComparison.OrdinalIgnoreCase);
//        }

//        public async Task<pgAuthorization> AuthorizeByPaymentTokenAsync(pgAuthorization authorization)
//        {
//            string url = "v1/accounts/" + _accountID + "/auths";
//            string resultJson = await HttpPOSTAsync(_cardPaymentBaseUrl + url, authorization);
//            pgAuthorization result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAuthorization>(resultJson);
//            return result;
//        }

//        public async Task<pgAuthorization> GetAuthorizationAsync(string authorizationID)
//        {
//            string url = "v1/accounts/" + _accountID + "/auths/" + authorizationID;
//            var resultJson = await HttpGETAsync(_cardPaymentBaseUrl + url);
//            pgAuthorization result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAuthorization>(resultJson);
//            return result;
//        }

//        public async Task<pgAuthorizations> GetAuthorizationByMerchantReferenceNumberAsync(string merchantReferenceNumber, int limit, int offset, DateTime startDate, DateTime endDate)
//        {
//            string url = "v1/accounts/" + _accountID + "/auths";

//            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>(){
//                new KeyValuePair<string, string>("merchantRefNum", merchantReferenceNumber),
//                new KeyValuePair<string, string>("limit", limit.ToString()),
//                new KeyValuePair<string, string>("offset", offset.ToString()),
//                new KeyValuePair<string, string>("startDate", startDate.ToString("s") + "Z"),   //2017-01-14T15:12:18Z
//                new KeyValuePair<string, string>("endDate", endDate.ToString("s") + "Z"),   //2017-01-14T15:12:18Z.
//            };

//            var resultJson = await HttpGETAsync(_cardPaymentBaseUrl + url, parameters);
//            pgAuthorizations result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAuthorizations>(resultJson);
//            return result;
//        }

//        public async Task<bool> CompleteAuthorizationAsync(Guid authorizationID)
//        {
//            string url = "v1/accounts/" + _accountID + "/auths/" + authorizationID;
//            string resultJson = await HttpPUTAsync(url);
//            pStatusModel statusModel = Newtonsoft.Json.JsonConvert.DeserializeObject<pStatusModel>(resultJson);
//            return statusModel.status.Equals("COMPLETED", StringComparison.OrdinalIgnoreCase);
//        }

//        /// <summary>
//        /// pgAuthorization - assign only Merchant Reference number, amount, dubCheck
//        /// </summary>
//        /// <param name="authorizationID"></param>
//        /// <param name="authorization"></param>
//        /// <returns></returns>
//        public async Task<bool> VoidAuthorization(Guid authorizationID, pgAuthorization authorization)
//        {
//            string url = "v1/accounts/" + _accountID + "/auths/" + authorizationID + "/voidauths";
//            string resultJson = await HttpPOSTAsync(url, authorization);
//            pgAuthorization result= Newtonsoft.Json.JsonConvert.DeserializeObject<pgAuthorization>(resultJson);
//            return result.status.Equals("COMPLETED", StringComparison.OrdinalIgnoreCase);
//        }

//        public async Task<pgAuthorization> GetVoidAuthorization(Guid authorizationID)
//        {
//            string url = "v1/accounts/" + _accountID + "/auths/" + authorizationID + "/voidauths/"+ authorizationID;
//            var resultJson = await HttpGETAsync(_cardPaymentBaseUrl + url);
//            pgAuthorization result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgAuthorization>(resultJson);
//            return result;
//        }

//        #endregion

//        #region Settlements

//        public async Task<pgSettlement> CreateSettlement(Guid authorizationID, string merchantReferenceNumber, bool duplicateCheck = true)
//        {
//            string url = "v1/accounts/" + _accountID + "/auths/"+ authorizationID+"settlements";
//            pgSettlement settlement = new pgSettlement() { dupCheck=duplicateCheck, merchantRefNum=merchantReferenceNumber };
//            string resultJson = await HttpPOSTAsync(url, settlement);
//            pgSettlement result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgSettlement>(resultJson);
//            return result;
//        }

//        public async Task<bool> cancelSettlement(Guid settlementID)
//        {
//            string url = "v1/accounts/" + _accountID + "/settlements/"+ settlementID;
//            string resultJson = await HttpPUTAsync(url);
//            pStatusModel statusModel= Newtonsoft.Json.JsonConvert.DeserializeObject<pStatusModel>(resultJson);
//            return statusModel.status.Equals("CANCELLED", StringComparison.OrdinalIgnoreCase);
//        }

//        public async Task<pgSettlement> GetSettlement(Guid settlementID)
//        {
//            string url = "v1/accounts/" + _accountID + "/settlements/"+ settlementID;
//            var resultJson = await HttpGETAsync(_cardPaymentBaseUrl + url);
//            pgSettlement result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgSettlement>(resultJson);
//            return result;
//        }

//        public async Task<pgSettlements> GetSettlementByMerchantReferenceNumberAsync(string merchantReferenceNumber, int limit, int offset, DateTime startDate, DateTime endDate)
//        {
//            string url = "v1/accounts/" + _accountID + "/settlements";

//            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>(){
//                new KeyValuePair<string, string>("merchantRefNum", merchantReferenceNumber),
//                new KeyValuePair<string, string>("limit", limit.ToString()),
//                new KeyValuePair<string, string>("offset", offset.ToString()),
//                new KeyValuePair<string, string>("startDate", startDate.ToString("s") + "Z"),   //2017-01-14T15:12:18Z
//                new KeyValuePair<string, string>("endDate", endDate.ToString("s") + "Z"),   //2017-01-14T15:12:18Z.
//            };

//            var resultJson = await HttpGETAsync(_cardPaymentBaseUrl + url, parameters);
//            pgSettlements result = Newtonsoft.Json.JsonConvert.DeserializeObject<pgSettlements>(resultJson);
//            return result;
//        }

//        #endregion

//        #region HTTP Methods

//        private async Task<string> HttpGETAsync(string url, List<KeyValuePair<string, string>> parameters = null)
//        {
//            //url = baseUrl + "/" + url;
//            string resultJson = string.Empty;
//            using (var client = new HttpClient())
//            {
//                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdF9vZGF0YTpCLXFhMi0wLTVlZTEwNjYyLTAtMzAyYzAyMTQyNDM1NTM2MGViMzI3NTk0ZmVlNmEyMDM0NmJhNGZhOWMwMjdjZTJmMDIxNDZjYmIwZjc3YmMwNWE1NGIxNmE4NzhjNTc0N2M5NmM0YjcxNjEyYTQ=");
//                //var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
//                url += parameters != null ? ConstructParameterUrl(parameters) : string.Empty;
//                resultJson = await client.GetStringAsync(url);
//            }
//            return resultJson;
//        }

//        private async Task<string> HttpPOSTAsync(string url, object body )
//        {
//            //url = baseUrl + "/" + url;
//            string responseJson = string.Empty;
//            using (var client = new HttpClient())
//            {
//                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdF9vZGF0YTpCLXFhMi0wLTVlZTEwNjYyLTAtMzAyYzAyMTQyNDM1NTM2MGViMzI3NTk0ZmVlNmEyMDM0NmJhNGZhOWMwMjdjZTJmMDIxNDZjYmIwZjc3YmMwNWE1NGIxNmE4NzhjNTc0N2M5NmM0YjcxNjEyYTQ=");
//                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

//                string requestJson = body != null ?
//                    (Newtonsoft.Json.JsonConvert.SerializeObject(body, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings
//                    {
//                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
//                    }))
//                : string.Empty;
//                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

//                var response = await client.PostAsync(url, content);
//                responseJson = await response.Content.ReadAsStringAsync();
//            }
//            return responseJson;
//        }

//        private async Task<string> HttpPUTAsync(string url, object body = null)
//        {
//            string responseJson = string.Empty;
//            using (var client = new HttpClient())
//            {
//                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdF9vZGF0YTpCLXFhMi0wLTVlZTEwNjYyLTAtMzAyYzAyMTQyNDM1NTM2MGViMzI3NTk0ZmVlNmEyMDM0NmJhNGZhOWMwMjdjZTJmMDIxNDZjYmIwZjc3YmMwNWE1NGIxNmE4NzhjNTc0N2M5NmM0YjcxNjEyYTQ=");
//                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

//                string requestJson = body != null
//                    ? (Newtonsoft.Json.JsonConvert.SerializeObject(body, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings
//                    {
//                        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
//                    }))
//                    : string.Empty;

//                var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

//                var response = await client.PutAsync(url, content);
//                responseJson = await response.Content.ReadAsStringAsync();
//            }
//            return responseJson;
//        }

//        private async Task<string> HttpDeleteAsync(string url)
//        {
//            string responseJson = string.Empty;
//            using (var client = new HttpClient())
//            {
//                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdF9vZGF0YTpCLXFhMi0wLTVlZTEwNjYyLTAtMzAyYzAyMTQyNDM1NTM2MGViMzI3NTk0ZmVlNmEyMDM0NmJhNGZhOWMwMjdjZTJmMDIxNDZjYmIwZjc3YmMwNWE1NGIxNmE4NzhjNTc0N2M5NmM0YjcxNjEyYTQ=");

//                //string requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(body, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings
//                //{
//                //    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
//                //});
//                var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

//                var response = await client.DeleteAsync(url);
//                responseJson = await response.Content.ReadAsStringAsync();
//            }
//            return responseJson;
//        }

//        private string ConstructParameterUrl(List<KeyValuePair<string, string>> parameters = null)
//        {
//            string parameterUrl = "?";
//            if (parameters != null && parameters.Count > 0)
//            {
//                foreach (var item in parameters)
//                {
//                    parameterUrl += $"{item.Key}={item.Value}";
//                }
//            }
//            return parameterUrl.Equals("?") ? string.Empty : parameterUrl;
//        }
//        #endregion
//    }

//    public class pStatusModel
//    {
//        public string status { get; set; }
//    }

//    //public class pgCustomer
//    //{
//    //    public string merchantCustomerId { get; set; }
//    //    public string locale { get; set; }
//    //    public string firstName { get; set; }
//    //    public string middleName { get; set; }
//    //    public string lastName { get; set; }
//    //    public pgDate dateOfBirth { get; set; }
//    //    public string email { get; set; }
//    //    public string phone { get; set; }
//    //    public string ip { get; set; }
//    //    public string gender { get; set; }
//    //    public string nationality { get; set; }
//    //    public string cellPhone { get; set; }

//    //    //Customer With card
//    //    public pgCard card { get; set; }
//    //}
//    public enum pgGender
//    {
//        Male, Female
//    }
//    public enum pgLocale
//    {
//        en_US
//    }

//    public class pgCustomer
//    {
//        public Guid? id { get; set; }   //No need to set
//        public string status { get; set; }
//        public string merchantCustomerId { get; set; }
//        public string locale { get; set; }
//        public string firstName { get; set; }
//        public string middleName { get; set; }
//        public string lastName { get; set; }
//        public pgDate dateOfBirth { get; set; }
//        public string email { get; set; }
//        public string phone { get; set; }
//        public string ip { get; set; }
//        public string gender { get; set; }
//        public string nationality { get; set; }
//        public string cellPhone { get; set; }
//        public string paymentToken { get; set; }
//        public pgAddress[] addresses { get; set; }
//        public pgCard card { get; set; }    //Creating the customer
//        public pgCard[] cards { get; set; }

//    }

//    public class pgDate
//    {
//        public int year { get; set; }
//        public int month { get; set; }
//        public int day { get; set; }
//    }

//    public class pgCard
//    {
//        public Guid? id { get; set; }   //No need to set
//        public string cardBin { get; set; } //No need to set
//        public string lastDigits { get; set; } //No need to set
//        public string cardNum { get; set; }
//        public pgDate cardExpiry { get; set; }
//        public string CVV { get; set; } //No need to assign
//        public string cardType { get; set; } //No need to set
//        public string cardCategory { get; set; } //No need to set
//        public string nickName { get; set; }
//        public string merchantRefNum { get; set; }
//        public string holderName { get; set; }
//        public Guid? billingAddressId { get; set; } //No need to set
//        public bool defaultCardIndicator { get; set; } //No need to set
//        public string paymentToken { get; set; } //No need to set
//        public string status { get; set; } //No need to set
//        public pgAddress billingAddress { get; set; }


//    }

//    public class pgAddress
//    {
//        public Guid? id { get; set; }    //No need to set
//        public string status { get; set; }  //No need to set
//        public string nickName { get; set; }
//        public string street { get; set; }
//        public string street2 { get; set; }
//        public string city { get; set; }
//        public string zip { get; set; }
//        public string country { get; set; }
//        public string state { get; set; }
//        public string recipientName { get; set; } //No need to set
//        public string phone { get; set; } //No need to set
//        public bool defaultShippingAddressIndicator { get; set; }   //Adding an address
//    }

//    public class pgAuthorization
//    {
//        public Guid id { get; set; }    //No need to assign
//        public string txnTime { get; set; }    //No need to assign
//        public string status { get; set; }    //No need to assign
//        public decimal availableToSettle { get; set; }    //No need to assign

//        public string merchantRefNum { get; set; }
//        public decimal amount { get; set; }
//        public bool settleWithAuth { get; set; }
//        public bool dupCheck { get; set; }
//        public pgCard card { get; set; }     //Assign only PaymentToken and CVV
//        public string[] keywords { get; set; } //Repeat Customer, Profile
//        public string customerIp { get; set; }
//        public string description { get; set; }

//        public string authCode { get; set; }//No need to assign
//        public pgProfile profile { get; set; }//No need to assign
//        public pgAddress billingDetails { get; set; }//No need to assign
//        public string currencyCode { get; set; }//No need to assign
//        public string avsResponse { get; set; }//No need to assign
//        public string cvvVerification { get; set; }//No need to assign
//        public pgLink[] links { get; set; }  //No need to assign

//    }

//    public class pgAuthorizations
//    {
//        public pgAuthorization[] auths { get; set; }
//    }

//    public class pgProfile
//    {
//        public string firstName { get; set; }
//        public string lastName { get; set; }
//        public string email { get; set; }
//    }

//    public class pgLink
//    {
//        public string rel { get; set; }
//        public string href { get; set; }
//    }

//    public class pgSettlement
//    {
//        public string merchantRefNum { get; set; }
//        public bool dupCheck { get; set; }

//        public Guid id { get; set; }    //No need to assign
//        public decimal amount { get; set; }//No need to assign
//        public decimal  availableToRefund { get; set; }//No need to assign
//        public string txnTime { get; set; }//No need to assign
//        public string status { get; set; }//No need to assign
//        public pgLink links { get; set; }//No need to assign
//    }

//    public class pgSettlements
//    {
//        public pgSettlement settlements { get; set; }
//    }

//}
