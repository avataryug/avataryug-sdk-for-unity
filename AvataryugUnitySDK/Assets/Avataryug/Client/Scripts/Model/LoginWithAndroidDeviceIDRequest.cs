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
  public class LoginWithAndroidDeviceIDRequest {
    /// <summary>
    /// Android device identifier for the user's device.
    /// </summary>
    /// <value>Android device identifier for the user's device.</value>
    [DataMember(Name="AndroidDeviceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AndroidDeviceID")]
    public string AndroidDeviceID { get; set; }

    /// <summary>
    /// Automatically create a Avataryug account if one is not currently linked to this ID.
    /// </summary>
    /// <value>Automatically create a Avataryug account if one is not currently linked to this ID.</value>
    [DataMember(Name="CreateAccount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CreateAccount")]
    public bool? CreateAccount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LoginWithAndroidDeviceIDRequest {\n");
      sb.Append("  AndroidDeviceID: ").Append(AndroidDeviceID).Append("\n");
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
