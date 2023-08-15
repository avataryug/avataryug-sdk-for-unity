using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class RenderAvatarImageResponseData
    {
        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "Platform", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Platform")]
        public string Platform { get; set; }

        /// <summary>
        /// Gets or Sets ThumbnailUrl
        /// </summary>
        [DataMember(Name = "ImageURL", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ImageURL")]
        public string ImageURL { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RenderAvatarImageResponseData {\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
            sb.Append("  ImageURL: ").Append(ImageURL).Append("\n");
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
