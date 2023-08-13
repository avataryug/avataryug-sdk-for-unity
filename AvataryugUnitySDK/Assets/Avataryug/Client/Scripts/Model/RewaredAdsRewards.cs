using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.Avataryug.Model
{

    /// <summary>
    /// This class holds metadata 
    /// </summary>
    [System.Serializable]
    public class MetaData
    {
        /// <summary>
        /// Gets or Sets item
        /// </summary>
        [DataMember(Name = "item", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "item")]
        public string item;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MetaData {\n");
            sb.Append("  item: ").Append(item).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }


    /// <summary>
    /// This class holds quantity and type of rewards
    /// </summary>
    [System.Serializable]
    public class ActionArray
    {

        /// <summary>
        /// Gets or Sets metaData
        /// </summary>
        [DataMember(Name = "metaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "metaData")]
        public MetaData metaData = new MetaData();

        /// <summary>
        /// Gets or Sets item
        /// </summary>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "quantity")]
        public string quantity;

        /// <summary>
        /// Gets or Sets type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public string type;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ActionArray {\n");
            sb.Append("  metaData: ").Append(metaData).Append("\n");
            sb.Append("  quantity: ").Append(quantity).Append("\n");
            sb.Append("  type: ").Append(type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }

    /// <summary>
    /// This class holds list of reward available for reward 
    /// </summary>
    [System.Serializable]
    public class RewaredAdsRewards
    {

        /// <summary>
        /// Gets or Sets rewards
        /// </summary>
        [DataMember(Name = "rewards", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "rewards")]
        public List<Rewards> rewards = new List<Rewards>();


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RewaredAdsRewards {\n");
            sb.Append("  rewards: ").Append(rewards).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }

    /// <summary>
    /// This class holds reward details
    /// </summary>
    [System.Serializable]
    public class Rewards
    {
        /// <summary>
        /// Gets or Sets Odds
        /// </summary>
        [DataMember(Name = "Odds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Odds")]
        public string Odds;

        /// <summary>
        /// Gets or Sets actionArray
        /// </summary>
        [DataMember(Name = "actionArray", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "actionArray")]
        public List<ActionArray> actionArray = new List<ActionArray>();

        /// <summary>
        /// Gets or Sets @checked
        /// </summary>
        [DataMember(Name = "@checked", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "@checked")]
        public bool @checked;

        /// <summary>
        /// Gets or Sets description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string description;

        /// <summary>
        /// Gets or Sets id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public int id;

        /// <summary>
        /// Gets or Sets name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string name;

        /// <summary>
        /// Gets or Sets rewardurl
        /// </summary>
        [DataMember(Name = "rewardurl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "rewardurl")]
        public object rewardurl;

        /// <summary>
        /// Gets or Sets selected
        /// </summary>
        [DataMember(Name = "selected", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "selected")]
        public bool selected;

        /// <summary>
        /// Gets or Sets value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "value")]
        public string value;
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Rewards {\n");
            sb.Append("  Odds: ").Append(Odds).Append("\n");
            sb.Append("  @checked: ").Append(@checked).Append("\n");
            sb.Append("  description: ").Append(description).Append("\n");
            sb.Append("  id: ").Append(id).Append("\n");
            sb.Append("  name: ").Append(name).Append("\n");
            sb.Append("  rewardurl: ").Append(rewardurl).Append("\n");
            sb.Append("  selected: ").Append(selected).Append("\n");
            sb.Append("  value: ").Append(value).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }

}

