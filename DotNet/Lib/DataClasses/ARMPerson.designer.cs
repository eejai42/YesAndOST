using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class ARMPerson
    {
        private void InitPoco()
        {
            
            this.ARMPersonId = Guid.NewGuid();
            
                this.APAAgreements = new BindingList<APAAgreement>();
            
                this.ARMChats = new BindingList<ARMChat>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMPersonId")]
        public Guid ARMPersonId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AvatarId")]
        public Guid AvatarId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMId")]
        public Guid ARMId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "JoinedOn")]
        public DateTime JoinedOn { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "APAAgreements")]
        public BindingList<APAAgreement> APAAgreements { get; set; }
            
        /// <summary>
        /// Find the related APAAgreements (from the list provided) and attach them locally to the APAAgreements list.
        /// </summary>
        public void LoadAPAAgreements(IEnumerable<APAAgreement> aPAAgreements)
        {
            aPAAgreements.Where(whereAPAAgreement => whereAPAAgreement.ARMPersonId == this.ARMPersonId)
                    .ToList()
                    .ForEach(feAPAAgreement => this.APAAgreements.Add(feAPAAgreement));
        }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMChats")]
        public BindingList<ARMChat> ARMChats { get; set; }
            
        /// <summary>
        /// Find the related ARMChats (from the list provided) and attach them locally to the ARMChats list.
        /// </summary>
        public void LoadARMChats(IEnumerable<ARMChat> aRMChats)
        {
            aRMChats.Where(whereARMChat => whereARMChat.ARMPersonId == this.ARMPersonId)
                    .ToList()
                    .ForEach(feARMChat => this.ARMChats.Add(feARMChat));
        }
        

        
        
        private static string CreateARMPersonWhere(IEnumerable<ARMPerson> aRMPersons, String forignKeyFieldName = "ARMPersonId")
        {
            if (!aRMPersons.Any()) return "1=1";
            else 
            {
                var idList = aRMPersons.Select(selectARMPerson => String.Format("'{0}'", selectARMPerson.ARMPersonId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
