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
    public class ConfirmPurchaseResultData
    {
        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        [DataMember(Name = "Owner", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Owner")]
        public string Owner { get; set; }

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
        /// Gets or Sets TransactionStatus
        /// </summary>
        [DataMember(Name = "TransactionStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "TransactionStatus")]
        public string TransactionStatus { get; set; }

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
        /// Gets or Sets CurrencyAmount
        /// </summary>
        [DataMember(Name = "CurrencyAmount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CurrencyAmount")]
        public string CurrencyAmount { get; set; }

        /// <summary>
        /// Gets or Sets CurrencyAmountUsd
        /// </summary>
        [DataMember(Name = "CurrencyAmountUsd", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CurrencyAmountUsd")]
        public int CurrencyAmountUsd { get; set; }

        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConfirmPurchaseResultData {\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  TransactionID: ").Append(TransactionID).Append("\n");
            sb.Append("  PaymentProvider: ").Append(PaymentProvider).Append("\n");
            sb.Append("  TransactionStatus: ").Append(TransactionStatus).Append("\n");
            sb.Append("  InstanceID: ").Append(InstanceID).Append("\n");
            sb.Append("  InstanceType: ").Append(InstanceType).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  CurrencyAmount: ").Append(CurrencyAmount).Append("\n");
            sb.Append("  CurrencyAmountUsd: ").Append(CurrencyAmountUsd).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
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
