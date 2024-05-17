using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class UpdateAvatarRequest
    {
        /// <summary>
        /// Gets or Sets AvatarID
        /// </summary>
        [DataMember(Name = "AvatarID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarID")]
        public string AvatarID { get; set; }
        /// <summary>
        /// Gets or Sets PatchData
        /// </summary>
        [DataMember(Name = "PatchData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "PatchData")]
        public string PatchData { get; set; }

        /// <summary>
        /// Gets or Sets PatchDataType
        /// </summary>
        [DataMember(Name = "PatchDataType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "PatchDataType")]
        public string PatchDataType { get; set; }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [DataMember(Name = "Action", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Action")]
        public string Action { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VerifyUserWithEmailRequest {\n");
            sb.Append("  AvatarID: ").Append(AvatarID).Append("\n");
            sb.Append("  PatchData: ").Append(PatchData).Append("\n");
            sb.Append("  PatchDataType: ").Append(PatchDataType).Append("\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }
}
