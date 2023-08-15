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
  public class ChangePasswordRequest {
    /// <summary>
    /// Gets or Sets OldPassword
    /// </summary>
    [DataMember(Name="OldPassword", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "OldPassword")]
    public string OldPassword { get; set; }

    /// <summary>
    /// Gets or Sets NewPassword
    /// </summary>
    [DataMember(Name="NewPassword", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "NewPassword")]
    public string NewPassword { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ChangePasswordRequest {\n");
      sb.Append("  OldPassword: ").Append(OldPassword).Append("\n");
      sb.Append("  NewPassword: ").Append(NewPassword).Append("\n");
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
