using System;
using UnityEngine;
using Com.Avataryug.Model;
using System.Collections.Generic;
using Com.Avataryug.Handler;
using System.IO;
[System.Serializable]
public class VertexDataClass
{
    public int Code;
    public string Status;
    public List<VetexDetail> Data = new List<VetexDetail>();
}
[System.Serializable]
public class VetexDetail
{
    public string BucketName;
    public string MainCatID;
    public string Platform;
    public string VertexArray;
    public string Meta;
    public string ID;
}

namespace Com.Avataryug
{
    /// <summary>
    /// Head model 
    /// </summary>
    public class HeadModel : MonoBehaviour
    {
        /// All vertex point local position
        private List<Vector3> headPosition = new List<Vector3>();

        /// Face Material
        [HideInInspector] public Material headMaterial;
        [HideInInspector] public Material eyeballmaterial;
        [HideInInspector] public Material innermaterial;
        //  public BlendShapePoint m_BlendShapePoint;

        /// Renderers to modify shape and material
        public SkinnedMeshRenderer headRenderer;
        public SkinnedMeshRenderer eyeRenderer;
        public SkinnedMeshRenderer mouthRenderer;

       public VertexDataClass verticesResult;

#if DEMO_AVATARYUG
        public EyeBlink m_EyeBlink;
#endif
        /// <summary>
        /// Store facewear points list
        public List<VertexDatas> m_VertexPointerData = new List<VertexDatas>();

        /// Current Avatar script reference
        public CustomizeAvatarLoader customizeAvatarLoader;

        /// Head parent to calcualte facewear vertex point world position
        public Transform headParent;

        /// Subscrible event
        private void OnEnable()
        {
            if (customizeAvatarLoader == null)
            {
                customizeAvatarLoader = GetComponentInParent<CustomizeAvatarLoader>();
            }

            ApiEvents.OnChangeColor += ApiEvents_OnChangeSkinColor;
        }

        /// Desubscrible event
        private void OnDisable()
        {
            ApiEvents.OnChangeColor -= ApiEvents_OnChangeSkinColor;
        }

        /// <summary>
        /// Assing material to eyeball and head material
        /// </summary>
        /// <param name="OnComplete"></param>
        public void LoadHeadwearPoints(Action OnComplete)
        {
            if (customizeAvatarLoader == null)
            {
                customizeAvatarLoader = GetComponentInParent<CustomizeAvatarLoader>();
            }

            GetSkinnedMesh();
            if (eyeRenderer != null)
            {
                eyeRenderer.material = eyeballmaterial;
            }
            if (mouthRenderer != null)
            {
                mouthRenderer.material = innermaterial;
            }
            if (headRenderer != null)
            {
                headMaterial.SetTexture("_MainTex", customizeAvatarLoader.avatarLocalData.baseSkinTexture);
                headMaterial.SetColor("_Color", Color.white);
                headRenderer.material = headMaterial;
#if DEMO_AVATARYUG
                m_EyeBlink = this.gameObject.AddComponent<EyeBlink>();
                m_EyeBlink.skinnedMeshRenderer = headRenderer;
#endif
            }

            Mesh mesh = new Mesh();
            headRenderer.BakeMesh(mesh);
            mesh.GetVertices(headPosition);
            mesh.Clear();
            LoadConflictVertexPoint(OnComplete);
        }
        /// <summary>
        /// Update facewear point position when changes
        /// </summary>

        public void  UpdateFacePoints()
        {
            Mesh mesh = new Mesh();
            headRenderer.BakeMesh(mesh);
            mesh.GetVertices(headPosition);
            mesh.Clear();
            foreach (var item in m_VertexPointerData)
            {
                Vector3 worldPosVertex = transform.localToWorldMatrix.MultiplyPoint3x4(headPosition[item.SinglePointIndex]);
                item.pointTransform.position = worldPosVertex;
                item.pointTransform.localEulerAngles = Vector3.zero;
            }
        }

