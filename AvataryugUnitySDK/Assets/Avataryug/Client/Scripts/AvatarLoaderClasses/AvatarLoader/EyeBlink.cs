using UnityEngine;

namespace Com.Avataryug
{
    /// <summary>
    /// /Used for eye blink here we make use of blendshapes to blink eyes
    /// </summary>
    public class EyeBlink : MonoBehaviour
    {
        public SkinnedMeshRenderer skinnedMeshRenderer; //Assign skinned mesh which has eyesClose blendshape 
        public float m_BlinkInterval = 3f;  // Time interval between blinks
        public float m_BlinkDuration = 0.4f;  // Duration of the blink animation

        private string blinkBlendShapeName = "eyesClosed";  // Name of the blink blend shape
        private int blinkBlendShapeIndex;
        private float nextBlinkTime;
        public bool stopBlink = false;

        /// <summary>
        /// Assign the blendshape index and timer 
        /// </summary>
        private void Start()
        {
            blinkBlendShapeIndex = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(blinkBlendShapeName);
            nextBlinkTime = Time.time + m_BlinkInterval;
        }

        /// <summary>
        /// Update method used to check time interal and call blink eye process 
        /// </summary>
        private void Update()
        {
            if (stopBlink)
            {
                return;
            }
            else
            {
                if (Time.time >= nextBlinkTime)
                {
                    Blink(); //Call blink process 
                    m_BlinkInterval = Random.Range(2, 6); //Used to blink eye on random interval
                    nextBlinkTime = Time.time + m_BlinkInterval; //Setting next interval time
                }
            }
        }

        /// <summary>
        /// Call Eye blink process here it will start the coroutine 
        /// </summary>
        private void Blink()
        {
            StartCoroutine(BlinkAnimation());
        }

        /// <summary>
        /// Blink Animation coroutine
        /// </summary>
        /// <returns></returns>
        private System.Collections.IEnumerator BlinkAnimation()
        {
            float startTime = Time.time;
            float endTime = startTime + m_BlinkDuration;

            while (Time.time <= endTime)
            {
                float progress = Mathf.Clamp01((Time.time - startTime) / m_BlinkDuration);
                float blendShapeValue = EaseInOut(progress);
                skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, blendShapeValue);
                yield return null;
            }

            UnBlink();
        }
        /// <summary>
        /// Back to unblink state 
        /// </summary>
        private void UnBlink()
        {
            StartCoroutine(UnBlinkAnimation());
        }

        /// <summary>
        /// UnBlink Animation coroutine
        /// </summary>
        /// <returns></returns>
        private System.Collections.IEnumerator UnBlinkAnimation()
        {
            float resetDuration = 0.1f; // Duration of the reset animation
            float resetStartTime = Time.time;
            float resetEndTime = resetStartTime + resetDuration;
            float startBlendShapeValue = skinnedMeshRenderer.GetBlendShapeWeight(blinkBlendShapeIndex);
            while (Time.time <= resetEndTime)
            {
                float resetProgress = (Time.time - resetStartTime) / resetDuration;
                float blendShapeValue = Mathf.Lerp(startBlendShapeValue, 0f, resetProgress);
                skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, blendShapeValue);
                yield return null;
            }
            skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, 0f);
        }
        private float EaseInOut(float t)
        {
            // Apply ease-in-out function
            return t < 0.5f ? 4f * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 3f) / 2f;
        }

        public void ResetBlinkBlendshape()
        {
            skinnedMeshRenderer.SetBlendShapeWeight(blinkBlendShapeIndex, 0);
            stopBlink = true;
        }
    }
}