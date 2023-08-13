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
  public class LoginWithIOSDeviceIDRequest {
    /// <summary>
    /// Gets or Sets IOSDeviceID
    /// </summary>
    [DataMember(Name="IOSDeviceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "IOSDeviceID")]
    public string IOSDeviceID { get; set; }

    /// <summary>
    /// Gets or Sets CreateAccount
    /// </summary>
    [DataMember(Name="CreateAccount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CreateAccount")]
    public bool? CreateAccount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LoginWithIOSDeviceIDRequest {\n");
      sb.Append("  IOSDeviceID: ").Append(IOSDeviceID).Append("\n");
      sb.Append("  CreateAccount: ").Append(CreateAccount).Append("\n");
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
