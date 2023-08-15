using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{
    [DataContract]
    public class GetAdPlacementByIDResultDataRewardsInnerActionArrayInnerMetaData
    {
        [DataMember(Name = "InstanceID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "InstanceID")]
        public string InstanceID { get; set; }

        /// <summary>
        /// Gets or Sets InstanceType
        /// </summary>
        [DataMember(Name = "InstanceType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "InstanceType")]
        public string InstanceType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("  InstanceID: ").Append(InstanceID).Append("\n");
            sb.Append("  InstanceType: ").Append(InstanceType).Append("\n");
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
    [DataContract]
    public class GetAdPlacementByIDResultDataRewardsInnerActionArrayInner
    {
        /// <summary>
        /// Gets or Sets MetaData
        /// </summary>
        [DataMember(Name = "MetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "MetaData")]
        public GetAdPlacementByIDResultDataRewardsInnerActionArrayInnerMetaData MetaData { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name = "Quantity", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "Type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("  MetaData: ").Append(MetaData).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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

    [DataContract]
    public class GetAdPlacementByIDResultDataRewardsInner
    {
        /// <summary>
        /// Gets or Sets ActionArray
        /// </summary>
        [DataMember(Name = "ActionArray", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ActionArray")]
        public List<GetAdPlacementByIDResultDataRewardsInnerActionArrayInner> ActionArray { get; set; }

        /// <summary>
        /// Gets or Sets Checked
        /// </summary>
        [DataMember(Name = "Checked", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Checked")]
        public bool Checked { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "Description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Odds
        /// </summary>
        [DataMember(Name = "Odds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Odds")]
        public string Odds { get; set; }

        /// <summary>
        /// Gets or Sets RewardURL
        /// </summary>
        [DataMember(Name = "RewardURL", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "RewardURL")]
        public string RewardURL { get; set; }

        /// <summary>
        /// Gets or Sets Selected
        /// </summary>
        [DataMember(Name = "Selected", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Selected")]
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "Value", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetAdsPlacementResponseData {\n");
            sb.Append("  ActionArray: ").Append(ActionArray).Append("\n");
            sb.Append("  Checked: ").Append(Checked).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Odds: ").Append(Odds).Append("\n");
            sb.Append("  RewardURL: ").Append(RewardURL).Append("\n");
            sb.Append("  Selected: ").Append(Selected).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GetAdsPlacementResponseData
    {
        /// <summary>
        /// Gets or Sets PlacementName
        /// </summary>
        [DataMember(Name = "PlacementName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "PlacementName")]
        public string PlacementName { get; set; }

        [DataMember(Name = "Platform", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Platform")]
        public string Platform { get; set; }


        [DataMember(Name = "AdFormat", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AdFormat")]
        public string AdFormat { get; set; }


        /// <summary>
        /// Gets or Sets AdUnit
        /// </summary>
        [DataMember(Name = "AdUnit", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AdUnit")]
        public string AdUnit { get; set; }


        /// <summary>
        /// Gets or Sets Rewards
        /// </summary>
        [DataMember(Name = "Rewards", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Rewards")]
        public string Rewards { get; set; }


        /// <summary>
        /// Gets or Sets Segments
        /// </summary>
        [DataMember(Name = "Segments", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Segments")]
        public string Segments { get; set; }


        [DataMember(Name = "AdLimits", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AdLimits")]
        public string AdLimits { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "Status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Status")]
        public int? Status { get; set; }


        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetAdsPlacementResponseData {\n");
            sb.Append("  PlacementName: ").Append(PlacementName).Append("\n");
            sb.Append("  Platform: ").Append(Platform).Append("\n");
            sb.Append("  AdFormat: ").Append(AdFormat).Append("\n");
            sb.Append("  AdUnit: ").Append(AdUnit).Append("\n");
            sb.Append("  Rewards: ").Append(Rewards).Append("\n");
            sb.Append("  Segments: ").Append(Segments).Append("\n");
            sb.Append("  AdLimits: ").Append(AdLimits).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
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
