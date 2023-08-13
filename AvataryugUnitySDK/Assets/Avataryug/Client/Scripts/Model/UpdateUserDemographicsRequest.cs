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
  public class UpdateUserDemographicsRequest {
    /// <summary>
    /// Gets or Sets Gender
    /// </summary>
    [DataMember(Name="Gender", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Gender")]
    public string Gender { get; set; }

    /// <summary>
    /// Gets or Sets AgeRange
    /// </summary>
    [DataMember(Name="AgeRange", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "AgeRange")]
    public string AgeRange { get; set; }

    /// <summary>
    /// Gets or Sets Race
    /// </summary>
    [DataMember(Name="Race", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Race")]
    public string Race { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateUserDemographicsRequest {\n");
      sb.Append("  Gender: ").Append(Gender).Append("\n");
      sb.Append("  AgeRange: ").Append(AgeRange).Append("\n");
      sb.Append("  Race: ").Append(Race).Append("\n");
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
