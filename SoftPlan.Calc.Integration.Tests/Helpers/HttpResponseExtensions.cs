
using System.Net.Http;
using Newtonsoft.Json;


namespace SoftPlan.Calc.Integration.Tests.Helpers
{
    public static class HttpResponseExtensions
    {
        public static Result<T> ConvertResponseMessageAsType<T>(this HttpResponseMessage response)
        {
            var responseBody = response.Content.ReadAsStringAsync().Result;
            var myResult = JsonConvert.DeserializeObject<Result<T>>(responseBody);
            return myResult;
        }
    }
}