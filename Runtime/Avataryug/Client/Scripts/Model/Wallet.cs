using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    [System.Serializable]
    public class Wallet
    {
        /// <summary>
        /// Gets or Sets VirtualCurrency
        /// </summary>
        [DataMember(Name = "VirtualCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "VirtualCurrency")]
        public string VirtualCurrency;

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "Amount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Amount")]
        public int Amount;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Wallet {\n");
            sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
            sb.Append("  Status: ").Append(Amount).Append("\n");
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
