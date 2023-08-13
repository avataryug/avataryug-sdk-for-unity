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
  public class Model201LoginWithCustomIDDataLinkedAccountsInner {
    /// <summary>
    /// Gets or Sets Platform
    /// </summary>
    [DataMember(Name="Platform", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Platform")]
    public string Platform { get; set; }

    /// <summary>
    /// Gets or Sets PlatformUserID
    /// </summary>
    [DataMember(Name="PlatformUserID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "PlatformUserID")]
    public string PlatformUserID { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Model201LoginWithCustomIDDataLinkedAccountsInner {\n");
      sb.Append("  Platform: ").Append(Platform).Append("\n");
      sb.Append("  PlatformUserID: ").Append(PlatformUserID).Append("\n");
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
