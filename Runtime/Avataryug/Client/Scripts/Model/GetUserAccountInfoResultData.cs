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
    public class GetUserAccountInfoResultData
    {
        /// <summary>
        /// Gets or Sets UserID
        /// </summary>
        [DataMember(Name = "UserID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "UserID")]
        public string UserID { get; set; }

        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "DisplayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DisplayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "UpdatedAt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "UpdatedAt")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "Wallet", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Wallet")]
        public string Wallet { get; set; }

        [DataMember(Name = "Location", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Location")]
        public string Location { get; set; }

        [DataMember(Name = "DefaultAvatarID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DefaultAvatarID")]
        public string DefaultAvatarID { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUserAccountInfoResultData {\n");
            sb.Append("  UserID: ").Append(UserID).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Wallet: ").Append(Wallet).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  DefaultAvatarID: ").Append(DefaultAvatarID).Append("\n");
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
