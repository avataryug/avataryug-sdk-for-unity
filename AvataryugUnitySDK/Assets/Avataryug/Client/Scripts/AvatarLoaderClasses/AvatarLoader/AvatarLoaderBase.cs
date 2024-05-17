using System;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;
using Com.Avataryug.Model;
using Newtonsoft.Json.Linq;
using Com.Avataryug.Handler;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Com.Avataryug
{
    /// <summary>
    /// The "AvatarLoaderBase" class is a base class responsible for managing the process of loading and handling avatar mesh information.
    /// It serves as a foundation for performing tasks like managing conflict buckets,
    /// loading different parts of the avatar, and handling textures and blendshapes for the face.
    /// This class encapsulates the core functionality related to avatar mesh processing and provides
    /// a framework for derived classes to extend and customize the behavior as needed.
    /// </summary>
    public abstract class AvatarLoaderBase : MonoBehaviour
    {
        ///Time delay between multiple click
        public readonly int delayTime = 100;

        ///Holds Hair model to compare  
        [HideInInspector] public GameObject HairModel;
        [HideInInspector] public GameObject HeadwearModel;

        ///Holds Default Color data and default textures
        [HideInInspector] public AvatarLocalData avatarLocalData;

        //Materials applied to loaded model
        [HideInInspector] public Material m_HeadMaterial;
        [HideInInspector] public Material m_BodyMaterial;
        [HideInInspector] public Material m_EyeballMaterial;
        [HideInInspector] public Material m_InnerMaterial;

        //Hold selected model data
        //Used for removing same model and compare with next model
        [HideInInspector] public EconomyItems currentTopData = new EconomyItems();
        [HideInInspector] public EconomyItems currentWristwearData = new EconomyItems();
        [HideInInspector] public EconomyItems currentBottomData = new EconomyItems();
        [HideInInspector] public EconomyItems currentOutfitData = new EconomyItems();
        [HideInInspector] public EconomyItems currentFootwearData = new EconomyItems();
        [HideInInspector] public EconomyItems currentHandwearData = new EconomyItems();
        [HideInInspector] public EconomyItems currentLispData = new EconomyItems();
        [HideInInspector] public EconomyItems currentfacialHairData = new EconomyItems();
        [HideInInspector] public EconomyItems currentEyeballData = new EconomyItems();
        [HideInInspector] public EconomyItems currentEyebrowData = new EconomyItems();
        [HideInInspector] public EconomyItems currentHairData = new EconomyItems();
        [HideInInspector] public EconomyItems currentHadwearData = new EconomyItems();
        [HideInInspector] public EconomyItems currentFaceshapeData = new EconomyItems();
        [HideInInspector] public EconomyItems currentEarshapeData = new EconomyItems();
        [HideInInspector] public EconomyItems currentNoseshapeData = new EconomyItems();
        [HideInInspector] public EconomyItems currentEyebrowshapeData = new EconomyItems();
        [HideInInspector] public EconomyItems currentEyeshapeData = new EconomyItems();
        [HideInInspector] public EconomyItems currentLipshapeData = new EconomyItems();
        [HideInInspector] public EconomyItems currentskintoneData = new EconomyItems();

        ///Holds body models bucket point 
        [HideInInspector] public List<GameObject> bodyPoints = new List<GameObject>();

        //To load default model in queue added to this list
        [HideInInspector] public List<ModelData> loadDefaultModellist = new List<ModelData>();
        [HideInInspector] public List<ModelData> DefaultModellist = new List<ModelData>();

        //Hold current model before loading next model
        [HideInInspector] public GameObject TopToDestroy;
        [HideInInspector] public GameObject BottomToDestroy;
        [HideInInspector] public GameObject HandwearToDestroy;
        [HideInInspector] public GameObject FootwearToDestroy;
        [HideInInspector] public GameObject OutfitToDestroy;

        //Hold models animator controller
        [HideInInspector] public List<Animator> animatorControllers = new List<Animator>();
        public List<GameObject> m_ModelForAnimation = new List<GameObject>();

        //Hold all loaded tattoo in this list
        [HideInInspector] public List<LoadedTattoo> lastLoadedTattoos = new List<LoadedTattoo>();

        /// <summary>
        /// Defaul model animation clip
        /// </summary>
        [HideInInspector] public AnimationClip tpose;

        //Selected Expression data
        [HideInInspector] public Expression currentexpression = new Expression();

        //Selected animation clip data
        [HideInInspector] public AvatarPoseClip currentClip = new AvatarPoseClip();

        //Variablet to check is Model is getting reset
        [HideInInspector] public bool isResetToCurrent;

        //Action to perform after model reset
        [HideInInspector] public Action OnResetToCurrent = null;

        //Hold head conflict bucketname
        [HideInInspector] public string HeadCoreBuck = "";

        //Parent Customize Avatar loader class
        [HideInInspector] public CustomizeAvatarLoader customizeAvatarLoader;

        //Holds head model script reference
        [HideInInspector] public HeadModel headModelScript;

        //Holds Facialhair script reference to modify blendshape
        [HideInInspector] public FacialHair facialHairScript;

        //Holds multiple model to destry before loading next model
        private List<GameObject> objToDestroy = new List<GameObject>();

        //Holds currnet body type
        public BodyType currentBodyType;
        [SerializeField]
        public Dictionary<string, Vector3> scaleMap = new Dictionary<string, Vector3>();
        /// <summary>
        /// Add your animation clip path here 
        /// </summary>
        ///
        public const string AnimationTargetName = "AnimationTargets/standard_idel";
        public const string AnimatorControllerName = "AnimatorControllers/FullBody";
        public const string TAnimatorControllerName = "AnimatorControllers/ClipController";

        /// <summary>
        /// Model to load from network add to this list
        /// </summary>
        public List<EconomyItems> networkModelQueue = new List<EconomyItems>();

        /// <summary>
        /// Gender for model to loade
        /// </summary>
        public Gender gender = Gender.Male;

        /// <summary>
        /// This function return gender from above variable if added in demo app return gender from user profile
        /// </summary>
        /// <returns></returns>
        public Gender GetGender()
        {
            Gender tempGender = gender;
#if DEMO_AVATARYUG
            tempGender = UserDetailHolder.Instance.userDetails.gender;
#endif
            return tempGender;
        }

        public void ApplyScaleToBody(Transform parent, Dictionary<string, Vector3> scaleMap)
        {
            foreach (Transform child in parent)
            {
                string childName = child.name;
                // Check if the child name exists in the scale map
                if (scaleMap.ContainsKey(childName))
                {
                    // Apply the corresponding scale value from the map
                    child.localScale = scaleMap[childName];
                }

                // Optionally, apply the scale recursively to child objects
                if (child.childCount > 0)
                    ApplyScaleToBody(child, scaleMap);
            }
        }
        /// <summary>
        /// Load Default Texture
        /// </summary>
        public void LoadStartData()
        {
            avatarLocalData = Resources.Load<AvatarLocalData>("AvatarLocalData");
            m_HeadMaterial = avatarLocalData.HeadMaterial;
            m_EyeballMaterial = avatarLocalData.EyeballMaterial;
            m_BodyMaterial = avatarLocalData.BodyMaterial;
            m_InnerMaterial = avatarLocalData.InnerMouthMaterial;
            m_HeadMaterial.SetTexture("_MainTex", avatarLocalData.baseSkinTexture);
            m_HeadMaterial.SetColor("_EyebrowColor", Utility.GetColor(avatarLocalData.DefaultEyebrowColor));
            switch (GetGender())
            {
                case Gender.Male:
                    m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(avatarLocalData.DefaultMaleLipColor));
                    break;
                case Gender.Female:
                    m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(avatarLocalData.DefaultLipColor));
                    break;
            }
            m_HeadMaterial.SetTexture("_TatooTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_BeardTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_EyebrowTexture", avatarLocalData.DefaultEyebrowTexture);
            m_HeadMaterial.SetTexture("_LipsTexture", avatarLocalData.DefaultLipTexture);
            m_EyeballMaterial.SetTexture("_MainTex", avatarLocalData.eyeballTexture);
            m_BodyMaterial.SetTexture("_MainTex", avatarLocalData.bodyTexture);
            for (int i = 0; i < AvataryugData.bodytattos.Count; i++)
            {
                m_BodyMaterial.SetTexture("_" + AvataryugData.bodytattos[i], avatarLocalData.empty);
            }

            //avatarLocalData.bodyTypeData
        }

        /// <summary>
        /// Clear class data
        /// </summary>
        public void ResetAvatarLoader()
        {
            HeadCoreBuck = "";
            m_HeadMaterial = null;
            m_BodyMaterial = null;
            m_EyeballMaterial = null;
            loadDefaultModellist = new List<ModelData>();
            bodyPoints = new List<GameObject>();
            headModelScript = null;
            lastLoadedTattoos = new List<LoadedTattoo>();
            currentTopData = currentWristwearData = currentBottomData = currentOutfitData = currentFootwearData = currentHandwearData = currentLispData = currentfacialHairData = currentEyeballData = currentEyebrowData = currentHairData = currentHadwearData = new EconomyItems();
            networkModelQueue = new List<EconomyItems>();
            HeadwearModel = HairModel = null;
        }

        /// <summary>
        /// This function check missing model after new model load and add missing model
        /// </summary>
        /// <param name="modelData"></param>
        public void CheckMissingAfterModelLoad(EconomyItems modelData)
        {
            bool loadTop = false;
            bool loadBottom = false;
            bool loadFootwear = false;
            bool loadHandwear = false;

            if (modelData.ItemCategory == "Top")
            {
                bool isbottomPresent = false;
                bool isFootwearPresent = false;

                foreach (var item in bodyPoints)
                {
                    if (!isbottomPresent && (item.name == "lowerbody_without_foot" || item.name == "lowerbody_till_knee"))
                    {
                        isbottomPresent = item.transform.childCount > 0;
                    }
                    if (!isFootwearPresent && item.name == "lowerbody_foot_both")
                    {
                        isFootwearPresent = item.transform.childCount > 0;
                    }
                }

                loadBottom = !isbottomPresent;
                loadFootwear = !isFootwearPresent;
            }
            if (modelData.ItemCategory == "Bottom")
            {
                bool isTopPresent = false;
                bool isFootwearPresent = false;
                foreach (var item in bodyPoints)
                {
                    if (!isTopPresent && (item.name == "upperbody_sleeve_short" || item.name == "upperbody_sleeve_full" || item.name == "upperbody_sleeveless"))
                    {
                        isTopPresent = item.transform.childCount > 0;
                    }

                    if (!isFootwearPresent && item.name == "lowerbody_foot_both")
                    {
                        isFootwearPresent = item.transform.childCount > 0;
                    }
                }
                loadTop = !isTopPresent;
                loadFootwear = !isFootwearPresent;
            }
            if (modelData.ItemCategory == "Outfit")
            {
                bool isFootwearPresent = false;
                bool isHandPResent = false;
                bool isTOpPresent = false;
                bool isbottomPresent = false;
                foreach (var item in bodyPoints)
                {
                    if (!isFootwearPresent && item.name == "lowerbody_foot_both")
                    {
                        isFootwearPresent = item.transform.childCount > 0;
                    }
                    if (!isHandPResent && item.name == "upperbody_hand_both")
                    {
                        isHandPResent = item.transform.childCount > 0;
                    }
                    if (!isTOpPresent && (item.name == "upperbody_sleeve_short" || item.name == "upperbody_sleeve_full" || item.name == "upperbody_sleeveless"))
                    {
                        isTOpPresent = item.transform.childCount > 0;
                    }
                    if (!isbottomPresent && (item.name == "lowerbody_without_foot" || item.name == "lowerbody_till_knee"))
                    {
                        isbottomPresent = item.transform.childCount > 0;
                    }
                }
                if (isTOpPresent || isbottomPresent)
                {
                    ApiEvents.OnShowTextPopup?.Invoke(null, "Conflicts not available");
                }
                loadFootwear = !isFootwearPresent;
                loadHandwear = !isHandPResent;
            }
            if (modelData.ItemCategory == "Footwear")
            {
                bool isTopPresent = false;
                bool isBottomPresent = false;
                bool isOutfitpresnet = false;
                foreach (var item in bodyPoints)
                {
                    if (!isTopPresent && (item.name == "upperbody_sleeve_short" || item.name == "upperbody_sleeve_full" || item.name == "upperbody_sleeveless"))
                    {
                        isTopPresent = item.transform.childCount > 0;
                    }
                    if (!isBottomPresent && (item.name == "lowerbody_without_foot" || item.name == "lowerbody_till_knee"))
                    {
                        isBottomPresent = item.transform.childCount > 0;
                    }
                    if (!isOutfitpresnet && (item.name == "fullbody_without_head" || item.name == "fullbody_with_head_foot" || item.name == "fullbody_without_head_foot"))
                    {
                        isOutfitpresnet = item.transform.childCount > 0;
                    }
                }

                if (!isOutfitpresnet)
                {
                    loadTop = !isTopPresent;
                    loadBottom = !isBottomPresent;
                }
            }

            if (loadTop)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[0]);
                OnLoadQueDefaultModel();
            }
            if (loadBottom)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[1]);
                OnLoadQueDefaultModel();
            }
            if (loadFootwear)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[2]);
                OnLoadQueDefaultModel();
            }
            if (loadHandwear)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[3]);
                OnLoadQueDefaultModel();
            }
        }

        /// <summary>
        /// Load Quemodel and removes from queue
        /// </summary>
        public void OnLoadQueDefaultModel()
        {
            if (loadDefaultModellist.Count == 0)
            {
                ApiEvents.OnApiResponce?.Invoke(null, null);
                Utility.ClearCatche();
            }
            else
            {
                ModelData modelData = loadDefaultModellist[0];
                loadDefaultModellist.RemoveAt(0);
                DownloadDefaultModel(modelData);
            }
        }

        /// <summary>
        /// This Function Dowload model from network
        /// </summary>
        /// <param name="modelData"></param>
        public void DownloadDefaultModel(ModelData modelData)
        {
            if (loadLocal)
            {
                GameObject objtospawn = null;

                switch (modelData.LocalPath)
                {
                    case "female_standard_top":
                        objtospawn = avatarLocalData.female_standard_top;
                        break;
                    case "female_standard_bottom":
                        objtospawn = avatarLocalData.female_standard_bottom;
                        break;
                    case "male_standard_top":
                        objtospawn = avatarLocalData.male_standard_top;
                        break;
                    case "male_standard_bottom":
                        objtospawn = avatarLocalData.male_standard_bottom;
                        break;
                    case "standard_footwear":
                        objtospawn = avatarLocalData.standard_footwear;
                        break;
                    case "standard_hand":
                        objtospawn = avatarLocalData.standard_hand;
                        break;
                }
                var obj = Instantiate(objtospawn);
                AddDefaultBodypart(obj, modelData, () =>
                {
                    OnLoadQueDefaultModel();
                });

            }
            else
            {
                FileDownloder.GetByteData(modelData.GlbPath, (result) =>
                {
                    FileHandler.SaveFile(result, modelData.GlbPath, () => { });
                    GltfFastLoader.LoadModel(result, (obj) =>
                    {
                        AddDefaultBodypart(obj, modelData, () =>
                        {
                            OnLoadQueDefaultModel();
                        });
                    });
                }, (error) => { Debug.LogError(error); });
            }
        }

        /// <summary>
        /// After downloading model this function set model in scene in its perticular bucket
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelData"></param>
        /// <param name="onComplete"></param>
        public void AddDefaultBodypart(GameObject model, ModelData modelData, Action onComplete)
        {
            string[] buc = modelData.CoreBucket.Split('/');
            string bucketname = buc[0];

            if (buc.Length > 1)
            {
                bucketname = buc[1];
            }

            if (bodyPoints.Count > 0)
            {
                foreach (var item in bodyPoints)
                {
                    if (item.name == bucketname)
                    {
                        if (item.transform.childCount > 0)
                        {
                            Destroy(item.transform.GetChild(0).gameObject);
                            break;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(modelData.ConflictingBuckets))
            {
                string data = "{" + "\"Conflicts\"" + ":" + modelData.ConflictingBuckets + "}";
                ConflictList conflits = JsonUtility.FromJson<ConflictList>(data);
                for (int i = 0; i < bodyPoints.Count; i++)
                {
                    for (int j = 0; j < conflits.Conflicts.Count; j++)
                    {
                        if (bodyPoints[i].name == conflits.Conflicts[j].name)
                        {
                            if (bodyPoints[i].transform.childCount > 0)
                            {
                                Destroy(bodyPoints[i].transform.GetChild(0).gameObject);
                            }
                        }
                    }
                }
            }

            bool isPrensent = false;
            GameObject ppin = null;
            if (bodyPoints.Count > 0)
            {
                foreach (var item in bodyPoints)
                {
                    if (item.name == bucketname)
                    {
                        ppin = item;
                        isPrensent = true;
                        break;
                    }
                }
            }

            if (!isPrensent)
            {
                GameObject gObject = new GameObject();
                gObject.transform.parent = transform;
                gObject.transform.localPosition = Vector3.zero;
                gObject.transform.localEulerAngles = Vector3.zero;
                gObject.name = bucketname;
                bodyPoints.Add(gObject);

                ppin = gObject;
            }

            ppin.transform.localEulerAngles = Vector3.zero;
            ppin.transform.localPosition = Vector3.zero;
            model.name = modelData.MainCatID;
            BodyMaterialHandler bodyTexture = model.AddComponent<BodyMaterialHandler>();
            bodyTexture.bodyMaterial = m_BodyMaterial;
            bodyTexture.Initialize();
            model.transform.SetParent(ppin.transform);
            model.transform.localPosition = Vector3.zero;
            model.transform.localEulerAngles = Vector3.zero;

            AfterFileImport(model, 0);
            onComplete?.Invoke();

            if (TopToDestroy != null) { DestroyImmediate(TopToDestroy); }
            if (BottomToDestroy != null) { DestroyImmediate(BottomToDestroy); }
            if (HandwearToDestroy != null) { DestroyImmediate(HandwearToDestroy); }
            if (FootwearToDestroy != null) { DestroyImmediate(FootwearToDestroy); }
            if (OutfitToDestroy != null) { DestroyImmediate(OutfitToDestroy); }
        }

        /// <summary>
        /// This Function Add Animation to current model
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="angle"></param>
        public void AfterFileImport(GameObject obj, float angle)
        {
            Transform[] childs = obj.GetComponentsInChildren<Transform>();
            foreach (var item in childs)
            {
                if (item.name.Contains("mixamorig:"))
                {
                    item.name = item.name.Replace("mixamorig:", "");
                }
            }

            Transform hips = obj.transform.Find("mixamorig:Hips");
            if (hips == null)
            {
                hips = obj.transform.Find("Hips");
            }
            if (hips != null)
            {
                obj.transform.name = "Model";
                GameObject model = new GameObject()
                {
                    name = "Armature"
                };
                model.transform.parent = obj.transform;

                model.transform.localPosition = Vector3.zero;
                hips.parent = model.transform;
                Avatar animationAvatar = Resources.Load<Avatar>(AnimationTargetName);
                RuntimeAnimatorController animatorController = Resources.Load<RuntimeAnimatorController>(AnimatorControllerName);
                Animator animator = obj.AddComponent<Animator>();
                obj.transform.localEulerAngles = Vector3.zero;
                animator.runtimeAnimatorController = animatorController;
                animator.avatar = animationAvatar;
                transform.gameObject.SetActive(false);
                transform.gameObject.SetActive(true);
                animatorControllers.Add(animator);
                model.transform.localEulerAngles = new Vector3(angle, 0, 0);

                SetBodyType(currentBodyType, () =>
                {
                    ApplyScaleToBody(transform, scaleMap);
                });
            }
            m_ModelForAnimation.Add(obj);
            Utility.DelayCall(50, () =>
            {
                m_ModelForAnimation = m_ModelForAnimation.FindAll(f => f != null).ToList();
                animatorControllers = animatorControllers.FindAll(f => f != null).ToList();
            });
        }

        /// <summary>
        /// This function check missing model after we remove current model
        /// </summary>
        /// <param name="modelData"></param>
        /// <param name="objtoDestroy"></param>
        public void CheckMissingModelAfterRemovingSameModel(EconomyItems modelData, GameObject objtoDestroy)
        {
            bool loadTop = false;
            bool loadBottom = false;
            bool loadFootwear = false;
            bool loadHandwear = false;

            if (modelData.ItemCategory == "Top")
            {
                TopToDestroy = objtoDestroy;
                bool isTopPresent = false;
                bool isbottomPresent = false;
                bool isFootwearPresent = false;
                foreach (var item in bodyPoints)
                {
                    if (!isTopPresent && (item.name == "upperbody_sleeve_short" || item.name == "upperbody_sleeve_full" || item.name == "upperbody_sleeveless"))
                    {
                        isTopPresent = item.transform.childCount > 0;
                    }
                    if (!isbottomPresent && (item.name == "lowerbody_without_foot" || item.name == "lowerbody_till_knee"))
                    {
                        isbottomPresent = item.transform.childCount > 0;
                    }
                    if (!isFootwearPresent && item.name == "lowerbody_foot_both")
                    {
                        isFootwearPresent = item.transform.childCount > 0;
                    }
                }
                loadTop = !isTopPresent;
                loadBottom = !isbottomPresent;
                loadFootwear = !isFootwearPresent;
            }

            if (modelData.ItemCategory == "Bottom")
            {
                BottomToDestroy = objtoDestroy;
                bool isBottomPresent = false;
                bool isTopPresent = false;
                bool isFootwearPresent = false;
                foreach (var item in bodyPoints)
                {
                    if (!isBottomPresent && (item.name == "lowerbody_without_foot" || item.name == "lowerbody_till_knee"))
                    {
                        isBottomPresent = item.transform.childCount > 0;
                    }
                    if (!isTopPresent && (item.name == "upperbody_sleeve_short" || item.name == "upperbody_sleeve_full" || item.name == "upperbody_sleeveless"))
                    {
                        isTopPresent = item.transform.childCount > 0;
                    }

                    if (!isFootwearPresent && item.name == "lowerbody_foot_both")
                    {
                        isFootwearPresent = item.transform.childCount > 0;
                    }
                }

                loadBottom = !isBottomPresent;
                loadTop = !isTopPresent;
                loadFootwear = !isFootwearPresent;
            }

            if (modelData.ItemCategory == "Outfit")
            {
                OutfitToDestroy = objtoDestroy;
                bool isFootwearPresent = false;
                bool isTopPresent = false;
                bool isBottomPresent = false;
                bool isHandPresent = false;

                foreach (var item in bodyPoints)
                {
                    if (!isBottomPresent && (item.name == "lowerbody_without_foot" || item.name == "lowerbody_till_knee"))
                    {
                        isBottomPresent = item.transform.childCount > 0;
                    }
                    if (!isTopPresent && (item.name == "upperbody_sleeve_short" || item.name == "upperbody_sleeve_full" || item.name == "upperbody_sleeveless"))
                    {
                        isTopPresent = item.transform.childCount > 0;
                    }
                    if (!isFootwearPresent && (item.name == "lowerbody_foot_both"))
                    {
                        isFootwearPresent = item.transform.childCount > 0;
                    }
                    if (!isHandPresent && item.name == "upperbody_hand_both")
                    {
                        isHandPresent = item.transform.childCount > 0;
                    }
                }

                loadTop = !isTopPresent;
                loadBottom = !isBottomPresent;
                loadFootwear = !isFootwearPresent;
                loadHandwear = !isHandPresent;
            }
            if (modelData.ItemCategory == "Footwear")
            {
                FootwearToDestroy = objtoDestroy;
                bool isFootwearPresent = false;
                foreach (var item in bodyPoints)
                {
                    if (!isFootwearPresent && item.name == "lowerbody_foot_both")
                    {
                        isFootwearPresent = item.transform.childCount > 0;
                    }
                }

                loadFootwear = !isFootwearPresent;
            }
            if (modelData.ItemCategory == "Handwear")
            {
                HandwearToDestroy = objtoDestroy;
                bool isHandPResent = false;
                foreach (var item in bodyPoints)
                {
                    if (!isHandPResent && item.name == "upperbody_hand_both")
                    {
                        isHandPResent = item.transform.childCount > 0;
                    }
                }
                loadHandwear = !isHandPResent;
            }

            if (loadTop)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[0]);
                OnLoadQueDefaultModel();
            }
            if (loadBottom)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[1]);
                OnLoadQueDefaultModel();
            }
            if (loadFootwear)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[2]);
                OnLoadQueDefaultModel();
            }
            if (loadHandwear)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[3]);
                OnLoadQueDefaultModel();
            }
        }

        /// <summary>
        /// Reset Avatar data
        /// </summary>
        public void ResetData()
        {

            gameObject.transform.position = Vector3.zero;
            gameObject.transform.localEulerAngles = Vector3.zero;

#if DEMO_AVATARYUG

            CurrentAvatarChanges.Instance.changedProps = new Props();
            for (int i = 0; i < CurrentAvatarChanges.Instance.currentProps.props.Count; i++)
            {
                var tempitem = CurrentAvatarChanges.Instance.currentProps.props[i];
                CurrentAvatarChanges.Instance.changedProps.props.Add(tempitem);
            }
            CurrentAvatarChanges.Instance.changeblendShapes = new List<Blendshape>();
            for (int i = 0; i < CurrentAvatarChanges.Instance.currentblendShapes.Count; i++)
            {
                CurrentAvatarChanges.Instance.changeblendShapes.Add(CurrentAvatarChanges.Instance.currentblendShapes[i]);
            }
            string col = CurrentAvatarChanges.Instance.currentpropColors.HairColor;
            CurrentAvatarChanges.Instance.changePropColors.HairColor = col;
            col = CurrentAvatarChanges.Instance.currentpropColors.FacialHairColor;
            CurrentAvatarChanges.Instance.changePropColors.FacialHairColor = col;
            col = CurrentAvatarChanges.Instance.currentpropColors.LipColor;
            CurrentAvatarChanges.Instance.changePropColors.LipColor = col;
            col = CurrentAvatarChanges.Instance.currentpropColors.EyebrowColor;
            CurrentAvatarChanges.Instance.changePropColors.EyebrowColor = col;
            UndoHandler.Instance.RecordedActions.Clear();
#endif
            currentTopData = new EconomyItems();
            currentWristwearData = new EconomyItems();
            currentBottomData = new EconomyItems();
            currentOutfitData = new EconomyItems();
            currentFootwearData = new EconomyItems();
            currentHandwearData = new EconomyItems();
            currentLispData = new EconomyItems();
            currentfacialHairData = new EconomyItems();
            currentEyeballData = new EconomyItems();
            currentEyebrowData = new EconomyItems();
            currentHairData = new EconomyItems();
            currentHadwearData = new EconomyItems();
            currentFaceshapeData = new EconomyItems();
            currentEarshapeData = new EconomyItems();
            currentNoseshapeData = new EconomyItems();
            currentEyebrowshapeData = new EconomyItems();
            currentEyeshapeData = new EconomyItems();
            currentLipshapeData = new EconomyItems();
            currentskintoneData = new EconomyItems();
        }

        /// <summary>
        /// Extract bucket names
        /// </summary>
        /// <param name="corebutckt"></param>
        /// <returns></returns>
        public string GetBucketname(string corebutckt)
        {
            string[] buc = corebutckt.Split('/');
            string bucketname = buc[0];
            if (buc.Length > 1)
            {
                bucketname = buc[1];
            }
            return bucketname;
        }

        /// <summary>
        /// Clear current selected item data
        /// </summary>
        public void ClearCurrent()
        {
            currentHandwearData = currentFootwearData = currentTopData = currentWristwearData = new EconomyItems();
            currentBottomData = currentLispData = currentfacialHairData = currentEyeballData = currentEyebrowData = new EconomyItems();
            currentOutfitData = currentHairData = currentHadwearData = currentFaceshapeData = currentEarshapeData = new EconomyItems();
            currentNoseshapeData = currentEyebrowshapeData = currentEyeshapeData = currentLipshapeData = currentskintoneData = new EconomyItems();
        }

        /// <summary>
        /// Check default model queue list is empty or not and load default model
        /// </summary>
        /// <param name="OnComplete"></param>
        public void OnLoadQueueDefaultModel(Action OnComplete)
        {
            if (loadDefaultModellist.Count == 0)
            {
                OnComplete?.Invoke();
            }
            else
            {
                ModelData modelData = loadDefaultModellist[0];
                loadDefaultModellist.RemoveAt(0);
                DownloadDefaultModel(modelData, OnComplete);
            }
        }
        public bool loadLocal = true;

        //async void GetDefaultmodel(string path, Action<byte[]> outdata)
        //{
        //    byte[] bytedata = await FileDownloder.GetGlbByte(path);
        //    outdata?.Invoke(bytedata);
        //}
        /// <summary>
        /// Download model from netwrok
        /// </summary>
        /// <param name="modelData"></param>
        /// <param name="OnComplete"></param>
        public void DownloadDefaultModel(ModelData modelData, Action OnComplete)
        {
            if (loadLocal)
            {
                GameObject objtospawn = null;

                switch (modelData.LocalPath)
                {
                    case "female_standard_top":
                        objtospawn = avatarLocalData.female_standard_top;
                        break;
                    case "female_standard_bottom":
                        objtospawn = avatarLocalData.female_standard_bottom;
                        break;
                    case "male_standard_top":
                        objtospawn = avatarLocalData.male_standard_top;
                        break;
                    case "male_standard_bottom":
                        objtospawn = avatarLocalData.male_standard_bottom;
                        break;
                    case "standard_footwear":
                        objtospawn = avatarLocalData.standard_footwear;
                        break;
                    case "standard_hand":
                        objtospawn = avatarLocalData.standard_hand;
                        break;
                }
                var obj = Instantiate(objtospawn);
                AddDefaultBodypart(obj, modelData, () =>
                {
                    OnLoadQueueDefaultModel(OnComplete);
                });
            }
            else
            {
                FileDownloder.GetByteData(modelData.GlbPath, (result) =>
                {
                    GltfFastLoader.LoadModel(result, (obj) =>
                    {
                        AddDefaultBodypart(obj, modelData, () =>
                        {
                            OnLoadQueueDefaultModel(OnComplete);
                        });
                    });
                }, (error) => { Debug.LogError(error); });
            }
        }

        /// <summary>
        /// Download tattos and store in list
        /// </summary>
        /// <param name="modelData"></param>
        public void DownloadTattoos(EconomyItems modelData)
        {
            string bucketName = GetBucketname(modelData.CoreBucket);
            var isPresentSameCat = false;
            var isPresentLatstId = false;
            var tatooSameIDindex = -1;
            var tatooSameCatindex = -1;
            if (lastLoadedTattoos.Count > 0)
            {
                for (int i = 0; i < lastLoadedTattoos.Count; i++)
                {
                    if (lastLoadedTattoos[i].ItemCategory == modelData.ItemCategory)
                    {
                        isPresentSameCat = true;
                        tatooSameCatindex = i;

                        if (lastLoadedTattoos[i].tattooid == modelData.ID)
                        {
                            isPresentLatstId = true;
                            tatooSameIDindex = i;
                        }
                    }
                }
            }

            bool addNew = false;
            if (isPresentSameCat)
            {
                if (isPresentLatstId)
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                    lastLoadedTattoos.RemoveAt(tatooSameIDindex);
                    OnProcessModelTexture();
                    Utility.DelayCall(delayTime, () =>
                    {
                        OnLoadQueueModel();
                    });
                }
                else
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                    lastLoadedTattoos.RemoveAt(tatooSameCatindex);
                    addNew = true;
                }
            }
            else
            {
                addNew = true;
            }

            if (addNew)
            {
                if (!string.IsNullOrEmpty(modelData.Artifacts))
                {
                    if (modelData.Artifacts != "[]")
                    {
                        TwoDArtifacts artifacts = JsonUtility.FromJson<TwoDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                        TwoDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        ApiEvents.OnApiRequest?.Invoke(null, false);

                        FileDownloder.GetNetworkTexture(artifact.url,
                        (texture) =>
                        {
#if DEMO_AVATARYUG
                            EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, texture, null);
#endif
                            lastLoadedTattoos.Add(new LoadedTattoo()
                            {
                                ItemCategory = modelData.ItemCategory,
                                tattooid = modelData.ID,
                                tattooTex = texture
                            });

#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                            OnProcessModelTexture();
                            Utility.DelayCall(delayTime, () =>
                            {
                                OnLoadQueueModel();
                            });
                        }, (err) =>
                        {
                            OnLoadQueueModel();
                        }, (pr) => { });
                    }
                    else
                    {
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
                else
                {
                    ApiEvents.OnShowTextPopup?.Invoke(null, "Tattoo not available");
                    Utility.DelayCall(delayTime, () =>
                    {
                        OnLoadQueueModel();
                    });
                }
            }
        }

        /// <summary>
        /// Add tattos in material
        /// </summary>
        void OnProcessModelTexture()
        {
            for (int i = 0; i < AvataryugData.bodytattos.Count; i++)
            {
                m_BodyMaterial.SetTexture("_" + AvataryugData.bodytattos[i], avatarLocalData.empty);
            }
            m_HeadMaterial.SetTexture("_TatooTexture", avatarLocalData.empty);
            if (lastLoadedTattoos.Count > 0)
            {
                for (int i = 0; i < lastLoadedTattoos.Count; i++)
                {
                    if (lastLoadedTattoos[i].ItemCategory == "HeadTattoo")
                    {
                        m_HeadMaterial.SetTexture("_TatooTexture", lastLoadedTattoos[i].tattooTex);
                    }
                    else
                    {
                        m_BodyMaterial.SetTexture("_" + lastLoadedTattoos[i].ItemCategory, lastLoadedTattoos[i].tattooTex);
                    }
                }
            }
        }

        /// <summary>
        /// Load skintone and add to the avatar 
        /// </summary>
        /// <param name="modelData"></param>
        public void LoadSkintone(EconomyItems modelData)
        {
            if (currentskintoneData.ID == modelData.ID)
            {

#if DEMO_AVATARYUG
                AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                currentskintoneData = new EconomyItems();
                m_BodyMaterial.SetTexture("_MainTex", avatarLocalData.bodyTexture);
                m_HeadMaterial.SetTexture("_MainTex", avatarLocalData.baseSkinTexture);
                OnLoadQueueModel();
            }
            else
            {
                if (!string.IsNullOrEmpty(modelData.Artifacts))
                {
                    if (modelData.Artifacts != "[]")
                    {
                        SkinToneArtifacts artifacts = JsonUtility.FromJson<SkinToneArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                        SkinToneArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        if (artifact != null)
                        {
                            ApiEvents.OnApiRequest?.Invoke(null, false);
                            if (!string.IsNullOrEmpty(artifact.face_path) && !string.IsNullOrEmpty(artifact.body_path))
                            {
                                FileDownloder.GetNetworkTexture(artifact.face_path,
                                (facetex) =>
                                {
                                    facetex.filterMode = FilterMode.Point;

                                    FileDownloder.GetNetworkTexture(artifact.body_path,
                                    (bodytex) =>
                                    {
                                        bodytex.filterMode = FilterMode.Point;
                                        currentskintoneData = modelData;
#if DEMO_AVATARYUG
                                        AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                                        m_HeadMaterial.SetTexture("_MainTex", facetex);
                                        m_HeadMaterial.SetColor("_Color", Color.white);
                                        m_BodyMaterial.SetTexture("_MainTex", bodytex);
                                        m_BodyMaterial.SetColor("_Color", Color.white);
#if DEMO_AVATARYUG
                                        EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, facetex, bodytex);
#endif
                                        Utility.DelayCall(delayTime, () =>
                                        {
                                            OnLoadQueueModel();
                                        });
                                    });
                                });
                            }
                        }
                        else
                        {
                            ApiEvents.OnShowTextPopup?.Invoke(null, "SkinTone not available");
                            Utility.DelayCall(delayTime, () =>
                            {
                                OnLoadQueueModel();
                            });
                        }
                    }
                    else
                    {
                        ApiEvents.OnShowTextPopup?.Invoke(null, "SkinTone not available");
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
                else
                {
                    ApiEvents.OnShowTextPopup?.Invoke(null, "SkinTone not available");
                    Utility.DelayCall(delayTime, () =>
                    {
                        OnLoadQueueModel();
                    });
                }
            }
        }

        /// <summary>
        /// This function load Top,Bottom ,Outfit,handwear,footwear
        /// </summary>
        /// <param name="modelData"></param>
        public async void LoadBodyPart(EconomyItems modelData)
        {
            string[] buc = modelData.CoreBucket.Split('/');
            string bucketname = buc[0];
            if (buc.Length > 1)
            {
                bucketname = buc[1];
            }
            bool isModelPresent = false;

            if (modelData.ItemCategory == "Top")
            {
                if (currentTopData.ID == modelData.ID)
                {
                    GameObject objtoDestroy = null;
                    if (bodyPoints.Count > 0)
                    {
                        foreach (var item in bodyPoints)
                        {
                            if (item.name == bucketname)
                            {
                                if (item.transform.childCount > 0)
                                {
                                    objtoDestroy = item.transform.GetChild(0).gameObject;
                                    isModelPresent = true;
                                }
                            }
                        }
                    }
                    if (objtoDestroy != null)
                    {
                        objtoDestroy.transform.parent = transform;
                    }
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(currentTopData);
#endif
                    currentTopData = new EconomyItems();
                    CheckMissingModelAfterRemovingSameModel(modelData, objtoDestroy);
                }
                else
                {

#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
                    AvatarBuildHandler.Instance.RemovePart("Outfit");
#endif
                    currentTopData = modelData;
                    currentOutfitData = new EconomyItems();
                }
            }
            if (modelData.ItemCategory == "Bottom")
            {
                if (currentBottomData.ID == modelData.ID)
                {
                    GameObject objtoDestroy = null;
                    if (bodyPoints.Count > 0)
                    {
                        foreach (var item in bodyPoints)
                        {
                            if (item.name == bucketname)
                            {
                                if (item.transform.childCount > 0)
                                {
                                    objtoDestroy = item.transform.GetChild(0).gameObject;
                                    isModelPresent = true;
                                }
                            }
                        }
                    }
                    if (objtoDestroy != null)
                    {
                        objtoDestroy.transform.parent = transform;
                    }
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(currentBottomData);
#endif
                    currentBottomData = new EconomyItems();
                    CheckMissingModelAfterRemovingSameModel(modelData, objtoDestroy);

                }
                else
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
                    AvatarBuildHandler.Instance.RemovePart("Outfit");
#endif
                    currentBottomData = modelData;
                    currentOutfitData = new EconomyItems();
                }
            }
            if (modelData.ItemCategory == "Outfit")
            {
                if (currentOutfitData.ID == modelData.ID)
                {
                    GameObject objtoDestroy = null;
                    if (bodyPoints.Count > 0)
                    {
                        foreach (var item in bodyPoints)
                        {
                            if (item.name == bucketname)
                            {
                                if (item.transform.childCount > 0)
                                {
                                    objtoDestroy = item.transform.GetChild(0).gameObject;
                                    isModelPresent = true;
                                }
                            }
                        }
                    }
                    if (objtoDestroy != null)
                    {
                        objtoDestroy.transform.parent = transform;
                    }
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(currentOutfitData);
#endif
                    currentOutfitData = new EconomyItems();
                    CheckMissingModelAfterRemovingSameModel(modelData, objtoDestroy);


                }
                else
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                    currentOutfitData = modelData;
                    currentTopData = new EconomyItems();
                    currentBottomData = new EconomyItems();
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart("Top");
                    AvatarBuildHandler.Instance.RemovePart("Bottom");
#endif
                    if (modelData.ConflictingBuckets.buckets.Find(f => f.name == "lowerbody_foot_both") != null)
                    {
#if DEMO_AVATARYUG
                        AvatarBuildHandler.Instance.RemovePart("Footwear");
#endif
                    }
                }
            }
            if (modelData.ItemCategory == "Footwear")
            {
                if (currentFootwearData.ID == modelData.ID)
                {
                    GameObject objtoDestroy = null;
                    if (bodyPoints.Count > 0)
                    {
                        foreach (var item in bodyPoints)
                        {
                            if (item.name == bucketname)
                            {
                                if (item.transform.childCount > 0)
                                {
                                    objtoDestroy = item.transform.GetChild(0).gameObject;
                                    isModelPresent = true;
                                }
                            }
                        }
                    }
                    if (objtoDestroy != null)
                    {
                        objtoDestroy.transform.parent = transform;
                    }

#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(currentFootwearData);
#endif
                    currentFootwearData = new EconomyItems();
                    CheckMissingModelAfterRemovingSameModel(modelData, objtoDestroy);

                }
                else
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                    currentFootwearData = modelData;

                }
            }
            if (modelData.ItemCategory == "Handwear")
            {
                if (currentHandwearData.ID == modelData.ID)
                {
                    GameObject objtoDestroy = null;
                    if (bodyPoints.Count > 0)
                    {
                        foreach (var item in bodyPoints)
                        {
                            if (item.name == bucketname)
                            {
                                if (item.transform.childCount > 0)
                                {
                                    objtoDestroy = item.transform.GetChild(0).gameObject;
                                    isModelPresent = true;
                                }
                            }
                        }
                    }
                    if (objtoDestroy != null)
                    {
                        objtoDestroy.transform.parent = transform;
                    }
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(currentHandwearData);
#endif
                    currentHandwearData = new EconomyItems();
                    CheckMissingModelAfterRemovingSameModel(modelData, objtoDestroy);
                }
                else
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                    currentHandwearData = modelData;
                }
            }
            if (modelData.ItemCategory == "Wristwear")
            {
                if (currentWristwearData.ID == modelData.ID)
                {
                    GameObject objtoDestroy = null;
                    if (bodyPoints.Count > 0)
                    {
                        foreach (var item in bodyPoints)
                        {
                            if (item.name == bucketname)
                            {
                                if (item.transform.childCount > 0)
                                {
                                    objtoDestroy = item.transform.GetChild(0).gameObject;
                                    isModelPresent = true;
                                }
                            }
                        }
                    }
                    if (objtoDestroy != null)
                    {
                        DestroyImmediate(objtoDestroy);
                    }
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(currentWristwearData);
#endif
                    currentWristwearData = new EconomyItems();
                }
                else
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                    currentWristwearData = modelData;
                }
            }

            await Task.Delay(100);

            if (!isModelPresent)
            {
                ThreeDArtifacts artifacts = JsonUtility.FromJson<ThreeDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                if (artifacts.artifacts.Count > 0)
                {
                    ThreeDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                    ApiEvents.OnApiRequest?.Invoke(null, false);
                    if (artifact != null)
                    {
                        if (!string.IsNullOrEmpty(artifact.url))
                        {
                            FileDownloder.GetByteData(artifact.url, (result) =>
                            {
                                byte[] byteData = ModelDecryptionHandler.GetGlbByte(result);
                                GltfFastLoader.LoadModel(byteData, (obj) =>
                               {
                                   foreach (var item in objToDestroy)
                                   {
                                       DestroyImmediate(item);
                                   }
                                   objToDestroy.Clear();
                                   obj.name = modelData.ID;
                                   AddNetworkBodyPart(obj, modelData, () =>
                                       {
                                           Utility.DelayCall(delayTime, () =>
                                           {
                                               OnLoadQueueModel();
                                           });
                                       });
                               });
                            }, (error) =>
                            {
                                ApiEvents.OnShowTextPopup?.Invoke(null, "Error in download file");
                                Utility.DelayCall(delayTime, () =>
                                {
                                    OnLoadQueueModel();
                                });
                            });
                        }
                        else
                        {
                            ApiEvents.OnShowTextPopup?.Invoke(null, "Data not available");
                            Utility.DelayCall(delayTime, () =>
                            {
                                OnLoadQueueModel();
                            });
                        }
                    }
                    else
                    {
                        ApiEvents.OnShowTextPopup?.Invoke(null, "Data not available");
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
                else
                {
                    ApiEvents.OnShowTextPopup?.Invoke(null, "Data not available");
                    Utility.DelayCall(delayTime, () =>
                    {
                        OnLoadQueueModel();
                    });
                }
            }
            else
            {
                Utility.DelayCall(delayTime, () =>
                {
                    OnLoadQueueModel();
                });
            }
        }

        /// <summary>
        /// This function download eyeball,lip,eyebrow texture
        /// </summary>
        /// <param name="modelData"></param>
        public void LoadHead2dCategory(EconomyItems modelData)
        {
            ApiEvents.OnApiRequest?.Invoke(null, false);
            if (modelData.ItemCategory == "Eyeball")
            {
                bool addnew = true;
                if (!string.IsNullOrEmpty(currentEyeballData.ID))
                {
                    if (currentEyeballData.ID == modelData.ID)
                    {
                        currentEyeballData = new EconomyItems();
                        m_EyeballMaterial.mainTexture = avatarLocalData.eyeballTexture;
                        addnew = false;
#if DEMO_AVATARYUG
                        AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
                if (addnew)
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                    currentEyeballData = modelData;
                    TwoDArtifacts artifacts = JsonUtility.FromJson<TwoDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    if (artifacts.artifacts.Count > 0)
                    {
                        TwoDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        FileDownloder.GetNetworkTexture(artifact.url,
                        (texture) =>
                        {
                            m_EyeballMaterial.mainTexture = texture;
#if DEMO_AVATARYUG
                            EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, texture, null);
#endif
                            Utility.DelayCall(delayTime, () =>
                            {
                                OnLoadQueueModel();
                            });
                        }, (err) => { }, (pr) => { });
                    }
                    else
                    {
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
            }
            if (modelData.ItemCategory == "Lips")
            {
                bool addnew = true;
                if (!string.IsNullOrEmpty(currentLispData.ID))
                {
                    if (currentLispData.ID == modelData.ID)
                    {
                        currentLispData = new EconomyItems();
                        m_HeadMaterial.SetTexture("_LipsTexture", avatarLocalData.DefaultLipTexture);
                        addnew = false;
#if DEMO_AVATARYUG
                        AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
                if (addnew)
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                    currentLispData = modelData;
                    TwoDArtifacts artifacts = JsonUtility.FromJson<TwoDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    if (artifacts.artifacts.Count > 0)
                    {
                        TwoDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        ApiEvents.OnApiRequest?.Invoke(null, false);
                        FileDownloder.GetNetworkTexture(artifact.url,
                        (texture) =>
                        {
#if DEMO_AVATARYUG
                            EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, texture, null);
#endif
                            m_HeadMaterial.SetTexture("_LipsTexture", texture);
                            Utility.DelayCall(delayTime, () =>
                            {
                                OnLoadQueueModel();
                            });

                        }, (err) => { }, (pr) => { });
                    }
                    else
                    {
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
            }
            if (modelData.ItemCategory == "Eyebrow")
            {
                bool addnew = true;
                if (!string.IsNullOrEmpty(currentEyebrowData.ID))
                {
                    if (currentEyebrowData.ID == modelData.ID)
                    {
                        currentEyebrowData = new EconomyItems();
                        m_HeadMaterial.SetTexture("_EyebrowTexture", avatarLocalData.DefaultEyebrowTexture);
                        addnew = false;
#if DEMO_AVATARYUG
                        AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
                if (addnew)
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                    currentEyebrowData = modelData;
                    TwoDArtifacts artifacts = JsonUtility.FromJson<TwoDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    if (artifacts.artifacts.Count > 0)
                    {
                        TwoDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        FileDownloder.GetNetworkTexture(artifact.url,
                        (texture) =>
                        {
#if DEMO_AVATARYUG
                            EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, texture, null);
#endif
                            m_HeadMaterial.SetTexture("_EyebrowTexture", texture);
                            Utility.DelayCall(delayTime, () =>
                            {
                                OnLoadQueueModel();
                            });
                        },
                        (err) => { }, (pr) => { });
                    }
                    else
                    {
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }
                }
            }
        }


        /// <summary>
        /// After model download delete conflict model and add model to its bucket
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelData"></param>
        /// <param name="onComplete"></param>
        void AddNetworkBodyPart(GameObject model, EconomyItems modelData, Action onComplete)
        {
            List<GameObject> objToDestroy = new List<GameObject>();
            string[] bucket = modelData.CoreBucket.Split('/');
            string bucketname = bucket[0];
            if (bucket.Length > 1)
            {
                bucketname = bucket[1];
            }

            if (bodyPoints.Count > 0)
            {
                foreach (var item in bodyPoints)
                {
                    if (item.name == bucketname)
                    {
                        if (item.transform.childCount > 0)
                        {
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.AddCurrentBodyPartWithid(new EconomyItems() { ID = item.transform.GetChild(0).gameObject.name });
#endif
                            objToDestroy.Add(item.transform.GetChild(0).gameObject);
                            break;
                        }
                    }
                }
            }

            if (modelData.ConflictingBuckets != null)
            {
                ConflictingBuckets conflits = modelData.ConflictingBuckets;

                for (int i = 0; i < bodyPoints.Count; i++)
                {
                    for (int j = 0; j < conflits.buckets.Count; j++)
                    {
                        if (bodyPoints[i].name == conflits.buckets[j].name)
                        {
                            if (bodyPoints[i].transform.childCount > 0)
                            {
                                objToDestroy.Add(bodyPoints[i].transform.GetChild(0).gameObject);
                            }
                        }
                    }
                }
            }

            bool isPrensent = false;
            GameObject ppin = null;
            if (bodyPoints.Count > 0)
            {
                foreach (var item in bodyPoints)
                {
                    if (item.name == bucketname)
                    {
                        ppin = item;
                        isPrensent = true;
                        break;
                    }
                }
            }
            if (!isPrensent)
            {
                if (modelData.ItemCategory == "Wristwear")
                {
                    BodywearPointDetail bone = LocalBodyPointList.bodywearPointDetails.Find(f => f.pointName == bucketname);

                    GameObject bodyBone = null;
                    Transform[] headChild = headModelScript.transform.GetComponentsInChildren<Transform>();
                    foreach (var item in headChild)
                    {
                        if (item.name == "mixamorig:" + bone.boneName || item.name == bone.boneName)
                        {
                            bodyBone = item.gameObject;
                        }
                    }

                    GameObject gObject = new GameObject
                    {
                        name = bone.pointName
                    };

                    bodyPoints.Add(gObject);

                    gObject.transform.SetParent(bodyBone.transform);
                    gObject.transform.localEulerAngles = bone.Rotation;
                    gObject.transform.localPosition = bone.Position;
                    ppin = gObject;
                }
                else
                {
                    GameObject gObject = new GameObject();
                    gObject.transform.parent = transform;
                    gObject.name = bucketname;
                    bodyPoints.Add(gObject);
                    ppin = gObject;
                    ppin.transform.localEulerAngles = Vector3.zero;
                    ppin.transform.localPosition = Vector3.zero;

                }
            }
            if (modelData.ItemCategory != "Wristwear")
            {
                ApiEvents.OnApiRequest?.Invoke(null, false);
                BodyMaterialHandler bodyTexture = model.AddComponent<BodyMaterialHandler>();
                bodyTexture.bodyMaterial = m_BodyMaterial;
                bodyTexture.Initialize();
                model.name = modelData.ID;

                model.gameObject.name = modelData.ID;
                model.transform.SetParent(ppin.transform);
                model.transform.localPosition = Vector3.zero;
                model.transform.localEulerAngles = Vector3.zero;

                AfterFileImport(model, 0);
            }

            else
            {
                model.name = modelData.ID;
                model.gameObject.name = modelData.ID;
                model.transform.SetParent(ppin.transform);
                model.transform.localPosition = Vector3.zero;
                model.transform.localEulerAngles = Vector3.zero;

            }
            model.name = modelData.ID;
            if (objToDestroy.Count > 0)
            {
                foreach (var item in objToDestroy)
                {
                    DestroyImmediate(item);
                }
            }
            objToDestroy.Clear();
            onComplete?.Invoke();
            CheckMissingAfterModelLoad(modelData);
        }

        /// <summary>
        /// Reset Hair model blendshpae
        /// </summary>
        public void ResetHairBlendshape()
        {
            if (HairModel != null)
            {
                HairModel.SetActive(true);
                SkinnedMeshRenderer blendShapes = HairModel.GetComponentInChildren<SkinnedMeshRenderer>();
                for (int a = 0; a < blendShapes.sharedMesh.blendShapeCount; a++)
                {
                    blendShapes.SetBlendShapeWeight(a, 0);
                }
                if (HeadwearModel == null)
                {
                    HeadCoreBuck = "";
                }
            }
        }

        /// <summary>
        /// This function clear all data and set to default data
        /// </summary>
        /// <param name="OnComplete"></param>
        public void ResetToDefaultData(Action OnComplete = null)
        {
#if DEMO_AVATARYUG
            AvatarBuildHandler.Instance.currentSelectedBodyParts.Clear();
#endif
            avatarLocalData = Resources.Load<AvatarLocalData>("AvatarLocalData");

            BodyTypeData myDeserializedClass = JsonConvert.DeserializeObject<BodyTypeData>(avatarLocalData.bodyTypeData.text);
#if DEMO_AVATARYUG
            CurrentAvatarChanges.Instance.currentBodyType = myDeserializedClass.Data.BodyTypes[0];
#endif
            currentBodyType = myDeserializedClass.Data.BodyTypes[0];
            HeadCoreBuck = "";
            m_HeadMaterial.SetTexture("_TatooTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_BeardTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_EyebrowTexture", avatarLocalData.DefaultEyebrowTexture);
            m_HeadMaterial.SetTexture("_LipsTexture", avatarLocalData.DefaultLipTexture);
            m_HeadMaterial.SetTexture("_MainTex", avatarLocalData.baseSkinTexture);
            m_EyeballMaterial.SetTexture("_MainTex", avatarLocalData.eyeballTexture);
            m_HeadMaterial.SetColor("_EyebrowColor", Utility.GetColor(avatarLocalData.DefaultEyebrowColor));
            switch (GetGender())
            {
                case Gender.Male:
                    m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(avatarLocalData.DefaultMaleLipColor));
                    break;
                case Gender.Female:
                    m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(avatarLocalData.DefaultLipColor));
                    break;
            }
            m_HeadMaterial.SetColor("_HairColor", Utility.GetColor(avatarLocalData.DefaultHairColor));
            m_HeadMaterial.SetColor("_BeardColor", Utility.GetColor(avatarLocalData.DefaultFacialHairColor));
            m_BodyMaterial.SetTexture("_MainTex", avatarLocalData.bodyTexture);
            for (int i = 0; i < AvataryugData.bodytattos.Count; i++)
            {
                m_BodyMaterial.SetTexture("_" + AvataryugData.bodytattos[i], avatarLocalData.empty);
            }
            lastLoadedTattoos.Clear();
            currentTopData = new EconomyItems();
            currentWristwearData = new EconomyItems();
            currentBottomData = new EconomyItems();
            currentOutfitData = new EconomyItems();
            currentFootwearData = new EconomyItems();
            currentHandwearData = new EconomyItems();
            currentLispData = new EconomyItems();
            currentfacialHairData = new EconomyItems();
            currentEyeballData = new EconomyItems();
            currentEyebrowData = new EconomyItems();
            currentHairData = new EconomyItems();
            currentHadwearData = new EconomyItems();
            currentFaceshapeData = new EconomyItems();
            currentEarshapeData = new EconomyItems();
            currentNoseshapeData = new EconomyItems();
            currentEyebrowshapeData = new EconomyItems();
            currentEyeshapeData = new EconomyItems();
            currentLipshapeData = new EconomyItems();
            currentskintoneData = new EconomyItems();
#if DEMO_AVATARYUG

            CurrentAvatarChanges.Instance.changePropColors = new PropColors();
            CurrentAvatarChanges.Instance.changeblendShapes = new List<Blendshape>();
            CurrentAvatarChanges.Instance.changedProps = new Props();

            CurrentAvatarChanges.Instance.changePropColors.EyebrowColor = avatarLocalData.DefaultEyebrowColor;
            CurrentAvatarChanges.Instance.changePropColors.HairColor = avatarLocalData.DefaultHairColor;
            CurrentAvatarChanges.Instance.changePropColors.FacialHairColor = avatarLocalData.DefaultFacialHairColor;
            CurrentAvatarChanges.Instance.changePropColors.LipColor = avatarLocalData.DefaultLipColor;

            UndoHandler.Instance.RecordedActions.Clear();
#endif
            ApiEvents.OnApiResponce?.Invoke(null, null);
            OnComplete?.Invoke();
        }

        /// <summary>
        /// This function load current selected avatar model
        /// </summary>
        /// <param name="oncomplete"></param>
        public void ResetToCurrentSelectedModel(Action oncomplete)
        {
            OnResetToCurrent = oncomplete;
            isResetToCurrent = true;

            ResetToDefault(() =>
            {
                ApiEvents.OnApiLoadingShow?.Invoke(null, new LoadingClass() { Message = "Loading customize avatar", ShowWarning = true });
                ApiEvents.OnApiRequest?.Invoke(null, false);
                networkModelQueue = new List<EconomyItems>();
#if DEMO_AVATARYUG

                CurrentAvatarChanges.Instance.changePropColors.HairColor = CurrentAvatarChanges.Instance.currentpropColors.HairColor;
                CurrentAvatarChanges.Instance.changePropColors.FacialHairColor = CurrentAvatarChanges.Instance.currentpropColors.FacialHairColor;
                CurrentAvatarChanges.Instance.changePropColors.LipColor = CurrentAvatarChanges.Instance.currentpropColors.LipColor;
                CurrentAvatarChanges.Instance.changePropColors.EyebrowColor = CurrentAvatarChanges.Instance.currentpropColors.EyebrowColor;
                CurrentAvatarChanges.Instance.changedBodyType = CurrentAvatarChanges.Instance.currentBodyType;
                CurrentAvatarChanges.Instance.changeblendShapes = new List<Blendshape>();

                foreach (var item in CurrentAvatarChanges.Instance.currentblendShapes)
                {
                    headModelScript.SetBlendShape(item);
                    CurrentAvatarChanges.Instance.changeblendShapes.Add(item);
                }

                foreach (var item in CurrentAvatarChanges.Instance.currentProps.props)
                {
                    var data = EconomyItemHolder.Instance.GetEconomyItemWithId(item.ID);
                    networkModelQueue.Add(data);
                }
                ApiEvents.UpdateUiAfterChanges?.Invoke(null, null);
#endif
                OnLoadQueueModel();
            });
        }

        /// <summary>
        /// This function remove selected model and reset to default model
        /// </summary>
        /// <param name="OnComplete"></param>
        public void ResetToDefault(Action OnComplete = null)
        {
            ApiEvents.OnApiRequest?.Invoke(null, false);
#if DEMO_AVATARYUG
            AvatarBuildHandler.Instance.currentSelectedBodyParts.Clear();
            AvatarBuildHandler.Instance.currentSelectedProp = new EconomyItems();
#endif
            avatarLocalData = Resources.Load<AvatarLocalData>("AvatarLocalData");
            BodyTypeData myDeserializedClass = JsonConvert.DeserializeObject<BodyTypeData>(avatarLocalData.bodyTypeData.text);
            currentBodyType = myDeserializedClass.Data.BodyTypes[0];
#if DEMO_AVATARYUG
            CurrentAvatarChanges.Instance.currentBodyType = myDeserializedClass.Data.BodyTypes[0];
#endif
            HeadCoreBuck = "";
            m_HeadMaterial.SetTexture("_TatooTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_BeardTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_EyebrowTexture", avatarLocalData.DefaultEyebrowTexture);
            m_HeadMaterial.SetTexture("_LipsTexture", avatarLocalData.DefaultLipTexture);
            m_EyeballMaterial.SetTexture("_MainTex", avatarLocalData.eyeballTexture);

            m_HeadMaterial.SetColor("_EyebrowColor", Utility.GetColor(avatarLocalData.DefaultEyebrowColor));
            switch (GetGender())
            {
                case Gender.Male:
                    m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(avatarLocalData.DefaultMaleLipColor));
                    break;
                case Gender.Female:
                    m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(avatarLocalData.DefaultLipColor));
                    break;
            }
            m_HeadMaterial.SetColor("_HairColor", Utility.GetColor(avatarLocalData.DefaultHairColor));
            m_HeadMaterial.SetColor("_BeardColor", Utility.GetColor(avatarLocalData.DefaultFacialHairColor));

            for (int i = 0; i < AvataryugData.bodytattos.Count; i++)
            {
                m_BodyMaterial.SetTexture("_" + AvataryugData.bodytattos[i], avatarLocalData.empty);
            }
            lastLoadedTattoos.Clear();
            currentTopData = new EconomyItems();
            currentWristwearData = new EconomyItems();
            currentBottomData = new EconomyItems();
            currentOutfitData = new EconomyItems();
            currentFootwearData = new EconomyItems();
            currentHandwearData = new EconomyItems();
            currentLispData = new EconomyItems();
            currentfacialHairData = new EconomyItems();
            currentEyeballData = new EconomyItems();
            currentEyebrowData = new EconomyItems();
            currentHairData = new EconomyItems();
            currentHadwearData = new EconomyItems();
            currentFaceshapeData = new EconomyItems();
            currentEarshapeData = new EconomyItems();
            currentNoseshapeData = new EconomyItems();
            currentEyebrowshapeData = new EconomyItems();
            currentEyeshapeData = new EconomyItems();
            currentLipshapeData = new EconomyItems();
            currentskintoneData = new EconomyItems();

#if DEMO_AVATARYUG

            CurrentAvatarChanges.Instance.changePropColors = new PropColors();
            CurrentAvatarChanges.Instance.changeblendShapes = new List<Blendshape>();
            CurrentAvatarChanges.Instance.changedProps = new Props();

            CurrentAvatarChanges.Instance.changePropColors.EyebrowColor = avatarLocalData.DefaultEyebrowColor;
            CurrentAvatarChanges.Instance.changePropColors.HairColor = avatarLocalData.DefaultHairColor;
            CurrentAvatarChanges.Instance.changePropColors.FacialHairColor = avatarLocalData.DefaultFacialHairColor;
            CurrentAvatarChanges.Instance.changePropColors.LipColor = avatarLocalData.DefaultLipColor;

            UndoHandler.Instance.RecordedActions.Clear();
#endif
            if (bodyPoints.Count > 0)
            {
                foreach (var item in bodyPoints)
                {
                    if (item.transform.childCount > 0)
                    {
                        DestroyImmediate(item.transform.GetChild(0).gameObject);
                    }
                }
            }
            for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
            {
                if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                {
                    DestroyImmediate(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                }
            }
            for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
            {
                string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                headModelScript.SetBlendShape(new Blendshape() { shapekeys = blendshapename, value = 0 });
                if (facialHairScript != null)
                {
                    facialHairScript.SetBlendshape(blendshapename, 0);
                }
            }
            for (int i = 0; i < DefaultAvatarData.GetDefaultModelList(GetGender()).Count; i++)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[i]);
            }
            OnLoadQueueDefaultModel(() =>
            {
                ApiEvents.OnApiResponce?.Invoke(null, null);
                OnComplete?.Invoke();
            });
        }

        /// <summary>
        /// This function Check queue list is empty or not and load model
        /// </summary>
        public void OnLoadQueueModel()
        {
            if (networkModelQueue.Count > 0)
            {
                EconomyItems modelData = networkModelQueue[0];
                networkModelQueue.RemoveAt(0);
                DownloadNetworkModel(modelData);
#if DEMO_AVATARYUG
                AvatarBuildHandler.Instance.currentSelectedProp = modelData;
#endif
                Utility.ClearCatche();
            }
            else
            {
                Utility.DelayCall(500, () =>
                {
                    if (isResetToCurrent)
                    {
                        isResetToCurrent = false;
                        OnResetToCurrent?.Invoke();
                    }
                    ApiEvents.OnApiResponce?.Invoke(null, null);
                });
            }
        }

        /// <summary>
        /// This function change face blendshapes
        /// </summary>
        /// <param name="modelData"></param>
        public void LoadBlendshape(EconomyItems modelData)
        {
            if (modelData.DisplayName == "Custom")
            {
                OnLoadQueueModel();
            }
            else
            {
                if (headModelScript != null && headModelScript.headRenderer != null)
                {

                    if (modelData.ItemCategory == "FaceShape")
                    {

                        for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
                        {
                            string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                            if (blendshapename.Contains("Face_"))
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(new BlendShapeValue() { shapekeys = blendshapename, sliderValue = 0 });
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = blendshapename, value = 0 });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(blendshapename, 0);
                                }
                            }
                        }
                        if (currentFaceshapeData.ID == modelData.ID)
                        {
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.RemovePart(modelData.ItemCategory);
#endif
                            currentFaceshapeData = new EconomyItems();

                        }
                        else
                        {
                            currentFaceshapeData = modelData;
                            if (facialHairScript != null)
                            {
                                facialHairScript.Clearshape();
                            }
                            foreach (var item in modelData.BlendshapeKeys.blendShapes)
                            {
#if DEMO_AVATARYUG

                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(item);
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = item.shapekeys, value = item.sliderValue });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(item.shapekeys, item.sliderValue);
                                }
                            }
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                        }
                    }

                    if (modelData.ItemCategory == "EyeShape")
                    {
                        for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
                        {
                            string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                            if (blendshapename.Contains("Eyeshape_") || blendshapename.Contains("Iris") || blendshapename.Contains("Pupil"))
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(new BlendShapeValue() { shapekeys = blendshapename, sliderValue = 0 });
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = blendshapename, value = 0 });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(blendshapename, 0);
                                }
                            }
                        }

                        if (currentEyeshapeData.ID == modelData.ID)
                        {
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.RemovePart(modelData.ItemCategory);
#endif
                            currentEyeshapeData = new EconomyItems();
                        }
                        else
                        {
                            currentEyeshapeData = modelData;
                            if (facialHairScript != null)
                            {
                                facialHairScript.Clearshape();
                            }
                            foreach (var item in modelData.BlendshapeKeys.blendShapes)
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(item);
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = item.shapekeys, value = item.sliderValue });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(item.shapekeys, item.sliderValue);
                                }
                            }
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                        }
                    }

                    if (modelData.ItemCategory == "EyebrowShape")
                    {
                        for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
                        {
                            string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                            if (blendshapename.Contains("Eyebrows_"))
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(new BlendShapeValue() { shapekeys = blendshapename, sliderValue = 0 });
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = blendshapename, value = 0 });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(blendshapename, 0);
                                }

                            }
                        }

                        if (currentEyebrowshapeData.ID == modelData.ID)
                        {
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.RemovePart(modelData.ItemCategory);
#endif
                            currentEyebrowshapeData = new EconomyItems();
                        }
                        else
                        {
                            currentEyebrowshapeData = modelData;
                            if (facialHairScript != null)
                            {
                                facialHairScript.Clearshape();
                            }
                            foreach (var item in modelData.BlendshapeKeys.blendShapes)
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(item);
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = item.shapekeys, value = item.sliderValue });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(item.shapekeys, item.sliderValue);
                                }
                            }
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                        }
                    }

                    if (modelData.ItemCategory == "NoseShape")
                    {
                        for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
                        {
                            string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                            if (blendshapename.Contains("Nose_"))
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(new BlendShapeValue() { shapekeys = blendshapename, sliderValue = 0 });
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = blendshapename, value = 0 });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(blendshapename, 0);
                                }
                            }
                        }

                        if (currentNoseshapeData.ID == modelData.ID)
                        {
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.RemovePart(modelData.ItemCategory);
#endif
                            currentNoseshapeData = new EconomyItems();
                        }
                        else
                        {
                            currentNoseshapeData = modelData;
                            if (facialHairScript != null)
                            {
                                facialHairScript.Clearshape();
                            }
                            foreach (var item in modelData.BlendshapeKeys.blendShapes)
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(item);
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = item.shapekeys, value = item.sliderValue });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(item.shapekeys, item.sliderValue);
                                }
                            }
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                        }
                    }

                    if (modelData.ItemCategory == "LipShape")
                    {
                        for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
                        {
                            string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                            if (blendshapename.Contains("Lips_"))
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(new BlendShapeValue() { shapekeys = blendshapename, sliderValue = 0 });
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = blendshapename, value = 0 });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(blendshapename, 0);
                                }
                            }
                        }
                        if (currentLipshapeData.ID == modelData.ID)
                        {
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.RemovePart(modelData.ItemCategory);
#endif
                            currentLipshapeData = new EconomyItems();
                        }
                        else
                        {
                            currentLipshapeData = modelData;
                            if (facialHairScript != null)
                            {
                                facialHairScript.Clearshape();
                            }
                            foreach (var item in modelData.BlendshapeKeys.blendShapes)
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(item);
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = item.shapekeys, value = item.sliderValue });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(item.shapekeys, item.sliderValue);
                                }
                            }
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                        }
                    }

                    if (modelData.ItemCategory == "EarShape")
                    {
                        for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
                        {
                            string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                            if (blendshapename.Contains("Ears_"))
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(new BlendShapeValue() { shapekeys = blendshapename, sliderValue = 0 });
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = blendshapename, value = 0 });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(blendshapename, 0);
                                }
                            }
                        }
                        if (currentEarshapeData.ID == modelData.ID)
                        {
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.RemovePart(modelData.ItemCategory);
#endif
                            currentEarshapeData = new EconomyItems();
                        }
                        else
                        {
                            currentEarshapeData = modelData;
                            if (facialHairScript != null)
                            {
                                facialHairScript.Clearshape();
                            }
                            foreach (var item in modelData.BlendshapeKeys.blendShapes)
                            {
#if DEMO_AVATARYUG
                                CurrentAvatarChanges.Instance.ChangeBlendshapevalue(item);
#endif
                                headModelScript.SetBlendShape(new Blendshape() { shapekeys = item.shapekeys, value = item.sliderValue });
                                if (facialHairScript != null)
                                {
                                    facialHairScript.SetBlendshape(item.shapekeys, item.sliderValue);
                                }
                            }
#if DEMO_AVATARYUG
                            AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif

                        }
                    }
                    Utility.DelayCall(delayTime, () =>
                    {
                        OnLoadQueueModel();
                    });
                }
            }
        }

        /// <summary>
        /// This function compare which type of model to load
        /// </summary>
        /// <param name="modelData"></param>
        public void DownloadNetworkModel(EconomyItems modelData)
        {
            if (modelData.ItemCategory == "SkinTone")
            {
                LoadSkintone(modelData);
            }
            else if (AvataryugData.IsBodyPartCategory(modelData.ItemCategory))
            {
                LoadBodyPart(modelData);
            }
            else if (AvataryugData.IsBodyTattooCategory(modelData.ItemCategory))
            {
                DownloadTattoos(modelData);
            }
            else if (AvataryugData.IsFacewearAccessary(modelData.ItemCategory))
            {
                headModelScript?.UpdateFacePoints();
                LoadFacewearAccessary(modelData);
            }
            else if (AvataryugData.IsHead2DCategoty(modelData.ItemCategory))
            {
                LoadHead2dCategory(modelData);
            }
            else if (AvataryugData.IsHeadCategoty(modelData.ItemCategory))
            {
                headModelScript?.UpdateFacePoints();

                if (modelData.ItemCategory == "Hair")
                {
                    LoadHair(modelData);
                }
                else if (modelData.ItemCategory == "Facialhair")
                {
                    LoadFacialhair(modelData);
                }
                else
                {
                    LoadFaceAccessary(modelData);
                }
            }
            else if (AvataryugData.IsBlendshapeCategory(modelData.ItemCategory))
            {
                LoadBlendshape(modelData);
            }
            else
            {
                OnLoadQueueModel();
            }
        }
        /// <summary>
        /// This function load face related models
        /// </summary>
        /// <param name="modelData"></param>
        public void LoadFacewearAccessary(EconomyItems modelData)
        {
            string[] buc = modelData.CoreBucket.Split('/');
            string bucketname = buc[0];
            if (buc.Length > 1)
            {
                bucketname = buc[1];
            }
            bool isModelPresent = false;

            if (headModelScript != null)
            {
                for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                {
                    if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                    {
                        if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                        {
                            if (headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).name.Contains(modelData.ID))
                            {
                                isModelPresent = true;
                                Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                break;
                            }
                        }
                    }
                }

                if (isModelPresent)
                {
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                    Utility.DelayCall(delayTime, () =>
                    {
                        OnLoadQueueModel();
                    });
                }
                if (!isModelPresent)
                {
                    if (modelData.ConflictingBuckets != null)
                    {
                        ConflictingBuckets conflits = modelData.ConflictingBuckets;

                        for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                        {
                            for (int j = 0; j < conflits.buckets.Count; j++)
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == conflits.buckets[j].name.ToLower())
                                {
                                    if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                                    {
                                        var objname = headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).name.Split('+');
                                        string id = "";
                                        if (objname.Length > 0)
                                        {
                                            id = objname[1];
                                        }
#if DEMO_AVATARYUG
                                        AvatarBuildHandler.Instance.RemovePart(new EconomyItems() { ID = id });
#endif
                                        Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                    }
                                }
                            }
                            if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                                {
                                    var objname = headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).name.Split('+');
                                    string id = "";
                                    if (objname.Length > 0)
                                    {
                                        id = objname[1];
                                    }
#if DEMO_AVATARYUG
                                    AvatarBuildHandler.Instance.RemovePart(new EconomyItems() { ID = id });
#endif
                                    Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                }
                            }
                        }
                    }
                    ThreeDArtifacts artifacts = JsonUtility.FromJson<ThreeDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    if (artifacts.artifacts.Count > 0)
                    {
                        ThreeDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        if (artifacts != null)
                        {
                            if (!string.IsNullOrWhiteSpace(artifact.url))
                            {
#if DEMO_AVATARYUG
                                AvatarBuildHandler.Instance.AddCurrentBodyPartWithid(modelData);
#endif
                                FileDownloder.GetByteData(artifact.url, (result) =>
                                {
                                    GltfFastLoader.LoadModel(ModelDecryptionHandler.GetGlbByte(result), (obj) =>
                                    {
                                        for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                                        {
                                            if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                                            {
                                                obj.transform.parent = headModelScript.m_VertexPointerData[i].pointTransform;
                                                obj.transform.localEulerAngles = Vector3.zero;
                                                obj.transform.localPosition = Vector3.zero;
                                                obj.name = bucketname + "+" + modelData.ID;
                                            }
                                        }


                                        if (modelData.ItemCategory == "Facewear")
                                        {
                                            if (HeadwearModel == null)
                                            {
                                                ResetHairBlendshape();
                                                HeadCoreBuck = "";
                                            }
                                            else
                                            {
                                                Debug.Log("HeadWear IS Present ");
                                            }
                                        }

                                        Utility.DelayCall(delayTime, () =>
                                        {
                                            OnLoadQueueModel();
                                        });
                                    });
                                }, (error) => { Debug.LogError(error); });
                            }
                            else
                            {
                                Utility.DelayCall(delayTime, () =>
                                {
                                    OnLoadQueueModel();
                                });
                                ApiEvents.OnShowTextPopup?.Invoke(null, "Artifact model not available");
                            }
                        }

                    }
                    else
                    {
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                        ApiEvents.OnShowTextPopup?.Invoke(null, "Artifact model not available");
                    }
                }
            }
        }

        /// <summary>
        /// This function load face related models
        /// </summary>
        /// <param name="modelData"></param>
        public void LoadFaceAccessary(EconomyItems modelData)
        {
            if (modelData.ItemCategory == "Hair" || modelData.ItemCategory == "Headwear")
            {
                ResetHairBlendshape();
            }

            string[] buc = modelData.CoreBucket.Split('/');
            string bucketname = buc[0];
            if (buc.Length > 1)
            {
                bucketname = buc[1];
            }
            bool isModelPresent = false;
            if (headModelScript != null)
            {
                for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                {
                    if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                    {
                        if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                        {
                            if (headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).name.Contains(modelData.ID))
                            {
                                isModelPresent = true;

                                if (modelData.ItemCategory == "Headwear")
                                {
                                    if (this.HairModel != null)
                                    {
                                        HairModel.SetActive(true);

                                    }
                                }
                                if (this.HeadwearModel != null)
                                {
                                    if (this.HeadwearModel == headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0))
                                    {
                                        this.HeadCoreBuck = "";
                                    }
                                }
                                if (modelData.ItemCategory == "Hair")
                                {
                                    currentHairData = new EconomyItems(); ;
                                    m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
                                }

                                if (modelData.ItemCategory == "Facialhair")
                                {
                                    m_HeadMaterial.SetTexture("_BeardTexture", avatarLocalData.empty);
                                }

                                if (modelData.ItemCategory == "Headwear")
                                {
                                    currentHadwearData = new EconomyItems();
                                }
                                Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                break;
                            }
                        }

                    }
                }

                if (isModelPresent)
                {
                    if (modelData.ItemCategory == "Headwear")
                    {
                        HeadCoreBuck = "";
                        ResetHairBlendshape();
                    }
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                    Utility.DelayCall(delayTime, () =>
                    {
                        OnLoadQueueModel();
                    });
                }
                if (!isModelPresent)
                {

                    if (modelData.ConflictingBuckets != null)
                    {
                        ConflictingBuckets conflits = modelData.ConflictingBuckets;

                        for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                        {
                            for (int j = 0; j < conflits.buckets.Count; j++)
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == conflits.buckets[j].name.ToLower())
                                {
                                    if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                                    {
                                        Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                        if (bucketname == "hair")
                                        {
                                            m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
                                        }
                                    }
                                }
                            }
                            if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                                {
                                    Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                    if (bucketname == "hair")
                                    {
                                        m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
                                    }
                                }
                            }
                        }
                    }
                    ThreeDArtifacts artifacts = JsonUtility.FromJson<ThreeDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    if (artifacts.artifacts.Count > 0)
                    {
                        ThreeDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        if (artifacts != null)
                        {
                            if (!string.IsNullOrWhiteSpace(artifact.url))
                            {
#if DEMO_AVATARYUG
                                AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                                FileDownloder.GetByteData(artifact.url, (result) =>
                                {
                                    GltfFastLoader.LoadModel(ModelDecryptionHandler.GetGlbByte(result), (obj) =>
                                    {
                                        for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                                        {
                                            if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                                            {
                                                obj.transform.parent = headModelScript.m_VertexPointerData[i].pointTransform;
                                                obj.transform.localEulerAngles = Vector3.zero;
                                                obj.transform.localPosition = Vector3.zero;
                                                obj.name = bucketname + "+" + modelData.ID;
                                            }
                                        }

                                        if (modelData.ItemCategory == "Headwear")
                                        {
                                            HeadwearModel = obj;
                                            HeadCoreBuck = bucketname;
                                            if (HairModel != null)
                                            {
                                                bool blendBucket = false;
                                                SkinnedMeshRenderer blendShapes = HairModel.GetComponentInChildren<SkinnedMeshRenderer>();
                                                for (int a = 0; a < blendShapes.sharedMesh.blendShapeCount; a++)
                                                {
                                                    if (bucketname.Contains(blendShapes.sharedMesh.GetBlendShapeName(a)))
                                                    {
                                                        blendBucket = true;
                                                        blendShapes.SetBlendShapeWeight(a, 1.0f);
                                                    }
                                                }
                                                if (!blendBucket)
                                                {
                                                    HairModel.SetActive(false);
                                                }
                                            }
                                            currentHadwearData = modelData;
                                        }
                                        if (modelData.ItemCategory == "Hair")
                                        {
                                            if (modelData.Config.isTwoD == 1)
                                            {
                                                obj.SetActive(false);
                                                Texture texture = obj.GetComponentInChildren<MeshRenderer>().material.mainTexture;
                                                m_HeadMaterial.SetTexture("_HairTexture", texture);
                                                m_HeadMaterial.SetColor("_HairColor", avatarLocalData.HairMaterial.GetColor("_Color"));
#if DEMO_AVATARYUG
                                                EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, (Texture)texture, null);
#endif
                                            }
                                            else
                                            {
                                                HairMaterialHandler bodyMaterial = obj.AddComponent<HairMaterialHandler>();
                                                bodyMaterial.customizeAvatarLoader = customizeAvatarLoader;
                                                bodyMaterial.hairMaterial = avatarLocalData.HairMaterial;
                                                bodyMaterial.Category = modelData.ItemCategory;
                                                bodyMaterial.SetData();
                                                currentHairData = modelData;
                                                SkinnedMeshRenderer blendName = obj.GetComponentInChildren<SkinnedMeshRenderer>();
                                                if (blendName != null)
                                                {
                                                    if (blendName.sharedMesh.blendShapeCount > 0)
                                                    {
                                                        HairModel = obj;
                                                    }

                                                    for (int a = 0; a < blendName.sharedMesh.blendShapeCount; a++)
                                                    {

                                                        if (HeadCoreBuck.Contains(blendName.sharedMesh.GetBlendShapeName(a)))
                                                        {
                                                            blendName.SetBlendShapeWeight(a, 1.0f);
                                                        }
                                                        else
                                                        {
                                                            //  Debug.Log("Checking Hair Data======>>Headgear Conflict DAta IS EMPTY");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (modelData.ItemCategory == "Facewear")
                                        {
                                            if (HeadwearModel == null)
                                            {
                                                ResetHairBlendshape();
                                                HeadCoreBuck = "";
                                            }
                                            else
                                            {
                                                Debug.Log("HeadWear IS Present ");
                                            }
                                        }

                                        if (modelData.ItemCategory == "Facialhair")
                                        {
                                            if (modelData.Config.isTwoD == 1)
                                            {
                                                obj.SetActive(false);
                                                Texture texture = obj.GetComponentInChildren<MeshRenderer>().material.mainTexture;
#if DEMO_AVATARYUG
                                                EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, (Texture)texture, null);
#endif
                                                m_HeadMaterial.SetTexture("_BeardTexture", texture);
                                                string currentColor = customizeAvatarLoader.avatarLocalData.DefaultFacialHairColor;
#if DEMO_AVATARYUG
                                                currentColor = CurrentAvatarChanges.Instance.changePropColors.FacialHairColor;
#endif
                                                if (ColorUtility.TryParseHtmlString(currentColor, out Color color1))
                                                {
                                                    m_HeadMaterial.SetColor("_BeardColor", color1);
                                                }
                                            }
                                            else
                                            {
                                                facialHairScript = obj.AddComponent<FacialHair>();
                                                facialHairScript.customizeAvatarLoader = customizeAvatarLoader;
                                                facialHairScript.Initialize();
                                                m_HeadMaterial.SetTexture("_BeardTexture", avatarLocalData.empty);
                                                currentfacialHairData = modelData;
                                            }
                                        }

                                        Utility.DelayCall(delayTime, () =>
                                        {
                                            OnLoadQueueModel();
                                        });
                                    });
                                }, (error) => { Debug.LogError(error); });
                            }
                            else
                            {
                                Utility.DelayCall(delayTime, () =>
                                {
                                    OnLoadQueueModel();
                                });
                                ApiEvents.OnShowTextPopup?.Invoke(null, "Artifact model not available");
                            }
                        }

                    }
                    else
                    {
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                        ApiEvents.OnShowTextPopup?.Invoke(null, "Artifact model not available");
                    }
                }
            }
        }


        /// <summary>
        /// Load Head model
        /// </summary>
        /// <param name="OnComplete"></param>
        public void LoadHeadModel(Action OnComplete)
        {
            ApiEvents.OnApiRequest?.Invoke(null, false);
            if (headModelScript == null)
            {
                if (loadLocal)
                {
                    ApiEvents.OnApiRequest?.Invoke(null, false);
                    var obj = Instantiate(avatarLocalData.headModel);
                    obj.transform.parent = transform;
                    obj.transform.localPosition = Vector3.zero;
                    obj.name = "Head";
                    headModelScript = obj.AddComponent<HeadModel>();
                    headModelScript.headMaterial = m_HeadMaterial;
                    headModelScript.eyeballmaterial = m_EyeballMaterial;
                    headModelScript.innermaterial = m_InnerMaterial;
                    AfterFileImport(obj, 0);
                    headModelScript.LoadHeadwearPoints(OnComplete);
                }
                else
                {
                    FileDownloder.GetByteData("https://avataryug.b-cdn.net/standards/head/unity/head_generic_rig_unity_v5.glb", (result) =>
                    {
                        ApiEvents.OnApiRequest?.Invoke(null, false);
                        GltfFastLoader.LoadModel(result, (obj) =>
                        {
                            obj.transform.parent = transform;
                            obj.transform.localPosition = Vector3.zero;
                            obj.name = "Head";
                            headModelScript = obj.AddComponent<HeadModel>();
                            headModelScript.headMaterial = m_HeadMaterial;
                            headModelScript.eyeballmaterial = m_EyeballMaterial;
                            headModelScript.innermaterial = m_InnerMaterial;
                            AfterFileImport(obj, 0);
                            headModelScript.LoadHeadwearPoints(OnComplete);
                        });
                    }, (error) => { Debug.LogError(error); });
                }
            }
            else
            {
                OnComplete?.Invoke();
            }
        }

        /// <summary>
        /// Load All Default Model
        /// </summary>
        public void LoadDefaulModel()
        {
            for (int i = 0; i < DefaultAvatarData.GetDefaultModelList(GetGender()).Count; i++)
            {
                loadDefaultModellist.Add(DefaultAvatarData.GetDefaultModelList(GetGender())[i]);
                OnLoadQueDefaultModel();
            }
        }

        /// <summary>
        /// This function add data of model to list in queue to load
        /// </summary>
        /// <param name="modelData"></param>
        /// <param name="undo"></param>
        public void LoadNetworkModel(EconomyItems modelData, bool undo)
        {
            ApiEvents.OnApiRequest?.Invoke(null, false);
            Utility.DelayCall(delayTime, () =>
            {
                if (!undo)
                {
                    networkModelQueue.Add(modelData);
#if DEMO_AVATARYUG
                    UndoHandler.Instance.AddProChangeAction(modelData);
#endif
                    OnLoadQueueModel();
                }
                else
                {
                    networkModelQueue.Add(modelData);
                    OnLoadQueueModel();
                }
            });
        }

        /// <summary>
        /// This function reset material to current selected avatar
        /// </summary>
        public void ResetToCurrentMaterial()
        {

            m_HeadMaterial.SetColor("_EyebrowColor", Utility.GetColor(avatarLocalData.DefaultEyebrowColor));
            switch (GetGender())
            {
                case Gender.Male:
                    m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(avatarLocalData.DefaultMaleLipColor));
                    break;
                case Gender.Female:
                    m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(avatarLocalData.DefaultLipColor));
                    break;
            }

            m_HeadMaterial.SetColor("_HairColor", Utility.GetColor(avatarLocalData.DefaultHairColor));
            m_HeadMaterial.SetTexture("_TatooTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_BeardTexture", avatarLocalData.empty);
            m_HeadMaterial.SetTexture("_EyebrowTexture", avatarLocalData.DefaultEyebrowTexture);
            m_HeadMaterial.SetTexture("_LipsTexture", avatarLocalData.DefaultLipTexture);
            m_HeadMaterial.SetTexture("_MainTex", avatarLocalData.baseSkinTexture);

            m_EyeballMaterial.SetTexture("_MainTex", avatarLocalData.eyeballTexture);

            m_BodyMaterial.SetTexture("_MainTex", avatarLocalData.bodyTexture);
            for (int i = 0; i < AvataryugData.bodytattos.Count; i++)
            {
                m_BodyMaterial.SetTexture("_" + AvataryugData.bodytattos[i], avatarLocalData.empty);
            }