        /// <summary>
        /// Load Vertex point data from netwrok and create point in face to load facewears
        /// </summary>
        /// <param name="OnComplete"></param>
        void LoadConflictVertexPoint(Action OnComplete)
        {
            Quaternion pointRotation = Quaternion.identity;
            Transform[] childs = transform.GetComponentsInChildren<Transform>();
            foreach (var item in childs)
            {
                if (item.gameObject.name == "mixamorig:Head" || item.gameObject.name == "Head")
                {
                    headParent = item;
                    break;
                }
            }

            VertexDataClass result = JsonUtility.FromJson<VertexDataClass>(customizeAvatarLoader.avatarLocalData.vertexData.text);
            
                verticesResult = result;
                for (int i = 0; i < verticesResult.Data.Count; i++)
                {
                    var toInt = verticesResult.Data[i].VertexArray.Replace("[", "").Replace("]", "");

                    if (toInt.Contains(","))
                    {
                        var data = toInt.Split(',');
                        int num = int.Parse(data[0]);
                        int num2 = int.Parse(data[1]);

                        string Vertexname = result.Data[i].BucketName + "_Left";
                        GameObject tempHolder = new GameObject();
                        tempHolder.name = Vertexname;
                        m_VertexPointerData.Add(new VertexDatas()
                        {
                            BucketName = verticesResult.Data[i].BucketName,
                            MainCatID = verticesResult.Data[i].MainCatID,
                            Platform = verticesResult.Data[i].Platform,
                            SinglePointIndex = num,
                            Meta = verticesResult.Data[i].Meta,
                            ID = verticesResult.Data[i].ID,
                            pointTransform = tempHolder.transform,
                            VertexArray = verticesResult.Data[i].VertexArray
                        });

                        tempHolder.transform.rotation = Quaternion.identity;
                        tempHolder.transform.SetParent(headParent.transform);
                        tempHolder.transform.position = headParent.localToWorldMatrix.MultiplyPoint3x4(headPosition[num]);
                        tempHolder.transform.localRotation = pointRotation;
                        string Vertexname2 = result.Data[i].BucketName + "_right";
                        GameObject tempHolder2 = new GameObject();
                        tempHolder2.name = Vertexname2;

                        m_VertexPointerData.Add(new VertexDatas()
                        { BucketName = verticesResult.Data[i].BucketName, MainCatID = verticesResult.Data[i].MainCatID, Platform = verticesResult.Data[i].Platform, SinglePointIndex = num2, Meta = verticesResult.Data[i].Meta, ID = verticesResult.Data[i].ID, pointTransform = tempHolder2.transform, VertexArray = verticesResult.Data[i].VertexArray });

                        tempHolder2.transform.rotation = Quaternion.identity;
                        tempHolder2.transform.SetParent(headParent.transform);
                        tempHolder2.transform.position = headParent.localToWorldMatrix.MultiplyPoint3x4(headPosition[num2]);
                        tempHolder.transform.localRotation = pointRotation;
                    }
                    else
                    {
                        int num = int.Parse(toInt);
                        GameObject tempHolder = new GameObject();
                        tempHolder.name = result.Data[i].BucketName;

                        m_VertexPointerData.Add(new VertexDatas()
                        {
                            BucketName = verticesResult.Data[i].BucketName,
                            MainCatID = verticesResult.Data[i].MainCatID,
                            Platform = verticesResult.Data[i].Platform,
                            SinglePointIndex = num,
                            Meta = verticesResult.Data[i].Meta,
                            ID = verticesResult.Data[i].ID,
                            pointTransform = tempHolder.transform,
                            VertexArray = verticesResult.Data[i].VertexArray
                        });

                        Vector3 worldPosVertex = headParent.localToWorldMatrix.MultiplyPoint3x4(headPosition[num]);
                        tempHolder.transform.rotation = Quaternion.identity;

                        if (headParent != null)
                        {
                            tempHolder.transform.SetParent(headParent.transform);
                        }
                        else
                        {
                            tempHolder.transform.SetParent(headRenderer.transform);
                        }
                        tempHolder.transform.position = worldPosVertex;
                        tempHolder.transform.localRotation = pointRotation;
                    }
                }
                OnComplete?.Invoke();
        }

