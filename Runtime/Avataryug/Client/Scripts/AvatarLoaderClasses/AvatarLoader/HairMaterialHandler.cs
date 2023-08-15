using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Avataryug
{
    /// <summary>
    /// This class handles the body material
    /// </summary>
    public class HairMaterialHandler : MonoBehaviour
    {
        public string Category;
        public Material hairMaterial;
        public List<Material> hairmaterials = new List<Material>();
        public Transform[] childrens;
        public CustomizeAvatarLoader customizeAvatarLoader;
        /// <summary>
        /// Subscribe event
        /// </summary>
        private void OnEnable()
        {
            ApiEvents.OnChangeColor += ApiEvents_OnChangeColor;
        }

        /// <summary>
        /// Desubscribe event
        /// </summary>
        private void OnDisable()
        {
            ApiEvents.OnChangeColor -= ApiEvents_OnChangeColor;
        }

        /// <summary>
        /// Change hair color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApiEvents_OnChangeColor(object sender, Color e)
        {
            if (sender.ToString() == "Hair")
            {
                if (customizeAvatarLoader.HairModel != null)
                {
                    for (int i = 0; i < hairmaterials.Count; i++)
                    {
                        hairmaterials[i].color = e;
                    }
#if DEMO_AVATARYUG
                    CurrentAvatarChanges.Instance.changePropColors.HairColor = "#" + ColorUtility.ToHtmlStringRGB(e).ToLower();
#endif
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetData()
        {
            if (Category == "Hair")
            {
                SkinnedMeshRenderer skinner = GetComponentInChildren<SkinnedMeshRenderer>();
                MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();
                if (skinner != null)
                {
                    List<Material> hairMat = new List<Material>();
                    skinner.GetMaterials(hairMat);
                    for (int i = 0; i < hairMat.Count; i++)
                    {
                        hairmaterials.Add(hairMaterial);
                        hairmaterials[i].mainTexture = hairMat[i].mainTexture;
                        if (hairMat[i].HasProperty("_BumpMap"))
                        {
                            hairmaterials[i].SetTexture("_BumpMap", hairMat[i].GetTexture("_BumpMap"));
                        }
#if DEMO_AVATARYUG
                        hairmaterials[i].color = GetColor(CurrentAvatarChanges.Instance.changePropColors.HairColor);
#endif
                    }
                    skinner.materials = hairmaterials.ToArray();
                }

                if (meshRenderer != null)
                {
                    List<Material> hairMat = new List<Material>();

                    meshRenderer.GetMaterials(hairMat);
                    for (int i = 0; i < hairMat.Count; i++)
                    {
                        hairmaterials.Add(hairMaterial);
                        hairmaterials[i].mainTexture = hairMat[i].mainTexture;
                        if (hairMat[i].HasProperty("_BumpMap"))
                        {
                            hairmaterials[i].SetTexture("_BumpMap", hairMat[i].GetTexture("_BumpMap"));
                        }

                        if (hairMat[i].HasProperty("_Metallic"))
                        {
                            hairmaterials[i].SetTexture("_Metallic", hairMat[i].GetTexture("_Metallic"));
                        }
#if DEMO_AVATARYUG
                        if (CurrentAvatarChanges.Instance.changePropColors.HairColor.Contains("#"))
                        {
                            hairmaterials[i].color = GetColor(CurrentAvatarChanges.Instance.changePropColors.HairColor);
                        }
                        else
                        {
                            hairmaterials[i].color = GetColor("#" + CurrentAvatarChanges.Instance.changePropColors.HairColor);
                        }
#endif
                    }
                }

                childrens = transform.GetComponentsInChildren<Transform>();
                foreach (var item in childrens)
                {
                    if (item.name.StartsWith("p_"))
                    {
                        Transform[] transforms1 = item.GetComponentsInChildren<Transform>();
                        if (transforms1.Length > 1)
                        {
                            // transforms1[transforms1.Length - 1].gameObject.AddComponent<JigleBon>();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Used to parse color 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        Color GetColor(string hex)
        {
            Color col = Color.black;
            if (!string.IsNullOrEmpty(hex))
            {
                ColorUtility.TryParseHtmlString(hex.Contains("#") ? hex : ("#" + hex), out col);
            }
            return col;
        }
    }

}
