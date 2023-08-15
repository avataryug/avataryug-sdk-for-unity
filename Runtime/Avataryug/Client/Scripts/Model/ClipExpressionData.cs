using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class ClipExpressionData
    {
        [DataMember(Name = "Style", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Style")]
        public Style Style = new Style();

        [DataMember(Name = "gender", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "gender")]
        public int gender;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ClipExpressionData {\n");
            sb.Append("  Style: ").Append(Style).Append("\n");
            sb.Append("  gender: ").Append(gender).Append("\n");
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


    [System.Serializable]
    public class Style
    {
        [DataMember(Name = "ClipID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ClipID")]
        public string ClipID;

        [DataMember(Name = "ExpressionID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ExpressionID")]
        public string ExpressionID;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Style {\n");
            sb.Append("  ClipID: ").Append(ClipID).Append("\n");
            sb.Append("  ExpressionID: ").Append(ExpressionID).Append("\n");
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