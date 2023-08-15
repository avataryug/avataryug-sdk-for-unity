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
  public class AddGenericServiceIDRequest {
    /// <summary>
    /// Generic service identifier to add to the player account.
    /// </summary>
    /// <value>Generic service identifier to add to the player account.</value>
    [DataMember(Name="GenericServiceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "GenericServiceID")]
    public string GenericServiceID { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddGenericServiceIDRequest {\n");
      sb.Append("  GenericServiceID: ").Append(GenericServiceID).Append("\n");
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
