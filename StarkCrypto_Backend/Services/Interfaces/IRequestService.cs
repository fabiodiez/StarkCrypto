using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace StarkCrypto.Services.Interfaces
{
    public interface IRequestService<T> where T : class, new()
    {
        T Post(IDictionary<string, string> headers, IDictionary<string, object> parameters, object body = null);
        Task<T> PostAsync(string Endpoint, IDictionary<string, string> headers, IDictionary<string, object> parameters, object body = null);
        T Get(string Endpoint, IDictionary<string, string> headers = null);
        Task<T> GetAsync(string Endpoint, IDictionary<string, string> headers = null);
    }
}
