using System;
using Com.Avataryug.Api;
using Com.Avataryug.Model;
using Com.Avataryug.Client;
using UnityEngine;

namespace Com.Avataryug.Handler
{
    /// <summary>
    /// The "AuthenticateHandler" class facilitates authentication operations by utilizing the "Base" class for API calls.
    /// It offers multiple methods for various authentication scenarios,
    /// These methods accept callback parameters to handle response and error conditions.
    /// By leveraging the "baseApiCall" instance, the class ensures appropriate API calls are made and callbacks are invoked accordingly.
    /// </summary>
    public class AuthenticateHandler
    {
        private Base baseApiCall;
        public AuthenticateHandler() { }
        public AuthenticateHandler(Base _baseApiCall)
        {
            baseApiCall = _baseApiCall;
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier, which can be a combination of strings, integers, numbers, and symbols.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LoginWithCustomID(Action<LoginWithCustomIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LoginWithCustomIDResult)r); }, error);
        }

        /// <summary>
        /// Register user with email id,
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void RegisterUser(Action<RegisterUserResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((RegisterUserResponse)r); }, error);
        }

        /// <summary>
        /// Signs the user into the Avataryug account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LoginWithEmailAddress(Action<LoginWithEmailAddressResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LoginWithEmailAddressResult)r); }, error);
        }

        /// <summary>
        /// Signs the user in using the Android device identifier.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LoginWithAndroidDeviceID(Action<LoginWithAndroidDeviceIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LoginWithAndroidDeviceIDResult)r); }, error);
        }

        /// <summary>
        /// Signs in the user using an identity token obtained from Sign in with Apple.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LoginWithApple(Action<LoginWithAppleResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LoginWithAppleResult)r); }, error);
        }

        /// <summary>
        /// Signs the user in using a Facebook access token.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LoginWithFacebook(Action<LoginWithFacebookResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LoginWithFacebookResult)r); }, error);
        }

        /// <summary>
        /// Signs the user in using their Google account credentials.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LoginWithGoogle(Action<LoginWithGoogleResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LoginWithGoogleResult)r); }, error);
        }

        /// <summary>
        /// Signs the user in using the vendor-specific iOS device identifier.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LoginWithIOSDeviceID(Action<LoginWithIOSDeviceIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LoginWithIOSDeviceIDResult)r); }, error);
        }
    }

    /// <summary>
    /// Signs the user in using a custom unique identifier, which can be a combination of strings, integers, numbers, and symbols,
    /// creating a session identifier for subsequent API calls that require an authenticated user.
    /// </summary>
    public class LoginWithCustomID : Base
    {
        public string CustomID;
        public bool CreateAccount;

        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AuthenticationApi();

                authApi.LoginWithCustomID(new LoginWithCustomIDRequest()
                {
                    CreateAccount = CreateAccount,
                    CustomID = CustomID
                },
                (res) =>
                {
                    Configuration.AccessToken = res.Data.AccessToken;
                    result?.Invoke(res);
                }, error);
            }
        }
    }

    /// <summary>
    /// Register user with email id,
    /// creating a session identifier for subsequent API calls that require an authenticated user.
    /// </summary>
    public class RegisterUser : Base
    {
        public string AddDisplayName;
        public string EmailID;
        public string Password;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new AuthenticationApi();
                auth.RegisterUser(new RegisterUserRequest()
                {
                    Password = Password,
                    DisplayName = AddDisplayName,
                    EmailID = EmailID
                }, (res) =>
                {
                    Configuration.AccessToken = res.Data.AccessToken;
                    result?.Invoke(res);
                }, error);
            }
        }
    }

    /// <summary>
    /// Signs the user into the Avataryug account, returning a session identifier that can subsequently be used for API calls which require an authenticated user.
    /// Unlike most other login API calls, LoginWithEmailAddress does not permit the creation of new accounts via the CreateAccountFlag.
    /// </summary>
    public class LoginWithEmailAddress : Base
    {
        public string EmailID;
        public string Password;

        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AuthenticationApi();
                authApi.LoginWithEmailAddress(new LoginWithEmailAddressRequest()
                {
                    EmailID = EmailID,
                    Password = Password
                }, (res) =>
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.Log("Login2" + res);
                    }
                    Configuration.AccessToken = res.Data.AccessToken;
                    result?.Invoke(res);
                }, error);
            }
        }
    }

    /// <summary>
    /// Signs the user in using the Android device identifier,
    /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
    /// </summary>
    public class LoginWithAndroidDeviceID : Base
    {
        public string AndroidDeviceID;
        public bool CreateAccount;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AuthenticationApi();
                authApi.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
                {
                    AndroidDeviceID = AndroidDeviceID,
                    CreateAccount = CreateAccount
                }, (res) =>
                {
                    Configuration.AccessToken = res.Data.AccessToken;
                    result?.Invoke(res);
                }, error);
            }
        }
    }

    /// <summary>
    /// Signs in the user using an identity token obtained from Sign in with Apple,
    /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
    /// </summary>
    public class LoginWithApple : Base
    {
        public string AppleID;
        public string AppleIdentityToken;
        public bool CreateAccount;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AuthenticationApi();
                authApi.LoginWithApple(new LoginWithAppleRequest()
                {
                    AppleID = AppleID,
                    AppleIdentityToken = AppleIdentityToken,
                    CreateAccount = CreateAccount
                },
                (res) =>
                {
                    Configuration.AccessToken = res.Data.AccessToken;
                    result?.Invoke(res);
                }, error);
            }
        }
    }

    /// <summary>
    /// Signs the user in using a Facebook access token,
    /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
    /// </summary>
    public class LoginWithFacebook : Base
    {
        public bool CreateAccount;
        public string FbAccessToken;
        public string FacebookID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AuthenticationApi();
                authApi.LoginWithFacebook(new LoginWithFacebookRequest()
                {
                    CreateAccount = CreateAccount,
                    FbAccessToken = FbAccessToken,
                    FacebookID = FacebookID
                }, (res) => { Configuration.AccessToken = res.Data.AccessToken; result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Signs the user in using their Google account credentials,
    /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
    /// </summary>
    public class LoginWithGoogle : Base
    {
        public bool CreateAccount;
        public string GoogleServerAuthCode;
        public string GoogleID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AuthenticationApi();
                authApi.LoginWithGoogle(new LoginWithGoogleRequest()
                {
                    CreateAccount = CreateAccount,
                    GoogleServerAuthCode = GoogleServerAuthCode,
                    GoogleID = GoogleID
                }, (res) =>
                {
                    Configuration.AccessToken = res.Data.AccessToken; result?.Invoke(res);
                }, error);
            }
        }
    }

    /// <summary>
    /// Signs the user in using the vendor-specific iOS device identifier,
    /// returning a session identifier that can subsequently be used for API calls which require an authenticated user
    /// </summary>
    public class LoginWithIOSDeviceID : Base
    {
        public bool CreateAccount;
        public string IOSDeviceID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AuthenticationApi();
                authApi.LoginWithIOSDeviceID(new LoginWithIOSDeviceIDRequest()
                {
                    CreateAccount = CreateAccount,
                    IOSDeviceID = IOSDeviceID
                },
                (res) =>
                {
                    Configuration.AccessToken = res.Data.AccessToken; result?.Invoke(res);
                }, error);
            }
        }
    }
}
