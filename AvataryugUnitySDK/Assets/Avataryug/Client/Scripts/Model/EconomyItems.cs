using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    [Serializable]
    public class EconomyItems
    {
        public string ItemCategory = "";

        public string ID = "";

        public string TemplateID = "";

        public string ItemSubCategory = "";

        public string DisplayName = "";

        public string Description = "";

        public string CustomMetaData = "";

        public string Style = "";

        public string Artifacts = "";

        public string ItemSkin = "";

        public string CoreBucket = "";

        public string OccupiedBuckets = "";

        public string Blendshapes = "";

        public string MeshData = "";

        public string BonesPhysics = "";

        public string BoneAdjustments = "";

        public int ItemGender;

        public int IsStackable;

        public int IsLimitedEdition;

        public int LimitedEditionIntialCount;

        public int Status;

        public int RealCurrency;

        public ConflictingBuckets ConflictingBuckets = new ConflictingBuckets();
        public string ConflictingBucketsString;

        public Configs Config = new Configs();
        public string ConfigString;

        public Entitlements Entitlement = new Entitlements();
        public string EntitlementString;

        public ItemThumbUrls ItemThumbnailsUrl = new ItemThumbUrls();

        public VirtualCurrencysResult VirtualCurrency = new VirtualCurrencysResult();

        public Tags tags = new Tags();

        public BlendShapes BlendshapeKeys = new BlendShapes();
        public string BlendshapeKeysString;
        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }

    [Serializable]
    public class ConflictingBuckets
    {

        [DataMember(Name = "buckets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "buckets")]
        public List<Bucket> buckets = new List<Bucket>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConflictingBuckets {\n");
            sb.Append("  buckets: ").Append(buckets).Append("\n");
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

    [Serializable]
    public class Bucket
    {
        /// <summary>
        /// Get or set name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string name = "";

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Bucket {\n");
            sb.Append("  name: ").Append(name).Append("\n");
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

    [Serializable]
    public class Configs
    {
        [DataMember(Name = "isNormalUpload", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isNormalUpload")]
        public int isNormalUpload;

        [DataMember(Name = "isOpacityUpload", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isOpacityUpload")]
        public int isOpacityUpload;

        [DataMember(Name = "isMetallicUpload", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isMetallicUpload")]
        public int isMetallicUpload;

        [DataMember(Name = "isEmissionUpload", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isEmissionUpload")]
        public int isEmissionUpload;

        [DataMember(Name = "isRoughnessUpload", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isRoughnessUpload")]
        public int isRoughnessUpload;

        [DataMember(Name = "isZipUpload", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isZipUpload")]
        public int isZipUpload;

        [DataMember(Name = "isTwoD", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isTwoD")]
        public int isTwoD;

        [DataMember(Name = "isTransparent", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isTransparent")]
        public int isTransparent;

        [DataMember(Name = "isGrid", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isGrid")]
        public int isGrid;

        [DataMember(Name = "isDiffuse", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "isDiffuse")]
        public int isDiffuse;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Configs {\n");
            sb.Append("  isNormalUpload: ").Append(isNormalUpload).Append("\n");
            sb.Append("  isOpacityUpload: ").Append(isOpacityUpload).Append("\n");
            sb.Append("  isMetallicUpload: ").Append(isMetallicUpload).Append("\n");
            sb.Append("  isEmissionUpload: ").Append(isEmissionUpload).Append("\n");
            sb.Append("  isRoughnessUpload: ").Append(isRoughnessUpload).Append("\n");
            sb.Append("  isZipUpload: ").Append(isZipUpload).Append("\n");
            sb.Append("  isTwoD: ").Append(isTwoD).Append("\n");
            sb.Append("  isTransparent: ").Append(isTransparent).Append("\n");
            sb.Append("  isGrid: ").Append(isGrid).Append("\n");
            sb.Append("  isDiffuse: ").Append(isDiffuse).Append("\n");
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

    [Serializable]
    public class Entitlements
    {
        [DataMember(Name = "ByCount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ByCount")]
        public string ByCount = "";

        [DataMember(Name = "ByTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ByTime")]
        public string ByTime = "";

        [DataMember(Name = "TimeData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "TimeData")]
        public string TimeData = "";

        [DataMember(Name = "Type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Type")]
        public string Type = "";

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Entitlements {\n");
            sb.Append("  ByCount: ").Append(ByCount).Append("\n");
            sb.Append("  ByTime: ").Append(ByTime).Append("\n");
            sb.Append("  TimeData: ").Append(TimeData).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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

    [Serializable]
    public class ItemThumbUrls
    {
        [DataMember(Name = "itemThumbnails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "itemThumbnails")]
        public List<ItemThumUrl> itemThumbnails = new List<ItemThumUrl>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemThumbUrls {\n");
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

    [Serializable]
    public class ItemThumUrl
    {

        [DataMember(Name = "device", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "device")]
        public int device;

        [DataMember(Name = "selected", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "selected")]
        public bool selected;

        [DataMember(Name = "texture", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "texture")]
        public string texture = "";

        [DataMember(Name = "thumbnail_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "thumbnail_url")]
        public string thumbnail_url = "";

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemThumUrl {\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  selected: ").Append(selected).Append("\n");
            sb.Append("  texture: ").Append(texture).Append("\n");
            sb.Append("  thumbnail_url: ").Append(thumbnail_url).Append("\n");
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

    [Serializable]
    public class VirtualCurrencyResult
    {
        [DataMember(Name = "Amount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Amount")]
        public string Amount = "";

        [DataMember(Name = "DisplayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DisplayName")]
        public string DisplayName = "";

        [DataMember(Name = "Selected", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Selected")]
        public bool Selected;

        [DataMember(Name = "UserID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "UserID")]
        public string UserID = "";

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VirtualCurrencyResult {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Selected: ").Append(Selected).Append("\n");
            sb.Append("  UserID: ").Append(UserID).Append("\n");
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

    [Serializable]
    public class VirtualCurrencysResult
    {
        [DataMember(Name = "virtualCurrencys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "virtualCurrencys")]
        public List<VirtualCurrencyResult> virtualCurrencys = new List<VirtualCurrencyResult>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VirtualCurrencysResult {\n");
            sb.Append("  virtualCurrencys: ").Append(virtualCurrencys).Append("\n");
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
    public class BlendShapes
    {
        [DataMember(Name = "shapekeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "shapekeys")]
        public List<BlendShapeValue> blendShapes = new List<BlendShapeValue>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlendShapes {\n");
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

    [Serializable]
    public class BlendShapeValue
    {

        [DataMember(Name = "shapekeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "shapekeys")]
        public string shapekeys = "";

        [DataMember(Name = "value", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "value")]
        public float sliderValue;

        // <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlendShapeValue {\n");
            sb.Append("  shapekeys: ").Append(shapekeys).Append("\n");
            sb.Append("  sliderValue: ").Append(sliderValue).Append("\n");
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
    public class SkinToneArtifact
    {
        [DataMember(Name = "body_path", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "body_path")]
        public string body_path;

        [DataMember(Name = "device", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "device")]
        public int device;

        [DataMember(Name = "face_path", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "face_path")]
        public string face_path;

        [DataMember(Name = "selected", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "selected")]
        public bool selected;

        [DataMember(Name = "texture_size", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "texture_size")]
        public int texture_size;

        // <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SkinToneArtifact {\n");
            sb.Append("  texture_size: ").Append(texture_size).Append("\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  face_path: ").Append(face_path).Append("\n");
            sb.Append("  selected: ").Append(selected).Append("\n");
            sb.Append("  body_path: ").Append(body_path).Append("\n");
            sb.Append("  texture_size: ").Append(texture_size).Append("\n");
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
    public class SkinToneArtifacts
    {
        [DataMember(Name = "artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "artifacts")]
        public List<SkinToneArtifact> artifacts = new List<SkinToneArtifact>();


        // <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SkinToneArtifacts {\n");
            sb.Append("  artifacts: ").Append(artifacts).Append("\n");
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
