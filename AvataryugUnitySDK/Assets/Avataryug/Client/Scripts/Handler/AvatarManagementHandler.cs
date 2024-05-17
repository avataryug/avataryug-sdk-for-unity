using System.Collections.Generic;
using Com.Avataryug.Client;
using Com.Avataryug.Model;
using Com.Avataryug.Api;

namespace Com.Avataryug.Handler
{
    /// <summary>
    /// The "AvatarManagementHandler" class is responsible for managing avatars and making API calls through the "Base" class.
    /// It provides multiple methods for creating, updating, and retrieving avatars related functionality.
    /// </summary>
    public class AvatarManagementHandler
    {
        public Base baseApiCall;
        public AvatarManagementHandler() { }
        public AvatarManagementHandler(Base _baseApiCall)
        {
            baseApiCall = _baseApiCall;
        }

        /// <summary>
        /// Get all the clips by input status
        /// 0 = Draft,
        /// 1 = Active,
        /// 2 = Inactive,
        /// 3 = Expired
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetClips(System.Action<GetClipsResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetClipsResponse)r); }, error);
        }

        /// <summary>
        /// Creates missing avatars into the mentioned platform for the user
        /// Please refer to the documentation for more information on platform-related details.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void SyncAvatars(System.Action<string> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((string)r); }, error);
        }

        /// <summary>
        /// Get the specified clip's details by providing ClipID
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetClipsByID(System.Action<GetClipsByIDResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetClipsByIDResponse)r); }, error);
        }

        /// <summary>
        /// Get the specified expression details by providing ExpressionID
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetExpressionByID(System.Action<GetExpressionByIDResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetExpressionByIDResponse)r); }, error);
        }

        /// <summary>
        /// Retrieve all expressions based on the provided status.
        /// 0 = Draft,
        /// 1 = Active,
        /// 2 = Inactive,
        /// 3 = Expired
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetExpressions(System.Action<GetExpressionsResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetExpressionsResponse)r); }, error);
        }

        /// <summary>
        /// Grant the selected avatar listed in the Avatar Preset by invoking the appropriate API.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GrantAvatarPresetToUser(System.Action<GrantAvatarToUserResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GrantAvatarToUserResponse)r); }, error);
        }

        /// <summary>
        /// Get all avatar presets
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetAvatarPresets(System.Action<GetAvatarPresetsResult> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetAvatarPresetsResult)r); }, error);
        }

        /// <summary>
        /// Retrive Avatar preset by ID
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetAvatarPresetsByID(System.Action<GetAvatarPresetByID200> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetAvatarPresetByID200)r); }, error);
        }

        /// <summary>
        /// Grant the selected avatar and its associated items to the user's inventory.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GrantAvatarPresetItemsToUser(System.Action<GrantAvatarPresetItemsToUserResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GrantAvatarPresetItemsToUserResponse)r); }, error);
        }

        /// <summary>
        /// Generates the 3D mesh as per the configuration in the Config panel
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GenerateAvatarMesh(System.Action<GenerateAvatarMeshResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GenerateAvatarMeshResponse)r); }, error);
        }

        /// <summary>
        /// Get vertices for all buckets
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetAllBucketVertices(System.Action<GetAllBucketVerticesResult> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetAllBucketVerticesResult)r); }, error);
        }

        /// <summary>
        /// Utilize the specified API to render the image of the avatar associated with the provided avatar ID.
        /// This API is specifically designed to generate and retrieve the rendered image of the avatar
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void RenderAvatarImage(System.Action<RenderAvatarImageResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((RenderAvatarImageResponse)r); }, error);
        }

        public void GetUserAvatarAllData(System.Action<GetUserAvatarAllDataResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetUserAvatarAllDataResponse)r); }, error);
        }


        public void BuildAvatarMesh(System.Action<GenerateAvatarMeshResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GenerateAvatarMeshResponse)r); }, error);
        }

        public void BuildAvatarImage(System.Action<RenderAvatarImageResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((RenderAvatarImageResponse)r); }, error);
        }
        public void CreateAvatar(System.Action<CreateAvatarResponse> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((CreateAvatarResponse)r); }, error);
        }
        public void UpdateAvatar(System.Action<string> result, System.Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((string)r); }, error);
        }

    }


    /// <summary>
    /// Creates missing avatars into the mentioned platform for the user
    /// </summary>
    public class SyncAvatars : Base
    {
        public bool Image;
        public bool Mesh;
        public string Platform;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AvatarManagementApi();
                authApi.SyncAvatars(new SyncAvatarsRequest()
                {
                    Image = Image,
                    Mesh = Mesh,
                    Platform = Platform,
                }
                , (res) => { result?.Invoke(res); }, error);
            }
        }
    }
    public class GetUserAvatarAllData : Base
    {
        public string Platfrom;
        public string AvatarID;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AvatarManagementApi();
                authApi.GetUserAvatarAllData(AvatarID, Platfrom, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get the specified expression details by providing ExpressionID
    /// </summary>
    public class GetExpressionByID : Base
    {
        public string expressionID;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AvatarManagementApi().GetExpressionByID(expressionID, result, error); ;
            }
        }
    }

    /// <summary>
    /// Generates the 3D mesh as per the configuration in the Config panel
    /// </summary>
    public class GenerateAvatarMesh : Base
    {
        public string AvatarID;
        public string Platform;


        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new AvatarManagementApi();
                auth.GenerateAvatarMesh(new GenerateAvatarMeshRequest()
                {
                    AvatarID = AvatarID,
                    Platform = Platform,
                }, result, error);
            }
        }
    }

    /// <summary>
    /// Grant Avatar Preset To User
    /// </summary>
    public class GrantAvatarPresetToUser : Base
    {
        public string AvatarData;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AvatarManagementApi().GrantAvatarPresetToUser(new GrantAvatarToUserRequest()
                {
                    AvatarData = AvatarData
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get all the active expressions
    /// </summary>
    public class GetExpressions : Base
    {
        public int Status;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AvatarManagementApi().GetExpressions(Status, result, error); ;
            }
        }
    }

    /// <summary>
    /// Get all the clips by Active status
    /// </summary>
    public class GetClips : Base
    {
        public int Status;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AvatarManagementApi().GetClips(Status, result, error); ;
            }
        }
    }

    /// <summary>
    /// Get the specified clip's details by providing ClipID
    /// </summary>
    public class GetClipsByID : Base
    {
        public string clipID;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AvatarManagementApi().GetClipsByID(clipID, result, error); ;
            }
        }
    }

    /// <summary>
    /// Grant Avatar Preset Items To User
    /// </summary>
    public class GrantAvatarPresetItemsToUser : Base
    {
        public List<string> itemId = new List<string>();
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                GrantAvatarPresetItemsToUserRequest grantAvatarPreset = new GrantAvatarPresetItemsToUserRequest();
                grantAvatarPreset.ItemIDs = new List<GrantAvatarPresetItemsToUserRequestItemIDsInner>();
                foreach (var item in itemId)
                {
                    grantAvatarPreset.ItemIDs.Add(new GrantAvatarPresetItemsToUserRequestItemIDsInner() { ItemID = item });
                }
                new AvatarManagementApi().GrantAvatarPresetItemsToUser(grantAvatarPreset, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get all avatar presets
    /// </summary>
    public class GetAvatarPresets : Base
    {
        public int Status;
        public int Gender;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AvatarManagementApi().GetAvatarPresets(Status, Gender, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Retrive Avatar preset by ID
    /// </summary>
    public class GetAvatarPresetsByID : Base
    {
        public string avatarPresetID;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AvatarManagementApi().GetAvatarPresetsByID(avatarPresetID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get vertices for all buckets
    /// </summary>
    public class GetAllBucketVertices : Base
    {
        public string platform;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AvatarManagementApi().GetAllBucketVertices(platform, result, error);
            }
        }
    }

    /// <summary>
    /// Render Avatar Image
    /// </summary>
    public class RenderAvatarImage : Base
    {
        public string AvatarID;
        public string Platform;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new AvatarManagementApi();
                auth.RenderAvatarImage(new RenderAvatarImageRequest()
                {
                    AvatarID = AvatarID,
                    Platform = Platform,
                }, result, error);
            }
        }
    }

    public class BuildAvatarMesh : Base
    {
        public string AvatarID;
        public string Platform;
        public string AvatarData;

        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new AvatarManagementApi();
                auth.BuildAvatarMesh(new BuildAvatarMeshRequest()
                {
                    AvatarID = AvatarID,
                    Platform = Platform,
                    AvatarData = AvatarData
                }, result, error);
            }
        }
    }

    public class BuildAvatarImage : Base
    {
        public string AvatarID;
        public string Platform;
        public string AvatarData;

        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new AvatarManagementApi();
                auth.BuildAvatarImage(new BuildAvatarImageRequest()
                {
                    AvatarID = AvatarID,
                    Platform = Platform,
                    AvatarData = AvatarData
                }, result, error);
            }
        }
    }

    public class CreateAvatar : Base
    {
        public string Platform;
        public string AvatarData;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new AvatarManagementApi();
                auth.CreateAvatar(new CreateAvatarRequest()
                {
                    Platform = Platform,
                    AvatarData = AvatarData
                }, result, error);
            }
        }
    }

    public class UpdateAvatar : Base
    {
        public string Action;
        public string AvatarID;
        public string PatchData;
        public string PatchDataType;
        public override void CallApi(System.Action<object> result, System.Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new AvatarManagementApi();
                auth.UpdateAvatar(new UpdateAvatarRequest()
                {
                    Action = Action,
                    AvatarID = AvatarID,
                    PatchData = PatchData,
                    PatchDataType = PatchDataType
                }, result, error);
            }
        }
    }
}