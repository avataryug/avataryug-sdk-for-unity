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
    public class PurchaseInstanceRequest
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
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name = "Price", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Price")]
        public int? Price { get; set; }

        /// <summary>
        /// Gets or Sets VirtualCurrency
        /// </summary>
        [DataMember(Name = "VirtualCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "VirtualCurrency")]
        public string VirtualCurrency { get; set; }

        /// <summary>
        /// Gets or Sets StoreID
        /// </summary>
        [DataMember(Name = "StoreID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "StoreID")]
        public string StoreID { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PurchaseInstanceRequest {\n");
            sb.Append("  InstanceID: ").Append(InstanceID).Append("\n");
            sb.Append("  InstanceType: ").Append(InstanceType).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
            sb.Append("  StoreID: ").Append(StoreID).Append("\n");
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
