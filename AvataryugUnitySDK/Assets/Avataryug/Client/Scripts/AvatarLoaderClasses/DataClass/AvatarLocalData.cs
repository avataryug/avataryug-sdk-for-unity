using UnityEngine;

namespace Com.Avataryug
{
    [CreateAssetMenu(fileName = "Avatar Local Data", menuName = "Avataryug/Avatar Local Data", order = 1)]
    public class AvatarLocalData : ScriptableObject
    {
        public Material HairMaterial;
        public Material BodyMaterial;
        public Material HeadMaterial;
        public Material EyeballMaterial;
        public Material FacialHairMaterial;
        public Material InnerMouthMaterial;
        public Texture empty;
        public Texture baseSkinTexture;
        public Texture eyeballTexture;
        public Texture bodyTexture;

        public Texture DefaultLipTexture;
        public Texture DefaultEyebrowTexture;

        public string DefaultFacialHairColor;
        public string DefaultEyebrowColor;
        public string DefaultHairColor;
        public string DefaultLipColor;
        public string DefaultMaleLipColor;
        public GameObject headModel;

        public GameObject female_standard_top;
        public GameObject female_standard_bottom;
        public GameObject male_standard_top;
        public GameObject male_standard_bottom;
        public GameObject standard_footwear;
        public GameObject standard_hand;
        public TextAsset vertexData;

    }

}