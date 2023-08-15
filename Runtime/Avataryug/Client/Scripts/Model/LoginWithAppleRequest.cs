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
  public class LoginWithAppleRequest {
    /// <summary>
    /// Identifier provided by Apple for this users AppleID.
    /// </summary>
    /// <value>Identifier provided by Apple for this users AppleID.</value>
    [DataMember(Name="AppleID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AppleID")]
    public string AppleID { get; set; }

    /// <summary>
    /// Automatically create a Avataryug account if one is not currently linked to this ID.
    /// </summary>
    /// <value>Automatically create a Avataryug account if one is not currently linked to this ID.</value>
    [DataMember(Name="CreateAccount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "CreateAccount")]
    public bool? CreateAccount { get; set; }

    /// <summary>
    /// The JSON Web token (JWT) returned by Apple after login. Represented as the identityToken field in the authorization credential payload.
    /// </summary>
    /// <value>The JSON Web token (JWT) returned by Apple after login. Represented as the identityToken field in the authorization credential payload.</value>
    [DataMember(Name="AppleIdentityToken", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AppleIdentityToken")]
    public string AppleIdentityToken { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LoginWithAppleRequest {\n");
      sb.Append("  AppleID: ").Append(AppleID).Append("\n");
      sb.Append("  CreateAccount: ").Append(CreateAccount).Append("\n");
      sb.Append("  AppleIdentityToken: ").Append(AppleIdentityToken).Append("\n");
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
