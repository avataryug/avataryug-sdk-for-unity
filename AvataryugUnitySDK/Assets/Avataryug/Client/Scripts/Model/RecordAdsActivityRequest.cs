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
    public class RecordAdsActivityRequest
    {
        /// <summary>
        /// Gets or Sets RevenueCurrency
        /// </summary>
        [DataMember(Name = "RevenueCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "RevenueCurrency")]
        public string RevenueCurrency { get; set; }

        /// <summary>
        /// Gets or Sets AdRevenue
        /// </summary>
        [DataMember(Name = "AdRevenue", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AdRevenue")]
        public int AdRevenue { get; set; }

        /// <summary>
        /// Gets or Sets PlacementID
        /// </summary>
        [DataMember(Name = "PlacementID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "PlacementID")]
        public string PlacementID { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RecordAdsActivityRequest {\n");
            sb.Append("  RevenueCurrency: ").Append(RevenueCurrency).Append("\n");
            sb.Append("  AdRevenue: ").Append(AdRevenue).Append("\n");
            sb.Append("  PlacementID: ").Append(PlacementID).Append("\n");
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
