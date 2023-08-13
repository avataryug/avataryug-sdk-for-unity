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
    public interface IUserDataManagementApi
    {
        /// <summary>
        /// Unlock Container Instance Opens the specified container, with the specified key (when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses &gt; 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        /// <param name="unlockContainerInstanceRequest"></param>
        /// <returns>UnlockContainerInstanceResult</returns>
        void UnlockContainerInstance(UnlockContainerInstanceRequest unlockContainerInstanceRequest, Action<UnlockContainerInstanceResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Users All Avatars Lists all of the avatars that belong to a specific user
        /// </summary>
        /// <param name="userID">Unique Avataryug assigned ID of the user on whom the operation will be performed</param>
        /// <returns>GetUsersAllAvatarsResult</returns>
        void GetUsersAllAvatars(string userID, Action<GetUsersAllAvatarsResult> result, Action<ApiException> error);

        /// <summary>
        /// Update User Avatar Update Avatar for the user
        /// </summary>
        /// <param name="updateUserAvatarRequest"></param>
        /// <returns>UpdateUserAvatarResult</returns>
        void UpdateUserAvatar(UpdateUserAvatarRequest updateUserAvatarRequest, Action<UpdateUserAvatarResult> result, Action<ApiException> error);

        /// <summary>
        /// Delete User Avatar Delete Avatar for the user
        /// </summary>
        /// <param name="deleteUserAvatarRequest"></param>
        /// <returns>DeleteUserAvatarResult</returns>
        void DeleteUserAvatar(DeleteUserAvatarRequest deleteUserAvatarRequest, Action<DeleteUserAvatarResult> result, Action<ApiException> error);

        /// <summary>
        /// Add Virtual Currency to User Increments the user&#39;s balance of the specified virtual currency by the stated amount
        /// </summary>
        /// <param name="addVirtualCurrencyToUserRequest"></param>
        /// <returns>AddVirtualCurrencyToUserResult</returns>
        void AddVirtualCurrencyToUser(AddVirtualCurrencyToUserRequest addVirtualCurrencyToUserRequest, Action<AddVirtualCurrencyToUserResult> result, Action<ApiException> error);

        /// <summary>
        /// ConsumeInstance Consume uses of a consumable item. When all uses are consumed, it will be removed from the user&#39;s inventory.
        /// </summary>
        /// <param name="consumeInstanceRequest"></param>
        /// <returns>ConsumeInstanceResult</returns>
        void ConsumeInstance(ConsumeInstanceRequest consumeInstanceRequest, Action<ConsumeInstanceResult> result, Action<ApiException> error);

        /// <summary>
        /// Get User Inventory Retrieves the user&#39;s current inventory of virtual goods
        /// </summary>
        /// <param name="userID">Unique Avataryug identifier of the user whose info is being requested. Optional, defaults to the authenticated user if no other lookup identifier set.</param>
        /// <returns>GetUserInventoryResult</returns>
        void GetUserInventory(Action<GetUserInventoryResult> result, Action<ApiException> error);

        /// <summary>
        /// Grant Items To User Adds the specified items to the specified user's inventory
        /// </summary>
        /// <param name="grantInstanceToUserRequest"></param>
        /// <returns>GrantInstanceToUserResult</returns>
        void GrantInstanceToUser(GrantInstanceToUserRequest grantInstanceToUserRequest, Action<GrantInstanceToUserResult> result, Action<ApiException> error);

        /// <summary>
        /// Purchase Instance Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as well as what the client believes the price to be. This lets the server fail the purchase if the price has changed.
        /// </summary>
        /// <param name="purchaseInstanceRequest"></param>
        /// <returns></returns>
        void PurchaseInstance(PurchaseInstanceRequest purchaseInstanceRequest, Action<object> result, Action<ApiException> error);

        /// <summary>
        /// Subtract User Virtual Currency Decrements the user&#39;s balance of the specified virtual currency by the stated amount. It is possible to make a VC balance negative with this API.
        /// </summary>
        /// <param name="subtractUserVirtualCurrencyRequest"></param>
        /// <returns></returns>
        void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest subtractUserVirtualCurrencyRequest, Action result, Action<ApiException> error);

        /// <summary>
        /// Start Purchase used to call once user starting the transation 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        void StartPurchase(Action<string> result, Action<ApiException> error);

        /// <summary>
        /// Add User Avatar Add Avatar to the user
        /// </summary>
        /// <param name="addUserAvatarRequest"></param>
        /// <returns>AddUserAvatarResult</returns>
        void AddUserAvatar(AddUserAvatarRequest addUserAvatarRequest, Action<AddUserAvatarResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Purchase Result
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        void GetPurchase(Action<ConfirmPurchaseResult> result, Action<ApiException> error);

        /// <summary>
        /// Confirm purchase
        /// </summary>
        /// <param name="confirmPurchaseRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        void ConfirmPurchase(ConfirmPurchaseRequest confirmPurchaseRequest, Action<ConfirmPurchaseResult> result, Action<ApiException> error);

        /// <summary>
        /// Pay for purchase
        /// </summary>
        /// <param name="payForPurchaseRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        void PayForPurchase(PayForPurchaseRequest payForPurchaseRequest, Action<PayForPurchaseResult> result, Action<ApiException> error);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UserDataManagementApi : IUserDataManagementApi
    {
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDataManagementApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public UserDataManagementApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDataManagementApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UserDataManagementApi(String basePath)
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
        /// Add Virtual Currency to User Increments the user&#39;s balance of the specified virtual currency by the stated amount
        /// </summary>
        /// <param name="addVirtualCurrencyToUserRequest"></param>
        /// <returns>AddVirtualCurrencyToUserResult</returns>
        public async void AddVirtualCurrencyToUser(AddVirtualCurrencyToUserRequest addVirtualCurrencyToUserRequest, Action<AddVirtualCurrencyToUserResult> result, Action<ApiException> error)
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

            var path = "/AddVirtualCurrencyToUser";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addVirtualCurrencyToUserRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling AddVirtualCurrencyToUser: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling AddVirtualCurrencyToUser: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((AddVirtualCurrencyToUserResult)ApiClient.Deserialize(response.Content, typeof(AddVirtualCurrencyToUserResult), response.Headers));
        }

        /// <summary>
        /// ConsumeInstance Consume uses of a consumable item. When all uses are consumed, it will be removed from the user&#39;s inventory.
        /// </summary>
        /// <param name="consumeInstanceRequest"></param>
        /// <returns>ConsumeInstanceResult</returns>
        public async void ConsumeInstance(ConsumeInstanceRequest consumeInstanceRequest, Action<ConsumeInstanceResult> result, Action<ApiException> error)
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

            var path = "/ConsumeInstance";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(consumeInstanceRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling ConsumeInstance: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling ConsumeInstance: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((ConsumeInstanceResult)ApiClient.Deserialize(response.Content, typeof(ConsumeInstanceResult), response.Headers));
        }

        /// <summary>
        /// Get User Inventory Retrieves the user&#39;s current inventory of virtual goods
        /// </summary>
        /// <param name="userID">Unique Avataryug identifier of the user whose info is being requested. Optional, defaults to the authenticated user if no other lookup identifier set.</param>
        /// <returns>GetUserInventoryResult</returns>
        public async void GetUserInventory(Action<GetUserInventoryResult> result, Action<ApiException> error)
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

            var path = "/GetUserInventory";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetUserInventory: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetUserInventory: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GetUserInventoryResult)ApiClient.Deserialize(response.Content, typeof(GetUserInventoryResult), response.Headers));
        }

        /// <summary>
        /// Grant Items To User Adds the specified items to the specified user&#39;s inventory
        /// </summary>
        /// <param name="grantInstanceToUserRequest"></param>
        /// <returns>GrantInstanceToUserResult</returns>
        public async void GrantInstanceToUser(GrantInstanceToUserRequest grantInstanceToUserRequest, Action<GrantInstanceToUserResult> result, Action<ApiException> error)
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
            if (Configuration.avatarProjectSettings.DebugLog)
            {
                UnityEngine.Debug.Log(grantInstanceToUserRequest.ToJson());
            }
            var path = "/GrantInstanceToUser";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(grantInstanceToUserRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GrantInstanceToUser: " + response.Content, response.Content));
                return;
            }

            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GrantInstanceToUser: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GrantInstanceToUserResult)ApiClient.Deserialize(response.Content, typeof(GrantInstanceToUserResult), response.Headers));
        }

        /// <summary>
        /// Purchase Instance Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as well as what the client believes the price to be. This lets the server fail the purchase if the price has changed.
        /// </summary>
        /// <param name="purchaseInstanceRequest"></param>
        /// <returns></returns>
        public async void PurchaseInstance(PurchaseInstanceRequest purchaseInstanceRequest, Action<object> result, Action<ApiException> error)
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
            if (Configuration.avatarProjectSettings.DebugLog)
            {
                UnityEngine.Debug.Log(purchaseInstanceRequest.ToJson() + "PurchaseInstance");
            }
            var path = "/PurchaseInstance";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(purchaseInstanceRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
            if (Configuration.avatarProjectSettings.DebugLog)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    UnityEngine.Debug.Log(response.Content + "PurchaseInstance1");
                }
            }
            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling PurchaseInstance: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling PurchaseInstance: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke(response.Content);
        }

        /// <summary>
        /// Subtract User Virtual Currency Decrements the user&#39;s balance of the specified virtual currency by the stated amount. It is possible to make a VC balance negative with this API.
        /// </summary>
        /// <param name="subtractUserVirtualCurrencyRequest"></param>
        /// <returns></returns>
        public async void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest subtractUserVirtualCurrencyRequest, Action result, Action<ApiException> error)
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

            var path = "/SubtractUserVirtualCurrency";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(subtractUserVirtualCurrencyRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SubtractUserVirtualCurrency: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SubtractUserVirtualCurrency: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke();

        }
        /// <summary>
        /// Start Purchase used to call once user starting the transation 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void StartPurchase(Action<string> result, Action<ApiException> error)
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


            var path = "/StartPurchase";
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
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SubtractUserVirtualCurrency: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SubtractUserVirtualCurrency: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke(response.Content);
        }

        /// <summary>
        /// Delete User Avatar Delete Avatar for the user
        /// </summary>
        /// <param name="deleteUserAvatarRequest"></param>
        /// <returns>DeleteUserAvatarResult</returns>
        public async void DeleteUserAvatar(DeleteUserAvatarRequest deleteUserAvatarRequest, Action<DeleteUserAvatarResult> result, Action<ApiException> error)
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

            var path = "/DeleteUserAvatar";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(deleteUserAvatarRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling DeleteUserAvatar: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling DeleteUserAvatar: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((DeleteUserAvatarResult)ApiClient.Deserialize(response.Content, typeof(DeleteUserAvatarResult), response.Headers));
        }

        /// <summary>
        /// Update User Avatar Update Avatar for the user
        /// </summary>
        /// <param name="updateUserAvatarRequest"></param>
        /// <returns>UpdateUserAvatarResult</returns>
        public async void UpdateUserAvatar(UpdateUserAvatarRequest updateUserAvatarRequest, Action<UpdateUserAvatarResult> result, Action<ApiException> error)
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

            var path = "/UpdateUserAvatar";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(updateUserAvatarRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateUserAvatar: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling UpdateUserAvatar: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((UpdateUserAvatarResult)ApiClient.Deserialize(response.Content, typeof(UpdateUserAvatarResult), response.Headers));
        }

        /// <summary>
        /// Add User Avatar Add Avatar to the user
        /// </summary>
        /// <param name="addUserAvatarRequest"></param>
        /// <returns>AddUserAvatarResult</returns>
        public async void AddUserAvatar(AddUserAvatarRequest addUserAvatarRequest, Action<AddUserAvatarResult> result, Action<ApiException> error)
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

            var path = "/AddUserAvatar";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(addUserAvatarRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling AddUserAvatar: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling AddUserAvatar: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((AddUserAvatarResult)ApiClient.Deserialize(response.Content, typeof(AddUserAvatarResult), response.Headers));
        }

        /// <summary>
        /// Get Users All Avatars Lists all of the avatars that belong to a specific user
        /// </summary>
        /// <param name="userID">Unique Avataryug assigned ID of the user on whom the operation will be performed</param>
        /// <returns>GetUsersAllAvatarsResult</returns>
        public async void GetUsersAllAvatars(string userID, Action<GetUsersAllAvatarsResult> result, Action<ApiException> error)
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
            if (userID == null) throw new ApiException(400, "Missing required parameter 'userID' when calling GetUsersAllAvatars");

            var path = "/GetUsersAllAvatars";
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
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetUsersAllAvatars: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetUsersAllAvatars: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((GetUsersAllAvatarsResult)ApiClient.Deserialize(response.Content, typeof(GetUsersAllAvatarsResult), response.Headers));
        }

        /// <summary>
        /// Unlock Container Instance Opens the specified container, with the specified key (when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses &gt; 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        /// <param name="unlockContainerInstanceRequest"></param>
        /// <returns>UnlockContainerInstanceResult</returns>
        public async void UnlockContainerInstance(UnlockContainerInstanceRequest unlockContainerInstanceRequest, Action<UnlockContainerInstanceResult> result, Action<ApiException> error)
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

            var path = "/UnlockContainerInstance";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(unlockContainerInstanceRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlockContainerInstance: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling UnlockContainerInstance: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((UnlockContainerInstanceResult)ApiClient.Deserialize(response.Content, typeof(UnlockContainerInstanceResult), response.Headers));
        }

        /// <summary>
        /// Confirm Purchase should be called after the transaction has been successfully completed.
        /// </summary>
        /// <param name="confirmPurchaseRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void ConfirmPurchase(ConfirmPurchaseRequest confirmPurchaseRequest, Action<ConfirmPurchaseResult> result, Action<ApiException> error)
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

            var path = "/ConfirmPurchase";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(confirmPurchaseRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling ConfirmPurchase: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling ConfirmPurchase: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((ConfirmPurchaseResult)ApiClient.Deserialize(response.Content, typeof(ConfirmPurchaseResult), response.Headers));
        }

        /// <summary>
        /// Get Purchase is used to retrieve comprehensive details of the purchase.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void GetPurchase(Action<ConfirmPurchaseResult> result, Action<ApiException> error)
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

            var path = "/GetPurchase";
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
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetPurchase: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetPurchase: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((ConfirmPurchaseResult)ApiClient.Deserialize(response.Content, typeof(ConfirmPurchaseResult), response.Headers));

        }

        /// <summary>
        /// Start Purchase should be called when user initiate the purchase process 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void StartPurchase(Action<object> result, Action<ApiException> error)
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

            var path = "/StartPurchase";
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
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling StartPurchase: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling StartPurchaseStartPurchase: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke(response.Content);
        }

        /// <summary>
        /// After complete the payment for the purchase use this method 
        /// </summary>
        /// <param name="payForPurchaseRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void PayForPurchase(PayForPurchaseRequest payForPurchaseRequest, Action<PayForPurchaseResult> result, Action<ApiException> error)
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

            var path = "/PayForPurchase";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(payForPurchaseRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling PayForPurchase: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling PayForPurchase: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((PayForPurchaseResult)ApiClient.Deserialize(response.Content, typeof(PayForPurchaseResult), response.Headers));
        }
    }
}
