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
  public class GetUserInventoryResultDataInner {
    /// <summary>
    /// Gets or Sets UserID
    /// </summary>
    [DataMember(Name="UserID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "UserID")]
    public string UserID { get; set; }

    /// <summary>
    /// Gets or Sets InstanceID
    /// </summary>
    [DataMember(Name="InstanceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "InstanceID")]
    public string InstanceID { get; set; }

    /// <summary>
    /// Gets or Sets InstanceType
    /// </summary>
    [DataMember(Name="InstanceType", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "InstanceType")]
    public string InstanceType { get; set; }

    /// <summary>
    /// Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name="DisplayName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "DisplayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or Sets Expires
    /// </summary>
    [DataMember(Name="Expires", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Expires")]
    public string Expires { get; set; }

    /// <summary>
    /// Gets or Sets Count
    /// </summary>
    [DataMember(Name="Count", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Count")]
    public int? Count { get; set; }

    /// <summary>
    /// Gets or Sets Status
    /// </summary>
    [DataMember(Name="Status", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Status")]
    public int? Status { get; set; }

    /// <summary>
    /// Gets or Sets Content
    /// </summary>
    [DataMember(Name="Content", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Content")]
    public string Content { get; set; }

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
      sb.Append("class GetUserInventoryResultDataInner {\n");
      sb.Append("  UserID: ").Append(UserID).Append("\n");
      sb.Append("  InstanceID: ").Append(InstanceID).Append("\n");
      sb.Append("  InstanceType: ").Append(InstanceType).Append("\n");
      sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
      sb.Append("  Expires: ").Append(Expires).Append("\n");
      sb.Append("  Count: ").Append(Count).Append("\n");
      sb.Append("  Status: ").Append(Status).Append("\n");
      sb.Append("  Content: ").Append(Content).Append("\n");
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
