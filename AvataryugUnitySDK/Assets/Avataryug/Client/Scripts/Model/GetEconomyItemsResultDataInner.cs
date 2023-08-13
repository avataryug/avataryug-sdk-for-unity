using System;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GetEconomyItemsResultDataInner
    {
        /// <summary>
        /// Gets or Sets TemplateID
        /// </summary>
        [DataMember(Name = "TemplateID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "TemplateID")]
        public string TemplateID { get; set; }

        /// <summary>
        /// Gets or Sets ItemGender
        /// </summary>
        [DataMember(Name = "ItemGender", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemGender")]
        public int? ItemGender { get; set; }

        /// <summary>
        /// Gets or Sets ItemCategory
        /// </summary>
        [DataMember(Name = "ItemCategory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemCategory")]
        public string ItemCategory { get; set; }

        /// <summary>
        /// Gets or Sets ItemSubCategory
        /// </summary>
        [DataMember(Name = "ItemSubCategory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemSubCategory")]
        public string ItemSubCategory { get; set; }

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
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "Tags", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Gets or Sets Entitlement
        /// </summary>
        [DataMember(Name = "Entitlement", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Entitlement")]
        public string Entitlement { get; set; }

        /// <summary>
        /// Gets or Sets IsStackable
        /// </summary>
        [DataMember(Name = "IsStackable", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "IsStackable")]
        public int? IsStackable { get; set; }

        /// <summary>
        /// Gets or Sets IsLimitedEdition
        /// </summary>
        [DataMember(Name = "IsLimitedEdition", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "IsLimitedEdition")]
        public int? IsLimitedEdition { get; set; }

        /// <summary>
        /// Gets or Sets LimitedEditionIntialCount
        /// </summary>
        [DataMember(Name = "LimitedEditionIntialCount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "LimitedEditionIntialCount")]
        public int? LimitedEditionIntialCount { get; set; }

        /// <summary>
        /// Gets or Sets CustomMetaData
        /// </summary>
        [DataMember(Name = "CustomMetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomMetaData")]
        public string CustomMetaData { get; set; }

        /// <summary>
        /// Gets or Sets Style
        /// </summary>
        [DataMember(Name = "Style", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Style")]
        public string Style { get; set; }

        /// <summary>
        /// Gets or Sets ItemThumbnailsUrl
        /// </summary>
        [DataMember(Name = "ItemThumbnailsUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemThumbnailsUrl")]
        public string ItemThumbnailsUrl { get; set; }

        /// <summary>
        /// Gets or Sets Artifacts
        /// </summary>
        [DataMember(Name = "Artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Artifacts")]
        public string Artifacts { get; set; }

        /// <summary>
        /// Gets or Sets BlendshapeKeys
        /// </summary>
        [DataMember(Name = "BlendshapeKeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BlendshapeKeys")]
        public string BlendshapeKeys { get; set; }

        /// <summary>
        /// Gets or Sets ItemSkin
        /// </summary>
        [DataMember(Name = "ItemSkin", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemSkin")]
        public string ItemSkin { get; set; }

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
        /// Gets or Sets Config
        /// </summary>
        [DataMember(Name = "Config", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Config")]
        public string Config { get; set; }

        /// <summary>
        /// Gets or Sets CoreBucket
        /// </summary>
        [DataMember(Name = "CoreBucket", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CoreBucket")]
        public string CoreBucket { get; set; }

        /// <summary>
        /// Gets or Sets ConflictingBuckets
        /// </summary>
        [DataMember(Name = "ConflictingBuckets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ConflictingBuckets")]
        public string ConflictingBuckets { get; set; }

        /// <summary>
        /// Gets or Sets OccupiedBuckets
        /// </summary>
        [DataMember(Name = "OccupiedBuckets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "OccupiedBuckets")]
        public string OccupiedBuckets { get; set; }

        /// <summary>
        /// Gets or Sets Blendshapes
        /// </summary>
        [DataMember(Name = "Blendshapes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Blendshapes")]
        public string Blendshapes { get; set; }

        /// <summary>
        /// Gets or Sets MeshData
        /// </summary>
        [DataMember(Name = "MeshData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "MeshData")]
        public string MeshData { get; set; }

        /// <summary>
        /// Gets or Sets BonesPhysics
        /// </summary>
        [DataMember(Name = "BonesPhysics", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BonesPhysics")]
        public string BonesPhysics { get; set; }

        /// <summary>
        /// Gets or Sets BoneAdjustments
        /// </summary>
        [DataMember(Name = "BoneAdjustments", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BoneAdjustments")]
        public string BoneAdjustments { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetEconomyItemsResultDataInner {\n");
            sb.Append("  TemplateID: ").Append(TemplateID).Append("\n");
            sb.Append("  ItemGender: ").Append(ItemGender).Append("\n");
            sb.Append("  ItemCategory: ").Append(ItemCategory).Append("\n");
            sb.Append("  ItemSubCategory: ").Append(ItemSubCategory).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
            sb.Append("  RealCurrency: ").Append(RealCurrency).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Entitlement: ").Append(Entitlement).Append("\n");
            sb.Append("  IsStackable: ").Append(IsStackable).Append("\n");
            sb.Append("  IsLimitedEdition: ").Append(IsLimitedEdition).Append("\n");
            sb.Append("  LimitedEditionIntialCount: ").Append(LimitedEditionIntialCount).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  Style: ").Append(Style).Append("\n");
            sb.Append("  ItemThumbnailsUrl: ").Append(ItemThumbnailsUrl).Append("\n");
            sb.Append("  Artifacts: ").Append(Artifacts).Append("\n");
            sb.Append("  BlendshapeKeys: ").Append(BlendshapeKeys).Append("\n");
            sb.Append("  ItemSkin: ").Append(ItemSkin).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  Config: ").Append(Config).Append("\n");
            sb.Append("  CoreBucket: ").Append(CoreBucket).Append("\n");
            sb.Append("  ConflictingBuckets: ").Append(ConflictingBuckets).Append("\n");
            sb.Append("  OccupiedBuckets: ").Append(OccupiedBuckets).Append("\n");
            sb.Append("  Blendshapes: ").Append(Blendshapes).Append("\n");
            sb.Append("  MeshData: ").Append(MeshData).Append("\n");
            sb.Append("  BonesPhysics: ").Append(BonesPhysics).Append("\n");
            sb.Append("  BoneAdjustments: ").Append(BoneAdjustments).Append("\n");
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
