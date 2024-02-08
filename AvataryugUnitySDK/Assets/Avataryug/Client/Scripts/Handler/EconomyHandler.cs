using System;
using Com.Avataryug.Api;
using Com.Avataryug.Client;
using Com.Avataryug.Model;

namespace Com.Avataryug.Handler
{
    /// <summary>
    /// The "EconomyHandler" class handles bundle containers, currencies, and items for economy-related operations.
    /// It utilizes the "Base" class for making API calls and provides methods for managing
    /// bundles, currencies, store, and items within the economy system.
    /// </summary>
    public class EconomyHandler
    {
        private Base baseApiCall;
        public EconomyHandler() { }
        public EconomyHandler(Base _baseApiCall)
        {
            baseApiCall = _baseApiCall;
        }

        /// <summary>
        /// Get Economy Bundles by ID
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetEconomyBundleByID(Action<GetEconomyBundleByIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetEconomyBundleByIDResult)r); }, error);
        }

        /// <summary>
        /// Get Economy Bundles
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetEconomyBundles(Action<GetEconomyBundlesResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetEconomyBundlesResult)r); }, error);
        }

        /// <summary>
        /// Get Economy Container by ID
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetEconomyContainerByID(Action<GetEconomyContainerByIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetEconomyContainerByIDResult)r); }, error);
        }

        /// <summary>
        /// Get Economy Containers
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetEconomyContainers(Action<GetEconomyContainersResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetEconomyContainersResult)r); }, error);
        }

        /// <summary>
        /// Get Economy Items
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetEconomyItems(Action<GetEconomyItemsResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetEconomyItemsResult)r); }, error);
        }

        /// <summary>
        /// Get Economy Item by ID
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetEconomyItemsByID(Action<GetEconomyItemsByIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetEconomyItemsByIDResult)r); }, error);
        }

        /// <summary>
        /// Get Economy Stores
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetEconomyStores(Action<GetEconomyStoresResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetEconomyStoresResult)r); }, error);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetStoreItemsByID(Action<GetStoreItemsByIDResult> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetStoreItemsByIDResult)r); }, error);
        }
    }

    /// <summary>
    /// Get Economy Bundles by ID
    /// </summary>
    public class GetEconomyBundleByID : Base
    {
        public string bundleID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new EconomyApi().GetEconomyBundleByID(bundleID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get Economy Bundles
    /// </summary>
    public class GetEconomyBundles : Base
    {
        public int bundleStatus;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new EconomyApi().GetEconomyBundles(bundleStatus, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get Economy Container by ID
    /// </summary>
    public class GetEconomyContainerByID : Base
    {
        public string containerID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new EconomyApi().GetEconomyContainerByID(containerID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get Economy Containers
    /// </summary>
    public class GetEconomyContainers : Base
    {
        public int containerStatus;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new EconomyApi().GetEconomyContainers(containerStatus, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get Economy Items
    /// </summary>
    public class GetEconomyItems : Base
    {
        public string category;
        public int status;
        public int gender;
        public int offset;
        public int limit;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new EconomyApi().GetEconomyItems(category, status, gender, offset, limit, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get Economy Item by ID
    /// </summary>
    public class GetEconomyItemsByID : Base
    {
        public string itemID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new EconomyApi().GetEconomyItemsByID(itemID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Get Economy Stores
    /// </summary>
    public class GetEconomyStores : Base
    {
        public int storeStatus;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new EconomyApi().GetEconomyStores(storeStatus, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Retrieves the set of items defined for the specified store, including all prices defined
    /// </summary>
    public class GetStoreItemsByID : Base
    {
        public string storeID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new EconomyApi().GetStoreItemsByID(storeID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }
}