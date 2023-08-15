﻿using System;
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
    /// 
    [DataContract]
    public class LinkCustomIDRequest
    {
        /// <summary>
        /// If another user is already linked to the custom ID, unlink the other user and re-link.
        /// </summary>
        /// <value>If another user is already linked to the custom ID, unlink the other user and re-link.</value>
        [DataMember(Name = "ForceLink", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ForceLink")]
        public bool? ForceLink { get; set; }

        /// <summary>
        /// Custom unique identifier for the user, generated by the project.
        /// </summary>
        /// <value>Custom unique identifier for the user, generated by the project.</value>
        [DataMember(Name = "CustomID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomID")]
        public string CustomID { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LinkCustomIDRequest {\n");
            sb.Append("  CustomID: ").Append(CustomID).Append("\n");
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