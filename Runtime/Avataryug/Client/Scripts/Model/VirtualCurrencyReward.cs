using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    /// <summary>
    /// This class holds list of virtual currency 
    /// </summary>
    [System.Serializable]
    public class VirtualCurrencys
    {

        //Get or Set currencyRewards
        [DataMember(Name = "currencyPrises", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "currencyPrises")]
        public List<CurrencyPrise> currencyPrises = new List<CurrencyPrise>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VirtualCurrencys {\n");
            sb.Append("  currencyPrises: ").Append(currencyPrises).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    /// <summary>
    /// This class holds virtual currency detail
    /// </summary>
    [System.Serializable]
    public class CurrencyPrise
    {
        //Get or Set Amount
        [DataMember(Name = "Amount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Amount")]
        public string Amount;

        //Get or Set DisplayName
        [DataMember(Name = "DisplayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DisplayName")]
        public string DisplayName;

        //Get or Set Selected
        [DataMember(Name = "Selected", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Selected")]
        public string Selected;

        //Get or Set UserID
        [DataMember(Name = "UserID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "UserID")]
        public string UserID;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CurrencyPrise {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Selected: ").Append(Selected).Append("\n");
            sb.Append("  UserID: ").Append(UserID).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}