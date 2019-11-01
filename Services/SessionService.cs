using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Blackbaud.SkyApiExample.Services
{
    
    /// <summary>
    /// Sets, gets, and destroys session variables.
    /// </summary>
    public class SessionService : ISessionService
    {
        private const string ACCESS_TOKEN_NAME = "token";
        private const string REFRESH_TOKEN_NAME = "refreshToken";
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        
        /// <summary>
        /// Destroys access and refresh tokens from the session.
        /// </summary>
        public void ClearTokens()
        {
            try 
            {
                _httpContextAccessor.HttpContext.Session.Remove(ACCESS_TOKEN_NAME);
                _httpContextAccessor.HttpContext.Session.Remove(REFRESH_TOKEN_NAME);
            }
            catch (Exception error)
            {
                Console.WriteLine("LOGOUT ERROR: " + error.Message);
            }
        }
        
        
        /// <summary>
        /// Return access token, if saved, or an empty string.
        /// </summary>
        public string GetAccessToken()
        {
            return TryGetString(ACCESS_TOKEN_NAME);
        }
        
        
        /// <summary>
        /// Return refresh token, if saved, or an empty string.
        /// </summary>
        public string GetRefreshToken()
        {
            return TryGetString(REFRESH_TOKEN_NAME);
        }
        
        
        /// <summary>
        /// Sets the access and refresh tokens based on an HTTP response.
        /// </summary>
        public void SetTokens(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions
            {
                
                IgnoreReadOnlyProperties = true
            };
            if (response.IsSuccessStatusCode)
            {
                string jsonString = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, dynamic> attrs = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(jsonString);
                _httpContextAccessor.HttpContext.Session.SetString(ACCESS_TOKEN_NAME, (string)attrs["access_token"].GetString());
                _httpContextAccessor.HttpContext.Session.SetString(REFRESH_TOKEN_NAME, (string)attrs["refresh_token"].GetString());
            }
        }
        
        
        /// <summary>
        /// Return session value as a string (if it exists), or an empty string.
        /// </summary>
        private string TryGetString(string name)
        {
            byte[] valueBytes = new Byte[700];
            bool valueOkay = _httpContextAccessor.HttpContext.Session.TryGetValue(name, out valueBytes);
            if (valueOkay)
            {
                return System.Text.Encoding.UTF8.GetString(valueBytes);
            }
            return null;
        }
    }
}