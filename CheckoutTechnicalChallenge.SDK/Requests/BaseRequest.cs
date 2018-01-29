using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK.Requests
{
    public abstract class BaseRequest
    {
        public string baseUrl => "http://localhost:49921/";
        public abstract string requestUrl { get; }
        public abstract string jsonString { get; }

        public string Get()
        {
            // Make Request
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(requestUrl).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Request was not succesfully made");
                }
                string returnString = response.Content.ReadAsStringAsync().Result;
                return returnString;
            }
        }

        public string Post()
        {
            // Make Request
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(requestUrl, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Request was not succesfully made");
                }
                string returnString = response.Content.ReadAsStringAsync().Result;
                return returnString;
            }
        }

        public string Put()
        {
            // Make Request
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsync(requestUrl, new StringContent(jsonString, Encoding.UTF8, "application/json")).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Request was not succesfully made");
                }
                string returnString = response.Content.ReadAsStringAsync().Result;
                return returnString;
            }
        }

        public string Delete()
        {
            // Make Request
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync(requestUrl).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Request was not succesfully made");
                }
                string returnString = response.Content.ReadAsStringAsync().Result;
                return returnString;
            }
        }


        public string Patch()
        {
            // Make Request
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, requestUrl)
                {
                    Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = new HttpResponseMessage();
                response = client.SendAsync(request).Result;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Request was not succesfully made");
                }
                string returnString = response.Content.ReadAsStringAsync().Result;
                return returnString;
            }
        }
    }
}
