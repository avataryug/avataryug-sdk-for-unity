using System;
using Com.Avataryug.Api;
using Com.Avataryug.Model;
using Com.Avataryug.Client;

namespace Com.Avataryug.Handler
{
    /// <summary>
    /// The "AdvertisingHandler" class is responsible for handling advertising operations.
    /// It uses the "Base" class for making API calls.
    /// The class provides three methods:
    /// "GetAdsPlacement" retrieves a list of ad placements by ID,
    /// "RecordAdsActivity" stores ads activity data for reporting, and
    /// "GrantAdsReward" grants rewards for ads.
    /// Each method takes callbacks for handling the response and error conditions.
    /// </summary>
    public class AdvertisingHandler
    {
        public Base baseApiCall;
        public AdvertisingHandler() { }
        public AdvertisingHandler(Base _baseApiCall)
        {
            baseApiCall = _baseApiCall;
        }

        /// <summary>
        /// Retrieves a list of ad placements by ID
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GetAdsPlacement(Action<GetAdsPlacementResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GetAdsPlacementResponse)r); }, error);
        }

        /// <summary>
        /// Stores ads activity data for reporting after ad watch 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void RecordAdsActivity(Action<RecordAdsActivityResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((RecordAdsActivityResponse)r); }, error);
        }

        /// <summary>
        /// Grants rewards for ads. 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="error"></param>
        public void GrantAdsReward(Action<GrantAdsRewardResponse> result, Action<ApiException> error)
        {
            baseApiCall.CallApi((r) => { result?.Invoke((GrantAdsRewardResponse)r); }, error);
        }
    }

    /// <summary>
    /// Retrieves a list of ad placements by ID
    /// </summary>
    public class GetAdsPlacement : Base
    {
        public string appID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AdvertisingApi();
                authApi.GetAdsPlacement(appID, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Stores ads activity data for reporting after ad watch 
    /// </summary>
    public class RecordAdsActivity : Base
    {
        public string RevenueCurrency;
        public int AdRevenue;
        public string PlacementID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                var authApi = new AdvertisingApi();
                authApi.RecordAdsActivity(new RecordAdsActivityRequest()
                {
                    AdRevenue = AdRevenue,
                    PlacementID = PlacementID,
                    RevenueCurrency = RevenueCurrency
                }, (res) => { result?.Invoke(res); }, error);
            }
        }
    }

    /// <summary>
    /// Grants rewards for ads. 
    /// </summary>
    public class GrantAdsReward : Base
    {
        public string PlacementID;
        public override void CallApi(Action<object> result, Action<ApiException> error)
        {
            if (Configuration.ProjectIdPresent)
            {
                Configuration.SetApi();
                new AdvertisingApi().GrantAdsReward(new GrantAdsRewardRequest() { PlacementID = PlacementID }, result, error);
            }
        }
    }
}

