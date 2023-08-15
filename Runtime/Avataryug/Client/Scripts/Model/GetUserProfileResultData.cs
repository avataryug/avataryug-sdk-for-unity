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
    public class GetUserProfileResultData
    {
        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }

        [DataMember(Name = "DisplayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DisplayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "DefaultAvatar", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DefaultAvatar")]
        public DefaultAvatar DefaultAvatar { get; set; }
        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "UpdatedAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "UpdatedAt")]
        public string UpdatedAt { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUserProfileResultData {\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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

    [DataContract]
    public class DefaultAvatar
    {
        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "AvatarID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarID")]
        public string AvatarID { get; set; }

        [DataMember(Name = "AvatarUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarUrl")]
        public string AvatarUrl { get; set; }

        [DataMember(Name = "ThumbUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ThumbUrl")]
        public string ThumbUrl { get; set; }

        [DataMember(Name = "AvatarData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarData")]
        public string AvatarData { get; set; }

        [DataMember(Name = "CreatedAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CreatedAt")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DefaultAvatar {\n");
            sb.Append("  AvatarID: ").Append(AvatarID).Append("\n");
            sb.Append("  AvatarUrl: ").Append(AvatarUrl).Append("\n");
            sb.Append("  ThumbUrl: ").Append(ThumbUrl).Append("\n");
            sb.Append("  AvatarData: ").Append(AvatarData).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
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
