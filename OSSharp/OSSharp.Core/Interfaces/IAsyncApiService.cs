using System;
using System.Threading.Tasks;

namespace OSSharp.Core.Interfaces
{
    interface IAsyncApiService
    {
        Task<T> GetAsync<T>(Uri resource);
    }
}
