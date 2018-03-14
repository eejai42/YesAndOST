using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class Person
    {
        private void InitPoco()
        {
            
            this.PersonId = Guid.NewGuid();
            
                this.AuthTokens = new BindingList<AuthToken>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "PersonId")]
        public Guid PersonId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "EmailAddress")]
        public String EmailAddress { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsEmailVerified")]
        public Boolean IsEmailVerified { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "PhoneNumber")]
        public String PhoneNumber { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsPhoneerified")]
        public Boolean IsPhoneerified { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DOB")]
        public Nullable<DateTime> DOB { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SSN")]
        public String SSN { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "PreferredHandle")]
        public String PreferredHandle { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AuthTokens")]
        public BindingList<AuthToken> AuthTokens { get; set; }
            
        /// <summary>
        /// Find the related AuthTokens (from the list provided) and attach them locally to the AuthTokens list.
        /// </summary>
        public void LoadAuthTokens(IEnumerable<AuthToken> authTokens)
        {
            authTokens.Where(whereAuthToken => whereAuthToken.PersonId == this.PersonId)
                    .ToList()
                    .ForEach(feAuthToken => this.AuthTokens.Add(feAuthToken));
        }
        

        
        
        private static string CreatePersonWhere(IEnumerable<Person> persons, String forignKeyFieldName = "PersonId")
        {
            if (!persons.Any()) return "1=1";
            else 
            {
                var idList = persons.Select(selectPerson => String.Format("'{0}'", selectPerson.PersonId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
