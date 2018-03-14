using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace YesAndOST.Lib.DataClasses
{                            
    public partial class Avatar
    {
        private void InitPoco()
        {
            
            this.AvatarId = Guid.NewGuid();
            
                this.ARMPersons = new BindingList<ARMPerson>();
            

        }

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AvatarId")]
        public Guid AvatarId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Handle")]
        public String Handle { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Nickname")]
        public String Nickname { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ARMPersons")]
        public BindingList<ARMPerson> ARMPersons { get; set; }
            
        /// <summary>
        /// Find the related ARMPersons (from the list provided) and attach them locally to the ARMPersons list.
        /// </summary>
        public void LoadARMPersons(IEnumerable<ARMPerson> aRMPersons)
        {
            aRMPersons.Where(whereARMPerson => whereARMPerson.AvatarId == this.AvatarId)
                    .ToList()
                    .ForEach(feARMPerson => this.ARMPersons.Add(feARMPerson));
        }
        

        
        
        private static string CreateAvatarWhere(IEnumerable<Avatar> avatars, String forignKeyFieldName = "AvatarId")
        {
            if (!avatars.Any()) return "1=1";
            else 
            {
                var idList = avatars.Select(selectAvatar => String.Format("'{0}'", selectAvatar.AvatarId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

namespace CoreLibrary.Extensions { }
