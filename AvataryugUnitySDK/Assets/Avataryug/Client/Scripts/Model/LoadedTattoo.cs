using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine;

namespace Com.Avataryug.Model
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class LoadedTattoo
    {
        /// <summary>
        /// Gets or Sets ItemCategory
        /// </summary>
        [DataMember(Name = "ItemCategory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemCategory")]
        public string ItemCategory;
        /// <summary>
        /// Gets or Sets tattooTex
        /// </summary>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "format")]
        public Texture2D tattooTex;
        /// <summary>
        /// Gets or Sets tattooid
        /// </summary>
        [DataMember(Name = "tattooid", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tattooid")]
        public string tattooid;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LoadedTattoo {\n");
            sb.Append("  ItemCategory: ").Append(ItemCategory).Append("\n");
            sb.Append("  tattooTex: ").Append(tattooTex).Append("\n");
            sb.Append("  tattooid: ").Append(tattooid).Append("\n");
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
