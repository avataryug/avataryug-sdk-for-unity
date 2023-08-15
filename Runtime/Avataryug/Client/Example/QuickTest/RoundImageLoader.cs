using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Com.Avataryug
{
    public class RoundImageLoader : MonoBehaviour
    {
        public float loadingSpeed = 0.1f; // Adjust the speed of the loading animation.
        public Image loadingImage;
        private float currentFillAmount = 0f;
        private bool isFilling = true;
        private void OnEnable()
        {
            if (loadingImage == null)
            {
                loadingImage = GetComponent<Image>();
            }
        }

        void Update()
        {
            if (isFilling)
            {
                currentFillAmount += loadingSpeed * 0.01f;
                loadingImage.fillAmount = currentFillAmount;
                if (currentFillAmount >= 1f)
                {
                    currentFillAmount = 1f;
                    loadingImage.fillAmount = currentFillAmount;
                    isFilling = false;
                }
            }
            else
            {
                currentFillAmount--;
                loadingImage.fillAmount = currentFillAmount;
                if (currentFillAmount <= 0f)
                {
                    currentFillAmount = 0f;
                    loadingImage.fillAmount = currentFillAmount;
                    isFilling = true;
                }
            }
        }
    }
}
