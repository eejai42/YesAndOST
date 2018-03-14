using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class AuthToken
    {
        private void InitPoco()
        {
            
            this.AuthTokenId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AuthTokenId")]
        public Guid AuthTokenId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "PersonId")]
        public Guid PersonId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TemporaryAccessToken")]
        public Nullable<Guid> TemporaryAccessToken { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "HashedToken")]
        public String HashedToken { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CreatedOn")]
        public DateTime CreatedOn { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ExpiresOn")]
        public Nullable<DateTime> ExpiresOn { get; set; }
    

        

        
        
        private static string CreateAuthTokenWhere(IEnumerable<AuthToken> authTokens, String forignKeyFieldName = "AuthTokenId")
        {
            if (!authTokens.Any()) return "1=1";
            else 
            {
                var idList = authTokens.Select(selectAuthToken => String.Format("'{0}'", selectAuthToken.AuthTokenId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
