using System.IO;
using UnityEditor;
using UnityEngine;

namespace Com.Avataryug
{
    /// <summary>
    /// This class is used to create an asset class that allows you to set the project ID and other keys for configuration purposes.
    /// </summary>
    public class AvataryugSettingObject
    {
#if UNITY_EDITOR
        [MenuItem("Avataryug/AvatarProjectSettings")]
        public static void AvatarProjectSettings()
        {
            string assetPath = "Assets/Resources/AvatarProjectSettings.asset";
            bool isSettingExist = File.Exists(assetPath);

            if (!isSettingExist)
            {
                string assetFolderPath = Path.Combine(Application.dataPath, "Resources");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(assetFolderPath))
                {
                    Directory.CreateDirectory(assetFolderPath);
                }

                //Create asset file here using scriptable object
                AvatarProjectSettings asset = ScriptableObject.CreateInstance<AvatarProjectSettings>();
                AssetDatabase.CreateAsset(asset, assetPath);
                AssetDatabase.SaveAssets();
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = asset;
            }
            else
            {
                Debug.Log("Asset file already exist at following path-->>" + assetPath);
                AvatarProjectSettings assetfileToActivate = AssetDatabase.LoadAssetAtPath<AvatarProjectSettings>(assetPath);
                EditorUtility.FocusProjectWindow();
                AssetDatabase.SaveAssets();
                Selection.activeObject = assetfileToActivate;
            }
        }
#endif
    }
}