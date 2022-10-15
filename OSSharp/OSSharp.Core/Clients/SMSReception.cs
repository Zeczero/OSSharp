using OSSharp.Core.Entities.SmsReception.NumberStatistics;
using OSSharp.Core.Entities.SmsReception.Order;
using OSSharp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OSSharp.Core.Clients
{
    public class SMSReception : Base, IOnlineSmsReception
    {
        public SMSReception(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<Statistics> GetNumberStatistics()
        {
            return await GetAsync<Statistics>(AddStringToQuery(ApiEndPoints.SmsOrderApiEndPoint.GetNumbersStats)).ConfigureAwait(false);
        }

        public async Task<ServiceModel> GetNumberStatistics(string serviceName)
        {
            string service = String.Join("", "service_", serviceName);
            var response = await GetAsync<Statistics>(AddStringToQuery(ApiEndPoints.SmsOrderApiEndPoint.GetNumbersStats, new Dictionary<string, object>
            {
                {"service", service }
            })).ConfigureAwait(false);

            return response.Services[service];
        }

        public async Task<Statistics> GetNumberStatistics(int countryCode)
        {
            var response = await GetAsync<Statistics>(AddStringToQuery(ApiEndPoints.SmsOrderApiEndPoint.GetNumbersStats, new Dictionary<string, object>
            {
                {"country", countryCode }

            })).ConfigureAwait(true);

            return response;
        }

        public async Task<List<OrderInformation>> GetOrderState(int tzid = 0, bool showCodeMessage = false, int form = 0, string orderBy = null, int msgList = 0, int clean = 0)
        {
            int choice = Convert.ToInt32(showCodeMessage);
            var response = await GetAsync<List<OrderInformation>>(AddStringToQuery(ApiEndPoints.SmsOrderApiEndPoint.GetNumberStatus, new Dictionary<string, object>
            {
                { "tzid", tzid },
                { "message_to_code", choice },
                { "form", form },
                { "orderby", orderBy },
                { "msg_list", msgList },
                { "clean", clean }

            })).ConfigureAwait(true);

            return response;
        }

        public async Task<NumberOrderRequest> OrderNumber(string serviceName, int country = 7, int[] reject = null, int extension = 0, int devId = 0, bool receiveNumber = false)
        {
            var response = await GetAsync<NumberOrderRequest>(AddStringToQuery(ApiEndPoints.SmsOrderApiEndPoint.BuyNumber, new Dictionary<string, object>
            {
                { "service", serviceName },
                { "country", country},
                { "reject", reject },
                { "extension", extension },
                { "dev_id", devId },
                { "number", receiveNumber }
            })).ConfigureAwait(true);

            return response;
        }
    }
}
