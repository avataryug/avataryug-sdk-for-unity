using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class Expression
    {
        [DataMember(Name = "DisplayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DisplayName")]
        public string DisplayName;

        [DataMember(Name = "Description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Description")]
        public string Description;

        [DataMember(Name = "Category", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Category")]
        public string Category;

        [DataMember(Name = "CustomMetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomMetaData")]
        public string CustomMetaData;

        [DataMember(Name = "Tags", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Tags")]
        public string Tags;

        [DataMember(Name = "Color", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Color")]
        public string Color;

        [DataMember(Name = "Metadata", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Metadata")]
        public string Metadata;

        [DataMember(Name = "Status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Status")]
        public int Status;

        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID;

        [DataMember(Name = "BlendshapeKeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BlendshapeKeys")]
        public BlendShapesExp BlendshapeKeys = new BlendShapesExp();

        [DataMember(Name = "ThumbnailsUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ThumbnailsUrl")]
        public List<ThumbnailUrl> ThumbnailsUrl = new List<ThumbnailUrl>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Expression {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  BlendshapeKeys: ").Append(BlendshapeKeys).Append("\n");
            sb.Append("  ThumbnailsUrl: ").Append(ThumbnailsUrl).Append("\n");
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
    public class BlendShapesExp
    {
        [DataMember(Name = "blendShapes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "blendShapes")]
        public List<BlendShapeExp> blendShapes = new List<BlendShapeExp>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlendShapesExp {\n");
            sb.Append("  blendShapes: ").Append(blendShapes).Append("\n");
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
    public class ExpThumbnailUrls
    {
        [DataMember(Name = "itemThumbnails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "itemThumbnails")]
        public List<ExpThumbnailUrl> itemThumbnails = new List<ExpThumbnailUrl>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ExpThumbnailUrls {\n");
            sb.Append("  itemThumbnails: ").Append(itemThumbnails).Append("\n");
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
    public class ExpThumbnailUrl
    {
        [DataMember(Name = "device", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "device")]
        public int device;

        [DataMember(Name = "textureLODSize", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "textureLODSize")]
        public int textureLODSize;

        [DataMember(Name = "thumbnail_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "thumbnail_url")]
        public string thumbnail_url;

        [DataMember(Name = "selected", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "selected")]
        public bool selected;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ExpThumbnailUrl {\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  textureLODSize: ").Append(textureLODSize).Append("\n");
            sb.Append("  thumbnail_url: ").Append(thumbnail_url).Append("\n");
            sb.Append("  selected: ").Append(selected).Append("\n");
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
    public class BlendShapeExp
    {
        [DataMember(Name = "selectedShape", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "selectedShape")]
        public string selectedShape;

        [DataMember(Name = "maincategory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "maincategory")]
        public string maincategory;

        [DataMember(Name = "sliderValue", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sliderValue")]
        public float sliderValue;

        [DataMember(Name = "value", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "value")]
        public float value;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlendShapeExp {\n");
            sb.Append("  selectedShape: ").Append(selectedShape).Append("\n");
            sb.Append("  maincategory: ").Append(maincategory).Append("\n");
            sb.Append("  sliderValue: ").Append(sliderValue).Append("\n");
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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}