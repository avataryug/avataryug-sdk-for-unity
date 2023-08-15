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
  public class RecordAdsActivityResponseData {
    /// <summary>
    /// Gets or Sets Owner
    /// </summary>
    [DataMember(Name="Owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Owner")]
    public string Owner { get; set; }

    /// <summary>
    /// Gets or Sets RevenueCurrency
    /// </summary>
    [DataMember(Name="RevenueCurrency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "RevenueCurrency")]
    public string RevenueCurrency { get; set; }

    /// <summary>
    /// Gets or Sets AdRevenue
    /// </summary>
    [DataMember(Name="AdRevenue", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AdRevenue")]
    public string AdRevenue { get; set; }

    /// <summary>
    /// Gets or Sets PlacementID
    /// </summary>
    [DataMember(Name="PlacementID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "PlacementID")]
    public string PlacementID { get; set; }

    /// <summary>
    /// Gets or Sets UpdatedAt
    /// </summary>
    [DataMember(Name="UpdatedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "UpdatedAt")]
    public string UpdatedAt { get; set; }

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
      sb.Append("class RecordAdsActivityResponseData {\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
      sb.Append("  RevenueCurrency: ").Append(RevenueCurrency).Append("\n");
      sb.Append("  AdRevenue: ").Append(AdRevenue).Append("\n");
      sb.Append("  PlacementID: ").Append(PlacementID).Append("\n");
      sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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
