using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class ContainerBase
    {
        /// <summary>
        /// Get or set Code
        /// </summary>
        [DataMember(Name = "Code", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Code")]
        public string Code;

        /// <summary>
        /// Get or set Quantity
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Quantity")]
        public string Quantity;

        /// <summary>
        /// Get or set UserID
        /// </summary>
        [DataMember(Name = "UserID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "UserID")]
        public string UserID;

        /// <summary>
        /// Get or set containerType
        /// </summary>
        [DataMember(Name = "containerType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "containerType")]
        public string containerType;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContainerBase {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  UserID: ").Append(UserID).Append("\n");
            sb.Append("  containerType: ").Append(containerType).Append("\n");
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