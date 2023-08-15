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
        public Texture empty;
        public Texture baseSkinTexture;
        public Texture eyelineTexture;
        public Texture eyeballTexture;
        public Texture bodyTexture;

        public Texture DefaultLipTexture;
        public Texture DefaultEyebrowTexture;

        public string DefaultFacialHairColor;
        public string DefaultEyebrowColor;
        public string DefaultHairColor;
        public string DefaultLipColor;
    }

}