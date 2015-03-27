using MyGenomics.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using MyGenomics.Data.Context;
using SugarCRM = MyGenomics.Data.SugarCRM;

namespace MyGenomics.Data.SugarCRM
{
    public class Client
    {
        #region Private Fields

        //private string _sessionId;
        private string _userId;
        private string _sugarUrl = "http://crm.mygenomics.eu/service/v4_1/rest.php?";
        private string _username = "chiara.carrozzini";
        private string _pwd = "chiaracarrozzini";
        private CultureInfo _culture = new CultureInfo("en-US");
        private WebClient _client = new WebClient();
        private JavaScriptSerializer _serializer = new JavaScriptSerializer();

        #endregion


        #region Public Methods

        public string Authenticate()
        {
            _serializer.MaxJsonLength = Int32.MaxValue;
            string json = _serializer.Serialize(new
            {
                user_auth = new { user_name = _username, password = CalculateMD5Hash(_pwd) },
                application_name = "RestClient"
            });

            var values = new NameValueCollection();
            values["method"] = "login";
            values["input_type"] = "json";
            values["response_type"] = "json";
            values["rest_data"] = json;

            var response = _client.UploadValues(_sugarUrl, values);

            var responseString = Encoding.Default.GetString(response);

            var loginResponse = _serializer.Deserialize<Dictionary<string, dynamic>>(responseString);
            _userId = loginResponse["name_value_list"]["user_id"]["value"];
            return loginResponse["id"];
        }

        public Contact GetContact(string userName, string sessionId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            var json = _serializer.Serialize(new
            {
                session = sessionId,
                module_name = "Contacts",
                query = "area_riservata_uid_c = '" + userName + "'",
                order_by = "",
                offset = "0",
                select_fields = "",
                link_name_to_fields_array = "",
                max_results = "100",
                deleted = 0
            });

            var values = new NameValueCollection();
            values = new NameValueCollection();
            values["method"] = "get_entry_list";
            values["input_type"] = "json";
            values["response_type"] = "json";
            values["rest_data"] = json;

            var response = _client.UploadValues(_sugarUrl, values);
            var responseString = Encoding.Default.GetString(response);

            var contacts = _serializer.Deserialize<Dictionary<string, dynamic>>(responseString);
            if (contacts["result_count"] > 0)
            {
                return MapContact(contacts["entry_list"][0]["name_value_list"]);
            }

            return null;
        }

        public List<Contact> GetContacts(string sessionId)
        {
            List<Contact> result = new List<Contact>();

            var json = _serializer.Serialize(new
            {
                session = sessionId,
                module_name = "Contacts",
                order_by = "",
                offset = "0",
                select_fields = "",
                link_name_to_fields_array = "",
                deleted = 0
            });

            var values = new NameValueCollection();
            values = new NameValueCollection();
            values["method"] = "get_entry_list";
            values["input_type"] = "json";
            values["response_type"] = "json";
            values["rest_data"] = json;

            var response = _client.UploadValues(_sugarUrl, values);
            var responseString = Encoding.Default.GetString(response);

            var contacts = _serializer.Deserialize<Dictionary<string, dynamic>>(responseString);
            var count = contacts["result_count"];
            for (int i = 0; i < count; i++)
            {
                result.Add(MapContact(contacts["entry_list"][i]["name_value_list"]));
            }
            return result;
        }


        public void UpdateExistingContact(Contact contact, string sessionId)
        {
            string userId = null;

            // Occorre caricare il contatto con username specificato per avere l'Id di Sugar
            Dictionary<string, string> user = new Dictionary<string, string>();

            // Leggo il contatto per avere l'ID
            var json = _serializer.Serialize(new
            {
                session = sessionId,
                module_name = "Contacts",
                query = "area_riservata_uid_c = '" + contact.UserName + "'",
                order_by = "",
                offset = "0",
                select_fields = "",
                link_name_to_fields_array = "",
                max_results = "100",
                deleted = 0
            });

            var values = new NameValueCollection();
            values = new NameValueCollection();
            values["method"] = "get_entry_list";
            values["input_type"] = "json";
            values["response_type"] = "json";
            values["rest_data"] = json;

            var response = _client.UploadValues(_sugarUrl, values);
            var responseString = Encoding.Default.GetString(response);

            var contacts = _serializer.Deserialize<Dictionary<string, dynamic>>(responseString);
            if (contacts["result_count"] > 0)
            {
                userId = contacts["entry_list"][0]["name_value_list"]["id"]["value"];
            }

            if (userId == null)

                throw new Exception("Existing contact: " + contact.UserName + " not found in CRM");

            // update
            json = _serializer.Serialize(new
            {
                session = sessionId,
                module_name = "Contacts",
                name_value_list = new
                {
                    //Address = item["primary_address_street"]["value"],
                    ////BirthCity = 
                    //BirthDate = birthDate,
                    //City = item["primary_address_city"]["value"],
                    //Email = item["email1"]["value"],
                    //FirstName = item["first_name"]["value"],
                    ////Gender
                    //LastName = item["last_name"]["value"],
                    //Password = item["area_riservata_psw_c"]["value"],
                    ////ContactalDoctor = 
                    ////ContactType =
                    //PhoneNumber = item["phone_mobile"]["value"],
                    //UserName = item["area_riservata_uid_c"]["value"],

                    id = userId,
                    primary_address_street = contact.Address,
                    birthdate = contact.BirthDate.Year + "-"
                        + contact.BirthDate.Month + "-"
                        + contact.BirthDate.Day,
                    email1 = contact.Email,
                    first_name = contact.FirstName,
                    last_name = contact.LastName,
                    // area_riservata_psw_c  - per ora on posso modificare la pwd
                    phone_mobile = contact.PhoneNumber,
                }
            });


            values = new NameValueCollection();
            values["method"] = "set_entry";
            values["input_type"] = "json";
            values["response_type"] = "json";
            values["rest_data"] = json;

            response = _client.UploadValues(_sugarUrl, values);
            responseString = Encoding.Default.GetString(response);
            var result = _serializer.Deserialize<Dictionary<string, dynamic>>(responseString);
            // TO DO: Check if there was an error    
        }

