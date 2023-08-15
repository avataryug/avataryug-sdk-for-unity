using System;
using Com.Avataryug.Client;
using Com.Avataryug.Handler;
using Com.Avataryug.Model;
using UnityEngine;
using UnityEngine.UI;

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
            if (customizeAvatarLoader == null)
            {
                customizeAvatarLoader = FindObjectOfType<CustomizeAvatarLoader>();
            }
            customizeAvatarLoader.LoadDefaultModel();
        }

    }
}