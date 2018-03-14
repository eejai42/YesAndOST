using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class ARM
    {
        private void InitPoco()
        {
            
            this.ARMId = Guid.NewGuid();
            
                this.Abstractions = new BindingList<Abstraction>();
            
                this.ARMPersons = new BindingList<ARMPerson>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMId")]
        public Guid ARMId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Started")]
        public Nullable<DateTime> Started { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Completed")]
        public Nullable<DateTime> Completed { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsComplete")]
        public Boolean IsComplete { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "InviteCode")]
        public Nullable<Guid> InviteCode { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FocusAbstractionId")]
        public Nullable<Guid> FocusAbstractionId { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Abstractions")]
        public BindingList<Abstraction> Abstractions { get; set; }
            
        /// <summary>
        /// Find the related Abstractions (from the list provided) and attach them locally to the Abstractions list.
        /// </summary>
        public void LoadAbstractions(IEnumerable<Abstraction> abstractions)
        {
            abstractions.Where(whereAbstraction => whereAbstraction.ARMId == this.ARMId)
                    .ToList()
                    .ForEach(feAbstraction => this.Abstractions.Add(feAbstraction));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMPersons")]
        public BindingList<ARMPerson> ARMPersons { get; set; }
            
        /// <summary>
        /// Find the related ARMPersons (from the list provided) and attach them locally to the ARMPersons list.
        /// </summary>
        public void LoadARMPersons(IEnumerable<ARMPerson> aRMPersons)
        {
            aRMPersons.Where(whereARMPerson => whereARMPerson.ARMId == this.ARMId)
                    .ToList()
                    .ForEach(feARMPerson => this.ARMPersons.Add(feARMPerson));
        }
        

        
        
        private static string CreateARMWhere(IEnumerable<ARM> aRMs, String forignKeyFieldName = "ARMId")
        {
            if (!aRMs.Any()) return "1=1";
            else 
            {
                var idList = aRMs.Select(selectARM => String.Format("'{0}'", selectARM.ARMId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