        public void SetQuestionnaireResult(Contact contact, List<Product> recommendedAnalysis, string sessionId)
        {
            // TO DO: Da implementare sulla base di ciò che deve essere salvato nel CRM
            Dictionary<string, string> crmProducts = new Dictionary<string, string>();

            //contacts_bc_prodotti_2
            var json = _serializer.Serialize(new
            {
                session = sessionId,
                module_name = "bc_Prodotti",
                order_by = "",
                offset = "0",
                select_fields = "",
                link_name_to_fields_array = "",
                max_results = "100",
                deleted = 0
            });

            var values = new NameValueCollection();
            values = new NameValueCollection();
            values["method"] = "get_entry_list";
            values["input_type"] = "json";
            values["response_type"] = "json";
            values["rest_data"] = json;

            var response = _client.UploadValues(_sugarUrl, values);
            var responseString = Encoding.Default.GetString(response);

            var responseList = _serializer.Deserialize<Dictionary<string, dynamic>>(responseString);
            var count = responseList["result_count"];
            for (int i = 0; i < count; i++)
            {
                var item = responseList["entry_list"][i]["name_value_list"];
                crmProducts.Add(item["id"]["value"], item["name"]["value"]);
            }



            // Get the Contact 
            string userId = null;
            json = _serializer.Serialize(new
            {
                session = sessionId,
                module_name = "Contacts",
                query = "area_riservata_uid_c = '" + contact.UserName + "'",
                order_by = "",
                offset = "0",
                select_fields = "",
                link_name_to_fields_array = "",
                max_results = "100",
                deleted = 0
            });

            values = new NameValueCollection();
            values["method"] = "get_entry_list";
            values["input_type"] = "json";
            values["response_type"] = "json";
            values["rest_data"] = json;

            response = _client.UploadValues(_sugarUrl, values);
            responseString = Encoding.Default.GetString(response);

            responseList = _serializer.Deserialize<Dictionary<string, dynamic>>(responseString);
            if (responseList["result_count"] > 0)
            {
                userId = responseList["entry_list"][0]["name_value_list"]["id"]["value"];
            }

            if (String.IsNullOrEmpty(userId))
                return;

            foreach (var item in recommendedAnalysis)
            {
                foreach (var prod in crmProducts.Where(p => p.Value.ToLowerInvariant().Contains(item.Name.ToLowerInvariant())))
                {
                    var jsonRelation = _serializer.Serialize(new
                    {
                        session = sessionId,
                        module_name = "Contacts",
                        module_id = userId,
                        link_field_name = "contacts_bc_prodotti_2",
                        related_ids = new string[] { prod.Key },
                        delete = 0
                    });

                    var relationValues = new NameValueCollection();
                    relationValues["method"] = "set_relationship";
                    relationValues["input_type"] = "json";
                    relationValues["response_type"] = "json";
                    relationValues["rest_data"] = jsonRelation;

                    var relationResponse = _client.UploadValues(_sugarUrl, relationValues);
                    var relationString = Encoding.Default.GetString(relationResponse);

                    responseList = _serializer.Deserialize<Dictionary<string, dynamic>>(responseString);
                } 
            }
        }


        #endregion


        #region Private Methods

        private Contact MapContact(dynamic item)
        {
            DateTime birthDate;

            // Conversione data
            if (item["birthdate"]["value"] is string &&
                !String.IsNullOrEmpty(item["birthdate"]["value"]))
            {
                string[] date = item["birthdate"]["value"].Split('-');
                birthDate = new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]));
            }
            else
                birthDate = new DateTime(1900, 1, 1);

            return new Contact()
            {
                //alt_address_city
                //alt_address_country
                //alt_address_postalcode
                //alt_address_state
                //alt_address_street
                //* altezza_in_cm_c
                //* area_riservata_psw_c
                //* area_riservata_uid_c
                //assistant
                //assistant_phone
                //birthdate
                //* chiede_fattura_c
                //* codice_fiscale_c
                //* cognome_fatturazione_c
                //* da_verificare_c
                //* data_di_nascita_c
                //date_entered
                //date_modified
                //* dati_fatturazione_c
                //deleted
                //department
                //description
                //do_not_call
                //* etnia_c
                //lead_source
                //* peso_in_kg_c
                //phone_fax
                //phone_home
                //phone_other
                //phone_work
                //primary_address_country
                //primary_address_postalcode
                //primary_address_state
                //salutation
                //* sesso_c
                //title

                Address = item["primary_address_street"]["value"],
                //BirthCity = 
                BirthDate = birthDate,
                City = item["primary_address_city"]["value"],
                Email = item["email1"]["value"],
                FirstName = item["first_name"]["value"],
                //Gender
                LastName = item["last_name"]["value"],
                Password = item["area_riservata_psw_c"]["value"],
                //ContactalDoctor = 
                //ContactType =
                PhoneNumber = item["phone_mobile"]["value"],
                UserName = item["area_riservata_uid_c"]["value"],
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }

        private string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        #endregion
    }
}

