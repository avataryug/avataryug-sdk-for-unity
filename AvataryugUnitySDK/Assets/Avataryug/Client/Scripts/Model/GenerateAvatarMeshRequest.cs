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
    public class GenerateAvatarMeshRequest
    {
        /// <summary>
        /// Gets or Sets ProjectData
        /// </summary>
        [DataMember(Name = "AvatarID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AvatarID")]
        public string AvatarID { get; set; }

        /// <summary>
        /// Gets or Sets MetaData
        /// </summary>
        [DataMember(Name = "Platform", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Platform")]
        public string Platform { get; set; }

        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GenerateAvatarMeshRequest {\n");
            sb.Append("  AvatarID: ").Append(AvatarID).Append("\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
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


    [System.Serializable]
    public class BuildAvatarMeshRequest
    {
        public string AvatarID;
        public string Platform;
        public string AvatarData;
    }

    [System.Serializable]
    public class BuildAvatarImageRequest
    {
        public string AvatarID;
        public string Platform;
        public string AvatarData;
    }



}
