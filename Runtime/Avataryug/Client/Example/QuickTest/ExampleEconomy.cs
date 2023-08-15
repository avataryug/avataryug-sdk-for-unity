using Com.Avataryug.Client;
using Com.Avataryug.Handler;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug
{
    /// <summary>
    /// This ExampleEconomy Class demonstrates API calling methods with temporary data.
    /// </summary>
    public class ExampleEconomy : MonoBehaviour
    {
        public Button economyItemsButton;
        public Button economyItemsByIDsButton;
        public Button economyBundlesButton;
        public Button economyBundlesByIDsButton;
        public Button economyContainersButton;
        public Button economyContainersByIDsButton;
        public Button economyStoresButton;
        public Button economyStoresByIDsButton;


        readonly string[] ItemCategory = new string[]
            {
            "LeftHandTattoo","RightHandTattoo","LeftArmTattoo","RightArmTattoo","LeftFootTattoo","RightFootTattoo","FrontLeftLegTattoo",
            "FrontRightLegTattoo","BackBodyTattoo","FrontBodyTattoo","BackLeftLegTattoo","BackRightLegTattoo","HeadTattoo","FaceShape",
            "EyeShape","EyebrowShape","NoseShape","LipShape","EarShape","Hair","Eyebrow","Lips","Facialhair","Headwear","Eyewear",
            "Eyeball","Mouthwear","Earwear","Eyebrowswear","Facewear","Neckwear","Nosewear","Top",
            "Bottom","Outfit","Footwear","Handwear","Wristwear", "SkinTone",
            };
        private void OnEnable()
        {
            if (economyItemsButton != null)
            {
                economyItemsButton.onClick.RemoveAllListeners();
                economyItemsButton.onClick.AddListener(GetEconomyItem);
            }
            if (economyItemsByIDsButton != null)
            {
                economyItemsByIDsButton.onClick.RemoveAllListeners();
                economyItemsByIDsButton.onClick.AddListener(GetEconomyItemsbyIds);
            }
            if (economyBundlesButton != null)
            {
                economyBundlesButton.onClick.RemoveAllListeners();
                economyBundlesButton.onClick.AddListener(GetBundles);
            }
            if (economyBundlesByIDsButton != null)
            {
                economyBundlesByIDsButton.onClick.RemoveAllListeners();
                economyBundlesByIDsButton.onClick.AddListener(GetBundlesByIDs);
            }
            if (economyContainersButton != null)
            {
                economyContainersButton.onClick.RemoveAllListeners();
                economyContainersButton.onClick.AddListener(GetContainers);
            }
            if (economyContainersByIDsButton != null)
            {
                economyContainersByIDsButton.onClick.RemoveAllListeners();
                economyContainersByIDsButton.onClick.AddListener(GetContainersByIDs);
            }
            if (economyStoresButton != null)
            {
                economyStoresButton.onClick.RemoveAllListeners();
                economyStoresButton.onClick.AddListener(GetEconomyStore);
            }
            if (economyStoresByIDsButton != null)
            {
                economyStoresByIDsButton.onClick.RemoveAllListeners();
                economyStoresByIDsButton.onClick.AddListener(GetEconomyStoreById);
            }
        }

        /// <summary>
        /// Get Economy Items
        /// </summary>
        private void GetEconomyItem()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            //Male = 1  Female = 2 //Commong = 3
            Debug.Log("On GetEconomyItems Button Click---->>>");
            string category = ItemCategory[UnityEngine.Random.Range(0, ItemCategory.Length - 1)];
            int gender = 1;
            if (category == "Top" || category == "Bottom" || category == "Outfit")
            {

            }
            else
            {
                gender = 3;
            }
            var auth = new EconomyHandler(new GetEconomyItems()
            {
                category = category,
                status = 1,
                gender = gender
            });
            auth.GetEconomyItems((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetEconomyItem-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetEconomyItem-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get Economy Item by ID
        /// </summary>
        private void GetEconomyItemsbyIds()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetEconomyItemsByID Button Click---->>>");
            var auth = new EconomyHandler(new GetEconomyItemsByID()
            {
                itemID = "00261441-df90-48e7-bd75-87ecac29e303"
            });
            auth.GetEconomyItemsByID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetEconomyItemsByID-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetEconomyItemsByID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get Economy Bundles
        /// </summary>
        private void GetBundles()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetEconomyBundles Button Click---->>>");
            var auth = new EconomyHandler(new GetEconomyBundles()
            {
                bundleStatus = 1
            });
            auth.GetEconomyBundles((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetEconomyBundles-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetEconomyBundles-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get Economy Bundles by ID
        /// </summary>
        private void GetBundlesByIDs()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetEconomyBundleByID Button Click---->>>");
            var auth = new EconomyHandler(new GetEconomyBundleByID()
            {
                bundleID = "1d90bb1e-6370-44e8-b692-a1619391d2a3"
            });
            auth.GetEconomyBundleByID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetEconomyBundleByID-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetEconomyBundleByID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get Economy Containers
        /// </summary>
        private void GetContainers()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetEconomyContainers Button Click---->>>");
            var auth = new EconomyHandler(new GetEconomyContainers()
            {
                containerStatus = 1
            });
            auth.GetEconomyContainers((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetEconomyContainers-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetEconomyContainers-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get Economy Container by ID
        /// </summary>
        private void GetContainersByIDs()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetEconomyContainerByID Button Click---->>>");
            var auth = new EconomyHandler(new GetEconomyContainerByID()
            {
                containerID = "d9c055e5-f9a1-4c9c-8586-da7c9b2ce041"
            });
            auth.GetEconomyContainerByID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetEconomyContainerByID-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetEconomyContainerByID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Get Economy Stores
        /// </summary>
        private void GetEconomyStore()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetEconomyStores Button Click---->>>");
            var auth = new EconomyHandler(new GetEconomyStores()
            {
                storeStatus = 1
            });
            auth.GetEconomyStores((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetEconomyStores-->>" + result.ToJson());

                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetEconomyStores-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        private void GetEconomyStoreById()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetStoreItemsByID Button Click---->>>");
            var auth = new EconomyHandler(new GetStoreItemsByID()
            {
                storeID = "252a6e92-9def-429c-81ec-bad861493510"
            });
            auth.GetStoreItemsByID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetEconomyStoreById-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetEconomyStoreById-->>" + error.ToJson());
                }
            });
        }
    }
}