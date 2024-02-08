using System;
using RestSharp;
using Com.Avataryug.Client;
using Com.Avataryug.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Avataryug.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEconomyApi
    {
        /// <summary>
        /// Get Economy Bundles by ID Get Economy Bundles by ID
        /// </summary>
        /// <param name="bundleID">Unqiue identifier for the bundle which is being requested.</param>
        /// <returns>GetEconomyBundleByIDResult</returns>
        void GetEconomyBundleByID(string bundleID, Action<GetEconomyBundleByIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Economy Bundles Get Economy Bundles
        /// </summary>
        /// <returns>GetEconomyBundlesResult</returns>
        void GetEconomyBundles(int Status, Action<GetEconomyBundlesResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Economy Container by ID Get Economy Container by ID
        /// </summary>
        /// <param name="containerID">Unqiue identifier for the container which is being requested.</param>
        /// <returns>GetEconomyContainerByIDResult</returns>
        void GetEconomyContainerByID(string containerID, Action<GetEconomyContainerByIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Economy Containers Get Economy Containers
        /// </summary>
        /// <returns>List&lt;GetEconomyContainersResultInner&gt;</returns>
        void GetEconomyContainers(int Status, Action<GetEconomyContainersResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Economy Items Get Economy Items
        /// </summary>
        /// <param name="category"></param>
        /// <param name="status"></param>
        /// <param name="gender"></param>
        /// <returns>GetEconomyItemsResult</returns>
        void GetEconomyItems(string category, int status, int gender, int offset, int limit, Action<GetEconomyItemsResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Economy Item by ID Get Economy Item by ID
        /// </summary>
        /// <param name="itemID">Unqiue identifier for the item which is being requested.</param>
        /// <returns>GetEconomyItemsByIDResult</returns>
        void GetEconomyItemsByID(string itemID, Action<GetEconomyItemsByIDResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Economy Stores Get Economy Stores
        /// </summary>
        /// <returns>GetEconomyStoresResult</returns>
        void GetEconomyStores(int Status, Action<GetEconomyStoresResult> result, Action<ApiException> error);

        /// <summary>
        /// Get Store Items by ID Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        /// <param name="storeID">Unqiue identifier for the store which is being requested.</param>
        /// <returns>GetStoreItemsByIDResult</returns>
        void GetStoreItemsByID(string storeID, Action<GetStoreItemsByIDResult> result, Action<ApiException> error);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class EconomyApi : IEconomyApi
    {
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EconomyApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public EconomyApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EconomyApi"/> class.
        /// </summary>
        /// <returns></returns>
        public EconomyApi(String basePath)
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
        /// Get Economy Bundles by ID Get Economy Bundles by ID
        /// </summary>
        /// <param name="bundleID">Unqiue identifier for the bundle which is being requested.</param>
        /// <returns>GetEconomyBundleByIDResult</returns>
        public async void GetEconomyBundleByID(string bundleID, Action<GetEconomyBundleByIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.LogError("ProjectId is not present");
                    }
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            // verify the required parameter 'bundleID' is set
            if (bundleID == null) throw new ApiException(400, "Missing required parameter 'bundleID' when calling GetEconomyBundleByID");

            var path = "/GetEconomyBundleByID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (bundleID != null) queryParams.Add("BundleID", ApiClient.ParameterToString(bundleID)); // query parameter
            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyBundleByID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyBundleByID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GetEconomyBundleByIDResult)ApiClient.Deserialize(response.Content, typeof(GetEconomyBundleByIDResult), response.Headers));
        }

        /// <summary>
        /// Get Economy Bundles Get Economy Bundles
        /// </summary>
        /// <returns>GetEconomyBundlesResult</returns>
        public async void GetEconomyBundles(int Status, Action<GetEconomyBundlesResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.LogError("ProjectId is not present");
                    }
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/GetEconomyBundles";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            queryParams.Add("Status", ApiClient.ParameterToString(Status)); // query parameter
            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyBundles: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyBundles: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GetEconomyBundlesResult)ApiClient.Deserialize(response.Content, typeof(GetEconomyBundlesResult), response.Headers));
        }

        /// <summary>
        /// Get Economy Container by ID Get Economy Container by ID
        /// </summary>
        /// <param name="containerID">Unqiue identifier for the container which is being requested.</param>
        /// <returns>GetEconomyContainerByIDResult</returns>
        public async void GetEconomyContainerByID(string containerID, Action<GetEconomyContainerByIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.LogError("ProjectId is not present");
                    }
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            // verify the required parameter 'containerID' is set
            if (containerID == null) throw new ApiException(400, "Missing required parameter 'containerID' when calling GetEconomyContainerByID");

            var path = "/GetEconomyContainerByID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (containerID != null) queryParams.Add("ContainerID", ApiClient.ParameterToString(containerID)); // query parameter
            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyContainerByID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyContainerByID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }
            result.Invoke((GetEconomyContainerByIDResult)ApiClient.Deserialize(response.Content, typeof(GetEconomyContainerByIDResult), response.Headers));
        }

        /// <summary>
        /// Get Economy Containers Get Economy Containers
        /// </summary>
        /// <returns>List&lt;GetEconomyContainersResultInner&gt;</returns>
        public async void GetEconomyContainers(int Status, Action<GetEconomyContainersResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.LogError("ProjectId is not present");
                    }
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/GetEconomyContainers";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            queryParams.Add("Status", ApiClient.ParameterToString(Status)); // query parameter
            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyContainers: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyContainers: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((GetEconomyContainersResult)ApiClient.Deserialize(response.Content, typeof(GetEconomyContainersResult), response.Headers));
        }

        /// <summary>
        /// Get Economy Items Get Economy Items
        /// </summary>
        /// <param name="category"></param>
        /// <param name="status"></param>
        /// <param name="gender"></param>
        /// <returns>GetEconomyItemsResult</returns>
        public async void GetEconomyItems(string category, int status, int gender, int offset, int limit, Action<GetEconomyItemsResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.LogError("ProjectId is not present");
                    }
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            // verify the required parameter 'category' is set
            if (category == null) throw new ApiException(400, "Missing required parameter 'category' when calling GetEconomyItems");

            var path = "/GetEconomyItems";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (category != null) queryParams.Add("Category", ApiClient.ParameterToString(category)); // query parameter
            queryParams.Add("Status", ApiClient.ParameterToString(status)); // query parameter
            queryParams.Add("Gender", ApiClient.ParameterToString(gender)); // query parameter
            queryParams.Add("Offset", ApiClient.ParameterToString(offset));
            queryParams.Add("Limit", ApiClient.ParameterToString(limit));
            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyItems: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyItems: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((GetEconomyItemsResult)ApiClient.Deserialize(response.Content, typeof(GetEconomyItemsResult), response.Headers));
        }

        /// <summary>
        /// Get Economy Item by ID Get Economy Item by ID
        /// </summary>
        /// <param name="itemID">Unqiue identifier for the item which is being requested.</param>
        /// <returns>GetEconomyItemsByIDResult</returns>
        public async void GetEconomyItemsByID(string itemID, Action<GetEconomyItemsByIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.LogError("ProjectId is not present");
                    }
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            // verify the required parameter 'itemID' is set
            if (itemID == null) throw new ApiException(400, "Missing required parameter 'itemID' when calling GetEconomyItemsByID");

            var path = "/GetEconomyItemsByID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (itemID != null) queryParams.Add("ItemID", ApiClient.ParameterToString(itemID)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyItemsByID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyItemsByID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((GetEconomyItemsByIDResult)ApiClient.Deserialize(response.Content, typeof(GetEconomyItemsByIDResult), response.Headers));
        }

        /// <summary>
        /// Get Economy Stores Get Economy Stores
        /// </summary>
        /// <returns>GetEconomyStoresResult</returns>
        public async void GetEconomyStores(int Status, Action<GetEconomyStoresResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.LogError("ProjectId is not present");
                    }
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }

            var path = "/GetEconomyStores";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            queryParams.Add("Status", ApiClient.ParameterToString(Status)); // query parameter
            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyStores: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetEconomyStores: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result.Invoke((GetEconomyStoresResult)ApiClient.Deserialize(response.Content, typeof(GetEconomyStoresResult), response.Headers));
        }

        /// <summary>
        /// Get Store Items by ID Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        /// <param name="storeID">Unqiue identifier for the store which is being requested.</param>
        /// <returns>GetStoreItemsByIDResult</returns>
        public async void GetStoreItemsByID(string storeID, Action<GetStoreItemsByIDResult> result, Action<ApiException> error)
        {
            if (!Configuration.ProjectIdPresent)
            {
                if (Configuration.avatarProjectSettings.DebugLog)
                {
                    if (Configuration.avatarProjectSettings.DebugLog)
                    {
                        Debug.LogError("ProjectId is not present");
                    }
                }
                ApiEvents.OnShowTextPopup?.Invoke(null, "Project Id is not set");
                return;
            }
            // verify the required parameter 'storeID' is set
            if (storeID == null) throw new ApiException(400, "Missing required parameter 'storeID' when calling GetStoreItemsByID");

            var path = "/GetStoreItemsByID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (storeID != null) queryParams.Add("StoreID", ApiClient.ParameterToString(storeID)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetStoreItemsByID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GetStoreItemsByID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GetStoreItemsByIDResult)ApiClient.Deserialize(response.Content, typeof(GetStoreItemsByIDResult), response.Headers));
        }
    }
}
