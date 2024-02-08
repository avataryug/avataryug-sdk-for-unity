using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Avataryug.Model;
using UnityEngine;
using Com.Avataryug.Handler;
using Com.Avataryug.UI;

namespace Com.Avataryug
{
    /// <summary>
    /// The "CustomizeAvatarLoader" class extends the base "AvatarLoaderBase" class
    /// and provides methods for customizing the loading process of avatars.
    /// It allows for loading unique avatar parts and implementing custom textures,
    /// blendshapes for facial features and many more.
    /// </summary>
    public class CustomizeAvatarLoader : AvatarLoaderBase
    {
        //Get Instance Class 
        public static CustomizeAvatarLoader Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomizeAvatarLoader();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Make it instance 
        /// </summary>
        private static CustomizeAvatarLoader _instance;
        public CustomizeAvatarLoader()
        {
            _instance = this;
        }

        [HideInInspector] public bool isStartDataLoadedforCustom = false;


        private void Awake()
        {
            customizeAvatarLoader = this;
            LoadStartData();
        }


        /// <summary>
        /// The code subscribed events when the "OnEnable" event is triggered.
        /// </summary>
        private void OnEnable()
        {
            transform.localPosition = Vector3.zero;

            ApiEvents.LoadNetworkModel += ApiEvents_LoadNetworkModel;
            ApiEvents.ResetAllHeadBlendshape += ApiEvents_ResetAllHeadBlendshape;
            ApiEvents.GetHeadBlendhape += ApiEvents_GetHeadBlendshape;
            ApiEvents.ResetAllExpression += ApiEvents_ResetAllExpression;
            ApiEvents.SetAnimatePose += ApiEvents_SetAnimatePose;
            ApiEvents.SetClip += ApiEvents_SetClip;
            ApiEvents.SetDefaultClipForExpressionPanel += ApiEvents_SetDefaultClipForExpressionPanel;
            ApiEvents.SetExpressions += ApiEvents_SetExpressions;
        }

        /// <summary>
        /// Loads the default model to get start 
        /// </summary>
        public void LoadDefaultModel()
        {
            LoadHeadModel(() =>
            {
                LoadDefaulModel();
            });
        }

        //Event Load Network model on event call 
        private void ApiEvents_LoadNetworkModel(object sender, EconomyItems e)
        {
            if (sender != null)
            {
                LoadNetworkModel(e, (bool)(sender));
            }
            else
            {
                LoadNetworkModel(e, false);
            }

        }

        /// Reset the blendshape to zero
        private void ApiEvents_ResetAllHeadBlendshape(object sender, EventArgs e)
        {
            headModelScript.ResetAllBlendhape();
            for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
            {
                string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                facialHairScript?.SetBlendshape(blendshapename, 0);
            }
        }

        //Event to get head blendshape and add into shapelist
        private void ApiEvents_GetHeadBlendshape(object sender, Action<List<Blendshape>> e)
        {
            List<Blendshape> shapelist = new List<Blendshape>();
            for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
            {
                int index = a;
                string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(index);
                float weight = headModelScript.headRenderer.GetBlendShapeWeight(index);
                if (weight != 0)
                {
                    shapelist.Add(new Blendshape()
                    {
                        shapekeys = blendshapename,
                        value = weight,
                    });
                }
            }
            e.Invoke(shapelist);
        }

        //Event to reset all applied expression
        private void ApiEvents_ResetAllExpression(object sender, Expression e)
        {
            foreach (var item in e.BlendshapeKeys.blendShapes)
            {
                headModelScript.SetBlendShape(new Blendshape() { shapekeys = item.selectedShape, value = 0 });
            }

            for (int a = 0; a < headModelScript.headRenderer.sharedMesh.blendShapeCount; a++)
            {
                string blendshapename = headModelScript.headRenderer.sharedMesh.GetBlendShapeName(a);
                facialHairScript?.SetBlendshape(blendshapename, 0);
            }
        }

        //Event set and animate the pose
        private void ApiEvents_SetAnimatePose(object sender, EventArgs e)
        {
            SetAnimatePose();
        }

        //Event set clip data
        private void ApiEvents_SetClip(AvatarPoseClip arg1, bool arg2, bool arg3)
        {
            SetClip(arg1, arg2, arg3);
        }

        //Event set Dedault clip to model so Expression can view properly
        private void ApiEvents_SetDefaultClipForExpressionPanel(object sender, Action e)
        {
            SetDefaultClipForExpressionPanel(e);
        }

        //Event to set expressions
        private void ApiEvents_SetExpressions(object sender, Expression e)
        {
            SetExpression(e, false);
        }

        /// <summary>
        /// Load Nextwork model data 
        /// </summary>
        /// <param name="modelData"></param>
        public void LoadNetworkModel(EconomyItems modelData)
        {
            networkModelQueue.Add(modelData);
            OnLoadQueueModel();
        }

