using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug
{
    public class QuickTestUIHandler : MonoBehaviour
    {
        public GameObject m_LoadingObject;
        public Image m_LoadingImage;

        private void OnEnable()
        {
            QuickTestApiEvents.OnApiRequest += QuickTestApiEvents_OnApiRequest;
            QuickTestApiEvents.OnApiResponce += QuickTestApiEvents_OnApiResponce;
        }

        private void QuickTestApiEvents_OnApiRequest(object sender, bool e)
        {
            m_LoadingObject.SetActive(true);
        }

        private void QuickTestApiEvents_OnApiResponce(object sender, EventArgs e)
        {
            m_LoadingObject.SetActive(false);
        }

        private void OnDisable()
        {
            QuickTestApiEvents.OnApiRequest -= QuickTestApiEvents_OnApiRequest;

            QuickTestApiEvents.OnApiResponce -= QuickTestApiEvents_OnApiResponce;
        }

    }
}
