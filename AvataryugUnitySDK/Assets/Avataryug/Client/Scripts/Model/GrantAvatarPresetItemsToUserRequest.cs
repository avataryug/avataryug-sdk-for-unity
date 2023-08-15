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
  public class GrantAvatarPresetItemsToUserRequest {
    /// <summary>
    /// Gets or Sets ItemIDs
    /// </summary>
    [DataMember(Name="ItemIDs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ItemIDs")]
    public List<GrantAvatarPresetItemsToUserRequestItemIDsInner> ItemIDs { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GrantAvatarPresetItemsToUserRequest {\n");
      sb.Append("  ItemIDs: ").Append(ItemIDs).Append("\n");
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