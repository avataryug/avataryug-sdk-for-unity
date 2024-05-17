using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using Com.Avataryug.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Com.Avataryug
{

    public static class ExtensionMethods
    {

        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }
        public static ContainerSetting GetContainerSetting(this GetEconomyContainersResultDataInner result)
        {
            return JsonUtility.FromJson<ContainerSetting>(result.ContainerSettings);
        }
        public static LinkedAcounts GetLinkedAcounts(this LoginWithAndroidDeviceIDResultData result)
        {
            return JsonUtility.FromJson<LinkedAcounts>("{" + "\"linkedAcounts\":" + result.LinkedAccounts + "}");
        }
        public static LinkedAcounts GetLinkedAcounts(this RegisterUserResponseData result)
        {
            return JsonUtility.FromJson<LinkedAcounts>("{" + "\"linkedAcounts\":" + result.LinkedAccounts + "}");
        }
        public static ContainerBundleContents GetContainerContents(this GetEconomyContainersResultDataInner result)
        {
            return JsonUtility.FromJson<ContainerBundleContents>(result.ContainerContents);
        }
        public static ContainerBundleContents GetContainerContents(this GetEconomyContainerByIDResult result)
        {
            return JsonUtility.FromJson<ContainerBundleContents>(result.Data.ContainerContents);
        }
        public static ContainerBundleContents GetContainerContents(this GetEconomyContainerByIDResultData result)
        {
            return JsonUtility.FromJson<ContainerBundleContents>(result.ContainerContents);
        }
        public static ContainerBundleContents GetItemContents(this GetEconomyContainerByIDResultData result)
        {
            return JsonUtility.FromJson<ContainerBundleContents>(result.ContainerContents);
        }

        public static ContainerBundleContents GetBunldeContents(this GetEconomyBundlesResultDataInner result)
        {
            return JsonUtility.FromJson<ContainerBundleContents>(result.BundleContents);
        }

        public static Wallets GetWallets(this GetUserAccountInfoResultData result)
        {
            return JsonUtility.FromJson<Wallets>("{" + "\"wallets\":" + result.Wallet + "}");
        }
        public static ContainerBundleContents GetBunldeContents(this GetEconomyBundleByIDResultData result)
        {
            return JsonUtility.FromJson<ContainerBundleContents>(result.BundleContents);
        }
        public static VirtualCurrencys GetContainerVirtualCurrency(this GetEconomyContainersResultDataInner result)
        {
            return JsonUtility.FromJson<VirtualCurrencys>("{" + "\"currencyPrises\":" + result.VirtualCurrency + "}");
        }
        public static VirtualCurrencys GetContainerVirtualCurrency(this GetEconomyBundleByIDResultData result)
        {
            return JsonUtility.FromJson<VirtualCurrencys>("{" + "\"currencyRewards\":" + result.VirtualCurrency + "}");
        }
        public static VirtualCurrencys GetContainerVirtualCurrency(this GetAvatarPresetsResultDataInner result)
        {
            return JsonUtility.FromJson<VirtualCurrencys>("{" + "\"currencyRewards\":" + result.VirtualCurrency + "}");
        }

        public static RewaredAdsRewards GetRewaredAdsRewards(this GetRewardedAdPlacementsResultData result)
        {
            return JsonUtility.FromJson<RewaredAdsRewards>("{" + "\"rewards\":" + result.Rewards + "}");
        }

        public static PropColors GetPropColor(this GetAvatarPresetsResultDataInner result)
        {
            return JsonUtility.FromJson<PropColors>(result.Color);
        }
        public static Props GetPropsD(this GetAvatarPresetsResultDataInner result)
        {
            return JsonUtility.FromJson<Props>("{" + "\"props\":" + JsonConvert.DeserializeObject(result.Props) + "}");
        }
        public static Props GetProps(this GetAvatarPresetsResultDataInner result)
        {
            return JsonUtility.FromJson<Props>("{" + "\"props\":" + result.Props + "}");
        }
        public static AvatarPresetArtifacts GetAvatarPresetArtifacts(this GetAvatarPresetsResultDataInner result)
        {
            return JsonUtility.FromJson<AvatarPresetArtifacts>("{" + "\"artifacts\":" + JsonConvert.DeserializeObject(result.MeshArtifacts) + "}");
        }
        public static ItemThumbnailsUrls GetItemThumbnailsUrls(this GetAvatarPresetsResultDataInner result)
        {
            return JsonUtility.FromJson<ItemThumbnailsUrls>("{" + "\"itemThumbnails\":" + JsonConvert.DeserializeObject(result.ImageArtifacts) + "}");
        }

        public static ItemThumbUrls GetItemThumbnUrls(this GetEconomyItemsByIDResult result)
        {
            return JsonUtility.FromJson<ItemThumbUrls>("{" + "\"itemThumbnails\":" + JsonConvert.DeserializeObject(result.Data.ItemThumbnailsUrl) + "}");
        }

        //public static ExpThumbnailUrls GetExpThumbnailUrls(this GetExpressionsResponseDataInner result)
        //{
        //    return JsonUtility.FromJson<ExpThumbnailUrls>("{" + "\"itemThumbnails\":" + JsonConvert.DeserializeObject(result.ThumbnailUrl) + "}");
        //}
        //public static ClipArtifacts GetClipArtifacts(this GetClipsResponseDataInner result)
        //{
        //    return JsonUtility.FromJson<ClipArtifacts>("{" + "\"artifacts\":" + JsonConvert.DeserializeObject(result.Artifacts) + "}");
        //}

        //public static ClipThumbnailUrls GetClipThumbnailUrls(this GetClipsResponseDataInner result)
        //{
        //    return JsonUtility.FromJson<ClipThumbnailUrls>("{" + "\"itemThumbnails\":" + JsonConvert.DeserializeObject(result.ThumbnailUrl) + "}");
        //}
        public static BlendShapes GetAvatarPresetBlendShapes(this GetAvatarPresetsResultDataInner result)
        {
            return JsonUtility.FromJson<BlendShapes>("{" + "\"blendShapes\":" + result.BlendshapeKeys + "}");

        }
        public static BlendShapes GetEconomyItemBlendShapes(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<BlendShapes>("{" + "\"blendShapes\":" + result.BlendshapeKeys + "}");
        }

        public static BlendShapesExp GetBlendShapes(this GetExpressionsResponseDataInner result)
        {
            return JsonUtility.FromJson<BlendShapesExp>("{" + "\"blendShapes\":" + result.BlendshapeKeys + "}");
        }
        public static Configs GetConfig(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<Configs>(result.Config);
        }
        public static Configs GetConfig(this GetUserAvatarAllDataResponseDataInner result)
        {
            return JsonUtility.FromJson<Configs>(result.Config);
        }
        public static ConflictingBuckets GetConflictingBuckets(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<ConflictingBuckets>("{" + "\"buckets\":" + result.ConflictingBuckets + "}");
        }
        public static ConflictingBuckets GetConflictingBuckets(this GetUserAvatarAllDataResponseDataInner result)
        {
            return JsonUtility.FromJson<ConflictingBuckets>("{" + "\"buckets\":" + result.ConflictingBuckets + "}");
        }

        public static BlendShapes GetEconomyItemBlendShapes(this GetUserAvatarAllDataResponseDataInner result)
        {
            return JsonUtility.FromJson<BlendShapes>("{" + "\"blendShapes\":" + result.BlendshapeKeys + "}");
        }

        public static Tags GetTags(this GetAvatarPresetsResultDataInner result)
        {
            return JsonUtility.FromJson<Tags>("{" + "\"tags\":" + result.Tags + "}");
        }
        public static Tags GetTags(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<Tags>("{" + "\"tags\":" + result.Tags + "}");
        }
        public static ThreeDArtifacts GetThreeDArtifacts(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<ThreeDArtifacts>("{" + "\"artifacts\":" + result.Artifacts + "}");
        }
        public static ThreeDArtifacts GetThreeDArtifacts(this EconomyItems result)
        {
            return JsonUtility.FromJson<ThreeDArtifacts>("{" + "\"artifacts\":" + result.Artifacts + "}");
        }
        public static TwoDArtifacts GetTwoDArtifacts(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<TwoDArtifacts>("{" + "\"artifacts\":" + result.Artifacts + "}");
        }
        public static TwoDArtifacts GetTwoDArtifacts(this EconomyItems result)
        {
            return JsonUtility.FromJson<TwoDArtifacts>("{" + "\"artifacts\":" + result.Artifacts + "}");
        }
        public static SkinToneArtifacts GetSkinToneArtifacts(this EconomyItems result)
        {
            return JsonUtility.FromJson<SkinToneArtifacts>("{" + "\"artifacts\":" + result.Artifacts + "}");
        }

        public static Entitlements GetEntitlement(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<Entitlements>(result.Entitlement);
        }
        public static VirtualCurrencysResult GetVirtualCurrencys(this GetEconomyBundlesResultDataInner result)
        {
            return JsonUtility.FromJson<VirtualCurrencysResult>("{" + "\"virtualCurrencys\":" + result.VirtualCurrency + "}");
        }

        public static VirtualCurrencysResult GetVirtualCurrencys(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<VirtualCurrencysResult>("{" + "\"virtualCurrencys\":" + result.VirtualCurrency + "}");
        }

        public static ItemThumbUrls GetItemThumbnailsUrls(this GetEconomyItemsResultDataInner result)
        {
            return JsonUtility.FromJson<ItemThumbUrls>("{" + "\"itemThumbnails\":" + result.ItemThumbnailsUrl + "}");
        }

        public static ConflictingBuckets GetConflictingBuckets(this GetEconomyItemsByIDResultData result)
        {
            return JsonUtility.FromJson<ConflictingBuckets>("{" + "\"buckets\":" + result.ConflictingBuckets + "}");
        }
        public static Configs GetConfig(this GetEconomyItemsByIDResultData result)
        {
            return JsonUtility.FromJson<Configs>(result.Config);
        }
        public static Entitlements GetEntitlement(this GetEconomyItemsByIDResultData result)
        {
            return JsonUtility.FromJson<Entitlements>(result.Entitlement);
        }

        public static Tags GetTags(this GetEconomyItemsByIDResultData result)
        {
            return JsonUtility.FromJson<Tags>("{" + "\"tags\":" + result.Tags + "}");
        }
        public static BlendShapes GetEconomyItemBlendShapes(this GetEconomyItemsByIDResultData result)
        {
            return JsonUtility.FromJson<BlendShapes>("{" + "\"blendShapes\":" + result.BlendshapeKeys + "}");
        }
        public static VirtualCurrencysResult GetVirtualCurrencys(this GetEconomyItemsByIDResultData result)
        {
            return JsonUtility.FromJson<VirtualCurrencysResult>("{" + "\"virtualCurrencys\":" + result.VirtualCurrency + "}");
        }
        public static ItemThumbUrls GetItemThumbnailsUrls(this GetEconomyItemsByIDResultData result)
        {
            return JsonUtility.FromJson<ItemThumbUrls>("{" + "\"itemThumbnails\":" + result.ItemThumbnailsUrl + "}");
        }
    }
    /// <summary>
    /// This method return device platform
    /// </summary>
    /// <returns></returns>
    public class Utility
    {
        public static void ClearCatche()
        {
            Resources.UnloadUnusedAssets();
            Caching.ClearCache();
        }
        public static Platfroms GetPlatfrom()
        {
            Platfroms platfroms = Platfroms.Android;
#if UNITY_ANDROID
            platfroms = Platfroms.Android;
#endif
#if UNITY_IOS
                        platfroms = Platfroms.iOS;
#endif
            return platfroms;
        }

        public static Color GetColor(string hexColor)
        {
            Color color = Color.white;
            ColorUtility.TryParseHtmlString(hexColor, out color);
            return color;
        }
        public static async void DelayCall(int time, Action onCOmplete)
        {
            await Task.Delay(time);
            onCOmplete?.Invoke();
        }
        public static bool IsInternetConnected()
        {
            return Application.internetReachability != NetworkReachability.NotReachable;
        }
        public static string GetAlphabets(int id)
        {
            int no = id + 65;
            return ((char)no).ToString();
        }


        public static DateTime GetIntToTime(string update_time)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            return dtDateTime.AddSeconds(int.Parse(update_time)).ToLocalTime();
        }

        public static string GetCombineList(List<string> datalist, string symbol)
        {
            string output = string.Empty;
            for (int i = 0; i < datalist.Count; i++)
            {
                if (i == datalist.Count - 1)
                {
                    output += datalist[i];
                }
                else
                {
                    output += datalist[i] + symbol;
                }
            }
            return output;
        }

        public static IEnumerator UpdateLayout(HorizontalLayoutGroup group)
        {
            yield return new WaitForEndOfFrame();
            group.spacing += 0.1f;
            yield return new WaitForEndOfFrame();
            group.spacing -= 0.1f;
        }
        public static IEnumerator UpdateLayout(VerticalLayoutGroup[] group)
        {
            yield return new WaitForEndOfFrame();
            foreach (var item in group)
            {
                item.spacing += 5f;
                item.spacing -= 5f;
            }
        }
        public static IEnumerator UpdateLayout(VerticalLayoutGroup group)
        {
            yield return new WaitForEndOfFrame();
            group.spacing -= 5f;
            group.spacing += 5f;
        }
        public static IEnumerator UpdateLayout(GridLayoutGroup group)
        {
            yield return new WaitForEndOfFrame();
            group.spacing += new Vector2(0.1f, 0.1f);
            group.spacing -= new Vector2(0.1f, 0.1f);
        }
        public static string TextWithColor(object text, Color color)
        {
            string colorstring = ColorUtility.ToHtmlStringRGBA(color);
            return "<color=#" + colorstring + ">" + text + "</color>";
        }
        public static string TextWithColor(object text, string htmlcolor)
        {
            if (htmlcolor.Contains("#"))
                htmlcolor = htmlcolor.Substring(1);
            return "<color=#" + htmlcolor + ">" + text + "</color>";
        }
        public const string latinregex = "^[a-zA-Z0-9]*$";

        public const string MatchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" +
                                                @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{3,4})$";

        public static string UsernameMatchPattern1 = @"\d{4}$";

        public static string[] UsernameMatchPattern = new string[8] { @"\d{1}$", @"\d{2}$", @"\d{3}$", @"\d{4}$", @"\d{5}$", @"\d{6}$", @"\d{7}$", @"\d{8}$" };

        public static Vector2Int MetaCheckPassword(string password)
        {
            Vector2Int vectors = new Vector2Int(0, 0);
            bool hasNum = false; bool hasCap = false; bool hasLow = false; bool hasSpec = false; char currentCharacter;
            if (!(password.Length >= 8))
            {
                vectors.x = 0;
            }
            else
            {
                vectors.x = 1;
            }

            for (int i = 0; i < password.Length; i++)
            {
                currentCharacter = password[i];
                if (char.IsDigit(currentCharacter))
                {
                    hasNum = true;
                }
                else
                if (char.IsUpper(currentCharacter))
                {
                    hasCap = true;
                }
                else
                if (char.IsLower(currentCharacter))
                {
                    hasLow = true;
                }
                else
                if (!char.IsLetterOrDigit(currentCharacter))
                {
                    hasSpec = true;
                }
            }
            Debug.Log(hasNum + "hasNum" + hasCap + "hasCap" + hasLow + "hasLow" + hasSpec + "hasSpec");
            if (hasNum && hasCap && hasLow && hasSpec)
            {
                vectors.y = 1;
            }
            else
            {
                vectors.y = 0;
            }

            Debug.Log(vectors);
            return vectors;
        }
        public static Vector3Int CheckPassword(string password, string userName)
        {
            Vector3Int vectors = new Vector3Int(0, 0, 0);
            bool hasNum = false; bool hasCap = false; bool hasLow = false; bool hasSpec = false; char currentCharacter;
            if (!(password.Length >= 6))
            {
                vectors.x = 0;
            }
            else
            {
                vectors.x = 1;
            }
            if (string.IsNullOrEmpty(userName))
            {
                vectors.y = 1;
            }
            else
            {
                if (password != userName)
                {
                    vectors.y = 1;
                }
                else
                {
                    vectors.y = 0;
                }
            }

            for (int i = 0; i < password.Length; i++)
            {
                currentCharacter = password[i];
                if (char.IsDigit(currentCharacter))
                {
                    hasNum = true;
                }
                else
                if (char.IsUpper(currentCharacter))
                {
                    hasCap = true;
                }
                else
                if (char.IsLower(currentCharacter))
                {
                    hasLow = true;
                }
                else
                if (!char.IsLetterOrDigit(currentCharacter))
                {
                    hasSpec = true;
                }
            }
            if (hasNum && hasCap && hasLow && hasSpec)
            {
                vectors.z = 1;
            }
            else
            {
                vectors.z = 0;
            }

            return vectors;
        }
        public static void SaveJsonFile(string _fileName, string data)
        {
            string path = "Assets/Resources/" + _fileName + ".json";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(data);
            writer.Close();
        }
        public static IEnumerator DelayCall(float time, Action start, Action end)
        {
            start?.Invoke();
            yield return new WaitForSeconds(time);
            end?.Invoke();
        }

        public static async void ValueToSync(float start, float end, float time, Action<float> value = null, Action oncomplete = null)
        {
            float elapsedTime = 0;
            while (elapsedTime < time)
            {
                value.Invoke(Mathf.Lerp(start, end, (elapsedTime / time)));
                elapsedTime += Time.deltaTime;
                await Task.Yield();
            }

            value.Invoke(end);
            oncomplete?.Invoke();
        }
        public static IEnumerator ValueTo(float start, float end, float time, Action<float> value = null, Action oncomplete = null)
        {
            float elapsedTime = 0;
            while (elapsedTime < time)
            {
                value.Invoke(Mathf.Lerp(start, end, (elapsedTime / time)));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            value.Invoke(end);
            oncomplete?.Invoke();
        }
        public static IEnumerator LoadImage(string url, Image image)
        {
            if (image == null)
            {
                yield return new WaitForEndOfFrame();
                Debug.Log("Image should not be empty");
            }
            else
            {
                if (!string.IsNullOrEmpty(url))
                {
                    Texture2D temptex = null;
                    if (!string.IsNullOrEmpty(url))
                    {
                        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
                        www.SendWebRequest();
                        while (!www.isDone)
                        {
                            yield return null;
                        }
                        if (www.error == null)
                        {
                            temptex = DownloadHandlerTexture.GetContent(www);
                        }
                        image.sprite = Sprite.Create(temptex, new Rect(0, 0, temptex.width, temptex.height), new Vector2(0.5f, 0.5f));
                        image.color = Color.white;
                    }
                }
            }
        }
        public static IEnumerator LoadImage(string url, string username, Action<Texture> callback)
        {
            //Debug.Log("called");
            Texture2D temptex = null;
            if (!string.IsNullOrEmpty(url))
            {
                UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
                www.SendWebRequest();
                while (!www.isDone)
                {
                    yield return null;
                }
                if (www.error == null)
                {
                    temptex = DownloadHandlerTexture.GetContent(www);
                }
                callback?.Invoke(temptex);
                //  var bytes = temptex.EncodeToPNG();
                // SaveSystem.Save("avatarurl", bytes.ToString());

                //image.sprite = Sprite.Create(temptex, new Rect(0, 0, temptex.width, temptex.height), new Vector2(0.5f, 0.5f));
                //image.color = Color.white;
            }
        }
        public static AvatarLocalData GetLocalData()
        {
            return Resources.Load<AvatarLocalData>("AvatarLocalData");
        }

        public static string GetRandomFourDigit()
        {
            string no = string.Empty;
            no = UnityEngine.Random.Range(0, 9999).ToString();
            if (no.Length == 3)
            {
                no = "0" + no;
            }
            else
            if (no.Length == 2)
            {
                no = "00" + no;
            }
            else if (no.Length == 1)
            {
                no = "000" + no;
            }
            return no;
        }

        public static bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }

        public static Color StringToColor(string colorID)
        {
            Color color = Color.white;
            ColorUtility.TryParseHtmlString(colorID, out color);
            return color;
        }

        private static readonly SortedDictionary<long, string> abbrevations = new SortedDictionary<long, string>() { { 1000, "K" }, { 1000000, "M" }, { 1000000000, "B" }, { 1000000000000, "T" } };

        public static string AbbreviateNumber(float number)
        {
            for (int i = abbrevations.Count - 1; i >= 0; i--)
            {
                KeyValuePair<long, string> pair = abbrevations.ElementAt(i);
                if (Mathf.Abs(number) >= pair.Key)
                {
                    int roundedNumber = Mathf.FloorToInt(number / pair.Key);
                    return roundedNumber.ToString() + pair.Value;
                }
            }
            return number.ToString();
        }

    }
}


