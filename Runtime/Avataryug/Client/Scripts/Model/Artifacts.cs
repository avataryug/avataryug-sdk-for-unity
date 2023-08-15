using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    /// <summary>
    /// This class Holds all platfrom artifcate detail with 3d model url
    /// </summary>
    [System.Serializable]
    public class AvatarPresetArtifacts
    {
        /// <summary>
        /// Get or set artifacts
        /// </summary>
        [DataMember(Name = "artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "artifacts")]
        public List<AvatarPresetArtifact> artifacts = new List<AvatarPresetArtifact>();

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
    public class AvatarPresetArtifact
    {
        /// <summary>
        /// Get or set device
        /// </summary>
        [DataMember(Name = "device", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "device")]
        public int device;


        /// <summary>
        /// Get or set format
        /// </summary>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "format")]
        public int format;


        /// <summary>
        /// Get or set lod
        /// </summary>
        [DataMember(Name = "lod", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lod")]
        public int lod;


        /// <summary>
        /// Get or set normals
        /// </summary>
        [DataMember(Name = "normals", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "normals")]
        public int normals;


        /// <summary>
        /// Get or set texture_size
        /// </summary>
        [DataMember(Name = "texture", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "texture")]
        public int texture;

        /// <summary>
        /// Get or set mesh_url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "url")]
        public string url;



        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AvatarPresetArtifact {\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  format: ").Append(format).Append("\n");
            sb.Append("  texture: ").Append(texture).Append("\n");
            sb.Append("  lod: ").Append(lod).Append("\n");
            sb.Append("  normals: ").Append(normals).Append("\n");
            sb.Append("  url: ").Append(url).Append("\n");
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