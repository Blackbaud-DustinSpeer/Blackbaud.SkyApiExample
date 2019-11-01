using System.Net.Http;

namespace Blackbaud.SkyApiExample.Services
{
    public interface IConstituentsService
    {   
        HttpResponseMessage GetConstituent(string id);
        HttpResponseMessage GetConstituents();
    }
}