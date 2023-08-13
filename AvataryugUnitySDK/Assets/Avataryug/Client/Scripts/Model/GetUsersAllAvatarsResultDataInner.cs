using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GetUsersAllAvatarsResultDataInner
    {
        /// <summary>
        /// Gets or Sets UserID
        /// </summary>
        [DataMember(Name = "AvatarID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarID")]
        public string AvatarID { get; set; }

        /// <summary>
        /// Gets or Sets AvatarUrl
        /// </summary>
        [DataMember(Name = "AvatarUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Gets or Sets ProjectID
        /// </summary>
        [DataMember(Name = "ThumbUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ThumbUrl")]
        public string ThumbUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "AvatarData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarData")]
        public string AvatarData { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUsersAllAvatarsResultDataInner {\n");
            sb.Append("  AvatarID: ").Append(AvatarID).Append("\n");
            sb.Append("  AvatarUrl: ").Append(AvatarUrl).Append("\n");
            sb.Append("  ThumbUrl: ").Append(ThumbUrl).Append("\n");
            sb.Append("  AvatarData: ").Append(AvatarData).Append("\n");

            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }
}
