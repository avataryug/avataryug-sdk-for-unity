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
    public class ConsumeInstanceRequest
    {

        /// <summary>
        /// Number of uses to consume from the item.
        /// </summary>
        /// <value>Number of uses to consume from the item.</value>
        [DataMember(Name = "InstanceID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "InstanceID")]
        public string InstanceID { get; set; }

        /// <summary>
        /// Gets or Sets InstanceCount
        /// </summary>
        [DataMember(Name = "InstanceCount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "InstanceCount")]
        public int? InstanceCount { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConsumeInstanceRequest {\n");
            sb.Append("  InstanceID: ").Append(InstanceID).Append("\n");
            sb.Append("  InstanceCount: ").Append(InstanceCount).Append("\n");
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
