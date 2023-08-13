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
    public class LinkAppleRequest
    {
        /// <summary>
        /// If another user is already linked to a specific Apple account, unlink the other user and re-link.
        /// </summary>
        /// <value>If another user is already linked to a specific Apple account, unlink the other user and re-link.</value>
        [DataMember(Name = "ForceLink", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ForceLink")]
        public bool? ForceLink { get; set; }

        /// <summary>
        /// Apple ID provided by Apple.
        /// </summary>
        /// <value>Apple ID provided by Apple.</value>
        [DataMember(Name = "AppleID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AppleID")]
        public string AppleID { get; set; }

        /// <summary>
        /// The JSON Web token (JWT) returned by Apple after login. Represented as the identityToken field in the authorization credential payload. Used to validate the request and find the user ID (Apple subject) to link with.
        /// </summary>
        /// <value>The JSON Web token (JWT) returned by Apple after login. Represented as the identityToken field in the authorization credential payload. Used to validate the request and find the user ID (Apple subject) to link with.</value>
        [DataMember(Name = "IdentityToken", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "IdentityToken")]
        public string IdentityToken { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LinkAppleRequest {\n");
            sb.Append("  ForceLink: ").Append(ForceLink).Append("\n");
            sb.Append("  AppleID: ").Append(AppleID).Append("\n");
            sb.Append("  IdentityToken: ").Append(IdentityToken).Append("\n");
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
