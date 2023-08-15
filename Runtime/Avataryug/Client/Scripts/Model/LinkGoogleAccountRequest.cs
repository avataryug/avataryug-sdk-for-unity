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
  public class LinkGoogleAccountRequest {
    /// <summary>
    /// If another user is already linked to the account, unlink the other user and re-link. If the current user is already linked, link both accounts.
    /// </summary>
    /// <value>If another user is already linked to the account, unlink the other user and re-link. If the current user is already linked, link both accounts.</value>
    [DataMember(Name="ForceLink", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ForceLink")]
    public bool? ForceLink { get; set; }

    /// <summary>
    /// Google ID provided by Google.
    /// </summary>
    /// <value>Google ID provided by Google.</value>
    [DataMember(Name="GoogleID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "GoogleID")]
    public string GoogleID { get; set; }

    /// <summary>
    /// Server authentication code obtained on the client by calling getServerAuthCode() (https://developers.google.com/identity/sign-in/android/offline-access) from Google Play for the user.
    /// </summary>
    /// <value>Server authentication code obtained on the client by calling getServerAuthCode() (https://developers.google.com/identity/sign-in/android/offline-access) from Google Play for the user.</value>
    [DataMember(Name="GoogleServerAuthCode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "GoogleServerAuthCode")]
    public string GoogleServerAuthCode { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LinkGoogleAccountRequest {\n");
      sb.Append("  ForceLink: ").Append(ForceLink).Append("\n");
      sb.Append("  GoogleID: ").Append(GoogleID).Append("\n");
      sb.Append("  GoogleServerAuthCode: ").Append(GoogleServerAuthCode).Append("\n");
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
