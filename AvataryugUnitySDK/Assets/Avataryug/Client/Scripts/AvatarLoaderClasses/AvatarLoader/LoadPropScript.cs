using System;
using Com.Avataryug.Handler;
using Com.Avataryug.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug.UI
{
    /// <summary>
    /// This enum Contains all categorys that are provided in plugin
    /// </summary>
    public enum ItemCategory
    {
        Top, Bottom, Outfit, Footwear, Handwear, Wristwear, LeftHandTattoo, RightHandTattoo,
        LeftArmTattoo, RightArmTattoo, LeftFootTattoo, RightFootTattoo, FrontLeftLegTattoo, FrontRightLegTattoo,
        BackBodyTattoo, FrontBodyTattoo, BackLeftLegTattoo, BackRightLegTattoo, HeadTattoo, SkinTone, Hair, Eyebrow,
        Eyeball, Lips, Facialhair, Headwear, Eyewear, Mouthwear, Earwear, Eyebrowswear, Facewear, Neckwear, Nosewear,
        FaceShape, EyeShape, EyebrowShape, NoseShape, LipShape, EarShape
    }

    /// <summary>
    /// This class is designed to showcase the functionality of loading random item props when the button is clicked.
    /// </summary>
    public class LoadPropScript : MonoBehaviour
    {
        // Economy item category
        public ItemCategory itemCategory;

        // Button to perfrom load model item
        private Button m_Button;

        // After loading model detail we store in this variable
        private EconomyItems loadedItem;

        /// <summary>
        /// Get button on enable
        /// </summary>
        private void OnEnable()
        {
            if (m_Button == null)
            {
                m_Button = GetComponent<Button>();
            }

            m_Button.onClick.RemoveAllListeners();
            m_Button.onClick.AddListener(LoadModel);
        }

        /// <summary>
        /// Action to load item detail on button click
        /// </summary>
        void LoadModel()
        {
            ApiEvents.OnApiRequest?.Invoke(null, false);
            LoadItem(() =>
            {
                ApiEvents.OnApiResponce?.Invoke(null, null);
                ApiEvents.LoadNetworkModel?.Invoke(null, loadedItem);
            });
        }

        /// <summary>
        /// This function load selected category item detail and load that perticaular model
        /// </summary>
        /// <param name="onComplete"></param>
        private void LoadItem(Action onComplete)
        {
            int gender = CustomizeAvatarLoader.Instance.gender == Gender.Male ? 1 : 2;
            string category = itemCategory.ToString();
            if (AvataryugData.IsCommonGender(category))
            {
                gender = 3; //Apart from Top, Bottom, Outfit reset all category maintain as gender 3
            }
            var auth = new EconomyHandler(new GetEconomyItems() { category = category, gender = gender, status = 1 });

            auth.GetEconomyItems((result) =>
            {
                ApiEvents.OnApiResponce?.Invoke(null, null);
                if (result.Data.Count > 0)
                {
                    int index = UnityEngine.Random.Range(0, result.Data.Count - 1);
                    EconomyItems economyItems = new EconomyItems();
                    economyItems.TemplateID = result.Data[index].TemplateID;
                    economyItems.ItemCategory = result.Data[index].ItemCategory;
                    economyItems.ItemSubCategory = result.Data[index].ItemSubCategory;
                    economyItems.DisplayName = result.Data[index].DisplayName;
                    economyItems.Description = result.Data[index].Description;
                    economyItems.CustomMetaData = result.Data[index].CustomMetaData;
                    economyItems.Style = result.Data[index].Style;
                    economyItems.Artifacts = result.Data[index].Artifacts;
                    economyItems.ItemSkin = result.Data[index].ItemSkin;
                    economyItems.ID = result.Data[index].ID;
                    economyItems.CoreBucket = result.Data[index].CoreBucket;
                    economyItems.OccupiedBuckets = result.Data[index].OccupiedBuckets;
                    economyItems.Blendshapes = result.Data[index].Blendshapes;
                    economyItems.MeshData = result.Data[index].MeshData;
                    economyItems.BonesPhysics = result.Data[index].BonesPhysics;
                    economyItems.BoneAdjustments = result.Data[index].BoneAdjustments;
                    economyItems.ItemGender = result.Data[index].ItemGender.Value;
                    economyItems.IsStackable = result.Data[index].IsStackable.Value;
                    economyItems.IsLimitedEdition = result.Data[index].IsLimitedEdition.Value;
                    economyItems.LimitedEditionIntialCount = result.Data[index].LimitedEditionIntialCount.Value;
                    economyItems.Status = result.Data[index].Status.Value;
                    economyItems.RealCurrency = result.Data[index].RealCurrency.Value;
                    economyItems.Entitlement = JsonUtility.FromJson<Entitlements>(result.Data[index].Entitlement);
                    economyItems.tags = JsonUtility.FromJson<Tags>("{" + "\"tags\":" + result.Data[index].Tags + "}");
                    economyItems.Config = JsonUtility.FromJson<Configs>(result.Data[index].Config);
                    string conflictData = result.Data[index].ConflictingBuckets;
                    if (!string.IsNullOrEmpty(conflictData))
                    {
                        var conflict = JsonUtility.FromJson<ConflictingBuckets>("{" + "\"buckets\":" + result.Data[index].ConflictingBuckets + "}");
                        if (conflict != null)
                        {
                            economyItems.ConflictingBuckets = JsonUtility.FromJson<ConflictingBuckets>("{" + "\"buckets\":" + result.Data[index].ConflictingBuckets + "}");
                        }
                    }
                    economyItems.VirtualCurrency = JsonUtility.FromJson<VirtualCurrencysResult>("{" + "\"virtualCurrencys\":" + result.Data[index].VirtualCurrency + "}");
                    economyItems.ItemThumbnailsUrl = JsonUtility.FromJson<ItemThumbUrls>("{" + "\"itemThumbnails\":" + result.Data[index].ItemThumbnailsUrl + "}");
                    economyItems.BlendshapeKeys = JsonUtility.FromJson<BlendShapes>("{" + "\"blendShapes\":" + result.Data[index].BlendshapeKeys + "}");
                    loadedItem = economyItems;
                    onComplete?.Invoke();
                }
                else
                {
                    Debug.Log(category + " category prop not present in database");
                    ApiEvents.OnShowTextPopup?.Invoke(null, category + " category prop not present in database");
                }
            },
            (error) =>
            {
                Debug.Log(error.ToJson());
            });
        }
    }

}