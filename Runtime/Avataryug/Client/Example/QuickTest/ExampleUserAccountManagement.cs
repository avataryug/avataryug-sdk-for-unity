using Com.Avataryug.Client;
using Com.Avataryug.Handler;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug
{
    /// <summary>
    /// This ExampleUserAccountManagement Class demonstrates API calling methods with temporary data.
    /// </summary>
    public class ExampleUserAccountManagement : MonoBehaviour
    {
        public Button linkCustomIDButton;
        public Button unlinkCustomButton;
        public Button linkAndroidDeviceButton;
        public Button unlinkAndroidDeviceButton;
        public Button linkAppleButton;
        public Button unlinkAppleButton;
        public Button linkIOSButton;
        public Button unlinkIOSButton;
        public Button linkGoogleButton;
        public Button unlinkGoogleButton;
        public Button linkFacebookButton;
        public Button unlinkFacebookeButton;
        public Button addGenericServiceButton;
        public Button removeGenericServiceButton;
        public Button updateDisplayNameButton;
        public Button getUserAccountInfoButton;
        public Button updateUserDemographicButton;
        public Button getUserProfileButton;
        public Button deleteUserButton;
        public Button updateDefaultAvatarButton;
        public Button changePasswordButton;

        private void OnEnable()
        {
            if (linkCustomIDButton != null)
            {
                linkCustomIDButton.onClick.RemoveAllListeners();
                linkCustomIDButton.onClick.AddListener(LinkCustomsID);
            }

            if (unlinkCustomButton != null)
            {
                unlinkCustomButton.onClick.RemoveAllListeners();
                unlinkCustomButton.onClick.AddListener(UnlinkCustomsID);
            }

            if (linkAndroidDeviceButton != null)
            {
                linkAndroidDeviceButton.onClick.RemoveAllListeners();
                linkAndroidDeviceButton.onClick.AddListener(LinkAndroidDevice);
            }
            if (unlinkAndroidDeviceButton != null)
            {
                unlinkAndroidDeviceButton.onClick.RemoveAllListeners();
                unlinkAndroidDeviceButton.onClick.AddListener(UnLinkAndroidDevice);
            }

            if (linkAppleButton != null)
            {
                linkAppleButton.onClick.RemoveAllListeners();
                linkAppleButton.onClick.AddListener(LinksApple);
            }

            if (unlinkAppleButton != null)
            {
                unlinkAppleButton.onClick.RemoveAllListeners();
                unlinkAppleButton.onClick.AddListener(UnLinksApple);
            }

            if (linkIOSButton != null)
            {
                linkIOSButton.onClick.RemoveAllListeners();
                linkIOSButton.onClick.AddListener(LinkIosDevice);
            }

            if (unlinkIOSButton != null)
            {
                unlinkIOSButton.onClick.RemoveAllListeners();
                unlinkIOSButton.onClick.AddListener(UnlinkIosDevice);
            }

            if (linkGoogleButton != null)
            {
                linkGoogleButton.onClick.RemoveAllListeners();
                linkGoogleButton.onClick.AddListener(LinkGoogle);
            }

            if (unlinkGoogleButton != null)
            {
                unlinkGoogleButton.onClick.RemoveAllListeners();
                unlinkGoogleButton.onClick.AddListener(UnlinkGoogle);
            }

            if (linkFacebookButton != null)
            {
                linkFacebookButton.onClick.RemoveAllListeners();
                linkFacebookButton.onClick.AddListener(LinkFB);
            }

            if (unlinkFacebookeButton != null)
            {
                unlinkFacebookeButton.onClick.RemoveAllListeners();
                unlinkFacebookeButton.onClick.AddListener(UnlinkFB);
            }

            if (addGenericServiceButton != null)
            {
                addGenericServiceButton.onClick.RemoveAllListeners();
                addGenericServiceButton.onClick.AddListener(AddGenericService);
            }

            if (removeGenericServiceButton != null)
            {
                removeGenericServiceButton.onClick.RemoveAllListeners();
                removeGenericServiceButton.onClick.AddListener(RemoveGenericService);
            }

            if (updateDisplayNameButton != null)
            {
                updateDisplayNameButton.onClick.RemoveAllListeners();
                updateDisplayNameButton.onClick.AddListener(UpdateProjectDisplayName);
            }

            if (getUserAccountInfoButton != null)
            {
                getUserAccountInfoButton.onClick.RemoveAllListeners();
                getUserAccountInfoButton.onClick.AddListener(GetUserAccountsInfo);
            }
            if (updateUserDemographicButton != null)
            {
                updateUserDemographicButton.onClick.RemoveAllListeners();
                updateUserDemographicButton.onClick.AddListener(UpdateUsersDemographic);
            }
            if (getUserProfileButton != null)
            {
                getUserProfileButton.onClick.RemoveAllListeners();
                getUserProfileButton.onClick.AddListener(GetUsersProfile);
            }
            if (deleteUserButton != null)
            {
                deleteUserButton.onClick.RemoveAllListeners();
                deleteUserButton.onClick.AddListener(DeleteUsers);
            }
            if (updateDefaultAvatarButton != null)
            {
                updateDefaultAvatarButton.onClick.RemoveAllListeners();
                updateDefaultAvatarButton.onClick.AddListener(UpdateDefaultAvatarsID);
            }
            if (changePasswordButton != null)
            {
                changePasswordButton.onClick.RemoveAllListeners();
                changePasswordButton.onClick.AddListener(Changepassword);
            }
        }

        /// <summary>
        /// Links the custom identifier, generated by the Project, to the user's Avataryug account
        /// </summary>
        private void LinkCustomsID()
        {
            Debug.Log("On LinkCustomID Button Click---->>>");
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);

            var auth = new UserAccountManagementHandle(new LinkCustomID()
            {
                CustomID = "CustomID2457",
                ForceLink = true
            });
            auth.LinkCustomID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("LinkCustomID-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LinkCustomID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Unlinks the related custom identifier from the user's Avataryug account
        /// </summary>
        private void UnlinkCustomsID()
        {
            Debug.Log("On UnlinkCustomID Button Click---->>>");
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            var auth = new UserAccountManagementHandle(new UnlinkCustomID()
            {

            });
            auth.UnlinkCustomID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UnlinkCustomsID-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UnlinkCustomsID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Links the Android device identifier to the user's Avataryug account
        /// </summary>
        private void LinkAndroidDevice()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LinkAndroidDeviceID Button Click---->>>");
            var auth = new UserAccountManagementHandle(new LinkAndroidDeviceID()
            {
                AndroidDeviceID = "ANDROIDID01312000",
                ForceLink = true
            });
            auth.LinkAndroidDeviceID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("LinkAndroidDeviceID-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LinkAndroidDeviceID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Unlinks the related Android device identifier from the user's Avataryug account
        /// </summary>
        private void UnLinkAndroidDevice()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UnlinkAndroidDeviceID Button Click---->>>");
            var auth = new UserAccountManagementHandle(new UnlinkAndroidDeviceID()
            {

            });
            auth.UnlinkAndroidDeviceID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UnlinkAndroidDeviceID-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UnlinkAndroidDeviceID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Links the Apple account associated with the token to the user's Avataryug account.
        /// </summary>
        private void LinksApple()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LinkApple Button Click---->>>");
            var auth = new UserAccountManagementHandle(new LinkApple()
            {
                AppleID = "AppleId2545",
                ForceLink = true,
                IdentityToken = "IdentityToken244"
            });
            auth.LinkApple((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("LinksApple-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LinksApple-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Unlinks the related Apple account from the user's Avataryug account.
        /// </summary>
        private void UnLinksApple()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UnlinkApple Button Click---->>>");
            var auth = new UserAccountManagementHandle(new UnlinkApple() { });
            auth.UnlinkApple((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UnLinksApple-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UnLinksApple-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Links the vendor-specific iOS device identifier to the user's Avataryug account
        /// </summary>
        private void LinkIosDevice()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LinkIOSDeviceID Button Click---->>>");
            var auth = new UserAccountManagementHandle(new LinkIOSDeviceID()
            {
                DeviceID = "DeviceID56565",
                ForceLink = true
            });
            auth.LinkIOSDeviceID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("LinkIOSDeviceID-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LinkIOSDeviceID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Unlinks the related iOS device identifier from the user's Avataryug account
        /// </summary>
        private void UnlinkIosDevice()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UnlinkIOSDeviceID Button Click---->>>");
            var auth = new UserAccountManagementHandle(new UnlinkIOSDeviceID()
            { });
            auth.UnlinkIOSDeviceID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UnlinkIOSDeviceID-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UnlinkIOSDeviceID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Links the currently signed-in user account to their Google account, using their Google account credentials
        /// </summary>
        private void LinkGoogle()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LinkGoogleAccount Button Click---->>>");
            var auth = new UserAccountManagementHandle(new LinkGoogleAccount()
            {
                GoogleServerAuthCode = "dgtetet",
                GoogleID = "ewtwt3we5t",
                ForceLink = true
            });
            auth.LinkGoogleAccount((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("LinkGoogleAccount-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LinkGoogleAccount-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Unlinks the related Google account from the user's Avataryug account
        /// </summary>
        private void UnlinkGoogle()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UnlinkGoogleAccount Button Click---->>>");
            var auth = new UserAccountManagementHandle(new UnlinkGoogleAccount()
            {

            });
            auth.UnlinkGoogleAccount((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UnlinkGoogleAccount-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UnlinkGoogleAccount-->>" + error.ToJson());
                }
            });

        }

        /// <summary>
        /// Links the Facebook account associated with the provided Facebook access token to the user's Avataryug account
        /// </summary>
        private void LinkFB()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LinkFacebookAccount Button Click---->>>");
            var auth = new UserAccountManagementHandle(new LinkFacebookAccount()
            {
                FacebookID = "FBID38769865",
                AccessToken = "iofsaiof",
                ForceLink = true
            });
            auth.LinkFacebookAccount((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("LinkFacebookAccount-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LinkFacebookAccount-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Unlinks the related Facebook account from the user's Avataryug account
        /// </summary>
        private void UnlinkFB()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UnlinkFacebookAccount Button Click---->>>");
            var auth = new UserAccountManagementHandle(new UnlinkFacebookAccount() { });
            auth.UnlinkFacebookAccount((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UnlinkFacebookAccount-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UnlinkFacebookAccount-->>" + error.ToJson());
                }
            });

        }

        /// <summary>
        /// Adds the specified generic service identifier to the user's Avataryug account.
        /// This is designed to allow for a Avataryug ID lookup of any arbitrary service identifier a Project wants to add.
        /// This identifier should never be used as authentication credentials, as the intent is that it is easily accessible by other users.
        /// </summary>
        private void AddGenericService()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On AddGenericServiceID Button Click---->>>");
            var auth = new UserAccountManagementHandle(new AddGenericServiceID()
            {
                GenericServiceID = "GenericServiceID27489126"
            });
            auth.AddGenericServiceID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("AddGenericService-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("AddGenericService-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Removes the generic service identifier from the user's Avataryug account.
        /// </summary>
        private void RemoveGenericService()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On RemoveGenericServiceID Button Click---->>>");
            var auth = new UserAccountManagementHandle(new RemoveGenericServiceID()
            {

            });

            auth.RemoveGenericServiceID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("RemoveGenericServiceID-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("RemoveGenericServiceID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Updates the display name for the user in the project
        /// </summary>
        private void UpdateProjectDisplayName()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UpdateUserProjectDisplayName Button Click---->>>");
            var auth = new UserAccountManagementHandle(new UpdateUserProjectDisplayName()
            {

                DisplayName = "UNITYSDKTEST101"

            });
            auth.UpdateUserProjectDisplayName((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UpdateUserProjectDisplayName-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UpdateUserProjectDisplayName-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Retrieves information about the user's account.
        /// </summary>
        private void GetUserAccountsInfo()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetUserAccountInfo Button Click---->>>");
            var auth = new UserAccountManagementHandle(new GetUserAccountInfo()
            {
                userID = Configuration.userIds
            });
            auth.GetUserAccountInfo((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetUserAccountInfo-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetUserAccountInfo-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Updates user demographic information.
        /// </summary>
        private void UpdateUsersDemographic()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UpdateUserDemographics Button Click---->>>");
            var auth = new UserAccountManagementHandle(new UpdateUserDemographics()
            {
                AgeRange = "20-24",
                Gender = "3",
                Race = "Asian"
            });
            auth.UpdateUserDemographics((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UpdateUsersDemographic-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UpdateUsersDemographic-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Retrieves the user's public profile information.
        /// </summary>
        private void GetUsersProfile()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On GetUserProfile Button Click---->>>");
            var auth = new UserAccountManagementHandle(new GetUserProfile()
            {
                userID = Configuration.userIds
            });
            auth.GetUserProfile((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("GetUsersProfile-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("GetUsersProfile-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Delete User Account from Avataryug platform.
        /// </summary>
        private void DeleteUsers()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On DeleteUser Button Click---->>>");
            var auth = new UserAccountManagementHandle(new DeleteUser() { });

            auth.DeleteUser((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("DeleteUsers-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("DeleteUsers-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Sets the default avatar ID to users account
        /// </summary>
        private void UpdateDefaultAvatarsID()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On UpdateDefaultAvatarsID Button Click---->>>");
            var auth = new UserAccountManagementHandle(new UpdateDefaultAvatarID()
            {
                Avatarid = "KotlinAvatar028"
            });
            auth.UpdateDefaultAvatarID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("UpdateDefaultAvatarID-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("UpdateDefaultAvatarID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        ///Allows users to change their password.
        /// </summary>
        private void Changepassword()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On ChangePassword Button Click---->>>");
            var auth = new UserAccountManagementHandle(new ChangePassword()
            {
                OldPassword = "12",
                NewPassword = "123"

            });
            auth.ChangePassword((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("Changepassword-->>" + result.ToJson());
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("Changepassword-->>" + error.ToJson());
                }
            });
        }
    }
}