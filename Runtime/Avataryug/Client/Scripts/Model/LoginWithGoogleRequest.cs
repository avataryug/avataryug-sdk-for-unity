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
  public class LoginWithGoogleRequest {
    /// <summary>
    /// Identifier provided by Google for this users Google ID
    /// </summary>
    /// <value>Identifier provided by Google for this users Google ID</value>
    [DataMember(Name="GoogleID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "GoogleID")]
    public string GoogleID { get; set; }

    /// <summary>
    /// OAuth 2.0 server authentication code obtained on the client by calling the getServerAuthCode() (https://developers.google.com/identity/sign-in/android/offline-access) Google client API.
    /// </summary>
    /// <value>OAuth 2.0 server authentication code obtained on the client by calling the getServerAuthCode() (https://developers.google.com/identity/sign-in/android/offline-access) Google client API.</value>
    [DataMember(Name="GoogleServerAuthCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "GoogleServerAuthCode")]
    public string GoogleServerAuthCode { get; set; }

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
      sb.Append("class LoginWithGoogleRequest {\n");
      sb.Append("  GoogleID: ").Append(GoogleID).Append("\n");
      sb.Append("  GoogleServerAuthCode: ").Append(GoogleServerAuthCode).Append("\n");
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
