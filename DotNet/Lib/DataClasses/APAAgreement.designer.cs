using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class APAAgreement
    {
        private void InitPoco()
        {
            
            this.APAAgreementId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "APAAgreementId")]
        public Guid APAAgreementId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMPersonId")]
        public Guid ARMPersonId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AbstractionId")]
        public Guid AbstractionId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IAgree")]
        public Nullable<Boolean> IAgree { get; set; }
    

        

        
        
        private static string CreateAPAAgreementWhere(IEnumerable<APAAgreement> aPAAgreements, String forignKeyFieldName = "APAAgreementId")
        {
            if (!aPAAgreements.Any()) return "1=1";
            else 
            {
                var idList = aPAAgreements.Select(selectAPAAgreement => String.Format("'{0}'", selectAPAAgreement.APAAgreementId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
