using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class PayForPurchaseRequest
    {
        /// <summary>
        /// Gets or Sets UserID
        /// </summary>
        [DataMember(Name = "UserID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "UserID")]
        public string UserID { get; set; }


        /// <summary>
        /// Gets or Sets TransactionID
        /// </summary>
        [DataMember(Name = "TransactionID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "TransactionID")]
        public string TransactionID { get; set; }


        /// <summary>
        /// Gets or Sets PaymentProvider
        /// </summary>
        [DataMember(Name = "PaymentProvider", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "PaymentProvider")]
        public string PaymentProvider { get; set; }


        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name = "Metadata", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Metadata")]
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or Sets CurrencyCode
        /// </summary>
        [DataMember(Name = "CurrencyCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CurrencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PayForPurchaseRequest {\n");
            sb.Append("  UserID: ").Append(UserID).Append("\n");
            sb.Append("  TransactionID: ").Append(TransactionID).Append("\n");
            sb.Append("  PaymentProvider: ").Append(PaymentProvider).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
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
