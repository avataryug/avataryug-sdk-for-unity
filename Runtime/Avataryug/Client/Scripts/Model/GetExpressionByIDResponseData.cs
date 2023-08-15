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
    public class GetExpressionByIDResponseData
    {
        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        [DataMember(Name = "DisplayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DisplayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "Description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name = "Category", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets CustomMetaData
        /// </summary>
        [DataMember(Name = "CustomMetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomMetaData")]
        public string CustomMetaData { get; set; }

        /// <summary>
        /// Gets or Sets ThumbnailsUrl
        /// </summary>
        [DataMember(Name = "ThumbnailUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ThumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or Sets BlendshapeKeys
        /// </summary>
        [DataMember(Name = "BlendshapeKeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BlendshapeKeys")]
        public string BlendshapeKeys { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "Tags", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Gets or Sets Color
        /// </summary>
        [DataMember(Name = "Color", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Color")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name = "Metadata", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Metadata")]
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "Status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Status")]
        public int? Status { get; set; }

        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetExpressionByIDResponseData {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  ThumbnailUrl: ").Append(ThumbnailUrl).Append("\n");
            sb.Append("  BlendshapeKeys: ").Append(BlendshapeKeys).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
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
