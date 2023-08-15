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
  public class LinkFacebookAccountRequest {
    /// <summary>
    /// If another user is already linked to the account, unlink the other user and re-link.
    /// </summary>
    /// <value>If another user is already linked to the account, unlink the other user and re-link.</value>
    [DataMember(Name="ForceLink", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ForceLink")]
    public bool? ForceLink { get; set; }

    /// <summary>
    /// Unique identifier from Facebook for the user.
    /// </summary>
    /// <value>Unique identifier from Facebook for the user.</value>
    [DataMember(Name="AccessToken", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AccessToken")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Facebook ID provided by Facebook.
    /// </summary>
    /// <value>Facebook ID provided by Facebook.</value>
    [DataMember(Name="FacebookID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "FacebookID")]
    public string FacebookID { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LinkFacebookAccountRequest {\n");
      sb.Append("  ForceLink: ").Append(ForceLink).Append("\n");
      sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
      sb.Append("  FacebookID: ").Append(FacebookID).Append("\n");
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
