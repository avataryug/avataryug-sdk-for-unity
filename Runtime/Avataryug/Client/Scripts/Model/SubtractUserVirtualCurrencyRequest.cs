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
    public class SubtractUserVirtualCurrencyRequest
    {
        /// <summary>
        /// Gets or Sets VirtualCurrency
        /// </summary>
        [DataMember(Name = "VirtualCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "VirtualCurrency")]
        public string VirtualCurrency { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "Amount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Amount")]
        public int? Amount { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubtractUserVirtualCurrencyRequest {\n");
            sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
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
