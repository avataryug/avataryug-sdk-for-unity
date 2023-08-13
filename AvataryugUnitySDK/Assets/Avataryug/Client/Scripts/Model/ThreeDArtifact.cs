using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class ThreeDArtifact
    {
        /// <summary>
        /// Gets or Sets device
        /// </summary>
        [DataMember(Name = "device", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "device")]
        public int device;
        /// <summary>
        /// Gets or Sets format
        /// </summary>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "format")]
        public int format;
        /// <summary>
        /// Gets or Sets lod
        /// </summary>
        [DataMember(Name = "lod", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lod")]
        public int lod;
        /// <summary>
        /// Gets or Sets mesh_url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "url")]
        public string url;

        /// <summary>
        /// Gets or Sets normals
        /// </summary>
        [DataMember(Name = "normals", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "normals")]
        public int normals;
        /// <summary>
        /// Gets or Sets texture size
        /// </summary>
        [DataMember(Name = "texture_size", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "texture_size")]
        public int texture_size;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ThreeDArtifact {\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  format: ").Append(format).Append("\n");
            sb.Append("  lod: ").Append(lod).Append("\n");
            sb.Append("  url: ").Append(url).Append("\n");
            sb.Append("  normals: ").Append(normals).Append("\n");
            sb.Append("  texture_size: ").Append(texture_size).Append("\n");
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
