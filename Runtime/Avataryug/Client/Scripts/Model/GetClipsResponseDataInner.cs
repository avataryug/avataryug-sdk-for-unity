using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class ThumbnailUrl
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
        [DataMember(Name = "texture", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "texture")]
        public int texture;

        /// <summary>
        /// Gets or Sets thumbnail_url
        /// </summary>
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
            sb.Append("class ThumbnailUrl {\n");
            sb.Append("  device: ").Append(device).Append("\n");
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
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }

    [System.Serializable]
    public class Artifact
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
        /// Gets or Sets url
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
            sb.Append("class Artifact {\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  format: ").Append(format).Append("\n");
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
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GetClipsResponseDataInner
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
        public List<ThumbnailUrl> ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or Sets Artifacts
        /// </summary>
        [DataMember(Name = "Artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Artifacts")]
        public List<Artifact> Artifacts { get; set; }

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
        /// Gets or Sets ClipType
        /// </summary>
        [DataMember(Name = "ClipType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ClipType")]
        public int? ClipType { get; set; }

        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }

        [DataMember(Name = "ClipTemplateID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ClipTemplateID")]
        public string ClipTemplateID { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetClipsResponseDataInner {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  ThumbnailUrl: ").Append(ThumbnailUrl).Append("\n");
            sb.Append("  Artifacts: ").Append(Artifacts).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ClipType: ").Append(ClipType).Append("\n");
            sb.Append("  ClipTemplateID: ").Append(ClipTemplateID).Append("\n");
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
