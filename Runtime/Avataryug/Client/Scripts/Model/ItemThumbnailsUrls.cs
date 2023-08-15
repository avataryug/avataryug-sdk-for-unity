using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;


namespace Com.Avataryug.Model
{
    /// <summary>
    /// This class container prop thumbnail url of all platform
    /// </summary>
    [System.Serializable]
    public class ItemThumbnailsUrls
    {
        //Get or set itemThumbnails
        [DataMember(Name = "itemThumbnails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "itemThumbnails")]
        public List<ItemThumbnailsUrl> itemThumbnails = new List<ItemThumbnailsUrl>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemThumbnailsUrl {\n");
            sb.Append("  itemThumbnails: ").Append(itemThumbnails).Append("\n");
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
    public class ItemThumbnailsUrl
    {
        [DataMember(Name = "device", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "device")]
        public float device;

        [DataMember(Name = "quality", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "quality")]
        public float quality;

        [DataMember(Name = "texture", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "texture")]
        public string texture;

        [DataMember(Name = "thumbnail_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "thumbnail_url")]
        public string thumbnail_url;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemThumbnailsUrl {\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  quality: ").Append(quality).Append("\n");
            sb.Append("  texture: ").Append(texture).Append("\n");
            sb.Append("  thumbnail_url: ").Append(thumbnail_url).Append("\n");
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