using System.Net.Http;

namespace Blackbaud.SkyApiExample.Services
{
    public interface ISessionService
    {   
        void SetTokens(HttpResponseMessage response);
        void ClearTokens();
        string GetAccessToken();
        string GetRefreshToken();
    }
}