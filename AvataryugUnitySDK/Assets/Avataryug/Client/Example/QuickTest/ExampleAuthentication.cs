using System;
using Com.Avataryug.Client;
using Com.Avataryug.Handler;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Avataryug
{
    /// <summary>
    /// This ExampleAuthentication Class demonstrates API calling methods with temporary data.
    /// </summary>
    public class ExampleAuthentication : MonoBehaviour
    {
        public Button customButton;
        public Button androidDeviceIDButton;
        public Button createNewAccountButton;
        public Button loginWithEmailButton;
        public Button loginWithAppleButton;
        public Button loginIOSDeviceIDButton;
        public Button loginWithGoogleButton;
        public Button loginFacebookButton;
        public GameObject LoadingPanel;
        private void OnEnable()
        {
            if (customButton != null)
            {
                customButton.onClick.RemoveAllListeners();
                customButton.onClick.AddListener(LoginwithCustomID);
            }
            if (androidDeviceIDButton != null)
            {

                androidDeviceIDButton.onClick.RemoveAllListeners();
                androidDeviceIDButton.onClick.AddListener(LoginwithAndroidDeviceID);
            }

            if (createNewAccountButton != null)
            {
                createNewAccountButton.onClick.RemoveAllListeners();
                createNewAccountButton.onClick.AddListener(LoginwithCreateAccounts);
            }

            if (loginWithEmailButton != null)
            {
                loginWithEmailButton.onClick.RemoveAllListeners();
                loginWithEmailButton.onClick.AddListener(LoginwithEmail);
            }

            if (loginWithAppleButton != null)
            {
                loginWithAppleButton.onClick.RemoveAllListeners();
                loginWithAppleButton.onClick.AddListener(LoginsWithApple);
            }

            if (loginIOSDeviceIDButton != null)
            {
                loginIOSDeviceIDButton.onClick.RemoveAllListeners();
                loginIOSDeviceIDButton.onClick.AddListener(LoginwithIOSDeviceID);
            }

            if (loginWithGoogleButton != null)
            {
                loginWithGoogleButton.onClick.RemoveAllListeners();
                loginWithGoogleButton.onClick.AddListener(LoginwithGoogle);
            }

            if (loginFacebookButton != null)
            {
                loginFacebookButton.onClick.RemoveAllListeners();
                loginFacebookButton.onClick.AddListener(LoginwithFacebook);
            }
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier, which can be a combination of strings, integers, numbers, and symbols,
        /// creating a session identifier for subsequent API calls that require an authenticated user.
        /// </summary>
        private void LoginwithCustomID()
        {
            Debug.Log("On LoginWithCustomID Button Click---->>>");
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            var auth = new AuthenticateHandler(new LoginWithCustomID()
            {
                CreateAccount = true,
                CustomID = "MyCustomID"
            });
            auth.LoginWithCustomID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.Log("LoginwithCustomID-->>" + result.ToJson());
                    Configuration.userIds = result.Data.User.UserID;
                }
            },
            (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LoginwithCustomID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Signs the user in using the Android device identifier,
        /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        private void LoginwithAndroidDeviceID()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LoginWithAndroidDeviceID Button Click---->>>");
            var auth = new AuthenticateHandler(new LoginWithAndroidDeviceID()
            {
                AndroidDeviceID = SystemInfo.deviceUniqueIdentifier.ToString().ToLower(),
                CreateAccount = true
            });
            auth.LoginWithAndroidDeviceID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Configuration.userIds = result.Data.User.UserID;
                    Debug.Log("LoginWithAndroidDeviceID-->>" + result.ToJson());
                }

            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LoginWithAndroidDeviceID---->>" + error.ToJson());
                }
            });
        }

        public string GenerateRandomEmail()
        {
            return string.Format("{0}@{1}.com", GenerateRandomAlphabetString(10), GenerateRandomAlphabetString(10));
        }

        /// <summary>
        /// Gets a string from the English alphabet at random
        /// </summary>
        public string GenerateRandomAlphabetString(int length)
        {
            string allowedChars = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var rnd = SeedRandom();

            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rnd.Next(allowedChars.Length)];
            }

            return new string(chars);
        }

        private System.Random SeedRandom()
        {
            return new System.Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// Register user with email id,
        /// creating a session identifier for subsequent API calls that require an authenticated user.
        /// </summary>
        private void LoginwithCreateAccounts()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            string email = GenerateRandomEmail();
            Debug.Log("On RegisterUser Button Click---->>>");
            var auth = new AuthenticateHandler(new RegisterUser()
            {
                AddDisplayName = "NewAccountCreated",
                EmailID = email,
                Password = "12",

            });
            auth.RegisterUser((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Configuration.userIds = result.Data.User.UserID;
                    Debug.Log("RegisterUser-->>" + result.ToJson());
                }
            }, (error) =>
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                    Debug.LogError("RegisterUser-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Signs the user into the Avataryug account, returning a session identifier that can subsequently be used for API calls which require an authenticated user.
        /// Unlike most other login API calls, LoginWithEmailAddress does not permit the creation of new accounts via the CreateAccountFlag.
        /// </summary>
        private void LoginwithEmail()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LoginWithEmailAddress Button Click---->>>");
            var auth = new AuthenticateHandler(new LoginWithEmailAddress()
            {
                EmailID = "gofoto9456@extemer.com",
                Password = "12"
            });

            auth.LoginWithEmailAddress((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Configuration.userIds = result.Data.User.UserID;
                    Debug.Log("LoginWithEmailAddress-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LoginWithEmailAddress-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Signs in the user using an identity token obtained from Sign in with Apple,
        /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        private void LoginsWithApple()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LoginWithApple Button Click---->>>");
            var auth = new AuthenticateHandler(new LoginWithApple()
            {
                CreateAccount = true,
                AppleID = "PineApple1923",
                AppleIdentityToken = "Token10190"
            });

            auth.LoginWithApple((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Configuration.userIds = result.Data.User.UserID;
                    Debug.Log("LoginWithApple-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LoginWithApple-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Signs the user in using the vendor-specific iOS device identifier,
        /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        private void LoginwithIOSDeviceID()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LoginWithIOSDeviceID Button Click---->>>");
            var auth = new AuthenticateHandler(new LoginWithIOSDeviceID()
            {
                CreateAccount = true,
                IOSDeviceID = "IOSPIOS0101",

            });

            auth.LoginWithIOSDeviceID((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Configuration.userIds = result.Data.User.UserID;
                    Debug.Log("LoginWithIOSDeviceID-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LoginWithIOSDeviceID-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Signs the user in using their Google account credentials,
        /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        private void LoginwithGoogle()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LoginWithGoogle Button Click---->>>");
            var auth = new AuthenticateHandler(new LoginWithGoogle()
            {
                CreateAccount = true,
                GoogleID = "IDGOOGLEDOGGLE0101",
                GoogleServerAuthCode = "AUTH10101"

            });

            auth.LoginWithGoogle((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Configuration.userIds = result.Data.User.UserID;
                    Debug.Log("LoginWithGoogle-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LoginWithGoogle-->>" + error.ToJson());
                }
            });
        }

        /// <summary>
        /// Signs the user in using a Facebook access token,
        /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        private void LoginwithFacebook()
        {
            QuickTestApiEvents.OnApiRequest?.Invoke(null, true);
            Debug.Log("On LoginWithFacebook Button Click---->>>");
            var auth = new AuthenticateHandler(new LoginWithFacebook()
            {
                CreateAccount = true,
                FacebookID = "FBID102102",
                FbAccessToken = "FBTOKEN294701"

            });

            auth.LoginWithFacebook((result) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Configuration.userIds = result.Data.User.UserID;
                    Debug.Log("LoginWithFacebook-->>" + result.ToJson());
                }
            }, (error) =>
            {
                QuickTestApiEvents.OnApiResponce?.Invoke(null, null);
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("LoginWithFacebook-->>" + error.ToJson());
                }
            });
        }

    }
}