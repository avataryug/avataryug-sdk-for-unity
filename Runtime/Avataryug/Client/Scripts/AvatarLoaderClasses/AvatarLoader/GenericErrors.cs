using System;
using UnityEngine;
using UnityEngine.UI;
namespace Com.Avataryug
{
    /// <summary>
    /// Used for demo Perpose to show the error popup
    /// </summary>
    public class GenericErrors : MonoBehaviour
    {
        [SerializeField] private GameObject m_PopMessage;
        [SerializeField] private Text m_TextMessage;
        [SerializeField] private Button m_OKButton;

        /// <summary>
        /// Subscribe events
        /// </summary>
        private void OnEnable()
        {
            m_OKButton.onClick.RemoveAllListeners();
            m_OKButton.onClick.AddListener(() =>
            {
                m_PopMessage.SetActive(false);
            });

            ApiEvents.OnShowTextPopup += ApiEvents_OnShowTextPopup;
        }

        /// <summary>
        /// Descuscribe events
        /// </summary>
        private void OnDisable()
        {
            ApiEvents.OnShowTextPopup -= ApiEvents_OnShowTextPopup;
        }

        /// <summary>
        /// Show popup messsage in scene
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApiEvents_OnShowTextPopup(object sender, string e)
        {
            m_PopMessage.gameObject.SetActive(true);
            m_TextMessage.text = e;

        }

    }
}
