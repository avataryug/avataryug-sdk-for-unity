using UnityEditor;
using UnityEngine;

namespace Com.Avataryug
{
    /// <summary>
    /// AvatarProjectSettings is a class that can be used in a ScriptableObject to store and manage settings related data.
    /// </summary>
    [CreateAssetMenu(fileName = "AvatarProjectSettings", menuName = "Avataryug/AvatarProjectSettings", order = 1)]
    public class AvatarProjectSettings : ScriptableObject
    {
        [Tooltip("Please enter the Project ID, which can be found in the portal. For more detailed information, please refer to our documentation.")]
        public string ProjectId;
        [Tooltip("Please enter secrect key from portal")]
        public string SecretKey;
        [Tooltip("Please enter iv key from portal")]
        public string IVSecretKey;
        [Tooltip("Used for developer logs")]
        public bool DebugLog;
        public void Save()
        {
#if UNITY_EDITOR
            AssetDatabase.SaveAssets();
#endif
        }
    }
}