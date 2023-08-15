using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// This class holds detail of locked container 
    /// </summary>
    [System.Serializable]
    public class ContainerSetting
    {

        // Get or set ContainerSettings
        [DataMember(Name = "ContainerSettings", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ContainerSettings")]
        public string ContainerSettings;

        // Get or set ContainerType
        [DataMember(Name = "ContainerType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ContainerType")]
        public string ContainerType;

        // Get or set LockedID
        [DataMember(Name = "LockedID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "LockedID")]
        public string LockedID;

        // Get or set LockedItemID
        [DataMember(Name = "LockedItemID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "LockedItemID")]
        public string LockedItemID;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContainerSetting {\n");
            sb.Append("  ContainerSettings: ").Append(ContainerSettings).Append("\n");
            sb.Append("  ContainerType: ").Append(ContainerType).Append("\n");
            sb.Append("  LockedID: ").Append(LockedID).Append("\n");
            sb.Append("  LockedItemID: ").Append(LockedItemID).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}

