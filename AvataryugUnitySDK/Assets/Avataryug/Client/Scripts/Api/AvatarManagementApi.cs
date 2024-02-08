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
    public interface IAvatarManagementApi
    {
        /// <summary>
        /// Sync Avatars
        /// </summary>
        /// <exception cref="Com.Avataryug.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="syncAvatarsRequest"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>SyncAvatarsResult</returns>
        void SyncAvatars(SyncAvatarsRequest syncAvatarsRequest, Action<string> result, Action<ApiException> error);

        /// <summary>
        /// Render Avatar Image 
        /// </summary>
        /// <param name="renderAvatarImageRequest"></param>
        /// <returns>RenderAvatarImageResponse</returns>
        void RenderAvatarImage(RenderAvatarImageRequest renderAvatarImageRequest, Action<RenderAvatarImageResponse> result, Action<ApiException> error);

        /// <summary>
        /// Get All Bucket Vertices Get vertices for all buckets
        /// </summary>
        /// <param name="platform">Name of the platform. I.e. Unreal, Unity</param>
        /// <returns>GetAllBucketVerticesResult</returns>
        void GetAllBucketVertices(string platform, Action<GetAllBucketVerticesResult> result, Action<ApiException> error);

        /// <summary>
        /// Generate Avatar Mesh This will generated 3D mesh of the Avatar
        /// </summary>
        /// <param name="generateAvatarMeshRequest"></param>
        /// <returns>GenerateAvatarMeshResponse</returns>
        void GenerateAvatarMesh(GenerateAvatarMeshRequest generateAvatarMeshRequest, Action<GenerateAvatarMeshResponse> result, Action<ApiException> error);

        /// <summary>
        /// Get Avatar Presets Get all avatar presets
        /// </summary>
        /// <returns>GetAvatarPresetsResult</returns>
        void GetAvatarPresets(int status, int gender, Action<GetAvatarPresetsResult> result, Action<ApiException> error);

        /// <summary>
        /// Get AvatarPresets By ID Retrive Avatar preset by ID
        /// </summary>
        /// <param name="avatarPresetID">Unique Identifier for the Avatar Preset which is being requested</param>
        /// <returns>GetAvatarPresetByID200</returns>
        void GetAvatarPresetsByID(string avatarPresetID, Action<GetAvatarPresetByID200> result, Action<ApiException> error);

        /// <summary>
        /// Grant Avatar Preset Items to the user 
        /// </summary>
        /// <param name="grantAvatarPresetItemsToUserRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        void GrantAvatarPresetItemsToUser(GrantAvatarPresetItemsToUserRequest grantAvatarPresetItemsToUserRequest, Action<GrantAvatarPresetItemsToUserResponse> result, Action<ApiException> error);

        /// <summary>
        /// Grant AvatarPreset To User Grants the specified Avatar to the user
        /// </summary>
        /// <param name="grantAvatarToUserRequest"></param>
        /// <returns>GrantAvatarToUserResult</returns>
        void GrantAvatarPresetToUser(GrantAvatarToUserRequest grantAvatarToUserRequest, Action<GrantAvatarToUserResponse> result, Action<ApiException> error);

        /// <summary>
        /// Get Clips 
        /// </summary>
        /// <returns>GetClipsResponse</returns>
        void GetClips(int Status, Action<GetClipsResponse> result, Action<ApiException> error);

        /// <summary>
        /// Get Clips By ID 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>GetClipsByIDResponse</returns>
        void GetClipsByID(string clipID, Action<GetClipsByIDResponse> result, Action<ApiException> error);

        /// <summary>
        /// Get Expression By ID 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>GetExpressionByIDResponse</returns>
        void GetExpressionByID(string userID, Action<GetExpressionByIDResponse> result, Action<ApiException> error);

        /// <summary>
        /// Get Expressions 
        /// </summary>
        /// <returns>GetExpressionsResponse</returns>
        void GetExpressions(int Status, Action<GetExpressionsResponse> result, Action<ApiException> error);

        void GetUserAvatarAllData(string AvatarID, string Platform, Action<GetUserAvatarAllDataResponse> result, Action<ApiException> error);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AvatarManagementApi : IAvatarManagementApi
    {
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClipsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public AvatarManagementApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClipsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AvatarManagementApi(String basePath)
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
        /// Render Avatar Image 
        /// </summary>
        /// <param name="renderAvatarImageRequest"></param>
        /// <returns>RenderAvatarImageResponse</returns>
        public async void RenderAvatarImage(RenderAvatarImageRequest renderAvatarImageRequest, Action<RenderAvatarImageResponse> result, Action<ApiException> error)
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

            var path = "/RenderAvatarImage";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(renderAvatarImageRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling RenderAvatarImage: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling RenderAvatarImage: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((RenderAvatarImageResponse)ApiClient.Deserialize(response.Content, typeof(RenderAvatarImageResponse), response.Headers));
        }

        /// <summary>
        /// Get Clips by Status = 1 
        /// 0 = Draft, 1 = Active, 2 = Inactive, 3 = Expired
        /// </summary>
        /// <returns>GetClipsResponse</returns>
        public async void GetClips(int Status, Action<GetClipsResponse> result, Action<ApiException> error)
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

            var path = "/GetClips";
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
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetClips: " + response.Content, response.Content));
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetClips: " + response.ErrorMessage, response.ErrorMessage));
            }
            Debug.Log("Clips=>" + response.Content);
            result?.Invoke((GetClipsResponse)ApiClient.Deserialize(response.Content, typeof(GetClipsResponse), response.Headers));
        }

        /// <summary>
        /// Get Clips By ID 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>GetClipsByIDResponse</returns>
        public async void GetClipsByID(string clipID, Action<GetClipsByIDResponse> result, Action<ApiException> error)
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
            if (clipID == null) throw new ApiException(400, "Missing required parameter 'userID' when calling GetClipsByID");

            var path = "/GetClipsByID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (clipID != null) queryParams.Add("ClipID", ApiClient.ParameterToString(clipID)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetClipsByID: " + response.Content, response.Content));
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetClipsByID: " + response.ErrorMessage, response.ErrorMessage));
            }
            result?.Invoke((GetClipsByIDResponse)ApiClient.Deserialize(response.Content, typeof(GetClipsByIDResponse), response.Headers));
        }

        /// <summary>
        /// Get All Bucket Vertices Get vertices for all buckets
        /// </summary>
        /// <param name="platform">Name of the platform. I.e. Unreal, Unity</param>
        /// <returns>GetAllBucketVerticesResult</returns>
        public async void GetAllBucketVertices(string platform, Action<GetAllBucketVerticesResult> result, Action<ApiException> error)
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

            // verify the required parameter 'platform' is set
            if (platform == null) throw new ApiException(400, "Missing required parameter 'platform' when calling GetAllBucketVertices");

            var path = "/GetAllBucketVertices";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (platform != null) queryParams.Add("Platform", ApiClient.ParameterToString(platform)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "apiKeyHeader", "apiKeyQuery" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAllBucketVertices: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAllBucketVertices: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }
            result?.Invoke((GetAllBucketVerticesResult)ApiClient.Deserialize(response.Content, typeof(GetAllBucketVerticesResult), response.Headers));
        }

        /// <summary>
        /// Get Expression By ID 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>GetExpressionByIDResponse</returns>
        public async void GetExpressionByID(string expressionID, Action<GetExpressionByIDResponse> result, Action<ApiException> error)
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
            if (expressionID == null) throw new ApiException(400, "Missing required parameter 'userID' when calling GetExpressionByID");

            var path = "/GetExpressionByID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (expressionID != null) queryParams.Add("ExpressionID", ApiClient.ParameterToString(expressionID)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetExpressionByID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetExpressionByID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GetExpressionByIDResponse)ApiClient.Deserialize(response.Content, typeof(GetExpressionByIDResponse), response.Headers));
        }

        /// <summary>
        /// Get Expressions 
        /// </summary>
        /// <returns>GetExpressionsResponse</returns>
        public async void GetExpressions(int Status, Action<GetExpressionsResponse> result, Action<ApiException> error)
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

            var path = "/GetExpressions";
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
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetExpressions: " + response.Content, response.Content));
                return;
            }

            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetExpressions: " + response.ErrorMessage, response.ErrorMessage));
            }
            result?.Invoke((GetExpressionsResponse)ApiClient.Deserialize(response.Content, typeof(GetExpressionsResponse), response.Headers));
        }

        /// <summary>
        /// Grant AvatarPreset To User Grants the specified Avatar to the user
        /// </summary>
        /// <param name="grantAvatarToUserRequest"></param>
        /// <returns>GrantAvatarToUserResult</returns>
        public async void GrantAvatarPresetToUser(GrantAvatarToUserRequest grantAvatarToUserRequest, Action<GrantAvatarToUserResponse> result, Action<ApiException> error)
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

            var path = "/GrantAvatarPresetToUser";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(grantAvatarToUserRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GrantAvatarToUser: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GrantAvatarToUser: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GrantAvatarToUserResponse)ApiClient.Deserialize(response.Content, typeof(GrantAvatarToUserResponse), response.Headers));
        }

        /// <summary>
        /// Get Avatar Presets Get all avatar presets
        /// </summary>
        /// <returns>GetAvatarPresetsResult</returns>
        public async void GetAvatarPresets(int status, int gender, Action<GetAvatarPresetsResult> result, Action<ApiException> error)
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

            var path = "/GetAvatarPresets";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            queryParams.Add("Status", ApiClient.ParameterToString(status));
            queryParams.Add("Gender", ApiClient.ParameterToString(gender));
            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAvatarPresets: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAvatarPresets: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }
            result?.Invoke((GetAvatarPresetsResult)ApiClient.Deserialize(response.Content, typeof(GetAvatarPresetsResult), response.Headers));
        }

        /// <summary>
        /// Get AvatarPresets By ID Retrive Avatar preset by ID
        /// </summary>
        /// <param name="avatarPresetID">Unique Identifier for the Avatar Preset which is being requested</param>
        /// <returns>GetAvatarPresetByID200</returns>
        public async void GetAvatarPresetsByID(string avatarPresetID, Action<GetAvatarPresetByID200> result, Action<ApiException> error)
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

            // verify the required parameter 'avatarPresetID' is set
            if (avatarPresetID == null) throw new ApiException(400, "Missing required parameter 'avatarPresetID' when calling GetAvatarPresetsByID");


            var path = "/GetAvatarPresetsByID";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (avatarPresetID != null) queryParams.Add("AvatarPresetID", ApiClient.ParameterToString(avatarPresetID)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAvatarPresetsByID: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAvatarPresetsByID: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }

            result?.Invoke((GetAvatarPresetByID200)ApiClient.Deserialize(response.Content, typeof(GetAvatarPresetByID200), response.Headers));
        }

        /// <summary>
        /// Grant Avatar Preset Items To User 
        /// </summary>
        /// <param name="grantAvatarPresetItemsToUserRequest">Request payload</param>
        /// <returns>GrantAvatarPresetItemsToUserResponse</returns>
        public async void GrantAvatarPresetItemsToUser(GrantAvatarPresetItemsToUserRequest grantAvatarPresetItemsToUserRequest, Action<GrantAvatarPresetItemsToUserResponse> result, Action<ApiException> error)
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

            var path = "/GrantAvatarPresetItemsToUser";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(grantAvatarPresetItemsToUserRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GrantAvatarPresetItemsToUser: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error.Invoke(new ApiException((int)response.StatusCode, "Error calling GrantAvatarPresetItemsToUser: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }
            result.Invoke((GrantAvatarPresetItemsToUserResponse)ApiClient.Deserialize(response.Content, typeof(GrantAvatarPresetItemsToUserResponse), response.Headers));
        }

        /// <summary>
        /// Generate Avatar Mesh This will generated 3D mesh of the Avatar
        /// </summary>
        /// <param name="generateAvatarMeshRequest"></param>
        /// <returns>GenerateAvatarMeshResponse</returns>
        public async void GenerateAvatarMesh(GenerateAvatarMeshRequest generateAvatarMeshRequest, Action<GenerateAvatarMeshResponse> result, Action<ApiException> error)
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

            var path = "/GenerateAvatarMesh";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(generateAvatarMeshRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GenerateAvatarMesh: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GenerateAvatarMesh: " + response.ErrorMessage, response.ErrorMessage));
            }
            result?.Invoke((GenerateAvatarMeshResponse)ApiClient.Deserialize(response.Content, typeof(GenerateAvatarMeshResponse), response.Headers));
        }

        /// <summary>
        /// Sync Avatar Creates missing avatars into the mentioned platform for the user
        /// </summary>
        /// <param name="syncAvatarsRequest"></param>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public async void SyncAvatars(SyncAvatarsRequest syncAvatarsRequest, Action<string> result, Action<ApiException> error)
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
            var path = "/SyncAvatars";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(syncAvatarsRequest); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SyncAvatars: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling SyncAvatars: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }
            result?.Invoke(response.Content);
        }

        public async void GetUserAvatarAllData(string AvatarID, string Platform, Action<GetUserAvatarAllDataResponse> result, Action<ApiException> error)
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

            var path = "/GetUserAvatarAllData";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            queryParams.Add("AvatarID", ApiClient.ParameterToString(AvatarID));
            queryParams.Add("Platform", ApiClient.ParameterToString(Platform));

            // authentication setting, if any
            String[] authSettings = new String[] { "bearerAuth" };

            // make the HTTP request
            IRestResponse response = (IRestResponse)await ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAvatarPresets: " + response.Content, response.Content));
                return;
            }
            else if (((int)response.StatusCode) == 0)
            {
                error?.Invoke(new ApiException((int)response.StatusCode, "Error calling GetAvatarPresets: " + response.ErrorMessage, response.ErrorMessage));
                return;
            }
            result?.Invoke((GetUserAvatarAllDataResponse)ApiClient.Deserialize(response.Content, typeof(GetUserAvatarAllDataResponse), response.Headers));
        }

    }
}
