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
    public class RenderAvatarImageRequest
    {
        /// <summary>
        /// Gets or Sets ProjectData
        /// </summary>
        [DataMember(Name = "AvatarID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarID")]
        public string AvatarID { get; set; }

        /// <summary>
        /// Gets or Sets MetaData
        /// </summary>
        [DataMember(Name = "Platform", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Platform")]
        public string Platform { get; set; }

        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RenderAvatarImageRequest {\n");
            sb.Append("  AvatarID: ").Append(AvatarID).Append("\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
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
