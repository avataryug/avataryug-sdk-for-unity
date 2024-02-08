using System;
using System.Collections.Generic;
using Com.Avataryug.Client;
using Com.Avataryug.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug
{
    /// <summary>
    /// API Evenets for use internal perpose 
    /// </summary>
    public class ApiEvents
    {
        public static EventHandler OnApiResponce;
        public static EventHandler OnItemPurchase;
        public static EventHandler OnItemSelect;
        public static EventHandler SetAnimatePose;
        public static EventHandler ResetAllHeadBlendshape;

        public static EventHandler<bool> OnApiRequest;


        public static EventHandler<LoadingClass> OnApiLoadingShow;

        public static EventHandler<string> OnApiSuccess;
        public static EventHandler<string> OnShowTextPopup;

        public static EventHandler<float> OnApiRequestWP;
        public static EventHandler<float> OnChangeBlendShape;

        public static EventHandler<Action<List<Blendshape>>> GetHeadBlendhape;
        public static EventHandler<Action> ResetToDefault;
        public static EventHandler<Action> ResetToCurrentSelected;
        public static EventHandler<Action> SetDefaultClipForExpressionPanel;

        public static Action<AvatarPoseClip, bool, bool> SetClip;

        public static EventHandler<ApiException> OnApiError;
        public static Action<SaveAvatarClass,Action> OnSaveModelResponse;
        public static EventHandler<EconomyItems> OnEconomyItemClick;
        public static EventHandler<Button> OnShapeClick;
        public static EventHandler<Color> OnChangeColor;
        public static EventHandler<EconomyItems> LoadNetworkModel;

        public static EventHandler<Expression> SetExpressions;
        public static EventHandler<Expression> ResetAllExpression;

        public static EventHandler<SortType> OnSortTypeChange;
        public static EventHandler<ModelParent> SetModelParentEnable;

        public static EventHandler UpdateUiAfterChanges;
        public static bool modeOn;


    }

    [Serializable]
    public class MessageClass
    {
        public string Title;
        public string Message;
    }
    [Serializable]
    public class SaveAvatarClass
    {
        public string MeshUrl;
        public string RenderImageUrl;
    }
    [Serializable]
    public class LoadingClass
    {
        public string Message;
        public bool ShowWarning;
    }
}