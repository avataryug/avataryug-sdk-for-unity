using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class ContainerBundleContents
    {
        /// <summary>
        /// Get or set Bundles
        /// </summary>
        [DataMember(Name = "Bundles", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Bundles")]
        public List<ContainerBase> Bundles = new List<ContainerBase>();

        /// <summary>
        /// Get or set Container
        /// </summary>
        [DataMember(Name = "Container", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Container")]
        public List<ContainerBase> Container = new List<ContainerBase>();

        /// <summary>
        /// Get or set Currencies
        /// </summary>
        [DataMember(Name = "Currencies", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Currencies")]
        public List<ContainerBase> Currencies = new List<ContainerBase>();

        /// <summary>
        /// Get or set Droptable
        /// </summary>
        [DataMember(Name = "Droptable", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Droptable")]
        public List<ContainerBase> Droptable = new List<ContainerBase>();

        /// <summary>
        /// Get or set Items
        /// </summary>
        [DataMember(Name = "Items", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Items")]
        public List<ContainerBase> Items = new List<ContainerBase>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContainerBundleContents {\n");
            sb.Append("  Bundles: ").Append(Bundles).Append("\n");
            sb.Append("  Container: ").Append(Container).Append("\n");
            sb.Append("  Currencies: ").Append(Currencies).Append("\n");
            sb.Append("  Droptable: ").Append(Droptable).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }


        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}