#if DEMO_AVATARYUG
            m_HeadMaterial.SetColor("_EyebrowColor", Utility.GetColor(CurrentAvatarChanges.Instance.currentpropColors.EyebrowColor));
            m_HeadMaterial.SetColor("_LipsColor", Utility.GetColor(CurrentAvatarChanges.Instance.currentpropColors.LipColor));
            m_HeadMaterial.SetColor("_HairColor", Utility.GetColor(CurrentAvatarChanges.Instance.currentpropColors.HairColor));


            foreach (var item in CurrentAvatarChanges.Instance.currentProps.props)
            {
                var modelData = EconomyItemHolder.Instance.GetEconomyCurrentItemWithId(item.ID);
                AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
                var economydata = EconomyItemHolder.Instance.GetCurrentEconomyTex(modelData.ID);
                if (modelData.ItemCategory == "SkinTone")
                {
                    m_HeadMaterial.SetTexture("_MainTex", economydata.texture1);
                    m_BodyMaterial.SetTexture("_MainTex", economydata.texture2);
                }

                if (AvataryugData.IsBodyTattooCategory(modelData.ItemCategory))
                {
                    m_BodyMaterial.SetTexture("_" + modelData.ItemCategory, economydata.texture1);
                }

                if (AvataryugData.IsHead2DCategoty(modelData.ItemCategory))
                {
                    if (modelData.ItemCategory == "Eyeball")
                    {
                        m_EyeballMaterial.mainTexture = economydata.texture1;
                    }
                    if (modelData.ItemCategory == "Lips")
                    {
                        m_HeadMaterial.SetTexture("_LipsTexture", economydata.texture1);
                    }
                    if (modelData.ItemCategory == "Eyebrow")
                    {
                        m_HeadMaterial.SetTexture("_EyebrowTexture", economydata.texture1);
                    }
                }
                if (AvataryugData.IsHeadCategoty(modelData.ItemCategory))
                {
                    if (modelData.ItemCategory == "Hair")
                    {
                        if (modelData.Config.isTwoD == 1)
                        {
                            m_HeadMaterial.SetTexture("_HairTexture", economydata.texture1);
                        }
                    }
                    if (modelData.ItemCategory == "Facialhair")
                    {
                        if (modelData.Config.isTwoD == 1)
                        {
                            m_HeadMaterial.SetTexture("_BeardTexture", economydata.texture1);
                        }
                    }
                }
            }
