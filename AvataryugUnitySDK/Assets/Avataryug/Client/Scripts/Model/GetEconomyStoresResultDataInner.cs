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
  public class GetEconomyStoresResultDataInner {
    /// <summary>
    /// Gets or Sets StoreID
    /// </summary>
    [DataMember(Name="StoreID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "StoreID")]
    public string StoreID { get; set; }

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
    /// Gets or Sets CustomMetaData
    /// </summary>
    [DataMember(Name="CustomMetaData", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CustomMetaData")]
    public string CustomMetaData { get; set; }

    /// <summary>
    /// Gets or Sets StoreContents
    /// </summary>
    [DataMember(Name="StoreContents", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "StoreContents")]
    public string StoreContents { get; set; }

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
      sb.Append("class GetEconomyStoresResultDataInner {\n");
      sb.Append("  StoreID: ").Append(StoreID).Append("\n");
      sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
      sb.Append("  StoreContents: ").Append(StoreContents).Append("\n");
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
