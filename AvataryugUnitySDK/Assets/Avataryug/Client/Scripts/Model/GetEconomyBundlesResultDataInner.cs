using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class GetEconomyBundlesResultDataInner {
    /// <summary>
    /// Gets or Sets BundleCategory
    /// </summary>
    [DataMember(Name="BundleCategory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "BundleCategory")]
    public string BundleCategory { get; set; }

    /// <summary>
    /// Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name="DisplayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "DisplayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="Description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets VirtualCurrency
    /// </summary>
    [DataMember(Name="VirtualCurrency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "VirtualCurrency")]
    public string VirtualCurrency { get; set; }

    /// <summary>
    /// Gets or Sets RealCurrency
    /// </summary>
    [DataMember(Name="RealCurrency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "RealCurrency")]
    public int? RealCurrency { get; set; }

    /// <summary>
    /// Gets or Sets Tags
    /// </summary>
    [DataMember(Name="Tags", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Tags")]
    public string Tags { get; set; }

    /// <summary>
    /// Gets or Sets Entitlement
    /// </summary>
    [DataMember(Name="Entitlement", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Entitlement")]
    public string Entitlement { get; set; }

    /// <summary>
    /// Gets or Sets IsStackable
    /// </summary>
    [DataMember(Name="IsStackable", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "IsStackable")]
    public int? IsStackable { get; set; }

    /// <summary>
    /// Gets or Sets BundleImageUrl
    /// </summary>
    [DataMember(Name="BundleImageUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "BundleImageUrl")]
    public string BundleImageUrl { get; set; }

    /// <summary>
    /// Gets or Sets IsLimitedEdition
    /// </summary>
    [DataMember(Name="IsLimitedEdition", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "IsLimitedEdition")]
    public int? IsLimitedEdition { get; set; }

    /// <summary>
    /// Gets or Sets LimitedEditionIntialCount
    /// </summary>
    [DataMember(Name="LimitedEditionIntialCount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "LimitedEditionIntialCount")]
    public int? LimitedEditionIntialCount { get; set; }

    /// <summary>
    /// Gets or Sets CustomMetaData
    /// </summary>
    [DataMember(Name="CustomMetaData", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CustomMetaData")]
    public string CustomMetaData { get; set; }

    /// <summary>
    /// Gets or Sets BundleContents
    /// </summary>
    [DataMember(Name="BundleContents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "BundleContents")]
    public string BundleContents { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="Status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Status")]
    public int? Status { get; set; }

    /// <summary>
    /// Gets or Sets ID
    /// </summary>
    [DataMember(Name="ID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ID")]
    public string ID { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetEconomyBundlesResultDataInner {\n");
      sb.Append("  BundleCategory: ").Append(BundleCategory).Append("\n");
      sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
      sb.Append("  RealCurrency: ").Append(RealCurrency).Append("\n");
      sb.Append("  Tags: ").Append(Tags).Append("\n");
      sb.Append("  Entitlement: ").Append(Entitlement).Append("\n");
      sb.Append("  IsStackable: ").Append(IsStackable).Append("\n");
      sb.Append("  BundleImageUrl: ").Append(BundleImageUrl).Append("\n");
      sb.Append("  IsLimitedEdition: ").Append(IsLimitedEdition).Append("\n");
      sb.Append("  LimitedEditionIntialCount: ").Append(LimitedEditionIntialCount).Append("\n");
      sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
      sb.Append("  BundleContents: ").Append(BundleContents).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  ID: ").Append(ID).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
    }

}
}
