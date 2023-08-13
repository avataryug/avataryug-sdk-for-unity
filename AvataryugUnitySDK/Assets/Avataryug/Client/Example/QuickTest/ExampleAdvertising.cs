using Com.Avataryug.Client;
using Com.Avataryug.Handler;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug
{
    /// <summary>
    /// This ExampleAdvertising Class demonstrates API calling methods with temporary data.
    /// </summary>
    public class ExampleAdvertising : MonoBehaviour
    {
        public Button getAdPlacementByIDButton;
        public Button grantAdsRewardButton;
        public Button recordAdsActivityButton;

        private void OnEnable()
        {
            if (getAdPlacementByIDButton != null)
            {
                getAdPlacementByIDButton.onClick.RemoveAllListeners();
                getAdPlacementByIDButton.onClick.AddListener(GetAdPlacementByID);
            }
            if (grantAdsRewardButton != null)
            {
                grantAdsRewardButton.onClick.RemoveAllListeners();
                grantAdsRewardButton.onClick.AddListener(GrantsAdsReward);
            }
            if (recordAdsActivityButton != null)
            {
                recordAdsActivityButton.onClick.RemoveAllListeners();
                recordAdsActivityButton.onClick.AddListener(RecordsAdsActivity);
            }
        }

        /// <summary>
        /// Retrieves a list of ad placements by ID
        /// </summary>
        private void GetAdPlacementByID()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetAdsPlacement Button Click---->>>");
            var auth = new AdvertisingHandler(new GetAdsPlacement()
            {
                appID = "a363728f-db74-425b-8f45-942e4c8f2a77"
            });
            auth.GetAdsPlacement((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetAdsPlacement-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetAdsPlacement-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Grants rewards for ads. 
        /// </summary>
        private void GrantsAdsReward()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GrantAdsReward Button Click---->>>");
            var auth = new AdvertisingHandler(new GrantAdsReward()
            {
                PlacementID = "a363728f-db74-425b-8f45-942e4c8f2a77"
            });
            auth.GrantAdsReward((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GrantAdsReward-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GrantAdsReward-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Stores ads activity data for reporting after ad watch 
        /// </summary>
        private void RecordsAdsActivity()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On RecordAdsActivity Button Click---->>>");
            var auth = new AdvertisingHandler(new RecordAdsActivity()
            {
                AdRevenue = 20,
                PlacementID = "a363728f-db74-425b-8f45-942e4c8f2a77",
                RevenueCurrency = "CC"
            });
            auth.RecordAdsActivity((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("RecordAdsActivity-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("RecordAdsActivity-->>" + error.ToJson());
                }
            });
        }


    }
}