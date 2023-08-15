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
    public class GetAvatarPresetByID200Data
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
        /// Gets or Sets VirtualCurrency
        /// </summary>
        [DataMember(Name = "VirtualCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "VirtualCurrency")]
        public string VirtualCurrency { get; set; }

        /// <summary>
        /// Gets or Sets RealCurrency
        /// </summary>
        [DataMember(Name = "RealCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "RealCurrency")]
        public int? RealCurrency { get; set; }

        /// <summary>
        /// Gets or Sets CustomMetaData
        /// </summary>
        [DataMember(Name = "CustomMetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomMetaData")]
        public string CustomMetaData { get; set; }

        /// <summary>
        /// Gets or Sets ItemThumbnailsUrl
        /// </summary>
        [DataMember(Name = "ImageArtifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ImageArtifacts")]
        public string ImageArtifacts { get; set; }

        /// <summary>
        /// Gets or Sets Artifacts
        /// </summary>
        [DataMember(Name = "MeshArtifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "MeshArtifacts")]
        public string MeshArtifacts { get; set; }

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
        /// Gets or Sets Props
        /// </summary>
        [DataMember(Name = "Props", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Props")]
        public string Props { get; set; }

        /// <summary>
        /// Gets or Sets Gender
        /// </summary>
        [DataMember(Name = "Gender", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Gender")]
        public int? Gender { get; set; }

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
        /// Gets or Sets ThumbUrl
        /// </summary>
        //[DataMember(Name="ThumbUrl", EmitDefaultValue=false)]
        //[JsonProperty(PropertyName = "ThumbUrl")]
        //public string ThumbUrl { get; set; }

        /// <summary>
        /// Gets or Sets Race
        /// </summary>
        [DataMember(Name = "Race", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Race")]
        public string Race { get; set; }

        /// <summary>
        /// Gets or Sets AgeRange
        /// </summary>
        [DataMember(Name = "AgeRange", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AgeRange")]
        public string AgeRange { get; set; }

        /// <summary>
        /// Gets or Sets UserID
        /// </summary>
        [DataMember(Name = "UserID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "UserID")]
        public string UserID { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetAvatarPresetByID200Data {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
            sb.Append("  RealCurrency: ").Append(RealCurrency).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  ImageArtifacts: ").Append(ImageArtifacts).Append("\n");
            sb.Append("  MeshArtifacts: ").Append(MeshArtifacts).Append("\n");
            sb.Append("  BlendshapeKeys: ").Append(BlendshapeKeys).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Props: ").Append(Props).Append("\n");
            sb.Append("  Gender: ").Append(Gender).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            //sb.Append("  ThumbUrl: ").Append(ThumbUrl).Append("\n");
            sb.Append("  Race: ").Append(Race).Append("\n");
            sb.Append("  AgeRange: ").Append(AgeRange).Append("\n");
            sb.Append("  UserID: ").Append(UserID).Append("\n");
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
