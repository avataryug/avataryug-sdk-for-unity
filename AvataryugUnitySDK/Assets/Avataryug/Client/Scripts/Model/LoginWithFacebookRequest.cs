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
  public class LoginWithFacebookRequest {
    /// <summary>
    /// Identifier provided by Facebook for this users FacebookID.
    /// </summary>
    /// <value>Identifier provided by Facebook for this users FacebookID.</value>
    [DataMember(Name="FacebookID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "FacebookID")]
    public string FacebookID { get; set; }

    /// <summary>
    /// Unique identifier from Facebook for the user.
    /// </summary>
    /// <value>Unique identifier from Facebook for the user.</value>
    [DataMember(Name="FbAccessToken", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "FbAccessToken")]
    public string FbAccessToken { get; set; }

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
      sb.Append("class LoginWithFacebookRequest {\n");
      sb.Append("  FacebookID: ").Append(FacebookID).Append("\n");
      sb.Append("  FbAccessToken: ").Append(FbAccessToken).Append("\n");
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
