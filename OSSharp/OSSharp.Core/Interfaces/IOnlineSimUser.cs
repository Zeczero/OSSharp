using OSSharp.Core.Clients;
using OSSharp.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSSharp.Core.Interfaces
{
    interface IOnlineSimUser
    {
        Task<CashBalance> GetBalance();
    }
}
