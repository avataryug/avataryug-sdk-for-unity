using UnityEngine;
using Com.Avataryug;
using Newtonsoft.Json;
using Com.Avataryug.Model;
using Com.Avataryug.Handler;
using System.Collections.Generic;

public class AvatarBuildHandler : Singleton<AvatarBuildHandler>
{
    protected AvatarBuildHandler() { }
    [HideInInspector] public EconomyItems currentTopData = new EconomyItems();
    [HideInInspector] public EconomyItems currentHairData = new EconomyItems();
    [HideInInspector] public EconomyItems currentLipsData = new EconomyItems();
    [HideInInspector] public EconomyItems currentBottomData = new EconomyItems();
    [HideInInspector] public EconomyItems currentOutfitData = new EconomyItems();
    [HideInInspector] public EconomyItems currentEyebrowData = new EconomyItems();
    [HideInInspector] public EconomyItems currentEyeballData = new EconomyItems();
    [HideInInspector] public EconomyItems currentEyewearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentEarwearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentEyeshapeData = new EconomyItems();
    [HideInInspector] public EconomyItems currentLipshapeData = new EconomyItems();
    [HideInInspector] public EconomyItems currentFootwearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentHeadwearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentskintoneData = new EconomyItems();
    [HideInInspector] public EconomyItems currentHandwearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentEarshapeData = new EconomyItems();
    [HideInInspector] public EconomyItems currentFacewearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentNeckwearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentNosewearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentFaceshapeData = new EconomyItems();
    [HideInInspector] public EconomyItems currentNoseshapeData = new EconomyItems();
    [HideInInspector] public EconomyItems currentWristwearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentMouthwearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentHeadTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentFacialHairData = new EconomyItems();
    [HideInInspector] public EconomyItems currentEyebrowshapeData = new EconomyItems();
    [HideInInspector] public EconomyItems currentEyebrowswearData = new EconomyItems();
    [HideInInspector] public EconomyItems currentLeftArmTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentRightArmTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentLeftHandTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentLeftFootTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentBackBodyTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentRightHandTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentRightFootTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentFrontBodyTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentBackLeftLegTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentFrontLeftLegTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentBackRightLegTattooData = new EconomyItems();
    [HideInInspector] public EconomyItems currentFrontRightLegTattooData = new EconomyItems();

