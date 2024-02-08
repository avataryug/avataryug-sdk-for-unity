using System.Collections.Generic;
using UnityEngine;

namespace Com.Avataryug
{
    [System.Serializable]
    public class ModelData
    {
        public string MainCatID;
        public string GlbPath;
        public string CoreBucket;
        public string ConflictingBuckets;
        public string LocalPath;

        public ModelData()
        {
            MainCatID = GlbPath = CoreBucket = ConflictingBuckets = LocalPath = "";
        }
    }
    public class DefaultAvatarData
    {
        public static List<ModelData> GetDefaultModelList(Gender gender)
        {
            List<ModelData> templist = new List<ModelData>();
            switch (gender)
            {
                case Gender.Male:
                    templist = modelMaleDatas;
                    break;
                case Gender.Female:
                    templist = modelFemaleDatas;
                    break;
            }
            return templist;
        }

        static List<ModelData> modelFemaleDatas = new List<ModelData>()
        {
            new ModelData()
            {
                MainCatID = "Top",
                CoreBucket = "upperbody_sleeve_short",
                GlbPath = "https://aystorage.b-cdn.net/standard/female_standard_top.glb",
                LocalPath = "female_standard_top",
                ConflictingBuckets = "{" + "\"conflits\"" + ":" + "[{\"name\":\"upperbody_shoulder_left\"},{\"name\":\"upperbody_sleeveless\"},{\"name\":\"upperbody_arm_right\"},{\"name\":\"upperbody_shoulder_both\"},{\"name\":\"upperbody_back\"},{\"name\":\"upperbody_sleeve_full\"},{\"name\":\"upperbody_arm_left\"},{\"name\":\"upperbody_wrist_both\"},{\"name\":\"upperbody_arm_both\"},{\"name\":\"upperbody_stomach\"},{\"name\":\"upperbody_hand_right\"},{\"name\":\"upperbody_shoulder_right\"},{\"name\":\"upperbody_wrist_right\"},{\"name\":\"upperbody_forearm_right\"},{\"name\":\"upperbody_forearm_both\"},{\"name\":\"upperbody_forearm_left\"},{\"name\":\"upperbody_wrist_left\"},{\"name\":\"upperbody_chest\"},{\"name\":\"upperbody_sleeve_short\"},{\"name\":\"upperbody_hand_left\"},{\"name\":\"upperbody_front\"},{\"name\":\"fullbody_without_foot\"},{\"name\":\"fullbody_with_head_foot\"},{\"name\":\"fullbody_without_head\"},{\"name\":\"fullbody_without_head_foot\"}]" + "}"
            },
            new ModelData()
            {
                MainCatID = "Bottom",
                CoreBucket = "lowerbody_without_foot",
                GlbPath = "https://aystorage.b-cdn.net/standard/female_standard_bottom.glb",
                 LocalPath = "female_standard_bottom",
                ConflictingBuckets = "{" + "\"conflits\"" + ":" + "[{\"name\":\"lowerbody_foot_right\"},{\"name\":\"lowerbody_knee_right\"},{\"name\":\"lowerbody_without_foot\"},{\"name\":\"lowerbody_leg_both\"},{\"name\":\"lowerbody_knee_left\"},{\"name\":\"lowerbody_foot_left\"},{\"name\":\"lowerbody_leg_left\"},{\"name\":\"lowerbody_knee_both\"},{\"name\":\"lowerbody_leg_right\"},{\"name\":\"lowerbody_till_knee\"},{\"name\":\"lowerbody_thigh_both\"},{\"name\":\"lowerbody_thigh_right\"},{\"name\":\"lowerbody_thigh_left\"},{\"name\":\"fullbody_without_foot\"},{\"name\":\"fullbody_with_head_foot\"},{\"name\":\"fullbody_without_head\"},{\"name\":\"fullbody_without_head_foot\"}]" + "}"
            },
            new ModelData()
            {
                MainCatID = "Footwear",
                CoreBucket = "lowerbody_foot_both",
                GlbPath = "https://aystorage.b-cdn.net/standard/standard_footwear.glb",
                    LocalPath = "standard_footwear",
                ConflictingBuckets = "{" + "\"conflits\"" + ":" + "[{\"name\":\"lowerbody_foot_both\"}]" + "}"
            },
            new ModelData()
            {
                MainCatID = "Handwear",
                CoreBucket = "upperbody_hand_both",
                GlbPath = "https://aystorage.b-cdn.net/standard/standard_hand.glb",
                LocalPath = "standard_hand",
                ConflictingBuckets = "{" + "\"conflits\"" + ":" + "[{\"name\":\"upperbody_hand_both\"}]" + "}"
            },
        };

