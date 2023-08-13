using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class AvatarPresetDataClass
    {
        /// <summary>
        /// Get or set DisplayName
        /// </summary>
        [DataMember(Name = "DisplayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DisplayName")]
        public string DisplayName;

        /// <summary>
        /// Get or set Description
        /// </summary>
        [DataMember(Name = "Description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Description")]
        public string Description;

        /// <summary>
        /// Get or set VirtualCurrency
        /// </summary>
        [DataMember(Name = "VirtualCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "VirtualCurrency")]
        public string VirtualCurrency;

        /// <summary>
        /// Get or set RealCurrency
        /// </summary>
        [DataMember(Name = "RealCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "RealCurrency")]
        public int RealCurrency;

        /// <summary>
        /// Get or set CustomMetaData
        /// </summary>
        [DataMember(Name = "CustomMetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomMetaData")]
        public string CustomMetaData;

        /// <summary>
        /// Get or set Artifacts
        /// </summary>
        [DataMember(Name = "ItemThumbnailsUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemThumbnailsUrl")]
        public string ItemThumbnailsUrl;

        /// <summary>
        /// Get or set
        /// </summary>
        [DataMember(Name = "Artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Artifacts")]
        public string Artifacts;

        /// <summary>
        /// Get or set Metadata
        /// </summary>
        [DataMember(Name = "Metadata", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Metadata")]
        public string Metadata;

        /// <summary>
        /// Get or set Status
        /// </summary>
        [DataMember(Name = "Status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Status")]
        public int Status;

        /// <summary>
        /// Get or set ThumbUrl
        /// </summary>
        [DataMember(Name = "ThumbUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ThumbUrl")]
        public string ThumbUrl;

        /// <summary>
        /// Get or set Race
        /// </summary>
        [DataMember(Name = "Race", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Race")]
        public string Race;

        /// <summary>
        /// Get or set AgeRange
        /// </summary>
        [DataMember(Name = "AgeRange", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AgeRange")]
        public string AgeRange;

        /// <summary>
        /// Get or set ID
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID;

        /// <summary>
        /// Get or set Tags
        /// </summary>
        [DataMember(Name = "Tags", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Tags")]
        public string Tags;

        /// <summary>
        /// Get or set Gender
        /// </summary>
        [DataMember(Name = "Gender", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Gender")]
        public int Gender;

        /// <summary>
        /// Get or set BlendshapeKeys
        /// </summary>
        [DataMember(Name = "BlendshapeKeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BlendshapeKeys")]
        public List<BlendShapeValue> BlendshapeKeys = new List<BlendShapeValue>();

        /// <summary>
        /// Get or set Props
        /// </summary>
        [DataMember(Name = "Props", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Props")]
        public List<Prop> Props = new List<Prop>();

        /// <summary>
        /// Get or set Color
        /// </summary>
        [DataMember(Name = "Color", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Color")]
        public PropColors Color = new PropColors();


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AvatarPresetDataClass {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
            sb.Append("  RealCurrency: ").Append(RealCurrency).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  ItemThumbnailsUrl: ").Append(ItemThumbnailsUrl).Append("\n");
            sb.Append("  Artifacts: ").Append(Artifacts).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ThumbUrl: ").Append(ThumbUrl).Append("\n");
            sb.Append("  Race: ").Append(Race).Append("\n");
            sb.Append("  AgeRange: ").Append(AgeRange).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Gender: ").Append(Gender).Append("\n");
            sb.Append("  BlendshapeKeys: ").Append(BlendshapeKeys).Append("\n");
            sb.Append("  Props: ").Append(Props).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
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