        /// <summary>
        /// Apply expression 
        /// </summary>
        public void SetExpressionPose()
        {
            RuntimeAnimatorController animatorController = Resources.Load<RuntimeAnimatorController>(TAnimatorControllerName);
            animatorControllers = animatorControllers.FindAll(f => f != null).ToList();
            foreach (var item in animatorControllers)
            {
                item.runtimeAnimatorController = animatorController;
                item.avatar = null;
                item.enabled = true;
            }
        }

        /// <summary>
        ///  Based in input start and store animation
        /// </summary>
        /// <param name="play"></param>
        public void PlayStopAnimation(bool play)
        {
            foreach (var item in animatorControllers)
            {
                item.enabled = play;
            }
        }

        /// <summary>
        /// Set controller and set the animation pose 
        /// </summary>
        void SetAnimatePose()
        {
            RuntimeAnimatorController animatorController = Resources.Load<RuntimeAnimatorController>(AnimatorControllerName);
            Avatar animationAvatar = Resources.Load<Avatar>(AnimationTargetName);
            animatorControllers = animatorControllers.FindAll(f => f != null).ToList();

            foreach (var item in animatorControllers)
            {
                RemoveMixamo(item.transform);
                item.runtimeAnimatorController = animatorController;
                item.GetComponent<Animator>().enabled = true;
                item.avatar = animationAvatar;
            }
            foreach (var item in m_ModelForAnimation)
            {
                    if (item.GetComponent<Animation>() != null)
                    {
                        Animation animation = item.GetComponent<Animation>();
                        animation.enabled = tpose;
                        animation.Play();
                    }
            }
        }

        /// <summary>
        /// Set default clip for expression panel
        /// </summary>
        /// <param name="oncomplete"></param>
        async void SetDefaultClipForExpressionPanel(Action oncomplete)
        {
            RuntimeAnimatorController animatorController = Resources.Load<RuntimeAnimatorController>(AnimatorControllerName);
            Avatar animationAvatar = Resources.Load<Avatar>(AnimationTargetName);
            animatorControllers = animatorControllers.FindAll(f => f != null).ToList();
            foreach (var item in animatorControllers)
            {
                item.runtimeAnimatorController = animatorController;
                item.GetComponent<Animator>().enabled = true;
                item.avatar = animationAvatar;
            }
            await Task.Delay(100);

            foreach (var item in m_ModelForAnimation)
            {
                if (item.GetComponent<Animation>() != null)
                {
                    Animation animation = item.GetComponent<Animation>();
                    animation.Stop();
                    animation.enabled = false;

                }
            }

            foreach (var item in animatorControllers)
            {
                item.GetComponent<Animator>().enabled = false;

            }
            oncomplete?.Invoke();
        }

        /// <summary>
        /// Set Expression 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="isundo"></param>
        private void SetExpression(Expression expression, bool isundo)
        {
            if (facialHairScript != null)
            {
                facialHairScript.Clearshape();
            }
#if DEMO_AVATARYUG
            foreach (var item in FindObjectOfType<ExpressionPosePanel>().expressionLists)
            {
                foreach (var shape in item.BlendshapeKeys.blendShapes)
                {
                    headModelScript.SetBlendShape(new Blendshape() { shapekeys = shape.selectedShape, value = 0 });
                }
            }
#endif
            if (currentexpression.ID == expression.ID)
            {
#if DEMO_AVATARYUG
                FindObjectOfType<ExpressionPosePanel>().selectedExpression = new Expression();
#endif
                currentexpression = new Expression();
            }
            else
            {
                currentexpression = expression;
                for (int i = 0; i < expression.BlendshapeKeys.blendShapes.Count; i++)
                {
                    facialHairScript?.SetBlendshape(expression.BlendshapeKeys.blendShapes[i].selectedShape, expression.BlendshapeKeys.blendShapes[i].sliderValue);
                }
                headModelScript.SetExpression(expression.BlendshapeKeys.blendShapes, true);
            }
        }

