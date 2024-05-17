using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Avataryug
{
    public class BodyTypeModel : MonoBehaviour
    {

    }

    [Serializable]
    public class BodyType
    {
        public string ID;
        public string Name;
        public string Thumbnail;
        public BodyValues BodyValues;
    }

    [Serializable]
    public class BodyValues
    {
        public string Armature;
        public string Hips;
        public string Spine;
        public string Spine1;
        public string Spine2;
        public string Neck;
        public string Head;
        public string LeftShoulder;
        public string LeftArm;
        public string LeftForeArm;
        public string LeftHand;
        public string LeftHandThumb1;
        public string LeftHandThumb2;
        public string LeftHandThumb3;
        public string LeftHandIndex1;
        public string LeftHandIndex2;
        public string LeftHandIndex3;
        public string LeftHandMiddle1;
        public string LeftHandMiddle2;
        public string LeftHandMiddle3;
        public string LeftHandRing1;
        public string LeftHandRing2;
        public string LeftHandRing3;
        public string LeftHandPinky1;
        public string LeftHandPinky2;
        public string LeftHandPinky3;
        public string RightShoulder;
        public string RightArm;
        public string RightForeArm;
        public string RightHand;
        public string RightHandThumb1;
        public string RightHandThumb2;
        public string RightHandThumb3;
        public string RightHandIndex1;
        public string RightHandIndex2;
        public string RightHandIndex3;
        public string RightHandMiddle1;
        public string RightHandMiddle2;
        public string RightHandMiddle3;
        public string RightHandRing1;
        public string RightHandRing2;
        public string RightHandRing3;
        public string RightHandPinky1;
        public string RightHandPinky2;
        public string RightHandPinky3;
        public string LeftUpLeg;
        public string LeftLeg;
        public string LeftFoot;
        public string LeftToeBase;
        public string LeftToe_End;
        public string RightUpLeg;
        public string RightLeg;
        public string RightFoot;
        public string RightToeBase;
        public string RightToe_End;
    }

    [Serializable]
    public class Data
    {
        public List<BodyType> BodyTypes;
    }

    [Serializable]
    public class BodyTypeData
    {
        public Data Data;
    }
}