#endif
        }

        /// <summary>
        /// This function load face related models
        /// </summary>
        /// <param name="modelData"></param>
        public void LoadHair(EconomyItems modelData)
        {
            ResetHairBlendshape();

            string[] buc = modelData.CoreBucket.Split('/');
            string bucketname = buc[0];
            if (buc.Length > 1)
            {
                bucketname = buc[1];
            }
            bool isModelPresent = false;
            bool addNew = true;
            if (!string.IsNullOrEmpty(currentHairData.ID))
            {
                isModelPresent = true;
                if (currentHairData.ID == modelData.ID)
                {
                    addNew = false;

#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                }
                else
                {
                    currentHairData = modelData;
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                }
            }
            else
            {
                currentHairData = modelData;
#if DEMO_AVATARYUG
                AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
            }
            if (isModelPresent)
            {
                m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
                if (headModelScript != null)
                {
                    for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                    {
                        if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                        {
                            if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).name.Contains(modelData.ID))
                                {
                                    if (this.HeadwearModel != null)
                                    {
                                        if (this.HeadwearModel == headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0))
                                        {
                                            this.HeadCoreBuck = "";
                                        }
                                    }
                                    Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                    break;
                                }
                            }

                        }
                    }
                }
                currentHairData = new EconomyItems();
            }
            if (addNew)
            {
                currentHairData = modelData;
                m_HeadMaterial.SetTexture("_HairTexture", avatarLocalData.empty);
                if (headModelScript != null)
                {
                    if (modelData.ConflictingBuckets != null)
                    {
                        ConflictingBuckets conflits = modelData.ConflictingBuckets;
                        for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                        {
                            for (int j = 0; j < conflits.buckets.Count; j++)
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == conflits.buckets[j].name.ToLower())
                                {
                                    if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                                    {
                                        Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                    }
                                }
                            }
                            if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                                {
                                    Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                }
                            }
                        }
                    }
                }

                if (modelData.Config.isTwoD == 1)
                {
                    TwoDArtifacts artifacts = JsonUtility.FromJson<TwoDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    TwoDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                    ApiEvents.OnApiRequest?.Invoke(null, false);
                    FileDownloder.GetNetworkTexture(artifact.url,
                    (texture) =>
                    {
                        m_HeadMaterial.SetTexture("_HairTexture", texture);
#if DEMO_AVATARYUG
                        EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, (Texture)texture, null);
                        string currentColor = CurrentAvatarChanges.Instance.changePropColors.HairColor;
                        if (ColorUtility.TryParseHtmlString(currentColor, out Color color1))
                        {
                            m_HeadMaterial.SetColor("_HairColor", color1);
                        }
#endif
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }, (err) =>
                    {
                        OnLoadQueueModel();
                    }, (pr) => { });
                }
                else
                {
                    ThreeDArtifacts artifacts = JsonUtility.FromJson<ThreeDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    if (artifacts.artifacts.Count > 0)
                    {
                        ThreeDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        if (artifacts != null)
                        {
                            if (!string.IsNullOrWhiteSpace(artifact.url))
                            {
#if DEMO_AVATARYUG
                                AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                                FileDownloder.GetByteData(artifact.url, (result) =>
                                {
                                    GltfFastLoader.LoadModel(ModelDecryptionHandler.GetGlbByte(result), (obj) =>
                                    {
                                        for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                                        {
                                            if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                                            {
                                                obj.transform.parent = headModelScript.m_VertexPointerData[i].pointTransform;
                                                obj.transform.localEulerAngles = Vector3.zero;
                                                obj.transform.localPosition = Vector3.zero;
                                                obj.transform.localScale = Vector3.one;
                                                obj.name = bucketname + "+" + modelData.ID;
                                            }
                                        }
                                        HairMaterialHandler bodyMaterial = obj.AddComponent<HairMaterialHandler>();
                                        bodyMaterial.customizeAvatarLoader = customizeAvatarLoader;
                                        bodyMaterial.hairMaterial = avatarLocalData.HairMaterial;
                                        bodyMaterial.Category = modelData.ItemCategory;
                                        bodyMaterial.SetData();

                                        SkinnedMeshRenderer blendName = obj.GetComponentInChildren<SkinnedMeshRenderer>();
                                        if (blendName != null)
                                        {
                                            if (blendName.sharedMesh.blendShapeCount > 0)
                                            {
                                                HairModel = obj;
                                            }

                                            for (int a = 0; a < blendName.sharedMesh.blendShapeCount; a++)
                                            {

                                                if (HeadCoreBuck.Contains(blendName.sharedMesh.GetBlendShapeName(a)))
                                                {
                                                    blendName.SetBlendShapeWeight(a, 1.0f);
                                                }
                                                else
                                                {
                                                    //  Debug.Log("Checking Hair Data======>>Headgear Conflict DAta IS EMPTY");
                                                }
                                            }
                                        }
                                        Utility.DelayCall(delayTime, () =>
                                        {
                                            OnLoadQueueModel();
                                        });
                                    });
                                }, (error) => { Debug.LogError(error); });
                            }
                            else
                            {
                                Utility.DelayCall(delayTime, () =>
                                {
                                    OnLoadQueueModel();
                                });
                                ApiEvents.OnShowTextPopup?.Invoke(null, "Artifact model not available");
                            }
                        }
                    }
                    else
                    {
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                        ApiEvents.OnShowTextPopup?.Invoke(null, "Artifact model not available");
                    }
                }
            }
            else
            {
                Utility.DelayCall(delayTime, () =>
                {
                    OnLoadQueueModel();
                });
            }
        }
        /// <summary>
        /// This function load face related models
        /// </summary>
        /// <param name="modelData"></param>
        public void LoadFacialhair(EconomyItems modelData)
        {

            string[] buc = modelData.CoreBucket.Split('/');
            string bucketname = buc[0];
            if (buc.Length > 1)
            {
                bucketname = buc[1];
            }
            bool isModelPresent = false;
            bool addNew = true;
            if (!string.IsNullOrEmpty(currentfacialHairData.ID))
            {
                isModelPresent = true;
                if (currentfacialHairData.ID == modelData.ID)
                {
                    addNew = false;

#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.RemovePart(modelData);
#endif
                }
                else
                {
                    currentfacialHairData = modelData;
#if DEMO_AVATARYUG
                    AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                }
            }
            else
            {
                currentfacialHairData = modelData;
#if DEMO_AVATARYUG
                AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
            }
            if (isModelPresent)
            {
                m_HeadMaterial.SetTexture("_BeardTexture", avatarLocalData.empty);
                if (headModelScript != null)
                {
                    for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                    {
                        if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                        {
                            if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).name.Contains(modelData.ID))
                                {
                                    Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                    break;
                                }
                            }

                        }
                    }
                }
                currentfacialHairData = new EconomyItems();
            }

            if (addNew)
            {
                currentfacialHairData = modelData;
                m_HeadMaterial.SetTexture("_BeardTexture", avatarLocalData.empty);
                if (headModelScript != null)
                {
                    if (modelData.ConflictingBuckets != null)
                    {
                        ConflictingBuckets conflits = modelData.ConflictingBuckets;
                        for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                        {
                            for (int j = 0; j < conflits.buckets.Count; j++)
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == conflits.buckets[j].name.ToLower())
                                {
                                    if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                                    {
                                        Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                    }
                                }
                            }
                            if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                            {
                                if (headModelScript.m_VertexPointerData[i].pointTransform.childCount > 0)
                                {
                                    Destroy(headModelScript.m_VertexPointerData[i].pointTransform.GetChild(0).gameObject);
                                }
                            }
                        }
                    }
                }
                if (modelData.Config.isTwoD == 1)
                {

                    TwoDArtifacts artifacts = JsonUtility.FromJson<TwoDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    TwoDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                    ApiEvents.OnApiRequest?.Invoke(null, false);
                    FileDownloder.GetNetworkTexture(artifact.url,
                    (texture) =>
                    {
                        m_HeadMaterial.SetTexture("_BeardTexture", texture);
                        string currentColor = customizeAvatarLoader.avatarLocalData.DefaultFacialHairColor;
#if DEMO_AVATARYUG
                        currentColor = CurrentAvatarChanges.Instance.changePropColors.FacialHairColor;
                        EconomyItemHolder.Instance.AddCurrentTexture(modelData.ID, (Texture)texture, null);
#endif
                        if (ColorUtility.TryParseHtmlString(currentColor, out Color color1))
                        {
                            m_HeadMaterial.SetColor("_BeardColor", color1);
                        }
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                    }, (err) =>
                    {
                        OnLoadQueueModel();
                    }, (pr) => { });

                }
                else
                {
                    ThreeDArtifacts artifacts = JsonUtility.FromJson<ThreeDArtifacts>("{" + "\"artifacts\":" + modelData.Artifacts + "}");
                    if (artifacts.artifacts.Count > 0)
                    {
                        ThreeDArtifact artifact = artifacts.artifacts.Find(f => f.device == (int)Utility.GetPlatfrom());
                        if (artifacts != null)
                        {
                            if (!string.IsNullOrWhiteSpace(artifact.url))
                            {
#if DEMO_AVATARYUG
                                AvatarBuildHandler.Instance.AddCurrentBodyPart(modelData);
#endif
                                FileDownloder.GetByteData(artifact.url, (result) =>
                                {
                                    GltfFastLoader.LoadModel(ModelDecryptionHandler.GetGlbByte(result), (obj) =>
                                    {
                                        for (int i = 0; i < headModelScript.m_VertexPointerData.Count; i++)
                                        {
                                            if (headModelScript.m_VertexPointerData[i].pointTransform.gameObject.name.ToLower() == bucketname.ToLower())
                                            {
                                                obj.transform.parent = headModelScript.m_VertexPointerData[i].pointTransform;
                                                obj.transform.localEulerAngles = Vector3.zero;
                                                obj.transform.localPosition = Vector3.zero;
                                                obj.transform.localScale = Vector3.one;
                                                obj.name = bucketname + "+" + modelData.ID;
                                            }
                                        }

                                        facialHairScript = obj.AddComponent<FacialHair>();
                                        facialHairScript.customizeAvatarLoader = customizeAvatarLoader;
                                        facialHairScript.Initialize();

                                        Utility.DelayCall(delayTime, () =>
                                        {
                                            OnLoadQueueModel();
                                        });
                                    });
                                }, (error) => { Debug.LogError(error); });
                            }
                            else
                            {
                                Utility.DelayCall(delayTime, () =>
                                {
                                    OnLoadQueueModel();
                                });
                                ApiEvents.OnShowTextPopup?.Invoke(null, "Artifact model not available");
                            }
                        }

                    }
                    else
                    {
                        Utility.DelayCall(delayTime, () =>
                        {
                            OnLoadQueueModel();
                        });
                        ApiEvents.OnShowTextPopup?.Invoke(null, "Artifact model not available");
                    }
                }
            }
            else
            {
                Utility.DelayCall(delayTime, () =>
                {
                    OnLoadQueueModel();
                });
            }


            if (headModelScript != null)
            {
                if (!isModelPresent)
                {


                }
            }
        }

        public void SetBodyType(BodyType e, Action onComplete)
        {
            if (e != null && !string.IsNullOrEmpty(e.ID))
            {
                currentBodyType = e;
                BodyType bodyType = e;
                if (bodyType.BodyValues != null)
                {
                    scaleMap.Clear();
                    BodyValues bodyValues = bodyType.BodyValues;

                    // Add entries to the scale map for each child object
                    scaleMap.Add("Armature", GetParsedValues(bodyValues.Armature));
                    scaleMap.Add("Hips", GetParsedValues(bodyValues.Hips));
                    scaleMap.Add("Spine", GetParsedValues(bodyValues.Spine));
                    scaleMap.Add("Spine1", GetParsedValues(bodyValues.Spine1));
                    scaleMap.Add("Spine2", GetParsedValues(bodyValues.Spine2));
                    scaleMap.Add("Neck", GetParsedValues(bodyValues.Neck));
                    scaleMap.Add("Head", GetParsedValues(bodyValues.Head));

                    scaleMap.Add("LeftShoulder", GetParsedValues(bodyValues.LeftShoulder));
                    scaleMap.Add("LeftArm", GetParsedValues(bodyValues.LeftArm));
                    scaleMap.Add("LeftForeArm", GetParsedValues(bodyValues.LeftForeArm));
                    scaleMap.Add("LeftHand", GetParsedValues(bodyValues.LeftHand));
                    scaleMap.Add("LeftHandThumb1", GetParsedValues(bodyValues.LeftHandThumb1));
                    scaleMap.Add("LeftHandThumb2", GetParsedValues(bodyValues.LeftHandThumb2));
                    scaleMap.Add("LeftHandThumb3", GetParsedValues(bodyValues.LeftHandThumb3));
                    scaleMap.Add("LeftHandIndex1", GetParsedValues(bodyValues.LeftHandIndex1));
                    scaleMap.Add("LeftHandIndex2", GetParsedValues(bodyValues.LeftHandIndex2));
                    scaleMap.Add("LeftHandIndex3", GetParsedValues(bodyValues.LeftHandIndex3));
                    scaleMap.Add("LeftHandMiddle1", GetParsedValues(bodyValues.LeftHandMiddle1));
                    scaleMap.Add("LeftHandMiddle2", GetParsedValues(bodyValues.LeftHandMiddle2));
                    scaleMap.Add("LeftHandMiddle3", GetParsedValues(bodyValues.LeftHandMiddle3));
                    scaleMap.Add("LeftHandRing1", GetParsedValues(bodyValues.LeftHandRing1));
                    scaleMap.Add("LeftHandRing2", GetParsedValues(bodyValues.LeftHandRing2));
                    scaleMap.Add("LeftHandRing3", GetParsedValues(bodyValues.LeftHandRing3));
                    scaleMap.Add("LeftHandPinky1", GetParsedValues(bodyValues.LeftHandPinky1));
                    scaleMap.Add("LeftHandPinky2", GetParsedValues(bodyValues.LeftHandPinky2));
                    scaleMap.Add("LeftHandPinky3", GetParsedValues(bodyValues.LeftHandPinky3));

                    scaleMap.Add("RightShoulder", GetParsedValues(bodyValues.RightShoulder));
                    scaleMap.Add("RightArm", GetParsedValues(bodyValues.RightArm));
                    scaleMap.Add("RightForeArm", GetParsedValues(bodyValues.RightForeArm));
                    scaleMap.Add("RightHand", GetParsedValues(bodyValues.RightHand));
                    scaleMap.Add("RightHandThumb1", GetParsedValues(bodyValues.RightHandThumb1));
                    scaleMap.Add("RightHandThumb2", GetParsedValues(bodyValues.RightHandThumb2));
                    scaleMap.Add("RightHandThumb3", GetParsedValues(bodyValues.RightHandThumb3));
                    scaleMap.Add("RightHandIndex1", GetParsedValues(bodyValues.RightHandIndex1));
                    scaleMap.Add("RightHandIndex2", GetParsedValues(bodyValues.RightHandIndex2));
                    scaleMap.Add("RightHandIndex3", GetParsedValues(bodyValues.RightHandIndex3));
                    scaleMap.Add("RightHandMiddle1", GetParsedValues(bodyValues.RightHandMiddle1));
                    scaleMap.Add("RightHandMiddle2", GetParsedValues(bodyValues.RightHandMiddle2));
                    scaleMap.Add("RightHandMiddle3", GetParsedValues(bodyValues.RightHandMiddle3));
                    scaleMap.Add("RightHandRing1", GetParsedValues(bodyValues.RightHandRing1));
                    scaleMap.Add("RightHandRing2", GetParsedValues(bodyValues.RightHandRing2));
                    scaleMap.Add("RightHandRing3", GetParsedValues(bodyValues.RightHandRing3));
                    scaleMap.Add("RightHandPinky1", GetParsedValues(bodyValues.RightHandPinky1));
                    scaleMap.Add("RightHandPinky2", GetParsedValues(bodyValues.RightHandPinky2));
                    scaleMap.Add("RightHandPinky3", GetParsedValues(bodyValues.RightHandPinky3));

                    scaleMap.Add("LeftUpLeg", GetParsedValues(bodyValues.LeftUpLeg));
                    scaleMap.Add("LeftLeg", GetParsedValues(bodyValues.LeftLeg));
                    scaleMap.Add("LeftFoot", GetParsedValues(bodyValues.LeftFoot));
                    scaleMap.Add("LeftToeBase", GetParsedValues(bodyValues.LeftToeBase));
                    scaleMap.Add("LeftToe_End", GetParsedValues(bodyValues.LeftToe_End));

                    scaleMap.Add("RightUpLeg", GetParsedValues(bodyValues.RightUpLeg));
                    scaleMap.Add("RightLeg", GetParsedValues(bodyValues.RightLeg));
                    scaleMap.Add("RightFoot", GetParsedValues(bodyValues.RightFoot));
                    scaleMap.Add("RightToeBase", GetParsedValues(bodyValues.RightToeBase));
                    scaleMap.Add("RightToe_End", GetParsedValues(bodyValues.RightToe_End));
                }
                onComplete.Invoke();
            }

        }
        // Access x, y, z values
        Vector3 GetParsedValues(string obj)
        {
            JObject armatureObject = JObject.Parse(obj);
            float x = (float)armatureObject["x"];
            float y = (float)armatureObject["y"];
            float z = (float)armatureObject["z"];
            return new Vector3(x, y, z);
        }
    }
}
