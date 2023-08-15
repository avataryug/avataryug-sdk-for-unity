using UnityEngine;
namespace Com.Avataryug
{
    public class FacialHair : MonoBehaviour
    {
        SkinnedMeshRenderer skinned;
        public CustomizeAvatarLoader customizeAvatarLoader;
        private void OnEnable()
        {
            ApiEvents.OnChangeColor += ApiEvents_OnChangeSkinColor;

            if (skinned == null)
            {
                skinned = GetComponentInChildren<SkinnedMeshRenderer>();
            }
            if (customizeAvatarLoader == null)
            {
                customizeAvatarLoader = GetComponentInParent<CustomizeAvatarLoader>();
            }
            if (skinned != null)
            {
                for (int i = 0; i < customizeAvatarLoader.headModelScript.headRenderer.sharedMesh.blendShapeCount; i++)
                {
                    int no = i;
                    string blendshapename = customizeAvatarLoader.headModelScript.headRenderer.sharedMesh.GetBlendShapeName(no);
                    SetBlendshape(blendshapename, customizeAvatarLoader.headModelScript.headRenderer.GetBlendShapeWeight(no));
                }
            }
        }
        private void OnDisable()
        {
            ApiEvents.OnChangeColor -= ApiEvents_OnChangeSkinColor;
        }
        public Color color1;
        public void Initialize()
        {
            if (skinned == null)
            {
                skinned = GetComponentInChildren<SkinnedMeshRenderer>();
            }
            if (customizeAvatarLoader == null)
            {
                customizeAvatarLoader = GetComponentInParent<CustomizeAvatarLoader>();
            }
            string currentColor = customizeAvatarLoader.avatarLocalData.DefaultFacialHairColor;
#if DEMO_AVATARYUG
            currentColor = CurrentAvatarChanges.Instance.changePropColors.FacialHairColor;
#endif
            if (ColorUtility.TryParseHtmlString(currentColor, out color1))
            {
                skinned.material.color = color1;
            }
        }

        private void ApiEvents_OnChangeSkinColor(object sender, Color e)
        {
            if (sender.ToString() == "Facialhair")
            {
                foreach (var item in skinned.materials)
                {
                    item.color = e;
                }
            }
        }


        public void Clearshape()
        {
            if (skinned != null)
            {
                for (int i = 0; i < skinned.sharedMesh.blendShapeCount; i++)
                {
                    int no = i;
                    skinned.SetBlendShapeWeight(no, 0);
                }
            }
        }
        public void SetBlendshape(string name, float weight)
        {
            if (skinned != null)
            {
                for (int i = 0; i < skinned.sharedMesh.blendShapeCount; i++)
                {
                    int no = i;
                    string blendshapename = skinned.sharedMesh.GetBlendShapeName(no);
                    if (blendshapename == name)
                    {
                        skinned.SetBlendShapeWeight(no, weight);
                    }
                }
            }
        }
    }
}