        /// <summary>
        /// Change Color of selected category lips, eyebrow, hair, facialhair
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApiEvents_OnChangeSkinColor(object sender, Color e)
        {
            if (sender != null)
            {
                if (sender.ToString() == "Eyebrow")
                {
#if DEMO_AVATARYUG
                    CurrentAvatarChanges.Instance.changePropColors.EyebrowColor = "#" + ColorUtility.ToHtmlStringRGB(e).ToLower();
#endif
                    headMaterial.SetColor("_EyebrowColor", e);
                }
                if (sender.ToString() == "Hair")
                {
                    headMaterial.SetColor("_HairColor", e);

                }

                if (sender.ToString() == "Lips")
                {
#if DEMO_AVATARYUG
                    CurrentAvatarChanges.Instance.changePropColors.LipColor = "#" + ColorUtility.ToHtmlStringRGB(e).ToLower();
#endif
                    headMaterial.SetColor("_LipsColor", e);
                }
                if (sender.ToString() == "Facialhair")
                {
#if DEMO_AVATARYUG
                    CurrentAvatarChanges.Instance.changePropColors.FacialHairColor = "#" + ColorUtility.ToHtmlStringRGB(e).ToLower();
#endif
                    headMaterial.SetColor("_BeardColor", e);
                }
            }
        }

