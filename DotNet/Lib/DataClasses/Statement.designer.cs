using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class Statement
    {
        private void InitPoco()
        {
            
            this.StatementId = Guid.NewGuid();
            
                this.Abstractions = new BindingList<Abstraction>();
            
                this.ARMChats = new BindingList<ARMChat>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "StatementId")]
        public Guid StatementId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "StatementText")]
        public String StatementText { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "StrippedStatementText")]
        public String StrippedStatementText { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "OriginalMD5Hash")]
        public Guid OriginalMD5Hash { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "StrippedMD5Hash")]
        public Guid StrippedMD5Hash { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Abstractions")]
        public BindingList<Abstraction> Abstractions { get; set; }
            
        /// <summary>
        /// Find the related Abstractions (from the list provided) and attach them locally to the Abstractions list.
        /// </summary>
        public void LoadAbstractions(IEnumerable<Abstraction> abstractions)
        {
            abstractions.Where(whereAbstraction => whereAbstraction.StatementId == this.StatementId)
                    .ToList()
                    .ForEach(feAbstraction => this.Abstractions.Add(feAbstraction));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMChats")]
        public BindingList<ARMChat> ARMChats { get; set; }
            
        /// <summary>
        /// Find the related ARMChats (from the list provided) and attach them locally to the ARMChats list.
        /// </summary>
        public void LoadARMChats(IEnumerable<ARMChat> aRMChats)
        {
            aRMChats.Where(whereARMChat => whereARMChat.StatementId == this.StatementId)
                    .ToList()
                    .ForEach(feARMChat => this.ARMChats.Add(feARMChat));
        }
        

        
        
        private static string CreateStatementWhere(IEnumerable<Statement> statements, String forignKeyFieldName = "StatementId")
        {
            if (!statements.Any()) return "1=1";
            else 
            {
                var idList = statements.Select(selectStatement => String.Format("'{0}'", selectStatement.StatementId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
