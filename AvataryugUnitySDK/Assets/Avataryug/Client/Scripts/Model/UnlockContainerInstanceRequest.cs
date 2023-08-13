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
  public class UnlockContainerInstanceRequest {
    /// <summary>
    /// ItemInstanceId of the container to unlock.
    /// </summary>
    /// <value>ItemInstanceId of the container to unlock.</value>
    [DataMember(Name="ContainerInstanceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ContainerInstanceID")]
    public string ContainerInstanceID { get; set; }

    /// <summary>
    /// ItemInstanceId of the key that will be consumed by unlocking this container. If the container requires a key, this parameter is required.
    /// </summary>
    /// <value>ItemInstanceId of the key that will be consumed by unlocking this container. If the container requires a key, this parameter is required.</value>
    [DataMember(Name="KeyInstanceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "KeyInstanceID")]
    public string KeyInstanceID { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UnlockContainerInstanceRequest {\n");
      sb.Append("  ContainerInstanceID: ").Append(ContainerInstanceID).Append("\n");
      sb.Append("  KeyInstanceID: ").Append(KeyInstanceID).Append("\n");
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