        /// <summary>
        /// Set the clip to from url
        /// </summary>
        /// <param name="avatarPoseClip"></param>
        /// <param name="isundo"></param>
        /// <param name="dontremovecurrent"></param>
        public void SetClip(AvatarPoseClip avatarPoseClip, bool isundo, bool dontremovecurrent)
        {
            if (avatarPoseClip.Artifacts.Count > 0)
            {
                ApiEvents.OnApiRequest?.Invoke(null, false);
                if (currentClip.ID == avatarPoseClip.ID)
                {
                    if (dontremovecurrent)
                    {
                        currentClip = avatarPoseClip;
                        FileDownloder.GetByteData(avatarPoseClip.Artifacts[0].url, (res) =>
                        {
                            GltfFastLoader.GetClips(res, (clips) =>
                            {
                                ApiEvents.OnApiResponce?.Invoke(null, null);
                                if (clips.Length > 0)
                                {
                                    SetPose(clips[clips.Length-1]);
                                }
                            });
                        
                        },
                        (err) =>
                        {
                            ApiEvents.OnShowTextPopup?.Invoke(null, "Error in download file");

                            ApiEvents.OnApiResponce?.Invoke(null, null);
                        });
                    }
                    else
                    {

                        currentClip = new AvatarPoseClip();
                        SetDefaultClipForExpressionPanel(() =>
                        {
                            ApiEvents.OnApiResponce?.Invoke(null, null);
                        });
                    }
                }
                else
                {
                    currentClip = avatarPoseClip;
                    FileDownloder.GetByteData(avatarPoseClip.Artifacts[0].url, (res) =>
                    {
                        GltfFastLoader.GetClips(res, (clips) =>
                        {
                            ApiEvents.OnApiResponce?.Invoke(null, null);
                            if (clips.Length > 0)
                            {
                                SetPose(clips[clips.Length-1]);
                            }
                        });
                    }, (err) =>
                    {
                        ApiEvents.OnShowTextPopup?.Invoke(null, "Error in download file");

                        ApiEvents.OnApiResponce?.Invoke(null, null);
                    });
                }
            }
        }
        void RemoveMixamo(Transform _bone)
        {
            if (_bone != null)
            {
                if (_bone.name == "Hips" || _bone.name == "mixamorig:Hips")
                {
                    Transform[] childs = _bone.GetComponentsInChildren<Transform>();
                    foreach (var ch in childs)
                    {
                        if (ch.name.Contains("mixamorig:"))
                        {
                            ch.name = ch.name.Replace("mixamorig:", "");
                        }
                    }
                }
                for (int i = 0; i < _bone.childCount; i++)
                {
                    RemoveMixamo(_bone.GetChild(i));
                }
            }
        }
        void AddMixamo(Transform _bone)
        {
            if (_bone != null)
            {
                if (_bone.name == "Hips" || _bone.name == "mixamorig:Hips")
                {
                    Transform[] childs = _bone.GetComponentsInChildren<Transform>();
                    foreach (var ch in childs)
                    {
                        if (ch.name.Contains("mixamorig:"))
                        {

                        }
                        else
                        {
                            ch.name = "mixamorig:" + ch.name;
                        }
                    }
                }
                for (int i = 0; i < _bone.childCount; i++)
                {
                    AddMixamo(_bone.GetChild(i));
                }
            }
        }

        /// <summary>
        /// Apply Clip when set pose get called
        /// </summary>
        /// <param name="clip"></param>
        public void SetPose(AnimationClip clip)
        {
            foreach (var item in m_ModelForAnimation)
            {
                if (item.GetComponent<Animator>() != null)
                {
                    item.GetComponent<Animator>().enabled = false;
                }
                if(item.GetComponent<SetArmature>() == null)
                {
                    SetArmature armature = item.AddComponent<SetArmature>();
                    armature.AddExtraArmature();
                }
                if (item.GetComponent<Animation>() != null)
                {
                    Animation animation = item.gameObject.GetComponent<Animation>();
                    animation.enabled = true;
                    animation.AddClip(clip, clip.name);
                    animation.clip = animation.GetClip(clip.name);
                    animation.Play();
                    animation.wrapMode = WrapMode.Loop;
                }
                else
                {
                    Animation animation = item.gameObject.AddComponent<Animation>();
                    animation.enabled = true;
                    animation.AddClip(clip, clip.name);
                    animation.clip = animation.GetClip(clip.name);
                    animation.Play();
                    animation.wrapMode = WrapMode.Loop;
                }
            }
        }

        /// <summary>
        /// The code removes subscribed events when the "OnDisable" event is triggered.
        /// </summary>
        private void OnDisable()
        {
            ApiEvents.LoadNetworkModel -= ApiEvents_LoadNetworkModel;
            ApiEvents.SetExpressions -= ApiEvents_SetExpressions;
            ApiEvents.SetDefaultClipForExpressionPanel -= ApiEvents_SetDefaultClipForExpressionPanel;
            ApiEvents.SetClip -= ApiEvents_SetClip;
            ApiEvents.SetAnimatePose -= ApiEvents_SetAnimatePose;
            ApiEvents.ResetAllExpression -= ApiEvents_ResetAllExpression;
            ApiEvents.GetHeadBlendhape -= ApiEvents_GetHeadBlendshape;
            ApiEvents.ResetAllHeadBlendshape -= ApiEvents_ResetAllHeadBlendshape;
        }

    }
}