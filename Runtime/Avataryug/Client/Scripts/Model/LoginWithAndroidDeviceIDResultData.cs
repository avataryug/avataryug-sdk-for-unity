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
  public class LoginWithAndroidDeviceIDResultData {
    /// <summary>
    /// Gets or Sets AccessToken
    /// </summary>
    [DataMember(Name="AccessToken", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AccessToken")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Gets or Sets User
    /// </summary>
    [DataMember(Name="User", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "User")]
    public Model201LoginWithCustomIDDataUser User { get; set; }

    /// <summary>
    /// Gets or Sets LinkedAccounts
    /// </summary>
    [DataMember(Name="LinkedAccounts", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "LinkedAccounts")]
    public string LinkedAccounts { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LoginWithAndroidDeviceIDResultData {\n");
      sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
      sb.Append("  User: ").Append(User).Append("\n");
      sb.Append("  LinkedAccounts: ").Append(LinkedAccounts).Append("\n");
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
