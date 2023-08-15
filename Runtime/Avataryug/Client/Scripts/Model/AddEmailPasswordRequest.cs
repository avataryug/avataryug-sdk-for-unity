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
    public class AddEmailPasswordRequest
    {
        /// <summary>
        /// Gets or Sets EmailID
        /// </summary>
        [DataMember(Name = "EmailID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "EmailID")]
        public string EmailID { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "Password", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddEmailPasswordRequest {\n");
            sb.Append("  EmailID: ").Append(EmailID).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
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
