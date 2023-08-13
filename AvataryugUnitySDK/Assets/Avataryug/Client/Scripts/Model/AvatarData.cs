using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class AvatarData
    {
        [DataMember(Name = "Race", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Race")]
        public string Race;

        [DataMember(Name = "AgeRange", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "AgeRange")]
        public string AgeRange;

        [DataMember(Name = "Gender", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Gender")]
        public int Gender;

        [DataMember(Name = "CustomMetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomMetaData")]
        public string CustomMetaData;

        [DataMember(Name = "MetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "MetaData")]
        public string MetaData;

        [DataMember(Name = "ColorMeta", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ColorMeta")]
        public PropColors ColorMeta = new PropColors();

        [DataMember(Name = "BucketData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BucketData")]
        public List<Prop> BucketData = new List<Prop>();

        [DataMember(Name = "Blendshapes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Blendshapes")]
        public List<Blendshape> Blendshapes = new List<Blendshape>();


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AvatarData {\n");
            sb.Append("  Race: ").Append(Race).Append("\n");
            sb.Append("  AgeRange: ").Append(AgeRange).Append("\n");
            sb.Append("  Gender: ").Append(Gender).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  MetaData: ").Append(MetaData).Append("\n");
            sb.Append("  ColorMeta: ").Append(ColorMeta).Append("\n");
            sb.Append("  BucketData: ").Append(BucketData).Append("\n");
            sb.Append("  Blendshapes: ").Append(Blendshapes).Append("\n");
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

    [System.Serializable]
    public class PropColors
    {
        [DataMember(Name = "HairColor", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "HairColor")]
        public string HairColor;

        [DataMember(Name = "EyebrowColor", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "EyebrowColor")]
        public string EyebrowColor;

        [DataMember(Name = "FacialHairColor", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "FacialHairColor")]
        public string FacialHairColor;

        [DataMember(Name = "LipColor", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "LipColor")]
        public string LipColor;

        [DataMember(Name = "FaceColor", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "FaceColor")]
        public string FaceColor = "#ffffff";


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PropColors {\n");
            sb.Append("  HairColor: ").Append(HairColor).Append("\n");
            sb.Append("  EyebrowColor: ").Append(EyebrowColor).Append("\n");
            sb.Append("  FacialHairColor: ").Append(FacialHairColor).Append("\n");
            sb.Append("  LipColor: ").Append(LipColor).Append("\n");
            sb.Append("  FaceColor: ").Append(FaceColor).Append("\n");
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

    [System.Serializable]
    public class Blendshape
    {
        [DataMember(Name = "value", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "value")]
        public float value;

        [DataMember(Name = "shapekeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "shapekeys")]
        public string shapekeys;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PropColors {\n");
            sb.Append("  value: ").Append(value).Append("\n");
            sb.Append("  shapekeys: ").Append(shapekeys).Append("\n");
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