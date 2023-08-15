using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace Com.Avataryug.Model
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class TwoDArtifacts
    {
        /// <summary>
        /// Gets or Sets artifacts
        /// </summary>
        [DataMember(Name = "artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "artifacts")]
        public List<TwoDArtifact> artifacts = new List<TwoDArtifact>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TwoDArtifacts {\n");
            sb.Append("  artifacts: ").Append(artifacts).Append("\n");
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

