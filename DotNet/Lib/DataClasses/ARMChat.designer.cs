using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class ARMChat
    {
        private void InitPoco()
        {
            
            this.ARMChatId = Guid.NewGuid();
            
                this.YesAnds = new BindingList<YesAnd>();
            
                this.YesAndARMChatId_YesAnds = new BindingList<YesAnd>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMChatId")]
        public Guid ARMChatId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CreatedAt")]
        public DateTime CreatedAt { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMPersonId")]
        public Guid ARMPersonId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AbstractionId")]
        public Guid AbstractionId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "StatementId")]
        public Guid StatementId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "YesAnds")]
        public BindingList<YesAnd> YesAnds { get; set; }
            
        /// <summary>
        /// Find the related YesAnds (from the list provided) and attach them locally to the YesAnds list.
        /// </summary>
        public void LoadYesAnds(IEnumerable<YesAnd> yesAnds)
        {
            yesAnds.Where(whereYesAnd => whereYesAnd.ARMChatId == this.ARMChatId)
                    .ToList()
                    .ForEach(feYesAnd => this.YesAnds.Add(feYesAnd));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "YesAndARMChatId_YesAnds")]
        public BindingList<YesAnd> YesAndARMChatId_YesAnds { get; set; }
            
        /// <summary>
        /// Find the related YesAnds (from the list provided) and attach them locally to the YesAnds list.
        /// </summary>
        public void LoadYesAndARMChatId_YesAnds(IEnumerable<YesAnd> yesAnds)
        {
            yesAnds.Where(whereYesAnd => whereYesAnd.YesAndARMChatId == this.ARMChatId)
                    .ToList()
                    .ForEach(feYesAnd => this.YesAndARMChatId_YesAnds.Add(feYesAnd));
        }
        

        
        
        private static string CreateARMChatWhere(IEnumerable<ARMChat> aRMChats, String forignKeyFieldName = "ARMChatId")
        {
            if (!aRMChats.Any()) return "1=1";
            else 
            {
                var idList = aRMChats.Select(selectARMChat => String.Format("'{0}'", selectARMChat.ARMChatId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
