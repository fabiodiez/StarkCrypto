using Newtonsoft.Json;
using RestSharp;
using StarkCrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace StarkCrypto.Services
{
    public class RequestService<T> where T : class, new() //IRequestService<T>, new()
    {
        public T Post(string Endpoint, IDictionary<string, string> headers, IDictionary<string, object> parameters, object body = null)
        {
            T responseService = new T();

            RestResponse response = null;  

            try
            {
                var client = new RestClient(Endpoint);

                var request = new RestRequest();

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {                        
                        request.AddParameter(parameter.Key, parameter.Value.ToString());
                    }
                }

                if (body != null)
                {
                    request.RequestFormat = DataFormat.Json;

                    //request.JsonSerializer = new RestSharpJsonNetSerializer();

                    request.AddJsonBody(body);
                }

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    responseService = JsonConvert.DeserializeObject<T>(response.Content);
                }
            }
            catch (JsonReaderException ex)
            {
                throw new Exception($"Erro na api: EndPoint {Endpoint} - JsonException {ex.InnerException} - Content: {response.Content}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseService;
        }

        public async Task<T> PostAsync(string Endpoint, IDictionary<string, string> headers, IDictionary<string, object> parameters, object body = null)
        {
            T responseService = new T();

            RestResponse response = null;

            try
            {
                var client = new RestClient(Endpoint);

                var request = new RestRequest();

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        request.AddParameter(parameter.Key, parameter.Value.ToString());
                    }
                }

                if (body != null)
                {
                    request.RequestFormat = DataFormat.Json;

                    //request.JsonSerializer = new RestSharpJsonNetSerializer();

                    request.AddJsonBody(body);
                }

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                response = await client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    responseService = JsonConvert.DeserializeObject<T>(response.Content);
                }
            }
            catch (JsonReaderException ex)
            {
                throw new Exception($"Erro na api: EndPoint {Endpoint} - JsonException {ex.InnerException} - Content: {response.Content}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseService;
        }

        public T Get(string Endpoint, IDictionary<string, string> headers = null)
        {
            T responseService = new T();

            RestResponse response = null;

            try
            {
                var client = new RestClient(Endpoint);

                var request = new RestRequest();
                
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    responseService = JsonConvert.DeserializeObject<T>(response.Content);
                }
            }
            catch (JsonReaderException ex)
            {
                throw new Exception($"Erro na api: EndPoint {Endpoint} - JsonException {ex.InnerException} - Content: {response.Content}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseService;
        }

        public async Task<T> GetAsync(string Endpoint, IDictionary<string, string> headers = null)
        {
            T responseService = new T();

            RestResponse response = null;

            try
            {
                var client = new RestClient(Endpoint);

                var request = new RestRequest();

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }               

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                response = await client.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    responseService = JsonConvert.DeserializeObject<T>(response.Content);
                }
            }
            catch (JsonReaderException ex)
            {
                throw new Exception($"Erro na api: EndPoint {Endpoint} - JsonException {ex.InnerException} - Content: {response.Content}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return responseService;
        }
    }
}
