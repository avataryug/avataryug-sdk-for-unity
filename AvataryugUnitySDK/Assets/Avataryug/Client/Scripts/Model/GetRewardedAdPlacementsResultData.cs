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
  public class GetRewardedAdPlacementsResultData {
    /// <summary>
    /// Gets or Sets PlacementName
    /// </summary>
    [DataMember(Name="PlacementName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "PlacementName")]
    public string PlacementName { get; set; }

    /// <summary>
    /// Gets or Sets AppId
    /// </summary>
    [DataMember(Name="AppId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AppId")]
    public string AppId { get; set; }

    /// <summary>
    /// Gets or Sets AdUnit
    /// </summary>
    [DataMember(Name="AdUnit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AdUnit")]
    public string AdUnit { get; set; }

    /// <summary>
    /// Gets or Sets Rewards
    /// </summary>
    [DataMember(Name="Rewards", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Rewards")]
    public string Rewards { get; set; }

    /// <summary>
    /// Gets or Sets Segments
    /// </summary>
    [DataMember(Name="Segments", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Segments")]
    public string Segments { get; set; }

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
      sb.Append("class GetRewardedAdPlacementsResultData {\n");
      sb.Append("  PlacementName: ").Append(PlacementName).Append("\n");
      sb.Append("  AppId: ").Append(AppId).Append("\n");
      sb.Append("  AdUnit: ").Append(AdUnit).Append("\n");
      sb.Append("  Rewards: ").Append(Rewards).Append("\n");
      sb.Append("  Segments: ").Append(Segments).Append("\n");
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
