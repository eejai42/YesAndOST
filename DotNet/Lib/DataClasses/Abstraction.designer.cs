using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class Abstraction
    {
        private void InitPoco()
        {
            
            this.AbstractionId = Guid.NewGuid();
            
                this.ParentAbstractionId_Abstractions = new BindingList<Abstraction>();
            
                this.APAAgreements = new BindingList<APAAgreement>();
            
                this.FocusAbstractionId_ARMs = new BindingList<ARM>();
            
                this.ARMChats = new BindingList<ARMChat>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AbstractionId")]
        public Guid AbstractionId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMId")]
        public Guid ARMId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "StatementId")]
        public Guid StatementId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ParentAbstractionId")]
        public Nullable<Guid> ParentAbstractionId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ParentAbstractionId_Abstractions")]
        public BindingList<Abstraction> ParentAbstractionId_Abstractions { get; set; }
            
        /// <summary>
        /// Find the related Abstractions (from the list provided) and attach them locally to the Abstractions list.
        /// </summary>
        public void LoadParentAbstractionId_Abstractions(IEnumerable<Abstraction> abstractions)
        {
            abstractions.Where(whereAbstraction => whereAbstraction.ParentAbstractionId == this.AbstractionId)
                    .ToList()
                    .ForEach(feAbstraction => this.ParentAbstractionId_Abstractions.Add(feAbstraction));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "APAAgreements")]
        public BindingList<APAAgreement> APAAgreements { get; set; }
            
        /// <summary>
        /// Find the related APAAgreements (from the list provided) and attach them locally to the APAAgreements list.
        /// </summary>
        public void LoadAPAAgreements(IEnumerable<APAAgreement> aPAAgreements)
        {
            aPAAgreements.Where(whereAPAAgreement => whereAPAAgreement.AbstractionId == this.AbstractionId)
                    .ToList()
                    .ForEach(feAPAAgreement => this.APAAgreements.Add(feAPAAgreement));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FocusAbstractionId_ARMs")]
        public BindingList<ARM> FocusAbstractionId_ARMs { get; set; }
            
        /// <summary>
        /// Find the related ARMs (from the list provided) and attach them locally to the ARMs list.
        /// </summary>
        public void LoadFocusAbstractionId_ARMs(IEnumerable<ARM> aRMs)
        {
            aRMs.Where(whereARM => whereARM.FocusAbstractionId == this.AbstractionId)
                    .ToList()
                    .ForEach(feARM => this.FocusAbstractionId_ARMs.Add(feARM));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMChats")]
        public BindingList<ARMChat> ARMChats { get; set; }
            
        /// <summary>
        /// Find the related ARMChats (from the list provided) and attach them locally to the ARMChats list.
        /// </summary>
        public void LoadARMChats(IEnumerable<ARMChat> aRMChats)
        {
            aRMChats.Where(whereARMChat => whereARMChat.AbstractionId == this.AbstractionId)
                    .ToList()
                    .ForEach(feARMChat => this.ARMChats.Add(feARMChat));
        }
        

        
        
        private static string CreateAbstractionWhere(IEnumerable<Abstraction> abstractions, String forignKeyFieldName = "AbstractionId")
        {
            if (!abstractions.Any()) return "1=1";
            else 
            {
                var idList = abstractions.Select(selectAbstraction => String.Format("'{0}'", selectAbstraction.AbstractionId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
