using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;


namespace Com.Avataryug.Model
{

    /// <summary>
    /// This class holds detail of linked accounts
    /// </summary>
    [System.Serializable]
    public class Accounts
    {
        //Get or Set Platform
        [DataMember(Name = "Platform", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Platform")]
        public string Platform;

        //Get or Set PlatformUserID
        [DataMember(Name = "PlatformUserID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "PlatformUserID")]
        public string PlatformUserID;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Accounts {\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
            sb.Append("  PlatformUserID: ").Append(PlatformUserID).Append("\n");
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

    [System.Serializable]
    public class LinkedAcounts
    {
        [DataMember(Name = "linkedAcounts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "linkedAcounts")]
        public List<Accounts> linkedAcounts = new List<Accounts>();


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LinkedAcounts {\n");
            sb.Append("  linkedAcounts: ").Append(linkedAcounts).Append("\n");
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

