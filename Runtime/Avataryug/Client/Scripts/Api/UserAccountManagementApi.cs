using System;
using System.Collections.Generic;
using RestSharp;
using Com.Avataryug.Client;
using Com.Avataryug.Model;
using UnityEngine;

namespace Com.Avataryug.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IUserAccountManagementApi
    {
        /// <summary>
        /// Change Password 
        /// </summary>
        /// <param name="changePasswordRequest"></param>
        /// <returns>ChangePasswordResponse</returns>
        void ChangePassword(ChangePasswordRequest changePasswordRequest, Action<ChangePasswordResponse> result, Action<ApiException> error);

        /// <summary>
        /// Delete User  Delete the user User 
        /// </summary>
        /// <returns>DeleteUserResponse</returns>
        void DeleteUser(DeleteUserRequest deleteUserRequest, Action<DeleteUserResponse> result, Action<ApiException> error);

        /// <summary>
        /// Update User Demographics 
        /// </summary>
        /// <param name="updateUserDemographicsRequest"></param>
        /// <returns>UpdateUserDemographicsResponse</returns>
        void UpdateUserDemographics(UpdateUserDemographicsRequest updateUserDemographicsRequest, Action<UpdateUserDemographicsResponse> result, Action<ApiException> error);

        /// <summary>
        /// Verify User With Email 
        /// </summary>
        /// <param name="verifyUserWithEmailRequest"></param>
        /// <returns>VerifyUserWithEmailResponse</returns>
        void VerifyUserWithEmail(VerifyUserWithEmailRequest verifyUserWithEmailRequest, Action<VerifyUserWithEmailResponse> result, Action<ApiException> error);

        /// <summary>
        /// Update Email Password 
        /// </summary>
        /// <param name="updateEmailPasswordRequest"></param>
        /// <returns>UpdateEmailPasswordResponse</returns>
        void UpdateEmailPassword(UpdateEmailPasswordRequest updateEmailPasswordRequest, Action<UpdateEmailPasswordResponse> result, Action<ApiException> error);

        /// <summary>
        /// Send Account Verification Email 
        /// </summary>
        /// <param name="sendAccountVerificationEmailRequest"></param>
        /// <returns>SendAccountVerificationEmailResponse</returns>
        void SendAccountVerificationEmail(SendAccountVerificationEmailRequest sendAccountVerificationEmailRequest, Action<SendAccountVerificationEmailResponse> result, Action<ApiException> error);

        /// <summary>
        /// Update Default AvatarID
        /// </summary>
        /// <exception cref="Com.Avataryug.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updateDefaultAvatarIDRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>UpdateDefaultAvatarIDResult</returns>
        void UpdateDefaultAvatarID(UpdateDefaultAvatarIDRequest updateDefaultAvatarIDRequest, Action<UpdateDefaultAvatarIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Add Email Password Adds Avataryug username/password auth to an existing account created via an anonymous auth method, e.g. automatic device ID login.
        /// </summary>
        /// <param name="addEmailPasswordRequest">Request payload</param>
        /// <returns>AddEmailPasswordResult</returns>
        void AddEmailPassword(AddEmailPasswordRequest addEmailPasswordRequest, Action<AddEmailPasswordResult> result, Action<ApiException> error);

        /// <summary>
        /// Add Generic Service ID Adds the specified generic service identifier to the user&#39;s Avataryug account. This is designed to allow for a Avataryug ID lookup of any arbitrary service identifier a Project wants to add. This identifier should never be used as authentication credentials, as the intent is that it is easily accessible by other users.
        /// </summary>
        /// <param name="addGenericServiceIDRequest"></param>
        /// <returns>AddGenericServiceIDResult</returns>
        void AddGenericServiceID(AddGenericServiceIDRequest addGenericServiceIDRequest, Action<AddGenericServiceIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Get User Account Info Get all users data
        /// </summary>
        /// <param name="userID">Unique Avataryug assigned ID of the user on whom the operation will be performed</param>
        /// <returns>GetUserAccountInfoResult</returns>
        void GetUserAccountInfo(string userID, Action<GetUserAccountInfoResult> result, Action<ApiException> error);

        /// <summary>
        /// Get User Profile Get Public data for the User
        /// </summary>
        /// <param name="userID">Unique Avataryug assigned ID of the user on whom the operation will be performed</param>
        /// <param name="showDisplayName">Whether to show display name of the user</param>
        /// <param name="showThumbUrl">Whether to show user&#39;s avatar thumbnail URL</param>
        /// <param name="showAvatarUrl">Whether to show user&#39;s avatar URL</param>
        /// <returns>GetUserProfileResult</returns>
        void GetUserProfile(string userID, Action<GetUserProfileResult> result, Action<ApiException> error);

        /// <summary>
        /// Link Android Device ID Links the Android device identifier to the user&#39;s Avataryug account
        /// </summary>
        /// <param name="linkAndroidDeviceIDRequest"></param>
        /// <returns>LinkAndroidDeviceIDResult</returns>
        void LinkAndroidDeviceID(LinkAndroidDeviceIDRequest linkAndroidDeviceIDRequest, Action<LinkAndroidDeviceIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Link Apple Links the Apple account associated with the token to the user&#39;s Avataryug account.
        /// </summary>
        /// <param name="linkAppleRequest"></param>
        /// <returns>LinkAppleResult</returns>
        void LinkApple(LinkAppleRequest linkAppleRequest, Action<LinkAppleResult> result, Action<ApiException> error);

        /// <summary>
        /// Link Custom ID Links the custom identifier, generated by the Project, to the user&#39;s Avataryug account
        /// </summary>
        /// <param name="linkCustomIDRequest"></param>
        /// <returns>LinkCustomIDResult</returns>
        void LinkCustomID(LinkCustomIDRequest linkCustomIDRequest, Action<LinkCustomIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Link Facebook Account Links the Facebook account associated with the provided Facebook access token to the user&#39;s Avataryug account
        /// </summary>
        /// <param name="linkFacebookAccountRequest"></param>
        /// <returns>LinkFacebookAccountResult</returns>
        void LinkFacebookAccount(LinkFacebookAccountRequest linkFacebookAccountRequest, Action<LinkFacebookAccountResult> result, Action<ApiException> error);

        /// <summary>
        /// Link Google Account Links the currently signed-in user account to their Google account, using their Google account credentials
        /// </summary>
        /// <param name="linkGoogleAccountRequest"></param>
        /// <returns>LinkGoogleAccountResult</returns>
        void LinkGoogleAccount(LinkGoogleAccountRequest linkGoogleAccountRequest, Action<LinkGoogleAccountResult> result, Action<ApiException> error);

        /// <summary>
        /// Link IOS Device ID Links the vendor-specific iOS device identifier to the user&#39;s Avataryug account
        /// </summary>
        /// <param name="linkIOSDeviceIDRequest"></param>
        /// <returns>LinkIOSDeviceIDResult</returns>
        void LinkIOSDeviceID(LinkIOSDeviceIDRequest linkIOSDeviceIDRequest, Action<LinkIOSDeviceIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Remove Generic Service ID Removes the specified generic service identifier from the user&#39;s Avataryug account.
        /// </summary>
        /// <returns>RemoveGenericServiceIDResult</returns>
        void RemoveGenericServiceID(Action<RemoveGenericServiceIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Unlink Android Device ID Unlinks the related Android device identifier from the user&#39;s Avataryug account
        /// </summary>
        /// <returns>UnlinkAndroidDeviceIDResult</returns>
        void UnlinkAndroidDeviceID(Action<UnlinkAndroidDeviceIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Unlink Apple Unlinks the related Apple account from the user&#39;s Avataryug account.
        /// </summary>
        /// <returns>UnlinkAppleResult</returns>
        void UnlinkApple(Action<UnlinkAppleResult> result, Action<ApiException> error);

        /// <summary>
        /// Unlink Custom ID Unlinks the related custom identifier from the user&#39;s Avataryug account
        /// </summary>
        /// <returns>UnlinkCustomIDResult</returns>
        void UnlinkCustomID(Action<UnlinkCustomIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Unlink Facebook Account Unlinks the related Facebook account from the user&#39;s Avataryug account
        /// </summary>
        /// <returns>UnlinkFacebookAccountResult</returns>
        void UnlinkFacebookAccount(Action<UnlinkFacebookAccountResult> result, Action<ApiException> error);

        /// <summary>
        /// Unlink Google Account Unlinks the related Google account from the user&#39;s Avataryug account 
        /// </summary>
        /// <returns>UnlinkGoogleAccountResult</returns>
        void UnlinkGoogleAccount(Action<UnlinkGoogleAccountResult> result, Action<ApiException> error);

        /// <summary>
        /// Unlink IOS Device ID Unlinks the related iOS device identifier from the user&#39;s Avataryug account
        /// </summary>
        /// <returns>UnlinkIOSDeviceIDResult</returns>
        void UnlinkIOSDeviceID(Action<UnlinkIOSDeviceIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Update User Display Name Updates the display name for the user in the project
        /// </summary>
        /// <param name="updateUserProjectDisplayNameRequest"></param>
        /// <returns>UpdateUserProjectDisplayNameResult</returns>
        void UpdateUserProjectDisplayName(UpdateUserProjectDisplayNameRequest updateUserProjectDisplayNameRequest, Action<UpdateUserProjectDisplayNameResult> result, Action<ApiException> error);

        /// <summary>
        /// Send Account Recovery Email 
        /// </summary>
        /// <param name="sendAccountRecoveryEmailRequset"></param>
        /// <returns>SendAccountRecoveryEmailResponse</returns>
        void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequset sendAccountRecoveryEmailRequset, Action<SendAccountRecoveryEmailResponse> result, Action<ApiException> error);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UserAccountManagementApi : IUserAccountManagementApi
    {
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountManagementApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public UserAccountManagementApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountManagementApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserAccountManagementApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Change Password 
        /// </summary>
        /// <param name="changePasswordRequest"></param>
        /// <returns>ChangePasswordResponse</returns>
        public async void ChangePassword(ChangePasswordRequest changePasswordRequest, Action<ChangePasswordResponse> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/ChangePassword";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(changePasswordRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling ChangePassword: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling ChangePassword: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((ChangePasswordResponse)ApiClient.Deserialize(response.Content, typeof(ChangePasswordResponse), response.Headers));
        }

        /// <summary>
        /// Delete User  Delete the user User 
        /// </summary>
        /// <returns>DeleteUserResponse</returns>
        public async void DeleteUser(DeleteUserRequest deleteUserRequest, Action<DeleteUserResponse> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                Debug.LogError("ProjectId is not present");
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/DeleteUser";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(deleteUserRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling DeleteUser: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling DeleteUser: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((DeleteUserResponse)ApiClient.Deserialize(response.Content, typeof(DeleteUserResponse), response.Headers));
        }

        /// <summary>
        /// Update User Demographics 
        /// </summary>
        /// <param name="updateUserDemographicsRequest"></param>
        /// <returns>UpdateUserDemographicsResponse</returns>
        public async void UpdateUserDemographics(UpdateUserDemographicsRequest updateUserDemographicsRequest, Action<UpdateUserDemographicsResponse> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }
            var path = "/UpdateUserDemographics";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateUserDemographicsRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateUserDemographics: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateUserDemographics: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((UpdateUserDemographicsResponse)ApiClient.Deserialize(response.Content, typeof(UpdateUserDemographicsResponse), response.Headers));
        }

        /// <summary>
        /// Verify User Email ID
        /// </summary>
        /// <param name="verifyUserWithEmailRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void VerifyUserWithEmail(VerifyUserWithEmailRequest verifyUserWithEmailRequest, Action<VerifyUserWithEmailResponse> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/VerifyUserWithEmail";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(verifyUserWithEmailRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling VerifyUserWithEmail: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling VerifyUserWithEmail: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((VerifyUserWithEmailResponse)ApiClient.Deserialize(response.Content, typeof(VerifyUserWithEmailResponse), response.Headers));
        }

        /// <summary>
        /// Update User Email Password 
        /// </summary>
        /// <param name="updateEmailPasswordRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void UpdateEmailPassword(UpdateEmailPasswordRequest updateEmailPasswordRequest, Action<UpdateEmailPasswordResponse> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UpdateEmailPassword";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateEmailPasswordRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateEmailPassword: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateEmailPassword: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((UpdateEmailPasswordResponse)ApiClient.Deserialize(response.Content, typeof(UpdateEmailPasswordResponse), response.Headers));
        }

        /// <summary>
        /// Send Account Verification email otp to provided email id
        /// </summary>
        /// <param name="sendAccountVerificationEmailRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void SendAccountVerificationEmail(SendAccountVerificationEmailRequest sendAccountVerificationEmailRequest, Action<SendAccountVerificationEmailResponse> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/SendAccountVerificationEmail";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(sendAccountVerificationEmailRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SendAccountVerificationEmail: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SendAccountVerificationEmail: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((SendAccountVerificationEmailResponse)ApiClient.Deserialize(response.Content, typeof(SendAccountVerificationEmailResponse), response.Headers));
        }

        /// <summary>
        /// Send Account Recovery Email 
        /// </summary>
        /// <param name="sendAccountRecoveryEmailRequset"></param>
        /// <returns>SendAccountRecoveryEmailResponse</returns>
        public async void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequset sendAccountRecoveryEmailRequset, Action<SendAccountRecoveryEmailResponse> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/SendAccountRecoveryEmail";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(sendAccountRecoveryEmailRequset); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SendAccountRecoveryEmail: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SendAccountRecoveryEmail: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }
            result?.Invoke((SendAccountRecoveryEmailResponse)ApiClient.Deserialize(response.Content, typeof(SendAccountRecoveryEmailResponse), response.Headers));
        }

        /// <summary>
        /// Add Email Password Adds Avataryug username/password auth to an existing account created via an anonymous auth method, e.g. automatic device ID login.
        /// </summary>
        /// <param name="addEmailPasswordRequest">Request payload</param>
        /// <returns>AddEmailPasswordResult</returns>
        public async void AddEmailPassword(AddEmailPasswordRequest addEmailPasswordRequest, Action<AddEmailPasswordResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/AddEmailPassword";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addEmailPasswordRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling AddEmailPassword: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling AddEmailPassword: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((AddEmailPasswordResult)ApiClient.Deserialize(response.Content, typeof(AddEmailPasswordResult), response.Headers));
        }

        /// <summary>
        /// Add Generic Service ID Adds the specified generic service identifier to the user&#39;s Avataryug account. This is designed to allow for a Avataryug ID lookup of any arbitrary service identifier a Project wants to add. This identifier should never be used as authentication credentials, as the intent is that it is easily accessible by other users.
        /// </summary>
        /// <param name="addGenericServiceIDRequest"></param>
        /// <returns>AddGenericServiceIDResult</returns>
        public async void AddGenericServiceID(AddGenericServiceIDRequest addGenericServiceIDRequest, Action<AddGenericServiceIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/AddGenericServiceID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addGenericServiceIDRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling AddGenericServiceID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling AddGenericServiceID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((AddGenericServiceIDResult)ApiClient.Deserialize(response.Content, typeof(AddGenericServiceIDResult), response.Headers));
        }

        /// <summary>
        /// Get User Account Info Get all users data
        /// </summary>
        /// <param name="userID">Unique Avataryug assigned ID of the user on whom the operation will be performed</param>
        /// <returns>GetUserAccountInfoResult</returns>
        public async void GetUserAccountInfo(string userID, Action<GetUserAccountInfoResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            // verify the required parameter 'userID' is set
            if (userID == null) throw new ApiException(400, "Missing required parameter 'userID' when calling GetUserAccountInfo");


            var path = "/GetUserAccountInfo";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (userID != null) queryParams.Add("UserID", ApiClient.ParameterToString(userID)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetUserAccountInfo: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetUserAccountInfo: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((GetUserAccountInfoResult)ApiClient.Deserialize(response.Content, typeof(GetUserAccountInfoResult), response.Headers));
        }

        /// <summary>
        /// Get User Profile Get Public data for the User
        /// </summary>
        /// <param name="userID">Unique Avataryug assigned ID of the user on whom the operation will be performed</param>
        /// <param name="showDisplayName">Whether to show display name of the user</param>
        /// <param name="showThumbUrl">Whether to show user&#39;s avatar thumbnail URL</param>
        /// <param name="showAvatarUrl">Whether to show user&#39;s avatar URL</param>
        /// <returns>GetUserProfileResult</returns>
        public async void GetUserProfile(string userID, Action<GetUserProfileResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            // verify the required parameter 'userID' is set
            if (userID == null) throw new ApiException(400, "Missing required parameter 'userID' when calling GetUserProfile");

            var path = "/GetUserProfile";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (userID != null) queryParams.Add("UserID", ApiClient.ParameterToString(userID)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };


            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetUserProfile: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetUserProfile: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((GetUserProfileResult)ApiClient.Deserialize(response.Content, typeof(GetUserProfileResult), response.Headers));
        }

        /// <summary>
        /// Link Android Device ID Links the Android device identifier to the user&#39;s Avataryug account
        /// </summary>
        /// <param name="linkAndroidDeviceIDRequest"></param>
        /// <returns>LinkAndroidDeviceIDResult</returns>
        public async void LinkAndroidDeviceID(LinkAndroidDeviceIDRequest linkAndroidDeviceIDRequest, Action<LinkAndroidDeviceIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/LinkAndroidDeviceID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(linkAndroidDeviceIDRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkAndroidDeviceID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkAndroidDeviceID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((LinkAndroidDeviceIDResult)ApiClient.Deserialize(response.Content, typeof(LinkAndroidDeviceIDResult), response.Headers));
        }

        /// <summary>
        /// Link Apple Links the Apple account associated with the token to the user&#39;s Avataryug account.
        /// </summary>
        /// <param name="linkAppleRequest"></param>
        /// <returns>LinkAppleResult</returns>
        public async void LinkApple(LinkAppleRequest linkAppleRequest, Action<LinkAppleResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/LinkApple";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(linkAppleRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkApple: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkApple: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((LinkAppleResult)ApiClient.Deserialize(response.Content, typeof(LinkAppleResult), response.Headers));
        }

        /// <summary>
        /// Link Custom ID Links the custom identifier, generated by the Project, to the user&#39;s Avataryug account
        /// </summary>
        /// <param name="linkCustomIDRequest"></param>
        /// <returns>LinkCustomIDResult</returns>
        public async void LinkCustomID(LinkCustomIDRequest linkCustomIDRequest, Action<LinkCustomIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/LinkCustomID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(linkCustomIDRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkCustomID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkCustomID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((LinkCustomIDResult)ApiClient.Deserialize(response.Content, typeof(LinkCustomIDResult), response.Headers));
        }

        /// <summary>
        /// Link Facebook Account Links the Facebook account associated with the provided Facebook access token to the user&#39;s Avataryug account
        /// </summary>
        /// <param name="linkFacebookAccountRequest"></param>
        /// <returns>LinkFacebookAccountResult</returns>
        public async void LinkFacebookAccount(LinkFacebookAccountRequest linkFacebookAccountRequest, Action<LinkFacebookAccountResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/LinkFacebookAccount";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(linkFacebookAccountRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkFacebookAccount: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkFacebookAccount: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((LinkFacebookAccountResult)ApiClient.Deserialize(response.Content, typeof(LinkFacebookAccountResult), response.Headers));
        }

        /// <summary>
        /// Link Google Account Links the currently signed-in user account to their Google account, using their Google account credentials
        /// </summary>
        /// <param name="linkGoogleAccountRequest"></param>
        /// <returns>LinkGoogleAccountResult</returns>
        public async void LinkGoogleAccount(LinkGoogleAccountRequest linkGoogleAccountRequest, Action<LinkGoogleAccountResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/LinkGoogleAccount";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(linkGoogleAccountRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkGoogleAccount: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkGoogleAccount: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((LinkGoogleAccountResult)ApiClient.Deserialize(response.Content, typeof(LinkGoogleAccountResult), response.Headers));
        }

        /// <summary>
        /// Link IOS Device ID Links the vendor-specific iOS device identifier to the user&#39;s Avataryug account
        /// </summary>
        /// <param name="linkIOSDeviceIDRequest"></param>
        /// <returns>LinkIOSDeviceIDResult</returns>
        public async void LinkIOSDeviceID(LinkIOSDeviceIDRequest linkIOSDeviceIDRequest, Action<LinkIOSDeviceIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }
            var path = "/LinkIOSDeviceID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(linkIOSDeviceIDRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkIOSDeviceID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling LinkIOSDeviceID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((LinkIOSDeviceIDResult)ApiClient.Deserialize(response.Content, typeof(LinkIOSDeviceIDResult), response.Headers));
        }

        /// <summary>
        /// Remove Generic Service ID Removes the specified generic service identifier from the user&#39;s Avataryug account.
        /// </summary>
        /// <returns>RemoveGenericServiceIDResult</returns>
        public async void RemoveGenericServiceID(Action<RemoveGenericServiceIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/RemoveGenericServiceID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling RemoveGenericServiceID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling RemoveGenericServiceID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((RemoveGenericServiceIDResult)ApiClient.Deserialize(response.Content, typeof(RemoveGenericServiceIDResult), response.Headers));
        }

        /// <summary>
        /// Unlink Android Device ID Unlinks the related Android device identifier from the user&#39;s Avataryug account
        /// </summary>
        /// <returns>UnlinkAndroidDeviceIDResult</returns>
        public async void UnlinkAndroidDeviceID(Action<UnlinkAndroidDeviceIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UnlinkAndroidDeviceID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkAndroidDeviceID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkAndroidDeviceID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((UnlinkAndroidDeviceIDResult)ApiClient.Deserialize(response.Content, typeof(UnlinkAndroidDeviceIDResult), response.Headers));
        }

        /// <summary>
        /// Unlink Apple Unlinks the related Apple account from the user&#39;s Avataryug account.
        /// </summary>
        /// <returns>UnlinkAppleResult</returns>
        public async void UnlinkApple(Action<UnlinkAppleResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UnlinkApple";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkApple: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkApple: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((UnlinkAppleResult)ApiClient.Deserialize(response.Content, typeof(UnlinkAppleResult), response.Headers));
        }

        /// <summary>
        /// Unlink Custom ID Unlinks the related custom identifier from the user&#39;s Avataryug account
        /// </summary>
        /// <returns>UnlinkCustomIDResult</returns>
        public async void UnlinkCustomID(Action<UnlinkCustomIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UnlinkCustomID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkCustomID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkCustomID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((UnlinkCustomIDResult)ApiClient.Deserialize(response.Content, typeof(UnlinkCustomIDResult), response.Headers));
        }

        /// <summary>
        /// Unlink Facebook Account Unlinks the related Facebook account from the user&#39;s Avataryug account
        /// </summary>
        /// <returns>UnlinkFacebookAccountResult</returns>
        public async void UnlinkFacebookAccount(Action<UnlinkFacebookAccountResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UnlinkFacebookAccount";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkFacebookAccount: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkFacebookAccount: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((UnlinkFacebookAccountResult)ApiClient.Deserialize(response.Content, typeof(UnlinkFacebookAccountResult), response.Headers));
        }

        /// <summary>
        /// Unlink Google Account Unlinks the related Google account from the user&#39;s Avataryug account 
        /// </summary>
        /// <returns>UnlinkGoogleAccountResult</returns>
        public async void UnlinkGoogleAccount(Action<UnlinkGoogleAccountResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UnlinkGoogleAccount";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkGoogleAccount: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkGoogleAccount: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((UnlinkGoogleAccountResult)ApiClient.Deserialize(response.Content, typeof(UnlinkGoogleAccountResult), response.Headers));
        }

        /// <summary>
        /// Unlink IOS Device ID Unlinks the related iOS device identifier from the user&#39;s Avataryug account
        /// </summary>
        /// <returns>UnlinkIOSDeviceIDResult</returns>
        public async void UnlinkIOSDeviceID(Action<UnlinkIOSDeviceIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UnlinkIOSDeviceID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkIOSDeviceID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlinkIOSDeviceID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((UnlinkIOSDeviceIDResult)ApiClient.Deserialize(response.Content, typeof(UnlinkIOSDeviceIDResult), response.Headers));
        }

        /// <summary>
        /// Update User Display Name Updates the display name for the user in the project
        /// </summary>
        /// <param name="updateUserProjectDisplayNameRequest"></param>
        /// <returns>UpdateUserProjectDisplayNameResult</returns>
        public async void UpdateUserProjectDisplayName(UpdateUserProjectDisplayNameRequest updateUserProjectDisplayNameRequest, Action<UpdateUserProjectDisplayNameResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UpdateUserProjectDisplayName";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateUserProjectDisplayNameRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateUserProjectDisplayName: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateUserProjectDisplayName: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((UpdateUserProjectDisplayNameResult)ApiClient.Deserialize(response.Content, typeof(UpdateUserProjectDisplayNameResult), response.Headers));
        }

        /// <summary>
        /// Update default avatar id to the user which can be used for user profile 
        /// </summary>
        /// <param name="updateDefaultAvatarIDRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void UpdateDefaultAvatarID(UpdateDefaultAvatarIDRequest updateDefaultAvatarIDRequest, Action<UpdateDefaultAvatarIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    Debug.LogError("ProjectId is not present");
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/UpdateDefaultAvatarID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateDefaultAvatarIDRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateDefaultAvatarID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateDefaultAvatarID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((UpdateDefaultAvatarIDResult)ApiClient.Deserialize(response.Content, typeof(UpdateDefaultAvatarIDResult), response.Headers));
        }
    }
}



