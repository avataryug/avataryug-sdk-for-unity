using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LoginWithCustomIDRequest
    {
        /// <summary>
        /// pet status in the store
        /// </summary>
        /// <value>pet status in the store</value>
        [DataMember(Name = "CustomID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomID")]
        public string CustomID { get; set; }

        /// <summary>
        /// Gets or Sets CreateAccount
        /// </summary>
        [DataMember(Name = "CreateAccount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CreateAccount")]
        public bool? CreateAccount { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LoginWithCustomIDRequest {\n");
            sb.Append("  CustomID: ").Append(CustomID).Append("\n");
            sb.Append("  CreateAccount: ").Append(CreateAccount).Append("\n");
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
