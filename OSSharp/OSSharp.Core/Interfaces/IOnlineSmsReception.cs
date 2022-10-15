using OSSharp.Core.Entities.SmsReception.NumberStatistics;
using OSSharp.Core.Entities.SmsReception.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSSharp.Core.Interfaces
{
    interface IOnlineSmsReception
    {
        Task<Statistics> GetNumberStatistics();
        Task<Statistics> GetNumberStatistics(int countryCode);
        Task<ServiceModel> GetNumberStatistics (string serviceName);
        Task<NumberOrderRequest> OrderNumber (string serviceName, int country = 7, int[] reject = null, int extension = 0, int devId = 0, bool receiveNumber = false);
        Task<List<OrderInformation>> GetOrderState(int tzid = 0, bool showCodeMessage = false, int form = 0, string orderBy = null, int msgList = 0, int clean = 0);
    }
}
