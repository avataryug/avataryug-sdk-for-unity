using System;
using RestSharp;
using Com.Avataryug.Model;
using Com.Avataryug.Client;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Avataryug.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAdvertisingApi
    {
        /// <summary>
        /// Record Ads Activity 
        /// </summary>
        /// <param name="recordAdsActivityRequest"></param>
        /// <returns>RecordAdsActivityResponse</returns>
        void RecordAdsActivity(RecordAdsActivityRequest recordAdsActivityRequest, Action<RecordAdsActivityResponse> result, Action<ApiException> error);
        /// <summary>
        /// Grant Ads Reward 
        /// </summary>
        /// <param name="grantAdsRewardRequest"></param>
        /// <returns>GrantAdsRewardResponse</returns>
        void GrantAdsReward(GrantAdsRewardRequest grantAdsRewardRequest, Action<GrantAdsRewardResponse> result, Action<ApiException> error);
        /// <summary>
        /// Get Ads Placement 
        /// </summary>
        /// <param name="appID"></param>
        /// <returns>GetAdsPlacementResponse</returns>
        void GetAdsPlacement(string appID, Action<GetAdsPlacementResponse> result, Action<ApiException> error);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AdvertisingApi : IAdvertisingApi
    {
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AdvertisingApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AdvertisingApi(String basePath)
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
        /// Get Ads Placement 
        /// </summary>
        /// <param name="appID"></param>
        /// <returns>GetAdsPlacementResponse</returns>
        public async void GetAdsPlacement(string appID, Action<GetAdsPlacementResponse> result, Action<ApiException> error)
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

            // verify the required parameter 'appID' is set
            if (appID == null) throw new ApiException(400, "Missing required parameter 'appID' when calling GetAdsPlacement");


            var path = "/GetAdPlacementByID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (appID != null) queryParams.Add("PlacementID", ApiClient.ParameterToString(appID)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAdsPlacement: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAdsPlacement: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GetAdsPlacementResponse)ApiClient.Deserialize(response.Content, typeof(GetAdsPlacementResponse), response.Headers));
        }

        /// <summary>
        /// Record Ads Activity 
        /// </summary>
        /// <param name="recordAdsActivityRequest"></param>
        /// <returns>RecordAdsActivityResponse</returns>
        public async void RecordAdsActivity(RecordAdsActivityRequest recordAdsActivityRequest, Action<RecordAdsActivityResponse> result, Action<ApiException> error)
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

            var path = "/RecordAdsActivity";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(recordAdsActivityRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling RecordAdsActivity: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling RecordAdsActivity: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((RecordAdsActivityResponse)ApiClient.Deserialize(response.Content, typeof(RecordAdsActivityResponse), response.Headers));
        }

        /// <summary>
        /// Grant Ads Reward 
        /// </summary>
        /// <param name="grantAdsRewardRequest"></param>
        /// <returns>GrantAdsRewardResponse</returns>
        public async void GrantAdsReward(GrantAdsRewardRequest grantAdsRewardRequest, Action<GrantAdsRewardResponse> result, Action<ApiException> error)
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

            var path = "/GrantAdsReward";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(grantAdsRewardRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GrantAdsReward: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GrantAdsReward: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }
            result?.Invoke((GrantAdsRewardResponse)ApiClient.Deserialize(response.Content, typeof(GrantAdsRewardResponse), response.Headers));
        }
    }
}