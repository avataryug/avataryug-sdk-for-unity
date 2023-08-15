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
    public class ConflictList
    {
        /// <summary>
        /// Gets or Sets Conflicts
        /// </summary>
        [DataMember(Name = "Conflicts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Conflicts")]
        public List<Conflict> Conflicts = new List<Conflict>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConflictList {\n");
            sb.Append("  Conflicts: ").Append(Conflicts).Append("\n");
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
