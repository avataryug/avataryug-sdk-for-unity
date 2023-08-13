using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Avataryug.Model
{

    [Serializable]
    public class EconomyItems
    {
        [DataMember(Name = "ItemCategory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemCategory")]
        public string ItemCategory = "";

        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID = "";

        [DataMember(Name = "TemplateID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "TemplateID")]
        public string TemplateID = "";

        [DataMember(Name = "ItemSubCategory", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemSubCategory")]
        public string ItemSubCategory = "";

        [DataMember(Name = "DisplayName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "DisplayName")]
        public string DisplayName = "";

        [DataMember(Name = "Description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Description")]
        public string Description = "";

        [DataMember(Name = "CustomMetaData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CustomMetaData")]
        public string CustomMetaData = "";

        [DataMember(Name = "Style", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Style")]
        public string Style = "";

        [DataMember(Name = "Artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Artifacts")]
        public string Artifacts = "";

        [DataMember(Name = "ItemSkin", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemSkin")]
        public string ItemSkin = "";

        [DataMember(Name = "CoreBucket", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "CoreBucket")]
        public string CoreBucket = "";

        [DataMember(Name = "OccupiedBuckets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "OccupiedBuckets")]
        public string OccupiedBuckets = "";

        [DataMember(Name = "Blendshapes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Blendshapes")]
        public string Blendshapes = "";

        [DataMember(Name = "Code", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Code")]
        public string MeshData = "";

        [DataMember(Name = "BonesPhysics", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BonesPhysics")]
        public string BonesPhysics = "";

        [DataMember(Name = "BoneAdjustments", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BoneAdjustments")]
        public string BoneAdjustments = "";

        [DataMember(Name = "ItemGender", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemGender")]
        public int ItemGender;

        [DataMember(Name = "IsStackable", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "IsStackable")]
        public int IsStackable;

        [DataMember(Name = "IsLimitedEdition", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "IsLimitedEdition")]
        public int IsLimitedEdition;

        [DataMember(Name = "LimitedEditionIntialCount", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "LimitedEditionIntialCount")]
        public int LimitedEditionIntialCount;

        [DataMember(Name = "Status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Status")]
        public int Status;

        [DataMember(Name = "RealCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "RealCurrency")]
        public int RealCurrency;

        [DataMember(Name = "ConflictingBuckets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ConflictingBuckets")]
        public ConflictingBuckets ConflictingBuckets = new ConflictingBuckets();

        [DataMember(Name = "Config", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Config")]
        public Configs Config = new Configs();

        [DataMember(Name = "Entitlement", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Entitlement")]
        public Entitlements Entitlement = new Entitlements();

        [DataMember(Name = "ItemThumbnailsUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ItemThumbnailsUrl")]
        public ItemThumbUrls ItemThumbnailsUrl = new ItemThumbUrls();

        [DataMember(Name = "VirtualCurrency", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "VirtualCurrency")]
        public VirtualCurrencysResult VirtualCurrency = new VirtualCurrencysResult();

        [DataMember(Name = "tags", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tags")]
        public Tags tags = new Tags();

        [DataMember(Name = "BlendshapeKeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "BlendshapeKeys")]
        public BlendShapes BlendshapeKeys = new BlendShapes();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EconomyItems {\n");
            sb.Append("  ItemCategory: ").Append(ItemCategory).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  TemplateID: ").Append(TemplateID).Append("\n");
            sb.Append("  ItemSubCategory: ").Append(ItemSubCategory).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  Style: ").Append(Style).Append("\n");
            sb.Append("  Artifacts: ").Append(Artifacts).Append("\n");
            sb.Append("  ItemSkin: ").Append(ItemSkin).Append("\n");
            sb.Append("  CoreBucket: ").Append(CoreBucket).Append("\n");
            sb.Append("  OccupiedBuckets: ").Append(OccupiedBuckets).Append("\n");
            sb.Append("  Blendshapes: ").Append(Blendshapes).Append("\n");
            sb.Append("  MeshData: ").Append(MeshData).Append("\n");
            sb.Append("  BonesPhysics: ").Append(BonesPhysics).Append("\n");
            sb.Append("  BoneAdjustments: ").Append(BoneAdjustments).Append("\n");
            sb.Append("  ItemGender: ").Append(ItemGender).Append("\n");
            sb.Append("  IsStackable: ").Append(IsStackable).Append("\n");
            sb.Append("  IsLimitedEdition: ").Append(IsLimitedEdition).Append("\n");
            sb.Append("  LimitedEditionIntialCount: ").Append(LimitedEditionIntialCount).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  RealCurrency: ").Append(RealCurrency).Append("\n");
            sb.Append("  ConflictingBuckets: ").Append(ConflictingBuckets).Append("\n");
            sb.Append("  Config: ").Append(Config).Append("\n");
            sb.Append("  Entitlement: ").Append(Entitlement).Append("\n");
            sb.Append("  ItemThumbnailsUrl: ").Append(ItemThumbnailsUrl).Append("\n");
            sb.Append("  VirtualCurrency: ").Append(VirtualCurrency).Append("\n");
            sb.Append("  tags: ").Append(tags).Append("\n");
            sb.Append("  BlendshapeKeys: ").Append(BlendshapeKeys).Append("\n");
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
        public float value;

        // <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlendShapeValue {\n");
            sb.Append("  shapekeys: ").Append(shapekeys).Append("\n");
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
