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
  public class GetEconomyContainersResultInner {
    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="Status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Status")]
    public int? Status { get; set; }

    /// <summary>
    /// Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name="DisplayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "DisplayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or Sets ContainerCategory
    /// </summary>
    [DataMember(Name="ContainerCategory", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ContainerCategory")]
    public string ContainerCategory { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="Description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets Tags
    /// </summary>
    [DataMember(Name="Tags", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Tags")]
    public string Tags { get; set; }

    /// <summary>
    /// Gets or Sets ContainerImageUrl
    /// </summary>
    [DataMember(Name="ContainerImageUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ContainerImageUrl")]
    public string ContainerImageUrl { get; set; }

    /// <summary>
    /// Gets or Sets IsStackable
    /// </summary>
    [DataMember(Name="IsStackable", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "IsStackable")]
    public int? IsStackable { get; set; }

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
    /// Gets or Sets Entitlement
    /// </summary>
    [DataMember(Name="Entitlement", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Entitlement")]
    public string Entitlement { get; set; }

    /// <summary>
    /// Gets or Sets ContainerSettings
    /// </summary>
    [DataMember(Name="ContainerSettings", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ContainerSettings")]
    public string ContainerSettings { get; set; }

    /// <summary>
    /// Gets or Sets ContainerContents
    /// </summary>
    [DataMember(Name="ContainerContents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ContainerContents")]
    public string ContainerContents { get; set; }

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
    /// Gets or Sets CustomMetaData
    /// </summary>
    [DataMember(Name="CustomMetaData", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CustomMetaData")]
    public string CustomMetaData { get; set; }

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
      sb.Append("class GetEconomyContainersResultInner {\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
      sb.Append("  ContainerCategory: ").Append(ContainerCategory).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Tags: ").Append(Tags).Append("\n");
      sb.Append("  ContainerImageUrl: ").Append(ContainerImageUrl).Append("\n");
      sb.Append("  IsStackable: ").Append(IsStackable).Append("\n");
      sb.Append("  IsLimitedEdition: ").Append(IsLimitedEdition).Append("\n");
      sb.Append("  LimitedEditionIntialCount: ").Append(LimitedEditionIntialCount).Append("\n");
      sb.Append("  Entitlement: ").Append(Entitlement).Append("\n");
      sb.Append("  ContainerSettings: ").Append(ContainerSettings).Append("\n");
      sb.Append("  ContainerContents: ").Append(ContainerContents).Append("\n");
      sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
      sb.Append("  RealCurrency: ").Append(RealCurrency).Append("\n");
      sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
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
