using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Com.Avataryug
{
    /// <summary>
    /// This class contains internal data used for customizing avatars. Please note that modifying this class may disrupt the smooth functioning of the system.
    /// </summary>
    public class AvataryugData
    {
        /// <summary>
        /// Checks is Gender is common 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool IsCommonGender(string category)
        {
            if (category == "Top" || category == "Bottom" || category == "Outfit")
            {
                return false;
            }
            return true;
        }

        public static List<string> bodytattos = new List<string>() { // "FrontBodyTattoo","BackBodyTattoo",
           "RightArmTattoo","LeftArmTattoo","FrontRightLegTattoo","FrontLeftLegTattoo",
            "BackRightLegTattoo","BackLeftLegTattoo","RightHandTattoo","LeftHandTattoo","RightFootTattoo","LeftFootTattoo"
        };

        public static string[] CategoryForColorPanel = new string[] { "Hair", "Eyebrow", "Lips", "Facialhair" };
        public static bool IsCategoryForColorPanel(string category)
        {
            bool isPresent = false;
            foreach (var item in CategoryForColorPanel)
            {
                if (item == category)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }

        public static string[] BlendshapeCategory = new string[6] { "FaceShape", "EyeShape", "EyebrowShape", "NoseShape", "LipShape", "EarShape" };
        public static bool IsBlendshapeCategory(string category)
        {
            bool isPresent = false;
            foreach (var item in BlendshapeCategory)
            {
                if (item == category)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }

        public static string[] HeadCategory = new string[] { "Hair", "Facialhair", "Headwear", "Eyewear" };
        public static bool IsHeadCategoty(string category)
        {
            bool isPresent = false;
            foreach (var item in HeadCategory)
            {
                if (item == category)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }

        public static string[] Head2DCategory = new string[] { "Eyebrow", "Eyeball", "Lips" };
        public static bool IsHead2DCategoty(string category)
        {
            bool isPresent = false;
            foreach (var item in Head2DCategory)
            {
                if (item == category)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }

        public static string[] FaceAccessary = new string[6] { "Mouthwear", "Earwear", "Eyebrowswear", "Facewear", "Neckwear", "Nosewear" };
        public static bool IsFacewearAccessary(string category)
        {
            bool isPresent = false;
            foreach (var item in FaceAccessary)
            {
                if (item == category)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }

        public static string[] BodyTattoCategory = new string[]
        {
        //"LeftHandTattoo",
        //"RightHandTattoo",

        "LeftArmTattoo",
        "RightArmTattoo",

        //"LeftFootTattoo",
        //"RightFootTattoo",

        "FrontLeftLegTattoo",
        "FrontRightLegTattoo",

        //"BackBodyTattoo",
        //"FrontBodyTattoo",

        "BackLeftLegTattoo",
        "BackRightLegTattoo",

        "HeadTattoo"
        };

        public static bool IsBodyTattooCategory(string category)
        {
            bool isPresent = false;
            foreach (var item in BodyTattoCategory)
            {
                if (item == category)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }

        public static string[] BodyPartCategory = new string[6]
        {
        "Top",
        "Bottom",
        "Outfit",
        "Footwear",
        "Handwear",
        "Wristwear"
        };

        public static string[] HeadInventoryCategty = new string[]
        {
        "All",
        "SkinTone",
        "Hair",
        "Eyebrow",
        "Eyeball",
        "Lips",
        "Facialhair",
        "Headwear",
        "Eyewear",
        "Mouthwear",
        "Earwear",
        "Eyebrowswear",
        "Facewear",
        "Neckwear",
        "Nosewear"
        };

        public static string[] FullInventoryCategty = new string[]
        {
        "All",
        "Top",
        "Bottom",
        "Outfit",
        "Footwear",
        "Handwear",
        "Wristwear",
        "LeftHandTattoo",
        "RightHandTattoo",
        "LeftArmTattoo",
        "RightArmTattoo",
        "LeftFootTattoo",
        "RightFootTattoo",
        "FrontLeftLegTattoo",
        "FrontRightLegTattoo",
        "BackBodyTattoo",
        "BackLeftLegTattoo",
        "BackRightLegTattoo",
        "SkinTone",
        "HeadTattoo"
        };

        public static bool IsBodyPartCategory(string category)
        {
            bool isPresent = false;
            foreach (var item in BodyPartCategory)
            {
                if (item == category)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }
        public static string[] SplitCamelCase(string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }
    }

    public class BodywearPointDetail
    {
        public string pointName;
        public string boneName;
        public Vector3 Position;
        public Vector3 Rotation;
        public BodywearPointDetail()
        {
            pointName = string.Empty;
            Rotation = Position = Vector3.zero;
        }
    }

    public class LocalBodyPointList
    {
        public static readonly List<BodywearPointDetail> bodywearPointDetails = new List<BodywearPointDetail>()
        {
            new BodywearPointDetail()
            {
                boneName = "Spine2",
                pointName = "upperbody_back" ,
                Rotation = Vector3.zero ,
                Position = new Vector3(0,0,0.1f)
            },
            new BodywearPointDetail()
            {
                boneName = "LeftShoulder",
                pointName = "upperboddy_shoulder_left" ,
                Rotation = Vector3.zero ,
                Position = new Vector3(-0.068f,0,0.048f)
            },
            new BodywearPointDetail()
            {
                boneName = "LeftArm",
                pointName = "upperbody_arm_left" ,
                Rotation = Vector3.zero ,
                Position = Vector3.zero
            },
            new BodywearPointDetail()
            {
                boneName = "LeftForeArm",
                pointName = "upperbody_forearm_left" ,
                Rotation = Vector3.zero ,
                Position = Vector3.zero
            },
            new BodywearPointDetail()
            {
                boneName = "LeftForeArm",
                pointName = "upperbody_wrist_left" ,
                Rotation = new Vector3(0,90,-80) ,
                Position = new Vector3(0,0.225f,0f)
            },
            new BodywearPointDetail()
            {
                boneName = "RightShoulder",
                pointName = "upperboddy_shoulder_right" ,
                Rotation = Vector3.zero ,
                Position = new Vector3(-0.068f,0,0.048f)
            },
            new BodywearPointDetail()
            {
                boneName = "RightArm",
                pointName = "upperbody_arm_right" ,
                Rotation = Vector3.zero ,
                Position = Vector3.zero
            },
            new BodywearPointDetail()
            {
                boneName = "RightForeArm",
                pointName = "upperbody_forearm_right" ,
                Rotation = Vector3.zero , Position =
                Vector3.zero
            },
            new BodywearPointDetail()
            {
                boneName = "RightForeArm",
                pointName = "upperbody_wrist_right" ,
                Rotation = Vector3.zero ,
                Position = new Vector3(0.0f,0.2f,0.0f)
            },
            new BodywearPointDetail()
            {
                boneName = "LeftUpLeg",
                pointName = "lowerbody_thigh_left" ,
                Rotation = Vector3.zero ,
                Position = new Vector3(-0.1090f,    0.004f,-0.0019f)
            },
            new BodywearPointDetail()
            {
                boneName = "LeftLeg",
                pointName = "lowerbody_knee_left",
                Rotation = Vector3.zero,
                Position = Vector3.zero
            },
            new BodywearPointDetail()
            {
                boneName = "LeftLeg",
                pointName = "lowerbody_leg_left",
                Rotation = Vector3.zero,
                Position = Vector3.zero
            },
            new BodywearPointDetail()
            {
                boneName = "RightUpLeg",
                pointName = "lowerbody_thigh_right",
                Rotation = Vector3.zero,
                Position = new Vector3(-0.1090f,    0.004f,-0.0019f)
            },
            new BodywearPointDetail()
            {
                boneName = "RightLeg",
                pointName = "lowerbody_knee_right",
                Rotation = Vector3.zero,
                Position = Vector3.zero
            },
            new BodywearPointDetail()
            {
                boneName = "RightLeg",
                pointName = "lowerbody_leg_right",
                Rotation = Vector3.zero,
                Position = Vector3.zero
            },
        };
    }
}