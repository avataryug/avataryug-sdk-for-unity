using System;
using UnityEngine;
using UnityEngine.UI;
using Com.Avataryug.Client;
using Com.Avataryug.Handler;
using Com.Avataryug.Model;

namespace Com.Avataryug
{
    public class UIHandler : MonoBehaviour
    {
        public Button m_Login;
        public GameObject LoginButtons;
        public GameObject ModelButtons;
        public Button m_MoreButton;
        public GameObject m_LoadingObject;
        private CustomizeAvatarLoader customizeAvatarLoader;
        public Button m_BuildModel;
        //public GenerateAvatarPanel m_GenerateAvatarPanel;
        /// <summary>
        /// Subscribe events
        /// </summary>
        private void OnEnable()
        {
            ApiEvents.OnApiRequest += ApiEvents_OnApiRequest;
            ApiEvents.OnApiResponce += ApiEvents_OnApiResponce;
        }
        /// <summary>
        /// Descuscribe events
        /// </summary>
        private void OnDisable()
        {
            ApiEvents.OnApiRequest -= ApiEvents_OnApiRequest;
            ApiEvents.OnApiResponce -= ApiEvents_OnApiResponce;
        }
        private void ApiEvents_OnApiResponce(object sender, EventArgs e)
        {
            m_LoadingObject.SetActive(false);
        }
        private void ApiEvents_OnApiRequest(object sender, bool e)
        {
            m_LoadingObject.SetActive(true);
        }
        void Start()
        {
            m_LoadingObject.SetActive(false);
            LoginButtons.gameObject.SetActive(true);
            ModelButtons.gameObject.SetActive(false);
            m_Login.onClick.RemoveAllListeners();
            m_Login.onClick.AddListener(LoginButtonClick);
            m_MoreButton.onClick.RemoveAllListeners();
            m_MoreButton.onClick.AddListener(LoadMore);
            m_BuildModel.onClick.RemoveAllListeners();
            m_BuildModel.onClick.AddListener(BuildModel);
        }
        void LoadMore()
        {
            string text = "For additional categories, please refer to the demo project or consult the documentation for more information";
            ApiEvents.OnShowTextPopup?.Invoke(null, text);
        }
        void LoginButtonClick()
        {
            ApiEvents.OnApiRequest?.Invoke(null, false);
            var auth = new AuthenticateHandler(new LoginWithCustomID()
            {
                CreateAccount = true,
                CustomID = SystemInfo.deviceUniqueIdentifier.ToLower()
            });
            auth.LoginWithCustomID((result) =>
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("LoginwithCustomID-->>" + result.ToJson());
                }

                LoginButtons.gameObject.SetActive(false);
                ModelButtons.gameObject.SetActive(true);
                ApiEvents.OnApiResponce?.Invoke(null, null);
                LoadModel();
            },
            (error) =>
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LoginwithCustomID-->>" + error.ToJson());
                }
            });
        }
        private void LoadModel()
        {
            //Debug.LogError("LoginwithCustomID----LoadModel->>");
            if (customizeAvatarLoader == null)
            {
                customizeAvatarLoader = FindObjectOfType<CustomizeAvatarLoader>();
            }
            customizeAvatarLoader.LoadDefaultModel();
            AvatarBuildHandler.Instance.CreateDefaultAvatar(CustomizeAvatarLoader.Instance.gender == Gender.Male ? 0 : 1);
        }
        void BuildModel()
        {
            ApiEvents.OnApiRequest?.Invoke(null, false);
            AvatarBuildHandler.Instance.ExportGlb((urlmesh) =>
            {
                Debug.Log(urlmesh);
                AvatarBuildHandler.Instance.ExportThumbnail((urlthumb) =>
                {
                    Debug.Log(urlmesh);
                    ApiEvents.OnApiResponce?.Invoke(null, null);
                    // m_GenerateAvatarPanel.SetDetail(() => { }, new SaveAvatarClass() { MeshUrl = urlmesh, RenderImageUrl = urlthumb });
                });
            });
        }
    }
}