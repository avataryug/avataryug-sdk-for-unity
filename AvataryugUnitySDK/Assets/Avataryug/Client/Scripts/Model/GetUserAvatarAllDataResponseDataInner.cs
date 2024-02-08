using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GetUserAvatarAllDataResponseDataInner
    {


        /// <summary>
        /// Gets or Sets TemplateID
        /// </summary>
        [DataMember(Name = "TemplateID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "TemplateID")]
        public string TemplateID { get; set; }

        /// <summary>
        /// Gets or Sets ItemCategory
        /// </summary>
        [DataMember(Name = "ItemCategory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemCategory")]
        public string ItemCategory { get; set; }

        /// <summary>
        /// Gets or Sets Artifacts
        /// </summary>
        [DataMember(Name = "Artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Artifacts")]
        public string Artifacts { get; set; }


        /// <summary>
        /// Gets or Sets BlendshapeKeys
        /// </summary>
        [DataMember(Name = "BlendshapeKeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BlendshapeKeys")]
        public string BlendshapeKeys { get; set; }

        /// <summary>
        /// Gets or Sets ItemSkin
        /// </summary>
        [DataMember(Name = "ItemSkin", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemSkin")]
        public string ItemSkin { get; set; }

        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }

        /// <summary>
        /// Gets or Sets Config
        /// </summary>
        [DataMember(Name = "Config", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Config")]
        public string Config { get; set; }


        /// <summary>
        /// Gets or Sets CoreBucket
        /// </summary>
        [DataMember(Name = "CoreBucket", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CoreBucket")]
        public string CoreBucket { get; set; }

        /// <summary>
        /// Gets or Sets ConflictingBuckets
        /// </summary>
        [DataMember(Name = "ConflictingBuckets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ConflictingBuckets")]
        public string ConflictingBuckets { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUserAvatarAllDataResponseDataInner {\n");
            sb.Append("  TemplateID: ").Append(TemplateID).Append("\n");
            sb.Append("  ItemCategory: ").Append(ItemCategory).Append("\n");
            sb.Append("  Artifacts: ").Append(Artifacts).Append("\n");
            sb.Append("  BlendshapeKeys: ").Append(BlendshapeKeys).Append("\n");
            sb.Append("  ItemSkin: ").Append(ItemSkin).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  Config: ").Append(Config).Append("\n");
            sb.Append("  CoreBucket: ").Append(CoreBucket).Append("\n");
            sb.Append("  ConflictingBuckets: ").Append(ConflictingBuckets).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }
}