        static List<ModelData> modelMaleDatas = new List<ModelData>()
        {
            new ModelData()
            {
                MainCatID = "Top",
                CoreBucket = "upperbody_sleeve_short",
                GlbPath = "https://aystorage.b-cdn.net/standard/male_standard_top.glb",
                   LocalPath = "male_standard_top",
                ConflictingBuckets = "{" + "\"conflits\"" + ":" + "[{\"name\":\"upperbody_shoulder_left\"},{\"name\":\"upperbody_sleeveless\"},{\"name\":\"upperbody_arm_right\"},{\"name\":\"upperbody_shoulder_both\"},{\"name\":\"upperbody_back\"},{\"name\":\"upperbody_sleeve_full\"},{\"name\":\"upperbody_arm_left\"},{\"name\":\"upperbody_wrist_both\"},{\"name\":\"upperbody_arm_both\"},{\"name\":\"upperbody_stomach\"},{\"name\":\"upperbody_hand_right\"},{\"name\":\"upperbody_shoulder_right\"},{\"name\":\"upperbody_wrist_right\"},{\"name\":\"upperbody_forearm_right\"},{\"name\":\"upperbody_forearm_both\"},{\"name\":\"upperbody_forearm_left\"},{\"name\":\"upperbody_wrist_left\"},{\"name\":\"upperbody_chest\"},{\"name\":\"upperbody_sleeve_short\"},{\"name\":\"upperbody_hand_left\"},{\"name\":\"upperbody_front\"},{\"name\":\"fullbody_without_foot\"},{\"name\":\"fullbody_with_head_foot\"},{\"name\":\"fullbody_without_head\"},{\"name\":\"fullbody_without_head_foot\"}]" + "}"
            },
            new ModelData()
            {
                MainCatID = "Bottom",
                CoreBucket = "lowerbody_without_foot",
                GlbPath = "https://aystorage.b-cdn.net/standard/male_standard_bottom.glb",
                LocalPath = "male_standard_bottom",
                ConflictingBuckets = "{" + "\"conflits\"" + ":" + "[{\"name\":\"lowerbody_foot_right\"},{\"name\":\"lowerbody_knee_right\"},{\"name\":\"lowerbody_without_foot\"},{\"name\":\"lowerbody_leg_both\"},{\"name\":\"lowerbody_knee_left\"},{\"name\":\"lowerbody_foot_left\"},{\"name\":\"lowerbody_leg_left\"},{\"name\":\"lowerbody_knee_both\"},{\"name\":\"lowerbody_leg_right\"},{\"name\":\"lowerbody_till_knee\"},{\"name\":\"lowerbody_thigh_both\"},{\"name\":\"lowerbody_thigh_right\"},{\"name\":\"lowerbody_thigh_left\"},{\"name\":\"fullbody_without_foot\"},{\"name\":\"fullbody_with_head_foot\"},{\"name\":\"fullbody_without_head\"},{\"name\":\"fullbody_without_head_foot\"}]" + "}"
            },
            new ModelData()
            {
                MainCatID = "Footwear",
                CoreBucket = "lowerbody_foot_both",
                GlbPath = "https://aystorage.b-cdn.net/standard/standard_footwear.glb",
                LocalPath = "standard_footwear",
                ConflictingBuckets = "{" + "\"conflits\"" + ":" + "[{\"name\":\"lowerbody_foot_both\"}]" + "}"
            },
            new ModelData()
            {
                MainCatID = "Handwear",
                CoreBucket = "upperbody_hand_both",
                GlbPath = "https://aystorage.b-cdn.net/standard/standard_hand.glb",
                LocalPath = "standard_hand",
                ConflictingBuckets = "{" + "\"conflits\"" + ":" + "[{\"name\":\"upperbody_hand_both\"}]" + "}"
            },
        };
    }
}