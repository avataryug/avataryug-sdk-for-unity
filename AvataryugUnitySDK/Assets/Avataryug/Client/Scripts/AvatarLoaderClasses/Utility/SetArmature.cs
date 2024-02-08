using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SetArmature : MonoBehaviour
{
    public void AddExtraArmature()
    {
        List<Transform> transforms = transform.GetComponentsInChildren<Transform>().ToList();
        if(transforms.FindAll(f => f.gameObject.name == "Armature").Count == 1)
        {
            foreach (var item in transforms)
            {
                if (item.gameObject.name == "Armature")
                {
                    if (item.transform.parent.name != "Armature")
                    {
                        var parent = item.transform.parent;
                        GameObject obj = new GameObject("Armature");
                        obj.transform.parent = parent;
                        obj.transform.localPosition = Vector3.zero;
                        obj.transform.localEulerAngles = Vector3.zero;
                        item.parent = obj.transform;
                    }
                }
            }
        }
    }  
}
