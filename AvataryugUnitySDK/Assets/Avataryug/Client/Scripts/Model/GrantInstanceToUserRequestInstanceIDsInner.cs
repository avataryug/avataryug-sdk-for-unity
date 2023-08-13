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
    public class GrantInstanceToUserRequestInstanceIDsInner
    {
        /// <summary>
        /// Gets or Sets InstanceID
        /// </summary>
        [DataMember(Name = "InstanceID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "InstanceID")]
        public string InstanceID { get; set; }

        /// <summary>
        /// Gets or Sets InstanceType
        /// </summary>
        [DataMember(Name = "InstanceType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "InstanceType")]
        public string InstanceType { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Quantity")]
        public int? Quantity { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GrantInstanceToUserRequestInstanceIDsInner {\n");
            sb.Append("  InstanceID: ").Append(InstanceID).Append("\n");
            sb.Append("  InstanceType: ").Append(InstanceType).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
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