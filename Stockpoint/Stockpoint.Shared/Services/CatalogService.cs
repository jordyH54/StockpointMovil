using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Stockpoint.Shared.Models;

namespace Stockpoint.Shared.Services
{
    public class CatalogService
    {
        private readonly HttpClient _http;
        private readonly AppStateService _appState;
        private readonly Dictionary<string, List<CatalogItem>> _cache = new();

        public CatalogService(HttpClient http, AppStateService appState)
        {
            _http = http;
            _appState = appState;
        }

        public async Task<List<CatalogItem>> GetCatalogAsync(string catalogName)
        {
            if (_cache.TryGetValue(catalogName, out var cached)) return cached;

            try
            {
                var client = new GetClient
                {
                    R = new cResul
                    {
                        metodos = "obtGetClient",
                        Token = _appState.SysToken,
                        modulo = "Catalogos"
                    }
                }.GetClientConfigured();

                var response = await client.PostAsJsonAsync("WebServices/CatalogosA", new
                {
                    Catalogo = catalogName,
                    R = new cResul
                    {
                        modulo = _appState.CurrentPage,
                        metodos = "Cargar",
                        Token = _appState.SysToken,
                    }
                });

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<CatalogItem>>();
                    _cache[catalogName] = result ?? new List<CatalogItem>();
                    return _cache[catalogName];
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading catalog {catalogName}: {ex.Message}");
            }

            return new List<CatalogItem>();
        }

        public void ClearCache(string catalogName)
        {
            _cache.Remove(catalogName);
        }

        public class CatalogItem
        {
            public string Valor { get; set; }
            public string Texto { get; set; }
        }
    }
}
