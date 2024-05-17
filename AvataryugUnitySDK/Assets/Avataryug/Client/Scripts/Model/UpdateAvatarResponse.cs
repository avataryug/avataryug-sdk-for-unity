using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    /// <summary>
    /// SyncAvatarsResult
    /// </summary>
    [DataContract]
    public class UpdateAvatarResponse
    {
        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name = "Code", EmitDefaultValue = false)]
        public int Code { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "Status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "Data", EmitDefaultValue = false)]
        public string Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SyncAvatarsResult {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented);
        }

    }

}
