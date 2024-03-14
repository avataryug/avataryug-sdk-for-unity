using UnityEngine;
using System.Collections.Generic;

namespace Com.Avataryug
{
    /// <summary>
    /// This script added to body model to change body material at runtime
    /// </summary>
    public class BodyMaterialHandler : MonoBehaviour
    {
        public Material bodyMaterial;
        public void Initialize()
        {
            SetBodyMeshMaterial();
            SetBodySkinMeshMaterial();
        }

        /// <summary>
        /// Apply to all mesh and set material to all body parts 
        /// </summary>
        public void SetBodyMeshMaterial()
        {
            MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
            if (meshRenderers != null)
            {
                for (int i = 0; i < meshRenderers.Length; i++)
                {
                    List<Material> materials = new List<Material>();
                    meshRenderers[i].GetMaterials(materials);
                    for (int j = 0; j < materials.Count; j++)
                    {
                        if (CheckIsBodyMaterial(materials[j].name.ToLower()))
                        {
                            materials[j] = bodyMaterial;
                        }
                    }
                    meshRenderers[i].materials = materials.ToArray();
                }
            }
        }

        /// <summary>
        /// Apply to all skinmesh and set material to all body parts 
        /// </summary>
        public void SetBodySkinMeshMaterial()
        {
            SkinnedMeshRenderer[] skinmeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (var item in skinmeshRenderers)
            {
                item.quality = SkinQuality.Bone4;
                List<Material> materials = new List<Material>();
                item.GetMaterials(materials);
                for (int j = 0; j < materials.Count; j++)
                {
                    if (CheckIsBodyMaterial(materials[j].name.ToLower()))
                    {
                        materials[j] = bodyMaterial;
                    }
                }
                item.materials = materials.ToArray();
            }
           
        }

        /// <summary>
        /// Check is skinmesh render is body type
        /// </summary>
        /// <param name="bodymaterialname"></param>
        /// <returns></returns>
        private bool CheckIsBodyMaterial(string bodymaterialname)
        {
            if (bodymaterialname == "body (instance)" || bodymaterialname == "bodymaterial" || bodymaterialname == "body" || bodymaterialname == "bodymaterial (instance)")
            {
                return true;
            }
            return false;
        }
    }
}