﻿/*
 * Client
 *
 * Avataryug Client side API
 *
 * The version of the OpenAPI document: 1.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Text;


namespace Com.Avataryug.Model
{
    /// <summary>
    /// SyncAvatarsRequest
    /// </summary>
    [DataContract]
    public class SyncAvatarsRequest
    {

        /// <summary>
        /// Gets or Sets Platform
        /// </summary>
        [DataMember(Name = "Platform", EmitDefaultValue = false)]
        public string Platform { get; set; }

        /// <summary>
        /// Gets or Sets Mesh
        /// </summary>
        [DataMember(Name = "Mesh", EmitDefaultValue = true)]
        public bool Mesh { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name = "Image", EmitDefaultValue = true)]
        public bool Image { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SyncAvatarsRequest {\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
            sb.Append("  Mesh: ").Append(Mesh).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }

}
