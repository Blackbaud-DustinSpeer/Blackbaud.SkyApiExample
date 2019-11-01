using System;
using System.Net.Http;

namespace Blackbaud.SkyApiExample.Services
{
    public interface IAuthenticationService
    {   
        HttpResponseMessage ExchangeCodeForAccessToken(string code);
        Uri GetAuthorizationUri();
        bool IsAuthenticated();
        void LogOut();
        HttpResponseMessage RefreshAccessToken();
    }
}