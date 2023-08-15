using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class Wallets
    {
        /// <summary>
        /// Gets or Sets wallets
        /// </summary>
        [DataMember(Name = "wallets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "wallets")]
        public List<Wallet> wallets = new List<Wallet>();


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Wallets {\n");
            sb.Append("  wallets: ").Append(wallets).Append("\n");
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
