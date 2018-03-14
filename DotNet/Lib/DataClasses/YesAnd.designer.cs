using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class YesAnd
    {
        private void InitPoco()
        {
            
            this.YesAndId = Guid.NewGuid();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "YesAndId")]
        public Guid YesAndId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMChatId")]
        public Guid ARMChatId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Yes")]
        public Nullable<Boolean> Yes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "YesAndAlso")]
        public Nullable<Boolean> YesAndAlso { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "YesAndARMChatId")]
        public Nullable<Guid> YesAndARMChatId { get; set; }
    

        

        
        
        private static string CreateYesAndWhere(IEnumerable<YesAnd> yesAnds, String forignKeyFieldName = "YesAndId")
        {
            if (!yesAnds.Any()) return "1=1";
            else 
            {
                var idList = yesAnds.Select(selectYesAnd => String.Format("'{0}'", selectYesAnd.YesAndId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
