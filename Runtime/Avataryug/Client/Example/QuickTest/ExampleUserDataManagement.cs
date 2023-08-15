using Com.Avataryug.Client;
using Com.Avataryug.Handler;
using Com.Avataryug.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug
{
    /// <summary>
    /// This ExampleUserDataManagement Class demonstrates API calling methods with temporary data.
    /// </summary>
    public class ExampleUserDataManagement : MonoBehaviour
    {
        public Button getUserInventoryButton;
        public Button getUsersAllAvatarsButton;
        public Button grantInstanceToUserButton;
        public Button updateUserAvatarButton;
        public Button consumeInstanceButton;
        public Button purchaseInstanceButton;
        public Button addVirtualCurrencyToUserButton;
        public Button subtractUserVirtualCurrencyButton;
        public Button addUserAvatarButton;
        public Button deleteUserAvatarButton;
        public Button confirmPurchaseButton;
        public Button getPurchaseButton;
        public Button payForPurchaseButton;
        public Button unlockContainerInstanceButton;

        private void OnEnable()
        {
            if (getUserInventoryButton != null)
            {
                getUserInventoryButton.onClick.RemoveAllListeners();
                getUserInventoryButton.onClick.AddListener(GetuserInventory);
            }
            if (getUsersAllAvatarsButton != null)
            {
                getUsersAllAvatarsButton.onClick.RemoveAllListeners();
                getUsersAllAvatarsButton.onClick.AddListener(GetUsersAllAvatar);
            }
            if (grantInstanceToUserButton != null)
            {
                grantInstanceToUserButton.onClick.RemoveAllListeners();
                grantInstanceToUserButton.onClick.AddListener(GrantsInstanceToUser);
            }
            if (updateUserAvatarButton != null)
            {
                updateUserAvatarButton.onClick.RemoveAllListeners();
                updateUserAvatarButton.onClick.AddListener(UpdateUsersAvatar);
            }
            if (consumeInstanceButton != null)
            {
                consumeInstanceButton.onClick.RemoveAllListeners();
                consumeInstanceButton.onClick.AddListener(ConsumeInstances);
            }
            if (purchaseInstanceButton != null)
            {
                purchaseInstanceButton.onClick.RemoveAllListeners();
                purchaseInstanceButton.onClick.AddListener(PurchasesInstance);
            }
            if (addVirtualCurrencyToUserButton != null)
            {
                addVirtualCurrencyToUserButton.onClick.RemoveAllListeners();
                addVirtualCurrencyToUserButton.onClick.AddListener(AddVirtualCurrencyToUsers);
            }
            if (subtractUserVirtualCurrencyButton != null)
            {
                subtractUserVirtualCurrencyButton.onClick.RemoveAllListeners();
                subtractUserVirtualCurrencyButton.onClick.AddListener(SubtractUsersVirtualCurrency);
            }
            if (addUserAvatarButton != null)
            {
                addUserAvatarButton.onClick.RemoveAllListeners();
                addUserAvatarButton.onClick.AddListener(AddUsersAvatar);
            }
            if (deleteUserAvatarButton != null)
            {
                deleteUserAvatarButton.onClick.RemoveAllListeners();
                deleteUserAvatarButton.onClick.AddListener(DeleteUsersAvatar);
            }
            if (confirmPurchaseButton != null)
            {
                confirmPurchaseButton.onClick.RemoveAllListeners();
                confirmPurchaseButton.onClick.AddListener(ConfirmPurchase);
            }
            if (getPurchaseButton != null)
            {
                getPurchaseButton.onClick.RemoveAllListeners();
                getPurchaseButton.onClick.AddListener(GetPurchase);
            }
            if (payForPurchaseButton != null)
            {
                payForPurchaseButton.onClick.RemoveAllListeners();
                payForPurchaseButton.onClick.AddListener(PayForPurchase);
            }
            if (unlockContainerInstanceButton != null)
            {
                unlockContainerInstanceButton.onClick.RemoveAllListeners();
                unlockContainerInstanceButton.onClick.AddListener(UnlockContainersInstance);
            }
        }

        /// <summary>
        /// Retrieves the user's current inventory of virtual goods
        /// </summary>
        private void GetuserInventory()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetUserInventory Button Click---->>>");
            var auth = new UserDataManagementHandler(new GetUserInventory());
            auth.GetUserInventory((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetUserInventory-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetUserInventory-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Lists all of the avatars that belong to a specific user
        /// </summary>
        private void GetUsersAllAvatar()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetUsersAllAvatars Button Click---->>>");
            var auth = new UserDataManagementHandler(new GetUsersAllAvatars()
            {
                userID = Configuration.userIds
            });
            auth.GetUsersAllAvatars((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetUsersAllAvatars-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetUsersAllAvatars-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Adds the specified items to the specified user's inventory
        /// </summary>
        private void GrantsInstanceToUser()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GrantInstanceToUser Button Click---->>>");
            var auth = new UserDataManagementHandler(new GrantInstanceToUser()
            {

            });
            auth.GrantInstanceToUser((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GrantInstanceToUser-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GrantInstanceToUser-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Update Avatar for the user
        /// </summary>
        private void UpdateUsersAvatar()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UpdateUserAvatar Button Click---->>>");
            var auth = new UserDataManagementHandler(new UpdateUserAvatar()
            {
                AvatarID = "",
                AvatarData = "",
            });
            auth.UpdateUserAvatar((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UpdateUserAvatar-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UpdateUserAvatar-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the user's inventory.
        /// </summary>
        private void ConsumeInstances()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On ConsumeInstance Button Click---->>>");
            var auth = new UserDataManagementHandler(new ConsumeInstance()
            {
                InstanceCount = 1,
                InstanceID = ""

            });
            auth.ConsumeInstance((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("ConsumeInstance-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ConsumeInstance-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Buys a single item with virtual currency.
        /// You must specify both the virtual currency to use to purchase, as well as what the client believes the price to be.
        /// This lets the server fail the purchase if the price has changed.
        /// </summary>
        private void PurchasesInstance()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On PurchaseInstance Button Click---->>>");
            var auth = new UserDataManagementHandler(new PurchaseInstance()
            {
                InstanceID = "",
                instanceType = InstanceType.BUNDLE,
                Price = 10,
                VirtualCurrency = "CC",
                StoreID = "",

            });
            auth.PurchaseInstance((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("PurchaseInstance-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("PurchaseInstance-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        private void AddVirtualCurrencyToUsers()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On AddVirtualCurrencyToUser Button Click---->>>");
            var auth = new UserDataManagementHandler(new AddVirtualCurrencyToUser()
            {
                VirtualCurrency = "CN",
                Amount = 100
            });
            auth.AddVirtualCurrencyToUser((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("AddVirtualCurrencyToUser-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("AddVirtualCurrencyToUser-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount.
        /// It is possible to make a VC balance negative with this API.
        /// </summary>
        private void SubtractUsersVirtualCurrency()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On SubtractUserVirtualCurrency Button Click---->>>");
            var auth = new UserDataManagementHandler(new SubtractUserVirtualCurrency()
            {
                VirtualCurrency = "CN",
                Amount = 10
            });
            auth.SubtractUserVirtualCurrency((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("SubtractUsersVirtualCurrency-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("SubtractUsersVirtualCurrency-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Add Avatar to the user
        /// </summary>
        private void AddUsersAvatar()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            var avatardata = new AvatarData();
            Debug.Log("On AddUserAvatar Button Click---->>>");
            var auth = new UserDataManagementHandler(new AddUserAvatar()
            {
                AvatarData = "",
            });
            auth.AddUserAvatar((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("AddUsersAvatar-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("AddUsersAvatar-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Delete specified Avatar for the user
        /// </summary>
        private void DeleteUsersAvatar()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On DeleteUserAvatar Button Click---->>>");
            var auth = new UserDataManagementHandler(new DeleteUserAvatar()
            {
                AvatarID = "sdasdas"
            });
            auth.DeleteUserAvatar((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("DeleteUserAvatar-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("DeleteUserAvatar-->>" + error.ToJson());
                }
            });
        }

        private void ConfirmPurchase()
        {
            Debug.Log("On ConfirmPurchase Button Click---->>>");
            //var auth = new UserDataManagementHandler(new ConfirmPurchase()
            //{
            //    AvatarID = "sdasdas"
            //});
            //auth.DeleteUserAvatar((result) =>
            //{
            //    if (Configuration.avatarProjectSettings.DebugLog)
            //    {
            //        Debug.Log("DeleteUserAvatar-->>" + result.ToJson());
            //    }
            //},
            //(error) =>
            //{
            //    if (Configuration.avatarProjectSettings.DebugLog)
            //    {
            //        Debug.LogError("DeleteUserAvatar-->>" + error.ToJson());
            //    }
            //});
        }

        private void GetPurchase()
        {
            Debug.Log("On GetPurchase Button Click---->>>");
        }

        private void PayForPurchase()
        {
            Debug.Log("On PayForPurchase Button Click---->>>");
        }

        /// <summary>
        /// Opens the specified container, with the specified key (when required), and returns the contents of the opened container.
        /// If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        private void UnlockContainersInstance()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UnlockContainerInstance Button Click---->>>");
            var auth = new UserDataManagementHandler(new UnlockContainerInstance()
            {
                ContainerInstanceID = "containerInstanceID007836",
                KeyInstanceID = "KeyInstanceUnity1292"
            });
            auth.UnlockContainerInstance((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UnlockContainerInstance-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UnlockContainerInstance-->>" + error.ToJson());
                }
            });
        }


    }
}