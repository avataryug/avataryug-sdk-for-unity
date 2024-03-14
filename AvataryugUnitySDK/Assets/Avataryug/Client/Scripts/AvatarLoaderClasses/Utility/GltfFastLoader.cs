using System;
using GLTFast;

using UnityEngine;
public class GltfFastLoader
{
    public static async void LoadModel(byte[] byteData,Action<GameObject> onModelLoad)
    {
        var gltf = new GltfImport();
        var settings = new ImportSettings {GenerateMipMaps = true,AnisotropicFilterLevel = 3,NodeNameMethod = NameImportMethod.Original};
        var success = await gltf.LoadGltfBinary(byteData, null, settings);
        if (success)
        {
            GameObject tempParent = new GameObject();
            await gltf.InstantiateMainSceneAsync(tempParent.transform);
            if (tempParent.transform.childCount > 0)
            {
                var glbModel = tempParent.transform.GetChild(0).gameObject;
                glbModel.transform.parent = null;
                GameObject.Destroy(tempParent);
                onModelLoad?.Invoke(glbModel);
            }
        }
        else
        {
            Debug.LogError("Loading glTF failed!");
        }
    }

    public static async void GetClips(byte[] byteData, Action<AnimationClip[]> onModelLoad)
    {
        var gltf = new GltfImport();
        var settings = new ImportSettings { GenerateMipMaps = true, AnisotropicFilterLevel = 3, NodeNameMethod = NameImportMethod.Original ,AnimationMethod = AnimationMethod.Legacy};
        var success = await gltf.LoadGltfBinary(byteData, null, settings);
        if (success)
        {
            onModelLoad?.Invoke(gltf.GetAnimationClips());
        }
        else
        {
            Debug.LogError("Loading glTF failed!");
        }
    }
}
