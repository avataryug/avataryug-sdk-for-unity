﻿using System;
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
  public class LinkAndroidDeviceIDRequest {
    /// <summary>
    /// If another user is already linked to the device, unlink the other user and re-link.
    /// </summary>
    /// <value>If another user is already linked to the device, unlink the other user and re-link.</value>
    [DataMember(Name="ForceLink", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ForceLink")]
    public bool? ForceLink { get; set; }

    /// <summary>
    /// Android device identifier for the user's device.
    /// </summary>
    /// <value>Android device identifier for the user's device.</value>
    [DataMember(Name="AndroidDeviceID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AndroidDeviceID")]
    public string AndroidDeviceID { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class LinkAndroidDeviceIDRequest {\n");
      sb.Append("  ForceLink: ").Append(ForceLink).Append("\n");
      sb.Append("  AndroidDeviceID: ").Append(AndroidDeviceID).Append("\n");
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
