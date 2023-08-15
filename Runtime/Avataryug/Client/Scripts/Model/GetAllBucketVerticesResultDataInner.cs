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
  public class GetAllBucketVerticesResultDataInner {
    /// <summary>
    /// Gets or Sets BucketName
    /// </summary>
    [DataMember(Name="BucketName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "BucketName")]
    public string BucketName { get; set; }

    /// <summary>
    /// Gets or Sets MainCatID
    /// </summary>
    [DataMember(Name="MainCatID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "MainCatID")]
    public string MainCatID { get; set; }

    /// <summary>
    /// Gets or Sets Platform
    /// </summary>
    [DataMember(Name="Platform", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Platform")]
    public string Platform { get; set; }

    /// <summary>
    /// Gets or Sets VertexArray
    /// </summary>
    [DataMember(Name="VertexArray", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "VertexArray")]
    public string VertexArray { get; set; }

    /// <summary>
    /// Gets or Sets Meta
    /// </summary>
    [DataMember(Name="Meta", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "Meta")]
    public string Meta { get; set; }

    /// <summary>
    /// Gets or Sets ID
    /// </summary>
    [DataMember(Name="ID", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ID")]
    public string ID { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetAllBucketVerticesResultDataInner {\n");
      sb.Append("  BucketName: ").Append(BucketName).Append("\n");
      sb.Append("  MainCatID: ").Append(MainCatID).Append("\n");
      sb.Append("  Platform: ").Append(Platform).Append("\n");
      sb.Append("  VertexArray: ").Append(VertexArray).Append("\n");
      sb.Append("  Meta: ").Append(Meta).Append("\n");
      sb.Append("  ID: ").Append(ID).Append("\n");
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
