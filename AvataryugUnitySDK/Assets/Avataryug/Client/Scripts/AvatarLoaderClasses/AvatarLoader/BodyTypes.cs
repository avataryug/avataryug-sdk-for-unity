using System;
using System.Collections.Generic;
using Com.Avataryug;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BodyTypes : MonoBehaviour
{
    public TextAsset jsonFile; // Reference to your JSON file
    string jsonData;

    [SerializeField]
    public Dictionary<string, Vector3> scaleMap = new Dictionary<string, Vector3>();

    private void Start()
    {
        if (jsonFile != null)
        {
            jsonData = jsonFile.text;
        }
        else
        {
            Debug.LogError("JSON file not found!");
        }
    }



    void ApplyScaleToBody(Transform parent)
    {
        foreach (Transform child in parent)
        {
            string childName = child.name;
            // Check if the child name exists in the scale map
            if (scaleMap.ContainsKey(childName))
            {
                // Apply the corresponding scale value from the map
                child.localScale = scaleMap[childName];
            }

            // Optionally, apply the scale recursively to child objects
            if (child.childCount > 0)
                ApplyScaleToBody(child);
        }
    }


    void SetBodyType(string jsonString, string bodyTypeID, Action onComplete)
    {
        BodyTypeData myDeserializedClass = JsonConvert.DeserializeObject<BodyTypeData>(jsonString);
        BodyType bodyType = new BodyType();
        // Access deserialized data
        for (int i = 0; i < myDeserializedClass.Data.BodyTypes.Count; i++)
        {
            bool isValid = myDeserializedClass.Data.BodyTypes[i].ID == bodyTypeID; // Store the result of comparison in a variable
            if (isValid)
            {
                Debug.Log("found the body");
                bodyType = myDeserializedClass.Data.BodyTypes[i];
                break;
            }
        }

        if (bodyType.BodyValues != null)
        {
            scaleMap.Clear();
            BodyValues bodyValues = new BodyValues();
            bodyValues = bodyType.BodyValues;

            // Add entries to the scale map for each child object
            scaleMap.Add("Armature", GetParsedValues(bodyValues.Armature));
            scaleMap.Add("Hips", GetParsedValues(bodyValues.Hips));
            scaleMap.Add("Spine", GetParsedValues(bodyValues.Spine));
            scaleMap.Add("Spine1", GetParsedValues(bodyValues.Spine1));
            scaleMap.Add("Spine2", GetParsedValues(bodyValues.Spine2));
            scaleMap.Add("Neck", GetParsedValues(bodyValues.Neck));
            scaleMap.Add("Head", GetParsedValues(bodyValues.Head));

            scaleMap.Add("LeftShoulder", GetParsedValues(bodyValues.LeftShoulder));
            scaleMap.Add("LeftArm", GetParsedValues(bodyValues.LeftArm));
            scaleMap.Add("LeftForeArm", GetParsedValues(bodyValues.LeftForeArm));
            scaleMap.Add("LeftHand", GetParsedValues(bodyValues.LeftHand));
            scaleMap.Add("LeftHandThumb1", GetParsedValues(bodyValues.LeftHandThumb1));
            scaleMap.Add("LeftHandThumb2", GetParsedValues(bodyValues.LeftHandThumb2));
            scaleMap.Add("LeftHandThumb3", GetParsedValues(bodyValues.LeftHandThumb3));
            scaleMap.Add("LeftHandIndex1", GetParsedValues(bodyValues.LeftHandIndex1));
            scaleMap.Add("LeftHandIndex2", GetParsedValues(bodyValues.LeftHandIndex2));
            scaleMap.Add("LeftHandIndex3", GetParsedValues(bodyValues.LeftHandIndex3));
            scaleMap.Add("LeftHandMiddle1", GetParsedValues(bodyValues.LeftHandMiddle1));
            scaleMap.Add("LeftHandMiddle2", GetParsedValues(bodyValues.LeftHandMiddle2));
            scaleMap.Add("LeftHandMiddle3", GetParsedValues(bodyValues.LeftHandMiddle3));
            scaleMap.Add("LeftHandRing1", GetParsedValues(bodyValues.LeftHandRing1));
            scaleMap.Add("LeftHandRing2", GetParsedValues(bodyValues.LeftHandRing2));
            scaleMap.Add("LeftHandRing3", GetParsedValues(bodyValues.LeftHandRing3));
            scaleMap.Add("LeftHandPinky1", GetParsedValues(bodyValues.LeftHandPinky1));
            scaleMap.Add("LeftHandPinky2", GetParsedValues(bodyValues.LeftHandPinky2));
            scaleMap.Add("LeftHandPinky3", GetParsedValues(bodyValues.LeftHandPinky3));

            scaleMap.Add("RightShoulder", GetParsedValues(bodyValues.RightShoulder));
            scaleMap.Add("RightArm", GetParsedValues(bodyValues.RightArm));
            scaleMap.Add("RightForeArm", GetParsedValues(bodyValues.RightForeArm));
            scaleMap.Add("RightHand", GetParsedValues(bodyValues.RightHand));
            scaleMap.Add("RightHandThumb1", GetParsedValues(bodyValues.RightHandThumb1));
            scaleMap.Add("RightHandThumb2", GetParsedValues(bodyValues.RightHandThumb2));
            scaleMap.Add("RightHandThumb3", GetParsedValues(bodyValues.RightHandThumb3));
            scaleMap.Add("RightHandIndex1", GetParsedValues(bodyValues.RightHandIndex1));
            scaleMap.Add("RightHandIndex2", GetParsedValues(bodyValues.RightHandIndex2));
            scaleMap.Add("RightHandIndex3", GetParsedValues(bodyValues.RightHandIndex3));
            scaleMap.Add("RightHandMiddle1", GetParsedValues(bodyValues.RightHandMiddle1));
            scaleMap.Add("RightHandMiddle2", GetParsedValues(bodyValues.RightHandMiddle2));
            scaleMap.Add("RightHandMiddle3", GetParsedValues(bodyValues.RightHandMiddle3));
            scaleMap.Add("RightHandRing1", GetParsedValues(bodyValues.RightHandRing1));
            scaleMap.Add("RightHandRing2", GetParsedValues(bodyValues.RightHandRing2));
            scaleMap.Add("RightHandRing3", GetParsedValues(bodyValues.RightHandRing3));
            scaleMap.Add("RightHandPinky1", GetParsedValues(bodyValues.RightHandPinky1));
            scaleMap.Add("RightHandPinky2", GetParsedValues(bodyValues.RightHandPinky2));
            scaleMap.Add("RightHandPinky3", GetParsedValues(bodyValues.RightHandPinky3));

            scaleMap.Add("LeftUpLeg", GetParsedValues(bodyValues.LeftUpLeg));
            scaleMap.Add("LeftLeg", GetParsedValues(bodyValues.LeftLeg));
            scaleMap.Add("LeftFoot", GetParsedValues(bodyValues.LeftFoot));
            scaleMap.Add("LeftToeBase", GetParsedValues(bodyValues.LeftToeBase));
            scaleMap.Add("LeftToe_End", GetParsedValues(bodyValues.LeftToe_End));

            scaleMap.Add("RightUpLeg", GetParsedValues(bodyValues.RightUpLeg));
            scaleMap.Add("RightLeg", GetParsedValues(bodyValues.RightLeg));
            scaleMap.Add("RightFoot", GetParsedValues(bodyValues.RightFoot));
            scaleMap.Add("RightToeBase", GetParsedValues(bodyValues.RightToeBase));
            scaleMap.Add("RightToe_End", GetParsedValues(bodyValues.RightToe_End));
        }
        onComplete.Invoke();
    }

    // Access x, y, z values
    Vector3 GetParsedValues(string obj)
    {
        JObject armatureObject = JObject.Parse(obj);
        float x = (float)armatureObject["x"];
        float y = (float)armatureObject["y"];
        float z = (float)armatureObject["z"];
        return new Vector3(x, y, z);
    }
}



