using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
namespace Com.Avataryug.Model
{
    [System.Serializable]
    public class AvatarPoseClip
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

        [DataMember(Name = "ClipType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ClipType")]
        public int ClipType;

        [DataMember(Name = "ID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ID")]
        public string ID;

        [DataMember(Name = "ClipTemplateId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ClipTemplateId")]
        public string ClipTemplateId;

        [DataMember(Name = "ThumbnailsUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ThumbnailsUrl")]
        public List<ThumbnailUrl> ThumbnailsUrl = new List<ThumbnailUrl>();

        [DataMember(Name = "Artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Artifacts")]
        public List<Artifact> Artifacts = new List<Artifact>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AvatarPoseClip {\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  CustomMetaData: ").Append(CustomMetaData).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ClipType: ").Append(ClipType).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  ClipTemplateId: ").Append(ClipTemplateId).Append("\n");
            sb.Append("  ThumbnailsUrl: ").Append(ThumbnailsUrl).Append("\n");
            sb.Append("  Artifacts: ").Append(Artifacts).Append("\n");
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
    public class ClipThumbnailUrls
    {
        [DataMember(Name = "itemThumbnails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "itemThumbnails")]
        public List<ClipThumbnailUrl> itemThumbnails = new List<ClipThumbnailUrl>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ClipThumbnailUrls {\n");
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
    public class ClipThumbnailUrl
    {
        [DataMember(Name = "device", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "device")]
        public int device;

        [DataMember(Name = "texture_size", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "texture_size")]
        public int texture_size;

        [DataMember(Name = "thumbnail_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "thumbnail_url")]
        public string thumbnail_url;

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ClipThumbnailUrl {\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  texture_size: ").Append(texture_size).Append("\n");
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
    public class ClipArtifacts
    {
        [DataMember(Name = "artifacts", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "artifacts")]
        public List<ClipArtifact> artifacts = new List<ClipArtifact>();

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ClipArtifacts {\n");
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
    [Serializable]
    public class ClipArtifact
    {
        [DataMember(Name = "device", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "device")]
        public int device;

        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "format")]
        public int format;

        [DataMember(Name = "characterpose", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "characterpose")]
        public int characterpose;

        [DataMember(Name = "lod", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lod")]
        public string lod;

        [DataMember(Name = "normals", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "normals")]
        public int normals;

        [DataMember(Name = "mesh_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "mesh_url")]
        public string mesh_url;

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
            sb.Append("class ClipArtifact {\n");
            sb.Append("  device: ").Append(device).Append("\n");
            sb.Append("  format: ").Append(format).Append("\n");
            sb.Append("  characterpose: ").Append(characterpose).Append("\n");
            sb.Append("  lod: ").Append(lod).Append("\n");
            sb.Append("  normals: ").Append(normals).Append("\n");
            sb.Append("  mesh_url: ").Append(mesh_url).Append("\n");
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
}