        /// <summary>
        /// Change Face Expressions
        /// </summary>
        /// <param name="blendShapes"></param>
        /// <param name="shootheffect"></param>
        public void SetExpression(List<BlendShapeExp> blendShapes, bool shootheffect = false)
        {
            GetSkinnedMesh();

            foreach (var shape in blendShapes)
            {
                for (int a = 0; a < headRenderer.sharedMesh.blendShapeCount; a++)
                {
                    int index = a;
                    headRenderer.SetBlendShapeWeight(index, 0);
                    string blendshapename = headRenderer.sharedMesh.GetBlendShapeName(index);
                    if (blendshapename == shape.selectedShape)
                    {
                        if (shootheffect)
                        {
                            StartCoroutine(Utility.ValueTo(headRenderer.GetBlendShapeWeight(index), (float)shape.sliderValue, 0.5f, (value) =>
                            {
                                headRenderer.SetBlendShapeWeight(index, value);
                            }));
                        }
                        else
                        {
                            headRenderer.SetBlendShapeWeight(index, (float)shape.sliderValue);
                        }
                    }
                }
            }

            foreach (var shape in blendShapes)
            {
                for (int a = 0; a < eyeRenderer.sharedMesh.blendShapeCount; a++)
                {
                    int index = a;
                    eyeRenderer.SetBlendShapeWeight(index, 0);
                    string blendshapename = eyeRenderer.sharedMesh.GetBlendShapeName(index);
                    if (blendshapename == shape.selectedShape)
                    {
                        if (shootheffect)
                        {
                            StartCoroutine(Utility.ValueTo(eyeRenderer.GetBlendShapeWeight(index), (float)shape.sliderValue, 0.5f, (value) =>
                            {
                                eyeRenderer.SetBlendShapeWeight(index, value);
                            }));
                        }
                        else
                        {
                            eyeRenderer.SetBlendShapeWeight(index, (float)shape.sliderValue);
                        }
                    }
                }
            }

            foreach (var shape in blendShapes)
            {
                for (int a = 0; a < mouthRenderer.sharedMesh.blendShapeCount; a++)
                {
                    int index = a;
                    mouthRenderer.SetBlendShapeWeight(index, 0);
                    string blendshapename = mouthRenderer.sharedMesh.GetBlendShapeName(index);
                    if (blendshapename == shape.selectedShape)
                    {
                        if (shootheffect)
                        {
                            StartCoroutine(Utility.ValueTo(mouthRenderer.GetBlendShapeWeight(index), (float)shape.sliderValue, 0.5f, (value) =>
                            {
                                mouthRenderer.SetBlendShapeWeight(index, value);
                            }));
                        }
                        else
                        {
                            mouthRenderer.SetBlendShapeWeight(index, (float)shape.sliderValue);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get Skinned mesh renderer and store in variable
        /// </summary>
        void GetSkinnedMesh()
        {
            if (headRenderer == null)
            {
                SkinnedMeshRenderer[] skinnedMeshes = GetComponentsInChildren<SkinnedMeshRenderer>();
                foreach (var item in skinnedMeshes)
                {
                    if (item.name == "head")
                    {
                        headRenderer = item;
                        headRenderer.updateWhenOffscreen = true;
                    }
                    if (item.name == "eyes")
                    {
                        eyeRenderer = item;
                        eyeRenderer.updateWhenOffscreen = true;
                    }
                    if (item.name == "inner_mouth")
                    {
                        mouthRenderer = item;
                        mouthRenderer.updateWhenOffscreen = true;
                    }
                }
            }
        }

        /// <summary>
        /// Reset all face blendshape
        /// </summary>
        /// <param name="smooth"></param>
        /// <param name="callback"></param>
        public void ResetAllBlendhape()
        {
            GetSkinnedMesh();
            for (int a = 0; a < headRenderer.sharedMesh.blendShapeCount; a++)
            {
                headRenderer.SetBlendShapeWeight(a, 0);
                eyeRenderer.SetBlendShapeWeight(a, 0);
                mouthRenderer.SetBlendShapeWeight(a, 0);
            }
        }

        /// <summary>
        /// Change blendshape of face,eyeball and mouth
        /// </summary>
        /// <param name="blendShape"></param>
        /// <param name="shootheffect"></param>
        public void SetBlendShape(Blendshape blendShape, bool shootheffect = false)
        {
            GetSkinnedMesh();
            for (int a = 0; a < headRenderer.sharedMesh.blendShapeCount; a++)
            {
                string blendshapename = headRenderer.sharedMesh.GetBlendShapeName(a);
                if (blendshapename == blendShape.shapekeys)
                {
                    if (shootheffect)
                    {
                        StartCoroutine(Utility.ValueTo(headRenderer.GetBlendShapeWeight(a), (float)blendShape.value, 0.5f, (value) =>
                        {
                            headRenderer.SetBlendShapeWeight(a, value);
                            //eyeRenderer.SetBlendShapeWeight(a, value);
                          //  mouthRenderer.SetBlendShapeWeight(a, value);
                        }));
                    }
                    else
                    {
                        headRenderer.SetBlendShapeWeight(a, (float)blendShape.value);
                       // eyeRenderer.SetBlendShapeWeight(a, (float)blendShape.value);
                       // mouthRenderer.SetBlendShapeWeight(a, (float)blendShape.value);
                    }
                    break;
                }
            }
            for (int a = 0; a < eyeRenderer.sharedMesh.blendShapeCount; a++)
            {
                string blendshapename = eyeRenderer.sharedMesh.GetBlendShapeName(a);
                if (blendshapename == blendShape.shapekeys)
                {
                    if (shootheffect)
                    {
                        StartCoroutine(Utility.ValueTo(eyeRenderer.GetBlendShapeWeight(a), (float)blendShape.value, 0.5f, (value) =>
                        {
                            eyeRenderer.SetBlendShapeWeight(a, value);
                        }));
                    }
                    else
                    {
                        eyeRenderer.SetBlendShapeWeight(a, (float)blendShape.value);
                    }
                    break;
                }
            }
            for (int a = 0; a < mouthRenderer.sharedMesh.blendShapeCount; a++)
            {
                string blendshapename = mouthRenderer.sharedMesh.GetBlendShapeName(a);
                if (blendshapename == blendShape.shapekeys)
                {
                    if (shootheffect)
                    {
                        StartCoroutine(Utility.ValueTo(mouthRenderer.GetBlendShapeWeight(a), (float)blendShape.value, 0.5f, (value) =>
                        {
                            mouthRenderer.SetBlendShapeWeight(a, value);
                        }));
                    }
                    else
                    {
                        mouthRenderer.SetBlendShapeWeight(a, (float)blendShape.value);
                    }
                    break;
                }
            }
        }
    }
}
