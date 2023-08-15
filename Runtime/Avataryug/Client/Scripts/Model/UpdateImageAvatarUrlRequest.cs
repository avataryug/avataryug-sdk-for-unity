using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// This class holds request detail of UpdateImageAvatarUrl
    /// </summary>
    [DataContract]
    public class UpdateImageAvatarUrlRequest
    {
        /// <summary>
        /// Avatar Image Url for the user.
        /// </summary>
        /// <value>Avatar Image Url for the user.</value>
        [DataMember(Name = "ImageUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ImageUrl")]
        public string ImageUrl { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateImageAvatarUrlRequest {\n");
            sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
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
