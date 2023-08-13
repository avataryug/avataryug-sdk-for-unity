using System;
using Com.Avataryug.Api;
using Com.Avataryug.Model;
using Com.Avataryug.Client;
using System.Collections.Generic;

namespace Com.Avataryug.Handler
{
    /// <summary>
    /// The code defines a class called "UserDataManagementHandler" with constructors and a method for updating user data methods.
    /// The class uses a "Base" object to make an API call and provides callbacks for handling the result or any errors.
    /// </summary>
    public class UserDataManagementHandler
    {
        private Base baseApiCall;
        public UserDataManagementHandler() { }
        public UserDataManagementHandler(Base _baseApiCall)
        {
            baseApiCall = _baseApiCall;
        }


        /// <summary>
        /// Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void AddVirtualCurrencyToUser(Action<AddVirtualCurrencyToUserResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((AddVirtualCurrencyToUserResult)r); }, error);
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the user's inventory.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void ConsumeInstance(Action<ConsumeInstanceResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((ConsumeInstanceResult)r); }, error);
        }

        /// <summary>
        /// Retrieves the user's current inventory of virtual goods
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetUserInventory(Action<GetUserInventoryResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetUserInventoryResult)r); }, error);
        }

        /// <summary>
        /// Adds the specified items to the specified user's inventory
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GrantInstanceToUser(Action<GrantInstanceToUserResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GrantInstanceToUserResult)r); }, error);
        }

        /// <summary>
        /// Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase,
        /// as well as what the client believes the price to be. This lets the server fail the purchase if the price has changed.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void PurchaseInstance(Action<object> result, Action<ApiException> error)
        {
            baseApiCall.CallApi(result, error);
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount. It is possible to make a VC balance negative with this API.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void SubtractUserVirtualCurrency(Action<object> result, Action<ApiException> error)
        {
            baseApiCall.CallApi(result, error);
        }

        /// <summary>
        /// Delete specified Avatar for the user
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void DeleteUserAvatar(Action<DeleteUserAvatarResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((DeleteUserAvatarResult)r); }, error);
        }

        /// <summary>
        /// Update Avatar for the user
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UpdateUserAvatar(Action<UpdateUserAvatarResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UpdateUserAvatarResult)r); }, error);
        }

        /// <summary>
        /// Add Avatar to the user
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void AddUserAvatar(Action<AddUserAvatarResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((AddUserAvatarResult)r); }, error);
        }

        /// <summary>
        /// Lists all of the avatars that belong to a specific user
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetUsersAllAvatars(Action<GetUsersAllAvatarsResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetUsersAllAvatarsResult)r); }, error);
        }

        /// <summary>
        /// Opens the specified container, with the specified key (when required),
        /// and returns the contents of the opened container.
        /// If the container (and key when relevant) are consumable (RemainingUses > 0),
        /// their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void UnlockContainerInstance(Action<UnlockContainerInstanceResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((UnlockContainerInstanceResult)r); }, error);
        }

        /// <summary>
        /// Creates an order for a list of items that needs to be purchased
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void StartPurchase(Action<object> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((object)r); }, error);
        }

        /// <summary>
        /// Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and virtual currency balances as appropriate
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void ConfirmPurchase(Action<ConfirmPurchaseResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((ConfirmPurchaseResult)r); }, error);
        }

        /// <summary>
        /// Get the purchase detials 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetPurchase(Action<ConfirmPurchaseResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((ConfirmPurchaseResult)r); }, error);
        }

    }

    /// <summary>
    /// Lists all of the avatars that belong to a specific user
    /// </summary>
    public class GetUsersAllAvatars : Base
    {
        public string userID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.GetUsersAllAvatars(userID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Add Avatar to the user
    /// </summary>
    public class AddUserAvatar : Base
    {
        public string AvatarData;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.AddUserAvatar(new AddUserAvatarRequest()
                {
                    AvatarData = AvatarData,
                }
                , (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Update Avatar for the user
    /// </summary>
    public class UpdateUserAvatar : Base
    {
        public string AvatarID;
        public string AvatarData;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.UpdateUserAvatar(new UpdateUserAvatarRequest() { AvatarID = AvatarID, AvatarData = AvatarData },
                (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Delete specified Avatar for the user
    /// </summary>
    public class DeleteUserAvatar : Base
    {
        public string AvatarID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.DeleteUserAvatar(new DeleteUserAvatarRequest() { AvatarID = AvatarID }
                , (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Increments the user's balance of the specified virtual currency by the stated amount
    /// </summary>
    public class AddVirtualCurrencyToUser : Base
    {
        public int Amount;
        public string VirtualCurrency;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            var authApi = new UserDataManagementApi();
            authApi.AddVirtualCurrencyToUser(new AddVirtualCurrencyToUserRequest()
            {
                Amount = Amount,
                VirtualCurrency = VirtualCurrency
            }, (res) => { result?.Invoke(res); }, error);
        }
    }

    /// <summary>
    /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the user's inventory.
    /// </summary>
    public class ConsumeInstance : Base
    {
        public int InstanceCount;
        public string InstanceID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.ConsumeInstance(new ConsumeInstanceRequest()
                {
                    InstanceID = InstanceID,
                    InstanceCount = InstanceCount,

                }
                , (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Opens the specified container, with the specified key (when required), and returns the contents of the opened container.
    /// If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
    /// </summary>
    public class UnlockContainerInstance : Base
    {
        public string ContainerInstanceID;
        public string KeyInstanceID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new UserDataManagementApi().UnlockContainerInstance(new UnlockContainerInstanceRequest()
                { ContainerInstanceID = ContainerInstanceID, KeyInstanceID = KeyInstanceID }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Retrieves the user's current inventory of virtual goods
    /// </summary>
    public class GetUserInventory : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.GetUserInventory((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Adds the specified items to the specified user's inventory
    /// </summary>
    public class GrantInstanceToUser : Base
    {
        public List<GrantInstanceToUserRequestInstanceIDsInner> InstanceIDs;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.GrantInstanceToUser(new GrantInstanceToUserRequest() { InstanceIDs = InstanceIDs }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Buys a single item with virtual currency.
    /// You must specify both the virtual currency to use to purchase, as well as what the client believes the price to be.
    /// This lets the server fail the purchase if the price has changed.
    /// </summary>
    public class PurchaseInstance : Base
    {
        public InstanceType instanceType;
        public string InstanceID;
        public int Price;
        public string VirtualCurrency;
        public string StoreID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.PurchaseInstance(new PurchaseInstanceRequest()
                {
                    InstanceID = InstanceID,
                    VirtualCurrency = VirtualCurrency,
                    InstanceType = instanceType.ToString(),
                    Price = Price,
                    StoreID = StoreID
                }, result, error);
            }
        }
    }

    /// <summary>
    /// Decrements the user's balance of the specified virtual currency by the stated amount.
    /// It is possible to make a VC balance negative with this API.
    /// </summary>
    public class SubtractUserVirtualCurrency : Base
    {
        public int Amount;
        public string VirtualCurrency;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.SubtractUserVirtualCurrency(new SubtractUserVirtualCurrencyRequest() { Amount = Amount, VirtualCurrency = VirtualCurrency }, () => { result?.Invoke("CurrencyAdded"); }, (err) => { });
            }
        }
    }

    /// <summary>
    /// Creates an order for a list of items that needs to be purchased
    /// </summary>
    public class StartPurchase : Base
    {
        public string TransactionID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.StartPurchase((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Retrieves a purchase along with its current Avataryug status.
    /// Returns inventory items from the purchase that are still active.
    /// </summary>
    public class GetPurchase : Base
    {
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.GetPurchase((res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and virtual currency balances as appropriate
    /// </summary>
    public class ConfirmPurchase : Base
    {
        public string TransactionID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new UserDataManagementApi();
                authApi.ConfirmPurchase(new ConfirmPurchaseRequest() { TransactionID = TransactionID }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }
}