    public void ResetAllData()
    {
        currentTopData = currentHairData = currentLipsData = currentBottomData = new EconomyItems();
        currentOutfitData = currentEyebrowData = currentEyeballData = currentEyewearData = new EconomyItems();
        currentEarwearData = currentEyeshapeData = currentLipshapeData = new EconomyItems();
        currentFootwearData = currentHeadwearData = currentskintoneData = currentHandwearData = new EconomyItems();
        currentEarshapeData = currentFacewearData = currentNeckwearData = currentNosewearData = new EconomyItems();
        currentFaceshapeData = currentNoseshapeData = currentWristwearData = currentMouthwearData = new EconomyItems();
        currentHeadTattooData = currentFacialHairData = new EconomyItems();
        currentEyebrowshapeData = currentEyebrowswearData = new EconomyItems();
        currentLeftArmTattooData = new EconomyItems();
        currentRightArmTattooData = currentLeftHandTattooData = currentLeftFootTattooData = currentBackBodyTattooData = new EconomyItems();
        currentRightHandTattooData = currentRightFootTattooData = currentFrontBodyTattooData = new EconomyItems();
        currentBackLeftLegTattooData = new EconomyItems();
        currentFrontLeftLegTattooData = currentBackRightLegTattooData = new EconomyItems();
        currentFrontRightLegTattooData = new EconomyItems();
    }
    public List<EconomyItems> networkModelQueue = new List<EconomyItems>();
    public void AddModelToBlender(EconomyItems modelData, System.Action OnComplete)
    {
        Debug.Log(modelData.ItemCategory);
        networkModelQueue.Add(modelData);
        OnLoadQueueModel(OnComplete);
    }
    public void OnLoadQueueModel(System.Action OnComplete)
    {
        if (networkModelQueue.Count > 0)
        {
            EconomyItems modelData = networkModelQueue[0];
            networkModelQueue.RemoveAt(0);
            DownloadNetworkModel(modelData, OnComplete);
        }
        else
        {
            OnComplete?.Invoke();
        }
    }
    public void DownloadNetworkModel(EconomyItems modelData, System.Action OnComplete)
    {
        if (modelData.ItemCategory == "SkinTone")
        {
            if (currentskintoneData.ID == modelData.ID)
            {
                currentskintoneData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentskintoneData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Top")
        {
            if (currentTopData.ID == modelData.ID)
            {
                currentTopData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentTopData = modelData;
                currentOutfitData = new EconomyItems();
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Bottom")
        {
            if (currentBottomData.ID == modelData.ID)
            {
                currentBottomData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentBottomData = modelData;
                currentOutfitData = new EconomyItems();
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Outfit")
        {
            if (currentOutfitData.ID == modelData.ID)
            {
                currentOutfitData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentOutfitData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
                currentTopData = new EconomyItems();
                currentBottomData = new EconomyItems();
                if (modelData.ConflictingBuckets.buckets.Find(f => f.name == "lowerbody_foot_both") != null)
                {
                    currentFootwearData = new EconomyItems();
                }
            }
        }
        if (modelData.ItemCategory == "Footwear")
        {
            if (currentFootwearData.ID == modelData.ID)
            {
                currentFootwearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentFootwearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Handwear")
        {
            if (currentHandwearData.ID == modelData.ID)
            {
                currentHandwearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentHandwearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Wristwear")
        {
            if (currentWristwearData.ID == modelData.ID)
            {
                currentWristwearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentWristwearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "LeftHandTattoo")
        {
            if (currentLeftHandTattooData.ID == modelData.ID)
            {
                currentLeftHandTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentLeftHandTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "RightHandTattoo")
        {
            if (currentRightHandTattooData.ID == modelData.ID)
            {
                currentRightHandTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentRightHandTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "LeftArmTattoo")
        {
            if (currentLeftArmTattooData.ID == modelData.ID)
            {
                currentLeftArmTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentLeftArmTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "RightArmTattoo")
        {
            if (currentRightArmTattooData.ID == modelData.ID)
            {
                currentRightArmTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentRightArmTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "LeftFootTattoo")
        {
            if (currentLeftFootTattooData.ID == modelData.ID)
            {
                currentLeftFootTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentLeftFootTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "RightFootTattoo")
        {
            if (currentRightFootTattooData.ID == modelData.ID)
            {
                currentRightFootTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentRightFootTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "FrontLeftLegTattoo")
        {
            if (currentFrontLeftLegTattooData.ID == modelData.ID)
            {
                currentFrontLeftLegTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentFrontLeftLegTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "FrontRightLegTattoo")
        {
            if (currentFrontRightLegTattooData.ID == modelData.ID)
            {
                currentFrontRightLegTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentFrontRightLegTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "BackBodyTattoo")
        {
            if (currentBackBodyTattooData.ID == modelData.ID)
            {
                currentBackBodyTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentBackBodyTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "FrontBodyTattoo")
        {
            if (currentFrontBodyTattooData.ID == modelData.ID)
            {
                currentFrontBodyTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentFrontBodyTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "BackLeftLegTattoo")
        {
            if (currentBackLeftLegTattooData.ID == modelData.ID)
            {
                currentBackLeftLegTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentBackLeftLegTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "BackRightLegTattoo")
        {
            if (currentBackRightLegTattooData.ID == modelData.ID)
            {
                currentBackRightLegTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentBackRightLegTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "HeadTattoo")
        {
            if (currentHeadTattooData.ID == modelData.ID)
            {
                currentHeadTattooData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentHeadTattooData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Mouthwear")
        {
            if (currentMouthwearData.ID == modelData.ID)
            {
                currentMouthwearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentMouthwearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Earwear")
        {
            if (currentEarwearData.ID == modelData.ID)
            {
                currentEarwearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentEarwearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Eyebrowswear")
        {
            if (currentEyebrowswearData.ID == modelData.ID)
            {
                currentEyebrowswearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentEyebrowswearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Facewear")
        {
            if (currentFacewearData.ID == modelData.ID)
            {
                currentFacewearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentFacewearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Neckwear")
        {
            if (currentNeckwearData.ID == modelData.ID)
            {
                currentNeckwearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentNeckwearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Nosewear")
        {
            if (currentNosewearData.ID == modelData.ID)
            {
                currentNosewearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentNosewearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Eyebrow")
        {
            if (currentEyebrowData.ID == modelData.ID)
            {
                currentEyebrowData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentEyebrowData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Eyeball")
        {
            if (currentEyeballData.ID == modelData.ID)
            {
                currentEyeballData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentEyeballData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Lips")
        {
            if (currentLipsData.ID == modelData.ID)
            {
                currentLipsData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentEyeballData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Hair")
        {
            if (currentHairData.ID == modelData.ID)
            {
                currentHairData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentHairData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Facialhair")
        {
            if (currentFacialHairData.ID == modelData.ID)
            {
                currentFacialHairData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentFacialHairData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Headwear")
        {
            if (currentHeadwearData.ID == modelData.ID)
            {
                currentHeadwearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentHeadwearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }
        if (modelData.ItemCategory == "Eyewear")
        {
            if (currentEyewearData.ID == modelData.ID)
            {
                currentEyewearData = new EconomyItems();
                PatchAvatarRemoveBucket(modelData);
            }
            else
            {
                currentEyewearData = modelData;
                PatchAvatarAddBucket(modelData, () =>
                {
                    OnLoadQueueModel(OnComplete);
                });
            }
        }

        if (modelData.ItemCategory == "FaceShape" || modelData.ItemCategory == "EyeShape" ||
            modelData.ItemCategory == "EyebrowShape" || modelData.ItemCategory == "NoseShape" ||
            modelData.ItemCategory == "LipShape" || modelData.ItemCategory == "EarShape")
        {
            PatchAvatarBlendshape(() => { });
        }
        OnComplete?.Invoke();

    }
#if DEMO_AVATARYUG
    public void CreateCurrentAvatar(List<EconomyItems> economyItems, AvatarPresetData avatarPresetData)
    {
       
        AvatarDataBlender avatarDataBlender = new AvatarDataBlender();
        ClipExpressionData clipExpressionData = new ClipExpressionData();
        clipExpressionData.Style.ClipID = "61c43d03-f21c-4a7c-97fe-9665be6739a4";
        clipExpressionData.Style.ExpressionID = "";
        clipExpressionData.gender = UserDetailHolder.Instance.userDetails.gender == Gender.Male ? 0 : 1;
        string metaData = JsonConvert.SerializeObject(clipExpressionData);
        avatarDataBlender.MetaData = JsonConvert.SerializeObject(metaData);

        avatarDataBlender.AgeRange = avatarPresetData.AgeRange;
        avatarDataBlender.Race = avatarPresetData.Race;
        avatarDataBlender.Gender = avatarPresetData.Gender == Gender.Male ? 0 : 1;
        avatarDataBlender.ColorMeta = avatarPresetData.Color;

        List<PropBucketData> propBucketDatas = new List<PropBucketData>();
        foreach (var item in economyItems)
        {
            propBucketDatas.Add(new PropBucketData()
            {
                Blendshapes = item.Blendshapes,
                Config = item.ConfigString,
                ConflictingBuckets = item.ConflictingBucketsString,
                CoreBucket = item.CoreBucket,
                ID = item.ID,
                ItemSkin = item.ItemSkin,
                MainCatID = item.ItemCategory,
                TemplateID = item.TemplateID,
            });
        }
        avatarDataBlender.BucketData = propBucketDatas;
        List<BlendshapeData> blendshapes = new List<BlendshapeData>();
        foreach (var item in avatarPresetData.BlendshapeKeys)
        {
            blendshapes.Add(new BlendshapeData() { k = item.shapekeys, v = item.sliderValue });
        }
        avatarDataBlender.Blendshapes = blendshapes;
        avatarDataBlender.CustomMetaData = "[]";
        var api = new AvatarManagementHandler(new CreateAvatar
        {
            AvatarData = JsonConvert.SerializeObject(avatarDataBlender),
            Platform = Utility.GetPlatfrom().ToString() 
        });
        api.CreateAvatar((result) =>
        {
            Debug.Log(result); 
            currentAvatarID = result.AvatarID;
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
    }

    public void CreateCurrentAvatar()
    {
        ApiEvents.OnApiRequest("Generating Avatar", false);
        ClipExpressionData clipExpressionData = new ClipExpressionData();
        clipExpressionData.Style.ClipID = "61c43d03-f21c-4a7c-97fe-9665be6739a4";
        clipExpressionData.Style.ExpressionID = "";
        clipExpressionData.gender = UserDetailHolder.Instance.userDetails.gender == Gender.Male ? 0 : 1;
        string metaData = JsonConvert.SerializeObject(clipExpressionData);

        AvatarData1 avatarData = new AvatarData1();
        avatarData.MetaData = metaData;
        avatarData.AgeRange = "21 to 24";
        avatarData.Race = "Custom";
        avatarData.Gender = clipExpressionData.gender;
        avatarData.ColorMeta = CurrentAvatarChanges.Instance.changePropColors;
        foreach (var item in AvatarBuildHandler.Instance.currentSelectedBodyParts)
        {
            avatarData.BucketData.Add(new BucketDatum()
            {
                Blendshapes = item.Blendshapes,
                Config = item.ConfigString,
                ConflictingBuckets = item.ConflictingBucketsString,
                CoreBucket = item.CoreBucket,
                ID = item.ID,
                ItemSkin = item.ItemSkin,
                MainCatID = item.ItemCategory,
                TemplateID = item.TemplateID
            });
        }
        avatarData.CustomMetaData = "[]";

        for (int a = 0; a < AvatarBuildHandler.Instance.ForCustomizeAvatar.headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
        {
            int index = a;
            string blendshapename = AvatarBuildHandler.Instance.ForCustomizeAvatar.headModelScript.headRenderer.sharedMesh.GetBlendShapeName(index);
            float weight = AvatarBuildHandler.Instance.ForCustomizeAvatar.headModelScript.headRenderer.GetBlendShapeWeight(index);
            if (weight != 0 && !CommonFunction.IsPresntinExpression(blendshapename))
            {
                avatarData.Blendshapes.Add(new Blendshape1()
                {
                    k = blendshapename,
                    v = weight.ToString(),
                });
            }
        }
        var api = new AvatarManagementHandler(new CreateAvatar
        {
            AvatarData = JsonConvert.SerializeObject(avatarData),
            Platform = Utility.GetPlatfrom().ToString()
        });
        api.CreateAvatar((result) =>
        {
            Debug.Log(result);
                    currentAvatarID = result.AvatarID;
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
    }
#endif
    public void CreateDefaultAvatar(int gender)
    {
        ClipExpressionData clipExpressionData = new ClipExpressionData();
        clipExpressionData.Style.ClipID = "61c43d03-f21c-4a7c-97fe-9665be6739a4";
        clipExpressionData.Style.ExpressionID = "";
        clipExpressionData.gender = gender;
        string metaData = JsonConvert.SerializeObject(clipExpressionData);

        AvatarData1 avatarData = new AvatarData1();
        avatarData.MetaData = metaData;
        avatarData.AgeRange = "21 to 24";
        avatarData.Race = "Custom";
        avatarData.Gender = clipExpressionData.gender;
#if DEMO_AVATARYUG
        avatarData.ColorMeta = CurrentAvatarChanges.Instance.changePropColors;
#endif
        avatarData.CustomMetaData = "[]";

        var api = new AvatarManagementHandler(new CreateAvatar
        {
            AvatarData = JsonConvert.SerializeObject(avatarData),
            Platform = Utility.GetPlatfrom().ToString()
        });
        api.CreateAvatar((result) =>
        {
            Debug.Log(result);
            currentAvatarID = result.AvatarID;
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
    }
    public void CreateDefaultAvatar()
    {
        ClipExpressionData clipExpressionData = new ClipExpressionData();
        clipExpressionData.Style.ClipID = "61c43d03-f21c-4a7c-97fe-9665be6739a4";
        clipExpressionData.Style.ExpressionID = "";
#if DEMO_AVATARYUG
            clipExpressionData.gender = UserDetailHolder.Instance.userDetails.gender == Gender.Male ? 0 : 1;
#endif
        string metaData = JsonConvert.SerializeObject(clipExpressionData);

        AvatarData1 avatarData = new AvatarData1();
        avatarData.MetaData = metaData;
        avatarData.AgeRange = "21 to 24";
        avatarData.Race = "Custom";
        avatarData.Gender = clipExpressionData.gender;
#if DEMO_AVATARYUG
        avatarData.ColorMeta = CurrentAvatarChanges.Instance.changePropColors;
#endif
        avatarData.CustomMetaData = "[]";

        var api = new AvatarManagementHandler(new CreateAvatar
        {
            AvatarData = JsonConvert.SerializeObject(avatarData),
            Platform = Utility.GetPlatfrom().ToString()
        });
        api.CreateAvatar((result) =>
        {
            Debug.Log(result);
            currentAvatarID = result.AvatarID;
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
    }
    public void PatchAddColor()
    {
        FinalColos finalColos = new FinalColos();

#if DEMO_AVATARYUG
        finalColos.ColorMeta.LipColor = CurrentAvatarChanges.Instance.changePropColors.LipColor;
        finalColos.ColorMeta.HairColor = CurrentAvatarChanges.Instance.changePropColors.HairColor;
        finalColos.ColorMeta.FaceColor = "#FFFFFF";
        finalColos.ColorMeta.EyebrowColor = CurrentAvatarChanges.Instance.changePropColors.EyebrowColor;
        finalColos.ColorMeta.FacialHairColor = CurrentAvatarChanges.Instance.changePropColors.FacialHairColor;
#endif
        var api = new AvatarManagementHandler(new UpdateAvatar
        {
            PatchData = JsonConvert.SerializeObject(finalColos),
            AvatarID = currentAvatarID,
            Action = "Add",
            PatchDataType = "Color"
        });
        api.UpdateAvatar((result) =>
        {
            Debug.Log(result);
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
    }
    public void PatchAvatarRemoveBucket(EconomyItems economyItem)
    {
        PropBucketData propBucketData = new PropBucketData();
        propBucketData.ID = economyItem.ItemCategory;
        propBucketData.CoreBucket = economyItem.CoreBucket;
        propBucketData.TemplateID = economyItem.TemplateID;
        propBucketData.ItemSkin = economyItem.ItemSkin;
        propBucketData.Config = economyItem.ConfigString;
        propBucketData.ConflictingBuckets = economyItem.ConflictingBucketsString;
        propBucketData.Blendshapes = economyItem.BlendshapeKeysString;
        propBucketData.MainCatID = economyItem.ItemCategory;
        var api = new AvatarManagementHandler(new UpdateAvatar
        {
            PatchData = JsonUtility.ToJson(propBucketData),
            AvatarID = currentAvatarID,
            Action = "Remove",
            PatchDataType = "Bucket"
        });
        api.UpdateAvatar((result) =>
        {
            Debug.Log(result);
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
    }
    public string currentSelectedClipid = "";

    public void AddClip(string id)
    {
        if (currentSelectedClipid == id)
        {
            PatchClip(false);
            currentSelectedClipid = string.Empty;
        }
        else
        {
            PatchClip(true);
            currentSelectedClipid = id;
        }
    }

    public void RemoveClip()
    {
        if (currentSelectedClipid != string.Empty)
        {
            PatchClip(false);
        }
    }
    public void PatchClip(bool isAdd)
    {
        var api = new AvatarManagementHandler(new UpdateAvatar
        {
            PatchData = currentSelectedClipid,
            AvatarID = currentAvatarID,
            Action = isAdd ? "Add" : "Remove",
            PatchDataType = "Clip"
        });
        api.UpdateAvatar((result) => { }, (error) => { });
    }
    public void PatchAvatarAddBucket(EconomyItems economyItem, System.Action OnComplete)
    {
        PropBucketData propBucketData = new PropBucketData();
        propBucketData.ID = economyItem.ItemCategory;
        propBucketData.CoreBucket = economyItem.CoreBucket;
        propBucketData.TemplateID = economyItem.TemplateID;
        propBucketData.ItemSkin = economyItem.ItemSkin;
        propBucketData.Config = economyItem.ConfigString;
        propBucketData.ConflictingBuckets = economyItem.ConflictingBucketsString;
        propBucketData.Blendshapes = economyItem.BlendshapeKeysString;
        propBucketData.MainCatID = economyItem.ItemCategory;
        var api = new AvatarManagementHandler(new UpdateAvatar
        {
            PatchData = JsonUtility.ToJson(propBucketData),
            AvatarID = currentAvatarID,
            Action = "Add",
            PatchDataType = "Bucket"
        });
        api.UpdateAvatar((result) =>
        {
            Debug.Log(result);
            OnComplete?.Invoke();
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
    }
    public void PatchAvatarBlendshape(System.Action onUpdate)
    {
#if DEMO_AVATARYUG
        SkinnedMeshRenderer head = AvatarBuildHandler.Instance.ForCustomizeAvatar.headModelScript.headRenderer;
        BlendsahpePatch blendsahpePatch = new BlendsahpePatch();
        for (int a = 0; a < head.sharedMesh.blendShapeCount; a++)
        {
            int index = a;
            string blendshapename = head.sharedMesh.GetBlendShapeName(index);
            float weight = head.GetBlendShapeWeight(index);
            if(weight != 0)
            {
                blendsahpePatch.Blendshapes.Add(new BlendshapeData() { k = blendshapename, v = weight });
            }
        }
        var api = new AvatarManagementHandler(new UpdateAvatar
        {
            PatchData = JsonUtility.ToJson(blendsahpePatch),
            AvatarID = currentAvatarID,
            Action = "Add",
            PatchDataType = "Blendshape"
        });
        api.UpdateAvatar((result) =>
        {
            Debug.Log("blend");
            onUpdate?.Invoke();
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
#endif
    }
    public void PatchAvatarExpression(System.Action onUpdate)
    {
#if DEMO_AVATARYUG
        SkinnedMeshRenderer head = AvatarBuildHandler.Instance.ForCustomizeAvatar.headModelScript.headRenderer;
        BlendsahpePatch blendsahpePatch = new BlendsahpePatch();
        for (int a = 0; a < head.sharedMesh.blendShapeCount; a++)
        {
            int index = a;
            string blendshapename = head.sharedMesh.GetBlendShapeName(index);
            float weight = head.GetBlendShapeWeight(index);
            if (weight != 0)
            {
                blendsahpePatch.Blendshapes.Add(new BlendshapeData() { k = blendshapename, v = weight });
            }
        }
        var api = new AvatarManagementHandler(new UpdateAvatar
        {
            PatchData = JsonUtility.ToJson(blendsahpePatch),
            AvatarID = currentAvatarID,
            Action = "Add",
            PatchDataType = "Expression"
        });
        api.UpdateAvatar((result) =>
        {
            Debug.Log("blend");
            onUpdate?.Invoke();
        }, (error) =>
        {
            Debug.Log(">>>>>" + error.ToJson());
        });
#endif
    }
    public void ExportGlb(System.Action<string> glbUrl)
    {
        if (!string.IsNullOrEmpty(currentAvatarID))
        {
            var api = new AvatarManagementHandler(new UpdateAvatar
            {
                PatchData = "{}",
                AvatarID = currentAvatarID,
                Action = "ExportGLB",
                PatchDataType = "ExportGLB"
            });
            api.UpdateAvatar((result) =>
            {
                Debug.Log(result.ToString());
                if (!string.IsNullOrEmpty(result))
                {
                    ExportGlbResult thumnailResult = JsonUtility.FromJson<ExportGlbResult>(result);
                    glbUrl?.Invoke(thumnailResult.Data.MeshURL);
                }
                else
                {
                    ApiEvents.OnApiResponce.Invoke(null, null);
                    ApiEvents.OnShowTextPopup?.Invoke(null, "Responce is null from server");
                }

            }, (error) =>
            {
                ApiEvents.OnApiResponce?.Invoke(null, null);
                Debug.Log(">>>>>" + error.ToJson());
            });
        }
    }
    public void ExportThumbnail(System.Action<string> imageUrl)
    {
        ApiEvents.OnApiRequest?.Invoke(null, false);
        var currentTime = System.DateTime.Now;
        var api = new AvatarManagementHandler(new UpdateAvatar
        {
            PatchData = "{}",
            AvatarID = currentAvatarID,
            Action = "Thumbnail",
            PatchDataType = "Thumbnail"
        });
        api.UpdateAvatar((result) =>
        {
            var totalTime = System.DateTime.Now - currentTime;
            Debug.Log(totalTime.Seconds);
            Debug.Log(result.ToString());
            if (!string.IsNullOrEmpty(result))
            {

                // Utility.DelayCall(500, () =>
                //  {
                ExportThumnailResult mResult = JsonUtility.FromJson<ExportThumnailResult>(result);
                imageUrl?.Invoke(mResult.Data.ImageURL);
                // });
            }
            else
            {
                ApiEvents.OnApiResponce.Invoke(null, null);
                ApiEvents.OnShowTextPopup?.Invoke(null, "Responce is null from server");
            }
        },
        (error) =>
        {
            ApiEvents.OnApiResponce?.Invoke(null, null);
            Debug.Log(">>>>>" + error.ToJson());
        });
    }
    public string currentAvatarID;
}

[System.Serializable]
public class PropBucketData
{
    public string ID;
    public string CoreBucket;
    public string TemplateID;
    public string ItemSkin;
    public string Config;
    public string ConflictingBuckets;
    public string Blendshapes;
    public string MainCatID;
}

[System.Serializable]
public class ColorObj
{
    public string LipColor;
    public string FaceColor;
    public string HairColor;
    public string EyebrowColor;
    public string FacialHairColor;
}
[System.Serializable]
public class FinalColos
{
    public ColorObj ColorMeta = new ColorObj();
}

[System.Serializable]
public class AvatarDataBlender
{
    public string MetaData;
    public string AgeRange;
    public PropColors ColorMeta = new PropColors();
    public List<PropBucketData> BucketData = new List<PropBucketData>();
    public List<BlendshapeData> Blendshapes = new List<BlendshapeData>();
    public string Race;
    public int Gender;
    public string CustomMetaData;
}
[System.Serializable]
public class BlendsahpePatch
{
    public List<BlendshapeData> Blendshapes = new List<BlendshapeData>();
}
[System.Serializable]
public class BlendshapeData
{
    public float v;
    public string k;
}

[System.Serializable]
public class Data
{
    public string Platform;
    public string ImageURL;
}
[System.Serializable]
public class ExportThumnailResult
{
    public int Code;
    public string Status;
    public Data Data;
}

[System.Serializable]
public class MeshResult
{
    public string Platform;
    public string MeshURL;
}
[System.Serializable]
public class ExportGlbResult
{
    public int Code;
    public string Status;
    public MeshResult Data;
}