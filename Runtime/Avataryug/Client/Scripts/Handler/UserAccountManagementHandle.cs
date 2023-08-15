using System;
using Com.Avataryug.Api;
using Com.Avataryug.Client;
using Com.Avataryug.Model;

namespace Com.Avataryug.Handler
{
    /// <summary>
    /// The "UserAccountManagementHandle" class manages user account-related operations through the use of the "Base" class.
    /// It provides a variety of methods for tasks such as
    /// changing passwords, deleting user accounts, updating user demographics, verifying users with email, and more.
    /// These methods utilize the "baseApiCall" instance to make API calls and handle responses and errors through callbacks.
    /// </summary>
    public class UserAccountManagementHandle
    {
        private Base baseApiCall;
        public UserAccountManagementHandle() { }
        public UserAccountManagementHandle(Base _baseApiCall)
        {
            baseApiCall = _baseApiCall;
        }

        /// <summary>
        /// Allows users to change their password.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void ChangePassword(Action<ChangePasswordResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((ChangePasswordResponse)r); }, error);
        }

        /// <summary>
        /// Deletes a user account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void DeleteUser(Action<DeleteUserResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((DeleteUserResponse)r); }, error);
        }

        /// <summary>
        /// Updates user demographic information.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UpdateUserDemographics(Action<UpdateUserDemographicsResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UpdateUserDemographicsResponse)r); }, error);
        }

        /// <summary>
        /// Verifies a user's email address.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void VerifyUserWithEmail(Action<VerifyUserWithEmailResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((VerifyUserWithEmailResponse)r); }, error);
        }

        /// <summary>
        /// Updates the user's email and password.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UpdateEmailPassword(Action<UpdateEmailPasswordResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UpdateEmailPasswordResponse)r); }, error);
        }

        /// <summary>
        /// Sends an account verification email to the user.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void SendAccountVerificationEmail(Action<SendAccountRecoveryEmailResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((SendAccountRecoveryEmailResponse)r); }, error);
        }

        /// <summary>
        /// Sends an account recovery email to the user.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void SendAccountRecoveryEmail(Action<SendAccountVerificationEmailResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((SendAccountVerificationEmailResponse)r); }, error);
        }

        /// <summary>
        /// Adds an email and password to the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void AddEmailPassword(Action<AddEmailPasswordResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((AddEmailPasswordResult)r); }, error);
        }

        /// <summary>
        /// Adds the specified generic service identifier to the user's Avataryug account.
        /// This is designed to allow for a Avataryug ID lookup of any arbitrary service identifier a Project wants to add.
        /// This identifier should never be used as authentication credentials, as the intent is that it is easily accessible by other users.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void AddGenericServiceID(Action<AddGenericServiceIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((AddGenericServiceIDResult)r); }, error);
        }

        /// <summary>
        /// Retrieves information about the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetUserAccountInfo(Action<GetUserAccountInfoResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetUserAccountInfoResult)r); }, error);
        }

        /// <summary>
        /// Retrieves the user's public profile information.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetUserProfile(Action<GetUserProfileResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetUserProfileResult)r); }, error);
        }

        /// <summary>
        /// Links an Android device ID to the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LinkAndroidDeviceID(Action<LinkAndroidDeviceIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LinkAndroidDeviceIDResult)r); }, error);
        }

        /// <summary>
        /// Links an Apple account to the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LinkApple(Action<LinkAppleResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LinkAppleResult)r); }, error);
        }

        /// <summary>
        /// Links a custom ID to the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LinkCustomID(Action<LinkCustomIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LinkCustomIDResult)r); }, error);
        }

        /// <summary>
        /// Links a Facebook account to the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LinkFacebookAccount(Action<LinkFacebookAccountResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LinkFacebookAccountResult)r); }, error);
        }

        /// <summary>
        /// Links a Google account to the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LinkGoogleAccount(Action<LinkGoogleAccountResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LinkGoogleAccountResult)r); }, error);
        }

        /// <summary>
        /// Links an iOS device ID to the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void LinkIOSDeviceID(Action<LinkIOSDeviceIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((LinkIOSDeviceIDResult)r); }, error);
        }

        /// <summary>
        /// Removes a generic service ID from the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void RemoveGenericServiceID(Action<RemoveGenericServiceIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((RemoveGenericServiceIDResult)r); }, error);
        }

        /// <summary>
        /// Unlinks an Android device ID from the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UnlinkAndroidDeviceID(Action<UnlinkAndroidDeviceIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UnlinkAndroidDeviceIDResult)r); }, error);
        }

        /// <summary>
        /// Unlinks an Apple account from the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UnlinkApple(Action<UnlinkAppleResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UnlinkAppleResult)r); }, error);
        }

        /// <summary>
        /// Unlinks a custom ID from the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UnlinkCustomID(Action<UnlinkCustomIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UnlinkCustomIDResult)r); }, error);
        }

        /// <summary>
        /// Unlinks a Facebook account from the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UnlinkFacebookAccount(Action<UnlinkFacebookAccountResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UnlinkFacebookAccountResult)r); }, error);
        }

        /// <summary>
        /// Unlinks a Google account from the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UnlinkGoogleAccount(Action<UnlinkGoogleAccountResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UnlinkGoogleAccountResult)r); }, error);
        }

        /// <summary>
        /// Unlinks an iOS device ID from the user's account.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UnlinkIOSDeviceID(Action<UnlinkIOSDeviceIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UnlinkIOSDeviceIDResult)r); }, error);
        }

        /// <summary>
        /// Updates the display name of the user in the project.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UpdateUserProjectDisplayName(Action<UpdateUserProjectDisplayNameResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UpdateUserProjectDisplayNameResult)r); }, error);
        }

        /// <summary>
        /// Updates the default avatar ID for the user.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UpdateDefaultAvatarID(Action<UpdateDefaultAvatarIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UpdateDefaultAvatarIDResult)r); }, error);
        }

    }

    /// <summary>
    ///Allows users to change their password.
    /// </summary>
    public class ChangePassword : Base
    {
        public string OldPassword;
        public string NewPassword;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();

                authApi.ChangePassword(new ChangePasswordRequest()
                {
                    OldPassword = OldPassword,
                    NewPassword = NewPassword
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Delete User Account from Avataryug platform.
    /// </summary>
    public class DeleteUser : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new UserAccountManagementApi();
                auth.DeleteUser(new DeleteUserRequest() { }, result, error);
            }
        }
    }

    /// <summary>
    /// Updates user demographic information.
    /// </summary>
    public class UpdateUserDemographics : Base
    {
        public string Gender;
        public string AgeRange;
        public string Race;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UpdateUserDemographics(new UpdateUserDemographicsRequest()
                {
                    AgeRange = AgeRange,
                    Gender = Gender,
                    Race = Race
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Verifies user account status to email verified once email verification is done
    /// </summary>
    public class VerifyUserWithEmail : Base
    {
        public string UserID;
        public string VerificationCode;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();

                authApi.VerifyUserWithEmail(new VerifyUserWithEmailRequest()
                {
                    UserID = UserID,
                    VerificationCode = VerificationCode
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Updates the user's email and password.
    /// </summary>
    public class UpdateEmailPassword : Base
    {
        public string EmailID;
        public string Password;
        public string VerificationCode;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();

                authApi.UpdateEmailPassword(new UpdateEmailPasswordRequest()
                {
                    EmailID = EmailID,
                    Password = Password,
                    VerificationCode = VerificationCode

                }, (res) => { result?.Invoke(res); }, error);

            }
        }
    }

    /// <summary>
    /// Sends an account verification email to the user.
    /// </summary>
    public class SendAccountVerificationEmail : Base
    {
        public string EmailID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.SendAccountVerificationEmail(new SendAccountVerificationEmailRequest()
                {
                    EmailID = EmailID
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Sends an account recovery email to the user.
    /// </summary>
    public class SendAccountRecoveryEmail : Base
    {
        public string EmailID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var auth = new UserAccountManagementApi();
                auth.SendAccountRecoveryEmail(new SendAccountRecoveryEmailRequset()
                {
                    EmailID = EmailID
                }, result, error); ;
            }
        }
    }

    /// <summary>
    /// Adds an email and password to the user's account.
    /// </summary>
    public class AddEmailPassword : Base
    {
        public string EmailID;
        public string Password;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.AddEmailPassword(new AddEmailPasswordRequest()
                {
                    EmailID = EmailID,
                    Password = Password,
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Adds the specified generic service identifier to the user's Avataryug account.
    /// This is designed to allow for a Avataryug ID lookup of any arbitrary service identifier a Project wants to add.
    /// This identifier should never be used as authentication credentials, as the intent is that it is easily accessible by other users.
    /// </summary>
    public class AddGenericServiceID : Base
    {
        public string GenericServiceID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.AddGenericServiceID(new AddGenericServiceIDRequest()
                {
                    GenericServiceID = GenericServiceID
                }
                , (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Retrieves information about the user's account.
    /// </summary>
    public class GetUserAccountInfo : Base
    {
        public string userID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.GetUserAccountInfo(userID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Retrieves the user's public profile information.
    /// </summary>
    public class GetUserProfile : Base
    {
        public string userID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new UserAccountManagementApi().GetUserProfile(userID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Links the Android device identifier to the user's Avataryug account
    /// </summary>
    public class LinkAndroidDeviceID : Base
    {
        public string AndroidDeviceID;
        public bool ForceLink;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.LinkAndroidDeviceID(new LinkAndroidDeviceIDRequest()
                {
                    AndroidDeviceID = AndroidDeviceID,
                    ForceLink = ForceLink
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Links the Apple account associated with the token to the user's Avataryug account.
    /// </summary>
    public class LinkApple : Base
    {
        public string AppleID;
        public bool ForceLink;
        public string IdentityToken;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.LinkApple(new LinkAppleRequest()
                {
                    AppleID = AppleID,
                    ForceLink = ForceLink,
                    IdentityToken = IdentityToken
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Links the custom identifier, generated by the Project, to the user's Avataryug account
    /// </summary>
    public class LinkCustomID : Base
    {
        public string CustomID;
        public bool ForceLink;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.LinkCustomID(new LinkCustomIDRequest()
                {
                    CustomID = CustomID,
                    ForceLink = ForceLink
                }
            , (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Links the Facebook account associated with the provided Facebook access token to the user's Avataryug account
    /// </summary>
    public class LinkFacebookAccount : Base
    {
        public string FacebookID;
        public bool ForceLink;
        public string AccessToken;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.LinkFacebookAccount(new LinkFacebookAccountRequest()
                {
                    AccessToken = AccessToken,
                    FacebookID = FacebookID,
                    ForceLink = ForceLink
                }
            , (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Links the currently signed-in user account to their Google account, using their Google account credentials
    /// </summary>
    public class LinkGoogleAccount : Base
    {
        public string GoogleServerAuthCode;
        public bool ForceLink;
        public string GoogleID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.LinkGoogleAccount(new LinkGoogleAccountRequest()
                {
                    GoogleServerAuthCode = GoogleServerAuthCode,
                    ForceLink = ForceLink,
                    GoogleID = GoogleID
                }
            , (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Links the vendor-specific iOS device identifier to the user's Avataryug account
    /// </summary>
    public class LinkIOSDeviceID : Base
    {
        public string DeviceID;
        public bool ForceLink;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.LinkIOSDeviceID(new LinkIOSDeviceIDRequest() { DeviceID = DeviceID, ForceLink = ForceLink }
            , (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Removes the generic service identifier from the user's Avataryug account.
    /// </summary>
    public class RemoveGenericServiceID : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.RemoveGenericServiceID((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Unlinks the related Android device identifier from the user's Avataryug account
    /// </summary>
    public class UnlinkAndroidDeviceID : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UnlinkAndroidDeviceID((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Unlinks the related Apple account from the user's Avataryug account.
    /// </summary>
    public class UnlinkApple : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UnlinkApple((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Unlinks the related custom identifier from the user's Avataryug account
    /// </summary>
    public class UnlinkCustomID : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UnlinkCustomID((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Unlinks the related Facebook account from the user's Avataryug account
    /// </summary>
    public class UnlinkFacebookAccount : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UnlinkFacebookAccount((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Unlinks the related Google account from the user's Avataryug account
    /// </summary>
    public class UnlinkGoogleAccount : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UnlinkGoogleAccount((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Unlinks the related iOS device identifier from the user's Avataryug account
    /// </summary>
    public class UnlinkIOSDeviceID : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UnlinkIOSDeviceID((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Updates the display name for the user in the project
    /// </summary>
    public class UpdateUserProjectDisplayName : Base
    {
        public string DisplayName;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UpdateUserProjectDisplayName(new UpdateUserProjectDisplayNameRequest() { DisplayName = DisplayName },
                (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Sets the default avatar ID to users account
    /// </summary>
    public class UpdateDefaultAvatarID : Base
    {
        public string Avatarid;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserAccountManagementApi();
                authApi.UpdateDefaultAvatarID(new UpdateDefaultAvatarIDRequest()
                {
                    DefaultAvatarID = Avatarid
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

}
