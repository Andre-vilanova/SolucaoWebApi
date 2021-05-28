using Microsoft.AspNetCore.TestHost;

namespace SoftPlan.Calc.Integration.Tests.Helpers
{
    public class HttpServiceClient : BaseHttpServiceClient
    {
        public HttpServiceClient(TestServer cliente) : base(cliente)
        {
        }
    }
}